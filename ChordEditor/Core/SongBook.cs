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
		public enum Fase
		{ Analyze, Rendering }

		public delegate void JobMessageDlg(string message);
		//public delegate void JobEndDlg();
		//public delegate void JobProgressDlg(int count, SheetHeader sh, SongBook.Fase fase);

		public static event JobMessageDlg JobMessage;
		//public static event JobEndDlg JobEnd;
		//public static event JobProgressDlg JobProgress;

		private class JobDictionary
		{
			private Dictionary<string, CategoryGroup> mList = new Dictionary<string, CategoryGroup>();

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

			internal void Execute(JobMessageDlg message, GeneartorOptions opt)
			{
				message?.Invoke("------ CREATE BOOK------");
				message?.Invoke($"Job Begin: {unsorted}/{unsorted+indexed} song to process.");

				Application app = new Application();
				app.CheckLanguage = false;
				app.Visible = true;

				Document doc = app.Documents.Add(System.IO.Path.GetFullPath("./Template/chordbook.dotx"), true, WdNewDocumentType.wdNewBlankDocument, true);
				doc.SpellingChecked = true;
				doc.GrammarChecked = true;
				doc.ShowGrammaticalErrors = false;
				doc.ShowSpellingErrors = false;

				Template tpl = new Template(doc);
				Dictionary<string, List<SongGroup>> groups = PreProcess(message, app, doc, tpl, opt);
				BuildOutput(message, app, doc, tpl, opt, groups);

				//app.Dialogs[WdWordDialog.wdDialogFileSaveAs].Show();

				//doc.Close(Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges);
				//app.Quit();

				message?.Invoke("Job Completed!\r\n");
			}

			private void BuildOutput(JobMessageDlg message, Application app, Document doc, Template tpl, GeneartorOptions opt, Dictionary<string, List<SongGroup>> groups)
			{
				message?.Invoke("Building final output...");
				foreach (KeyValuePair<string, List<SongGroup>> kvp in groups)
				{
					AddSectionHeader(doc, tpl, kvp.Key);

					foreach (SongGroup lsg in kvp.Value)
					{
						foreach (ProcessedSheet ps in lsg)
						{
							message?.Invoke($"{Fase.Rendering} {ps.mSheet.Header.SheetCategory} {ps.mSheet.Header.Title}");
							ps.ProcessFile(app, doc, tpl, opt, Fase.Rendering, object.ReferenceEquals(ps, lsg[lsg.Count-1]));
						}
					}

					doc.Words.Last.InsertBreak(WdBreakType.wdSectionBreakNextPage); //add section break
				}

				AddIndex(doc);
			}

			private void AddSectionHeader(Document doc, Template tpl, string section)
			{
				Paragraph par = doc.Content.Paragraphs.Add();
				par.Range.Text = section;
				par.set_Style(tpl.SectionHeader);
				par.Range.SpellingChecked = true;
				par.Range.GrammarChecked = true;
				par.Range.InsertParagraphAfter();
				par.Range.InsertBreak(WdBreakType.wdPageBreak);
			}

			private class SongGroup : List<ProcessedSheet>
			{
				public double UsedSpace => this.Sum(item => item.mSize);
				public double WastedSpace => PageCount - UsedSpace;
				public int PageCount => (int)Math.Ceiling(UsedSpace);
			}

			private Dictionary<string, List<SongGroup>> PreProcess(JobMessageDlg message, Application app, Document doc, Template tpl, GeneartorOptions opt)
			{
				ComputeAllSongSize(message, app, doc, tpl, opt);
				return CreatePageGroups(message);
				//AssignIndexes(message, catgroups);
			}

			//private void AssignIndexes(JobMessageDlg message, Dictionary<string, List<SongGroup>> catgroups)
			//{
			//	message?.Invoke("Assigning song indexes...");
			//	foreach (KeyValuePair<string, CategoryGroup> kvp in mList)
			//	{
			//		//compute prev max index
			//		int index = 0;
			//		foreach (ProcessedSheet ps in kvp.Value.Indexed)
			//			index = Math.Max(index, ps.mSheet.Header.Index);

			//		List<SongGroup> groups = catgroups[kvp.Key];

			//		if (groups != null)
			//		{
			//			foreach (List<ProcessedSheet> group in groups)
			//			{
			//				foreach (ProcessedSheet sheet in group)
			//				{
			//					sheet.mSheet.Header.Index = index++;
			//				}
			//			}
			//		}
			//	}
			//}

			private Dictionary<string, List<SongGroup>> CreatePageGroups(JobMessageDlg message)
			{
				Dictionary<string, List<SongGroup>> catgroups = new Dictionary<string, List<SongGroup>>();
				message?.Invoke("Creating best fit groups for space optimization...");
				foreach (KeyValuePair<string, CategoryGroup> kvp in mList)
				{
					List<SongGroup> groups = new List<SongGroup>();

					//ordina per dimensione decrescente, dalla più grande alla più piccola
					List<ProcessedSheet> tosort = new List<ProcessedSheet>(kvp.Value.Unsorted);
					tosort.Sort((a, b) => b.mSize.CompareTo(a.mSize));

					while (tosort.Count > 0)
					{
						SongGroup group = new SongGroup();          //create a new group
						MoveBetweenList(tosort, group, tosort[0]);  //peek the biggest one

						for (int i = 0; i < tosort.Count;)
						{
							if (tosort[i].mSize < group.WastedSpace)
								MoveBetweenList(tosort, group, tosort[i]);
							else
								i++;
						}

						groups.Add(group);
					}

					catgroups.Add(kvp.Key, groups);
				}

				return catgroups;
			}

			private void ComputeAllSongSize(JobMessageDlg message, Application app, Document doc, Template tpl, GeneartorOptions opt)
			{
				message?.Invoke("Computing song size...");

				Dictionary<string, double> knownSize = (Dictionary<string, double>)Serializer.ObjFromFile("SongSizeData.bin");
				if (knownSize == null || opt.RebuildSize) knownSize = new Dictionary<string, double>();

				foreach (KeyValuePair<string, CategoryGroup> kvp in mList)
				{
					foreach (ProcessedSheet ps in kvp.Value.Indexed)
						ComputeSongSize(message, app, doc, tpl, opt, knownSize, ps);
					foreach (ProcessedSheet ps in kvp.Value.Unsorted)
						ComputeSongSize(message, app, doc, tpl, opt, knownSize, ps);
				}

				Serializer.ObjToFile(knownSize, "SongSizeData.bin");
			}

			private static void ComputeSongSize(JobMessageDlg message, Application app, Document doc, Template tpl, GeneartorOptions opt, Dictionary<string, double> knownSize, ProcessedSheet ps)
			{
				ps.mSheet.ReloadFile();
				ps.mSheet.FixContentIssues();               //correct file content
				if (ps.mSheet.HasMemoryChanges)
				{
					if (knownSize.ContainsKey(ps.mSheet.Header.FileName)) knownSize.Remove(ps.mSheet.Header.FileName); //must compute a new size
					ps.mSheet.Save();
				}

				if (knownSize.ContainsKey(ps.mSheet.Header.FileName))
				{
					ps.mSize = knownSize[ps.mSheet.Header.FileName];
				}
				else
				{
					message?.Invoke($"{Fase.Analyze} {ps.mSheet.Header.SheetCategory} {ps.mSheet.Header.Title}");
					ps.ProcessFile(app, doc, tpl, opt, Fase.Analyze, false);
					knownSize.Add(ps.mSheet.Header.FileName, ps.mSize);
				}
			}

			private static void MoveBetweenList(List<ProcessedSheet> from, List<ProcessedSheet> to, List<ProcessedSheet> items)
			{
				foreach (ProcessedSheet item in items)
					MoveBetweenList(from, to, item);
			}

			private static void MoveBetweenList(List<ProcessedSheet> from, List<ProcessedSheet> to, ProcessedSheet item)
			{
				from.Remove(item);
				to.Add(item);
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
				public Style SectionHeader;

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

					SectionHeader = doc.Styles["SectionHeader"];

					Page = doc.PageSetup;

					System.Diagnostics.Debug.WriteLine($"Page Height {Page.PageHeight}");
				}

			}

			private class ProcessedSheet
			{
				public bool loaded;
				public double mSize;
				internal Sheet mSheet;
				List<Paragraph> mContent = new List<Paragraph>();

				public ProcessedSheet(SheetHeader sh)
				{ mSheet = new Sheet(sh.FileName); }

				internal void ProcessFile(Application app, Document doc, Template tpl, GeneartorOptions opt, Fase fase, bool closingGroup)
				{
					if (!loaded) mSheet.ReloadFile();
					loaded = true;

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

						OnNewParagraph(app, doc, tpl, Helper, InChorus, opt, closingGroup); //close last paragraph
					}

					if (fase == Fase.Analyze)
					{
						Range range = doc.Range(mContent[0].Range.Start, mContent[0].Range.End);

						int pcount = (int)range.Information[WdInformation.wdNumberOfPagesInDocument];
						float uph = doc.PageSetup.PageHeight - doc.PageSetup.BottomMargin - doc.PageSetup.TopMargin; //usefull page height
						float lph = ((float)range.Information[WdInformation.wdVerticalPositionRelativeToPage] - doc.PageSetup.TopMargin); //last page used height
						float waste = uph - lph;

						if (lph / uph > 1)
							System.Diagnostics.Debug.WriteLine("error?");

						float size = uph * pcount - waste;
						mSize = (pcount - 1) + lph / uph;

						System.Diagnostics.Debug.WriteLine($"{mSheet.Header.SheetCategory}\t{mSheet.Header.Title}\t{mSize}\t");
						doc.Content.Delete();
					}
				}

				private void AppendToParagraph(StringBuilder Helper, string line)
				{
					if (Helper.Length > 0)
						Helper.Append('\v');		//append vertical newline (new line, same paragraph)

					Helper.Append(line);
				}

				private void OnNewParagraph(Application app, Document doc, Template tpl, StringBuilder Helper, bool InChorus, GeneartorOptions opt, bool closingGroup = false)
				{
					//close prev paragraph
					if (Helper.Length > 0)
						AddParagraph(app, doc, tpl, Helper.ToString(), InChorus, opt, closingGroup);

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

				private void AddParagraph(Application app, Document doc, Template tpl, string content, bool InChorus, GeneartorOptions opt, bool closingGroup = false)
				{
					System.Text.RegularExpressions.MatchCollection chords = RegexList.Chords.ChordProNote.Matches(content);
					//remove all chords
					content = RegexList.Chords.ChordProNote.Replace(content, "");

					bool WithChords = chords.Count > 0;
					Style style = InChorus ? (WithChords ? tpl.ChorusWC : tpl.ChorusWoC) : (WithChords ? tpl.StorpheWC : tpl.StorpheWoC);
					Paragraph par = doc.Content.Paragraphs.Add();
					par.Range.Text = closingGroup ? content + "\f" : content ;
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

					par.Range.InsertParagraphAfter();

					mContent.Add(par);
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
				if (!sh.Deletable && sh.Progress >= SheetHeader.SheetProgress.Verified && sh.SheetCategory != null)
					job.Add(sh, opt);
			}

			job.Execute((string message) => { JobMessage?.Invoke(message); }, opt);
		}

		public class GeneartorOptions
		{
			public bool RebuildIdx;
			public bool RebuildSize;
			public bool StripChord;
		}

	}
}
