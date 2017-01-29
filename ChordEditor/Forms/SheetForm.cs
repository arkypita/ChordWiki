using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FastColoredTextBoxNS;


namespace ChordEditor.Forms
{
    public partial class SheetForm : ChordEditor.UserControls.DockingManager.DockContent
    {
        public delegate void SheetFormDelegate(SheetForm sf);
        public static event SheetFormDelegate DelayedTextChanged;
        public static event SheetFormDelegate HeaderChanged;

        private Core.Sheet mSheet;
        private Core.ChordNotation mSheetNotation;
        private bool mNormalized;
		private bool mForceClose = false;

		TextStyle mChordStyle = new TextStyle(Brushes.OliveDrab, null, FontStyle.Regular);
		TextStyle mMetaStyle = new TextStyle(Brushes.Brown, null, FontStyle.Regular);

        private SheetForm()
        {
            InitializeComponent();
        }

        private SheetForm(Core.Sheet sheet)
        {
            InitializeComponent();
            mSheet = sheet;

			FSW.Path = System.IO.Path.GetDirectoryName(sheet.Header.FilePath);
			FSW.Filter = System.IO.Path.GetFileName(sheet.Header.FilePath);

            TB.Text = sheet.Content;
			TB.ClearUndo();
			TB_ZoomChanged(null, null);

			CbZoom.Items.Add(String.Format("{0} %", 50));
			CbZoom.Items.Add(String.Format("{0} %", 70));
			CbZoom.Items.Add(String.Format("{0} %", 90));
			CbZoom.Items.Add(String.Format("{0} %", 100));
			CbZoom.Items.Add(String.Format("{0} %", 125));
			CbZoom.Items.Add(String.Format("{0} %", 150));
			CbZoom.Items.Add(String.Format("{0} %", 175));
			CbZoom.Items.Add(String.Format("{0} %", 200));
			CbZoom.Items.Add(String.Format("{0} %", 300));

            MnUndo.ShortcutKeys = GetShortCut(FastColoredTextBoxNS.FCTBAction.Undo);
            MnRedo.ShortcutKeys = GetShortCut(FastColoredTextBoxNS.FCTBAction.Redo);
            MnCut.ShortcutKeys = GetShortCut(FastColoredTextBoxNS.FCTBAction.Cut);
            MnCopy.ShortcutKeys = GetShortCut(FastColoredTextBoxNS.FCTBAction.Copy);
            MnPaste.ShortcutKeys = GetShortCut(FastColoredTextBoxNS.FCTBAction.Paste);
            MnSelectAll.ShortcutKeys = GetShortCut(FastColoredTextBoxNS.FCTBAction.SelectAll);


            Core.Sheet.SheetChange += Sheet_SheetChange;
        }

        private Keys GetShortCut(FastColoredTextBoxNS.FCTBAction action)
        {
            foreach (KeyValuePair<Keys, FastColoredTextBoxNS.FCTBAction> kvp in TB.HotkeysMapping)
                if (action == kvp.Value)
                    return kvp.Key;
            return Keys.None;
        }

		private void TryReloadRetry()
		{
			try
			{
				Sheet.ReloadFile();
				TB.Text = Sheet.Content;
				TB.ClearUndo();
			}
			catch {RetryReload.Start();}
		}

		private void RetryReload_Tick(object sender, EventArgs e)
		{
			RetryReload.Stop();
			TryReloadRetry();
		}

        private void SheetForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Core.Sheet.SheetChange -= Sheet_SheetChange;
        }

        void Sheet_SheetChange(Core.Sheet s)
        {
            if (object.Equals(mSheet, s))
                RefreshTitle();
        }

