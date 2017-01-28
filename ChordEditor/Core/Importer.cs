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
        const string CaptureChordCOT = @"(((DO|RE|MI|FA|SOL|LA|SI|Do|Re|Mi|Fa|Sol|La|Si)|([CDEFGAB]))(#|♯|b|♭)?(\+|M|maj|-|min|m|sus|ecc|dim)?((\d){0,2}(\+)?)?)";
        const string CaptureChordPro = @"\[(((DO|RE|MI|FA|SOL|LA|SI|Do|Re|Mi|Fa|Sol|La|Si)|([CDEFGAB]))(#|♯|b|♭)?(\+|M|maj|-|min|m|sus|ecc|dim)?((\d){0,2}(\+)?)?)\]";
        const string CaptureChordProTagAndVal = @"{([^}|:]+):([^}|:]+)}"; 

        public class ImportedContent
        {
            public string Artist;
            public string Title;

            public string Text;

        }

        internal static ImportedContent ImportClipbord(string text)
        {
            text = CleanUp(text);

            if (IsChordPro(text))
                return ImportChordPro(text); //search for artist and title and import as is
            else if (IsCOT(text))
                return ImportCOT(text); //translate Chord Over Text -> ChordPro
            else
                return new ImportedContent() { Text = text }; //return as is
        }

        private static string CleanUp(string text)
        {
            text = Regex.Replace(text, @"\r\n[ \t]+\r\n", "\r\n\r\n", RegexOptions.Compiled); //remove empty line filled of spaces
            text = Regex.Replace(text, @"(\r\n){2,}", "\r\n\r\n", RegexOptions.Compiled); //remove multiple white lines, keep paragraph (2 line)
            return text;
        }

        static bool IsChordPro(string text)
        {
            string[] paragraph = text.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None);

            //cicla paragrafo per paragrafo
            //alla ricerca di un paragrafo "chordpro"
            foreach (string par in paragraph) 
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(CaptureChordPro, System.Text.RegularExpressions.RegexOptions.Compiled);
                MatchCollection matches = regex.Matches(par);

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

            
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(CaptureChordProTagAndVal, System.Text.RegularExpressions.RegexOptions.Compiled);
            MatchCollection matches = regex.Matches(text);
            foreach (Match m in matches) //remove match and put it in header
            {
                string key = m.Groups[1].Value.ToLower();
                if (key == "title" || key == "t")
                {
                    //assign title
                    rv.Title = m.Groups[2].Value;
                    //remove tag from text
                    int position = m.Groups[0].Index + offset;
                    sb.Remove(position, m.Groups[0].Length);
                    offset += -m.Groups[0].Length;
                }
                else if (key == "subtitle" || key == "st")
                {
                    //assign artist
                    rv.Artist = m.Groups[2].Value;
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

        private static bool IsSongLine(string line)
        {
            line = line.Trim();

            if (line.Length == 0)
                return false;

            return !IsChordLine(line);
        }

        private static bool IsChordLine(string line)
        {
            line = line.Trim();

            if (line.Length == 0)
                return false;

            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(CaptureChordCOT, System.Text.RegularExpressions.RegexOptions.Compiled);
            MatchCollection matches = regex.Matches(line);

            if (matches.Count == 0)
                return false;

            //verifico che davanti al primo match ci siano solo spazi bianchi
            if (matches[0].Index != 0) //lo testo con posizione zero perché avendo trimmato non mi aspetto nulla davanti a lui
                return false;

            for (int i = 0; i < matches.Count -1 ; i++ )
            {
                //verifico di non avere nient'altro che spazi tra un match e l'altro

                int i1 = matches[i].Index + matches[i].Length; //i1 = fine del primo match
                int i2 = matches[i+1].Index; //i2 = inizio del successivo match

                string bw = line.Substring(i1, i2 - i1);
                if (bw.Trim().Length > 0) //se ho qualcosa che non sia spazio
                    return false;
            }

            //verifico che dopo l'ultimo match ci siano solo spazi bianchi
            if (matches[matches.Count - 1].Index + matches[matches.Count - 1].Length != line.Length) //lo testo verificando che non ci sia più nulla dopo di lui
                return false;



            return true;
        }

        static ImportedContent ImportCOT(string text)
        {
            ImportedContent rv = new ImportedContent();

            System.Text.StringBuilder sb = new StringBuilder();

            string[] lines = text.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            //cerca di individuare titolo e artista
            if (lines.Length > 10) //possiamo ipotizzare che stiamo importando una canzone intera?!
            {
                string guessTitle = null;
                string guessArtist = null;

                //se la prima linea è di testo
                //e la seconda è uno spazio
                if (IsSongLine(lines[0]) && (string.IsNullOrWhiteSpace(lines[1]) || string.IsNullOrWhiteSpace(lines[2])))
                     guessTitle = lines[0];
                if (IsSongLine(lines[1]) && (string.IsNullOrWhiteSpace(lines[2]) || string.IsNullOrWhiteSpace(lines[3])))
                    guessArtist = lines[1];

                if (guessTitle != null)
                {
                    guessTitle = Forms.InputBox.Show("Guess title", "Is this title correct?", guessTitle, false);
                    if (guessTitle != null)
                    {
                        rv.Title = guessTitle;
                        lines = lines.Skip(1).ToArray();
                    }

                    if (guessArtist != null)
                    {
                        guessArtist = Forms.InputBox.Show("Guess artist", "Is this artist correct?", guessArtist, false);
                        if (guessArtist != null)
                        {
                            rv.Artist = guessArtist;
                            lines = lines.Skip(1).ToArray();
                        }
                    }

                    if (string.IsNullOrWhiteSpace(lines[0]))//se dopo queste operazioni sono rimasto con una linea vuota iniziale
                        lines = lines.Skip(1).ToArray(); //me la levo
                }
 
            }


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

            return rv;
        }

        private static string MergeCOT(string text, string chords)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(CaptureChordCOT, System.Text.RegularExpressions.RegexOptions.Compiled);
            MatchCollection matches = regex.Matches(chords);

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

    }
}
