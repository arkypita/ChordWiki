using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
								if (begin != null) begin(unsorted+indexed);

								Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
								Microsoft.Office.Interop.Word.Document doc = app.Documents.Open(System.IO.Path.GetFullPath("./Template/chordbook.docx"));


								
								foreach(KeyValuePair<string, JobDictionary.CategoryGroup> kvp in mList)
								{
										int count = 0;
										foreach (ProcessedSheet ps in kvp.Value.Indexed)
										{
												ps.Process(doc);
												if (progress != null)
														progress(count++, ps.Sheet.Header);
										}
										foreach (ProcessedSheet ps in kvp.Value.Unsorted)
										{
												ps.Process(doc);
												if (progress != null)
														progress(count++, ps.Sheet.Header);
										}
								}

								if (end != null) end();
						}



						private class ProcessedSheet
						{
								internal Sheet Sheet;
								List<ISongElement> mList = new List<ISongElement>();
								double FinalHeight = 0.0;

								private interface ISongElement
								{
										
								}

								private class TitleElement : ISongElement
								{
										private string p;

										public TitleElement(string p)
										{this.p = p;}
								}

								private class ArtistElement : ISongElement
								{
										private string p;

										public ArtistElement(string p)
										{
												// TODO: Complete member initialization
												this.p = p;
										}
								}

								private class ChorusElement : ISongElement
								{ }

								private class StropheElement : ISongElement
								{
										private string line;

										public StropheElement(string line)
										{
												// TODO: Complete member initialization
												this.line = line;
										}
								}

								private class ChordsElement : ISongElement
								{ }

								public ProcessedSheet(SheetHeader sh)
								{
										Sheet = new Sheet(sh.FileName);
								}


								internal void Process(Microsoft.Office.Interop.Word.Document doc)
								{
										Sheet.ReloadFile();

										mList.Add(new TitleElement(Sheet.Header.Title));
										FinalHeight += doc.Styles["SongTitle"].Font.Size;

										if (Sheet.Header.Artist != null)
										{
												mList.Add(new ArtistElement(Sheet.Header.Artist));
												FinalHeight += doc.Styles["SongArtist"].Font.Size;
										}

										using (var reader = new System.IO.StringReader(Sheet.Content))
										{
												for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
												{
														mList.Add(new StropheElement(line));
														FinalHeight += 1.0;
												}
										}
								}

						}

				}

				public static void Generate()
				{
						GeneartorOptions opt = Forms.BookGenerator.CreateAndShowDialog();

						JobDictionary job = new JobDictionary();


						foreach (SheetHeader sh in SheetDB.List)
						{
								if (!sh.Deletable && /*sh.Progress >= SheetHeader.SheetProgress.Reviewed &&*/ sh.SheetCategory != null)
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
