namespace ChordEditor.Forms
{
	partial class SheetForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
						this.components = new System.ComponentModel.Container();
						System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SheetForm));
						this.CHP = new FastColoredTextBoxNS.FastColoredTextBox();
						this.CMS = new System.Windows.Forms.ContextMenuStrip(this.components);
						this.CMnChorus = new System.Windows.Forms.ToolStripMenuItem();
						this.CMnComment = new System.Windows.Forms.ToolStripMenuItem();
						this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
						this.CMnUndo = new System.Windows.Forms.ToolStripMenuItem();
						this.CMnRedo = new System.Windows.Forms.ToolStripMenuItem();
						this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
						this.CMnCut = new System.Windows.Forms.ToolStripMenuItem();
						this.CMnCopy = new System.Windows.Forms.ToolStripMenuItem();
						this.CMnPaste = new System.Windows.Forms.ToolStripMenuItem();
						this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
						this.CMnSelectAll = new System.Windows.Forms.ToolStripMenuItem();
						this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
						this.label1 = new System.Windows.Forms.Label();
						this.CbZoom = new System.Windows.Forms.ComboBox();
						this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
						this.SC = new System.Windows.Forms.SplitContainer();
						this.COT = new FastColoredTextBoxNS.FastColoredTextBox();
						this.FSW = new System.IO.FileSystemWatcher();
						this.VT = new System.Windows.Forms.Timer(this.components);
						this.RetryReload = new System.Windows.Forms.Timer(this.components);
						this.ACM = new AutocompleteMenuNS.AutocompleteMenu();
						this.IL = new System.Windows.Forms.ImageList(this.components);
						this.MMS = new System.Windows.Forms.MenuStrip();
						this.MMnFile = new System.Windows.Forms.ToolStripMenuItem();
						this.MMnClose = new System.Windows.Forms.ToolStripMenuItem();
						this.MMnSave = new System.Windows.Forms.ToolStripMenuItem();
						this.MnPrint = new System.Windows.Forms.ToolStripMenuItem();
						this.MMnEdit = new System.Windows.Forms.ToolStripMenuItem();
						this.MMnChorus = new System.Windows.Forms.ToolStripMenuItem();
						this.MMnComment = new System.Windows.Forms.ToolStripMenuItem();
						this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripSeparator();
						this.MMnUndo = new System.Windows.Forms.ToolStripMenuItem();
						this.MMnRedo = new System.Windows.Forms.ToolStripMenuItem();
						this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
						this.MMnCut = new System.Windows.Forms.ToolStripMenuItem();
						this.MMnCopy = new System.Windows.Forms.ToolStripMenuItem();
						this.MMnPaste = new System.Windows.Forms.ToolStripMenuItem();
						this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
						this.MMnSelectAll = new System.Windows.Forms.ToolStripMenuItem();
						this.MTS = new System.Windows.Forms.ToolStrip();
						this.BtnSave = new System.Windows.Forms.ToolStripButton();
						this.BtnPrint = new System.Windows.Forms.ToolStripButton();
						this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
						this.BtnCut = new System.Windows.Forms.ToolStripButton();
						this.BtnCopy = new System.Windows.Forms.ToolStripButton();
						this.BtnPaste = new System.Windows.Forms.ToolStripButton();
						this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
						this.BtnUndo = new System.Windows.Forms.ToolStripButton();
						this.BtnRedo = new System.Windows.Forms.ToolStripButton();
						this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
						this.BtnChorus = new System.Windows.Forms.ToolStripButton();
						this.BtnComment = new System.Windows.Forms.ToolStripButton();
						this.BtnCopyChord = new System.Windows.Forms.ToolStripButton();
						this.BtnPasteChord = new System.Windows.Forms.ToolStripButton();
						this.toolStripButton2 = new System.Windows.Forms.ToolStripSeparator();
						this.BtnTrashChord = new System.Windows.Forms.ToolStripButton();
						((System.ComponentModel.ISupportInitialize)(this.CHP)).BeginInit();
						this.CMS.SuspendLayout();
						this.tableLayoutPanel1.SuspendLayout();
						this.tableLayoutPanel2.SuspendLayout();
						((System.ComponentModel.ISupportInitialize)(this.SC)).BeginInit();
						this.SC.Panel1.SuspendLayout();
						this.SC.Panel2.SuspendLayout();
						this.SC.SuspendLayout();
						((System.ComponentModel.ISupportInitialize)(this.COT)).BeginInit();
						((System.ComponentModel.ISupportInitialize)(this.FSW)).BeginInit();
						this.MMS.SuspendLayout();
						this.MTS.SuspendLayout();
						this.SuspendLayout();
						// 
						// CHP
						// 
						this.CHP.AutoCompleteBracketsList = new char[] {
        '{',
        '}',
        '[',
        ']'};
						this.ACM.SetAutocompleteMenu(this.CHP, this.ACM);
						this.CHP.AutoIndent = false;
						this.CHP.AutoIndentChars = false;
						this.CHP.AutoIndentExistingLines = false;
						this.CHP.AutoScrollMinSize = new System.Drawing.Size(18, 30);
						this.CHP.BackBrush = null;
						this.CHP.CharHeight = 14;
						this.CHP.CharWidth = 8;
						this.CHP.CommentPrefix = "";
						this.CHP.ContextMenuStrip = this.CMS;
						this.CHP.Cursor = System.Windows.Forms.Cursors.IBeam;
						this.CHP.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
						this.CHP.Dock = System.Windows.Forms.DockStyle.Fill;
						this.CHP.Font = new System.Drawing.Font("Courier New", 9.75F);
						this.CHP.Hotkeys = resources.GetString("CHP.Hotkeys");
						this.CHP.IsReplaceMode = false;
						this.CHP.Location = new System.Drawing.Point(0, 0);
						this.CHP.Name = "CHP";
						this.CHP.Paddings = new System.Windows.Forms.Padding(8);
						this.CHP.PreferredLineWidth = 60;
						this.CHP.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(255)))));
						this.CHP.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("CHP.ServiceColors")));
						this.CHP.ShowLineNumbers = false;
						this.CHP.Size = new System.Drawing.Size(426, 471);
						this.CHP.TabIndex = 0;
						this.CHP.Zoom = 100;
						this.CHP.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.CHPTextChanged);
						this.CHP.Pasting += new System.EventHandler<FastColoredTextBoxNS.TextChangingEventArgs>(this.CHPPasting);
						this.CHP.SelectionChanged += new System.EventHandler(this.CHP_SelectionChanged);
						this.CHP.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.CHPTextChangedDelayed);
						this.CHP.SelectionChangedDelayed += new System.EventHandler(this.CHP_SelectionChangedDelayed);
						this.CHP.UndoRedoStateChanged += new System.EventHandler<System.EventArgs>(this.CHP_UndoRedoStateChanged);
						this.CHP.ZoomChanged += new System.EventHandler(this.CHPZoomChanged);
						this.CHP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CHP_MouseDown);
						// 
						// CMS
						// 
						this.CMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CMnChorus,
            this.CMnComment,
            this.toolStripMenuItem3,
            this.CMnUndo,
            this.CMnRedo,
            this.toolStripMenuItem1,
            this.CMnCut,
            this.CMnCopy,
            this.CMnPaste,
            this.toolStripMenuItem2,
            this.CMnSelectAll});
						this.CMS.Name = "CMS";
						this.CMS.Size = new System.Drawing.Size(172, 198);
						this.CMS.Opening += new System.ComponentModel.CancelEventHandler(this.CMS_Opening);
						// 
						// CMnChorus
						// 
						this.CMnChorus.Image = ((System.Drawing.Image)(resources.GetObject("CMnChorus.Image")));
						this.CMnChorus.Name = "CMnChorus";
						this.CMnChorus.Size = new System.Drawing.Size(171, 22);
						this.CMnChorus.Text = "Chorus";
						this.CMnChorus.Click += new System.EventHandler(this.ActionChorus);
						// 
						// CMnComment
						// 
						this.CMnComment.Image = ((System.Drawing.Image)(resources.GetObject("CMnComment.Image")));
						this.CMnComment.Name = "CMnComment";
						this.CMnComment.Size = new System.Drawing.Size(171, 22);
						this.CMnComment.Text = "Comment";
						this.CMnComment.Click += new System.EventHandler(this.ActionComment);
						// 
						// toolStripMenuItem3
						// 
						this.toolStripMenuItem3.Name = "toolStripMenuItem3";
						this.toolStripMenuItem3.Size = new System.Drawing.Size(168, 6);
						// 
						// CMnUndo
						// 
						this.CMnUndo.Image = ((System.Drawing.Image)(resources.GetObject("CMnUndo.Image")));
						this.CMnUndo.Name = "CMnUndo";
						this.CMnUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
						this.CMnUndo.Size = new System.Drawing.Size(171, 22);
						this.CMnUndo.Text = "Undo";
						this.CMnUndo.Click += new System.EventHandler(this.ActionUndo);
						// 
						// CMnRedo
						// 
						this.CMnRedo.Image = ((System.Drawing.Image)(resources.GetObject("CMnRedo.Image")));
						this.CMnRedo.Name = "CMnRedo";
						this.CMnRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
						this.CMnRedo.Size = new System.Drawing.Size(171, 22);
						this.CMnRedo.Text = "Redo";
						this.CMnRedo.Click += new System.EventHandler(this.ActionRedo);
						// 
						// toolStripMenuItem1
						// 
						this.toolStripMenuItem1.Name = "toolStripMenuItem1";
						this.toolStripMenuItem1.Size = new System.Drawing.Size(168, 6);
						// 
						// CMnCut
						// 
						this.CMnCut.Image = ((System.Drawing.Image)(resources.GetObject("CMnCut.Image")));
						this.CMnCut.Name = "CMnCut";
						this.CMnCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
						this.CMnCut.Size = new System.Drawing.Size(171, 22);
						this.CMnCut.Text = "Cut";
						this.CMnCut.Click += new System.EventHandler(this.SelectionCut);
						// 
						// CMnCopy
						// 
						this.CMnCopy.Image = ((System.Drawing.Image)(resources.GetObject("CMnCopy.Image")));
						this.CMnCopy.Name = "CMnCopy";
						this.CMnCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
						this.CMnCopy.Size = new System.Drawing.Size(171, 22);
						this.CMnCopy.Text = "Copy";
						this.CMnCopy.Click += new System.EventHandler(this.SelectionCopy);
						// 
						// CMnPaste
						// 
						this.CMnPaste.Image = ((System.Drawing.Image)(resources.GetObject("CMnPaste.Image")));
						this.CMnPaste.Name = "CMnPaste";
						this.CMnPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
						this.CMnPaste.Size = new System.Drawing.Size(171, 22);
						this.CMnPaste.Text = "Paste";
						this.CMnPaste.Click += new System.EventHandler(this.SelectionPaste);
						// 
						// toolStripMenuItem2
						// 
						this.toolStripMenuItem2.Name = "toolStripMenuItem2";
						this.toolStripMenuItem2.Size = new System.Drawing.Size(168, 6);
						// 
						// CMnSelectAll
						// 
						this.CMnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("CMnSelectAll.Image")));
						this.CMnSelectAll.Name = "CMnSelectAll";
						this.CMnSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
						this.CMnSelectAll.Size = new System.Drawing.Size(171, 22);
						this.CMnSelectAll.Text = "Select all";
						this.CMnSelectAll.Click += new System.EventHandler(this.ActionSelectAll);
						// 
						// tableLayoutPanel1
						// 
						this.tableLayoutPanel1.AutoSize = true;
						this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
						this.tableLayoutPanel1.ColumnCount = 3;
						this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
						this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
						this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
						this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
						this.tableLayoutPanel1.Controls.Add(this.CbZoom, 1, 0);
						this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
						this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 476);
						this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
						this.tableLayoutPanel1.Name = "tableLayoutPanel1";
						this.tableLayoutPanel1.RowCount = 1;
						this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
						this.tableLayoutPanel1.Size = new System.Drawing.Size(870, 27);
						this.tableLayoutPanel1.TabIndex = 1;
						// 
						// label1
						// 
						this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
						this.label1.AutoSize = true;
						this.label1.Location = new System.Drawing.Point(3, 7);
						this.label1.Name = "label1";
						this.label1.Size = new System.Drawing.Size(34, 13);
						this.label1.TabIndex = 0;
						this.label1.Text = "Zoom";
						// 
						// CbZoom
						// 
						this.CbZoom.Anchor = System.Windows.Forms.AnchorStyles.Left;
						this.CbZoom.FormattingEnabled = true;
						this.CbZoom.Location = new System.Drawing.Point(43, 3);
						this.CbZoom.Name = "CbZoom";
						this.CbZoom.Size = new System.Drawing.Size(62, 21);
						this.CbZoom.TabIndex = 1;
						this.CbZoom.SelectedIndexChanged += new System.EventHandler(this.CbZoom_SelectedIndexChanged);
						this.CbZoom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CbZoom_KeyDown);
						this.CbZoom.Validating += new System.ComponentModel.CancelEventHandler(this.CbZoom_Validating);
						// 
						// tableLayoutPanel2
						// 
						this.tableLayoutPanel2.ColumnCount = 1;
						this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
						this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 1);
						this.tableLayoutPanel2.Controls.Add(this.SC, 0, 0);
						this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
						this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
						this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
						this.tableLayoutPanel2.Name = "tableLayoutPanel2";
						this.tableLayoutPanel2.RowCount = 2;
						this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
						this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
						this.tableLayoutPanel2.Size = new System.Drawing.Size(870, 503);
						this.tableLayoutPanel2.TabIndex = 2;
						// 
						// SC
						// 
						this.SC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
						this.SC.Dock = System.Windows.Forms.DockStyle.Fill;
						this.SC.Location = new System.Drawing.Point(3, 3);
						this.SC.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
						this.SC.Name = "SC";
						// 
						// SC.Panel1
						// 
						this.SC.Panel1.Controls.Add(this.CHP);
						this.SC.Panel1MinSize = 50;
						// 
						// SC.Panel2
						// 
						this.SC.Panel2.Controls.Add(this.COT);
						this.SC.Panel2MinSize = 0;
						this.SC.Size = new System.Drawing.Size(864, 473);
						this.SC.SplitterDistance = 428;
						this.SC.TabIndex = 2;
						// 
						// COT
						// 
						this.COT.AutoCompleteBracketsList = new char[] {
        '{',
        '}',
        '[',
        ']'};
						this.ACM.SetAutocompleteMenu(this.COT, this.ACM);
						this.COT.AutoIndent = false;
						this.COT.AutoIndentChars = false;
						this.COT.AutoIndentExistingLines = false;
						this.COT.AutoScrollMinSize = new System.Drawing.Size(18, 30);
						this.COT.BackBrush = null;
						this.COT.CaretVisible = false;
						this.COT.CharHeight = 14;
						this.COT.CharWidth = 8;
						this.COT.CommentPrefix = "";
						this.COT.Cursor = System.Windows.Forms.Cursors.Arrow;
						this.COT.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
						this.COT.Dock = System.Windows.Forms.DockStyle.Fill;
						this.COT.Hotkeys = resources.GetString("COT.Hotkeys");
						this.COT.IsReplaceMode = false;
						this.COT.Location = new System.Drawing.Point(0, 0);
						this.COT.Name = "COT";
						this.COT.Paddings = new System.Windows.Forms.Padding(8);
						this.COT.PreferredLineWidth = 60;
						this.COT.ReadOnly = true;
						this.COT.SelectionColor = System.Drawing.Color.Transparent;
						this.COT.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("COT.ServiceColors")));
						this.COT.ShowLineNumbers = false;
						this.COT.Size = new System.Drawing.Size(430, 471);
						this.COT.TabIndex = 1;
						this.COT.Zoom = 100;
						// 
						// FSW
						// 
						this.FSW.EnableRaisingEvents = true;
						this.FSW.SynchronizingObject = this;
						this.FSW.Changed += new System.IO.FileSystemEventHandler(this.FSW_Changed);
						this.FSW.Created += new System.IO.FileSystemEventHandler(this.FSW_Created);
						this.FSW.Deleted += new System.IO.FileSystemEventHandler(this.FSW_Deleted);
						// 
						// VT
						// 
						this.VT.Interval = 500;
						this.VT.Tick += new System.EventHandler(this.VT_Tick);
						// 
						// RetryReload
						// 
						this.RetryReload.Interval = 500;
						this.RetryReload.Tick += new System.EventHandler(this.RetryReload_Tick);
						// 
						// ACM
						// 
						this.ACM.AllowsTabKey = true;
						this.ACM.AppearInterval = 100;
						this.ACM.Colors = ((AutocompleteMenuNS.Colors)(resources.GetObject("ACM.Colors")));
						this.ACM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
						this.ACM.ImageList = this.IL;
						this.ACM.Items = new string[0];
						this.ACM.MinFragmentLength = 1;
						this.ACM.SearchPattern = "\\[[[a-zA-Z]*#?\\-?[0-9]{0,2}\\+?\\]?";
						this.ACM.TargetControlWrapper = null;
						// 
						// IL
						// 
						this.IL.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IL.ImageStream")));
						this.IL.TransparentColor = System.Drawing.Color.Transparent;
						this.IL.Images.SetKeyName(0, "musical-note.png");
						// 
						// MMS
						// 
						this.MMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MMnFile,
            this.MMnEdit});
						this.MMS.Location = new System.Drawing.Point(0, 0);
						this.MMS.Name = "MMS";
						this.MMS.Size = new System.Drawing.Size(870, 24);
						this.MMS.TabIndex = 3;
						this.MMS.Text = "menuStrip1";
						this.MMS.Visible = false;
						// 
						// MMnFile
						// 
						this.MMnFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MMnClose,
            this.MMnSave,
            this.MnPrint});
						this.MMnFile.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
						this.MMnFile.Name = "MMnFile";
						this.MMnFile.Size = new System.Drawing.Size(37, 20);
						this.MMnFile.Text = "&File";
						// 
						// MMnClose
						// 
						this.MMnClose.Image = ((System.Drawing.Image)(resources.GetObject("MMnClose.Image")));
						this.MMnClose.MergeAction = System.Windows.Forms.MergeAction.Insert;
						this.MMnClose.MergeIndex = 2;
						this.MMnClose.Name = "MMnClose";
						this.MMnClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
						this.MMnClose.Size = new System.Drawing.Size(157, 22);
						this.MMnClose.Text = "&Close";
						this.MMnClose.Click += new System.EventHandler(this.ActionClose);
						// 
						// MMnSave
						// 
						this.MMnSave.Enabled = false;
						this.MMnSave.Image = ((System.Drawing.Image)(resources.GetObject("MMnSave.Image")));
						this.MMnSave.MergeAction = System.Windows.Forms.MergeAction.Insert;
						this.MMnSave.MergeIndex = 7;
						this.MMnSave.Name = "MMnSave";
						this.MMnSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
						this.MMnSave.Size = new System.Drawing.Size(157, 22);
						this.MMnSave.Text = "&Save";
						this.MMnSave.Click += new System.EventHandler(this.ActionSave);
						// 
						// MnPrint
						// 
						this.MnPrint.Image = ((System.Drawing.Image)(resources.GetObject("MnPrint.Image")));
						this.MnPrint.MergeAction = System.Windows.Forms.MergeAction.Insert;
						this.MnPrint.MergeIndex = 9;
						this.MnPrint.Name = "MnPrint";
						this.MnPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
						this.MnPrint.Size = new System.Drawing.Size(157, 22);
						this.MnPrint.Text = "&Print";
						this.MnPrint.Click += new System.EventHandler(this.ActionPrint);
						// 
						// MMnEdit
						// 
						this.MMnEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MMnChorus,
            this.MMnComment,
            this.toolStripMenuItem13,
            this.MMnUndo,
            this.MMnRedo,
            this.toolStripMenuItem9,
            this.MMnCut,
            this.MMnCopy,
            this.MMnPaste,
            this.toolStripMenuItem6,
            this.MMnSelectAll});
						this.MMnEdit.Name = "MMnEdit";
						this.MMnEdit.Size = new System.Drawing.Size(39, 20);
						this.MMnEdit.Text = "&Edit";
						this.MMnEdit.DropDownOpening += new System.EventHandler(this.MMnEdit_DropDownOpening);
						// 
						// MMnChorus
						// 
						this.MMnChorus.Image = ((System.Drawing.Image)(resources.GetObject("MMnChorus.Image")));
						this.MMnChorus.Name = "MMnChorus";
						this.MMnChorus.Size = new System.Drawing.Size(128, 22);
						this.MMnChorus.Text = "Chorus";
						this.MMnChorus.Click += new System.EventHandler(this.ActionChorus);
						// 
						// MMnComment
						// 
						this.MMnComment.Image = ((System.Drawing.Image)(resources.GetObject("MMnComment.Image")));
						this.MMnComment.Name = "MMnComment";
						this.MMnComment.Size = new System.Drawing.Size(128, 22);
						this.MMnComment.Text = "Comment";
						this.MMnComment.Click += new System.EventHandler(this.ActionComment);
						// 
						// toolStripMenuItem13
						// 
						this.toolStripMenuItem13.Name = "toolStripMenuItem13";
						this.toolStripMenuItem13.Size = new System.Drawing.Size(125, 6);
						// 
						// MMnUndo
						// 
						this.MMnUndo.Image = ((System.Drawing.Image)(resources.GetObject("MMnUndo.Image")));
						this.MMnUndo.Name = "MMnUndo";
						this.MMnUndo.Size = new System.Drawing.Size(128, 22);
						this.MMnUndo.Text = "Undo";
						this.MMnUndo.Click += new System.EventHandler(this.ActionUndo);
						// 
						// MMnRedo
						// 
						this.MMnRedo.Image = ((System.Drawing.Image)(resources.GetObject("MMnRedo.Image")));
						this.MMnRedo.Name = "MMnRedo";
						this.MMnRedo.Size = new System.Drawing.Size(128, 22);
						this.MMnRedo.Text = "Redo";
						this.MMnRedo.Click += new System.EventHandler(this.ActionRedo);
						// 
						// toolStripMenuItem9
						// 
						this.toolStripMenuItem9.Name = "toolStripMenuItem9";
						this.toolStripMenuItem9.Size = new System.Drawing.Size(125, 6);
						// 
						// MMnCut
						// 
						this.MMnCut.Image = ((System.Drawing.Image)(resources.GetObject("MMnCut.Image")));
						this.MMnCut.Name = "MMnCut";
						this.MMnCut.Size = new System.Drawing.Size(128, 22);
						this.MMnCut.Text = "Cut";
						this.MMnCut.Click += new System.EventHandler(this.SelectionCut);
						// 
						// MMnCopy
						// 
						this.MMnCopy.Image = ((System.Drawing.Image)(resources.GetObject("MMnCopy.Image")));
						this.MMnCopy.Name = "MMnCopy";
						this.MMnCopy.Size = new System.Drawing.Size(128, 22);
						this.MMnCopy.Text = "Copy";
						this.MMnCopy.Click += new System.EventHandler(this.SelectionCopy);
						// 
						// MMnPaste
						// 
						this.MMnPaste.Image = ((System.Drawing.Image)(resources.GetObject("MMnPaste.Image")));
						this.MMnPaste.Name = "MMnPaste";
						this.MMnPaste.Size = new System.Drawing.Size(128, 22);
						this.MMnPaste.Text = "Paste";
						this.MMnPaste.Click += new System.EventHandler(this.SelectionPaste);
						// 
						// toolStripMenuItem6
						// 
						this.toolStripMenuItem6.Name = "toolStripMenuItem6";
						this.toolStripMenuItem6.Size = new System.Drawing.Size(125, 6);
						// 
						// MMnSelectAll
						// 
						this.MMnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("MMnSelectAll.Image")));
						this.MMnSelectAll.Name = "MMnSelectAll";
						this.MMnSelectAll.Size = new System.Drawing.Size(128, 22);
						this.MMnSelectAll.Text = "Select all";
						this.MMnSelectAll.Click += new System.EventHandler(this.ActionSelectAll);
						// 
						// MTS
						// 
						this.MTS.ImageScalingSize = new System.Drawing.Size(32, 32);
						this.MTS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnSave,
            this.BtnPrint,
            this.toolStripSeparator6,
            this.BtnCut,
            this.BtnCopy,
            this.BtnPaste,
            this.toolStripButton1,
            this.BtnUndo,
            this.BtnRedo,
            this.toolStripSeparator1,
            this.BtnChorus,
            this.BtnComment,
            this.BtnCopyChord,
            this.BtnPasteChord,
            this.toolStripButton2,
            this.BtnTrashChord});
						this.MTS.Location = new System.Drawing.Point(0, 0);
						this.MTS.Name = "MTS";
						this.MTS.Size = new System.Drawing.Size(870, 39);
						this.MTS.TabIndex = 4;
						this.MTS.Text = "toolStrip1";
						this.MTS.Visible = false;
						// 
						// BtnSave
						// 
						this.BtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
						this.BtnSave.Enabled = false;
						this.BtnSave.Image = ((System.Drawing.Image)(resources.GetObject("BtnSave.Image")));
						this.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
						this.BtnSave.Name = "BtnSave";
						this.BtnSave.Size = new System.Drawing.Size(36, 36);
						this.BtnSave.Text = "&Save";
						this.BtnSave.Click += new System.EventHandler(this.ActionSave);
						// 
						// BtnPrint
						// 
						this.BtnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
						this.BtnPrint.Image = ((System.Drawing.Image)(resources.GetObject("BtnPrint.Image")));
						this.BtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
						this.BtnPrint.Name = "BtnPrint";
						this.BtnPrint.Size = new System.Drawing.Size(36, 36);
						this.BtnPrint.Text = "&Print";
						this.BtnPrint.Click += new System.EventHandler(this.ActionPrint);
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
						this.BtnPaste.Image = ((System.Drawing.Image)(resources.GetObject("BtnPaste.Image")));
						this.BtnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
						this.BtnPaste.Name = "BtnPaste";
						this.BtnPaste.Size = new System.Drawing.Size(36, 36);
						this.BtnPaste.Text = "&Paste";
						this.BtnPaste.Click += new System.EventHandler(this.SelectionPaste);
						// 
						// toolStripButton1
						// 
						this.toolStripButton1.Name = "toolStripButton1";
						this.toolStripButton1.Size = new System.Drawing.Size(6, 39);
						// 
						// BtnUndo
						// 
						this.BtnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
						this.BtnUndo.Enabled = false;
						this.BtnUndo.Image = ((System.Drawing.Image)(resources.GetObject("BtnUndo.Image")));
						this.BtnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
						this.BtnUndo.Name = "BtnUndo";
						this.BtnUndo.Size = new System.Drawing.Size(36, 36);
						this.BtnUndo.Text = "Undo";
						this.BtnUndo.Click += new System.EventHandler(this.ActionUndo);
						// 
						// BtnRedo
						// 
						this.BtnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
						this.BtnRedo.Enabled = false;
						this.BtnRedo.Image = ((System.Drawing.Image)(resources.GetObject("BtnRedo.Image")));
						this.BtnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
						this.BtnRedo.Name = "BtnRedo";
						this.BtnRedo.Size = new System.Drawing.Size(36, 36);
						this.BtnRedo.Text = "Redo";
						this.BtnRedo.Click += new System.EventHandler(this.ActionRedo);
						// 
						// toolStripSeparator1
						// 
						this.toolStripSeparator1.Name = "toolStripSeparator1";
						this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
						// 
						// BtnChorus
						// 
						this.BtnChorus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
						this.BtnChorus.Image = ((System.Drawing.Image)(resources.GetObject("BtnChorus.Image")));
						this.BtnChorus.ImageTransparentColor = System.Drawing.Color.Magenta;
						this.BtnChorus.Name = "BtnChorus";
						this.BtnChorus.Size = new System.Drawing.Size(36, 36);
						this.BtnChorus.Text = "Chorus";
						this.BtnChorus.Click += new System.EventHandler(this.ActionChorus);
						// 
						// BtnComment
						// 
						this.BtnComment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
						this.BtnComment.Image = ((System.Drawing.Image)(resources.GetObject("BtnComment.Image")));
						this.BtnComment.ImageTransparentColor = System.Drawing.Color.Magenta;
						this.BtnComment.Name = "BtnComment";
						this.BtnComment.Size = new System.Drawing.Size(36, 36);
						this.BtnComment.Text = "Comment";
						this.BtnComment.Click += new System.EventHandler(this.ActionComment);
						// 
						// BtnCopyChord
						// 
						this.BtnCopyChord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
						this.BtnCopyChord.Image = ((System.Drawing.Image)(resources.GetObject("BtnCopyChord.Image")));
						this.BtnCopyChord.ImageTransparentColor = System.Drawing.Color.Magenta;
						this.BtnCopyChord.Name = "BtnCopyChord";
						this.BtnCopyChord.Size = new System.Drawing.Size(36, 36);
						this.BtnCopyChord.Text = "Copy Chords from selected line/s";
						this.BtnCopyChord.Click += new System.EventHandler(this.ActionCopyChords);
						// 
						// BtnPasteChord
						// 
						this.BtnPasteChord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
						this.BtnPasteChord.Image = ((System.Drawing.Image)(resources.GetObject("BtnPasteChord.Image")));
						this.BtnPasteChord.ImageTransparentColor = System.Drawing.Color.Magenta;
						this.BtnPasteChord.Name = "BtnPasteChord";
						this.BtnPasteChord.Size = new System.Drawing.Size(36, 36);
						this.BtnPasteChord.Text = "Paste Chords over selected line/s";
						this.BtnPasteChord.Click += new System.EventHandler(this.ActionPasteChords);
						// 
						// toolStripButton2
						// 
						this.toolStripButton2.Name = "toolStripButton2";
						this.toolStripButton2.Size = new System.Drawing.Size(6, 39);
						// 
						// BtnTrashChord
						// 
						this.BtnTrashChord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
						this.BtnTrashChord.Image = ((System.Drawing.Image)(resources.GetObject("BtnTrashChord.Image")));
						this.BtnTrashChord.ImageTransparentColor = System.Drawing.Color.Magenta;
						this.BtnTrashChord.Name = "BtnTrashChord";
						this.BtnTrashChord.Size = new System.Drawing.Size(36, 36);
						this.BtnTrashChord.Text = "Delete chords in selected line/s";
						this.BtnTrashChord.Click += new System.EventHandler(this.ActionTrashChords);
						// 
						// SheetForm
						// 
						this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
						this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
						this.BackColor = System.Drawing.Color.White;
						this.ClientSize = new System.Drawing.Size(870, 503);
						this.Controls.Add(this.MMS);
						this.Controls.Add(this.tableLayoutPanel2);
						this.Controls.Add(this.MTS);
						this.DockAreas = ChordEditor.UserControls.DockingManager.DockAreas.Document;
						this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
						this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
						this.MainMenuStrip = this.MMS;
						this.Name = "SheetForm";
						this.TabText = "";
						this.Text = "New sheet";
						this.ToolTipText = "";
						this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SheetForm_FormClosing);
						this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SheetForm_FormClosed);
						this.Load += new System.EventHandler(this.SheetForm_Load);
						((System.ComponentModel.ISupportInitialize)(this.CHP)).EndInit();
						this.CMS.ResumeLayout(false);
						this.tableLayoutPanel1.ResumeLayout(false);
						this.tableLayoutPanel1.PerformLayout();
						this.tableLayoutPanel2.ResumeLayout(false);
						this.tableLayoutPanel2.PerformLayout();
						this.SC.Panel1.ResumeLayout(false);
						this.SC.Panel2.ResumeLayout(false);
						((System.ComponentModel.ISupportInitialize)(this.SC)).EndInit();
						this.SC.ResumeLayout(false);
						((System.ComponentModel.ISupportInitialize)(this.COT)).EndInit();
						((System.ComponentModel.ISupportInitialize)(this.FSW)).EndInit();
						this.MMS.ResumeLayout(false);
						this.MMS.PerformLayout();
						this.MTS.ResumeLayout(false);
						this.MTS.PerformLayout();
						this.ResumeLayout(false);
						this.PerformLayout();

		}

		#endregion

		private FastColoredTextBoxNS.FastColoredTextBox CHP;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.ComboBox CbZoom;
		private System.IO.FileSystemWatcher FSW;
		private System.Windows.Forms.Timer VT;
		private System.Windows.Forms.Timer RetryReload;
        private System.Windows.Forms.ContextMenuStrip CMS;
        private System.Windows.Forms.ToolStripMenuItem CMnUndo;
        private System.Windows.Forms.ToolStripMenuItem CMnRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CMnCut;
        private System.Windows.Forms.ToolStripMenuItem CMnCopy;
        private System.Windows.Forms.ToolStripMenuItem CMnPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem CMnSelectAll;
        private AutocompleteMenuNS.AutocompleteMenu ACM;
        private System.Windows.Forms.ImageList IL;
        private System.Windows.Forms.SplitContainer SC;
        private FastColoredTextBoxNS.FastColoredTextBox COT;
        private System.Windows.Forms.ToolStripMenuItem CMnChorus;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem CMnComment;
				private System.Windows.Forms.MenuStrip MMS;
				private System.Windows.Forms.ToolStripMenuItem MMnEdit;
				private System.Windows.Forms.ToolStripMenuItem MMnChorus;
				private System.Windows.Forms.ToolStripMenuItem MMnComment;
				private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
				private System.Windows.Forms.ToolStripMenuItem MMnUndo;
				private System.Windows.Forms.ToolStripMenuItem MMnRedo;
				private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
				private System.Windows.Forms.ToolStripMenuItem MMnCut;
				private System.Windows.Forms.ToolStripMenuItem MMnCopy;
				private System.Windows.Forms.ToolStripMenuItem MMnPaste;
				private System.Windows.Forms.ToolStripSeparator toolStripMenuItem13;
				private System.Windows.Forms.ToolStripMenuItem MMnSelectAll;
				private System.Windows.Forms.ToolStrip MTS;
				private System.Windows.Forms.ToolStripButton BtnSave;
				private System.Windows.Forms.ToolStripButton BtnPrint;
				private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
				private System.Windows.Forms.ToolStripButton BtnCut;
				private System.Windows.Forms.ToolStripButton BtnCopy;
				private System.Windows.Forms.ToolStripButton BtnPaste;
				private System.Windows.Forms.ToolStripMenuItem MMnFile;
				private System.Windows.Forms.ToolStripMenuItem MMnSave;
				private System.Windows.Forms.ToolStripMenuItem MMnClose;
				private System.Windows.Forms.ToolStripMenuItem MnPrint;
				private System.Windows.Forms.ToolStripSeparator toolStripButton1;
				private System.Windows.Forms.ToolStripButton BtnUndo;
				private System.Windows.Forms.ToolStripButton BtnRedo;
				private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
				private System.Windows.Forms.ToolStripButton BtnChorus;
				private System.Windows.Forms.ToolStripButton BtnComment;
				private System.Windows.Forms.ToolStripButton BtnCopyChord;
				private System.Windows.Forms.ToolStripButton BtnPasteChord;
				private System.Windows.Forms.ToolStripButton BtnTrashChord;
				private System.Windows.Forms.ToolStripSeparator toolStripButton2;
	}
}