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
		Forms.PendingChangesForm FormPendingChanges = new Forms.PendingChangesForm();
		Forms.SheetPropertyForm FormDocumentProperty = new Forms.SheetPropertyForm();


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



			FormPendingChanges.Show(DP);
			FormDocumentProperty.Show(DP);

		
			Program.OpenedSheet.OpenSheet += OnOpenSheet; 
			
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
			Program.DocumentSave();
		}

		private void DocumentPrint(object sender, EventArgs e)
		{
			Program.DocumentPrint();
		}

		private void DocumentClose(object sender, EventArgs e)
		{
			Program.DocumentClose();
		}

		private void DocumentSaveAs(object sender, EventArgs e)
		{
			Program.DocumentSaveAs();
		}

		private void DocumentPrintPreview(object sender, EventArgs e)
		{
			Program.DocumentPrintPreview();
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

		void OnOpenSheet(Sheet sheet)
		{
			Forms.SheetForm.CreateAndShow(sheet, DP);
		}
		
		void OnActiveDocumentChanged(object sender, EventArgs e)
		{
			
		}
		
	}
}
