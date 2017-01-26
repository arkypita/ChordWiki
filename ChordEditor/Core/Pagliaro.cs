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

            new chordMatch(ChordNotation.Italian, "REb", 1),
            new chordMatch(ChordNotation.Italian, "MIb", 3),
            new chordMatch(ChordNotation.Italian, "SOLb", 6),
            new chordMatch(ChordNotation.Italian, "LAb", 8),
            new chordMatch(ChordNotation.Italian, "SIb", 10),

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

            new chordMatch(ChordNotation.American, "Db", 1),
            new chordMatch(ChordNotation.American, "Eb", 3),
            new chordMatch(ChordNotation.American, "Gb", 6),
            new chordMatch(ChordNotation.American, "Ab", 8),
            new chordMatch(ChordNotation.American, "Bb", 10),

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

        public Chord(string text, bool notationonly = false)
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
                }
            }

            if (IsValid)
            {
                mVariant = mBaseText.Substring(noteDictionary[mNotation][mNote].Length);
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
        public static ChordNotation WhatNotation(string text)
        {return new Chord(text, true).Notation;}

        public static string ChangeNotation(string text, ChordNotation notation)
        {return new Chord(text, false).ToNotation(notation);}

        public static string Traspose(string text, int semitones)
        { return new Chord(text, false).Traspose(semitones); }
    }
}
