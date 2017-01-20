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
	}
}
