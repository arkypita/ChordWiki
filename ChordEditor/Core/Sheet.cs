using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChordEditor.Core
{
	public class Sheet
	{
        public SheetHeader mHeader;
        public SheetContent mContent;

        public Sheet()
        {
            mHeader = new SheetHeader();
            mContent = new SheetContent();
        }

        public Sheet(string filename)
        {
            using (System.IO.StreamReader sr = new System.IO.StreamReader(Program.CurrentFolder + filename))
            {
                mHeader = new SheetHeader(filename, sr);
                mContent = new SheetContent(sr);
            }
        }

        public void Save()
        {
            if (!HasChanges)
                return;


            System.IO.Directory.CreateDirectory(Program.CurrentFolder); //ensure path
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(Program.CurrentFolder + mHeader.FileName))
            {
                //write header
                mHeader.Write(sw);

                //write separator
                sw.WriteLine("");

                //write content
                mContent.Write(sw);

                sw.Close();
            }
        }

        public bool HasChanges
        { get { return mHeader.HasChanges || true; } }

	}
}
