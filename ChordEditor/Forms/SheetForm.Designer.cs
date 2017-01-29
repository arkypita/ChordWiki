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
            this.TB = new FastColoredTextBoxNS.FastColoredTextBox();
            this.CMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MnUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.MnRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnCut = new System.Windows.Forms.ToolStripMenuItem();
            this.MnCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.MnSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.CbZoom = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.FSW = new System.IO.FileSystemWatcher();
            this.VT = new System.Windows.Forms.Timer(this.components);
            this.RetryReload = new System.Windows.Forms.Timer(this.components);
            this.ACM = new AutocompleteMenuNS.AutocompleteMenu();
            this.IL = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TB)).BeginInit();
            this.CMS.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FSW)).BeginInit();
            this.SuspendLayout();
            // 
            // TB
            // 
            this.TB.AutoCompleteBracketsList = new char[] {
        '{',
        '}',
        '[',
        ']'};
            this.ACM.SetAutocompleteMenu(this.TB, this.ACM);
            this.TB.AutoIndent = false;
            this.TB.AutoIndentChars = false;
            this.TB.AutoIndentExistingLines = false;
            this.TB.AutoScrollMinSize = new System.Drawing.Size(18, 30);
            this.TB.BackBrush = null;
            this.TB.CharHeight = 14;
            this.TB.CharWidth = 8;
            this.TB.CommentPrefix = "#";
            this.TB.ContextMenuStrip = this.CMS;
            this.TB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB.Hotkeys = resources.GetString("TB.Hotkeys");
            this.TB.IsReplaceMode = false;
            this.TB.Location = new System.Drawing.Point(3, 3);
            this.TB.Name = "TB";
            this.TB.Paddings = new System.Windows.Forms.Padding(8);
            this.TB.PreferredLineWidth = 60;
            this.TB.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(255)))));
            this.TB.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("TB.ServiceColors")));
            this.TB.ShowLineNumbers = false;
            this.TB.Size = new System.Drawing.Size(666, 470);
            this.TB.TabIndex = 0;
            this.TB.Zoom = 100;
            this.TB.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.TB_TextChanged);
            this.TB.Pasting += new System.EventHandler<FastColoredTextBoxNS.TextChangingEventArgs>(this.TB_Pasting);
            this.TB.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.TB_TextChangedDelayed);
            this.TB.ZoomChanged += new System.EventHandler(this.TB_ZoomChanged);
            // 
            // CMS
            // 
            this.CMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnUndo,
            this.MnRedo,
            this.toolStripMenuItem1,
            this.MnCut,
            this.MnCopy,
            this.MnPaste,
            this.toolStripMenuItem2,
            this.MnSelectAll});
            this.CMS.Name = "CMS";
            this.CMS.Size = new System.Drawing.Size(121, 148);
            this.CMS.Opening += new System.ComponentModel.CancelEventHandler(this.CMS_Opening);
            // 
            // MnUndo
            // 
            this.MnUndo.Image = ((System.Drawing.Image)(resources.GetObject("MnUndo.Image")));
            this.MnUndo.Name = "MnUndo";
            this.MnUndo.Size = new System.Drawing.Size(120, 22);
            this.MnUndo.Text = "Undo";
            this.MnUndo.Click += new System.EventHandler(this.ActionUndo);
            // 
            // MnRedo
            // 
            this.MnRedo.Image = ((System.Drawing.Image)(resources.GetObject("MnRedo.Image")));
            this.MnRedo.Name = "MnRedo";
            this.MnRedo.Size = new System.Drawing.Size(120, 22);
            this.MnRedo.Text = "Redo";
            this.MnRedo.Click += new System.EventHandler(this.ActionRedo);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(117, 6);
            // 
            // MnCut
            // 
            this.MnCut.Image = ((System.Drawing.Image)(resources.GetObject("MnCut.Image")));
            this.MnCut.Name = "MnCut";
            this.MnCut.Size = new System.Drawing.Size(120, 22);
            this.MnCut.Text = "Cut";
            this.MnCut.Click += new System.EventHandler(this.SelectionCut);
            // 
            // MnCopy
            // 
            this.MnCopy.Image = ((System.Drawing.Image)(resources.GetObject("MnCopy.Image")));
            this.MnCopy.Name = "MnCopy";
            this.MnCopy.Size = new System.Drawing.Size(120, 22);
            this.MnCopy.Text = "Copy";
            this.MnCopy.Click += new System.EventHandler(this.SelectionCopy);
            // 
            // MnPaste
            // 
            this.MnPaste.Image = ((System.Drawing.Image)(resources.GetObject("MnPaste.Image")));
            this.MnPaste.Name = "MnPaste";
            this.MnPaste.Size = new System.Drawing.Size(120, 22);
            this.MnPaste.Text = "Paste";
            this.MnPaste.Click += new System.EventHandler(this.SelectionPaste);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(117, 6);
            // 
            // MnSelectAll
            // 
            this.MnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("MnSelectAll.Image")));
            this.MnSelectAll.Name = "MnSelectAll";
            this.MnSelectAll.Size = new System.Drawing.Size(120, 22);
            this.MnSelectAll.Text = "Select all";
            this.MnSelectAll.Click += new System.EventHandler(this.ActionSelectAll);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(672, 27);
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
            this.CbZoom.Validating += new System.ComponentModel.CancelEventHandler(this.CbZoom_Validating);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.TB, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(672, 503);
            this.tableLayoutPanel2.TabIndex = 2;
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
            this.ACM.SearchPattern = "[\\w\\.\\[]";
            this.ACM.TargetControlWrapper = null;
            // 
            // IL
            // 
            this.IL.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IL.ImageStream")));
            this.IL.TransparentColor = System.Drawing.Color.Transparent;
            this.IL.Images.SetKeyName(0, "musical-note.png");
            // 
            // SheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(672, 503);
            this.Controls.Add(this.tableLayoutPanel2);
            this.DockAreas = ChordEditor.UserControls.DockingManager.DockAreas.Document;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SheetForm";
            this.TabText = "";
            this.Text = "New sheet";
            this.ToolTipText = "";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SheetForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SheetForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.TB)).EndInit();
            this.CMS.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FSW)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private FastColoredTextBoxNS.FastColoredTextBox TB;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.ComboBox CbZoom;
		private System.IO.FileSystemWatcher FSW;
		private System.Windows.Forms.Timer VT;
		private System.Windows.Forms.Timer RetryReload;
        private System.Windows.Forms.ContextMenuStrip CMS;
        private System.Windows.Forms.ToolStripMenuItem MnUndo;
        private System.Windows.Forms.ToolStripMenuItem MnRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MnCut;
        private System.Windows.Forms.ToolStripMenuItem MnCopy;
        private System.Windows.Forms.ToolStripMenuItem MnPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem MnSelectAll;
        private AutocompleteMenuNS.AutocompleteMenu ACM;
        private System.Windows.Forms.ImageList IL;
	}
}