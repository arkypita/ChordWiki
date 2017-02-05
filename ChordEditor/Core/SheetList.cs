using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChordEditor.Core
{
		public class SheetList : IEnumerable<Sheet>
		{
				public delegate void SheetDelegate(Sheet sheet);
				public event SheetDelegate OpenSheet;

				private List<Sheet> mList = new List<Sheet>();

				public void CreateNew()
				{
						Sheet sheet = new Sheet();
						mList.Add(sheet);

						if (OpenSheet != null)
								OpenSheet(sheet);
				}



				internal void Open(SheetHeader sh)
				{
						Sheet sheet = new Sheet(sh.FileName);
						mList.Add(sheet);

						if (OpenSheet != null)
								OpenSheet(sheet);
				}

				IEnumerator<Sheet> IEnumerable<Sheet>.GetEnumerator()
				{
						return mList.GetEnumerator();
				}

				System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
				{
						return mList.GetEnumerator();
				}
		}
}
