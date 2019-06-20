using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordEditor.Core
{
	public static class Serializer
	{
		public static object ObjFromFile(string filename)
		{
			lock (filename)
			{
				try
				{
					if (System.IO.File.Exists(filename))
					{
						System.Runtime.Serialization.Formatters.Binary.BinaryFormatter f = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
						using (System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None))
							return f.Deserialize(fs);
					}
				}
				catch { }

				return null;
			}
		}

		public static void ObjToFile(object data, string filename)
		{
			lock (filename)
			{
				System.Runtime.Serialization.Formatters.Binary.BinaryFormatter f = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				using (System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write, System.IO.FileShare.None))
					f.Serialize(fs, data);
			}
		}
	}
}
