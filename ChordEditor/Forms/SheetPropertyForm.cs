using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using ChordEditor.Core;

namespace ChordEditor.Forms
{
		public partial class SheetPropertyForm : ChordEditor.UserControls.DockingManager.DockContent
		{
				private const string NEW_CAT = "--- new category ---";
				private bool suspendCatEvent = false;

				class TrasposeCbItem
				{
						public int howMany;

						public override string ToString()
						{ return howMany.ToString("+#;-#;0"); }
				}

				public SheetPropertyForm()
				{
						InitializeComponent();

						CbSemitoni.BeginUpdate();
						for (int i = 11; i > -12; i--)
								CbSemitoni.Items.Add(new TrasposeCbItem() { howMany = i });
						CbSemitoni.SelectedIndex = 11;
						CbSemitoni.EndUpdate();

						PbAdd.Image = SF.Images["ImgUNK"];
						PbVerify.Image = SF.Images["ImgUNK"];
						PbReview.Image = SF.Images["ImgUNK"];
						PbLock.Image = SF.Images["ImgUNK"];
						PbNormalized.Image = SF.Images["ImgUNK"];
						PbNotation.Image = NF.Images[Core.ChordNotation.Unknown.ToString()];
				}

				private void SheetPropertyForm_Load(object sender, EventArgs e)
				{
						RefreshCategoryList();
						DockPanel.ActiveDocumentChanged += DockPanel_ActiveDocumentChanged;
						SheetForm.DelayedTextChanged += SheetForm_DelayedTextChanged;
						SheetForm.HeaderChanged += SheetForm_HeaderChanged;
						Core.SheetDB.ListChanged += SheetDB_ListChanged;
				}

				void SheetDB_ListChanged()
				{
						if (InvokeRequired)
								Invoke(new SheetDB.ListChangedDelegate(SheetDB_ListChanged));
						else
								RefreshCategoryList();
				}

				void SheetForm_HeaderChanged(SheetForm sf)
				{
						if (object.Equals(ActiveSheet, sf))
								RefreshFileHeader();
				}

				void SheetForm_DelayedTextChanged(SheetForm sf)
				{
						if (object.Equals(sf.Sheet, ActiveSheet))
								RefreshFileInfo();
				}

				private void RefreshFileInfo()
				{
						SheetForm sf = ActiveSheetForm;

						if (sf != null)
								PbNotation.Image = NF.Images[sf.SheetNotation.ToString()];
						else
								PbNotation.Image = NF.Images[Core.ChordNotation.Unknown.ToString()];

						if (sf != null)
								PbNormalized.Image = SF.Images[sf.IsNormalized ? "ImgOK" : "ImgKO"];
						else
								PbNormalized.Image = SF.Images["ImgUNK"];

						PbNormalized.Enabled = (sf != null && !sf.IsNormalized);
						PbNotation.Enabled = (sf != null && (sf.SheetNotation == Core.ChordNotation.American || sf.SheetNotation == Core.ChordNotation.Italian));
				}

				void RefreshCategoryList()
				{
						suspendCatEvent = true;
						CbCategory.BeginUpdate();
						CbCategory.Items.Clear();
						CbCategory.Items.AddRange(SheetDB.Categories.ToArray());
						CbCategory.Items.Add(NEW_CAT);

						if (ActiveSheet != null && ActiveSheet.Header.SheetCategory != null && CbCategory.Items.Contains(ActiveSheet.Header.SheetCategory))
								CbCategory.SelectedItem = ActiveSheet.Header.SheetCategory;
						else
								CbCategory.SelectedIndex = -1;

						CbCategory.EndUpdate();
						suspendCatEvent = false;
				}

				void DockPanel_ActiveDocumentChanged(object sender, EventArgs e)
				{
						CbSemitoni.SelectedIndex = 11;
						RefreshFileHeader();
						RefreshFileInfo();
				}

