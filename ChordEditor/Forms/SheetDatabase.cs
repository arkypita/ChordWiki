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
using BrightIdeasSoftware;

namespace ChordEditor.Forms
{
		public partial class SheetDatabase : UserControls.DockingManager.DockContent
		{
				public SheetDatabase()
				{
						InitializeComponent();

						//this.ChProgress.ImageGetter = delegate(object rowObject)
						//{
						//		Core.SheetHeader sh = (Core.SheetHeader)rowObject;

						//		if (sh.Progress == Core.SheetHeader.SheetProgress.Added)
						//				return "incomplete";
						//		if (sh.Progress == Core.SheetHeader.SheetProgress.Verified)
						//				return "suspended";
						//		if (sh.Progress == Core.SheetHeader.SheetProgress.Reviewed)
						//				return "verified";
						//		if (sh.Progress == Core.SheetHeader.SheetProgress.Locked)
						//				return "locked";

						//		return null;
						//};


						this.ChProgress.Renderer = new MappedImageRenderer(new Object[] { 
																				Core.SheetHeader.SheetProgress.Added, IL.Images["incomplete"], 
																				Core.SheetHeader.SheetProgress.Verified, IL.Images["suspended"], 
																				Core.SheetHeader.SheetProgress.Reviewed, IL.Images["verified"], 
																				Core.SheetHeader.SheetProgress.Locked, IL.Images["locked"],
																				Core.SheetHeader.SheetProgress.Deleted, IL.Images["deleted"]
																				});

						LV.AboutToCreateGroups += (s, args) =>
						{
								foreach (var group in args.Groups)
								{
										if (group.Header == "{null}")
										{
												if (args.Parameters.GroupByColumn == ChRevisor)
														group.Header = "Not reviewed";
												else if (args.Parameters.GroupByColumn == ChCategory)
														group.Header = "Uncategorised";
												else if (args.Parameters.GroupByColumn == ChArtist)
														group.Header = "Unknown artist";
												else if (args.Parameters.GroupByColumn == ChTitle)
														group.Header = "No Title";
										}

										if (args.Parameters.GroupByColumn == ChProgress)
												group.Header = group.Header;
								}
						};

						LV.BeforeCreatingGroups += LV_BeforeCreatingGroups;
						SheetDB.ListChanged += SheetDB_ListChanged;
				}

				void LV_BeforeCreatingGroups(object sender, CreateGroupsEventArgs e)
				{
						//GroupComparer property on the event argument block. This comparer controls the ordering of the groups.

						if (e.Parameters.GroupByColumn == ChProgress)
								e.Parameters.GroupComparer = new ProgressComparer(e.Parameters.GroupByOrder);
				}

				private class ProgressComparer : System.Collections.Generic.IComparer<BrightIdeasSoftware.OLVGroup>
				{
						private SortOrder sortOrder;

						public ProgressComparer(SortOrder sortOrder)
						{
								// TODO: Complete member initialization
								this.sortOrder = sortOrder;
						}

						public int Compare(OLVGroup x, OLVGroup y)
						{
								SheetHeader.SheetProgress px = (SheetHeader.SheetProgress)x.Key;
								SheetHeader.SheetProgress py = (SheetHeader.SheetProgress)y.Key;

								if (px == py)
										return 0;
								else if (px == SheetHeader.SheetProgress.Deleted)
										return 1;
								else if (py == SheetHeader.SheetProgress.Deleted)
										return -1;
								else
										return sortOrder == SortOrder.Ascending ? px.CompareTo(py) : py.CompareTo(px);
						}
				}

				void SheetDB_ListChanged()
				{
						if (InvokeRequired)
						{
								Invoke(new SheetDB.ListChangedDelegate(SheetDB_ListChanged));
						}
						else
						{
								
								LV.BuildList();
								LV_SelectionChanged(null, null);
						}
				}

				private void SheetDatabase_Load(object sender, EventArgs e)
				{
						LV.SetObjects(SheetDB.List);

						byte[] state = Settings.LVState;
						if (state != null)
								LV.RestoreState(state);
				}

				private void LV_SelectionChanged(object sender, EventArgs e)
				{
						BtnOpen.Enabled = LV.SelectedObjects.Count > 0;
						BtnDelete.Enabled = LV.SelectedObjects.Count > 0;
						BtnUndelete.Enabled = LV.SelectedObjects.Count > 0;

						BtnErase.Enabled = LV.SelectedObjects.Count > 0;
				}

				private void BtnOpen_Click(object sender, EventArgs e)
				{
						foreach (Core.SheetHeader sh in LV.SelectedObjects)
								FocusOrCreate(sh);
				}

