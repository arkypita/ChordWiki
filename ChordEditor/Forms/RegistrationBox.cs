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
	public partial class RegistrationBox : Form
	{
		private RegistrationBox()
		{
			InitializeComponent();
		}



		private void BtnOk_Click(object sender, EventArgs e)
		{
            using (SharpSvn.SvnClient cln = new SharpSvn.SvnClient())
            {
                cln.Authentication.Clear(); // Clear a previous authentication
                cln.Authentication.DefaultCredentials = new System.Net.NetworkCredential(TbUsername.Text, TbPassword.Text);

                Settings.Default.UserName = TbUsername.Text;
                Settings.Default.CurrentRepo = TbURL.Text;


                try
                {
                    if (Core.Program.VerifyURL())
                    {
                        Settings.Default.LocalRepo = false;
                    }
                    else
                    {
                        cln.Authentication.Clear(); // Clear a previous authentication
                        Settings.Default.UserName = "";
                        Settings.Default.CurrentRepo = "";
                        Settings.Default.LocalRepo = true;
                    }
                }
                catch 
                {
                    cln.Authentication.Clear(); // Clear a previous authentication
                    Settings.Default.UserName = "";
                    Settings.Default.CurrentRepo = "";
                }

                Settings.Default.Save();

            }

			DialogResult = System.Windows.Forms.DialogResult.OK;
			Close();
		}

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        internal static void CreateAndShowDialog()
        {
            using (RegistrationBox rb = new RegistrationBox())
            { rb.ShowDialog(); }
        }
    }
}
