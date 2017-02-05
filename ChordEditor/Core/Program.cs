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



        public static SheetDB SheetDB;

        static Program()
        {
            SheetDB = new SheetDB();
        }


        public static string CurrentFolder
        { get { return SVN.CurrentFolder; } }





		public static void Restart()
		{
			try{System.Windows.Forms.Application.Exit();}
			catch {}
			System.Diagnostics.Process P = new System.Diagnostics.Process();
			System.Diagnostics.Process.Start(System.Windows.Forms.Application.ExecutablePath);
		}

        internal static void ImportFile(string filename)
        {
            //if (SvnOperationBegin != null)
            //    SvnOperationBegin("------ IMPORT FILE ------");

            string cat = Forms.InputBox.Show("Common category", "Category?");
            string aut = Forms.InputBox.Show("Common author", "Author?");

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
                            sheet.Header.SheetAuthor = aut;

                            sheet.Content = Program.Normalize(ic.Text);
                            sheet.Save();

                            //if (SvnOperationMessage != null)
                            //    SvnOperationMessage(String.Format("Import: {0}{1}{2}", ic.Title, ic.Artist != null ? " - " : "", ic.Artist));
                        }

                    }
                }
                catch (Exception ex) { /*OnSvnEx(ex);*/ }

                //SendOperationEnd();
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
