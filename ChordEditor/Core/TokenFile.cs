using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordEditor.Core
{
	public class TokenFile
	{
		public static bool TestAndDelete(string filename)
		{
			try
			{
				if (System.IO.File.Exists(filename))
				{
					System.IO.File.Delete(filename);
					return true;
				}

			}
			catch { }

			return false;
		}

		internal static void Set(string filename)
		{
			using (System.IO.FileStream fs = System.IO.File.Create(filename))
				fs.Close();
		}	
	}
}
