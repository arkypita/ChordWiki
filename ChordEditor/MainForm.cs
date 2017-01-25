/*
 * Created by SharpDevelop.
 * User: Diego
 * Date: 18/01/2017
 * Time: 19:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ChordEditor.Core;

namespace ChordEditor
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		Forms.PendingChangesForm PendingChanges = new Forms.PendingChangesForm();
        Forms.SheetPropertyForm SheetProperty = new Forms.SheetPropertyForm();
        Forms.SheetDatabase SheetDataBase = new Forms.SheetDatabase();
        

		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			using (Forms.SpashScreen ss = new Forms.SpashScreen())
				ss.ShowDialog();

			PendingChanges.Show(DP);
			SheetProperty.Show(DP);
            DocumentOpen(null, null);
		}

		#region Button and Menu Handler

		private void MainFormClose(object sender, EventArgs e)
		{
			Close();
		}

		private void DocumentCreate(object sender, EventArgs e)
		{
			Forms.SheetForm.CreateAndShow(new Core.Sheet(), DP);
		}

		private void DocumentOpen(object sender, EventArgs e)
		{
            SheetDataBase.Show(DP);
            SheetDataBase.Visible = true;
		}

		private void DocumentSave(object sender, EventArgs e)
		{
            ActiveSheet.Save(true);
		}

		private void DocumentPrint(object sender, EventArgs e)
		{
            ActiveSheet.Print();
		}

		private void DocumentClose(object sender, EventArgs e)
		{
            ActiveSheet.Close();
		}

		private void DocumentSaveAs(object sender, EventArgs e)
		{
            ActiveSheet.SaveAs();
		}

		private void DocumentPrintPreview(object sender, EventArgs e)
		{
            ActiveSheet.PrintPreview();
		}

		private void DatabaseSyncronize(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			Program.DatabaseSyncronize(this);
			Cursor = Cursors.Default;
		}

		private void DatabaseDownload(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			Program.DatabaseDownload(this);
			Cursor = Cursors.Default;
		}

		private void DatabaseUpload(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			Program.DatabaseUpload(this);
			Cursor = Cursors.Default;
		}

		private void DatabaseRevert(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			Program.DatabaseRevert(this);
			Cursor = Cursors.Default;
		}

		private void SelectionCut(object sender, EventArgs e)
		{
			if (ActiveEditor != null)
				ActiveEditor.Cut();
		}

		private void SelectionCopy(object sender, EventArgs e)
		{
			if (ActiveEditor != null)
				ActiveEditor.Copy();
		}

		private void SelectionPaste(object sender, EventArgs e)
		{
			if (ActiveEditor != null)
				ActiveEditor.Paste();
		}

		private void ActionUndo(object sender, EventArgs e)
		{
			if (ActiveEditor != null && ActiveEditor.UndoEnabled)
				ActiveEditor.Undo();
		}

		private void ActionRedo(object sender, EventArgs e)
		{
			if (ActiveEditor != null && ActiveEditor.RedoEnabled)
				ActiveEditor.Redo();
		}

		private void ActionSelectAll(object sender, EventArgs e)
		{
			if (ActiveEditor != null)
				ActiveEditor.SelectAll();
		}

		#endregion

        private void DP_ActiveDocumentChanged(object sender, EventArgs e)
        {
            BtnPrintSheet.Enabled = MnPrintSheet.Enabled = ActiveSheet != null;
            BtnSaveSheet.Enabled = MnSaveSheet.Enabled = ActiveSheet != null;
            MnCloseSheet.Enabled = ActiveSheet != null;
            MnPrintSheetPreview.Enabled = ActiveSheet != null;
            MnSaveAllSheet.Enabled = ActiveSheet != null;

			if (ActiveEditor != null)
			{
				MnUndo.ShortcutKeys = GetShortCut(FastColoredTextBoxNS.FCTBAction.Undo);
				MnRedo.ShortcutKeys = GetShortCut(FastColoredTextBoxNS.FCTBAction.Redo);
				MnCut.ShortcutKeys = GetShortCut(FastColoredTextBoxNS.FCTBAction.Cut);
				MnCopy.ShortcutKeys = GetShortCut(FastColoredTextBoxNS.FCTBAction.Copy);
				MnPaste.ShortcutKeys = GetShortCut(FastColoredTextBoxNS.FCTBAction.Paste);
				MnSelectAll.ShortcutKeys = GetShortCut(FastColoredTextBoxNS.FCTBAction.SelectAll);
			}
        }

		private Keys GetShortCut(FastColoredTextBoxNS.FCTBAction action)
		{
			foreach (KeyValuePair<Keys, FastColoredTextBoxNS.FCTBAction> kvp in ActiveEditor.HotkeysMapping)
				if (action == kvp.Value)
					return kvp.Key;
			return Keys.None;
		}

        Forms.SheetForm ActiveSheet
        { get { return DP.ActiveDocument as Forms.SheetForm; } }

		FastColoredTextBoxNS.FastColoredTextBox ActiveEditor
		{get{return ActiveSheet != null ? ActiveSheet.Editor : null;}}

		private void ET_Tick(object sender, EventArgs e)
		{


			MnCut.Enabled = BtnCut.Enabled = ActiveEditor != null && !ActiveEditor.Selection.IsEmpty;
			MnCopy.Enabled = BtnCopy.Enabled = ActiveEditor != null && !ActiveEditor.Selection.IsEmpty;
			MnPaste.Enabled = BtnPaste.Enabled = ActiveEditor != null;
			MnUndo.Enabled = ActiveEditor != null && ActiveEditor.UndoEnabled;
			MnRedo.Enabled = ActiveEditor != null && ActiveEditor.RedoEnabled;
            MnSelectAll.Enabled = ActiveEditor != null;
		}





	}
}
