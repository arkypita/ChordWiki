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
            if (Settings.Default.CurrentRepo.Trim().Length > 0)
            {
                Uri uri = new Uri(Settings.Default.CurrentRepo);
                SetCurrentFolder(String.Format("./{0}{1}/", uri.Host, uri.AbsolutePath));
            }
            else
            {
                SetCurrentFolder(@"./localhost/database/");
            }

            SheetDB = new SheetDB();
            SheetDB.ReloadDataBase();
        }

        internal static void DatabaseSyncronize(System.Windows.Forms.Form form)
        {

            if (Settings.Default.CurrentRepo.Trim().Length == 0)
            {
                string repo = null;
                if (Forms.InputBox.Show(ref repo) == System.Windows.Forms.DialogResult.OK)
                {
                    repo = repo.Trim();

                    if (repo.Length == 0)
                        return;

                    Settings.Default.CurrentRepo = repo;
                    Settings.Default.Save();

                    Uri tmp = new Uri(Settings.Default.CurrentRepo);
                    SetCurrentFolder(String.Format("./{0}{1}/", tmp.Host, tmp.AbsolutePath));
                }
            }


            Uri uri = new Uri(Settings.Default.CurrentRepo);
            using (SharpSvn.SvnClient cln = new SharpSvn.SvnClient())
            {
                SharpSvn.UI.SvnUI.Bind(cln, form);

                if (cln.GetUriFromWorkingCopy(CurrentFolder) == null) //se non è un repository
                    cln.CheckOut(uri, CurrentFolder); //esegui un primo checkout

                foreach (string filename in System.IO.Directory.GetFiles(CurrentFolder))
                {
                    if (System.IO.Path.GetExtension(filename).ToLower() == ".cpw")
                    {
                        if (cln.GetUriFromWorkingCopy(filename) == null)
                            cln.Add(filename);
                    }
                }

                SharpSvn.SvnCommitArgs args = new SharpSvn.SvnCommitArgs();
                args.LogMessage = GenerateLogMessage();
                args.ThrowOnError = true;
                args.ThrowOnCancel = true;

                try
                {
                    SharpSvn.SvnCommitResult result;
                    cln.Commit(CurrentFolder, args, out result);
                }
                catch (Exception ex)
                {
                }
                cln.Update(CurrentFolder);
            }

            SheetDB.ReloadDataBase();
        }

        private static string GenerateLogMessage()
        { return string.Format("Committed @ {0} by user {1}", DateTime.Now, UserLongName); }

        public static string UserLongName
        { get { return "Diego Settimi"; } }

        private static string mCurrentFolder;
        public static string CurrentFolder
        { get { return mCurrentFolder; } }

        private static void SetCurrentFolder(string value)
        {
            if (value != mCurrentFolder)
            {
                mCurrentFolder = value;
                System.IO.Directory.CreateDirectory(mCurrentFolder); //ensure path
            }
        }
    }
}
