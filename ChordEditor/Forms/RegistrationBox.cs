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
		public partial class RegistrationBox : Form
		{
				private RegistrationBox()
				{
						InitializeComponent();
						TbUsername.Text = Settings.Username;
						TbURL.Text = Settings.CurrentRepo;
				}



				private void BtnOk_Click(object sender, EventArgs e)
				{
						using (SharpSvn.SvnClient cln = new SharpSvn.SvnClient())
						{
								cln.Authentication.ClearAuthenticationCache(); //del prev auth
								cln.Authentication.Clear(); //del prev auth

								cln.Configuration.SetOption("servers", "global", "http-auth-types", "basic;digest");
								cln.Authentication.UserNamePasswordHandlers += DialogUserNamePasswordHandler;
								cln.Authentication.SslServerTrustHandlers += DialogSslServerTrustHandler;

								Exception error = VerifyURL(cln, TbURL.Text);

								if (error != null)
								{
										System.Windows.Forms.MessageBox.Show(String.Format("{0}\r\n\r\n{1}", error.Message, error.InnerException != null ? error.InnerException.Message : null), "Configuration error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

										Settings.LocalRepo = true;
										Settings.Username = TbUsername.Text;
										Settings.CurrentRepo = TbURL.Text;
								}
								else
								{
										Settings.LocalRepo = false;
										Settings.Username = TbUsername.Text;
										Settings.CurrentRepo = TbURL.Text;
										SVN.Recreate();
								}

								Settings.Save();

								cln.Authentication.UserNamePasswordHandlers -= DialogUserNamePasswordHandler;
								cln.Authentication.SslServerTrustHandlers -= DialogSslServerTrustHandler;
						}

						DialogResult = System.Windows.Forms.DialogResult.OK;
						Close();
				}


				public static Exception VerifyURL(SharpSvn.SvnClient cln, string repo)
				{
						if (repo == "")
								return new Exception("Please fill repository information!");

						try
						{
								SharpSvn.SvnInfoEventArgs info;
								Uri totest = new Uri(repo);

								if (totest.IsFile)
										throw new InvalidOperationException("Repository url needs to be an internet resource.");

								lock (cln)
										cln.GetInfo(SharpSvn.SvnTarget.FromUri(totest), out info); //deve fare eccezione, perché mi serve per avere certezza che sia un giusto db

								if (info.NodeKind != SharpSvn.SvnNodeKind.Directory)
										throw new InvalidOperationException("Url does not point to a valid repository folder.");

								return null;
						}
						catch (Exception ex)
						{
								return ex;
						}
				}



				private void DialogSslServerTrustHandler(object sender, SharpSvn.Security.SvnSslServerTrustEventArgs e)
				{
						e.AcceptedFailures = e.Failures;
						e.Save = e.MaySave && true;
				}

				private void DialogUserNamePasswordHandler(object sender, SharpSvn.Security.SvnUserNamePasswordEventArgs e)
				{
						e.UserName = TbUsername.Text;
						e.Password = TbPassword.Text;
						e.Save = true;
				}

				private void BtnCancel_Click(object sender, EventArgs e)
				{
						DialogResult = System.Windows.Forms.DialogResult.Cancel;
						Close();
				}

				internal static void CreateAndShowDialog()
				{
						using (RegistrationBox rb = new RegistrationBox())
						{
								if (Application.OpenForms.Count > 0)
										rb.ShowDialog(Application.OpenForms[Application.OpenForms.Count - 1]);
								else
										rb.ShowDialog(Application.OpenForms[Application.OpenForms.Count - 1]);

								rb.BringToFront();
						}
				}
		}
}
