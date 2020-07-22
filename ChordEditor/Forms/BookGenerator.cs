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

		internal static SongBook.GeneratorOptions CreateAndShowDialog(MainForm mainForm)
		{
			using (BookGenerator rb = new BookGenerator())
			{
				if (rb.ShowDialog(mainForm) == DialogResult.OK)
				{
					SongBook.GeneratorOptions rv = new SongBook.GeneratorOptions();
					rv.RebuildIdx = rb.CbRebuildIndexes.Checked;
					rv.RebuildSize = rb.CbRebuildAllSize.Checked;

					if (rb.RbPerChitarra.Checked)
						rv.Type = SongBook.GeneratorOptions.BookType.Guitar;
					else if (rb.RbPerCanto.Checked)
						rv.Type = SongBook.GeneratorOptions.BookType.Singer;

					return rv;
				}

				return null;
			}
		}

	}
}
