using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;


namespace ChordEditor.Core
{
    class Importer
    {
        public class ImportedContent
        {
            public string Artist;
            public string Title;

            public string Text;

        }

        internal static ImportedContent ImportClipbord(string text, bool ask)
        {
            text = CleanUp(text);

            if (IsChordPro(text))
                return ImportChordPro(text); //search for artist and title and import as is
            else if (IsCOT(text))
                return ImportCOT(text, ask); //translate Chord Over Text -> ChordPro
            else
                return new ImportedContent() { Text = text }; //return as is
        }

        private static string CleanUp(string text)
        {
			text = RegexList.Cleanup.AnyTrash.Replace(text, "");
			text = RegexList.Cleanup.AnyStrangeSpace.Replace(text, " ");
			text = RegexList.Cleanup.AnyTabulation.Replace(text, "            "); //tabulation = 12 spaces
            text = RegexList.Cleanup.AnyNewLine.Replace(text, "\r\n"); //normalize newline
			text = RegexList.Cleanup.AnyWhitespacesLine.Replace(text, "\r\n\r\n"); //remove empty line filled of spaces
			text = RegexList.Cleanup.MultipleSpacedLine.Replace(text, "\r\n\r\n"); //remove multiple white lines, keep paragraph (2 line)
            return text;
        }

        static bool IsChordPro(string text)
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
                        parlen -= m.Length;

                    double rapporto = (double)parlen / (double)matches.Count;

                    // gli accordi distano meno
                    // di 50 caratteri tra loro
                    if (rapporto < 50)
                        return true; //ho trovato un paragrafo chordpro!
                }
            }

            return false;
        }

        static ImportedContent ImportChordPro(string text)
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

        static bool IsCOT(string text)
        {

            string[] paragraphs = text.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None);

            //cicla paragrafo per paragrafo
            //alla ricerca di un paragrafo "Chord Over Text" che alterni accordi e testo
            foreach (string paragraph in paragraphs)
            {
                string[] lines = paragraph.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                for (int i = 0; i < lines.Length; i++) //cerco una linea con accordi COT
                    if (IsChordLine(lines[i]))
                        return true;

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
				return false;

			return RegexList.Import.PotentialTitle.IsMatch(line) && !ContainsMoreChordThanText(line);
		}

        private static bool IsSongLine(string line)
        {
            line = line.Trim();

            if (line.Length == 0)
                return false;

            return !IsChordLine(line);
        }

		private static bool ContainsMoreChordThanText(string text)
		{
			text = text.Trim();

			if (text.Length == 0)
				return false;

			MatchCollection matches = RegexList.Chords.ValidChordCOT.Matches(text);

			if (matches.Count == 0)
				return false;

			int chordlen = 0;
			foreach (Match m in matches)
				chordlen += m.Length;


			text = RegexList.Chords.ValidChordCOT.Replace(text, ""); //rimuovo tutti gli accordi trovati e vedo cosa resta
			text = text.Replace(" ","");

			return text.Length == 0 || chordlen > text.Length;
		}



        private static bool IsChordLine(string line)
        {
            line = line.Trim();

            if (line.Length == 0)
                return false;

			MatchCollection matches = RegexList.Chords.ValidChordCOT.Matches(line);

            if (matches.Count == 0)
                return false;

			line = RegexList.Chords.ValidChordCOT.Replace(line, ""); //rimuovo tutti gli accordi trovati
			return string.IsNullOrWhiteSpace(line);
        }

        internal static ImportedContent ImportCOT(string text, bool ask, double ssize = 1.0)
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
                        sb.AppendLine(MergeCOT("", chords));                    //emetto gli accordi

                    sb.AppendLine("");                                          //e comunque emetto una linea vuota
                    chords = null;                                              //avendoli emessi posso dimenticarli
                }
                else if (IsChordLine(line))
                {
                    if (chords != null)                                         //avevo una precedente linea di accordi
                        sb.AppendLine(MergeCOT("", chords));                    //emetto la precedente linea di accordi

                    chords = line;                                              //memorizzo questa nuova linea di accordi
                }
                else if (IsSongLine(line))
                {
                    if (chords != null)                                         //avevo una precedente linea di accordi
                        sb.AppendLine(MergeCOT(line, chords));                  //eseguo il merge con gli accordi
                    else                                                        //altrimenti
                        sb.AppendLine(line);                                    //emetto la riga così come è

                    chords = null;                                              //avendoli emessi posso dimenticarli
                }
            }

            if (chords != null)                                         //se finivo con una linea di accordi
                sb.AppendLine(MergeCOT("", chords));                    //emetto gli accordi


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
                    guessTitle = lines[0];
                if (IsTitleLine(lines[1]))
                    guessArtist = lines[1];

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
                        lines.RemoveAt(0);
                }

            }
        }

        private static string MergeCOT(string text, string chords)
        {
			MatchCollection matches = RegexList.Chords.ValidChordCOT.Matches(chords);

            int chordlen = 0;
            foreach (Match m in matches)
                chordlen += m.Value.Length + 2;

            StringBuilder sb = new StringBuilder();

            //aggiungo tanti caratteri a sinistra per allinearmi con il primo accordo
            //line = line.PadLeft(line.Length + matches[0].Index); 

            //aggiungo tanti caratteri a destra per allinearmi ad ospitare l'ultimo accordo
            text = text.PadRight(matches[matches.Count - 1].Index + matches[matches.Count - 1].Length); 

            int i1 = 0;
            int i2 = 0;
            foreach (Match m in matches)
            {
                i2 = m.Index; //lo devo inserire in posizione index

                sb.Append(text.Substring(i1, i2 - i1)); //aggiungo la parte precedente della linea
                sb.AppendFormat("[{0}]", m.Value); //aggiungo l'accordo

                i1 = i2;
            }

            if (i1 < text.Length-1)
                sb.Append(text.Substring(i1, text.Length - i1)); //aggiungo la parte precedente della linea

            return sb.ToString().Trim();
        }

        internal static string ParseMSWord(string filename, List<string> rv)
        {
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

            rv.AddRange(ExtractBlock(CleanUp(text)));
            return font;
        }

        private static List<string> ExtractBlock(string text)
        {
            List<string> rv = new List<string>();
            //Cerco dei potenziali titoli (TUTTO MAIUSCOLO, ALMENO 4 CARATTERI, LINEA INTERA)

			string[] lines = text.Split(new string[] { "\r\n" }, StringSplitOptions.None);

			int lasttitle = 0;
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < lines.Length; i++)
			{
				if (IsTitleLine(lines[i]) && (i - lasttitle) > 1) //abbiamo trovato una linea di titolo che dista più di 1 righe dalla precedente
				{
					lasttitle = i;
					rv.Add(sb.ToString()); //estraggo il gruppo
					sb.Clear();//svuoto il buffer
				}

				sb.AppendLine(lines[i]);
			}

			if (sb.Length > 0)
			{
				rv.Add(sb.ToString()); //estraggo il gruppo
				sb.Clear();//svuoto il buffer
			}

            return rv;
        }
    }
}
