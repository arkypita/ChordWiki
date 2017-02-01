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

        class TrasposeCbItem
        {
            public int howMany;

            public override string ToString()
            {return howMany.ToString("+#;-#;0");}
        }

		public SheetPropertyForm()
		{
			InitializeComponent();

            CbSemitoni.BeginUpdate();
            for (int i = 11; i > -12; i--)
                CbSemitoni.Items.Add(new TrasposeCbItem() { howMany = i });
            CbSemitoni.SelectedIndex = 11;
            CbSemitoni.EndUpdate();

		}

        private void SheetPropertyForm_Load(object sender, EventArgs e)
        {
            RefreshCategoryList();
            DockPanel.ActiveDocumentChanged += DockPanel_ActiveDocumentChanged;
            SheetForm.DelayedTextChanged += SheetForm_DelayedTextChanged;
            SheetForm.HeaderChanged += SheetForm_HeaderChanged;
        }

        void SheetForm_HeaderChanged(SheetForm sf)
        {
            if (object.Equals(sf.Sheet, ActiveSheet))
                RefreshFileHeader();
        }

        void SheetForm_DelayedTextChanged(SheetForm sf)
        {
            if (object.Equals(sf.Sheet, ActiveSheet))
                RefreshFileInfo();
        }

        private void RefreshFileInfo()
        {
            SheetForm sf = ActiveSheetForm;

            if (sf != null)
                PbNotation.Image = NF.Images[sf.SheetNotation.ToString()];
            else
                PbNotation.Image = NF.Images[Core.ChordNotation.Unknown.ToString()];

            if (sf != null)
                PbNormalized.Image = SF.Images[sf.IsNormalized ? "ImgOK" : "ImgKO"];
            else
                PbNormalized.Image = SF.Images["ImgUNK"];

            PbNormalized.Enabled = (sf != null && !sf.IsNormalized);
            PbNotation.Enabled = (sf != null && (sf.SheetNotation == Core.ChordNotation.American || sf.SheetNotation == Core.ChordNotation.Italian));
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
            CbSemitoni.SelectedIndex = 11;

            RefreshFileHeader();
            RefreshFileInfo();

        }

        private void RefreshFileHeader()
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

        SheetForm ActiveSheetForm
		{ get { return DockPanel != null ? DockPanel.ActiveDocument as Forms.SheetForm : null; } }

        Core.Sheet ActiveSheet
        {get{return ActiveSheetForm != null ? ActiveSheetForm.Sheet : null;} }

        private void TbTitle_TextChanged(object sender, EventArgs e)
        {if (ActiveSheet != null) ActiveSheet.Header.Title = TbTitle.Text;}

        private void TbArtist_TextChanged(object sender, EventArgs e)
        {if (ActiveSheet != null) ActiveSheet.Header.Artist = TbArtist.Text;}

        private void CbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)CbCategory.SelectedItem == NEW_CAT)
            {
                string cat = InputBox.Show("New category", "Category?");
                if (cat != null)
                {
                    if (!CbCategory.Items.Contains(cat))
                        CbCategory.Items.Insert(CbCategory.Items.Count - 1, cat);
                    ActiveSheet.Header.SheetCategory = cat;
                }

                CbCategory.SelectedItem = ActiveSheet.Header.SheetCategory;
            }
            else if (CbCategory.SelectedItem != null)
            {
                ActiveSheet.Header.SheetCategory = (string)CbCategory.SelectedItem;
            }
        }

		private void ValidateTextBox(object sender, CancelEventArgs e)
		{
			TextBox tb = sender as TextBox;
			if (tb.Text.Length > 0 && tb.Text.Trim().Length == 0)
				tb.Text = "";
		}

        private void PbNotation_Click(object sender, EventArgs e)
        {
            if (ActiveSheetForm != null)
                ActiveSheetForm.ChangeNotation();
        }

        private void PbTrasposeDown_Click(object sender, EventArgs e)
        {
            if (ActiveSheetForm != null)
                ActiveSheetForm.Traspose(-1);
        }

        private void PbTrasposeUp_Click(object sender, EventArgs e)
        {
            if (ActiveSheetForm != null)
                ActiveSheetForm.Traspose(+1);
        }

        private void CbSemitoni_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbSemitoni.SelectedIndex != 11)
            {
                if (ActiveSheetForm != null)
                    ActiveSheetForm.Traspose(((TrasposeCbItem)CbSemitoni.SelectedItem).howMany);
    
                CbSemitoni.SelectedIndex = 11;
            }
        }

        private void PbNormalized_Click(object sender, EventArgs e)
        {
            if (ActiveSheetForm != null)
                ActiveSheetForm.Normalize();
        }
		
	}
}
