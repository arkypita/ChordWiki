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
	public partial class InputBox : Form
	{
		private InputBox()
		{
			InitializeComponent();
		}

		private InputBox(string p1, string p2)
		{
			InitializeComponent();

			Text = p1;
			LblQuestion.Text = p2;
			TbInput.Focus();
		}

		private void BtnOk_Click(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.OK;
			Close();
		}

		internal static string Show(string title, string question)
		{
			using (InputBox ib = new InputBox(title, question))
			{
				if (ib.ShowDialog() == DialogResult.OK)
					return ib.TbInput.Text.Trim().Length > 0 ? ib.TbInput.Text.Trim() : null;
			}
			return null;
		}
	}
}
