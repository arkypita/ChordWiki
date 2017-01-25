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
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.ToolStripMenuItem MnSaveSheet;
		private System.Windows.Forms.ToolStripMenuItem MnSaveAllSheet;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem MnPrintSheet;
		private System.Windows.Forms.ToolStripMenuItem MnPrintSheetPreview;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem MnExit;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem MnUndo;
		private System.Windows.Forms.ToolStripMenuItem MnRedo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem MnCut;
		private System.Windows.Forms.ToolStripMenuItem MnCopy;
		private System.Windows.Forms.ToolStripMenuItem MnPaste;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem MnSelectAll;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolTip MTT;
		private System.Windows.Forms.ToolStripButton BtnNewSheet;
		private System.Windows.Forms.ToolStripButton BtnOpenSheet;
		private System.Windows.Forms.ToolStripButton BtnSaveSheet;
		private System.Windows.Forms.ToolStripButton BtnPrintSheet;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripButton BtnCut;
		private System.Windows.Forms.ToolStripButton BtnCopy;
		private System.Windows.Forms.ToolStripButton BtnPaste;
		
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
			this.MnCloseSheet = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.MnSaveSheet = new System.Windows.Forms.ToolStripMenuItem();
			this.MnSaveAllSheet = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.MnPrintSheet = new System.Windows.Forms.ToolStripMenuItem();
			this.MnPrintSheetPreview = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.MnSyncronize = new System.Windows.Forms.ToolStripMenuItem();
			this.MMnFullSync = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.MMnDownloadOnly = new System.Windows.Forms.ToolStripMenuItem();
			this.MMnUploadOnly = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.MMnRevert = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.MnExit = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MnUndo = new System.Windows.Forms.ToolStripMenuItem();
			this.MnRedo = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.MnCut = new System.Windows.Forms.ToolStripMenuItem();
			this.MnCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.MnPaste = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.MnSelectAll = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MTS = new System.Windows.Forms.ToolStrip();
			this.BtnSyncronize = new System.Windows.Forms.ToolStripSplitButton();
			this.MnFullSync = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.MnDownloadOnly = new System.Windows.Forms.ToolStripMenuItem();
			this.MnUploadOnly = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.BtnOpenSheet = new System.Windows.Forms.ToolStripButton();
			this.BtnNewSheet = new System.Windows.Forms.ToolStripButton();
			this.BtnSaveSheet = new System.Windows.Forms.ToolStripButton();
			this.BtnPrintSheet = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.BtnCut = new System.Windows.Forms.ToolStripButton();
			this.BtnCopy = new System.Windows.Forms.ToolStripButton();
			this.BtnPaste = new System.Windows.Forms.ToolStripButton();
			this.MTT = new System.Windows.Forms.ToolTip(this.components);
			this.ET = new System.Windows.Forms.Timer(this.components);
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.MnRevert = new System.Windows.Forms.ToolStripMenuItem();
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
            this.MnCloseSheet,
            this.toolStripSeparator,
            this.MnSaveSheet,
            this.MnSaveAllSheet,
            this.toolStripSeparator1,
            this.MnPrintSheet,
            this.MnPrintSheetPreview,
            this.toolStripSeparator2,
            this.MnSyncronize,
            this.toolStripMenuItem1,
            this.MnExit});
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
			this.MnNewSheet.Size = new System.Drawing.Size(157, 22);
			this.MnNewSheet.Text = "&New";
			this.MnNewSheet.Click += new System.EventHandler(this.DocumentCreate);
			// 
			// MnOpenSheet
			// 
			this.MnOpenSheet.Image = ((System.Drawing.Image)(resources.GetObject("MnOpenSheet.Image")));
			this.MnOpenSheet.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MnOpenSheet.Name = "MnOpenSheet";
			this.MnOpenSheet.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.MnOpenSheet.Size = new System.Drawing.Size(157, 22);
			this.MnOpenSheet.Text = "&Open";
			this.MnOpenSheet.Click += new System.EventHandler(this.DocumentOpen);
			// 
			// MnCloseSheet
			// 
			this.MnCloseSheet.Enabled = false;
			this.MnCloseSheet.Image = ((System.Drawing.Image)(resources.GetObject("MnCloseSheet.Image")));
			this.MnCloseSheet.Name = "MnCloseSheet";
			this.MnCloseSheet.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
			this.MnCloseSheet.Size = new System.Drawing.Size(157, 22);
			this.MnCloseSheet.Text = "&Close";
			this.MnCloseSheet.Click += new System.EventHandler(this.DocumentClose);
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(154, 6);
			// 
			// MnSaveSheet
			// 
			this.MnSaveSheet.Enabled = false;
			this.MnSaveSheet.Image = ((System.Drawing.Image)(resources.GetObject("MnSaveSheet.Image")));
			this.MnSaveSheet.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MnSaveSheet.Name = "MnSaveSheet";
			this.MnSaveSheet.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.MnSaveSheet.Size = new System.Drawing.Size(157, 22);
			this.MnSaveSheet.Text = "&Save";
			this.MnSaveSheet.Click += new System.EventHandler(this.DocumentSave);
			// 
			// MnSaveAllSheet
			// 
			this.MnSaveAllSheet.Enabled = false;
			this.MnSaveAllSheet.Image = ((System.Drawing.Image)(resources.GetObject("MnSaveAllSheet.Image")));
			this.MnSaveAllSheet.Name = "MnSaveAllSheet";
			this.MnSaveAllSheet.Size = new System.Drawing.Size(157, 22);
			this.MnSaveAllSheet.Text = "Save &As";
			this.MnSaveAllSheet.Click += new System.EventHandler(this.DocumentSaveAs);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
			// 
			// MnPrintSheet
			// 
			this.MnPrintSheet.Enabled = false;
			this.MnPrintSheet.Image = ((System.Drawing.Image)(resources.GetObject("MnPrintSheet.Image")));
			this.MnPrintSheet.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MnPrintSheet.Name = "MnPrintSheet";
			this.MnPrintSheet.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.MnPrintSheet.Size = new System.Drawing.Size(157, 22);
			this.MnPrintSheet.Text = "&Print";
			this.MnPrintSheet.Click += new System.EventHandler(this.DocumentPrint);
			// 
			// MnPrintSheetPreview
			// 
			this.MnPrintSheetPreview.Enabled = false;
			this.MnPrintSheetPreview.Image = ((System.Drawing.Image)(resources.GetObject("MnPrintSheetPreview.Image")));
			this.MnPrintSheetPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MnPrintSheetPreview.Name = "MnPrintSheetPreview";
			this.MnPrintSheetPreview.Size = new System.Drawing.Size(157, 22);
			this.MnPrintSheetPreview.Text = "Print Pre&view";
			this.MnPrintSheetPreview.Click += new System.EventHandler(this.DocumentPrintPreview);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(154, 6);
			// 
			// MnSyncronize
			// 
			this.MnSyncronize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MMnFullSync,
            this.toolStripMenuItem3,
            this.MMnDownloadOnly,
            this.MMnUploadOnly,
            this.toolStripMenuItem4,
            this.MMnRevert});
			this.MnSyncronize.Image = ((System.Drawing.Image)(resources.GetObject("MnSyncronize.Image")));
			this.MnSyncronize.Name = "MnSyncronize";
			this.MnSyncronize.Size = new System.Drawing.Size(157, 22);
			this.MnSyncronize.Text = "Syncroni&ze";
			this.MnSyncronize.Click += new System.EventHandler(this.DatabaseSyncronize);
			// 
			// MMnFullSync
			// 
			this.MMnFullSync.Image = ((System.Drawing.Image)(resources.GetObject("MMnFullSync.Image")));
			this.MMnFullSync.Name = "MMnFullSync";
			this.MMnFullSync.Size = new System.Drawing.Size(193, 22);
			this.MMnFullSync.Text = "Syncronize all";
			this.MMnFullSync.Click += new System.EventHandler(this.DatabaseSyncronize);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(190, 6);
			// 
			// MMnDownloadOnly
			// 
			this.MMnDownloadOnly.Image = ((System.Drawing.Image)(resources.GetObject("MMnDownloadOnly.Image")));
			this.MMnDownloadOnly.Name = "MMnDownloadOnly";
			this.MMnDownloadOnly.Size = new System.Drawing.Size(193, 22);
			this.MMnDownloadOnly.Text = "Update from server";
			this.MMnDownloadOnly.Click += new System.EventHandler(this.DatabaseDownload);
			// 
			// MMnUploadOnly
			// 
			this.MMnUploadOnly.Image = ((System.Drawing.Image)(resources.GetObject("MMnUploadOnly.Image")));
			this.MMnUploadOnly.Name = "MMnUploadOnly";
			this.MMnUploadOnly.Size = new System.Drawing.Size(193, 22);
			this.MMnUploadOnly.Text = "Commit local changes";
			this.MMnUploadOnly.Click += new System.EventHandler(this.DatabaseUpload);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(190, 6);
			// 
			// MMnRevert
			// 
			this.MMnRevert.Image = ((System.Drawing.Image)(resources.GetObject("MMnRevert.Image")));
			this.MMnRevert.Name = "MMnRevert";
			this.MMnRevert.Size = new System.Drawing.Size(193, 22);
			this.MMnRevert.Text = "Revert all changes";
			this.MMnRevert.Click += new System.EventHandler(this.DatabaseRevert);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(154, 6);
			// 
			// MnExit
			// 
			this.MnExit.Image = ((System.Drawing.Image)(resources.GetObject("MnExit.Image")));
			this.MnExit.Name = "MnExit";
			this.MnExit.ShortcutKeyDisplayString = "";
			this.MnExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.MnExit.Size = new System.Drawing.Size(157, 22);
			this.MnExit.Text = "E&xit";
			this.MnExit.Click += new System.EventHandler(this.MainFormClose);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnUndo,
            this.MnRedo,
            this.toolStripSeparator3,
            this.MnCut,
            this.MnCopy,
            this.MnPaste,
            this.toolStripSeparator4,
            this.MnSelectAll});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "&Edit";
			// 
			// MnUndo
			// 
			this.MnUndo.Enabled = false;
			this.MnUndo.Image = ((System.Drawing.Image)(resources.GetObject("MnUndo.Image")));
			this.MnUndo.Name = "MnUndo";
			this.MnUndo.Size = new System.Drawing.Size(122, 22);
			this.MnUndo.Text = "&Undo";
			this.MnUndo.Click += new System.EventHandler(this.ActionUndo);
			// 
			// MnRedo
			// 
			this.MnRedo.Enabled = false;
			this.MnRedo.Image = ((System.Drawing.Image)(resources.GetObject("MnRedo.Image")));
			this.MnRedo.Name = "MnRedo";
			this.MnRedo.Size = new System.Drawing.Size(122, 22);
			this.MnRedo.Text = "&Redo";
			this.MnRedo.Click += new System.EventHandler(this.ActionRedo);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(119, 6);
			// 
			// MnCut
			// 
			this.MnCut.Enabled = false;
			this.MnCut.Image = ((System.Drawing.Image)(resources.GetObject("MnCut.Image")));
			this.MnCut.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MnCut.Name = "MnCut";
			this.MnCut.Size = new System.Drawing.Size(122, 22);
			this.MnCut.Text = "Cu&t";
			this.MnCut.Click += new System.EventHandler(this.SelectionCut);
			// 
			// MnCopy
			// 
			this.MnCopy.Enabled = false;
			this.MnCopy.Image = ((System.Drawing.Image)(resources.GetObject("MnCopy.Image")));
			this.MnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MnCopy.Name = "MnCopy";
			this.MnCopy.Size = new System.Drawing.Size(122, 22);
			this.MnCopy.Text = "&Copy";
			this.MnCopy.Click += new System.EventHandler(this.SelectionCopy);
			// 
			// MnPaste
			// 
			this.MnPaste.Enabled = false;
			this.MnPaste.Image = ((System.Drawing.Image)(resources.GetObject("MnPaste.Image")));
			this.MnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MnPaste.Name = "MnPaste";
			this.MnPaste.Size = new System.Drawing.Size(122, 22);
			this.MnPaste.Text = "&Paste";
			this.MnPaste.Click += new System.EventHandler(this.SelectionPaste);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(119, 6);
			// 
			// MnSelectAll
			// 
			this.MnSelectAll.Enabled = false;
			this.MnSelectAll.Name = "MnSelectAll";
			this.MnSelectAll.Size = new System.Drawing.Size(122, 22);
			this.MnSelectAll.Text = "Select &All";
			this.MnSelectAll.Click += new System.EventHandler(this.ActionSelectAll);
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
            this.BtnSyncronize,
            this.toolStripSeparator5,
            this.BtnOpenSheet,
            this.BtnNewSheet,
            this.BtnSaveSheet,
            this.BtnPrintSheet,
            this.toolStripSeparator6,
            this.BtnCut,
            this.BtnCopy,
            this.BtnPaste});
			this.MTS.Location = new System.Drawing.Point(0, 24);
			this.MTS.Name = "MTS";
			this.MTS.Size = new System.Drawing.Size(789, 39);
			this.MTS.TabIndex = 2;
			this.MTS.Text = "toolStrip1";
			// 
			// BtnSyncronize
			// 
			this.BtnSyncronize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnSyncronize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnFullSync,
            this.toolStripMenuItem2,
            this.MnDownloadOnly,
            this.MnUploadOnly,
            this.toolStripMenuItem5,
            this.MnRevert});
			this.BtnSyncronize.Image = ((System.Drawing.Image)(resources.GetObject("BtnSyncronize.Image")));
			this.BtnSyncronize.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnSyncronize.Name = "BtnSyncronize";
			this.BtnSyncronize.Size = new System.Drawing.Size(48, 36);
			this.BtnSyncronize.Text = "Syncroni&ze";
			this.BtnSyncronize.ToolTipText = "Syncronize";
			this.BtnSyncronize.ButtonClick += new System.EventHandler(this.DatabaseSyncronize);
			// 
			// MnFullSync
			// 
			this.MnFullSync.Image = ((System.Drawing.Image)(resources.GetObject("MnFullSync.Image")));
			this.MnFullSync.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.MnFullSync.Name = "MnFullSync";
			this.MnFullSync.Size = new System.Drawing.Size(193, 22);
			this.MnFullSync.Text = "Syncronize all";
			this.MnFullSync.Click += new System.EventHandler(this.DatabaseSyncronize);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(190, 6);
			// 
			// MnDownloadOnly
			// 
			this.MnDownloadOnly.Image = ((System.Drawing.Image)(resources.GetObject("MnDownloadOnly.Image")));
			this.MnDownloadOnly.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.MnDownloadOnly.Name = "MnDownloadOnly";
			this.MnDownloadOnly.Size = new System.Drawing.Size(193, 22);
			this.MnDownloadOnly.Text = "Update from server";
			this.MnDownloadOnly.Click += new System.EventHandler(this.DatabaseDownload);
			// 
			// MnUploadOnly
			// 
			this.MnUploadOnly.Image = ((System.Drawing.Image)(resources.GetObject("MnUploadOnly.Image")));
			this.MnUploadOnly.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.MnUploadOnly.Name = "MnUploadOnly";
			this.MnUploadOnly.Size = new System.Drawing.Size(193, 22);
			this.MnUploadOnly.Text = "Commit local changes";
			this.MnUploadOnly.Click += new System.EventHandler(this.DatabaseUpload);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
			// 
			// BtnOpenSheet
			// 
			this.BtnOpenSheet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnOpenSheet.Image = ((System.Drawing.Image)(resources.GetObject("BtnOpenSheet.Image")));
			this.BtnOpenSheet.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnOpenSheet.Name = "BtnOpenSheet";
			this.BtnOpenSheet.Size = new System.Drawing.Size(36, 36);
			this.BtnOpenSheet.Text = "&Open From Database";
			this.BtnOpenSheet.Click += new System.EventHandler(this.DocumentOpen);
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
			// BtnSaveSheet
			// 
			this.BtnSaveSheet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnSaveSheet.Enabled = false;
			this.BtnSaveSheet.Image = ((System.Drawing.Image)(resources.GetObject("BtnSaveSheet.Image")));
			this.BtnSaveSheet.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnSaveSheet.Name = "BtnSaveSheet";
			this.BtnSaveSheet.Size = new System.Drawing.Size(36, 36);
			this.BtnSaveSheet.Text = "&Save";
			this.BtnSaveSheet.Click += new System.EventHandler(this.DocumentSave);
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
			// BtnCut
			// 
			this.BtnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnCut.Enabled = false;
			this.BtnCut.Image = ((System.Drawing.Image)(resources.GetObject("BtnCut.Image")));
			this.BtnCut.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnCut.Name = "BtnCut";
			this.BtnCut.Size = new System.Drawing.Size(36, 36);
			this.BtnCut.Text = "C&ut";
			this.BtnCut.Click += new System.EventHandler(this.SelectionCut);
			// 
			// BtnCopy
			// 
			this.BtnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnCopy.Enabled = false;
			this.BtnCopy.Image = ((System.Drawing.Image)(resources.GetObject("BtnCopy.Image")));
			this.BtnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnCopy.Name = "BtnCopy";
			this.BtnCopy.Size = new System.Drawing.Size(36, 36);
			this.BtnCopy.Text = "&Copy";
			this.BtnCopy.Click += new System.EventHandler(this.SelectionCopy);
			// 
			// BtnPaste
			// 
			this.BtnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnPaste.Enabled = false;
			this.BtnPaste.Image = ((System.Drawing.Image)(resources.GetObject("BtnPaste.Image")));
			this.BtnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnPaste.Name = "BtnPaste";
			this.BtnPaste.Size = new System.Drawing.Size(36, 36);
			this.BtnPaste.Text = "&Paste";
			this.BtnPaste.Click += new System.EventHandler(this.SelectionPaste);
			// 
			// ET
			// 
			this.ET.Enabled = true;
			this.ET.Interval = 400;
			this.ET.Tick += new System.EventHandler(this.ET_Tick);
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(190, 6);
			// 
			// MnRevert
			// 
			this.MnRevert.Image = ((System.Drawing.Image)(resources.GetObject("MnRevert.Image")));
			this.MnRevert.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.MnRevert.Name = "MnRevert";
			this.MnRevert.Size = new System.Drawing.Size(193, 22);
			this.MnRevert.Text = "Revert all changes";
			this.MnRevert.Click += new System.EventHandler(this.DatabaseRevert);
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
			this.DP.ActiveDocumentChanged += new System.EventHandler(this.DP_ActiveDocumentChanged);
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

		private System.Windows.Forms.ToolStripMenuItem MnSyncronize;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private UserControls.DockingManager.DockPanel DP;
		private System.Windows.Forms.ToolStripMenuItem MnCloseSheet;
		private System.Windows.Forms.Timer ET;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripSplitButton BtnSyncronize;
		private System.Windows.Forms.ToolStripMenuItem MnFullSync;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem MnDownloadOnly;
		private System.Windows.Forms.ToolStripMenuItem MnUploadOnly;
        private System.Windows.Forms.ToolStripMenuItem MMnFullSync;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem MMnDownloadOnly;
        private System.Windows.Forms.ToolStripMenuItem MMnUploadOnly;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem MMnRevert;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
		private System.Windows.Forms.ToolStripMenuItem MnRevert;
	}
}
