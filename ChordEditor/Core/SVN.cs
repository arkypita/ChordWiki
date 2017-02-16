using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChordEditor.Core;

namespace ChordEditor.Core
{
		public static class SVN
		{
				public delegate void SvnBeginMessage(string message);
				public delegate void SvnEndMessage(string message, bool reload);
				public delegate void SvnFileAction(string filename, SharpSvn.SvnNotifyAction action);
				public delegate void SvnOperationError(Exception ex);
				public static event SvnBeginMessage SvnBegin;
				public static event SvnEndMessage SvnEnd;
				public static event SvnFileAction SvnAction;
				public static event SvnOperationError SvnError;

				private static SharpSvn.SvnClient cln;

				static SVN()
				{
						Recreate();
				}

				public static void Recreate()
				{
						Dispose();
						cln = new SharpSvn.SvnClient();
						cln.Notify += OnNotify;
						cln.SvnError += OnError;
						cln.Conflict += OnConflict;
				}

				public static void Dispose()
				{
						if (cln != null)
						{
								cln.Notify -= OnNotify;
								cln.SvnError -= OnError;
								cln.Conflict -= OnConflict;
								cln.Dispose();
						}
				}

				public static string Username
				{
						get { return Settings.Username; }
						set { Settings.Username = value; }
				}

				public static bool LocalOrInvalid
				{ get { return UseLocalRepo || CurrentRepoUri == null; } }

				public static string CurrentFolder
				{
						get
						{
								string path;

								if (LocalOrInvalid)
										path = @"./localhost/database/";
								else
										path = String.Format("./{0}{1}/", CurrentRepoUri.Host, CurrentRepoUri.AbsolutePath);

								System.IO.Directory.CreateDirectory(path); //ensure path
								return path;
						}
				}

				public static bool DatabaseHasChanges()
				{
						if (LocalOrInvalid)
								return false;

						return HasChanges();
				}

				public static void DatabaseDownload()
				{
						SendOperationBegin("------ CHECKOUT ------");

						if (CheckWorkingCopy())
								System.Threading.Tasks.Task.Run(() =>
								{
										lock (cln)
										{
												CheckOutIfRequired();
												Update();
										}
										SendOperationEnd();
								});
						else
								SendOperationSkip();
				}

				public static void DatabaseUpload()
				{
						SendOperationBegin("------ COMMIT ------");

						if (CheckWorkingCopy())
								System.Threading.Tasks.Task.Run(() =>
								{
										lock (cln)
										{
												CheckOutIfRequired();
												Commit();
										}
										SendOperationEnd();
								});
						else
								SendOperationSkip();
				}


				public static void TotalCleanup()
				{
						SendOperationBegin("------ TOTAL CLEANUP ------");

						try
						{
								System.IO.Directory.Delete(CurrentFolder, true);
								lock (cln)
										CheckOut();
						}
						catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.ToString()); }

