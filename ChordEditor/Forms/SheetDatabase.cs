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

                if (sh.Progress == Core.SheetHeader.SheetProgress.Incomplete)
                    return "incomplete";
                if (sh.Progress == Core.SheetHeader.SheetProgress.Complete)
                    return "suspended";
                if (sh.Progress == Core.SheetHeader.SheetProgress.Reviewed)
                    return "verified";
                if (sh.Progress == Core.SheetHeader.SheetProgress.Locked)
                    return "locked";

                return null;
            };

            LV.AboutToCreateGroups += (s, args) =>
            {
                foreach (var group in args.Groups)
                {
                    if (group.Header == "{null}")
                    {
                        if (args.Parameters.GroupByColumn == ChRevisor)
                            group.Header = "Not reviewed";
                        else if (args.Parameters.GroupByColumn == ChCategory)
                            group.Header = "Uncategorised";
                    }
                }
            };

            Core.Program.SheetDB.ListChanged += SheetDB_ListChanged;
        }

        //void SheetHeader_HeaderChange(Core.SheetHeader sh)
        //{
        //    LV.UpdateObject(sh);
        //}

        void SheetDB_ListChanged()
        {
            LV.BuildList();
            LV_SelectionChanged(null, null);
        }

        private void SheetDatabase_Load(object sender, EventArgs e)
        {
            LV.SetObjects(Core.Program.SheetDB);
        }

        private void LV_SelectionChanged(object sender, EventArgs e)
        {
            BtnOpen.Enabled = LV.SelectedObjects.Count > 0;
            BtnDelete.Enabled = LV.SelectedObjects.Count > 0;
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            foreach (Core.SheetHeader sh in LV.SelectedObjects)
                FocusOrCreate(sh);
        }

        private void FocusOrCreate(Core.SheetHeader sh)
        {
            SheetForm sf = null;
            foreach (UserControls.DockingManager.DockContent dc in DockPanel.Documents)
            {
                if (dc is SheetForm && object.Equals(((SheetForm)dc).Sheet.Header, sh))
                {
                    sf = dc as SheetForm;
                    break;
                }
            }

            if (sf != null)
                sf.Show();
            else
                Forms.SheetForm.CreateAndShow(new Core.Sheet(sh.FileName), DockPanel);
        }

        private void LV_ItemActivate(object sender, EventArgs e)
        {
            Core.SheetHeader sh = LV.SelectedObject as Core.SheetHeader;
            if (sh != null) FocusOrCreate(sh);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
			Forms.SheetForm.CreateAndShow(new Core.Sheet(), DockPanel);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
			

            foreach (Core.SheetHeader sh in LV.SelectedObjects)
            {
				if (System.IO.File.Exists(sh.FilePath))
				{
					if (Core.Program.LocalOrInvalid)
						System.IO.File.Delete(sh.FilePath); //delete file from filesystem
					else
						using (SharpSvn.SvnClient cln = new SharpSvn.SvnClient())
							cln.Delete(sh.FilePath, new SharpSvn.SvnDeleteArgs() { Force = true }); //mark for svn deletion
				}
            }

            Core.Program.SheetDB.ReloadDataBase();
        }
    }
}
