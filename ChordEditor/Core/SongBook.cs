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

								Application app = new Application();
								Document doc = app.Documents.Open(System.IO.Path.GetFullPath("./Template/chordbook.docx"));
								Template tpl = new Template(doc);


								PreProcess(progress, doc, tpl);
								//todo: implement sorting
								Write(doc);

								app.Dialogs[WdWordDialog.wdDialogFileSaveAs].Show();
								doc.Close();

								if (end != null) end();
						}

						private void Write(Document doc)
						{
								//foreach (KeyValuePair<string, JobDictionary.CategoryGroup> kvp in mList)
								//{
								//		//int count = 0;
								//		foreach (ProcessedSheet ps in kvp.Value.Indexed)
								//		{
								//				ps.Write(doc);
								//				//if (progress != null)
								//				//		progress(count++, ps.Sheet.Header);
								//		}
								//		foreach (ProcessedSheet ps in kvp.Value.Unsorted)
								//		{
								//				ps.Write(doc);
								//				//if (progress != null)
								//				//		progress(count++, ps.Sheet.Header);
								//		}
								//}
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

						private void Sort()
						{
								//foreach (KeyValuePair<string, JobDictionary.CategoryGroup> kvp in mList)
								//{
								//		int count = 0;
								//		foreach (ProcessedSheet ps in kvp.Value.Indexed)
								//		{
								//				ps.Analyze(tpl);
								//				if (progress != null)
								//						progress(count++, ps.Sheet.Header);
								//		}
								//		foreach (ProcessedSheet ps in kvp.Value.Unsorted)
								//		{
								//				ps.Analyze(tpl);
								//				if (progress != null)
								//						progress(count++, ps.Sheet.Header);
								//		}
								//}
						}


						private class Template
						{
								public Style SongTitle;
								public Style SongArtist;
								public Style ChordStyle;
								public Style ChorusWC;
								public Style StorpheWC;

								public PageSetup Page;

								public Template(Document doc)
								{
										SongTitle = doc.Styles["SongTitle"];
										SongArtist = doc.Styles["SongArtist"];
										
										ChorusWC = doc.Styles["ChorusWC"];
										StorpheWC = doc.Styles["StropheWC"];

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

										AddParagraph(doc, tpl.SongTitle, mSheet.Header.Title);
										if (mSheet.Header.Artist != null)
												AddParagraph(doc, tpl.SongArtist, mSheet.Header.Artist);

										string[] pars = mSheet.Content.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
										foreach (string par in pars)
												AddParagraph(doc, tpl.StorpheWC, par);
								}

								private void AddParagraph(Document doc, Style style, string content)
								{
										content = content.Replace("\r\n", "\v");

										Paragraph par = doc.Content.Paragraphs.Add();
										par.Range.Text = content;
										par.set_Style(style);
										mContent.Add(par);
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
								if (!sh.Deletable && sh.Progress >= SheetHeader.SheetProgress.Verified && sh.SheetCategory != null)
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
