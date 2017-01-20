using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChordEditor.Core
{
	public class SheetList 
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
		
		
	}
}
