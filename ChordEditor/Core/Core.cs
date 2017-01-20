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

		static Program()
		{
			OpenedSheet = new SheetList();
		}

		internal static void DocumentCreate()
		{
			OpenedSheet.CreateNew();
		}

		internal static void DocumentOpen()
		{

		}

		internal static void DocumentSave()
		{
			
		}

		internal static void DocumentPrint()
		{
			
		}

		internal static void DocumentClose()
		{
			
		}

		internal static void DocumentSaveAs()
		{
			
		}

		internal static void DocumentPrintPreview()
		{
			
		}

		internal static void DatabaseSyncronize()
		{
			
		}
	}
}
