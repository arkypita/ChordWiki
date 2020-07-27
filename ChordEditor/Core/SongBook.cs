using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
			private int indexed = 0;
			private int unsorted = 0;

			private class CategoryGroup
			{
				public List<ProcessedSheet> Indexed = new List<ProcessedSheet>();
				public List<ProcessedSheet> Unsorted = new List<ProcessedSheet>();
			}

			internal void Add(SheetHeader sh, GeneratorOptions opt)
			{
				if (!mList.ContainsKey(sh.SheetCategory))
				{
					mList.Add(sh.SheetCategory, new CategoryGroup());
				}

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

			internal void Execute(JobMessageDlg message, GeneratorOptions opt)
			{
				try
				{
					message?.Invoke("------ CREATE BOOK------");
					message?.Invoke($"Job Begin: {unsorted}/{unsorted + indexed} song to process.");

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
				catch (Exception ex){ message?.Invoke($"Error: {ex.Message}\r\n"); }
			}

			private void BuildOutput(JobMessageDlg message, Application app, Document doc, Template tpl, GeneratorOptions opt, Dictionary<string, List<SongGroup>> groups)
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
							ps.ProcessFile(app, doc, tpl, opt, Fase.Rendering, object.ReferenceEquals(ps, lsg[lsg.Count - 1]));
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

				public double SpaceToFill
				{
					get
					{
						if (PageCount == 1)
						{
							return 1 + WastedSpace;
						}
						else if (IsEven(PageCount))
						{
							return 1 + WastedSpace;
						}
						else
						{
							return WastedSpace;
						}
					}
				}

				private static bool IsEven(int value)
				{
					return value % 2 != 0;
				}
			}

			private Dictionary<string, List<SongGroup>> PreProcess(JobMessageDlg message, Application app, Document doc, Template tpl, GeneratorOptions opt)
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
							if (tosort[i].mSize < group.SpaceToFill)
							{
								MoveBetweenList(tosort, group, tosort[i]);
							}
							else
							{
								i++;
							}
						}

						groups.Add(group);
					}

					catgroups.Add(kvp.Key, groups);
				}

				return catgroups;
			}

			private void ComputeAllSongSize(JobMessageDlg message, Application app, Document doc, Template tpl, GeneratorOptions opt)
			{
				message?.Invoke("Computing song size...");

				Dictionary<string, double> knownSize = (Dictionary<string, double>)Serializer.ObjFromFile("SongSizeData.bin");
				if (knownSize == null || opt.RebuildSize)
				{
					knownSize = new Dictionary<string, double>();
				}

				foreach (KeyValuePair<string, CategoryGroup> kvp in mList)
				{
					foreach (ProcessedSheet ps in kvp.Value.Indexed)
					{
						ComputeSongSize(message, app, doc, tpl, opt, knownSize, ps);
					}

					foreach (ProcessedSheet ps in kvp.Value.Unsorted)
					{
						ComputeSongSize(message, app, doc, tpl, opt, knownSize, ps);
					}
				}

				Serializer.ObjToFile(knownSize, "SongSizeData.bin");
			}

			private static void ComputeSongSize(JobMessageDlg message, Application app, Document doc, Template tpl, GeneratorOptions opt, Dictionary<string, double> knownSize, ProcessedSheet ps)
			{
				string key = ps.mSheet.Header.FileNameLC + "." + opt.Type; //concatena opzione perché cambia la dimensione
				ps.mSheet.ReloadFile();

				// decommentare se si vuole fare un giro di correzione automatica dei file
				// suggerisco di non usare questa tecnica bensì aggiungere un pulsante per la pulizia
				// comunque viene fatta automaticamente sulla save

				//ps.mSheet.FixContentIssues();   //correct file content
				//if (ps.mSheet.HasMemoryChanges) //non dovrebbe succedere se non si chiama la FixContentIssues perché nessuno tocca il file
				//{
				//	if (knownSize.ContainsKey(key))
				//		knownSize.Remove(key); //must compute a new size

				//	ps.mSheet.Save();
				//}

				if (knownSize.ContainsKey(key))
				{
					ps.mSize = knownSize[key];
				}
				else
				{
					message?.Invoke($"{Fase.Analyze} {ps.mSheet.Header.SheetCategory} {ps.mSheet.Header.Title}");
					ps.ProcessFile(app, doc, tpl, opt, Fase.Analyze, false);
					knownSize.Add(key, ps.mSize);
				}
			}

			private static void MoveBetweenList(List<ProcessedSheet> from, List<ProcessedSheet> to, List<ProcessedSheet> items)
			{
				foreach (ProcessedSheet item in items)
				{
					MoveBetweenList(from, to, item);
				}
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

				public Style ChorusM;   //monospace
				public Style StorpheM;  //monospace

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

					ChorusM = doc.Styles["ChorusM"];
					StorpheM = doc.Styles["StropheM"];

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

				public ProcessedSheet(SheetHeader sh)
				{ mSheet = new Sheet(sh.FileNameLC); }

				internal void ProcessFile(Application app, Document doc, Template tpl, GeneratorOptions opt, Fase fase, bool closingGroup)
				{
					if (!loaded)
					{
						mSheet.ReloadFile();
					}

					loaded = true;

					AddSongTitle(doc, tpl.SongTitle, mSheet.Header.SheetCategory, mSheet.Header.Title);
					if (mSheet.Header.Artist != null)
						AddSongArtist(doc, tpl.SongArtist, mSheet.Header.Artist);

					StringBuilder Helper = new StringBuilder();

					string content = mSheet.Content;

					if (opt.Type == GeneratorOptions.BookType.Singer)
					{
						content = RegexList.Chords.ChordProNote.Replace(content, "");			//rimuovi gli accordi
						content = RegexList.Cleanup.AnyWhitespacesLine.Replace(content, "");    //rimuovi le linee di spazi vuoti che si vengono a formare
					}

					using (System.IO.StringReader sr = new System.IO.StringReader(content))
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
						Range range = doc.Paragraphs.Last.Range;

						int pcount = (int)range.Information[WdInformation.wdNumberOfPagesInDocument];
						float uph = doc.PageSetup.PageHeight - doc.PageSetup.BottomMargin - doc.PageSetup.TopMargin; //usefull page height
						float lph = ((float)range.Information[WdInformation.wdVerticalPositionRelativeToPage] - doc.PageSetup.TopMargin); //last page used height
						float waste = uph - lph;

						if (lph / uph > 1)
						{
							System.Diagnostics.Debug.WriteLine("error?");
						}

						float size = uph * pcount - waste;
						mSize = (pcount - 1) + lph / uph;

						System.Diagnostics.Debug.WriteLine($"{mSheet.Header.SheetCategory}\t{mSheet.Header.Title}\t{mSize}\t");
						doc.Content.Delete();
					}
				}

				private void AppendToParagraph(StringBuilder Helper, string line)
				{
					if (Helper.Length > 0)
					{
						Helper.Append('\v');        //append vertical newline (new line, same paragraph)
					}

					Helper.Append(line);
				}

				private void OnNewParagraph(Application app, Document doc, Template tpl, StringBuilder Helper, bool InChorus, GeneratorOptions opt, bool closingGroup = false)
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
					par.Range.InsertParagraphAfter();
				}

				private void AddParagraph(Application app, Document doc, Template tpl, string content, bool InChorus, GeneratorOptions opt, bool closingGroup = false)
				{
					if (opt.Type == GeneratorOptions.BookType.Singer)
						AddParagraphSinger(app, doc, tpl, content, InChorus, opt, closingGroup);
					else if (opt.Type == GeneratorOptions.BookType.Guitar)
						AddParagraphGuitar(app, doc, tpl, content, InChorus, opt, closingGroup);
				}

				private static void AddParagraphSinger(Application app, Document doc, Template tpl, string content, bool ChorusStyle, GeneratorOptions opt, bool closingGroup)
				{
					//inserisci il paragrafo
					Style style = ChorusStyle ? tpl.ChorusWoC : tpl.StorpheWoC;
					Paragraph par = doc.Content.Paragraphs.Add();
					par.Range.Text = closingGroup ? content + "\f" : content;
					par.set_Style(style);
					par.Range.SpellingChecked = true;
					par.Range.GrammarChecked = true;
					ProcessComments(doc, content, par);
					par.Range.InsertParagraphAfter();
				}

				private static void AddParagraphGuitar(Application app, Document doc, Template tpl, string content, bool InChorus, GeneratorOptions opt, bool closingGroup)
				{
					content = CpToMonospace(content);

					Style style = InChorus ? tpl.ChorusM : tpl.StorpheM;
					Paragraph par = doc.Content.Paragraphs.Add();
					par.Range.Text = closingGroup ? content + "\f" : content;
					par.set_Style(style);
					par.Range.SpellingChecked = true;
					par.Range.GrammarChecked = true;
					ProcessComments(doc, content, par);
					par.Range.InsertParagraphAfter();
				}

				private static void ProcessComments(Document doc, string content, Paragraph par)
				{
					int delta = 0; //cumulativo dei caratteri aggiunti e/o tolti

					foreach (Match m in RegexList.Comments.CHPCommentTag.Matches(content))
					{
						string src = m.Value;
						string rpl = $"({m.Groups["commento"].Value.Trim()})";

						int index = par.Range.Start + m.Index + delta;
						Range rng = doc.Range(index, index + src.Length);
						rng.Text = rpl;

						delta = delta + rpl.Length - src.Length;

						rng.Bold = -1; //attiva il bold
					}
				}

				private static string CpToMonospace(string content)
				{
					MatchCollection allmatch = Core.RegexList.Chords.ChordProNote.Matches(content);
					bool ContainsChords = allmatch.Count > 0;

					if (!ContainsChords)
						return content;

					StringBuilder rv = new StringBuilder();
					string[] arr = content.Split(new char[] { '\v' });
					foreach (string line in arr)
					{
						MatchCollection matches = Core.RegexList.Chords.ChordProNote.Matches(line);

						string chords;
						string song;

						Forms.SheetForm.ExtractSongChord(line, matches, out chords, out song);

						rv.Append(chords);
						rv.Append('\v');
						rv.Append(song);
						rv.Append('\v');
					}
					return rv.ToString().Trim(new char[] { '\v' });
				}
			}
		}

		public static void Generate(MainForm mainForm)
		{
			//Core.WordFile wf = new Core.WordFile();
			//wf.CreatePackage("D:\\songbook.docx");

			GeneratorOptions opt = Forms.BookGenerator.CreateAndShowDialog(mainForm);
			if (opt != null)
			{
				JobDictionary job = new JobDictionary();

				foreach (SheetHeader sh in SheetDB.List)
					if (!sh.Deletable && sh.Progress >= SheetHeader.SheetProgress.Locked && sh.SheetCategory != null) //if (sh.Title.Contains("TEST"))
						job.Add(sh, opt);

				job.Execute((string message) => { JobMessage?.Invoke(message); }, opt);
			}
		}

		public class GeneratorOptions
		{
			public bool RebuildIdx;
			public bool RebuildSize;
			public BookType Type;

			public enum BookType
			{Guitar, Singer}
		}

	}
}
