using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordEditor.Core
{
    public enum ChordNotation
    { Unknown, American, Italian, French }

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

        public string Ord2Chord(int index)
        { return mNotes[index]; }

        public int Chord2Ord(string chord)
        { return mUpperNotes.IndexOf(chord.ToUpper()); }

    //def __AlterationStandard(self, a, rs):
    //    for r in rs:
    //        p = 0
    //        b = ''
    //        for m in r[0].finditer(a):
    //            b += a[p:m.start()] + r[1]
    //            p = m.end()
    //        b += a[p:]
    //        a = b
    //    return a

    //def PostprocessingFromStandard(self, c, a):
    //    return c, a

    //def PreprocessingToStandard(self, c, a):
    //    return c, a

    //def AlterationFromStandard(self, a):
    //    return self.__AlterationStandard(a, self.repl)

    //def AlterationToStandard(self, a):
    //    return self.__AlterationStandard(a, self.replrev)

    }

    public class Traspose
    {
        private static Dictionary<ChordNotation, NotationInfo> mNotations;

        static Traspose()
        {
            mNotations = new Dictionary<ChordNotation, NotationInfo>();
            mNotations.Add(ChordNotation.American, new NotationInfo(ChordNotation.American, new List<string> { "C", "D", "E", "F", "G", "A", "B" }, new Dictionary<string, string> { }, "American (C D E... B)"));
            mNotations.Add(ChordNotation.Italian, new NotationInfo(ChordNotation.Italian, new List<string> { "Do", "Re", "Mi", "Fa", "Sol", "La", "Si" }, new Dictionary<string, string> { { "maj7", "7+" }, { "sus4", "4" }, { "m", "-" } }, "Italiano (Do Re Mi... Si)"));
        }


//        enNotation = Notation(
//    "enNotation",
//    _("American (C D E... B)"),
//    ['C', 'D', 'E', 'F', 'G', 'A', 'B'],
//    [],
//    []
//)

//itNotation = Notation(
//    "itNotation",
//    _("Italian (Do Re Mi... Si)"),
//    ["Do", "Re", "Mi", "Fa", "Sol", "La", "Si"],
//    [
//        (r"maj7", "7+"),
//        (r"sus4", "4"),
//        (r"^m", "-")
//    ],
//    [
//        (r"7\+", "maj7"),
//        (r"^4", "sus4"),
//        (r"^-", "m")
//    ]
//)

//frNotation = Notation(
//    "frNotation",
        //    _(u"Français (Do Ré Mi... Si)"),
//    ["Do", u"Ré", "Mi", "Fa", "Sol", "La", "Si"],
//    [
//        (r"maj7", "7+"),
//        (r"sus4", "4"),
//    ],
//    [
//        (r"7\+", "maj7"),
//        (r"^4", "sus4"),
//    ]
//)

//ptNotation = Notation(
//    "ptNotation",
//    _(u"Portuguese (Dó Ré Mi... Si)"),
//    [u"Dó", u"Ré", "Mi", u"Fá", "Sol", u"Lá", "Si"],
//    [
//        (r"maj7", "7+"),
//        (r"sus4", "4"),
//        (r"^m", "-")
//    ],
//    [
//        (r"7\+", "maj7"),
//        (r"^4", "sus4"),
//        (r"^-", "m")
//    ]
//)




        public static ChordNotation WhatNotation(string chord)
        {
            chord = chord.ToUpper().Trim("[] ".ToCharArray());
            if (chord.StartsWith("DO"))
                return ChordNotation.Italian;
            else if (chord.StartsWith("RE"))
                return ChordNotation.Italian;
            else if (chord.StartsWith("MI"))
                return ChordNotation.Italian;
            else if (chord.StartsWith("FA"))
                return ChordNotation.Italian;
            else if (chord.StartsWith("SOL"))
                return ChordNotation.Italian;
            else if (chord.StartsWith("LA"))
                return ChordNotation.Italian;
            else if (chord.StartsWith("SI"))
                return ChordNotation.Italian;

            if (chord.StartsWith("A"))
                return ChordNotation.American;
            else if (chord.StartsWith("B"))
                return ChordNotation.American;
            else if (chord.StartsWith("C"))
                return ChordNotation.American;
            else if (chord.StartsWith("D"))
                return ChordNotation.American;
            else if (chord.StartsWith("E"))
                return ChordNotation.American;
            else if (chord.StartsWith("F"))
                return ChordNotation.American;
            else if (chord.StartsWith("G"))
                return ChordNotation.American;

            return ChordNotation.Unknown;
        }

        public static string ChangeNotation(string chord, ChordNotation target)
        {
            chord = chord.Trim("[] ".ToCharArray());


            if (target == ChordNotation.American)
            {
                if (replaceChord(ref chord, "DO", "C"))
                    return chord;
                if (replaceChord(ref chord, "RE", "D"))
                    return chord;
                if (replaceChord(ref chord, "MI", "E"))
                    return chord;
                if (replaceChord(ref chord, "FA", "F"))
                    return chord;
                if (replaceChord(ref chord, "SOL", "G"))
                    return chord;
                if (replaceChord(ref chord, "LA", "A"))
                    return chord;
                if (replaceChord(ref chord, "SI", "B"))
                    return chord;
            }
            else if (target == ChordNotation.Italian)
            {
                if (replaceChord(ref chord, "A", "LA"))
                    return chord;
                if (replaceChord(ref chord, "B", "SI"))
                    return chord;
                if (replaceChord(ref chord, "C", "DO"))
                    return chord;
                if (replaceChord(ref chord, "D", "RE"))
                    return chord;
                if (replaceChord(ref chord, "E", "MI"))
                    return chord;
                if (replaceChord(ref chord, "F", "FA"))
                    return chord;
                if (replaceChord(ref chord, "G", "SOL"))
                    return chord;
            }


            return chord;
        }

        private static bool replaceChord(ref string chord, string find, string replace)
        {
            if (chord.ToUpper().StartsWith(find))
            {
                chord = chord.Substring(find.Length);
                chord = string.Format("[{0}{1}]", replace, chord);
                return true;
            }
            return false;
        }

    }
}
