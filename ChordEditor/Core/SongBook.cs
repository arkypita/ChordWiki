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

		private class JobDictionary
		{
			private Dictionary<string, JobDictionary.CategoryGroup> mList = new Dictionary<string, JobDictionary.CategoryGroup>();
			internal delegate void JobBegin(int total);
			internal delegate void JobEnd();
			internal delegate void JobProgress(int count, SheetHeader sh);


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

			internal void Execute(JobBegin begin, JobProgress progress, JobEnd end)
			{
				if (begin != null) begin(unsorted + indexed);

				object oFalse = false;
				object oTrue = true;
				object oMissing = System.Reflection.Missing.Value;

				Application app = new Application();
				Document doc = app.Documents.Open(System.IO.Path.GetFullPath("./Template/chordbook.dotx"), oMissing,oTrue, oFalse);
				Template tpl = new Template(doc);

				PreProcess(progress, doc, tpl);

				app.Dialogs[WdWordDialog.wdDialogFileSaveAs].Show();
				
				doc.Close(Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges);
				app.Quit();

				if (end != null) end();
			}

			

			private void PreProcess(JobProgress progress, Document doc, Template tpl)
			{
				foreach (KeyValuePair<string, JobDictionary.CategoryGroup> kvp in mList)
				{
					int count = 0;
					foreach (ProcessedSheet ps in kvp.Value.Indexed)
					{
						ps.Analyze(doc, tpl);
						if (progress != null)
							progress(count++, ps.mSheet.Header);
					}
					foreach (ProcessedSheet ps in kvp.Value.Unsorted)
					{
						ps.Analyze(doc, tpl);
						if (progress != null)
							progress(count++, ps.mSheet.Header);
					}
				}
			}


			private class Template
			{
				public Style SongTitle;
				public Style SongArtist;
				public Style ChorusWC;
				public Style StorpheWC;
				public Style ChorusWoC;
				public Style StorpheWoC;

				public PageSetup Page;

				public Template(Document doc)
				{
					SongTitle = doc.Styles["SongTitle"];
					SongArtist = doc.Styles["SongArtist"];

					ChorusWC = doc.Styles["ChorusWC"];
					StorpheWC = doc.Styles["StropheWC"];

					ChorusWoC = doc.Styles["ChorusWoC"];
					StorpheWoC = doc.Styles["StropheWoC"];

					Page = doc.PageSetup;
				}
			}

			private class ProcessedSheet
			{
				internal Sheet mSheet;
				List<Paragraph> mContent = new List<Paragraph>();

				public ProcessedSheet(SheetHeader sh)
				{ mSheet = new Sheet(sh.FileName); }

				internal void Analyze(Document doc, Template tpl)
				{
					mSheet.ReloadFile();

					AddHeader(doc, tpl.SongTitle, mSheet.Header.Title);
					if (mSheet.Header.Artist != null)
						AddHeader(doc, tpl.SongArtist, mSheet.Header.Artist);


					StringBuilder Helper = new StringBuilder();
					bool InChorus = false;
					using (System.IO.StringReader sr = new System.IO.StringReader(mSheet.Content))
					{
						string line = null;
						bool chorus = false;

						while ((line = sr.ReadLine()) != null)
						{
							if (line == "{soc}")
							{ OnNewParagraph(doc, tpl, Helper, InChorus); InChorus = true; }
							else if (line == "{eoc}")
							{ OnNewParagraph(doc, tpl, Helper, InChorus); InChorus = false; }
							else if (string.IsNullOrWhiteSpace(line))
							{ OnNewParagraph(doc, tpl, Helper, InChorus); }
							else
							{ AppendToParagraph(Helper, line); }
						}

						OnNewParagraph(doc, tpl, Helper, InChorus); //close last paragraph
					}
				}

				private void AppendToParagraph(StringBuilder Helper, string line)
				{
					if (Helper.Length > 0)
						Helper.Append('\v');		//append vertical newline (new line, same paragraph)

					Helper.Append(line);
				}

				private void OnNewParagraph(Document doc, Template tpl, StringBuilder Helper, bool InChorus)
				{
					//close prev paragraph
					if (Helper.Length > 0)
						AddParagraph(doc, tpl, Helper.ToString(), InChorus);

					//begin new paragraph
					Helper.Clear();
				}

				private void AddHeader(Document doc, Style style, string title)
				{
					Paragraph par = doc.Content.Paragraphs.Add();
					par.Range.Text = title;
					par.set_Style(style);
					mContent.Add(par);
					par.Range.InsertParagraphAfter();
				}

				private void AddParagraph(Document doc, Template tpl, string content, bool InChorus)
				{
					System.Text.RegularExpressions.MatchCollection matches = Core.RegexList.Chords.ChordProNote.Matches(content);
					//remove all chords
					content = Core.RegexList.Chords.ChordProNote.Replace(content, "");
					
					bool WithChords = matches.Count > 0;
					Style style = InChorus ? (WithChords ? tpl.ChorusWC : tpl.ChorusWoC) : (WithChords ? tpl.StorpheWC : tpl.StorpheWoC);
					Paragraph par = doc.Content.Paragraphs.Add();
					par.Range.Text = content;
					par.set_Style(style);

					foreach (System.Text.RegularExpressions.Match match in matches)
					{
						Microsoft.Office.Interop.Word.Shape textbox = doc.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 0, 0, 100, 20, par.Range);
						textbox.TextFrame.TextRange.Text = match.Value;
						textbox.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
						textbox.TextFrame.MarginBottom = 0;
						textbox.TextFrame.MarginLeft = 0;
						textbox.TextFrame.MarginRight = 0;
						textbox.TextFrame.MarginTop = 0;

						//textbox.Width = 20;
					}

					par.Range.InsertParagraphAfter();
				}

				


			}

		}

		public static void Generate()
		{
			GeneartorOptions opt = Forms.BookGenerator.CreateAndShowDialog();

			JobDictionary job = new JobDictionary();


			foreach (SheetHeader sh in SheetDB.List)
			{
				if (!sh.Deletable && sh.Progress >= SheetHeader.SheetProgress.Reviewed && sh.SheetCategory != null)
					job.Add(sh, opt);
			}

			job.Execute(null, (int count, SheetHeader sh) => { System.Diagnostics.Debug.WriteLine(sh.Title); }, null);
		}


		public class GeneartorOptions
		{
			public bool RebuildIdx;
		}

	}
}
