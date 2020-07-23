using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace ChordEditor.Core
{
	internal static class Importer
	{
		public delegate void ImporterBeginMessage(string message);
		public delegate void ImporterEndMessage(string message, bool reload);
		public delegate void ImporterFileAction(string message);
		public delegate void ImporterError(Exception ex);
		public static event ImporterBeginMessage ImportBegin;
		public static event ImporterEndMessage ImportEnd;
		public static event ImporterFileAction ImportAction;
		public static event ImporterError ImportError;


		private static string lotoftext = "aaaaaaaaaaaaaaaaaaaaaaabbcccccccccdddddddeeeeeeeeeeeeeeeeeeeeeeeeffggghhhiiiiiiiiiiiiiiiiiiiiiiilllllllllllllmmmmmnnnnnnnnnnnnnnooooooooooooooooooooppppppqrrrrrrrrrrrrrsssssssssstttttttttttuuuuuuvvvvz";
		private static string lotofspace = "                                                                                                             ";

		public class ImportedContent
		{
			public string Artist;
			public string Title;
			public string Text;
		}

		public static void ImportFile()
		{
			String filename = GetFileName();
			if (filename != null)
			{
				string cat = Forms.InputBox.Show("Common category", "Category?");
				string aut = Forms.InputBox.Show("Common author", "Author?");

				SendOperationBegin();

				System.Threading.Tasks.Task.Run(() =>
				{
					try
					{
						Importer.ParseMSWord(filename, delegate (double CharW, double SpaceW, string text)
										{
									try
									{ CreateSheetFromText(cat, aut, CharW, SpaceW, text); }
									catch (Exception ex)
									{ SendError(ex); }
								});
					}
					catch (Exception ex)
					{ SendError(ex); }

					SendOperationEnd();
				});
			}
		}

		private static void CreateSheetFromText(string cat, string aut, double CharW, double SpaceW, string song)
		{
			if (!String.IsNullOrWhiteSpace(song.Trim()))
			{
				Importer.ImportedContent ic = Importer.ImportCOT(song, false, SpaceW / CharW);


				Sheet sheet = new Sheet();
				sheet.Header.Artist = ic.Artist;
				sheet.Header.Title = ic.Title;
				sheet.Header.SheetCategory = cat;
				sheet.Header.SheetAuthor = aut;

				sheet.Content = Pagliaro.Normalize(ic.Text);
				sheet.Save();

				if (ImportAction != null)
				{
					ImportAction(String.Format("Import: {0}{1}{2}", ic.Title, ic.Artist != null ? " - " : "", ic.Artist));
				}
			}
		}


		private static string GetFileName()
		{
			using (System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog())
			{
				ofd.Title = "Select file to import";
				ofd.Filter = "Any supported file|*.txt;*.doc;*.docx";
				ofd.CheckFileExists = true;
				ofd.Multiselect = false;
				ofd.RestoreDirectory = true;

				if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					return ofd.FileName;
				}
			}

			return null;
		}


		private static void SendOperationEnd()
		{
			ImportEnd?.Invoke("Complete!", true);
		}

		private static void SendError(Exception ex)
		{
			ImportError?.Invoke(ex);
		}

		private static void SendOperationBegin()
		{
			ImportBegin?.Invoke("------ IMPORT FILE ------");
		}


		public static ImportedContent ImportClipbord(string text, bool ask)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return null;
			}

			text = CleanUp(text);

			if (IsChordPro(text))
			{
				return ImportChordPro(text); //search for artist and title and import as is
			}
			else if (IsCOT(text))
			{
				return ImportCOT(text, ask); //translate Chord Over Text -> ChordPro
			}
			else
			{
				return new ImportedContent() { Text = text }; //return as is
			}
		}

		public static string CleanUp(string text)
		{
			text = RegexList.Cleanup.AnyTrash.Replace(text, "");
			text = RegexList.Cleanup.AnyShitTriplepoint.Replace(text, "...");
			text = RegexList.Cleanup.AnyStrangeSpace.Replace(text, " ");
			text = RegexList.Cleanup.AnyTabulation.Replace(text, "            ");	//tabulation = 12 spaces
			text = RegexList.Cleanup.AnyNewLine.Replace(text, "\r\n");				//normalize newline
			text = RegexList.Cleanup.AnyWhitespacesLine.Replace(text, "\r\n\r\n");	//remove empty line filled of spaces
			text = RegexList.Cleanup.MultipleSpacedLine.Replace(text, "\r\n\r\n");	//remove multiple white lines, keep paragraph (2 line)
			text = RegexList.Cleanup.WhiteSpacesAtEndOfLine.Replace(text, "");
			return text;
		}

		private static bool IsChordPro(string text)
		{
			string[] paragraph = text.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None);

			//cicla paragrafo per paragrafo
			//alla ricerca di un paragrafo "chordpro"
			foreach (string par in paragraph)
			{
				MatchCollection matches = RegexList.Chords.ValidChordCHP.Matches(par);
				if (matches.Count >= 5) //voglio almeno 5 accordi!
				{
					int parlen = par.Length;
					foreach (Match m in matches)
					{
						parlen -= m.Length;
					}

					double rapporto = (double)parlen / (double)matches.Count;

					// gli accordi distano meno
					// di 50 caratteri tra loro
					if (rapporto < 50)
					{
						return true; //ho trovato un paragrafo chordpro!
					}
				}
			}

			return false;
		}

		private static ImportedContent ImportChordPro(string text)
		{
			ImportedContent rv = new ImportedContent();

			System.Text.StringBuilder sb = new StringBuilder(text);
			int offset = 0;


			MatchCollection matches = RegexList.Chords.CHPTagAndVal.Matches(text);
			foreach (Match m in matches) //remove match and put it in header
			{
				string key = m.Groups[1].Value.ToLower();
				if (key == "title" || key == "t")
				{
					//assign title
					rv.Title = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(m.Groups[2].Value.ToLower());
					//remove tag from text
					int position = m.Groups[0].Index + offset;
					sb.Remove(position, m.Groups[0].Length);
					offset += -m.Groups[0].Length;
				}
				else if (key == "subtitle" || key == "st")
				{
					//assign artist
					rv.Artist = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(m.Groups[2].Value.ToLower());
					//remove tag from text
					int position = m.Groups[0].Index + offset;
					sb.Remove(position, m.Groups[0].Length);
					offset += -m.Groups[0].Length;
				}
			}
			rv.Text = sb.ToString().Trim("\r\n".ToCharArray()); //trim spaces remaining after remove title and artist

			return rv;
		}

		private static bool IsCOT(string text)
		{

			string[] paragraphs = text.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None);

			//cicla paragrafo per paragrafo
			//alla ricerca di un paragrafo "Chord Over Text" che alterni accordi e testo
			foreach (string paragraph in paragraphs)
			{
				string[] lines = paragraph.Split(new string[] { "\r\n" }, StringSplitOptions.None);

				for (int i = 0; i < lines.Length; i++) //cerco una linea con accordi COT
				{
					if (IsChordLine(lines[i]))
					{
						return true;
					}
				}

				//cambiato con test meno selettivo... mi accontento di trovare una linea con COT

				/*
				//ho trovato un paragrafo abbastanza lungo (almeno 6 righe tra accordi e testo)
				//con numero pari di righe (accordi e testo) 
				//la prima linea del paragrafo è di accordi
				if (lines.Length >= 6 && lines.Length % 2 == 0 && IsChordLine(lines[0]))
				{
						//verifico l'alternanza accordi/testo
						bool alternanza = true;
						for (int i = 0; i < lines.Length / 2 ; i++) //di due in due
								alternanza = alternanza && IsChordLine(lines[i*2]) && IsSongLine(lines[i*2 + 1]);

						//alternanza accordi - testo verificata
						if (alternanza)
								return true;
				}
				*/
			}

			return false;

		}

		private static bool IsTitleLine(string line)
		{
			line = line.Trim();

			if (line.Length == 0)
			{
				return false;
			}

			return RegexList.Import.PotentialTitle.IsMatch(line) && !ContainsMoreChordThanText(line);
		}

		private static bool IsSongLine(string line)
		{
			line = line.Trim();

			if (line.Length == 0)
			{
				return false;
			}

			return !IsChordLine(line);
		}

		private static bool ContainsMoreChordThanText(string text)
		{
			text = text.Trim();

			if (text.Length == 0)
			{
				return false;
			}

			MatchCollection matches = RegexList.Chords.ValidChordCOT.Matches(text);

			if (matches.Count == 0)
			{
				return false;
			}

			int chordlen = 0;
			foreach (Match m in matches)
			{
				chordlen += m.Length;
			}

			text = RegexList.Chords.ValidChordCOT.Replace(text, ""); //rimuovo tutti gli accordi trovati e vedo cosa resta
			text = text.Replace(" ", "");

			return text.Length == 0 || chordlen > text.Length;
		}



		private static bool IsChordLine(string line)
		{
			line = line.Trim();

			if (line.Length == 0)
			{
				return false;
			}

			MatchCollection matches = RegexList.Chords.ValidChordCOT.Matches(line);

			if (matches.Count == 0)
			{
				return false;
			}

			line = RegexList.Chords.ValidChordCOT.Replace(line, ""); //rimuovo tutti gli accordi trovati
			return string.IsNullOrWhiteSpace(line);
		}

		private static ImportedContent ImportCOT(string text, bool ask, double ssize = 1.0)
		{
			ImportedContent rv = new ImportedContent();

			List<string> lines = new List<string>(text.Split(new string[] { "\r\n" }, StringSplitOptions.None));

			//cerca di individuare titolo e artista
			GuessCOT(ask, rv, lines);
			ParseCOT(rv, lines, ssize);

			return rv;
		}

		private static void ParseCOT(ImportedContent rv, List<string> lines, double ssize = 1.0)
		{
			System.Text.StringBuilder sb = new StringBuilder();
			string chords = null;
			foreach (string line in lines)
			{
				if (line.Trim().Length == 0) //linea vuota
				{
					if (chords != null)                                         //avevo una precedente linea di accordi
					{
						sb.AppendLine(MergeCOT("", chords, ssize));                    //emetto gli accordi
					}

					sb.AppendLine("");                                          //e comunque emetto una linea vuota
					chords = null;                                              //avendoli emessi posso dimenticarli
				}
				else if (IsChordLine(line))
				{
					if (chords != null)                                         //avevo una precedente linea di accordi
					{
						sb.AppendLine(MergeCOT("", chords, ssize));                    //emetto la precedente linea di accordi
					}

					chords = line;                                              //memorizzo questa nuova linea di accordi
				}
				else if (IsSongLine(line))
				{
					if (chords != null)                                         //avevo una precedente linea di accordi
					{
						sb.AppendLine(MergeCOT(line, chords, ssize));                  //eseguo il merge con gli accordi
					}
					else                                                        //altrimenti
					{
						sb.AppendLine(line);                                    //emetto la riga così come è
					}

					chords = null;                                              //avendoli emessi posso dimenticarli
				}
			}

			if (chords != null)                                         //se finivo con una linea di accordi
			{
				sb.AppendLine(MergeCOT("", chords, ssize));                    //emetto gli accordi
			}

			rv.Text = sb.ToString();
		}

		private static void GuessCOT(bool ask, ImportedContent rv, List<string> lines)
		{
			if (lines.Count > 10) //possiamo ipotizzare che stiamo importando una canzone intera?!
			{
				string guessTitle = null;
				string guessArtist = null;

				//se la prima linea è di testo
				//e la seconda è uno spazio

				if (IsTitleLine(lines[0]))
				{
					guessTitle = lines[0];
				}

				if (IsTitleLine(lines[1]))
				{
					guessArtist = lines[1];
				}

				if (guessTitle != null)
				{
					guessTitle = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(guessTitle.Trim().ToLower());
					guessTitle = ask ? Forms.InputBox.Show("Guess title", "Is this title correct?", guessTitle, false) : guessTitle;
					if (guessTitle != null)
					{
						rv.Title = guessTitle;
						lines.RemoveAt(0);
					}

					if (guessArtist != null)
					{
						guessArtist = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(guessArtist.Trim().ToLower());
						guessArtist = ask ? Forms.InputBox.Show("Guess artist", "Is this artist correct?", guessArtist, false) : guessArtist;
						if (guessArtist != null)
						{
							rv.Artist = guessArtist;
							lines.RemoveAt(0);
						}
					}

					while (string.IsNullOrWhiteSpace(lines[0])) //rimuovi tutte le linee vuote dopo il titolo
					{
						lines.RemoveAt(0);
					}
				}

			}
		}

		private static string MergeCOT(string text, string chords, double ssize)
		{
			MatchCollection matches = RegexList.Chords.ValidChordCOT.Matches(chords);
			StringBuilder sb = new StringBuilder();



			int cumulatedchords = 0;
			int cumulatedspaces = 0;
			int prev_chord_end = 0;
			int prev_ipos = 0;
			foreach (Match m in matches)
			{
				cumulatedspaces += (m.Index - prev_chord_end); //inizio di questo accordo meno fine del precedente

				int ipos = cumulatedchords + (int)(cumulatedspaces * ssize); //position of original string where to insert chord

				sb.Append(SubstringOrSpaces(text, prev_ipos, ipos)); //aggiungo la parte precedente della linea
				sb.AppendFormat("[{0}]", m.Value); //aggiungo l'accordo

				cumulatedchords += m.Length;
				prev_chord_end = m.Index + m.Length;
				prev_ipos = ipos;
			}

			//aggiungo tutto quello che resta della stringa
			sb.Append(SubstringOrSpaces(text, prev_ipos, Math.Max(text.Length, prev_ipos)));

			return sb.ToString().Trim();
		}

		private static string SubstringOrSpaces(string text, int from, int to)
		{
			if (to > text.Length)
			{
				text = text + new string(' ', to - text.Length);
			}

			return text.Substring(from, to - from);
		}

		private delegate void ProcessOneSongDlg(double CharW, double SpaceW, string song);
		private static void ParseMSWord(string filename, ProcessOneSongDlg OnSong)
		{
			//get all data from word
			Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
			Microsoft.Office.Interop.Word.Document doc = app.Documents.Open(filename);
			string text = doc.Content.Text;
			string font = "";

			foreach (Microsoft.Office.Interop.Word.Paragraph par in doc.Content.Paragraphs)
			{
				try
				{
					font = par.Range.Font.Name;
					break;
				}
				catch { }
			}

			doc.Close();
			app.Quit();

			//calc font sizes
			double charW = 1.0;
			double spaceW = 1.0;
			using (System.Drawing.Font f = new System.Drawing.Font(font, 10))
			{
				charW = System.Windows.Forms.TextRenderer.MeasureText(lotoftext, f).Width / (double)lotoftext.Length;
				spaceW = System.Windows.Forms.TextRenderer.MeasureText(lotofspace, f).Width / (double)lotofspace.Length;
			}

			text = CleanUp(text);

			ExtractBlock(text, delegate (string block) { OnSong(charW, spaceW, block); });
		}

		private delegate void OnBlockDlg(string block);
		private static void ExtractBlock(string text, OnBlockDlg OnBlock)
		{
			//Cerco dei potenziali titoli (TUTTO MAIUSCOLO, ALMENO 4 CARATTERI, LINEA INTERA)

			string[] lines = text.Split(new string[] { "\r\n" }, StringSplitOptions.None);

			int lasttitle = 0;
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < lines.Length; i++)
			{
				if (IsTitleLine(lines[i]) && (i - lasttitle) > 1) //abbiamo trovato una linea di titolo che dista più di 1 righe dalla precedente
				{
					lasttitle = i;
					OnBlock(sb.ToString()); //estraggo il gruppo
					sb.Clear();//svuoto il buffer
				}

				sb.AppendLine(lines[i]);
			}

			if (sb.Length > 0)
			{
				OnBlock(sb.ToString()); //estraggo il gruppo
				sb.Clear();//svuoto il buffer
			}
		}

		internal static string MergeChordFromClip(string target, string clip)
		{
			string[] tlines = target.Split(new string[] { "\r\n" }, StringSplitOptions.None);
			string[] clines = clip.Split(new string[] { "\r\n" }, StringSplitOptions.None);

			if (clines.Length != tlines.Length)
			{
				return target;
			}

			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < tlines.Length; i++)
			{
				string tline = tlines[i];
				string cline = clines[i];

				MatchCollection matches = RegexList.Chords.ChordProNote.Matches(cline);

				int offset = 0;
				int prev_ipos = 0;
				foreach (Match m in matches)
				{
					int ipos = m.Index - offset; //position of original string where to insert chord

					sb.Append(SubstringOrSpaces(tline, prev_ipos, ipos)); //aggiungo la parte precedente della linea
					sb.AppendFormat(m.Value); //aggiungo l'accordo

					offset += m.Length;
					prev_ipos = ipos;
				}

				sb.Append(SubstringOrSpaces(tline, prev_ipos, Math.Max(tline.Length, prev_ipos))); //aggiungi quello che rimane

				if (i != tlines.Length - 1)
				{
					sb.AppendLine();
				}
			}

			return sb.ToString();
		}
	}
}
