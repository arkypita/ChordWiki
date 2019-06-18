using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Office.Interop.Word;

namespace ChordEditor.Core
{
	public static class SongBook
	{

		public delegate void JobBeginDlg(int total);
		public delegate void JobEndDlg();
		public delegate void JobProgressDlg(int count, SheetHeader sh);

		public static event JobBeginDlg JobBegin;
		public static event JobEndDlg JobEnd;
		public static event JobProgressDlg JobProgress;

		private class JobDictionary
		{
			private Dictionary<string, CategoryGroup> mList = new Dictionary<string, JobDictionary.CategoryGroup>();

			int indexed = 0;
			int unsorted = 0;

			private class CategoryGroup
			{
				public List<ProcessedSheet> Indexed = new List<ProcessedSheet>();
				public List<ProcessedSheet> Unsorted = new List<ProcessedSheet>();
			}

			internal void Add(SheetHeader sh, GeneartorOptions opt)
			{
				if (!mList.ContainsKey(sh.SheetCategory))
					mList.Add(sh.SheetCategory, new CategoryGroup());

				if (sh.Index < 0 || opt.RebuildIdx)
				{
					mList[sh.SheetCategory].Unsorted.Add(new ProcessedSheet(sh));
					unsorted++;
				}
				else
				{
					mList[sh.SheetCategory].Indexed.Add(new ProcessedSheet(sh));
					indexed++;
				}
			}

			internal void Execute(JobBeginDlg begin, JobProgressDlg progress, JobEndDlg end, GeneartorOptions opt)
			{
				begin?.Invoke(unsorted + indexed);

				Application app = new Application();
				app.CheckLanguage = false;
				app.Visible = true;

				Document doc = app.Documents.Add(System.IO.Path.GetFullPath("./Template/chordbook.dotx"), true, WdNewDocumentType.wdNewBlankDocument, true);
				doc.SpellingChecked = true;
				doc.GrammarChecked = true;
				doc.ShowGrammaticalErrors = false;
				doc.ShowSpellingErrors = false;

				Template tpl = new Template(doc);
				PreProcess(progress, app, doc, tpl, opt);

				//app.Dialogs[WdWordDialog.wdDialogFileSaveAs].Show();

				//doc.Close(Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges);
				//app.Quit();

				end?.Invoke();
			}



			private void PreProcess(JobProgressDlg progress, Application app, Document doc, Template tpl, GeneartorOptions opt)
			{
				foreach (KeyValuePair<string, CategoryGroup> kvp in mList)
				{
					int count = 0;
					foreach (ProcessedSheet ps in kvp.Value.Indexed)
					{
						ps.Analyze(app, doc, tpl, opt);
						progress?.Invoke(count++, ps.mSheet.Header);
					}
					foreach (ProcessedSheet ps in kvp.Value.Unsorted)
					{
						ps.Analyze(app, doc, tpl, opt);
						progress?.Invoke(count++, ps.mSheet.Header);
					}
				}

				AddIndex(doc);
			}

			private void AddIndex(Document doc)
			{
				Paragraph par = doc.Content.Paragraphs.Add();
				par.Range.InsertBreak(WdBreakType.wdPageBreak);
				doc.Indexes.Add(par.Range, WdHeadingSeparator.wdHeadingSeparatorBlankLine, true, WdIndexType.wdIndexIndent, 2, false, WdIndexSortBy.wdIndexSortBySyllable, WdLanguageID.wdItalian);
			}

			private class Template
			{
				public Style SongTitle;
				public Style SongArtist;
				public Style ChorusWC;
				public Style StorpheWC;
				public Style ChorusWoC;
				public Style StorpheWoC;
				public Style ChordTB;

				public PageSetup Page;

				public Template(Document doc)
				{
					SongTitle = doc.Styles["SongTitle"];
					SongArtist = doc.Styles["SongArtist"];

					ChorusWC = doc.Styles["ChorusWC"];
					StorpheWC = doc.Styles["StropheWC"];

					ChorusWoC = doc.Styles["ChorusWoC"];
					StorpheWoC = doc.Styles["StropheWoC"];

					ChordTB = doc.Styles["ChordTB"];

					Page = doc.PageSetup;
				}

			}

			private class ProcessedSheet
			{
				internal Sheet mSheet;
				List<Paragraph> mContent = new List<Paragraph>();

				public ProcessedSheet(SheetHeader sh)
				{ mSheet = new Sheet(sh.FileName); }

				internal void Analyze(Application app, Document doc, Template tpl, GeneartorOptions opt)
				{
					mSheet.ReloadFile();

					AddSongTitle(doc, tpl.SongTitle, mSheet.Header.SheetCategory, mSheet.Header.Title);
					if (mSheet.Header.Artist != null)
						AddSongArtist(doc, tpl.SongArtist, mSheet.Header.Artist);


					StringBuilder Helper = new StringBuilder();
					using (System.IO.StringReader sr = new System.IO.StringReader(mSheet.Content))
					{
						string line = null;
						bool InChorus = false;

						while ((line = sr.ReadLine()) != null)
						{
							if (line == "{soc}")
							{ OnNewParagraph(app, doc, tpl, Helper, InChorus, opt); InChorus = true; }
							else if (line == "{eoc}")
							{ OnNewParagraph(app, doc, tpl, Helper, InChorus, opt); InChorus = false; }
							else if (string.IsNullOrWhiteSpace(line))
							{ OnNewParagraph(app, doc, tpl, Helper, InChorus, opt); }
							else
							{ AppendToParagraph(Helper, line); }
						}

						OnNewParagraph(app, doc, tpl, Helper, InChorus, opt); //close last paragraph
					}
				}

