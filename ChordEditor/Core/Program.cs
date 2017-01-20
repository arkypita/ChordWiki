/*
 * Created by SharpDevelop.
 * User: Diego
 * Date: 19/01/2017
 * Time: 22:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ChordEditor.Core
{
	/// <summary>
	/// Description of Core.
	/// </summary>
	public static class Program
	{

		public static SheetList OpenedSheet;
        public static SheetDB SheetDB;

		static Program()
		{
			OpenedSheet = new SheetList();
            SheetDB = new SheetDB();

            SheetDB.LoadCurrentFolder();
		}

		internal static void DocumentCreate()
		{
			OpenedSheet.CreateNew();
		}

		internal static void DocumentOpen()
		{
            using (Forms.SheetDatabase f = new Forms.SheetDatabase())
                f.ShowDialog();
		}

		internal static void DatabaseSyncronize()
		{
			
		}

        public static string UserLongName
        { get { return "Diego Settimi"; } }

        public static string CurrentFolder
        { get { return ".\\SheetDB\\Local\\"; } }
	}
}
