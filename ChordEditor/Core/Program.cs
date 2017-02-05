/*
 * Created by SharpDevelop.
 * User: Diego
 * Date: 19/01/2017
 * Time: 22:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace ChordEditor.Core
{
		/// <summary>
		/// Description of Core.
		/// </summary>
		public static class Program
		{
				public static void Restart()
				{
						try { System.Windows.Forms.Application.Exit(); }
						catch { }
						System.Diagnostics.Process P = new System.Diagnostics.Process();
						System.Diagnostics.Process.Start(System.Windows.Forms.Application.ExecutablePath);
				}

		}
}
