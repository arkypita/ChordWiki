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

		TextStyle mChordCOTStyle = new TextStyle(Brushes.Black, null, FontStyle.Bold);
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

            CHP.Text = sheet.Content;
            CHP.ClearUndo();
            CHPZoomChanged(null, null);

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
            foreach (KeyValuePair<Keys, FastColoredTextBoxNS.FCTBAction> kvp in CHP.HotkeysMapping)
                if (action == kvp.Value)
                    return kvp.Key;
            return Keys.None;
        }

        private void TryReloadRetry()
        {
            try
            {
                Sheet.ReloadFile();
                CHP.Text = Sheet.Content;
                CHP.ClearUndo();
            }
            catch { RetryReload.Start(); }
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
        { get { return CHP; } }

        private void CHPTextChangedDelayed(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            mSheet.Content = CHP.Text;
            Analyze();

            if (DelayedTextChanged != null)
                DelayedTextChanged(this);

            RefreshPreview();
        }

		private void RefreshPreview()
		{
			StringBuilder text = new StringBuilder();

			using (System.IO.StringReader sr = new System.IO.StringReader(CHP.Text))
			{
				string line = null;
				while ((line = sr.ReadLine()) != null)
				{
					//split chord and text;
					System.Text.RegularExpressions.MatchCollection matches = Core.RegexList.Chords.ChordProNote.Matches(line);
					if (matches.Count == 0)
					{
						text.Append(line + "\r\n");
					}
					else
					{
						int offset = 0;
						string chords = "";
						foreach (System.Text.RegularExpressions.Match match in matches)
						{
							string cval = match.Groups[1].Value;

							int position = match.Index - offset; //posizione dell'accordo corrente - cumulativo di tutti quelli che ho già tolto
							offset += match.Length;

							chords = chords + new string(' ', Math.Max(1, position - chords.Length)); //aggiungi spazi bianchi, almeno 1
							chords = chords + cval;
						}
						string song = Core.RegexList.Chords.ChordProNote.Replace(line, "");

						text.Append(chords + "\r\n");
						text.Append(song + "\r\n");
					}
				}
			}


			COT.Text = text.ToString();
		}



        private void CbZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CHP.Zoom = int.Parse(((string)CbZoom.SelectedItem).Trim(" %".ToCharArray()));
            }
            catch { CHPZoomChanged(null, null); }
        }

        private void CHPZoomChanged(object sender, EventArgs e)
        {
            int newval = Math.Min(Math.Max(CHP.Zoom, 50), 300);
            if (CHP.Zoom != newval)
                CHP.Zoom = newval;

            CbZoom.Text = String.Format("{0} %", CHP.Zoom);
        }

        private void CbZoom_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                CHP.Zoom = int.Parse(((string)CbZoom.Text).Trim(" %".ToCharArray()));
            }
            catch { CHPZoomChanged(null, null); }
        }

        private void CHPTextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            //clear previous highlighting
            e.ChangedRange.ClearStyle();
            //highlight tags
            e.ChangedRange.SetStyle(mChordStyle, @"\[(.*?)\]");
            e.ChangedRange.SetStyle(mMetaStyle, @"{[^}]+}");
        }


		private void COTTextChanged(object sender, TextChangedEventArgs e)
		{
			//clear previous highlighting
			e.ChangedRange.ClearStyle();
			//highlight tags
			e.ChangedRange.SetStyle(mChordCOTStyle, @"(?<=^| |\r\n)(?:(?:(?:DO|RE|MI|FA|SOL|LA|SI|Do|Re|Mi|Fa|Sol|La|Si)|(?:[CDEFGAB]))(?:#|♯|b|♭)?(?:\+|M|MAJ|maj|-|MIN|min|m|SUS|sus|ECC|ecc|DIM|dim)?(?:(?:\d){1,2}(?:\+)?)?)(?= |$|\r\n)");
		}

        private void Analyze()
        {

            int Unknown = 0;
            int Italian = 0;
            int American = 0;

            //get matches with different notations
            bool normal = true;
            foreach (System.Text.RegularExpressions.Match m in Core.RegexList.Chords.ChordProNote.Matches(CHP.Text))
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

            GenerateAutocomplete();
        }


        public Core.ChordNotation SheetNotation
        { get { return mSheetNotation; } }

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
                CHP.Text = Core.Program.ChangeNotation(CHP.Text, targetNotation);
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
            CHP.Text = Core.Program.Traspose(CHP.Text, semitones);
        }

        internal void Normalize()
        {
            CHP.Text = Core.Program.Normalize(CHP.Text);
        }

        private void CHPPasting(object sender, TextChangingEventArgs e)
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
            CHP.Undo();
        }

        private void ActionRedo(object sender, EventArgs e)
        {
            CHP.Redo();
        }

        private void SelectionCut(object sender, EventArgs e)
        {
            CHP.Cut();
        }

        private void SelectionCopy(object sender, EventArgs e)
        {
            CHP.Copy();
        }

        private void SelectionPaste(object sender, EventArgs e)
        {
            CHP.Paste();
        }

        private void ActionSelectAll(object sender, EventArgs e)
        {
            CHP.SelectAll();
        }

        private void CMS_Opening(object sender, CancelEventArgs e)
        {
            MnUndo.Enabled = CHP.UndoEnabled;
            MnRedo.Enabled = CHP.RedoEnabled;
            MnCut.Enabled = !string.IsNullOrEmpty(CHP.SelectedText);
            MnCopy.Enabled = !string.IsNullOrEmpty(CHP.SelectedText);
            MnPaste.Enabled = Clipboard.ContainsText();
            MnSelectAll.Enabled = !string.IsNullOrEmpty(CHP.Text);
        }

        private Core.ChordNotation mAcNotation = Core.ChordNotation.Unknown;
        private void GenerateAutocomplete()
        {
            Core.ChordNotation target = mSheetNotation == Core.ChordNotation.Unknown ? Core.ChordNotation.Italian : mSheetNotation;


            if (target != mAcNotation)
            {
                List<NoteSnippet> notes = new List<NoteSnippet>();

                foreach (string note in Core.Chord.noteDictionary[target])
                    notes.Add(new NoteSnippet(note));

                foreach (string note in Core.Chord.noteDictionary[target])
                    notes.Add(new NoteSnippet(note + "-"));

                foreach (string note in Core.Chord.noteDictionary[target])
                    notes.Add(new NoteSnippet(note + "7"));

                foreach (string note in Core.Chord.noteDictionary[target])
                    notes.Add(new NoteSnippet(note + "-7"));

                foreach (string note in Core.Chord.noteDictionary[target])
                    notes.Add(new NoteSnippet(note + "9"));

                foreach (string note in Core.Chord.noteDictionary[target])
                    notes.Add(new NoteSnippet(note + "-9"));

                ACM.SetAutocompleteItems(notes);
            }



            mAcNotation = target;
        }




        internal class NoteSnippet : AutocompleteMenuNS.AutocompleteItem
        {
            public NoteSnippet(string note): base(string.Format("[{0}]",note), 0, note)
            {}

            public override AutocompleteMenuNS.CompareResult Compare(string fragmentText)
            {
                string digittext = fragmentText.Trim("[]".ToCharArray()).ToLower(); //testo digitato, ripulito dalle parentesi
                string matchtext = Text.Trim("[]".ToCharArray()).ToLower(); //testo del campione, ripulito dalle parentesi

                if (digittext == matchtext)
                    return AutocompleteMenuNS.CompareResult.VisibleAndSelected;
                if (matchtext.StartsWith(digittext) || digittext.StartsWith(matchtext))
                    return AutocompleteMenuNS.CompareResult.Visible;
                return AutocompleteMenuNS.CompareResult.Hidden;
            }
        }






    }
}
