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
	public partial class LogMessageForm : ChordEditor.UserControls.DockingManager.DockContent
	{
		public LogMessageForm()
		{
			InitializeComponent();

            Core.Program.SvnOperationBegin += Program_SvnOperationBegin;
            Core.Program.SvnOperationEnd += Program_SvnOperationEnd;
            Core.Program.SvnOperationMessage += Program_SvnOperationMessage;
            Core.Program.SvnOperationError += Program_SvnOperationError;
		}

        void Program_SvnOperationError(string message)
        {
            Log(message, errorStyle);
        }

        void Program_SvnOperationMessage(string message)
        {
            Log(message, messStyle);
        }

        void Program_SvnOperationEnd(string message)
        {
            Log(message + "\r\n", opStyle);
        }

        void Program_SvnOperationBegin(string message)
        {
            Log(message, opStyle);
        }


        TextStyle messStyle = new TextStyle(Brushes.DarkBlue, null, FontStyle.Regular);
        TextStyle opStyle = new TextStyle(Brushes.Black, null, FontStyle.Regular);
        TextStyle errorStyle = new TextStyle(Brushes.Red, null, FontStyle.Regular);

        private void Log(string text, Style style)
        {
            text = DateTime.Now.ToLongTimeString() + "\t" + text + "\r\n";
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

        private void fctb_TextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            fctb.GoEnd();//scroll to end of the text
        }

	}
}
