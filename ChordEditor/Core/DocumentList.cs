using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChordEditor.Core
{
	public class DocumentList 
	{
		private List<Document> mList = new List<Document>();
		
		public Document CreateNew()
		{
			Document d = new Document();
			mList.Add(d);
			return d;
		}
		
	}
}
