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
          

            Program.OpenedSheet.OpenSheet += OpenedSheet_OpenSheet;
		}

        void OpenedSheet_OpenSheet(Sheet sheet)
        {
            Forms.SheetForm.CreateAndShow(sheet, DP);
        }


		#region Button and Menu Handler

		private void MainFormClose(object sender, EventArgs e)
		{
			Close();
		}

		private void DocumentCreate(object sender, EventArgs e)
		{
			Program.DocumentCreate();
		}

		private void DocumentOpen(object sender, EventArgs e)
		{
			Program.DocumentOpen();
		}

		private void DocumentSave(object sender, EventArgs e)
		{
            ActiveSheet.Save();
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
			Program.DatabaseSyncronize();
		}

		private void SelectionCut(object sender, EventArgs e)
		{

		}

		private void SelectionCopy(object sender, EventArgs e)
		{

		}

		private void SelectionPaste(object sender, EventArgs e)
		{

		}

		private void ActionUndo(object sender, EventArgs e)
		{

		}

		private void ActionRedo(object sender, EventArgs e)
		{

		}

		private void ActionSelectAll(object sender, EventArgs e)
		{

		}

		#endregion

        private void DP_ActiveDocumentChanged(object sender, EventArgs e)
        {
            BtnPrintSheet.Enabled = MnPrintSheet.Enabled = ActiveSheet != null;
            BtnSaveSheet.Enabled = MnSaveSheet.Enabled = ActiveSheet != null;
            MnCloseSheet.Enabled = ActiveSheet != null;
            MnPrintSheetPreview.Enabled = ActiveSheet != null;
            MnSaveAllSheet.Enabled = ActiveSheet != null;
        }

        Forms.SheetForm ActiveSheet
        { get { return DP.ActiveDocument as Forms.SheetForm; } }

	}
}
