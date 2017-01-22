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
	public partial class SheetPropertyForm : ChordEditor.UserControls.DockingManager.DockContent
	{
        private const string NEW_CAT = "--- new category ---";

		public SheetPropertyForm()
		{
			InitializeComponent();
		}

        private void SheetPropertyForm_Load(object sender, EventArgs e)
        {
            RefreshCategoryList();
            DockPanel.ActiveDocumentChanged += DockPanel_ActiveDocumentChanged;
        }

        void RefreshCategoryList()
        {
            CbCategory.BeginUpdate();
            CbCategory.Items.Clear();
            CbCategory.Items.AddRange(Core.Program.SheetDB.Categories.ToArray());
            CbCategory.Items.Add(NEW_CAT);

            if (ActiveSheet != null && CbCategory.Items.Contains(ActiveSheet.Header.SheetCategory))
                CbCategory.SelectedItem = ActiveSheet.Header.SheetCategory;
            else
                CbCategory.SelectedIndex = -1;

            CbCategory.EndUpdate();
        }

        void DockPanel_ActiveDocumentChanged(object sender, EventArgs e)
        {
            if (ActiveSheet != null)
            {
                TbTitle.Text = ActiveSheet.Header.Title;
                TbArtist.Text = ActiveSheet.Header.Artist;
                TbSheetAuthor.Text = ActiveSheet.Header.SheetAuthor;
                TbSheetRevisor.Text = ActiveSheet.Header.SheetRevisor;
                TbProgress.Text = ActiveSheet.Header.Progress.ToString();

                PbSheetRevisor.Visible = TbSheetRevisor.Visible = ActiveSheet.Header.SheetRevisor != null;

                TlpMain.Enabled = true;

                if (ActiveSheet != null && ActiveSheet.Header.SheetCategory != null && CbCategory.Items.Contains(ActiveSheet.Header.SheetCategory))
                    CbCategory.SelectedItem = ActiveSheet.Header.SheetCategory;
                else
                    CbCategory.SelectedIndex = -1;
            }
            else
            {
                foreach (Control c in TlpHeader.Controls)
                    if (c is TextBox)
                        ((TextBox)c).Text = "";

                PbSheetRevisor.Visible = TbSheetRevisor.Visible = false;

                CbCategory.SelectedIndex = -1;

                TlpMain.Enabled = false;
            }

        }

        String OnNull(string val, string replacement)
        {
            if (val == null || val.Trim().Length == 0)
                return replacement;
            else
                return val;
        }

        Core.Sheet ActiveSheet
        {
            get
            {
                Forms.SheetForm sf = DockPanel.ActiveDocument as Forms.SheetForm; 
                return sf != null ? sf.Sheet : null;
            } 
        }

        private void TbTitle_TextChanged(object sender, EventArgs e)
        {if (ActiveSheet != null) ActiveSheet.Header.Title = TbTitle.Text;}

        private void TbArtist_TextChanged(object sender, EventArgs e)
        {if (ActiveSheet != null) ActiveSheet.Header.Artist = TbArtist.Text;}

        private void CbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)CbCategory.SelectedItem == NEW_CAT)
            {
                string cat = null;
                if (InputBox.Show(ref cat) == System.Windows.Forms.DialogResult.OK)
                {
                    if (cat != null && cat.Trim().Length > 0)
                    {
                        if (!CbCategory.Items.Contains(cat))
                            CbCategory.Items.Insert(CbCategory.Items.Count - 2, cat);
                        ActiveSheet.Header.SheetCategory = cat;
                    }
                }

                CbCategory.SelectedItem = ActiveSheet.Header.SheetCategory;
            }
            else if (CbCategory.SelectedItem != null)
            {
                ActiveSheet.Header.SheetCategory = (string)CbCategory.SelectedItem;
            }
        }
		
	}
}