				private void AppendToParagraph(StringBuilder Helper, string line)
				{
					if (Helper.Length > 0)
						Helper.Append('\v');		//append vertical newline (new line, same paragraph)

					Helper.Append(line);
				}

				private void OnNewParagraph(Application app, Document doc, Template tpl, StringBuilder Helper, bool InChorus, GeneartorOptions opt)
				{
					//close prev paragraph
					if (Helper.Length > 0)
						AddParagraph(app, doc, tpl, Helper.ToString(), InChorus, opt);

					//begin new paragraph
					Helper.Clear();
				}

				private void AddSongTitle(Document doc, Style style, string category, string title)
				{
					Paragraph par = doc.Content.Paragraphs.Add();
					par.Range.Text = title;
					par.set_Style(style);
					mContent.Add(par);
					par.Range.SpellingChecked = true;
					par.Range.GrammarChecked = true;
					doc.Indexes.MarkEntry(par.Range, $"{category}:{title}");
					par.Range.InsertParagraphAfter();
				}

				private void AddSongArtist(Document doc, Style style, string title)
				{
					Paragraph par = doc.Content.Paragraphs.Add();
					par.Range.Text = title;
					par.set_Style(style);
					par.Range.SpellingChecked = true;
					par.Range.GrammarChecked = true;
					mContent.Add(par);
					par.Range.InsertParagraphAfter();
				}

				private void AddParagraph(Application app, Document doc, Template tpl, string content, bool InChorus, GeneartorOptions opt)
				{
					System.Text.RegularExpressions.MatchCollection chords = RegexList.Chords.ChordProNote.Matches(content);
					//remove all chords
					content = RegexList.Chords.ChordProNote.Replace(content, "");

					bool WithChords = chords.Count > 0;
					Style style = InChorus ? (WithChords ? tpl.ChorusWC : tpl.ChorusWoC) : (WithChords ? tpl.StorpheWC : tpl.StorpheWoC);
					Paragraph par = doc.Content.Paragraphs.Add();
					par.Range.Text = content;
					par.set_Style(style);
					par.Range.SpellingChecked = true;
					par.Range.GrammarChecked = true;

					int parstart = par.Range.Start;
					int offset = 0;

					if (!opt.StripChord)
					{
						foreach (System.Text.RegularExpressions.Match chord in chords)
						{

							//var left = app.Selection.get_Information(Microsoft.Office.Interop.Word.WdInformation.wdHorizontalPositionRelativeToPage);
							//var top = app.Selection.get_Information(Microsoft.Office.Interop.Word.WdInformation.wdVerticalPositionRelativeToPage);

							Shape TB = doc.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 0, 0, 40, 20);
							TB.RelativeHorizontalPosition = WdRelativeHorizontalPosition.wdRelativeHorizontalPositionCharacter;

							TB.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
							TB.Fill.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
							TB.TextFrame.MarginBottom = 0;
							TB.TextFrame.MarginLeft = 0;
							TB.TextFrame.MarginRight = 0;
							TB.TextFrame.MarginTop = 0;
							TB.TextFrame.AutoSize = (int)Microsoft.Office.Core.MsoTriState.msoTrue;
							TB.TextFrame.TextRange.Text = chord.Value.Trim(new char[] { '[', ']' });
							TB.TextFrame.TextRange.set_Style(tpl.ChordTB);

							TB.Select();
							app.Selection.Cut();
							doc.Range(parstart + chord.Index - offset, parstart + chord.Index - offset + 1).Select();
							app.Selection.Paste();

							offset += chord.Length - 1;
						}
					}
					mContent.Add(par);
					par.Range.InsertParagraphAfter();

				}
			}
		}

		public static void Generate()
		{
			//Core.WordFile wf = new Core.WordFile();
			//wf.CreatePackage("D:\\songbook.docx");

			GeneartorOptions opt = Forms.BookGenerator.CreateAndShowDialog();
			JobDictionary job = new JobDictionary();

			foreach (SheetHeader sh in SheetDB.List)
			{
				if (!sh.Deletable && sh.Progress >= SheetHeader.SheetProgress.Locked && sh.SheetCategory != null)
					job.Add(sh, opt);
			}

			job.Execute(
				(int total) => { JobBegin?.Invoke(total); },
				(int count, SheetHeader sh) => { JobProgress?.Invoke(count, sh); },
				() => {JobEnd?.Invoke(); },
				opt);
		}

		public class GeneartorOptions
		{
			public bool RebuildIdx;
			public bool StripChord;
		}

	}
}
