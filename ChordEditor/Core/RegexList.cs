using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ChordEditor.Core
{
	public static class RegexList
	{
		public static class Chords
		{
			public static Regex ValidChordCOT = new Regex(@"(((DO|RE|MI|FA|SOL|LA|SI|Do|Re|Mi|Fa|Sol|La|Si)|([CDEFGAB]))(#|♯|b|♭)?(\+|M|maj|-|min|m|sus|ecc|dim)?((\d){0,2}(\+)?)?)", RegexOptions.Compiled);
			public static Regex ValidChordCHP = new Regex(@"\[(((DO|RE|MI|FA|SOL|LA|SI|Do|Re|Mi|Fa|Sol|La|Si)|([CDEFGAB]))(#|♯|b|♭)?(\+|M|maj|-|min|m|sus|ecc|dim)?((\d){0,2}(\+)?)?)\]", RegexOptions.Compiled);
			public static Regex CHPTagAndVal = new Regex(@"{([^}|:]+):([^}|:]+)}", RegexOptions.Compiled);

			public static Regex ChordProNote = new Regex(@"\[(.*?)\]", RegexOptions.Compiled);
		}

		public static class Import
		{
			public static Regex PotentialTitle = new Regex(@"\r\n([A-Z| |0-9|-]{8,})\r\n", RegexOptions.Compiled);
		}

		public static class Cleanup
		{
 			public static Regex AnyNewLine = new Regex(@"\r\n|\n\r|\n|\r", RegexOptions.Compiled);
            public static Regex AnyWhitespacesLine = new Regex(@"\r\n[ \t]+\r\n", RegexOptions.Compiled);
			public static Regex MultipleSpacedLine = new Regex(@"(\r\n){2,}", RegexOptions.Compiled);
		}
	}
}
