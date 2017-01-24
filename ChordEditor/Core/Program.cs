/*
 * Created by SharpDevelop.
 * User: Diego
 * Date: 19/01/2017
 * Time: 22:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ChordEditor.Core
{
    /// <summary>
    /// Description of Core.
    /// </summary>
    public static class Program
    {
        public static SheetDB SheetDB;

        static Program()
        {
            //Settings.Default.Reset(); //reset config
			Settings.Default.Upgrade();
			

			System.IO.Directory.CreateDirectory(CurrentFolder); //ensure path

            SheetDB = new SheetDB();
            SheetDB.ReloadDataBase();
        }

        internal static void DatabaseSyncronize(System.Windows.Forms.Form form)
        {
			CheckWorkingCopy(form);

			if (!LocalOrInvalid)
			{
				using (SharpSvn.SvnClient cln = new SharpSvn.SvnClient())
				{
					SharpSvn.UI.SvnUI.Bind(cln, form);

					CheckOutRequired(cln);
					LogCommit(cln);
					Commit(cln);
					Update(cln);
				}
            }

            SheetDB.ReloadDataBase();
        }

		private static void LogCommit(SharpSvn.SvnClient cln)
		{
			//SharpSvn.SvnStatusArgs statusArgs = new SharpSvn.SvnStatusArgs();
			//statusArgs.Depth = SharpSvn.SvnDepth.Files;
			//statusArgs.RetrieveAllEntries = true;
			//System.Collections.ObjectModel.Collection<SharpSvn.SvnStatusEventArgs> statuses;
			//cln.GetStatus(CurrentFolder, statusArgs, out statuses);
			//foreach (SharpSvn.SvnStatusEventArgs status in statuses)
			//	Console.WriteLine(String.Format("{0}: {1}", status.LocalContentStatus, status.Path));
		}

		private static void CheckOutRequired(SharpSvn.SvnClient cln)
		{
			if (cln.GetUriFromWorkingCopy(CurrentFolder) == null) //se non è un repository
				cln.CheckOut(CurrentRepoUri, CurrentFolder); //esegui un primo checkout
		}

		private static void Update(SharpSvn.SvnClient cln)
		{
			try { cln.Update(CurrentFolder); }
			catch { }
		}

		private static void Commit(SharpSvn.SvnClient cln)
		{
			try
			{
				SharpSvn.SvnCommitResult result;
				cln.Commit(CurrentFolder, new SharpSvn.SvnCommitArgs() { LogMessage = GenerateLogMessage(), ThrowOnError = true }, out result);
			}
			catch (Exception ex) { }
		}

		private static void CheckWorkingCopy(System.Windows.Forms.Form form)
		{
			if (LocalOrInvalid)
			{
				string repo = Forms.InputBox.Show("Database URL", "Url?");
				if (repo != null) //verify repo
				{
					using (SharpSvn.SvnClient cln = new SharpSvn.SvnClient())
					{
						SharpSvn.UI.SvnUI.Bind(cln, form);

						SharpSvn.SvnInfoEventArgs info;

						SharpSvn.SvnInfoArgs args = new SharpSvn.SvnInfoArgs();
						args.ThrowOnError = true;
						args.ThrowOnCancel = true;

						try
						{
							Uri totest = new Uri(repo);

							if (totest.IsFile)
								throw new InvalidOperationException("Repository url needs to be an internet resource.");

							cln.GetInfo(SharpSvn.SvnTarget.FromUri(totest), out info);
							if (info.NodeKind != SharpSvn.SvnNodeKind.Directory)
								throw new InvalidOperationException("Url does not point to a valid repository folder.");
						}
						catch (Exception ex) //not a valid url
						{
							System.Windows.Forms.MessageBox.Show(ex.Message, "Invalid repository!", System.Windows.Forms.MessageBoxButtons.OK,
																	System.Windows.Forms.MessageBoxIcon.Error);
							repo = null;
						}
					}
				}

				Settings.Default.CurrentRepo = repo;
				Settings.Default.LocalRepo = repo == null;
				Settings.Default.Save();
			}
		}

		internal static void DatabaseDownload(System.Windows.Forms.Form form)
		{
			CheckWorkingCopy(form);

			if (!LocalOrInvalid)
			{
				using (SharpSvn.SvnClient cln = new SharpSvn.SvnClient())
				{
					SharpSvn.UI.SvnUI.Bind(cln, form);

					CheckOutRequired(cln);
					Update(cln);
				}
			}

			SheetDB.ReloadDataBase();
		}

		internal static void DatabaseUpload(System.Windows.Forms.Form form)
		{
			CheckWorkingCopy(form);

			if (!LocalOrInvalid)
			{
				using (SharpSvn.SvnClient cln = new SharpSvn.SvnClient())
				{
					SharpSvn.UI.SvnUI.Bind(cln, form);

					CheckOutRequired(cln);
					LogCommit(cln);
					Commit(cln);
				}
			}

			SheetDB.ReloadDataBase();
		}


        private static string GenerateLogMessage()
        { return string.Format("Committed @ {0} by user {1}", DateTime.Now, UserLongName); }

        public static string UserLongName
        { get { return "Diego Settimi"; } }




		private static bool LocalRepo
		{ get { return Settings.Default.LocalRepo; } }

		public static bool LocalOrInvalid
		{ get { return LocalRepo || CurrentRepoUri == null; } }

		private static Uri CurrentRepoUri
		{
			get
			{
				if (LocalRepo)
					return null;

				if (Settings.Default.CurrentRepo == null || Settings.Default.CurrentRepo.Trim().Length == 0)
					return null;

				try { return new Uri(Settings.Default.CurrentRepo); }
				catch { return null; }
			}
		}

		public static string CurrentFolder
		{
			get
			{
				if (LocalOrInvalid)
					return @"./localhost/database/";
				else
					return String.Format("./{0}{1}/", CurrentRepoUri.Host, CurrentRepoUri.AbsolutePath);
			}
		}



	}
}
