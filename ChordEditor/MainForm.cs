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
		Forms.LogMessageForm LogMessages;
		Forms.SheetPropertyForm SheetProperty;
		Forms.SheetDatabase SheetDataBase;

		private bool errorRecorded = false;
		private bool completedWithoutError = true;
		private int mErrorCount = 0;

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

			LogMessages = new Forms.LogMessageForm();
			LogMessages.Show(DP);

			VerifyTotalCleanup();

			SheetProperty = new Forms.SheetPropertyForm();
			SheetProperty.Show(DP);

			SheetDataBase = new Forms.SheetDatabase();
			SheetDataBase.Show(DP);

            Program.SvnOperationBegin += Program_SvnOperationBegin;
            Program.SvnOperationEnd += Program_SvnOperationEnd;
			Program.SvnOperationError += Program_SvnOperationError;

			Program.SheetDB.ReloadDataBase();
		}

		void Program_SvnOperationError(Exception ex)
		{
			if (InvokeRequired)
			{
				Invoke(new Program.SvnOperationErrorDelegate(Program_SvnOperationError), ex);
			}
			else
			{
				completedWithoutError = false;

				if (!errorRecorded)
				{
					mErrorCount++;
					errorRecorded = true;
				}
			}
		}

		void VerifyTotalCleanup()
		{
			if (TokenFile.TestAndDelete("cleanup.tok"))
				Program.TotalCleanup(this);
		}

		void VerifyErrorCount()
		{
			if (mErrorCount > 10)
			{
				if (System.Windows.Forms.MessageBox.Show("It would seem that there are strong issues in your working copy.\r\nI can fix it with a \"Strong Cleanup\".\r\nPerform strong cleanup now?\r\n\r\nApplication restart is required.",
					"Syncronization error", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Yes)
				{
					TokenFile.Set("cleanup.tok");
					mForceClose = true;
					Program.Restart();
				}
			}
			else if (mErrorCount > 5)
			{
				if (System.Windows.Forms.MessageBox.Show("It would seem that there are some issues in your working copy.\r\nSometimes these problems can be solved with the \"Cleanup\" function.\r\nPerform cleanup now?",
					"Syncronization error", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Yes)
				{
					DatabaseCleanup(null, null);
				}
			}
		}

        void Program_SvnOperationBegin(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Program.SvnOperationDelegate(Program_SvnOperationBegin), message);
            }
            else
            {
				errorRecorded = true;
				completedWithoutError = true;
                Cursor = Cursors.WaitCursor;
                MnSyncronize.Enabled = BtnSyncronize.Enabled = false;
            }
        }

        void Program_SvnOperationEnd(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Program.SvnOperationDelegate(Program_SvnOperationEnd), message);
            }
            else
            {
                MnSyncronize.Enabled = BtnSyncronize.Enabled = true;
                Cursor = Cursors.Default;

				if (completedWithoutError)
					mErrorCount = 0;

				VerifyErrorCount();
				VerifyClosingAct();
            }
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
		{Program.DatabaseSyncronize(this);}

		private void DatabaseDownload(object sender, EventArgs e)
		{Program.DatabaseDownload(this);}

		private void DatabaseUpload(object sender, EventArgs e)
		{Program.DatabaseUpload(this);}

		private void DatabaseRevert(object sender, EventArgs e)
		{Program.DatabaseRevert(this);}

		private void DatabaseCleanup(object sender, EventArgs e)
		{
			mErrorCount = 0;
			Program.DatabaseCleanup(this);
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

		FastColoredTextBoxNS.FastColoredTextBox ActiveEditor
		{get{return ActiveSheet != null ? ActiveSheet.Editor : null;}}

		private bool mForceClose = false;
		private bool mClosePending = false;
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!mForceClose && Program.DatabaseHasChanges())
			{
				DialogResult rv = System.Windows.Forms.MessageBox.Show("There are some changes not yet sent to the server.\r\nSubmit your changes?",
																		"Uncommitted changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

				if (rv == System.Windows.Forms.DialogResult.Yes)
				{
					mClosePending = true;
					Enabled = false;
					Program.DatabaseUpload(this); //è asincrono
					e.Cancel = true;
				}
				else if (rv == System.Windows.Forms.DialogResult.Cancel)
				{
					e.Cancel = true;
				}
			}
		}

		private void VerifyClosingAct() //chiamata dalla end operation
		{
			if (mClosePending)
				VCAT.Start(); //aspetto un secondo x vedere i messaggi
		}

		private void VCAT_Tick(object sender, EventArgs e)
		{
			VCAT.Enabled = false;
			if (mClosePending)
			{
				Enabled = true; //riabilito l'interfaccia, potrebbe essere necessaria nuova interazione sul close
				mClosePending = false;
				Close();
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			if (!Program.LocalOrInvalid)
				Program.DatabaseDownload(this);
		}

        private void MnImport_Click(object sender, EventArgs e)
        {

            using (System.Windows.Forms.OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select file to import";
                ofd.Filter = "Any supported file|*.txt;*.doc;*.docx";
                ofd.CheckFileExists = true;
                ofd.Multiselect = false;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    Program.ImportFile(ofd.FileName);
            }

        }

        private void MnCloseAll_Click(object sender, EventArgs e)
        {
            List<Forms.SheetForm> toclose = new List<Forms.SheetForm>();
            foreach (UserControls.DockingManager.DockContent document in DP.ActiveDocumentPane.Contents)
            {
                if (document is Forms.SheetForm)
                    toclose.Add(document as Forms.SheetForm);
            }

            foreach (Forms.SheetForm sf in toclose)
                sf.Close();
        }

        private void MnSaveAll_Click(object sender, EventArgs e)
        {
            List<Forms.SheetForm> toclose = new List<Forms.SheetForm>();
            foreach (UserControls.DockingManager.DockContent document in DP.ActiveDocumentPane.Contents)
            {
                if (document is Forms.SheetForm)
                    toclose.Add(document as Forms.SheetForm);
            }

            foreach (Forms.SheetForm sf in toclose)
                sf.Save(false);

            Program.SheetDB.ReloadDataBase();
        }







	}
}
