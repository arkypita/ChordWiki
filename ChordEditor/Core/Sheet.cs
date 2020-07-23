using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ChordEditor.Core
{
	public class Sheet
	{
		public delegate void SheetDelegate(Sheet s);
		public static event SheetDelegate SheetChange;

		private SheetHeader mHeader;
		private string mContent;
		private string mOContent;

		public Sheet()
		{
			mHeader = new SheetHeader();
			mHeader.Progress = SheetHeader.SheetProgress.Added;

			SheetHeader.HeaderChanged += SheetHeader_HeaderChanged;
		}

		public Sheet(string filename)
		{
			mHeader = new SheetHeader(filename);
			ReloadFile();
			SheetHeader.HeaderChanged += SheetHeader_HeaderChanged;
		}

		public SheetHeader Header
		{ get { return mHeader; } }

		public string Content
		{
			get { return mContent; }
			set
			{
				if (mContent != value)
				{
					mContent = value;

					if (SheetChange != null)
						SheetChange(this);
				}
			}
		}

		private void SheetHeader_HeaderChanged(SheetHeader sh)
		{
			if (SheetChange != null && object.Equals(sh, mHeader))
			{
				SheetChange(this);
			}
		}

		public void Save()
		{
			if (!HasMemoryChanges)
				return;

			mContent = RemoveTrailingLeadingWitespace(mContent);

			bool createNew = !System.IO.File.Exists(mHeader.FilePath);
			using (System.IO.StreamWriter sw = new System.IO.StreamWriter(mHeader.FilePath))
			{
				//write header
				mHeader.Write(sw);

				//write separator
				sw.WriteLine("");

				//write content
				if (mContent != null)
				{
					sw.Write(mContent);
				}

				sw.Close();
			}

			mHeader.UpdateFileInfo();
			BackupStatus();

			if (createNew)
			{
				SVN.AddFile(mHeader.FilePath);
			}

			SheetChange?.Invoke(this);
		}

		private string RemoveTrailingLeadingWitespace(string text)
		{
			return text.Trim(new char[] { '\r', '\n', '\t', ' '});
		}


		public bool AutomaticNormalizationCleanup(bool save)
		{
			string text = mContent;
			text = Importer.CleanUp(text);
			text = Pagliaro.Normalize(text);
			text = NormalizeComment(text);
			text = RemoveTrailingLeadingWitespace(text);
			Content = text; //fa l'evento se siamo nella pagina di edit, altrimenti no
			bool changes = HasMemoryChanges;

			if (save)		//veniamo dal ciclo che lo fa su tutte
				Save();

			return changes;
		}

		private static string NormalizeComment(string text)
		{
			//auto transform missing comment tag (Rit.) to comment tag {c:Rit.}
			text = RegexList.Comments.AutoComment.Replace(text, "{c:${commento}}");

			//normalize other tag
			int offset = 0;
			Match match = RegexList.Comments.CommentoTag.Match(text, offset);
			while (match != null && match.Success)
			{
				string oldval = match.Value;
				string comment = match.Groups["commento"].Value;

				comment = RegexList.Comments.Ritornello.Replace(comment, "rit");
				comment = RegexList.Comments.VolteCount1.Replace(comment, "${numvolte}v");
				comment = RegexList.Comments.VolteCount2.Replace(comment, "${numvolte}v");
				comment = RegexList.Comments.Strumentale.Replace(comment, "strum");
				comment = RegexList.Comments.Introduzione.Replace(comment, "intro");
				comment = comment.Trim();

				string newval = "{c:" + comment +"}";
				text = text.Remove(match.Index, match.Length);
				text = text.Insert(match.Index, newval);

				offset = match.Index + oldval.Length + (newval.Length - oldval.Length);
				match = RegexList.Comments.CommentoTag.Match(text, offset);
			}

			return text;
		}

		private void BackupStatus()
		{
			//salvo la mia memoria x confronto changes
			mOContent = mContent;
			mHeader.BackupStatus();
		}

		public bool HasMemoryChanges
		{ get { return mHeader.MemoryHasChanges || mContent != mOContent; } }

		internal void ReloadFile()
		{
			using (System.IO.StreamReader sr = new System.IO.StreamReader(mHeader.FilePath))
			{
				mHeader.LoadFromStream(sr);
				mContent = sr.ReadToEnd();
			}

			BackupStatus();
		}
	}
}
