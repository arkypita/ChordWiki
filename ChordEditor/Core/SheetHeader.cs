using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordEditor.Core
{

    public class SheetHeader
    {
        private string mFileName;
        private Dictionary<string, string> mMetaData;

        public SheetHeader()
        {
            mFileName = Guid.NewGuid().ToString() + ".cpw";
            mMetaData = new Dictionary<string, string>();
            SheetAuthor = Program.UserLongName;
            Title = "La canzone del sole";
            Artist = "Lucio Battisti";
            SheetCategory = "Cantautori";
        }

        public SheetHeader(string filename, System.IO.StreamReader sr)
        {
            mFileName = System.IO.Path.GetFileName(filename);
            mMetaData = new Dictionary<string, string>();

            string line = null;
            while (!sr.EndOfStream && (line = sr.ReadLine()) != "") //stringa vuota separa header dai dati
            {
                int index;
                if (line.StartsWith("{") && line.EndsWith("}") && (index = line.IndexOf(':')) >= 0)
                    SetMeta(line.Substring(1, index-1), line.Substring(index+1, line.Length - index -2));
            }
        }

        public string FileName
        { get { return mFileName; } }

        public string Title
        {
            get { return GetMeta("title"); }
            set { SetMeta("title", value); }
        }

        public string Subtitle
        {
            get { return GetMeta("subtitle"); }
            set { SetMeta("subtitle", value); }
        }

        public string Artist
        {
            get { return GetMeta("artist"); }
            set { SetMeta("artist", value); }
        }

        public string Key
        {
            get { return GetMeta("key"); }
            set { SetMeta("key", value); }
        }

        public string SheetCategory
        {
            get { return GetMeta("sheetcategory"); }
            set { SetMeta("sheetcategory", value); }
        }

        public string SheetAuthor
        {
            get { return GetMeta("sheetauthor"); }
            set { SetMeta("sheetauthor", value); }
        }

        public string SheetRevisor
        {
            get { return GetMeta("sheetrevisor"); }
            set { SetMeta("sheetrevisor", value); }
        }

        public bool Locked
        {
            get { return GetMeta("locked") == null ? false : bool.Parse(GetMeta("locked")); }
            set { SetMeta("locked", value.ToString()); }
        }

        public List<string> Tags
        {
            get 
            {
                string tags = GetMeta("tags");
                if (tags != null)
                    return new List<string>(tags.Split(",".ToCharArray()));
                else
                    return new List<string>();
            }
            set 
            {
                StringBuilder sb = new StringBuilder();
                foreach (string tag in value)
                {
                    sb.Append(tag);
                    sb.Append(",");
                }
                if (sb.Length > 0)
                    sb.Length = sb.Length - 1;
                
                SetMeta("tags", sb.ToString());
            }
        }

        private string GetMeta(string key)
        {
            if (key == null || key.Trim().Length == 0)
                throw new InvalidOperationException("Empty string not allowed in file metadata!");

            key = key.Trim().ToLower();

            if (mMetaData.ContainsKey(key))
                return mMetaData[key];
            else
                return null;
        }

        private void SetMeta(string key, string value)
        {
            if (key == null || key.Trim().Length == 0 )
                throw new InvalidOperationException("Empty key not allowed in file metadata!");

            key = key.Trim().ToLower();

            if ((value == null || value.Trim().Length == 0) && mMetaData.ContainsKey(key))
            {
                mMetaData.Remove(key);
            }
            else
            {
                value = value.Trim();
                if (mMetaData.ContainsKey(key))
                    mMetaData[key] = value;
                else
                    mMetaData.Add(key, value);
            }
        }

        internal void Write(System.IO.StreamWriter sw)
        {
            WriteNoNull(sw, "title");
            WriteNoNull(sw, "subtitle");
            WriteNoNull(sw, "artist");
            WriteNoNull(sw, "key");
            WriteNoNull(sw, "tags");
            WriteNoNull(sw, "sheetcategory");
            WriteNoNull(sw, "sheetauthor");
            WriteNoNull(sw, "sheetrevisor");
            if (Locked) WriteNoNull(sw, "locked");
        }

        private void WriteNoNull(System.IO.StreamWriter sw, string key)
        {
            string value = GetMeta(key);
            if (key != null && value != null && key.Length > 0 && value.Length > 0)
                sw.WriteLine("{{{0}:{1}}}", key, value);
        }

        public bool HasChanges
        { get { return true; } }
    }
}