				private void FocusOrCreate(Core.SheetHeader sh)
				{
						SheetForm sf = null;
						foreach (UserControls.DockingManager.DockContent dc in DockPanel.Documents)
						{
								if (dc is SheetForm && object.Equals(((SheetForm)dc).Sheet.Header, sh))
								{
										sf = dc as SheetForm;
										break;
								}
						}

						if (sf != null)
								sf.Show();
						else
								Forms.SheetForm.CreateAndShow(new Core.Sheet(sh.FileName), DockPanel);
				}

				private void LV_ItemActivate(object sender, EventArgs e)
				{
						Core.SheetHeader sh = LV.SelectedObject as Core.SheetHeader;
						if (sh != null) FocusOrCreate(sh);
				}

				private void BtnNew_Click(object sender, EventArgs e)
				{
						Forms.SheetForm.CreateAndShow(new Core.Sheet(), DockPanel);
				}

				private void BtnDelete_Click(object sender, EventArgs e)
				{
						List<string> paths = new List<string>();
						foreach (Core.SheetHeader sh in LV.SelectedObjects)
								if (System.IO.File.Exists(sh.FilePath) && sh.Progress < SheetHeader.SheetProgress.Reviewed && !sh.Deletable)
										paths.Add(sh.FilePath);

						SVN.MarkForDeletion(paths); //mark for deletion
						SheetDB.ReloadDataBase();
				}

				private void LV_KeyDown(object sender, KeyEventArgs e)
				{
						if (e.KeyCode == Keys.Delete)
								BtnDelete_Click(sender, e);
				}

				public void TimedFilter(ObjectListView olv, string txt)
				{
						TimedFilter(olv, txt, 0);
				}

				public void TimedFilter(ObjectListView olv, string txt, int matchKind)
				{
						TextMatchFilter filter = null;
						if (!String.IsNullOrEmpty(txt))
						{
								switch (matchKind)
								{
										case 0:
										default:
												filter = TextMatchFilter.Contains(olv, txt);
												break;
										case 1:
												filter = TextMatchFilter.Prefix(olv, txt);
												break;
										case 2:
												filter = TextMatchFilter.Regex(olv, txt);
												break;
								}
						}

						// Text highlighting requires at least a default renderer
						if (olv.DefaultRenderer == null)
								olv.DefaultRenderer = new HighlightTextRenderer(filter);

						//Stopwatch stopWatch = new Stopwatch();
						//stopWatch.Start();
						olv.AdditionalFilter = filter;
						olv.Invalidate();
						//stopWatch.Stop();

						/*
						IList objects = olv.Objects as IList;
						if (objects == null)
								this.ToolStripStatus1 = prefixForNextSelectionMessage =
										String.Format("Filtered in {0}ms", stopWatch.ElapsedMilliseconds);
						else
								this.ToolStripStatus1 = prefixForNextSelectionMessage =
										String.Format("Filtered {0} items down to {1} items in {2}ms",
																	objects.Count,
																	olv.Items.Count,
																	stopWatch.ElapsedMilliseconds);
						 */
				}

				private void LV_BeforeSearching(object sender, BeforeSearchingEventArgs e)
				{
						if (string.IsNullOrEmpty(e.StringToFind))
						{
								LV.AdditionalFilter = null;
								LV.Invalidate();
								LV.EmptyListMsg = "";
						}
						else
						{
								TimedFilter(LV, e.StringToFind);
								LV.EmptyListMsg = "No match. Press \"Esc\" to clear search filter!";
						}

						e.Canceled = true;
				}

				private void LV_FormatRow(object sender, FormatRowEventArgs e)
				{
						SheetHeader sh = (SheetHeader)e.Model;
						if (sh.Deletable)
						{
								e.Item.ForeColor = Color.Red;
								e.Item.Font = new Font(e.Item.Font, FontStyle.Strikeout);
						}

				}

				private void BtnUndelete_Click(object sender, EventArgs e)
				{
						List<string> paths = new List<string>();
						foreach (Core.SheetHeader sh in LV.SelectedObjects)
								if (System.IO.File.Exists(sh.FilePath) && sh.Deletable)
										paths.Add(sh.FilePath);

						SVN.UnMarkForDeletion(paths); //unmark for deletion
						SheetDB.ReloadDataBase();
				}

				private void BtnErase_Click(object sender, EventArgs e)
				{
						List<string> paths = new List<string>();
						foreach (Core.SheetHeader sh in LV.SelectedObjects)
								if (System.IO.File.Exists(sh.FilePath) && sh.Progress < SheetHeader.SheetProgress.Reviewed)
										paths.Add(sh.FilePath);
						
						SVN.TrueDelete(paths); //erase
						SheetDB.ReloadDataBase();
				}

				private void SheetDatabase_Shown(object sender, EventArgs e)
				{
						BtnErase.Visible = Settings.SuperUser && !SVN.LocalOrInvalid;
						BtnUndelete.Visible = !SVN.LocalOrInvalid;
				}

				private void SheetDatabase_FormClosing(object sender, FormClosingEventArgs e)
				{
						Settings.LVState = LV.SaveState();
				}

		}
}