				private void RefreshFileHeader()
				{
						if (ActiveSheet != null)
						{
								TbTitle.Text = ActiveSheet.Header.Title;
								TbArtist.Text = ActiveSheet.Header.Artist;

								if (ActiveSheet != null && ActiveSheet.Header.SheetCategory != null && CbCategory.Items.Contains(ActiveSheet.Header.SheetCategory))
										CbCategory.SelectedItem = ActiveSheet.Header.SheetCategory;
								else
										CbCategory.SelectedIndex = -1;


								PbAdd.Image = SF.Images[ActiveSheet.Header.Progress >= Core.SheetHeader.SheetProgress.Added ? "ImgOK" : "ImgKO"];
								PbVerify.Image = SF.Images[ActiveSheet.Header.Progress >= Core.SheetHeader.SheetProgress.Verified ? "ImgOK" : "ImgKO"];
								PbReview.Image = SF.Images[ActiveSheet.Header.Progress >= Core.SheetHeader.SheetProgress.Reviewed ? "ImgOK" : "ImgKO"];
								PbLock.Image = SF.Images[ActiveSheet.Header.Progress >= Core.SheetHeader.SheetProgress.Locked ? "ImgOK" : "ImgKO"];

								TbSheetAuthor.Text = ActiveSheet.Header.SheetAuthor;
								TbVerified.Text = ActiveSheet.Header.VerifiedBy;
								TbSheetRevisor.Text = ActiveSheet.Header.SheetRevisor;
								TbLocked.Text = ActiveSheet.Header.LockedBy;

								PbAdd.Enabled = false;
								PbVerify.Enabled = (ActiveSheet.Header.Progress == Core.SheetHeader.SheetProgress.Added || ActiveSheet.Header.Progress == Core.SheetHeader.SheetProgress.Verified);
								PbReview.Enabled = (ActiveSheet.Header.Progress == Core.SheetHeader.SheetProgress.Verified || ActiveSheet.Header.Progress == Core.SheetHeader.SheetProgress.Reviewed);
								PbLock.Enabled = (ActiveSheet.Header.Progress == Core.SheetHeader.SheetProgress.Reviewed || ActiveSheet.Header.Progress == Core.SheetHeader.SheetProgress.Locked) && (ActiveSheet.Header.LockedBy == null || SVN.Username == null || ActiveSheet.Header.LockedBy == SVN.Username);

								TlpMain.Enabled = true;

								GbSongInfo.Enabled = GbTools.Enabled = ActiveSheet.Header.Progress < Core.SheetHeader.SheetProgress.Reviewed;
						}
						else
						{
								foreach (Control c in TlpHeader.Controls)
										if (c is TextBox)
												((TextBox)c).Text = "";
								foreach (Control c in TlpProgress.Controls)
										if (c is TextBox)
												((TextBox)c).Text = "";

								CbCategory.SelectedIndex = -1;

								PbAdd.Image = SF.Images["ImgUNK"];
								PbVerify.Image = SF.Images["ImgUNK"];
								PbReview.Image = SF.Images["ImgUNK"];
								PbLock.Image = SF.Images["ImgUNK"];

								TlpMain.Enabled = false;
						}
				}

				String OnNull(string val, string replacement)
				{
						if (val == null || val.Trim().Length == 0)
								return replacement;
						else
								return val;
				}

				SheetForm ActiveSheetForm
				{ get { return DockPanel != null ? DockPanel.ActiveDocument as Forms.SheetForm : null; } }

				Core.Sheet ActiveSheet
				{ get { return ActiveSheetForm != null ? ActiveSheetForm.Sheet : null; } }

				private void TbTitle_TextChanged(object sender, EventArgs e)
				{ if (ActiveSheet != null) ActiveSheet.Header.Title = TbTitle.Text; }

				private void TbArtist_TextChanged(object sender, EventArgs e)
				{ if (ActiveSheet != null) ActiveSheet.Header.Artist = TbArtist.Text; }

				private void CbCategory_SelectedIndexChanged(object sender, EventArgs e)
				{
						if (suspendCatEvent)
								return;

						if ((string)CbCategory.SelectedItem == NEW_CAT)
						{
								string cat = InputBox.Show("New category", "Category?");
								if (cat != null)
								{
										if (!CbCategory.Items.Contains(cat))
												CbCategory.Items.Insert(CbCategory.Items.Count - 1, cat);
										ActiveSheet.Header.SheetCategory = cat;
								}

								CbCategory.SelectedItem = ActiveSheet.Header.SheetCategory;
						}
						else if (CbCategory.SelectedItem != null)
						{
								ActiveSheet.Header.SheetCategory = (string)CbCategory.SelectedItem;
						}
				}

				private void ValidateTextBox(object sender, CancelEventArgs e)
				{
						TextBox tb = sender as TextBox;
						if (tb.Text.Length > 0 && tb.Text.Trim().Length == 0)
								tb.Text = "";
				}

				private void PbNotation_Click(object sender, EventArgs e)
				{
						if (ActiveSheetForm != null)
								ActiveSheetForm.ChangeNotation();
				}

				private void PbTrasposeDown_Click(object sender, EventArgs e)
				{
						if (ActiveSheetForm != null)
								ActiveSheetForm.Traspose(-1);
				}

