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
	public partial class SpashScreen : Form
	{
		public SpashScreen()
		{
			InitializeComponent();
		}

		private void CloseTimer_Tick(object sender, EventArgs e)
		{
			Close();
		}
	}
}
