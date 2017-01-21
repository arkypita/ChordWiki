using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChordEditor.Forms
{
    public partial class SheetDatabase : UserControls.DockingManager.DockContent
    {
        public SheetDatabase()
        {
            InitializeComponent();

            this.ChTitle.ImageGetter = delegate(object rowObject)
            {
                Core.SheetHeader sh = (Core.SheetHeader)rowObject;
                return "verified";
            };
        }

        private void SheetDatabase_Load(object sender, EventArgs e)
        {
            LV.SetObjects(Core.Program.SheetDB);
            LV.BuildGroups(ChCategory, SortOrder.Descending);
        }

        private void LV_SelectionChanged(object sender, EventArgs e)
        {
            BtnOpen.Enabled = LV.SelectedObjects.Count > 0;
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            Hide();
            foreach (Core.SheetHeader sh in LV.SelectedObjects)
                Core.Program.OpenedSheet.Open(sh.FileName);
        }

        private void LV_ItemActivate(object sender, EventArgs e)
        {
            Hide();
            Core.SheetHeader sh = LV.SelectedObject as Core.SheetHeader;
            if (sh != null)
                Core.Program.OpenedSheet.Open(sh.FileName);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            Core.Program.DocumentCreate();
        }

    }
}
