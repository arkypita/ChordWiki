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
		public SheetPropertyForm()
		{
			InitializeComponent();
		}

        void DockPanel_ActiveDocumentChanged(object sender, EventArgs e)
        {
            if (ActiveSheet != null)
            {
                TbTitle.Text = ActiveSheet.mHeader.Title;
                TbArtist.Text = ActiveSheet.mHeader.Artist;
                TlpMain.Enabled = true;
            }
            else
            {
                foreach (Control c in TlpHeader.Controls)
                    if (c is TextBox)
                        ((TextBox)c).Text = "";

                TlpMain.Enabled = false;
            }

        }

        Core.Sheet ActiveSheet
        {
            get
            {
                Forms.SheetForm sf = DockPanel.ActiveDocument as Forms.SheetForm; 
                return sf != null ? sf.Sheet : null;
            } 
        }

        private void SheetPropertyForm_Load(object sender, EventArgs e)
        {DockPanel.ActiveDocumentChanged += DockPanel_ActiveDocumentChanged;}

        private void TbTitle_TextChanged(object sender, EventArgs e)
        {if (ActiveSheet != null) ActiveSheet.mHeader.Title = TbTitle.Text;}

        private void TbArtist_TextChanged(object sender, EventArgs e)
        {if (ActiveSheet != null) ActiveSheet.mHeader.Artist = TbArtist.Text;}
		
	}
}
