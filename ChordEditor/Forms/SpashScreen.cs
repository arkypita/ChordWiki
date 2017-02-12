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

						if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
								LblVersion.Text = string.Format("Version {0}", System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion);
						else
								LblVersion.Text = string.Format("Version {0}*", Application.ProductVersion);
				}

				private void CloseTimer_Tick(object sender, EventArgs e)
				{
						CloseTimer.Stop();
						Close();
				}

				internal void ShowDialog(int p, bool cc)
				{
						mCC = cc;
						CloseTimer.Interval = p;
						CloseTimer.Start();
						ShowDialog();
				}

				private bool mCC = false;
				private void SpashScreen_Click(object sender, EventArgs e)
				{
						if (mCC)
								CloseTimer_Tick(sender, e);
				}
		}
}
