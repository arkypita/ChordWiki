using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChordEditor.Forms
{
    public partial class SheetForm : ChordEditor.UserControls.DockingManager.DockContent
    {
        private Core.Sheet mSheet;

        private SheetForm()
        {
            InitializeComponent();
        }

        private SheetForm(Core.Sheet sheet)
        {
            InitializeComponent();
            mSheet = sheet;
            TB.Text = sheet.Content;
            Core.Sheet.SheetChange += Sheet_SheetChange;
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
            throw new NotImplementedException();
        }

        internal void SaveAs()
        {
            throw new NotImplementedException();
        }

        internal void PrintPreview()
        {
            throw new NotImplementedException();
        }

        private void SheetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mSheet.HasMemoryChanges && true)
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

        private void TB_TextChangedDelayed(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            mSheet.Content = TB.Text;
        }


    }
}