						SendOperationEnd();
				}

				public static void DatabaseCleanup()
				{
						SendOperationBegin("------ CLEANUP ------");

						if (!UseLocalRepo)
								System.Threading.Tasks.Task.Run(() =>
								{
										lock (cln)
										{
												Revert();
												Cleanup();
												DeleteUnversioned();
										}
										SendOperationEnd();
								});
						else
								SendOperationSkip();
				}

				public static void DatabaseRevert()
				{
						SendOperationBegin("------ REVERT ------");

						if (CheckWorkingCopy())
								System.Threading.Tasks.Task.Run(() =>
								{
										lock (cln)
										{
												Revert();
												DeleteUnversioned();
										}
										SendOperationEnd();
								});
						else
								SendOperationSkip();
				}

				public static void AddFile(string filepath)
				{
						try
						{
								if (!UseLocalRepo)
								{
										lock (cln)
												cln.Add(filepath); //mark for svn add
								}
						}
						catch (Exception ex) { }
				}


				public static void MarkForDeletion(string p)
				{
						try
						{
								if (!UseLocalRepo)
								{
										lock (cln)
												cln.SetProperty(p, "deletable", "true");
								}
						}
						catch (Exception ex) { }
				}

				public static void UnMarkForDeletion(string p)
				{
						try
						{
								if (!UseLocalRepo)
								{
										lock (cln)
												cln.DeleteProperty(p, "deletable");
								}
						}
						catch (Exception ex) { }
				}

				private static void TrueDelete(string p)
				{
						try
						{
								if (!UseLocalRepo)
								{
										lock (cln)
												cln.Delete(p, new SharpSvn.SvnDeleteArgs() { Force = true });
								}
						}
						catch (Exception ex) { }
				}


				private static Exception VerifyRepo()
				{
						if (Core.Settings.CurrentRepo == "")
								return new Exception("Please fill repository information!");

						try
						{
								SharpSvn.SvnInfoEventArgs info;
								Uri totest = new Uri(Core.Settings.CurrentRepo);

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


				public static void DatabaseSyncronize()
				{
						SendOperationBegin("------ SYNCRONIZE ------");

						if (CheckWorkingCopy())
								System.Threading.Tasks.Task.Run(() =>
								{
										lock (cln)
										{
												CheckOutIfRequired();
												Commit();
												Update();
										}
										SendOperationEnd();
								});
						else
								SendOperationSkip();
				}

				public static System.Collections.Generic.Dictionary<string, SharpSvn.SvnStatus> GetAllFileStatus(string directory)
				{
						if (!UseLocalRepo)
						{
								lock (cln)
										return GetStatus(directory);
						}
						else
								return new Dictionary<string, SharpSvn.SvnStatus>();
				}

				public static System.Collections.Generic.Dictionary<string, SharpSvn.SvnPropertyCollection> GetAllFileProperty(string directory)
				{
						if (!UseLocalRepo)
						{
								lock (cln)
										return GetProps(directory);
						}
						else
								return new Dictionary<string, SharpSvn.SvnPropertyCollection>();
				}

				#region Property private

				private static bool UseLocalRepo
				{ get { return Settings.LocalRepo; } }

				private static Uri CurrentRepoUri
				{
						get
						{
								if (UseLocalRepo)
										return null;

								if (Settings.CurrentRepo == null || Settings.CurrentRepo.Trim().Length == 0)
										return null;

								try { return new Uri(Settings.CurrentRepo); }
								catch { return null; }
						}
				}

				#endregion

				#region Funzioni private

				private static System.Collections.Generic.Dictionary<string, SharpSvn.SvnPropertyCollection> GetProps(string directory)
				{
						System.Collections.Generic.Dictionary<string, SharpSvn.SvnPropertyCollection> rv = new System.Collections.Generic.Dictionary<string, SharpSvn.SvnPropertyCollection>();

						try
						{
								System.Collections.ObjectModel.Collection<SharpSvn.SvnPropertyListEventArgs> props;
								cln.GetPropertyList(directory, new SharpSvn.SvnPropertyListArgs { Depth = SharpSvn.SvnDepth.Files}, out props);

								foreach (SharpSvn.SvnPropertyListEventArgs ea in props)
										rv.Add(System.IO.Path.GetFileName(ea.Path).ToLower(), ea.Properties);
						}
						catch (Exception ex) { }

						return rv;
				}


				private static System.Collections.Generic.Dictionary<string, SharpSvn.SvnStatus> GetStatus(string directory)
				{
						System.Collections.Generic.Dictionary<string, SharpSvn.SvnStatus> rv = new System.Collections.Generic.Dictionary<string, SharpSvn.SvnStatus>();

						try
						{
								System.Collections.ObjectModel.Collection<SharpSvn.SvnStatusEventArgs> statuses;
								cln.GetStatus(directory, new SharpSvn.SvnStatusArgs { Depth = SharpSvn.SvnDepth.Files, RetrieveAllEntries = true }, out statuses);

								foreach (SharpSvn.SvnStatusEventArgs ea in statuses)
										rv.Add(System.IO.Path.GetFileName(ea.FullPath).ToLower(), ea.LocalContentStatus);
						}
						catch (Exception ex) { }

						return rv;
				}

				private static void Revert()
				{
						try { cln.Revert(CurrentFolder, new SharpSvn.SvnRevertArgs { Depth = SharpSvn.SvnDepth.Files, ThrowOnError = false, ThrowOnWarning = false }); }
						catch (Exception ex) { OnSvnEx(ex); }
				}

				private static void Cleanup()
				{
						try { cln.CleanUp(CurrentFolder, new SharpSvn.SvnCleanUpArgs { ThrowOnError = false, ThrowOnWarning = false }); }
						catch (Exception ex) { OnSvnEx(ex); }
				}

				private static void DeleteUnversioned()
				{
						try
						{
								System.Collections.ObjectModel.Collection<SharpSvn.SvnStatusEventArgs> statuses;
								cln.GetStatus(CurrentFolder, new SharpSvn.SvnStatusArgs { Depth = SharpSvn.SvnDepth.Files, RetrieveAllEntries = true, ThrowOnError = false, ThrowOnWarning = false }, out statuses);
								foreach (SharpSvn.SvnStatusEventArgs status in statuses)
								{
										if (System.IO.Path.GetExtension(status.Path).ToLower() == ".cpw" && status.LocalContentStatus == SharpSvn.SvnStatus.NotVersioned)
												System.IO.File.Delete(status.Path);
								}
						}
						catch (Exception ex) { OnSvnEx(ex); }
				}

				private static void CheckOutIfRequired()
				{
						try
						{
								if (cln.GetUriFromWorkingCopy(CurrentFolder) == null) //se non è un repository
										CheckOut(); //esegui un primo checkout
						}
						catch (Exception ex) { OnSvnEx(ex); }
				}

				private static void CheckOut()
				{
						try { cln.CheckOut(CurrentRepoUri, CurrentFolder, new SharpSvn.SvnCheckOutArgs { ThrowOnError = false, ThrowOnWarning = false }); }
						catch (Exception ex) { OnSvnEx(ex); }
				}

				private static void Update()
				{
						try { cln.Update(CurrentFolder, new SharpSvn.SvnUpdateArgs { ThrowOnError = false, ThrowOnWarning = false }); }
						catch (Exception ex) { OnSvnEx(ex); }
				}

				private static void OnSvnEx(Exception ex)
				{
						if (SvnError != null)
								SvnError(ex);
				}

				private static void Commit()
				{
						try { cln.Commit(CurrentFolder, new SharpSvn.SvnCommitArgs() { LogMessage = GenerateLogMessage(), ThrowOnError = false, ThrowOnWarning = false }); }
						catch (Exception ex) { OnSvnEx(ex); }
				}

				private static bool CheckWorkingCopy()
				{
						bool show = VerifyRepo() != null;
						if (show) cln.Authentication.Clear(); // Clear a previous authentication
						if (show) Forms.RegistrationBox.CreateAndShowDialog();

						return !LocalOrInvalid;
				}

				private static void OnConflict(object sender, SharpSvn.SvnConflictEventArgs e)
				{
						SheetHeader sh = SheetDB.GetByFileNameWithDeleted(System.IO.Path.GetFileName(e.Path));

						if (sh != null && sh.Progress >= SheetHeader.SheetProgress.Reviewed)
								e.Choice = SharpSvn.SvnAccept.Mine; //assume mine is better, i don't want to lose my job!
						else
								e.Choice = SharpSvn.SvnAccept.Theirs; //assume theris is better
				}

				private static void SendOperationBegin(string message)
				{
						if (SvnBegin != null)
								SvnBegin(message);
				}

				private static void SendOperationEnd()
				{
						if (SvnEnd != null)
								SvnEnd("Complete!", true);
				}

				private static void SendOperationSkip()
				{
						if (SvnEnd != null)
								SvnEnd("Skipped!", false);
				}

				private static void OnError(object sender, SharpSvn.SvnErrorEventArgs e)
				{ OnSvnEx(e.Exception); }

				private static void OnNotify(object sender, SharpSvn.SvnNotifyEventArgs e)
				{
						if (SvnAction != null)
						{
								string filename = e.FullPath != null ? System.IO.Path.GetFileName(e.FullPath) : "";
								SvnAction(filename, e.Action);
						}
				}

				private static bool HasChanges()
				{
						bool rv = false;

						try
						{
								cln.Status(CurrentFolder, delegate(object sender, SharpSvn.SvnStatusEventArgs e)
								{
										if (e.LocalContentStatus == SharpSvn.SvnStatus.Modified || e.LocalContentStatus == SharpSvn.SvnStatus.Added || e.LocalContentStatus == SharpSvn.SvnStatus.Deleted)
										{ rv = true; e.Cancel = true; }
								});
						}
						catch (Exception ex)
						{ OnSvnEx(ex); }

						return rv;
				}


				private static string GenerateLogMessage()
				{ return string.Format("Committed @ {0} by user {1}", DateTime.Now, Username); }

				#endregion



		}
}
