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

				private InputBox(string p1, string p2, string p3, bool e)
				{
						InitializeComponent();

						Text = p1;
						LblQuestion.Text = p2;
						TbInput.Text = p3;
						TbInput.ReadOnly = !e;
				}

				private void BtnOk_Click(object sender, EventArgs e)
				{
						DialogResult = System.Windows.Forms.DialogResult.OK;
						Close();
				}

				internal static string Show(string title, string question, string suggestion = "", bool editable = true)
				{
						using (InputBox ib = new InputBox(title, question, suggestion, editable))
						{
								if (ib.ShowDialog() == DialogResult.OK)
										return ib.TbInput.Text.Trim().Length > 0 ? ib.TbInput.Text.Trim() : null;
						}
						return null;
				}

				private void InputBox_Load(object sender, EventArgs e)
				{
						if (TbInput.ReadOnly)
								ActiveControl = BtnCancel;
						else
								ActiveControl = TbInput;
				}

				private void BtnCancel_Click(object sender, EventArgs e)
				{
						DialogResult = System.Windows.Forms.DialogResult.Cancel;
						Close();
				}
		}
}
