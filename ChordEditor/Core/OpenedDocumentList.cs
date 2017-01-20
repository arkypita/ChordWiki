using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChordEditor.Core
{
	public class OpenedDocumentList 
	{
		private List<OpenedDocument> mList = new List<OpenedDocument>();
		
		public OpenedDocument CreateNew()
		{
			OpenedDocument d = new OpenedDocument();
			mList.Add(d);
			return d;
		}
		
	}
}
