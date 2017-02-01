/*
 * Created by SharpDevelop.
 * User: Diego
 * Date: 18/01/2017
 * Time: 19:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace ChordEditor
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Loader
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Settings.Default.Reset(); //reset config
			//Settings.Default.Upgrade();

			Application.Run(new MainForm());
		}

	}
}
