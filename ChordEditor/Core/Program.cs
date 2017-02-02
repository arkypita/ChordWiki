/*
 * Created by SharpDevelop.
 * User: Diego
 * Date: 19/01/2017
 * Time: 22:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace ChordEditor.Core
{
    /// <summary>
    /// Description of Core.
    /// </summary>
    public static class Program
    {
        private static string lotoftext = "Rianimo possono carrara gia sue milizie potermi affonda ora. Regge solca fossi mio poi lei. Vicende mia pei custode secondo ben trovare piacera pur. Ho finito vedrai te ad ah faccia. Ride moto vai vite anno mie sta otri anch ora. Intero col quindi fra scossa. ";
        private static string lotofspace = "                                                                                                             ";

        public delegate void SvnOperationDelegate(string message);
		public delegate void SvnOperationErrorDelegate(Exception ex);
        public static event SvnOperationDelegate SvnOperationBegin;
        public static event SvnOperationDelegate SvnOperationEnd;
        public static event SvnOperationDelegate SvnOperationMessage;
		public static event SvnOperationErrorDelegate SvnOperationError;

        public static SheetDB SheetDB;

        static Program()
        {
			System.IO.Directory.CreateDirectory(CurrentFolder); //ensure path

            SheetDB = new SheetDB();
        }

		private static void Revert(SharpSvn.SvnClient cln)
		{
			try { cln.Revert(CurrentFolder, new SharpSvn.SvnRevertArgs { Depth = SharpSvn.SvnDepth.Files, ThrowOnError = false, ThrowOnWarning = false }); }
            catch (Exception ex) {OnSvnEx(ex);}
		}

		private static void Cleanup(SharpSvn.SvnClient cln)
		{
			try { cln.CleanUp(CurrentFolder, new SharpSvn.SvnCleanUpArgs { ThrowOnError = false, ThrowOnWarning = false }); }
			catch (Exception ex) {OnSvnEx(ex);}
		}

		private static void DeleteUnversioned(SharpSvn.SvnClient cln)
		{
			try 
			{
				System.Collections.ObjectModel.Collection<SharpSvn.SvnStatusEventArgs> statuses;
				cln.GetStatus(Program.CurrentFolder, new SharpSvn.SvnStatusArgs { Depth = SharpSvn.SvnDepth.Files, RetrieveAllEntries = true, ThrowOnError = false, ThrowOnWarning = false }, out statuses);
				foreach (SharpSvn.SvnStatusEventArgs status in statuses)
				{
					if (System.IO.Path.GetExtension(status.Path).ToLower() == ".cpw" && status.LocalContentStatus == SharpSvn.SvnStatus.NotVersioned)
						System.IO.File.Delete(status.Path);
				}
			}
            catch (Exception ex) {OnSvnEx(ex);}
		}

		private static void CheckOutIfRequired(SharpSvn.SvnClient cln)
		{
            try
            {
				if (cln.GetUriFromWorkingCopy(CurrentFolder) == null) //se non è un repository
					CheckOut(cln); //esegui un primo checkout
            }
            catch (Exception ex) {OnSvnEx(ex);}
		}

		private static void CheckOut(SharpSvn.SvnClient cln)
		{
			try{cln.CheckOut(CurrentRepoUri, CurrentFolder, new SharpSvn.SvnCheckOutArgs { ThrowOnError = false, ThrowOnWarning = false }); }
			catch (Exception ex) { OnSvnEx(ex); }
		}

		private static void Update(SharpSvn.SvnClient cln)
		{
			try { cln.Update(CurrentFolder, new SharpSvn.SvnUpdateArgs { ThrowOnError = false, ThrowOnWarning = false }); }
            catch (Exception ex) {OnSvnEx(ex);}
		}

        private static void OnSvnEx(Exception ex)
        {
            if (SvnOperationError != null)
                SvnOperationError(ex);
        }

		private static void Commit(SharpSvn.SvnClient cln)
		{
			try{cln.Commit(CurrentFolder, new SharpSvn.SvnCommitArgs() { LogMessage = GenerateLogMessage(), ThrowOnError = false, ThrowOnWarning = false });}
            catch (Exception ex){OnSvnEx(ex);}
		}

		private static void CheckWorkingCopy()
		{
			bool show = false;
			using (SharpSvn.SvnClient cln = new SharpSvn.SvnClient())
			{
				show = VerifyURL(cln, Settings.CurrentRepo) != null ;
				if (show) cln.Authentication.Clear(); // Clear a previous authentication
			}		
			if (show)
				Forms.RegistrationBox.CreateAndShowDialog();
		}

		public static Exception VerifyURL(SharpSvn.SvnClient cln, string repo)
		{
			if (repo == "")
				return new Exception("Please fill repository information!");

			try
			{
                SharpSvn.SvnInfoEventArgs info;
				Uri totest = new Uri(Settings.CurrentRepo);

				if (totest.IsFile)
					throw new InvalidOperationException("Repository url needs to be an internet resource.");
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


        internal static void DatabaseSyncronize()
        {
            if (SvnOperationBegin != null)
                SvnOperationBegin("------ SYNCRONIZE ------");

            CheckWorkingCopy();

			if (!LocalOrInvalid)
			{
				System.Threading.Tasks.Task.Run(() =>
				{
					using (SharpSvn.SvnClient cln = new SharpSvn.SvnClient())
					{
						cln.Notify += cln_Notify;
						cln.SvnError += cln_SvnError;
						cln.Conflict += cln_Conflict;

						CheckOutIfRequired(cln);
						Commit(cln);
						Update(cln);

						cln.Notify -= cln_Notify;
						cln.SvnError -= cln_SvnError;
						cln.Conflict -= cln_Conflict;
					}

					SendOperationEnd();
					SheetDB.ReloadDataBase();
				});
			}
			else
				SendOperationSkip();
        }

		static void cln_Conflict(object sender, SharpSvn.SvnConflictEventArgs e)
		{
			e.Choice = SharpSvn.SvnAccept.Mine; //assume mine is better, i don't want to lose my job!
		}

		private static void SendOperationEnd()
		{
			if (SvnOperationEnd != null)
				SvnOperationEnd("Complete!");
		}

		private static void SendOperationSkip()
		{
			if (SvnOperationEnd != null)
				SvnOperationEnd("Skipped!");
		}

        static void cln_SvnError(object sender, SharpSvn.SvnErrorEventArgs e)
        {OnSvnEx(e.Exception);}

        static void cln_Notify(object sender, SharpSvn.SvnNotifyEventArgs e)
        {
            if (SvnOperationMessage != null)
            {
                string filename = e.FullPath != null ? System.IO.Path.GetFileName(e.FullPath) : "";
                SheetHeader sh = SheetDB.GetByFileName(filename);

                if (sh != null)
                    SvnOperationMessage(String.Format("{0}\t[{4}]\t{1}{2}{3}", e.Action, sh.Artist, sh.Artist != null ? @"\" : "", sh.Title, filename));
                else
                    SvnOperationMessage(String.Format("{0}\t[{1}]", e.Action, filename));
            }
        }

		internal static bool DatabaseHasChanges()
		{
			if (LocalOrInvalid)
				return false;


			bool rv = false;
			using (SharpSvn.SvnClient cln = new SharpSvn.SvnClient())
			{
				try 
				{
					cln.Status(CurrentFolder, delegate(object sender, SharpSvn.SvnStatusEventArgs e) 
						{
							if (e.LocalContentStatus == SharpSvn.SvnStatus.Modified || e.LocalContentStatus == SharpSvn.SvnStatus.Added || e.LocalContentStatus == SharpSvn.SvnStatus.Deleted)
							{rv = true; e.Cancel = true;}
						});
				}
				catch (Exception ex) 
				{ OnSvnEx(ex); }
			}
			return rv;
		}

		internal static void DatabaseDownload()
		{
            if (SvnOperationBegin != null)
                SvnOperationBegin("------ CHECKOUT ------");

			CheckWorkingCopy();

			if (!LocalOrInvalid)
			{
                System.Threading.Tasks.Task.Run(() =>
                {
                    using (SharpSvn.SvnClient cln = new SharpSvn.SvnClient())
                    {
                        cln.Notify += cln_Notify;
                        cln.SvnError += cln_SvnError;
						cln.Conflict += cln_Conflict;

                        CheckOutIfRequired(cln);
                        Update(cln);

                        cln.Notify -= cln_Notify;
                        cln.SvnError -= cln_SvnError;
						cln.Conflict -= cln_Conflict;
                    }


					SendOperationEnd();

                    SheetDB.ReloadDataBase();

                });
			}
			else
				SendOperationSkip();
		}

		internal static void DatabaseUpload()
		{
            if (SvnOperationBegin != null)
                SvnOperationBegin("------ COMMIT ------");

			CheckWorkingCopy();

			if (!LocalOrInvalid)
			{
                System.Threading.Tasks.Task.Run(() =>
                {
                    using (SharpSvn.SvnClient cln = new SharpSvn.SvnClient())
                    {
                        cln.Notify += cln_Notify;
                        cln.SvnError += cln_SvnError;
						cln.Conflict += cln_Conflict;

                        CheckOutIfRequired(cln);
                        Commit(cln);

                        cln.Notify -= cln_Notify;
                        cln.SvnError -= cln_SvnError;
						cln.Conflict -= cln_Conflict;
                    }

					SendOperationEnd();

                    SheetDB.ReloadDataBase();

                });
			}
			else
				SendOperationSkip();
		}

		
		internal static void TotalCleanup()
		{
			if (SvnOperationBegin != null)
				SvnOperationBegin("------ TOTAL CLEANUP ------");

			try 
			{
				System.IO.Directory.Delete(CurrentFolder, true);

				using (SharpSvn.SvnClient cln = new SharpSvn.SvnClient())
					CheckOut(cln);
			}
			catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.ToString()); }

			SendOperationEnd();

		}

		internal static void DatabaseCleanup()
		{
			if (SvnOperationBegin != null)
				SvnOperationBegin("------ CLEANUP ------");

			if (!LocalRepo)
			{
				System.Threading.Tasks.Task.Run(() =>
				{
					using (SharpSvn.SvnClient cln = new SharpSvn.SvnClient())
					{
						cln.Notify += cln_Notify;
						cln.SvnError += cln_SvnError;
							
						Revert(cln);
						Cleanup(cln);
						DeleteUnversioned(cln);

						cln.Notify -= cln_Notify;
						cln.SvnError -= cln_SvnError;
					}

					SendOperationEnd();

					SheetDB.ReloadDataBase();

				});
			}
			else
				SendOperationSkip();
		}

		internal static void DatabaseRevert()
		{
            if (SvnOperationBegin != null)
                SvnOperationBegin("------ REVERT ------");

			CheckWorkingCopy();

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

					SendOperationEnd();

                    SheetDB.ReloadDataBase();

                });
			}
			else
				SendOperationSkip();
 		}


        private static string GenerateLogMessage()
        { return string.Format("Committed @ {0} by user {1}", DateTime.Now, Username); }

        public static string Username
        {
            get { return Settings.Username; } 
            set { Settings.Username = value; } 
        }

		private static bool LocalRepo
		{ get { return Settings.LocalRepo; } }

		public static bool LocalOrInvalid
		{ get { return LocalRepo || CurrentRepoUri == null; } }

		private static Uri CurrentRepoUri
		{
			get
			{
				if (LocalRepo)
					return null;

				if (Settings.CurrentRepo == null || Settings.CurrentRepo.Trim().Length == 0)
					return null;

				try { return new Uri(Settings.CurrentRepo); }
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


		public static void Restart()
		{
			try{System.Windows.Forms.Application.Exit();}
			catch {}
			System.Diagnostics.Process P = new System.Diagnostics.Process();
			System.Diagnostics.Process.Start(System.Windows.Forms.Application.ExecutablePath);
		}

        internal static void ImportFile(string filename)
        {
            if (SvnOperationBegin != null)
                SvnOperationBegin("------ IMPORT FILE ------");

            string cat = Forms.InputBox.Show("Common category", "Category?");

            System.Threading.Tasks.Task.Run(() =>
            {
                try
                {
                    List<string> songs = new List<string>();
                    string font = Importer.ParseMSWord(filename, songs);
                    double charW = 1.0;
                    double spaceW = 1.0;
                    using (System.Drawing.Font f = new System.Drawing.Font(font, 10))
                    {
                        charW = System.Windows.Forms.TextRenderer.MeasureText(lotoftext, f).Width / (double)lotoftext.Length;
                        spaceW = System.Windows.Forms.TextRenderer.MeasureText(lotofspace, f).Width / (double)lotofspace.Length;
                    }

                    foreach (string song in songs)
                    {
                        if (!String.IsNullOrWhiteSpace(song.Trim()))
                        {
                            Importer.ImportedContent ic = Importer.ImportCOT(song, false, spaceW / charW);


                            Sheet sheet = new Sheet();
                            sheet.Header.Artist = ic.Artist;
                            sheet.Header.Title = ic.Title;
                            sheet.Header.SheetCategory = cat;

                            sheet.Content = Program.Normalize(ic.Text);
                            sheet.Save();

                            if (SvnOperationMessage != null)
                                SvnOperationMessage(String.Format("Import: {0}{1}{2}", ic.Title, ic.Artist != null ? " - " : "", ic.Artist));
                        }

                    }
                }
                catch (Exception ex) { OnSvnEx(ex); }

                SendOperationEnd();
                SheetDB.ReloadDataBase();

            });

            
        }

        internal static string Normalize(string source)
        {
            System.Text.StringBuilder text = new System.Text.StringBuilder(source);
            int offset = 0;

            foreach (System.Text.RegularExpressions.Match m in RegexList.Chords.ChordProNote.Matches(source))
            {
                System.Text.RegularExpressions.Group g = m.Groups[1];

                string oldChord = g.Value;
                string newChord = Core.Pagliaro.Normalize(oldChord);

                int position = g.Index + offset;
                text.Remove(position, oldChord.Length);
                text.Insert(position, newChord);

                offset += newChord.Length - oldChord.Length;
            }
            return text.ToString();
        }

        internal static string Traspose(string source, int semitones)
        {
            System.Text.StringBuilder text = new System.Text.StringBuilder(source);
            int offset = 0;

			foreach (System.Text.RegularExpressions.Match m in RegexList.Chords.ChordProNote.Matches(source))
            {
                System.Text.RegularExpressions.Group g = m.Groups[1];

                string oldChord = g.Value;
                string newChord = Core.Pagliaro.Traspose(oldChord, semitones);

                int position = g.Index + offset;
                text.Remove(position, oldChord.Length);
                text.Insert(position, newChord);

                offset += newChord.Length - oldChord.Length;
            }
            return text.ToString();
        }

        internal static string ChangeNotation(string source, ChordNotation targetNotation)
        {
            System.Text.StringBuilder text = new System.Text.StringBuilder(source);
            int offset = 0;

			foreach (System.Text.RegularExpressions.Match m in RegexList.Chords.ChordProNote.Matches(source))
            {
                System.Text.RegularExpressions.Group g = m.Groups[1];

                string oldChord = g.Value;
                string newChord = Core.Pagliaro.ChangeNotation(oldChord, targetNotation);

                int position = g.Index + offset;
                text.Remove(position, oldChord.Length);
                text.Insert(position, newChord);

                offset += newChord.Length - oldChord.Length;
            }
            return text.ToString();
        }
    }
}