        private void RefreshTitle()
        {
            if (mSheet.Header.Title != null && mSheet.Header.Artist != null)
            {
                ToolTipText = mSheet.Header.Artist + " - " + mSheet.Header.Title;
                Text = mSheet.Header.Title;
            }
            else if (mSheet.Header.Title != null)
            {
                ToolTipText = Text = mSheet.Header.Title;
            }
            else
            {
                ToolTipText = Text = "New sheet";
            }

            if (mSheet.HasMemoryChanges)
                Text = "* " + Text;
        }

        public static void CreateAndShow(Core.Sheet sheet, UserControls.DockingManager.DockPanel panel)
        {
            SheetForm sf = new SheetForm(sheet);
            sf.Show(panel);
        }

        public MenuStrip GetMenu()
        {
            return null;
        }
        public ToolBar GetToolBar()
        {
            return null;
        }

        internal bool Save(bool reloadDB)
        {
            if (mSheet.HasMemoryChanges)
            {
                if (mSheet.Header.Title == null || mSheet.Header.Title.Trim().Length == 0) //no song title!
                {
                    System.Windows.Forms.MessageBox.Show("Invalid song title!\r\nPlease complete sheet information.", "Save error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                mSheet.Save();
                if (reloadDB) Core.Program.SheetDB.ReloadDataBase();
            }

            return true;
        }

        internal void Print()
        {
            //throw new NotImplementedException();
        }

        internal void SaveAs()
        {
            //throw new NotImplementedException();
        }

        internal void PrintPreview()
        {
            //throw new NotImplementedException();
        }

        private void SheetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mSheet.HasMemoryChanges && !mForceClose)
            {
                DialogResult rv = System.Windows.Forms.MessageBox.Show("This file contains changes.\r\nSave changes?", "Close confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (rv == System.Windows.Forms.DialogResult.Yes)
                    e.Cancel = !Save(true);
                else if (rv == System.Windows.Forms.DialogResult.Cancel)
                    e.Cancel = true;
            }
        }


        public Core.Sheet Sheet
        { get { return mSheet; } }

		public FastColoredTextBoxNS.FastColoredTextBox Editor
		{ get { return TB; } }

        private void TB_TextChangedDelayed(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            mSheet.Content = TB.Text;
            Analyze();

            if (DelayedTextChanged != null)
                DelayedTextChanged(this);
        }

		private void CbZoom_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				TB.Zoom = int.Parse(((string)CbZoom.SelectedItem).Trim(" %".ToCharArray()));
			}
			catch { TB_ZoomChanged(null, null); }
		}

		private void TB_ZoomChanged(object sender, EventArgs e)
		{
			int newval = Math.Min(Math.Max(TB.Zoom, 50), 300);
			if (TB.Zoom != newval)
				TB.Zoom = newval;

			CbZoom.Text = String.Format("{0} %", TB.Zoom);
		}

		private void CbZoom_Validating(object sender, CancelEventArgs e)
		{
			try
			{
				TB.Zoom = int.Parse(((string)CbZoom.Text).Trim(" %".ToCharArray()));
			}
			catch { TB_ZoomChanged(null, null); }
		}

		private void TB_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
		{
           //clear previous highlighting
			e.ChangedRange.ClearStyle();
            //highlight tags
            e.ChangedRange.SetStyle(mChordStyle, @"\[(.*?)\]");
            e.ChangedRange.SetStyle(mMetaStyle, @"{[^}]+}");
		}

        private void Analyze()
        {

			int Unknown = 0;
			int Italian = 0;
			int American = 0;

			//get matches with different notations
            bool normal = true;
			System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\[(.*?)\]", System.Text.RegularExpressions.RegexOptions.Compiled);
			foreach (System.Text.RegularExpressions.Match m in regex.Matches(TB.Text))
			{
				string text = m.Groups[1].Value; //estrai il gruppo ricercato, ovvero solo il contenuto delle parentesi quadre
				Core.Chord c = Core.Pagliaro.GetChord(text);

				if (c.Notation == Core.ChordNotation.Italian)
					Italian++;
				else if (c.Notation == Core.ChordNotation.American)
					American++;
				else
					Unknown++;

                if (text != c.Normalized)
                    normal = false;
            }

            mNormalized = normal;

			if (Italian > 0 && Italian >= American && Italian >= Unknown)
				mSheetNotation = Core.ChordNotation.Italian;
			else if (American > 0 && American >= Italian && American >= Unknown)
				mSheetNotation = Core.ChordNotation.American;
			else
				mSheetNotation = Core.ChordNotation.Unknown;
        }


        public Core.ChordNotation SheetNotation
        {get { return mSheetNotation; }}

        public bool IsNormalized
        { get { return mNormalized; } }

        internal void ChangeNotation()
        {
            Core.ChordNotation targetNotation = Core.ChordNotation.Unknown;
            if (SheetNotation == Core.ChordNotation.Italian)
                targetNotation = Core.ChordNotation.American;
            else if (SheetNotation == Core.ChordNotation.American)
                targetNotation = Core.ChordNotation.Italian;

            if (targetNotation != Core.ChordNotation.Unknown)
                TB.Text = Core.Program.ChangeNotation(TB.Text, targetNotation);


        }

		public bool ForceCloseWhenDelete()
		{
			mForceClose = true;
			Close();
			return true;
		}

		private void FSW_Deleted(object sender, System.IO.FileSystemEventArgs e)
		{
			VT.Enabled = true;
		}

		private void FSW_Changed(object sender, System.IO.FileSystemEventArgs e) //quando viene semplicemente sovrascritto
		{
			TryReloadRetry();
		}

		private void FSW_Created(object sender, System.IO.FileSystemEventArgs e) //quando viene cancellato e ricreato
		{
			TryReloadRetry();
		}

		private void VT_Tick(object sender, EventArgs e)
		{
			VT.Enabled = false;

			if (!System.IO.File.Exists(Sheet.Header.FilePath)) //se è stato eliminato per davvero -> chiudi
				ForceCloseWhenDelete();
		}



        internal void Traspose(int semitones)
        {
            TB.Text = Core.Program.Traspose(TB.Text, semitones);
        }

        internal void Normalize()
        {
            TB.Text = Core.Program.Normalize(TB.Text);
        }

        private void TB_Pasting(object sender, TextChangingEventArgs e)
        {
            Core.Importer.ImportedContent content = Core.Importer.ImportClipbord(e.InsertingText, true);

            if (content != null)
            {
                if (content.Artist != null)
                    mSheet.Header.Artist = content.Artist;

                if (content.Title != null)
                    mSheet.Header.Title = content.Title;

                if (content.Title != null || content.Artist != null)
                    if (HeaderChanged != null)
                        HeaderChanged(this);

                e.InsertingText = content.Text;
            }

            e.Cancel = (content == null);
        }

        private void ActionUndo(object sender, EventArgs e)
        {
            TB.Undo();
        }

        private void ActionRedo(object sender, EventArgs e)
        {
            TB.Redo();
        }

        private void SelectionCut(object sender, EventArgs e)
        {
            TB.Cut();
        }

        private void SelectionCopy(object sender, EventArgs e)
        {
            TB.Copy();
        }

        private void SelectionPaste(object sender, EventArgs e)
        {
            TB.Paste();
        }

        private void ActionSelectAll(object sender, EventArgs e)
        {
            TB.SelectAll();
        }

        private void CMS_Opening(object sender, CancelEventArgs e)
        {
            MnUndo.Enabled = TB.UndoEnabled;
            MnRedo.Enabled = TB.RedoEnabled;
            MnCut.Enabled = !string.IsNullOrEmpty(TB.SelectedText);
            MnCopy.Enabled = !string.IsNullOrEmpty(TB.SelectedText);
            MnPaste.Enabled = Clipboard.ContainsText();
            MnSelectAll.Enabled = !string.IsNullOrEmpty(TB.Text);
        }
    }
}
