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
				PreProcess(message, app, doc, tpl, opt);
				BuildOutput(message, app, doc, tpl, opt);

				//app.Dialogs[WdWordDialog.wdDialogFileSaveAs].Show();

				//doc.Close(Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges);
				//app.Quit();

				message?.Invoke("Job Completed!\r\n");
			}

			private void BuildOutput(JobMessageDlg message, Application app, Document doc, Template tpl, GeneartorOptions opt)
			{
				message?.Invoke("Building final output...");
				foreach (KeyValuePair<string, CategoryGroup> kvp in mList)
				{
					foreach (ProcessedSheet ps in kvp.Value.Indexed)
					{
						message?.Invoke($"{Fase.Rendering} {ps.mSheet.Header.SheetCategory} {ps.mSheet.Header.Title}");
						ps.ProcessFile(app, doc, tpl, opt, Fase.Rendering);
					}

					kvp.Value.Unsorted.Sort((a, b) => a.mSheet.Header.Index.CompareTo(b.mSheet.Header.Index)); //sort unsorted

					foreach (ProcessedSheet ps in kvp.Value.Unsorted)
					{
						message?.Invoke($"{Fase.Rendering} {ps.mSheet.Header.SheetCategory} {ps.mSheet.Header.Title}");
						ps.ProcessFile(app, doc, tpl, opt, Fase.Rendering);
					}
				}

				AddIndex(doc);
			}

			private void PreProcess(JobMessageDlg message, Application app, Document doc, Template tpl, GeneartorOptions opt)
			{
				message?.Invoke("Compute song size...");
				foreach (KeyValuePair<string, CategoryGroup> kvp in mList)
				{
					foreach (ProcessedSheet ps in kvp.Value.Unsorted)
					{
						message?.Invoke($"{Fase.Analyze} {ps.mSheet.Header.SheetCategory} {ps.mSheet.Header.Title}");
						ps.ProcessFile(app, doc, tpl, opt, Fase.Analyze);
					}
				}

				message?.Invoke("Creating best fit groups for space optimization...");
				Dictionary<string, List<List<ProcessedSheet>>> catgroups = new Dictionary<string, List<List<ProcessedSheet>>>();
				foreach (KeyValuePair<string, CategoryGroup> kvp in mList)
				{
					List<List<ProcessedSheet>> groups = new List<List<ProcessedSheet>>();

					//ordina per dimensione decrescente, dalla più grande alla più piccola
					List<ProcessedSheet> tosort = new List<ProcessedSheet>(kvp.Value.Unsorted);
					tosort.Sort((a, b) => b.mSize.CompareTo(a.mSize));  

					while (tosort.Count > 0)
					{
						//create a new group
						List<ProcessedSheet> group = new List<ProcessedSheet>();

						//peek the biggest one
						MoveBetweenList(tosort, group, tosort[0]);

						//find best fitting song/songs
						List<ProcessedSheet> bestfitting = GetBestFitting(tosort, Math.Ceiling(group[0].mSize) - group[0].mSize);

						//move best fitting into group
						MoveBetweenList(tosort, group, bestfitting);

						groups.Add(group);
					}

					catgroups.Add(kvp.Key, groups);
				}

				message?.Invoke("Assigning song indexes...");
				foreach (KeyValuePair<string, CategoryGroup> kvp in mList)
				{
					//compute prev max index
					int index = 0;
					foreach (ProcessedSheet ps in kvp.Value.Indexed)
						index = Math.Max(index, ps.mSheet.Header.Index);

					List<List<ProcessedSheet>> groups = catgroups[kvp.Key];

					if (groups != null)
					{
						foreach (List<ProcessedSheet> group in groups)
						{
							foreach (ProcessedSheet sheet in group)
							{
								sheet.mSheet.Header.Index = index++;
							}
						}
					}
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

			private List<ProcessedSheet> GetBestFitting(List<ProcessedSheet> sheets, double freespace)
			{
				List<List<ProcessedSheet>> combos = GetAllCombos(sheets, freespace);
				List<ProcessedSheet> bestcombination = new List<ProcessedSheet>();

				double bestspace = 0;
				foreach (List<ProcessedSheet> combo in combos)
				{
					if (combo.Count > combos[0].Count && bestspace > 0) //prefer the shortest one
						break;

					double combospace = 0;
					foreach (ProcessedSheet sheet in combo)
						combospace += sheet.mSize;

					if (combospace < freespace && combospace > bestspace)
					{
						bestspace = combospace;
						bestcombination = combo;
					}
				}

				return bestcombination;
			}



			private static List<List<ProcessedSheet>> GetAllCombos(List<ProcessedSheet>list, double limit)
			{
				List<List<ProcessedSheet>> rv = new List<List<ProcessedSheet>>();

				for (int a = 0; a < list.Count ; a++ )
				{
					if (list[a].mSize <= limit)
						rv.Add(new List<ProcessedSheet>() { list[a] });

					for (int b = a; b < list.Count; b++)
					{
						if (list[a].mSize + list[b].mSize <= limit)
							rv.Add(new List<ProcessedSheet>() { list[a], list[b] });

						for (int c = b; c < list.Count; c++)
						{
							if (list[a].mSize + list[b].mSize + list[c].mSize <= limit)
								rv.Add(new List<ProcessedSheet>() { list[a], list[b], list[c] });

							for (int d = c; d < list.Count; d++)
							{
								if (list[a].mSize + list[b].mSize + list[c].mSize + list[d].mSize <= limit)
									rv.Add(new List<ProcessedSheet>() { list[a], list[b], list[c], list[d] });
							}
						}
					}
				}


				return rv;
			}

			//// Iterative, using 'i' as bitmask to choose each combo members
			//public static List<List<T>> GetAllCombos<T>(List<T> list)
			//{
			//	int comboCount = (int)Math.Pow(2, list.Count) - 1;
			//	List<List<T>> result = new List<List<T>>();
			//	for (int i = 1; i < comboCount + 1; i++)
			//	{
			//		// make each combo here
			//		result.Add(new List<T>());
			//		for (int j = 0; j < list.Count; j++)
			//		{
			//			if ((i >> j) % 2 != 0)
			//				result.Last().Add(list[j]);
			//		}
			//	}
			//	return result;
			//}

			// Example usage
			



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

				internal void ProcessFile(Application app, Document doc, Template tpl, GeneartorOptions opt, Fase fase)
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

						OnNewParagraph(app, doc, tpl, Helper, InChorus, opt); //close last paragraph
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
				if (!sh.Deletable && sh.Progress >= SheetHeader.SheetProgress.Verified && sh.SheetCategory != null)
					job.Add(sh, opt);
			}

			job.Execute((string message) => { JobMessage?.Invoke(message); }, opt);
		}

		public class GeneartorOptions
		{
			public bool RebuildIdx;
			public bool StripChord;
		}

	}
}
