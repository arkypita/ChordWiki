using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordEditor.Core
{
    public class SheetDB : IEnumerable<SheetHeader>
    {
        public delegate void ListChangedDelegate();
        public event ListChangedDelegate ListChanged;

        List<SheetHeader> mList = new List<SheetHeader>();

        public SheetDB()
        {
            
        }

        public void ReloadDataBase()
        {
            if (System.IO.Directory.Exists(Program.CurrentFolder))
            {
                //load from disk
                mList = LoadIndex();
                //remove all deleted files
                mList.RemoveAll(item => !System.IO.File.Exists(item.FilePath));
                //update changed files           
                mList.ForEach(item => item.ReloadChangedHeader());
                //add new files

                string[] filenames = System.IO.Directory.GetFiles(Program.CurrentFolder);
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

                SaveIndex();

                if (ListChanged != null)
                    ListChanged();
            }
        }

        private List<SheetHeader> LoadIndex()
        {
            List<SheetHeader> rv = null;
            try
            {
                if (System.IO.File.Exists(Program.CurrentFolder + "index.bin"))
                {
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter f = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    using (System.IO.FileStream fs = new System.IO.FileStream(Program.CurrentFolder + "index.bin", System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None))
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

        private void SaveIndex()
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter f = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (System.IO.FileStream fs = new System.IO.FileStream(Program.CurrentFolder + "index.bin", System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None))
            {
                f.Serialize(fs, mList);
                fs.Close();
            }
        }

        IEnumerator<SheetHeader> IEnumerable<SheetHeader>.GetEnumerator()
        {
            return mList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return mList.GetEnumerator();
        }
    }
}
