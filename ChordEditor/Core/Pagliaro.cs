using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordEditor.Core
{
    public enum ChordNotation
    { Unknown, Italian, American }

    //formato accordo
    //[DO#][-/ecc/dim]([4/7/9/11/13][+])
    public class Chord
    {

        private static int mNoteCount = 12;

        private struct chordMatch
        {
            public ChordNotation Notation;
            public string Match;
            public int Index;

            public chordMatch(ChordNotation n, string m, int i)
            {
                Notation = n;
                Match = m;
                Index = i;
            }
        }

        #region Data Structures

        private static Dictionary<ChordNotation, string[]> noteDictionary = new Dictionary<ChordNotation, string[]>
        {
            {ChordNotation.Italian, new string[] {"DO", "DO#", "RE", "RE#", "MI", "FA", "FA#", "SOL", "SOL#", "LA", "LA#", "SI" }},
            {ChordNotation.American, new string[] { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" }},
        };

        private static chordMatch[] matchDictionary = new chordMatch[]
        {
            //notazione italiana

            new chordMatch(ChordNotation.Italian, "DO#", 1),
            new chordMatch(ChordNotation.Italian, "RE#", 3),
            new chordMatch(ChordNotation.Italian, "FA#", 6),
            new chordMatch(ChordNotation.Italian, "SOL#", 8),
            new chordMatch(ChordNotation.Italian, "LA#", 10),

            new chordMatch(ChordNotation.Italian, "REB", 1),
            new chordMatch(ChordNotation.Italian, "MIB", 3),
            new chordMatch(ChordNotation.Italian, "SOLB", 6),
            new chordMatch(ChordNotation.Italian, "LAB", 8),
            new chordMatch(ChordNotation.Italian, "SIB", 10),

            new chordMatch(ChordNotation.Italian, "DO♯", 1),
            new chordMatch(ChordNotation.Italian, "RE♯", 3),
            new chordMatch(ChordNotation.Italian, "FA♯", 6),
            new chordMatch(ChordNotation.Italian, "SOL♯", 8),
            new chordMatch(ChordNotation.Italian, "LA♯", 10),

            new chordMatch(ChordNotation.Italian, "RE♭", 1),
            new chordMatch(ChordNotation.Italian, "MI♭", 3),
            new chordMatch(ChordNotation.Italian, "SOL♭", 6),
            new chordMatch(ChordNotation.Italian, "LA♭", 8),
            new chordMatch(ChordNotation.Italian, "SI♭", 10),

            new chordMatch(ChordNotation.Italian, "DO", 0),
            new chordMatch(ChordNotation.Italian, "RE", 2),
            new chordMatch(ChordNotation.Italian, "MI", 4),
            new chordMatch(ChordNotation.Italian, "FA", 5),
            new chordMatch(ChordNotation.Italian, "SOL", 7),
            new chordMatch(ChordNotation.Italian, "LA", 9),
            new chordMatch(ChordNotation.Italian, "SI", 11),

            //notazione americana

            new chordMatch(ChordNotation.American, "C#", 1),
            new chordMatch(ChordNotation.American, "D#", 3),
            new chordMatch(ChordNotation.American, "F#", 6),
            new chordMatch(ChordNotation.American, "G#", 8),
            new chordMatch(ChordNotation.American, "A#", 10),

            new chordMatch(ChordNotation.American, "DB", 1),
            new chordMatch(ChordNotation.American, "EB", 3),
            new chordMatch(ChordNotation.American, "GB", 6),
            new chordMatch(ChordNotation.American, "AB", 8),
            new chordMatch(ChordNotation.American, "BB", 10),

            new chordMatch(ChordNotation.American, "C♯", 1),
            new chordMatch(ChordNotation.American, "D♯", 3),
            new chordMatch(ChordNotation.American, "F♯", 6),
            new chordMatch(ChordNotation.American, "G♯", 8),
            new chordMatch(ChordNotation.American, "A♯", 10),

            new chordMatch(ChordNotation.American, "D♭", 1),
            new chordMatch(ChordNotation.American, "E♭", 3),
            new chordMatch(ChordNotation.American, "G♭", 6),
            new chordMatch(ChordNotation.American, "A♭", 8),
            new chordMatch(ChordNotation.American, "B♭", 10),

            new chordMatch(ChordNotation.American, "C", 0),
            new chordMatch(ChordNotation.American, "D", 2),
            new chordMatch(ChordNotation.American, "E", 4),
            new chordMatch(ChordNotation.American, "F", 5),
            new chordMatch(ChordNotation.American, "G", 7),
            new chordMatch(ChordNotation.American, "A", 9),
            new chordMatch(ChordNotation.American, "B", 11),
        };



        #endregion

        private ChordNotation mNotation = ChordNotation.Unknown;
        private int mNote = -1; //note index
        private string mVariant = ""; //all the text next to note, in normalized format
        private string mBaseText;

        public Chord(string text)
        {
            if (text == null)
                return;

            mBaseText = text.Trim();
            text = mBaseText.ToUpper();

            for (int i = 0; mNote < 0 && i < matchDictionary.Length; i++)
            {
                chordMatch cm = matchDictionary[i];
                if (text.StartsWith(cm.Match))
                {
                    mNote = cm.Index;
                    mNotation = cm.Notation;
                    mVariant = mBaseText.Substring(cm.Match.Length);
                }
            }

            if (IsValid)
            {
                //if (normalize)
                //{
                    if (mVariant.StartsWith("+"))                     //rimuovi notazione di maggiore iniziale
                        mVariant = mVariant.Substring(1);
                    else if (mVariant.ToLower().StartsWith("maj"))    //rimuovi notazione di maggiore iniziale
                        mVariant = mVariant.Substring(3);
                    else if (mVariant.StartsWith("M"))                //rimuovi notazione di maggiore iniziale
                        mVariant = mVariant.Substring(1);
                    else if (mVariant.ToLower().StartsWith("min"))                      //notazione di minore standardizzata
                    { mVariant = mVariant.Substring(3); mVariant = "-" + mVariant; }
                    else if (mVariant.StartsWith("m"))                                  //notazione di minore standardizzata
                    { mVariant = mVariant.Substring(1); mVariant = "-" + mVariant; }

                    mVariant = mVariant.ToLower(); //può essere fatto solo a questo punto del codice, perché prima si rischia di confondere M con m

                    //mVariant = mVariant.Replace("sus", "ecc");  //normalizza eccedenti
                //}
            }   
        }

        public bool IsValid
        { get { return mNote >= 0; } }

        public ChordNotation Notation
        { get { return mNotation; } }

        public string ToNotation(ChordNotation notation)
        {
            if (!IsValid)
                return mBaseText;
            else
                return noteDictionary[notation][mNote] + mVariant;
        }

        public string Normalized
        {
            get
            {
                if (!IsValid)
                    return mBaseText;
                else
                    return noteDictionary[mNotation][mNote] + mVariant;
            }
        }

        internal string Traspose(int semitones)
        {
            if (!IsValid)
                return mBaseText;
            else
            {
                int idx = (mNote + semitones) % mNoteCount;
                if (idx < 0)
                    idx = mNoteCount + idx;

                return noteDictionary[mNotation][idx] + mVariant;
            }
        }
    }

    public class NotationInfo
    {
        public NotationInfo(ChordNotation notation, List<string> notes, Dictionary<string, string> replacement, string desc)
        {
            mNotation = notation;
            mNotes = notes;
            mUpperNotes = notes.ConvertAll(s => s.ToUpper());
            mReplacement = replacement;
            mDescription = desc;
        }

        private readonly ChordNotation mNotation;
        private readonly List<string> mNotes;
        private readonly List<string> mUpperNotes;
        private readonly Dictionary<string, string> mReplacement;
        private readonly string mDescription;

        public string Description
        { get { return mDescription; } }

        public bool MatchNotation(string text)
        { return mUpperNotes.Any(n => text.ToUpper().StartsWith(n)); }

        public int NoteIndex(string text)
        { return mUpperNotes.FindIndex(n => text.ToUpper().StartsWith(n)); }

        internal string NormalizeChord(string text)
        {
            string matchtext = text.ToUpper();
            foreach (string un in mUpperNotes)
                if (matchtext.StartsWith(un))
                    return mNotes[mUpperNotes.IndexOf(un)] + text.Substring(un.Length); //if match

            //todo: normalize variation (maj, min, 7...)

            return text; //if no match
        }

        internal string GetNote(int index)
        { return mNotes[index]; }

        internal string GetVariation(string text)
        { return text.Substring(mUpperNotes[NoteIndex(text)].Length); }

    }

    public class Pagliaro
    {
        public static Chord GetChord(string text)
        {return new Chord(text);}

        public static string ChangeNotation(string text, ChordNotation notation)
        {return new Chord(text).ToNotation(notation);}

        public static string Traspose(string text, int semitones)
        { return new Chord(text).Traspose(semitones); }

        internal static string Normalize(string text)
        { return new Chord(text).Normalized; }
    }
}
