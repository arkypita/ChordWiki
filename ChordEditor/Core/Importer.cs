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
            return Regex.Replace(text, @"(\r\n){2,}", "\r\n\r\n"); //remove multiple white lines, keep paragraph (2 line)
        }

        const string CaptureChordCOT = @"(([CDEFGAB]|(DO|RE|MI|FA|SOL|LA|SI|Do|Re|Mi|Fa|Sol|La|Si))(#|♯|b|♭)?(\+|M|maj|-|min|m|sus|ecc|dim)?((\d){0,2}(\+)?)?)";
        const string CaptureChordPro = @"\[(([CDEFGAB]|(DO|RE|MI|FA|SOL|LA|SI|Do|Re|Mi|Fa|Sol|La|Si))(#|♯|b|♭)?(\+|M|maj|-|min|m|sus|ecc|dim)?((\d){0,2}(\+)?)?)\]";
        const string CaptureChordProTagAndVal = @"{([^}|:]+):([^}|:]+)}"; 

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

            System.Text.StringBuilder TB = new StringBuilder(text);
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
                    TB.Remove(position, m.Groups[0].Length);
                    offset += -m.Groups[0].Length;
                }
                else if (key == "subtitle" || key == "st")
                {
                    //assign artist
                    rv.Artist = m.Groups[2].Value;
                    //remove tag from text
                    int position = m.Groups[0].Index + offset;
                    TB.Remove(position, m.Groups[0].Length);
                    offset += -m.Groups[0].Length;
                }
            }
            rv.Text = TB.ToString().Trim("\r\n".ToCharArray()); //trim spaces remaining after remove title and artist

            return rv;
        }

        static bool IsCOT(string text)
        {
            return false;
        }

        static ImportedContent ImportCOT(string text)
        {
            return new ImportedContent();
        }

    }
}