				private void PbTrasposeUp_Click(object sender, EventArgs e)
				{
						if (ActiveSheetForm != null)
								ActiveSheetForm.Traspose(+1);
				}

				private void CbSemitoni_SelectedIndexChanged(object sender, EventArgs e)
				{
						if (CbSemitoni.SelectedIndex != 11)
						{
								if (ActiveSheetForm != null)
										ActiveSheetForm.Traspose(((TrasposeCbItem)CbSemitoni.SelectedItem).howMany);

								CbSemitoni.SelectedIndex = 11;
						}
				}

				private void PbNormalized_Click(object sender, EventArgs e)
				{
						if (ActiveSheetForm != null)
								ActiveSheetForm.Normalize();
				}

				private void PbVerify_Click(object sender, EventArgs e)
				{
						if (ActiveSheet != null)
						{
								if (ActiveSheet.Header.Progress == Core.SheetHeader.SheetProgress.Verified)
								{
										ActiveSheet.Header.Progress = Core.SheetHeader.SheetProgress.Added;
										ActiveSheet.Header.VerifiedBy = "";
								}
								else if (ActiveSheet.Header.Progress == Core.SheetHeader.SheetProgress.Added)
								{
										ActiveSheet.Header.Progress = Core.SheetHeader.SheetProgress.Verified;
										ActiveSheet.Header.VerifiedBy = SVN.Username;
								}
								RefreshFileHeader();
						}
				}

				private void PbReview_Click(object sender, EventArgs e)
				{
						if (ActiveSheet != null)
						{
								if (VerifyMd5Hash(InputBox.Show("Privileged option", "Revisor Password?", "", true, true), "5e32071dfea812699c2582eb6ac00eb9"))
								{
										if (ActiveSheet.Header.Progress == Core.SheetHeader.SheetProgress.Reviewed)
										{
												ActiveSheet.Header.Progress = Core.SheetHeader.SheetProgress.Verified;
												ActiveSheet.Header.SheetRevisor = "";
										}
										else if (ActiveSheet.Header.Progress == Core.SheetHeader.SheetProgress.Verified)
										{
												ActiveSheet.Header.Progress = Core.SheetHeader.SheetProgress.Reviewed;
												ActiveSheet.Header.SheetRevisor = SVN.Username;
										}
										RefreshFileHeader();
								}
						}
				}


				static string GetMd5Hash(string input)
				{
						using (MD5 md5Hash = MD5.Create())
						{
								// Convert the input string to a byte array and compute the hash.
								byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

								// Create a new Stringbuilder to collect the bytes
								// and create a string.
								StringBuilder sBuilder = new StringBuilder();

								// Loop through each byte of the hashed data 
								// and format each one as a hexadecimal string.
								for (int i = 0; i < data.Length; i++)
								{
										sBuilder.Append(data[i].ToString("x2"));
								}

								// Return the hexadecimal string.
								return sBuilder.ToString();
						}
				}

				// Verify a hash against a string.
				static bool VerifyMd5Hash(string input, string hash)
				{
						if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(hash))
								return false;

						using (MD5 md5Hash = MD5.Create())
						{
								// Hash the input.
								string hashOfInput = GetMd5Hash(input);

								// Create a StringComparer an compare the hashes.
								StringComparer comparer = StringComparer.OrdinalIgnoreCase;

								if (0 == comparer.Compare(hashOfInput, hash))
								{
										return true;
								}
								else
								{
										return false;
								}
						}
				}


				private void PbLock_Click(object sender, EventArgs e)
				{
						if (ActiveSheet != null)
						{
								if (VerifyMd5Hash(InputBox.Show("Privileged option", "Lock Password?", "", true, true), "8af0c15085845360b61b67ea41a87cfb"))
								{
										if (ActiveSheet.Header.Progress == Core.SheetHeader.SheetProgress.Locked)
										{
												ActiveSheet.Header.Progress = Core.SheetHeader.SheetProgress.Reviewed;
												ActiveSheet.Header.LockedBy = "";
										}
										else if (ActiveSheet.Header.Progress == Core.SheetHeader.SheetProgress.Reviewed)
										{
												ActiveSheet.Header.Progress = Core.SheetHeader.SheetProgress.Locked;
												ActiveSheet.Header.LockedBy = SVN.Username;
										}
										RefreshFileHeader();
								}
						}
				}

				private void PbAdd_Click(object sender, EventArgs e)
				{
						;
				}
		}
}
