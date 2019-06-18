using ChordEditor.Core;
using System;
using System.Windows.Forms;

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

			DialogResult = DialogResult.OK;
			Close();
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		internal static SongBook.GeneartorOptions CreateAndShowDialog()
		{
			using (BookGenerator rb = new BookGenerator())
			{
				if (Application.OpenForms.Count > 0)
				{
					rb.ShowDialog(Application.OpenForms[Application.OpenForms.Count - 1]);
				}
				else
				{
					rb.ShowDialog(Application.OpenForms[Application.OpenForms.Count - 1]);
				}

				SongBook.GeneartorOptions rv = new SongBook.GeneartorOptions();
				rv.RebuildIdx = rb.CbRebuildIndexes.Checked;
				rv.StripChord = rb.CbStripChords.Checked;

				return rv;
			}
		}

	}
}
