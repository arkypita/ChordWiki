using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordEditor.Core
{
		public static class SheetDB
		{
				public delegate void ListChangedDelegate();
				public static event ListChangedDelegate ListChanged;

				static List<SheetHeader> mList = new List<SheetHeader>();
				static List<SheetHeader> mDeleted = new List<SheetHeader>();

				static List<string> mCategories = new List<string>();
				static List<string> mTags = new List<string>();

				static SheetDB()
				{
						Importer.ImportEnd += Importer_ImportEnd;
						SVN.SvnEnd += SVN_SvnEnd;
				}

				static void SVN_SvnEnd(string message, bool reload)
				{
						if (reload)
								ReloadDataBase();
				}

				static void Importer_ImportEnd(string message, bool reload)
				{
						if (reload)
								ReloadDataBase();
				}



				private static string CurrentFolder
				{ get { return SVN.CurrentFolder; } }

				public static void ReloadDataBase()
				{
						if (System.IO.Directory.Exists(CurrentFolder))
						{
								//load from disk
								mList.Clear();
								mList.AddRange(LoadIndex());
								
								//store deleted to mDeleted
								foreach (SheetHeader sh in mList)
										if (!System.IO.File.Exists(sh.FilePath))
												mDeleted.Add(sh);

								//remove all deleted files
  							mList.RemoveAll(item => !System.IO.File.Exists(item.FilePath));
								
								//update changed files           
								mList.ForEach(item => item.ReloadChangedHeader());
								//add new files

								string[] filenames = System.IO.Directory.GetFiles(CurrentFolder);
								foreach (string filename in filenames)
								{
										if (System.IO.Path.GetFileName(filename).ToLower().EndsWith(".cpw"))
										{
												SheetHeader sh = new SheetHeader(filename);
												if (!mList.Contains(sh))
												{
														sh.ReloadHeader();
														mList.Add(sh);
												}
										}
								}

								foreach (SheetHeader sh in mList)
								{
										string cat = sh.SheetCategory;
										if (cat != null && !mCategories.Contains(cat))
												mCategories.Add(cat);

										foreach (string tag in sh.Tags)
												if (!mTags.Contains(tag))
														mTags.Add(tag);
								}

								SaveIndex();

								Dictionary<string, SharpSvn.SvnStatus> statuses = SVN.GetAllFileStatus(CurrentFolder);
								Dictionary<string, SharpSvn.SvnPropertyCollection> props = SVN.GetAllFileProperty(CurrentFolder);

								foreach (SheetHeader sh in mList)
								{
										if (statuses.ContainsKey(sh.FileName.ToLower()))
												sh.SVNStatus = statuses[sh.FileName.ToLower()];

										if (props.ContainsKey(sh.FileName.ToLower()))
												sh.Deletable = props[sh.FileName.ToLower()]["deletable"].StringValue == "true";
										else
												sh.Deletable = false;
								}

								if (ListChanged != null)
										ListChanged();
						}
				}

				private static List<SheetHeader> LoadIndex()
				{
						List<SheetHeader> rv = null;
						try
						{
								if (System.IO.File.Exists(CurrentFolder + "index.bin"))
								{
										System.Runtime.Serialization.Formatters.Binary.BinaryFormatter f = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
										using (System.IO.FileStream fs = new System.IO.FileStream(CurrentFolder + "index.bin", System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None))
										{
												rv = (List<SheetHeader>)f.Deserialize(fs);
												fs.Close();
										}
								}
						}
						catch { }

						if (rv != null)
								return rv;
						else
								return new List<SheetHeader>();
				}

				private static void SaveIndex()
				{
						System.Runtime.Serialization.Formatters.Binary.BinaryFormatter f = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
						using (System.IO.FileStream fs = new System.IO.FileStream(CurrentFolder + "index.bin", System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None))
						{
								f.Serialize(fs, mList);
								fs.Close();
						}
				}

				public static List<string> Categories
				{ get { return mCategories; } }

				public static List<string> Tags
				{ get { return mTags; } }

				public static List<SheetHeader> List
				{ get { return mList; } }


				public static SheetHeader GetByFileNameWithDeleted(string p)
				{
						SheetHeader rv = GetByFileNameWithDeleted1(p);
						if (rv == null && System.IO.File.Exists(p))
						{
								TryFastLoad(p);
								rv = GetByFileNameWithDeleted1(p);
						}
						return rv;
				}

				private static void TryFastLoad(string p)
				{
						try
						{
								SheetHeader sh = new SheetHeader(p);
								if (!mList.Contains(sh))
								{
										sh.ReloadHeader();
										mList.Add(sh);
								}
						}
						catch (Exception ex)
						{
 
						}
				}

				private static SheetHeader GetByFileNameWithDeleted1(string p)
				{
						if (p != null && p.Length > 0)
						{
								p = System.IO.Path.GetFileName(p).ToLower();

								foreach (SheetHeader sh in mList)
										if (System.IO.Path.GetFileName(sh.FileName).ToLower() == p)
												return sh;
								foreach (SheetHeader sh in mDeleted)
										if (System.IO.Path.GetFileName(sh.FileName).ToLower() == p)
												return sh;
						}

						return null;
				}
		}
}
