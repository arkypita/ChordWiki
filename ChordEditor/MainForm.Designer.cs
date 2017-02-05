﻿/*
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
				private System.Windows.Forms.ToolTip MTT;
				private System.Windows.Forms.ToolStripButton BtnNewSheet;
				private System.Windows.Forms.ToolStripButton BtnOpenSheet;

				/// <summary>
				/// Disposes resources used by the form.
				/// </summary>
				/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
				protected override void Dispose(bool disposing)
				{
						if (disposing)
						{
								if (components != null)
								{
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
						ChordEditor.UserControls.DockingManager.DockPanelSkin dockPanelSkin2 = new ChordEditor.UserControls.DockingManager.DockPanelSkin();
						ChordEditor.UserControls.DockingManager.AutoHideStripSkin autoHideStripSkin2 = new ChordEditor.UserControls.DockingManager.AutoHideStripSkin();
						ChordEditor.UserControls.DockingManager.DockPanelGradient dockPanelGradient4 = new ChordEditor.UserControls.DockingManager.DockPanelGradient();
						ChordEditor.UserControls.DockingManager.TabGradient tabGradient8 = new ChordEditor.UserControls.DockingManager.TabGradient();
						ChordEditor.UserControls.DockingManager.DockPaneStripSkin dockPaneStripSkin2 = new ChordEditor.UserControls.DockingManager.DockPaneStripSkin();
						ChordEditor.UserControls.DockingManager.DockPaneStripGradient dockPaneStripGradient2 = new ChordEditor.UserControls.DockingManager.DockPaneStripGradient();
						ChordEditor.UserControls.DockingManager.TabGradient tabGradient9 = new ChordEditor.UserControls.DockingManager.TabGradient();
						ChordEditor.UserControls.DockingManager.DockPanelGradient dockPanelGradient5 = new ChordEditor.UserControls.DockingManager.DockPanelGradient();
						ChordEditor.UserControls.DockingManager.TabGradient tabGradient10 = new ChordEditor.UserControls.DockingManager.TabGradient();
						ChordEditor.UserControls.DockingManager.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient2 = new ChordEditor.UserControls.DockingManager.DockPaneStripToolWindowGradient();
						ChordEditor.UserControls.DockingManager.TabGradient tabGradient11 = new ChordEditor.UserControls.DockingManager.TabGradient();
						ChordEditor.UserControls.DockingManager.TabGradient tabGradient12 = new ChordEditor.UserControls.DockingManager.TabGradient();
						ChordEditor.UserControls.DockingManager.DockPanelGradient dockPanelGradient6 = new ChordEditor.UserControls.DockingManager.DockPanelGradient();
						ChordEditor.UserControls.DockingManager.TabGradient tabGradient13 = new ChordEditor.UserControls.DockingManager.TabGradient();
						ChordEditor.UserControls.DockingManager.TabGradient tabGradient14 = new ChordEditor.UserControls.DockingManager.TabGradient();
						this.MSS = new System.Windows.Forms.StatusStrip();
						this.MMS = new System.Windows.Forms.MenuStrip();
						this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
						this.MnNewSheet = new System.Windows.Forms.ToolStripMenuItem();
						this.MnOpenSheet = new System.Windows.Forms.ToolStripMenuItem();
						this.MnCloseSheet = new System.Windows.Forms.ToolStripMenuItem();
						this.MnCloseAll = new System.Windows.Forms.ToolStripMenuItem();
						this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
						this.MnImport = new System.Windows.Forms.ToolStripMenuItem();
						this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
						this.MnSaveSheet = new System.Windows.Forms.ToolStripMenuItem();
						this.MnSaveAll = new System.Windows.Forms.ToolStripMenuItem();
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
						this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
						this.MMnCleanup = new System.Windows.Forms.ToolStripMenuItem();
						this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
						this.MnExit = new System.Windows.Forms.ToolStripMenuItem();
						this.MTS = new System.Windows.Forms.ToolStrip();
						this.BtnSyncronize = new System.Windows.Forms.ToolStripSplitButton();
						this.MnFullSync = new System.Windows.Forms.ToolStripMenuItem();
						this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
						this.MnDownloadOnly = new System.Windows.Forms.ToolStripMenuItem();
						this.MnUploadOnly = new System.Windows.Forms.ToolStripMenuItem();
						this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
						this.MnRevert = new System.Windows.Forms.ToolStripMenuItem();
						this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
						this.MnCleanup = new System.Windows.Forms.ToolStripMenuItem();
						this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
						this.BtnOpenSheet = new System.Windows.Forms.ToolStripButton();
						this.BtnNewSheet = new System.Windows.Forms.ToolStripButton();
						this.MTT = new System.Windows.Forms.ToolTip(this.components);
						this.ET = new System.Windows.Forms.Timer(this.components);
						this.VCAT = new System.Windows.Forms.Timer(this.components);
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
            this.fileToolStripMenuItem});
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
            this.MnCloseAll,
            this.toolStripMenuItem8,
            this.MnImport,
            this.toolStripSeparator,
            this.MnSaveSheet,
            this.MnSaveAll,
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
						// MnCloseAll
						// 
						this.MnCloseAll.Image = ((System.Drawing.Image)(resources.GetObject("MnCloseAll.Image")));
						this.MnCloseAll.Name = "MnCloseAll";
						this.MnCloseAll.Size = new System.Drawing.Size(157, 22);
						this.MnCloseAll.Text = "Close All";
						this.MnCloseAll.Click += new System.EventHandler(this.MnCloseAll_Click);
						// 
						// toolStripMenuItem8
						// 
						this.toolStripMenuItem8.Name = "toolStripMenuItem8";
						this.toolStripMenuItem8.Size = new System.Drawing.Size(154, 6);
						// 
						// MnImport
						// 
						this.MnImport.Image = ((System.Drawing.Image)(resources.GetObject("MnImport.Image")));
						this.MnImport.Name = "MnImport";
						this.MnImport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
						this.MnImport.Size = new System.Drawing.Size(157, 22);
						this.MnImport.Text = "Import";
						this.MnImport.Click += new System.EventHandler(this.MnImport_Click);
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
						// MnSaveAll
						// 
						this.MnSaveAll.Image = ((System.Drawing.Image)(resources.GetObject("MnSaveAll.Image")));
						this.MnSaveAll.Name = "MnSaveAll";
						this.MnSaveAll.Size = new System.Drawing.Size(157, 22);
						this.MnSaveAll.Text = "Save All";
						this.MnSaveAll.Click += new System.EventHandler(this.MnSaveAll_Click);
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
            this.MMnRevert,
            this.toolStripMenuItem7,
            this.MMnCleanup});
						this.MnSyncronize.Image = ((System.Drawing.Image)(resources.GetObject("MnSyncronize.Image")));
						this.MnSyncronize.Name = "MnSyncronize";
						this.MnSyncronize.Size = new System.Drawing.Size(157, 22);
						this.MnSyncronize.Text = "Syncroni&ze";
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
						// toolStripMenuItem7
						// 
						this.toolStripMenuItem7.Name = "toolStripMenuItem7";
						this.toolStripMenuItem7.Size = new System.Drawing.Size(190, 6);
						// 
						// MMnCleanup
						// 
						this.MMnCleanup.Image = ((System.Drawing.Image)(resources.GetObject("MMnCleanup.Image")));
						this.MMnCleanup.Name = "MMnCleanup";
						this.MMnCleanup.Size = new System.Drawing.Size(193, 22);
						this.MMnCleanup.Text = "Cleanup!";
						this.MMnCleanup.Click += new System.EventHandler(this.DatabaseCleanup);
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
						// MTS
						// 
						this.MTS.ImageScalingSize = new System.Drawing.Size(32, 32);
						this.MTS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnSyncronize,
            this.toolStripSeparator5,
            this.BtnOpenSheet,
            this.BtnNewSheet});
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
            this.MnRevert,
            this.toolStripMenuItem6,
            this.MnCleanup});
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
						// toolStripMenuItem6
						// 
						this.toolStripMenuItem6.Name = "toolStripMenuItem6";
						this.toolStripMenuItem6.Size = new System.Drawing.Size(190, 6);
						// 
						// MnCleanup
						// 
						this.MnCleanup.Image = ((System.Drawing.Image)(resources.GetObject("MnCleanup.Image")));
						this.MnCleanup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
						this.MnCleanup.Name = "MnCleanup";
						this.MnCleanup.Size = new System.Drawing.Size(193, 22);
						this.MnCleanup.Text = "Cleanup!";
						this.MnCleanup.Click += new System.EventHandler(this.DatabaseCleanup);
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
						// ET
						// 
						this.ET.Enabled = true;
						this.ET.Interval = 400;
						// 
						// VCAT
						// 
						this.VCAT.Interval = 1000;
						this.VCAT.Tick += new System.EventHandler(this.VCAT_Tick);
						// 
						// DP
						// 
						this.DP.BackColor = System.Drawing.SystemColors.Control;
						this.DP.Dock = System.Windows.Forms.DockStyle.Fill;
						this.DP.Location = new System.Drawing.Point(0, 63);
						this.DP.Name = "DP";
						this.DP.Size = new System.Drawing.Size(789, 426);
						dockPanelGradient4.EndColor = System.Drawing.SystemColors.ControlLight;
						dockPanelGradient4.StartColor = System.Drawing.SystemColors.ControlLight;
						autoHideStripSkin2.DockStripGradient = dockPanelGradient4;
						tabGradient8.EndColor = System.Drawing.SystemColors.Control;
						tabGradient8.StartColor = System.Drawing.SystemColors.Control;
						tabGradient8.TextColor = System.Drawing.SystemColors.ControlDarkDark;
						autoHideStripSkin2.TabGradient = tabGradient8;
						autoHideStripSkin2.TextFont = new System.Drawing.Font("Segoe UI", 9F);
						dockPanelSkin2.AutoHideStripSkin = autoHideStripSkin2;
						tabGradient9.EndColor = System.Drawing.SystemColors.ControlLightLight;
						tabGradient9.StartColor = System.Drawing.SystemColors.ControlLightLight;
						tabGradient9.TextColor = System.Drawing.SystemColors.ControlText;
						dockPaneStripGradient2.ActiveTabGradient = tabGradient9;
						dockPanelGradient5.EndColor = System.Drawing.SystemColors.Control;
						dockPanelGradient5.StartColor = System.Drawing.SystemColors.Control;
						dockPaneStripGradient2.DockStripGradient = dockPanelGradient5;
						tabGradient10.EndColor = System.Drawing.SystemColors.ControlLight;
						tabGradient10.StartColor = System.Drawing.SystemColors.ControlLight;
						tabGradient10.TextColor = System.Drawing.SystemColors.ControlText;
						dockPaneStripGradient2.InactiveTabGradient = tabGradient10;
						dockPaneStripSkin2.DocumentGradient = dockPaneStripGradient2;
						dockPaneStripSkin2.TextFont = new System.Drawing.Font("Segoe UI", 9F);
						tabGradient11.EndColor = System.Drawing.SystemColors.ActiveCaption;
						tabGradient11.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
						tabGradient11.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
						tabGradient11.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
						dockPaneStripToolWindowGradient2.ActiveCaptionGradient = tabGradient11;
						tabGradient12.EndColor = System.Drawing.SystemColors.Control;
						tabGradient12.StartColor = System.Drawing.SystemColors.Control;
						tabGradient12.TextColor = System.Drawing.SystemColors.ControlText;
						dockPaneStripToolWindowGradient2.ActiveTabGradient = tabGradient12;
						dockPanelGradient6.EndColor = System.Drawing.SystemColors.ControlLight;
						dockPanelGradient6.StartColor = System.Drawing.SystemColors.ControlLight;
						dockPaneStripToolWindowGradient2.DockStripGradient = dockPanelGradient6;
						tabGradient13.EndColor = System.Drawing.SystemColors.InactiveCaption;
						tabGradient13.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
						tabGradient13.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
						tabGradient13.TextColor = System.Drawing.SystemColors.InactiveCaptionText;
						dockPaneStripToolWindowGradient2.InactiveCaptionGradient = tabGradient13;
						tabGradient14.EndColor = System.Drawing.Color.Transparent;
						tabGradient14.StartColor = System.Drawing.Color.Transparent;
						tabGradient14.TextColor = System.Drawing.SystemColors.ControlDarkDark;
						dockPaneStripToolWindowGradient2.InactiveTabGradient = tabGradient14;
						dockPaneStripSkin2.ToolWindowGradient = dockPaneStripToolWindowGradient2;
						dockPanelSkin2.DockPaneStripSkin = dockPaneStripSkin2;
						this.DP.Skin = dockPanelSkin2;
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
						this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
						this.Load += new System.EventHandler(this.MainForm_Load);
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
				private System.Windows.Forms.Timer VCAT;
				private System.Windows.Forms.ToolStripMenuItem MnCleanup;
				private System.Windows.Forms.ToolStripMenuItem MMnCleanup;
				private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
				private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
				private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
				private System.Windows.Forms.ToolStripMenuItem MnImport;
				private System.Windows.Forms.ToolStripMenuItem MnCloseAll;
				private System.Windows.Forms.ToolStripMenuItem MnSaveAll;
		}
}
