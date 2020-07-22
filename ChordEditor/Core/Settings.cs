/*
 * Created by SharpDevelop.
 * User: Diego
 * Date: 25/12/2016
 * Time: 19:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ChordEditor.Core
{
		/// <summary>
		/// Description of Settings.
		/// </summary>
		public static class Settings
		{
				private static System.Collections.Generic.Dictionary<string, object> dic;

				static Settings()
				{
						try
						{
								if (System.IO.File.Exists("ChordEditor.Settings.bin"))
								{
										System.Runtime.Serialization.Formatters.Binary.BinaryFormatter f = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
										using (System.IO.FileStream fs = new System.IO.FileStream("ChordEditor.Settings.bin", System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None))
										{
												dic = (System.Collections.Generic.Dictionary<string, object>)f.Deserialize(fs);
												fs.Close();
										}
								}

						}
						catch { }

						if (dic == null)
								dic = new System.Collections.Generic.Dictionary<string, object>();
				}


				public static object GetObject(string key, object defval)
				{
						return dic.ContainsKey(key) ? dic[key] : defval;
				}

				public static void SetObject(string key, object value)
				{
						if (dic.ContainsKey(key))
								dic[key] = value;
						else
								dic.Add(key, value);
				}

				public static void Save()
				{
						System.Runtime.Serialization.Formatters.Binary.BinaryFormatter f = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
						using (System.IO.FileStream fs = new System.IO.FileStream("ChordEditor.Settings.bin", System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None))
						{
								f.Serialize(fs, dic);
								fs.Close();
						}
				}

				public static string Username
				{
						get { return (string)GetObject("Username", ""); }
						set { SetObject("Username", value); }
				}

				public static string CurrentRepo
				{
						get { return (string)GetObject("CurrentRepo", ""); }
						set { SetObject("CurrentRepo", value); }
				}

				public static bool LocalRepo
				{
						get { return (bool)GetObject("UseLocalRepo", true); }
						set { SetObject("UseLocalRepo", value); }
				}

				public static bool SuperUser
				{
						get { return true /*Username == "diego" || Username == "davide" || Username == "matteo"*/; }
				}

				public static byte[] LVState
				{
						get { return (byte[])GetObject("LVState", null); }
						set { SetObject("LVState", value); }
				}

				public static byte[] DPState
				{
						get { return (byte[])GetObject("DPState", null); }
						set { SetObject("DPState", value); }
				}
		}
}
