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

        internal void Save(bool reloadDB)
        {
            if (mSheet.HasChanges)
            {
                mSheet.Save();
                if (reloadDB) Core.Program.SheetDB.ReloadDataBase();
            }
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
            if (mSheet.HasChanges && true)
                Save(true);
        }

        public Core.Sheet Sheet
        { get { return mSheet; } }
    }
}
