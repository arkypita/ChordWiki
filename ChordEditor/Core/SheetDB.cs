using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordEditor.Core
{
    public class SheetDB : IEnumerable<SheetHeader>
    {
        List<SheetHeader> mList = new List<SheetHeader>();

        public SheetDB()
        {
 
        }

        public void LoadCurrentFolder()
        {
            mList.Clear();
            if (System.IO.Directory.Exists(Program.CurrentFolder))
            {
                foreach (String filename in System.IO.Directory.GetFiles(Program.CurrentFolder))
                {
                    if (System.IO.Path.GetExtension(filename).ToLower() == ".cpw")
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(filename))
                        {
                            SheetHeader sh = new SheetHeader(filename, sr);
                            mList.Add(sh);
                        }
                    }
                }
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
