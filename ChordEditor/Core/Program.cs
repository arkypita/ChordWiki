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
        public delegate void SvnOperationDelegate(string message);
        public static event SvnOperationDelegate SvnOperationBegin;
        public static event SvnOperationDelegate SvnOperationEnd;
        public static event SvnOperationDelegate SvnOperationMessage;
        public static event SvnOperationDelegate SvnOperationError;

        public static SheetDB SheetDB;

        static Program()
        {
            //Settings.Default.Reset(); //reset config
			Settings.Default.Upgrade();
			

			System.IO.Directory.CreateDirectory(CurrentFolder); //ensure path

            SheetDB = new SheetDB();
            SheetDB.ReloadDataBase();
        }

		private static void Revert(SharpSvn.SvnClient cln)
		{
			try {cln.Revert(CurrentFolder, new SharpSvn.SvnRevertArgs { Depth = SharpSvn.SvnDepth.Files }); }
            catch (Exception ex)
            {
                OnSvnEx(ex);
            }
		}

		private static void DeleteUnversioned(SharpSvn.SvnClient cln)
		{
			try 
			{
				SharpSvn.SvnStatusArgs statusArgs = new SharpSvn.SvnStatusArgs();
				statusArgs.Depth = SharpSvn.SvnDepth.Files;
				statusArgs.RetrieveAllEntries = true;
				System.Collections.ObjectModel.Collection<SharpSvn.SvnStatusEventArgs> statuses;
				cln.GetStatus(Program.CurrentFolder, statusArgs, out statuses);
				foreach (SharpSvn.SvnStatusEventArgs status in statuses)
				{
					if (System.IO.Path.GetExtension(status.Path).ToLower() == ".cpw" && status.LocalContentStatus == SharpSvn.SvnStatus.NotVersioned)
						System.IO.File.Delete(status.Path);
				}
			}
            catch (Exception ex)
            {
                OnSvnEx(ex);
            }
		}

		private static void CheckOutRequired(SharpSvn.SvnClient cln)
		{
            try
            {
                if (cln.GetUriFromWorkingCopy(CurrentFolder) == null) //se non è un repository
                    cln.CheckOut(CurrentRepoUri, CurrentFolder); //esegui un primo checkout
            }
            catch (Exception ex)
            {
                OnSvnEx(ex);
            }
		}

		private static void Update(SharpSvn.SvnClient cln)
		{
			try { cln.Update(CurrentFolder); }
            catch (Exception ex)
            {
                OnSvnEx(ex);
            }
		}

        private static void OnSvnEx(Exception ex)
        {
            if (SvnOperationError != null)
                SvnOperationError(ex.ToString());
        }

		private static void Commit(SharpSvn.SvnClient cln)
		{
			try
			{
				SharpSvn.SvnCommitResult result;
				cln.Commit(CurrentFolder, new SharpSvn.SvnCommitArgs() { LogMessage = GenerateLogMessage(), ThrowOnError = true }, out result);
			}
            catch (Exception ex)
            {
                OnSvnEx(ex);
            }
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


        internal static void DatabaseSyncronize(System.Windows.Forms.Form form)
        {
            if (SvnOperationBegin != null)
                SvnOperationBegin("------ SYNCRONIZE ------");

            CheckWorkingCopy(form);

            if (!LocalOrInvalid)
            {
                System.Threading.Tasks.Task.Run(() =>
                {
                    using (SharpSvn.SvnClient cln = new SharpSvn.SvnClient())
                    {
                        cln.Notify += cln_Notify;
                        cln.SvnError += cln_SvnError;

                        CheckOutRequired(cln);
                        Commit(cln);
                        Update(cln);

                        cln.Notify += cln_Notify;
                        cln.SvnError += cln_SvnError;
                    }

                    if (SvnOperationEnd != null)
                        SvnOperationEnd("Complete!");

                    SheetDB.ReloadDataBase();

                });
            }
        }

        static void cln_SvnError(object sender, SharpSvn.SvnErrorEventArgs e)
        {
            if (SvnOperationError != null)
                SvnOperationError(e.Exception.Message);
        }

        static void cln_Notify(object sender, SharpSvn.SvnNotifyEventArgs e)
        {
            if (SvnOperationMessage != null)
            {
                string filename = e.FullPath != null ? System.IO.Path.GetFileName(e.FullPath) : "";
                SheetHeader sh = SheetDB.GetByFileName(filename);

                if (sh != null)
                    SvnOperationMessage(String.Format("{0}\t{1}{2}{3}\t[{4}]", e.Action, sh.Artist, sh.Artist != null ? @"\" : "", sh.Title, filename));
                else
                    SvnOperationMessage(String.Format("{0}\t[{1}]", e.Action, filename));
            }
        }

		internal static void DatabaseDownload(System.Windows.Forms.Form form)
		{
            if (SvnOperationBegin != null)
                SvnOperationBegin("------ CHECKOUT ------");

			CheckWorkingCopy(form);

			if (!LocalOrInvalid)
			{
                System.Threading.Tasks.Task.Run(() =>
                {
                    using (SharpSvn.SvnClient cln = new SharpSvn.SvnClient())
                    {
                        cln.Notify += cln_Notify;
                        cln.SvnError += cln_SvnError;

                        CheckOutRequired(cln);
                        Update(cln);

                        cln.Notify -= cln_Notify;
                        cln.SvnError -= cln_SvnError;
                    }


                    if (SvnOperationEnd != null)
                        SvnOperationEnd("Complete!");

                    SheetDB.ReloadDataBase();

                });
			}
		}

		internal static void DatabaseUpload(System.Windows.Forms.Form form)
		{
            if (SvnOperationBegin != null)
                SvnOperationBegin("------ COMMIT ------");

			CheckWorkingCopy(form);

			if (!LocalOrInvalid)
			{
                System.Threading.Tasks.Task.Run(() =>
                {
                    using (SharpSvn.SvnClient cln = new SharpSvn.SvnClient())
                    {
                        cln.Notify += cln_Notify;
                        cln.SvnError += cln_SvnError;

                        CheckOutRequired(cln);
                        Commit(cln);

                        cln.Notify -= cln_Notify;
                        cln.SvnError -= cln_SvnError;
                    }

                    if (SvnOperationEnd != null)
                        SvnOperationEnd("Complete!");

                    SheetDB.ReloadDataBase();

                });
			}
		}

		internal static void DatabaseRevert(System.Windows.Forms.Form form)
		{
            if (SvnOperationBegin != null)
                SvnOperationBegin("------ REVERT ------");

			CheckWorkingCopy(form);

			if (!LocalOrInvalid)
			{
                System.Threading.Tasks.Task.Run(() =>
                {
                    using (SharpSvn.SvnClient cln = new SharpSvn.SvnClient())
                    {
                        cln.Notify += cln_Notify;
                        cln.SvnError += cln_SvnError;

                        Revert(cln);
                        DeleteUnversioned(cln);

                        cln.Notify -= cln_Notify;
                        cln.SvnError -= cln_SvnError;
                    }

                    if (SvnOperationEnd != null)
                        SvnOperationEnd("Complete!");

                    SheetDB.ReloadDataBase();

                });
			}
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
