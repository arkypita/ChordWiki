//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using Microsoft.Office.Interop.Word;

//namespace ChordEditor.Core
//{
//	public static class SongBook
//	{

//		private class JobDictionary
//		{
//			private Dictionary<string, JobDictionary.CategoryGroup> mList = new Dictionary<string, JobDictionary.CategoryGroup>();
//			internal delegate void JobBegin(int total);
//			internal delegate void JobEnd();
//			internal delegate void JobProgress(int count, SheetHeader sh);


//			int indexed = 0;
//			int unsorted = 0;

//			private class CategoryGroup
//			{
//				public List<ProcessedSheet> Indexed = new List<ProcessedSheet>();
//				public List<ProcessedSheet> Unsorted = new List<ProcessedSheet>();
//			}

//			internal void Add(SheetHeader sh, GeneartorOptions opt)
//			{
//				if (!mList.ContainsKey(sh.SheetCategory))
//					mList.Add(sh.SheetCategory, new CategoryGroup());

//				if (sh.Index < 0 || opt.RebuildIdx)
//				{
//					mList[sh.SheetCategory].Unsorted.Add(new ProcessedSheet(sh));
//					unsorted++;
//				}
//				else
//				{
//					mList[sh.SheetCategory].Indexed.Add(new ProcessedSheet(sh));
//					indexed++;
//				}
//			}

//			internal void Execute(JobBegin begin, JobProgress progress, JobEnd end)
//			{
//				begin?.Invoke(unsorted + indexed);

//				object oMissing = System.Reflection.Missing.Value;

//				Application app = new Application();
//				app.CheckLanguage = false;
//				app.Visible = true;

//				Document doc = app.Documents.Add(System.IO.Path.GetFullPath("./Template/chordbook.dotx"), true, WdNewDocumentType.wdNewBlankDocument, true);
//				doc.SpellingChecked = true;
//				doc.GrammarChecked = true;
//				doc.ShowGrammaticalErrors = false;
//				doc.ShowSpellingErrors = false;

//				Template tpl = new Template(doc);
//				PreProcess(progress, app, doc, tpl);

//				//app.Dialogs[WdWordDialog.wdDialogFileSaveAs].Show();

//				//doc.Close(Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges);
//				//app.Quit();

//				end?.Invoke();
//			}



//			private void PreProcess(JobProgress progress, Application app, Document doc, Template tpl)
//			{
//				foreach (KeyValuePair<string, JobDictionary.CategoryGroup> kvp in mList)
//				{
//					int count = 0;
//					foreach (ProcessedSheet ps in kvp.Value.Indexed)
//					{
//						ps.Analyze(app, doc, tpl);
//						progress?.Invoke(count++, ps.mSheet.Header);
//					}
//					foreach (ProcessedSheet ps in kvp.Value.Unsorted)
//					{
//						ps.Analyze(app, doc, tpl);
//						progress?.Invoke(count++, ps.mSheet.Header);
//					}
//				}
//			}


//			private class Template
//			{
//				public Style SongTitle;
//				public Style SongArtist;
//				public Style ChorusWC;
//				public Style StorpheWC;
//				public Style ChorusWoC;
//				public Style StorpheWoC;
//				public Style ChordTB;

//				public PageSetup Page;

//				public Template(Document doc)
//				{
//					SongTitle = doc.Styles["SongTitle"];
//					SongArtist = doc.Styles["SongArtist"];

//					ChorusWC = doc.Styles["ChorusWC"];
//					StorpheWC = doc.Styles["StropheWC"];

//					ChorusWoC = doc.Styles["ChorusWoC"];
//					StorpheWoC = doc.Styles["StropheWoC"];

//					ChordTB = doc.Styles["ChordTB"];

//					Page = doc.PageSetup;
//				}

//			}

//			private class ProcessedSheet
//			{
//				internal Sheet mSheet;
//				List<Paragraph> mContent = new List<Paragraph>();

//				public ProcessedSheet(SheetHeader sh)
//				{ mSheet = new Sheet(sh.FileName); }

//				internal void Analyze(Application app, Document doc, Template tpl)
//				{
//					mSheet.ReloadFile();

//					AddHeader(doc, tpl.SongTitle, mSheet.Header.Title);
//					if (mSheet.Header.Artist != null)
//						AddHeader(doc, tpl.SongArtist, mSheet.Header.Artist);


//					StringBuilder Helper = new StringBuilder();
//					bool InChorus = false;
//					using (System.IO.StringReader sr = new System.IO.StringReader(mSheet.Content))
//					{
//						string line = null;
//						bool chorus = false;

