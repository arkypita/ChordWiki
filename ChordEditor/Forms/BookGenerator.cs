using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChordEditor.Core;

namespace ChordEditor.Forms
{
		public partial class BookGenerator : Form
		{
				private BookGenerator()
				{
						InitializeComponent();
				}



				private void BtnOk_Click(object sender, EventArgs e)
				{

						DialogResult = System.Windows.Forms.DialogResult.OK;
						Close();
				}

				private void BtnCancel_Click(object sender, EventArgs e)
				{
						DialogResult = System.Windows.Forms.DialogResult.Cancel;
						Close();
				}

				internal static Core.SongBook.GeneartorOptions CreateAndShowDialog()
				{
						using (BookGenerator rb = new BookGenerator())
						{
								if (Application.OpenForms.Count > 0)
										rb.ShowDialog(Application.OpenForms[Application.OpenForms.Count - 1]);
								else
										rb.ShowDialog(Application.OpenForms[Application.OpenForms.Count - 1]);

								Core.SongBook.GeneartorOptions rv = new SongBook.GeneartorOptions();
								rv.RebuildIdx = rb.CbRebuildIndexes.Checked;

								return rv;
						}
				}

		}
}
