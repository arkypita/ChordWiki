/*
 * Created by SharpDevelop.
 * User: Diego
 * Date: 18/01/2017
 * Time: 19:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ChordEditor
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.StatusStrip MSS;
		private System.Windows.Forms.MenuStrip MMS;
		private System.Windows.Forms.ToolStrip MTS;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem MnNewSheet;
		private System.Windows.Forms.ToolStripMenuItem MnOpenSheet;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolTip MTT;
		private System.Windows.Forms.ToolStripButton BtnNewSheet;
		private System.Windows.Forms.ToolStripButton BtnOpenSheet;
		private System.Windows.Forms.ToolStripButton BtnPrintSheet;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripButton cutToolStripButton;
		private System.Windows.Forms.ToolStripButton copyToolStripButton;
		private System.Windows.Forms.ToolStripButton pasteToolStripButton;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// 
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			ChordEditor.UserControls.DockingManager.DockPanelSkin dockPanelSkin1 = new ChordEditor.UserControls.DockingManager.DockPanelSkin();
			ChordEditor.UserControls.DockingManager.AutoHideStripSkin autoHideStripSkin1 = new ChordEditor.UserControls.DockingManager.AutoHideStripSkin();
			ChordEditor.UserControls.DockingManager.DockPanelGradient dockPanelGradient1 = new ChordEditor.UserControls.DockingManager.DockPanelGradient();
			ChordEditor.UserControls.DockingManager.TabGradient tabGradient1 = new ChordEditor.UserControls.DockingManager.TabGradient();
			ChordEditor.UserControls.DockingManager.DockPaneStripSkin dockPaneStripSkin1 = new ChordEditor.UserControls.DockingManager.DockPaneStripSkin();
			ChordEditor.UserControls.DockingManager.DockPaneStripGradient dockPaneStripGradient1 = new ChordEditor.UserControls.DockingManager.DockPaneStripGradient();
			ChordEditor.UserControls.DockingManager.TabGradient tabGradient2 = new ChordEditor.UserControls.DockingManager.TabGradient();
			ChordEditor.UserControls.DockingManager.DockPanelGradient dockPanelGradient2 = new ChordEditor.UserControls.DockingManager.DockPanelGradient();
			ChordEditor.UserControls.DockingManager.TabGradient tabGradient3 = new ChordEditor.UserControls.DockingManager.TabGradient();
			ChordEditor.UserControls.DockingManager.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient1 = new ChordEditor.UserControls.DockingManager.DockPaneStripToolWindowGradient();
			ChordEditor.UserControls.DockingManager.TabGradient tabGradient4 = new ChordEditor.UserControls.DockingManager.TabGradient();
			ChordEditor.UserControls.DockingManager.TabGradient tabGradient5 = new ChordEditor.UserControls.DockingManager.TabGradient();
			ChordEditor.UserControls.DockingManager.DockPanelGradient dockPanelGradient3 = new ChordEditor.UserControls.DockingManager.DockPanelGradient();
			ChordEditor.UserControls.DockingManager.TabGradient tabGradient6 = new ChordEditor.UserControls.DockingManager.TabGradient();
			ChordEditor.UserControls.DockingManager.TabGradient tabGradient7 = new ChordEditor.UserControls.DockingManager.TabGradient();
			this.MSS = new System.Windows.Forms.StatusStrip();
			this.MMS = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MnNewSheet = new System.Windows.Forms.ToolStripMenuItem();
			this.MnOpenSheet = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.syncronizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MTS = new System.Windows.Forms.ToolStrip();
			this.BtnNewSheet = new System.Windows.Forms.ToolStripButton();
			this.BtnOpenSheet = new System.Windows.Forms.ToolStripButton();
			this.BtnPrintSheet = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.MTT = new System.Windows.Forms.ToolTip(this.components);
			this.DP = new ChordEditor.UserControls.DockingManager.DockPanel();
			this.MMS.SuspendLayout();
			this.MTS.SuspendLayout();
			this.SuspendLayout();
			// 
			// MSS
			// 
			this.MSS.Location = new System.Drawing.Point(0, 489);
			this.MSS.Name = "MSS";
			this.MSS.Size = new System.Drawing.Size(789, 22);
			this.MSS.TabIndex = 0;
			this.MSS.Text = "statusStrip1";
			// 
			// MMS
			// 
			this.MMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.fileToolStripMenuItem,
			this.editToolStripMenuItem,
			this.toolsToolStripMenuItem});
			this.MMS.Location = new System.Drawing.Point(0, 0);
			this.MMS.Name = "MMS";
			this.MMS.Size = new System.Drawing.Size(789, 24);
			this.MMS.TabIndex = 1;
			this.MMS.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.MnNewSheet,
			this.MnOpenSheet,
			this.closeToolStripMenuItem,
			this.toolStripSeparator2,
			this.syncronizeToolStripMenuItem,
			this.toolStripMenuItem1,
			this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// MnNewSheet
			// 
			this.MnNewSheet.Image = ((System.Drawing.Image)(resources.GetObject("MnNewSheet.Image")));
			this.MnNewSheet.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MnNewSheet.Name = "MnNewSheet";
			this.MnNewSheet.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.MnNewSheet.Size = new System.Drawing.Size(152, 22);
			this.MnNewSheet.Text = "&New";
			this.MnNewSheet.Click += new System.EventHandler(this.DocumentCreate);
			// 
			// MnOpenSheet
			// 
			this.MnOpenSheet.Image = ((System.Drawing.Image)(resources.GetObject("MnOpenSheet.Image")));
			this.MnOpenSheet.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MnOpenSheet.Name = "MnOpenSheet";
			this.MnOpenSheet.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.MnOpenSheet.Size = new System.Drawing.Size(152, 22);
			this.MnOpenSheet.Text = "&Open";
			this.MnOpenSheet.Click += new System.EventHandler(this.DocumentOpen);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Enabled = false;
			this.closeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("closeToolStripMenuItem.Image")));
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.closeToolStripMenuItem.Text = "&Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.DocumentClose);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
			// 
			// syncronizeToolStripMenuItem
			// 
			this.syncronizeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("syncronizeToolStripMenuItem.Image")));
			this.syncronizeToolStripMenuItem.Name = "syncronizeToolStripMenuItem";
			this.syncronizeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.syncronizeToolStripMenuItem.Text = "Syncroni&ze";
			this.syncronizeToolStripMenuItem.Click += new System.EventHandler(this.DatabaseSyncronize);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeyDisplayString = "";
			this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.MainFormClose);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.undoToolStripMenuItem,
			this.redoToolStripMenuItem,
			this.toolStripSeparator3,
			this.cutToolStripMenuItem,
			this.copyToolStripMenuItem,
			this.pasteToolStripMenuItem,
			this.toolStripSeparator4,
			this.selectAllToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "&Edit";
			// 
			// undoToolStripMenuItem
			// 
			this.undoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("undoToolStripMenuItem.Image")));
			this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
			this.undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.undoToolStripMenuItem.Text = "&Undo";
			this.undoToolStripMenuItem.Click += new System.EventHandler(this.ActionUndo);
			// 
			// redoToolStripMenuItem
			// 
			this.redoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("redoToolStripMenuItem.Image")));
			this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
			this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
			this.redoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.redoToolStripMenuItem.Text = "&Redo";
			this.redoToolStripMenuItem.Click += new System.EventHandler(this.ActionRedo);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
			// 
			// cutToolStripMenuItem
			// 
			this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
			this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
			this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.cutToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.cutToolStripMenuItem.Text = "Cu&t";
			this.cutToolStripMenuItem.Click += new System.EventHandler(this.SelectionCut);
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
			this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.copyToolStripMenuItem.Text = "&Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.SelectionCopy);
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
			this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.pasteToolStripMenuItem.Text = "&Paste";
			this.pasteToolStripMenuItem.Click += new System.EventHandler(this.SelectionPaste);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
			// 
			// selectAllToolStripMenuItem
			// 
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.selectAllToolStripMenuItem.Text = "Select &All";
			this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.ActionSelectAll);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.optionsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
			this.toolsToolStripMenuItem.Text = "&Tools";
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("optionsToolStripMenuItem.Image")));
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.optionsToolStripMenuItem.Text = "&Options";
			// 
			// MTS
			// 
			this.MTS.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.MTS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.BtnNewSheet,
			this.BtnOpenSheet,
			this.BtnPrintSheet,
			this.toolStripSeparator6,
			this.cutToolStripButton,
			this.copyToolStripButton,
			this.pasteToolStripButton});
			this.MTS.Location = new System.Drawing.Point(0, 24);
			this.MTS.Name = "MTS";
			this.MTS.Size = new System.Drawing.Size(789, 39);
			this.MTS.TabIndex = 2;
			this.MTS.Text = "toolStrip1";
			// 
			// BtnNewSheet
			// 
			this.BtnNewSheet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnNewSheet.Image = ((System.Drawing.Image)(resources.GetObject("BtnNewSheet.Image")));
			this.BtnNewSheet.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnNewSheet.Name = "BtnNewSheet";
			this.BtnNewSheet.Size = new System.Drawing.Size(36, 36);
			this.BtnNewSheet.Text = "&New";
			this.BtnNewSheet.Click += new System.EventHandler(this.DocumentCreate);
			// 
			// BtnOpenSheet
			// 
			this.BtnOpenSheet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnOpenSheet.Image = ((System.Drawing.Image)(resources.GetObject("BtnOpenSheet.Image")));
			this.BtnOpenSheet.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnOpenSheet.Name = "BtnOpenSheet";
			this.BtnOpenSheet.Size = new System.Drawing.Size(36, 36);
			this.BtnOpenSheet.Text = "&Open";
			this.BtnOpenSheet.Click += new System.EventHandler(this.DocumentOpen);
			// 
			// BtnPrintSheet
			// 
			this.BtnPrintSheet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnPrintSheet.Enabled = false;
			this.BtnPrintSheet.Image = ((System.Drawing.Image)(resources.GetObject("BtnPrintSheet.Image")));
			this.BtnPrintSheet.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnPrintSheet.Name = "BtnPrintSheet";
			this.BtnPrintSheet.Size = new System.Drawing.Size(36, 36);
			this.BtnPrintSheet.Text = "&Print";
			this.BtnPrintSheet.Click += new System.EventHandler(this.DocumentPrint);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 39);
			// 
			// cutToolStripButton
			// 
			this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
			this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cutToolStripButton.Name = "cutToolStripButton";
			this.cutToolStripButton.Size = new System.Drawing.Size(36, 36);
			this.cutToolStripButton.Text = "C&ut";
			this.cutToolStripButton.Click += new System.EventHandler(this.SelectionCut);
			// 
			// copyToolStripButton
			// 
			this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
			this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.copyToolStripButton.Name = "copyToolStripButton";
			this.copyToolStripButton.Size = new System.Drawing.Size(36, 36);
			this.copyToolStripButton.Text = "&Copy";
			this.copyToolStripButton.Click += new System.EventHandler(this.SelectionCopy);
			// 
			// pasteToolStripButton
			// 
			this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
			this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.pasteToolStripButton.Name = "pasteToolStripButton";
			this.pasteToolStripButton.Size = new System.Drawing.Size(36, 36);
			this.pasteToolStripButton.Text = "&Paste";
			this.pasteToolStripButton.Click += new System.EventHandler(this.SelectionPaste);
			// 
			// DP
			// 
			this.DP.BackColor = System.Drawing.SystemColors.Control;
			this.DP.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DP.Location = new System.Drawing.Point(0, 63);
			this.DP.Name = "DP";
			this.DP.Size = new System.Drawing.Size(789, 426);
			dockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight;
			dockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight;
			autoHideStripSkin1.DockStripGradient = dockPanelGradient1;
			tabGradient1.EndColor = System.Drawing.SystemColors.Control;
			tabGradient1.StartColor = System.Drawing.SystemColors.Control;
			tabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark;
			autoHideStripSkin1.TabGradient = tabGradient1;
			autoHideStripSkin1.TextFont = new System.Drawing.Font("Segoe UI", 9F);
			dockPanelSkin1.AutoHideStripSkin = autoHideStripSkin1;
			tabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight;
			tabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight;
			tabGradient2.TextColor = System.Drawing.SystemColors.ControlText;
			dockPaneStripGradient1.ActiveTabGradient = tabGradient2;
			dockPanelGradient2.EndColor = System.Drawing.SystemColors.Control;
			dockPanelGradient2.StartColor = System.Drawing.SystemColors.Control;
			dockPaneStripGradient1.DockStripGradient = dockPanelGradient2;
			tabGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
			tabGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
			tabGradient3.TextColor = System.Drawing.SystemColors.ControlText;
			dockPaneStripGradient1.InactiveTabGradient = tabGradient3;
			dockPaneStripSkin1.DocumentGradient = dockPaneStripGradient1;
			dockPaneStripSkin1.TextFont = new System.Drawing.Font("Segoe UI", 9F);
			tabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption;
			tabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			tabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
			tabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
			dockPaneStripToolWindowGradient1.ActiveCaptionGradient = tabGradient4;
			tabGradient5.EndColor = System.Drawing.SystemColors.Control;
			tabGradient5.StartColor = System.Drawing.SystemColors.Control;
			tabGradient5.TextColor = System.Drawing.SystemColors.ControlText;
			dockPaneStripToolWindowGradient1.ActiveTabGradient = tabGradient5;
			dockPanelGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
			dockPanelGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
			dockPaneStripToolWindowGradient1.DockStripGradient = dockPanelGradient3;
			tabGradient6.EndColor = System.Drawing.SystemColors.InactiveCaption;
			tabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			tabGradient6.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
			tabGradient6.TextColor = System.Drawing.SystemColors.InactiveCaptionText;
			dockPaneStripToolWindowGradient1.InactiveCaptionGradient = tabGradient6;
			tabGradient7.EndColor = System.Drawing.Color.Transparent;
			tabGradient7.StartColor = System.Drawing.Color.Transparent;
			tabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark;
			dockPaneStripToolWindowGradient1.InactiveTabGradient = tabGradient7;
			dockPaneStripSkin1.ToolWindowGradient = dockPaneStripToolWindowGradient1;
			dockPanelSkin1.DockPaneStripSkin = dockPaneStripSkin1;
			this.DP.Skin = dockPanelSkin1;
			this.DP.TabIndex = 4;
			this.DP.ActiveDocumentChanged += new System.EventHandler(this.OnActiveDocumentChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(789, 511);
			this.Controls.Add(this.DP);
			this.Controls.Add(this.MTS);
			this.Controls.Add(this.MSS);
			this.Controls.Add(this.MMS);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.MMS;
			this.Name = "MainForm";
			this.Text = "BG3 ChordPro Editor";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.MMS.ResumeLayout(false);
			this.MMS.PerformLayout();
			this.MTS.ResumeLayout(false);
			this.MTS.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private System.Windows.Forms.ToolStripMenuItem syncronizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private UserControls.DockingManager.DockPanel DP;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
	}
}
