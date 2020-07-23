using ChordEditor.Core;
using FastColoredTextBoxNS;
using System;
using System.Drawing;

namespace ChordEditor.Forms
{
	public partial class LogMessageForm : ChordEditor.UserControls.DockingManager.DockContent
	{
		public LogMessageForm()
		{
			InitializeComponent();

			SVN.SvnBegin += Program_SvnOperationBegin;
			SVN.SvnEnd += Program_SvnOperationEnd;
			SVN.SvnAction += Program_SvnOperationMessage;
			SVN.SvnError += Program_SvnOperationError;

			Importer.ImportBegin += Importer_ImportBegin;
			Importer.ImportAction += Importer_ImportAction;
			Importer.ImportEnd += Importer_ImportEnd;

			SongBook.JobMessage += SongBook_JobMessage;
			Sheet.SheetMessage += Sheet_SheetMessage;
		}

		private void Sheet_SheetMessage(string message)
		{
			Log(message, opStyle);
			System.Windows.Forms.Application.DoEvents();
		}

		private void SongBook_JobMessage(string message)
		{
			Log(message, opStyle);
		}

		private void Importer_ImportEnd(string message, bool reload)
		{
			Log(message + "\r\n", opStyle);
		}

		private void Importer_ImportAction(string message)
		{
			Log(message, messStyle);
		}

		private void Importer_ImportBegin(string message)
		{
			Log(message, opStyle);
		}

		private void Program_SvnOperationError(Exception ex)
		{
			Log(ex.Message, errorStyle);
		}

		private void Program_SvnOperationMessage(string filename, SharpSvn.SvnNotifyAction action)
		{
			//if (action == SharpSvn.SvnNotifyAction.Add) //skip message
			//		return;
			//if (action == SharpSvn.SvnNotifyAction.CommitSendData) //skip message
			//		return;
			if (action == SharpSvn.SvnNotifyAction.UpdateStarted) //skip message
			{
				return;
			}

			if (action == SharpSvn.SvnNotifyAction.UpdateCompleted) //skip message
			{
				return;
			}

			if (action == SharpSvn.SvnNotifyAction.UpdateUpdate) //skip message
			{
				return;
			}

			SheetHeader sh = SheetDB.GetByFileNameWithDeleted(filename);

			if (sh != null && sh.Title != null)
			{
				Log(String.Format("{0}\t{1}", action, String.Format("{0}{1}{2}", sh.Title, sh.Artist != null ? " - " : "", sh.Artist)), messStyle);
			}
			else
			{
				Log(String.Format("{0}\t{1}", action, filename), messStyle);
			}
		}

		private void Program_SvnOperationEnd(string message, bool reload)
		{
			Log(message + "\r\n", opStyle);
		}

		private void Program_SvnOperationBegin(string message)
		{
			Log(message, opStyle);
		}

		private TextStyle messStyle = new TextStyle(Brushes.DarkBlue, null, FontStyle.Regular);
		private TextStyle opStyle = new TextStyle(Brushes.Black, null, FontStyle.Regular);
		private TextStyle errorStyle = new TextStyle(Brushes.Red, null, FontStyle.Regular);

		private void Log(string text, Style style)
		{
			text = DateTime.Now.ToLongTimeString() + " " + text + "\r\n";
			//some stuffs for best performance
			fctb.BeginUpdate();
			fctb.Selection.BeginUpdate();
			//remember user selection
			var userSelection = fctb.Selection.Clone();
			//add text with predefined style
			fctb.TextSource.CurrentTB = fctb;
			fctb.AppendText(text, style);
			//restore user selection
			if (!userSelection.IsEmpty || userSelection.Start.iLine < fctb.LinesCount - 2)
			{
				fctb.Selection.Start = userSelection.Start;
				fctb.Selection.End = userSelection.End;
			}

			//
			fctb.Selection.EndUpdate();
			fctb.EndUpdate();
		}

		private void fctb_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (InvokeRequired)
			{
				Invoke(new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(fctb_TextChanged), sender, e);
			}
			else
			{
				fctb.GoEnd();//scroll to end of the text
			}
		}

	}
}