//						while ((line = sr.ReadLine()) != null)
//						{
//							if (line == "{soc}")
//							{ OnNewParagraph(app, doc, tpl, Helper, InChorus); InChorus = true; }
//							else if (line == "{eoc}")
//							{ OnNewParagraph(app, doc, tpl, Helper, InChorus); InChorus = false; }
//							else if (string.IsNullOrWhiteSpace(line))
//							{ OnNewParagraph(app, doc, tpl, Helper, InChorus); }
//							else
//							{ AppendToParagraph(Helper, line); }
//						}

//						OnNewParagraph(app, doc, tpl, Helper, InChorus); //close last paragraph
//					}
//				}

//				private void AppendToParagraph(StringBuilder Helper, string line)
//				{
//					if (Helper.Length > 0)
//						Helper.Append('\v');		//append vertical newline (new line, same paragraph)

//					Helper.Append(line);
//				}

//				private void OnNewParagraph(Application app, Document doc, Template tpl, StringBuilder Helper, bool InChorus)
//				{
//					//close prev paragraph
//					if (Helper.Length > 0)
//						AddParagraph(app, doc, tpl, Helper.ToString(), InChorus);

//					//begin new paragraph
//					Helper.Clear();
//				}

//				private void AddHeader(Document doc, Style style, string title)
//				{
//					Paragraph par = doc.Content.Paragraphs.Add();
//					par.Range.Text = title;
//					par.set_Style(style);
//					mContent.Add(par);
//					par.Range.InsertParagraphAfter();
//				}

//				private void AddParagraph(Application app, Document doc, Template tpl, string content, bool InChorus)
//				{

//					System.Text.RegularExpressions.MatchCollection matches = Core.RegexList.Chords.ChordProNote.Matches(content);
//					//remove all chords
//					content = Core.RegexList.Chords.ChordProNote.Replace(content, "");

//					bool WithChords = matches.Count > 0;
//					Style style = InChorus ? (WithChords ? tpl.ChorusWC : tpl.ChorusWoC) : (WithChords ? tpl.StorpheWC : tpl.StorpheWoC);
//					Paragraph par = doc.Content.Paragraphs.Add();
//					par.Range.Text = content;
//					par.set_Style(style);
//					par.Range.SpellingChecked = true;
//					par.Range.GrammarChecked = true;

//					int parstart = par.Range.Start;
//					int offset = 0;
//					foreach (System.Text.RegularExpressions.Match match in matches)
//					{
						
//						//var left = app.Selection.get_Information(Microsoft.Office.Interop.Word.WdInformation.wdHorizontalPositionRelativeToPage);
//						//var top = app.Selection.get_Information(Microsoft.Office.Interop.Word.WdInformation.wdVerticalPositionRelativeToPage);

//						Shape TB = doc.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 0, 0, 40, 20);
//						TB.RelativeHorizontalPosition = WdRelativeHorizontalPosition.wdRelativeHorizontalPositionCharacter;

//						TB.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
//						TB.Fill.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
//						TB.TextFrame.MarginBottom = 0;
//						TB.TextFrame.MarginLeft = 0;
//						TB.TextFrame.MarginRight = 0;
//						TB.TextFrame.MarginTop = 0;
//						TB.TextFrame.AutoSize = (int)Microsoft.Office.Core.MsoTriState.msoTrue;
//						TB.TextFrame.TextRange.Text = match.Value.Trim(new char[] { '[', ']' });
//						TB.TextFrame.TextRange.set_Style(tpl.ChordTB);

//						TB.Select();
//						app.Selection.Cut();
//						doc.Range(parstart + match.Index - offset, parstart + match.Index - offset + 1).Select();
//						app.Selection.Paste();

//						offset += match.Length - 1;

//						System.Threading.Thread.Sleep(500);
//					}

//					par.Range.InsertParagraphAfter();

//				}






//			}

//		}

//		public static void Generate()
//		{
//			//Core.WordFile wf = new Core.WordFile();
//			//wf.CreatePackage("D:\\songbook.docx");

//			GeneartorOptions opt = Forms.BookGenerator.CreateAndShowDialog();
//			JobDictionary job = new JobDictionary();

//			foreach (SheetHeader sh in SheetDB.List)
//			{
//				if (!sh.Deletable && sh.Progress >= SheetHeader.SheetProgress.Locked && sh.SheetCategory != null)
//					job.Add(sh, opt);
//			}

//			job.Execute(null, (int count, SheetHeader sh) => { System.Diagnostics.Debug.WriteLine(sh.Title); }, null);
//		}

//		public class GeneartorOptions
//		{
//			public static int LineLenght = 60; //caratteri per linea
//			public static int PageWidth = 55; //linee per pagina
//			public bool RebuildIdx;
//		}

//	}
//}
