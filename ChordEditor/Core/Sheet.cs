using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChordEditor.Core
{
	public class Sheet
	{
        public delegate void SheetDelegate(Sheet s);
        public static event SheetDelegate SheetChange;

        private SheetHeader mHeader;
        private string mContent;
        private string mOContent;

        public Sheet()
        {
            mHeader = new SheetHeader();
            mHeader.Progress = SheetHeader.SheetProgress.Added;

            SheetHeader.HeaderChanged += SheetHeader_HeaderChanged;
        }

        public Sheet(string filename)
        {
            mHeader = new SheetHeader(filename);
			ReloadFile();
            SheetHeader.HeaderChanged += SheetHeader_HeaderChanged;
        }

        public SheetHeader Header
        { get { return mHeader; } }

        public string Content
        {
            get { return mContent; } 
            set 
            {
                if (mContent != value)
                {
                    mContent = value;

                    if (SheetChange != null)
                        SheetChange(this);
                }
            } 
        }

        void SheetHeader_HeaderChanged(SheetHeader sh)
        {
            if (SheetChange != null && object.Equals(sh, mHeader))
                SheetChange(this);
        }

        public void Save()
        {
            if (!HasMemoryChanges)
                return;

			bool createNew = !System.IO.File.Exists(mHeader.FilePath);

            System.IO.Directory.CreateDirectory(Program.CurrentFolder); //ensure path
			using (System.IO.StreamWriter sw =  new System.IO.StreamWriter(mHeader.FilePath))
			{
				//write header
				mHeader.Write(sw);

				//write separator
				sw.WriteLine("");

				//write content
				if (mContent != null)
					sw.Write(mContent);

				sw.Close();
			}

			mHeader.UpdateFileInfo();
            BackupStatus();

			if (createNew && !Program.LocalOrInvalid)
                using (SharpSvn.SvnClient cln = new SharpSvn.SvnClient())
                {
                    try
                    {
                        cln.Add(mHeader.FilePath); //mark for svn add
                    }
                    catch (Exception ex) { }
                }

            if (SheetChange != null)
                SheetChange(this);
        }

        void BackupStatus()
        {
            //salvo la mia memoria x confronto changes
            mOContent = mContent;
            mHeader.BackupStatus();
        }

        public bool HasMemoryChanges
        { get { return mHeader.MemoryHasChanges || mContent != mOContent; } }

		internal void ReloadFile()
		{
			using (System.IO.StreamReader sr = new System.IO.StreamReader(mHeader.FilePath))
			{
				mHeader.LoadFromStream(sr);
				mContent = sr.ReadToEnd();
			}

			BackupStatus();
		}
	}
}
