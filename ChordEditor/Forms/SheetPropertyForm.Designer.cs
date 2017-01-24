namespace ChordEditor.Forms
{
	partial class SheetPropertyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SheetPropertyForm));
            this.TlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.PbNotation = new System.Windows.Forms.PictureBox();
            this.GbSheetInfo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TbProgress = new System.Windows.Forms.TextBox();
            this.TbSheetAuthor = new System.Windows.Forms.TextBox();
            this.TbSheetRevisor = new System.Windows.Forms.TextBox();
            this.PbSheetAuthor = new System.Windows.Forms.PictureBox();
            this.PbSheetRevisor = new System.Windows.Forms.PictureBox();
            this.PbSheetProgress = new System.Windows.Forms.PictureBox();
            this.GbSongInfo = new System.Windows.Forms.GroupBox();
            this.TlpHeader = new System.Windows.Forms.TableLayoutPanel();
            this.TbTitle = new ChordEditor.UserControls.NullTextBox();
            this.TbArtist = new ChordEditor.UserControls.NullTextBox();
            this.CbCategory = new System.Windows.Forms.ComboBox();
            this.TbTags = new ChordEditor.UserControls.NullTextBox();
            this.PbSongTitle = new System.Windows.Forms.PictureBox();
            this.PbArtist = new System.Windows.Forms.PictureBox();
            this.PbCategory = new System.Windows.Forms.PictureBox();
            this.PbTags = new System.Windows.Forms.PictureBox();
            this.TT = new System.Windows.Forms.ToolTip(this.components);
            this.NF = new System.Windows.Forms.ImageList(this.components);
            this.TlpMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbNotation)).BeginInit();
            this.GbSheetInfo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbSheetAuthor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbSheetRevisor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbSheetProgress)).BeginInit();
            this.GbSongInfo.SuspendLayout();
            this.TlpHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbSongTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbArtist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbTags)).BeginInit();
            this.SuspendLayout();
            // 
            // TlpMain
            // 
            this.TlpMain.ColumnCount = 1;
            this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpMain.Controls.Add(this.groupBox1, 0, 1);
            this.TlpMain.Controls.Add(this.GbSheetInfo, 0, 2);
            this.TlpMain.Controls.Add(this.GbSongInfo, 0, 0);
            this.TlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpMain.Enabled = false;
            this.TlpMain.Location = new System.Drawing.Point(0, 0);
            this.TlpMain.Name = "TlpMain";
            this.TlpMain.RowCount = 4;
            this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpMain.Size = new System.Drawing.Size(237, 452);
            this.TlpMain.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 115);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tools";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.PbNotation, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(225, 96);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Notation";
            // 
            // PbNotation
            // 
            this.PbNotation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PbNotation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbNotation.Image = ((System.Drawing.Image)(resources.GetObject("PbNotation.Image")));
            this.PbNotation.Location = new System.Drawing.Point(54, 1);
            this.PbNotation.Margin = new System.Windows.Forms.Padding(1);
            this.PbNotation.Name = "PbNotation";
            this.PbNotation.Size = new System.Drawing.Size(32, 22);
            this.PbNotation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PbNotation.TabIndex = 12;
            this.PbNotation.TabStop = false;
            this.TT.SetToolTip(this.PbNotation, "Change notation");
            this.PbNotation.Click += new System.EventHandler(this.PbNotation_Click);
            // 
            // GbSheetInfo
            // 
            this.GbSheetInfo.AutoSize = true;
            this.GbSheetInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GbSheetInfo.Controls.Add(this.tableLayoutPanel1);
            this.GbSheetInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbSheetInfo.Location = new System.Drawing.Point(3, 254);
            this.GbSheetInfo.Name = "GbSheetInfo";
            this.GbSheetInfo.Size = new System.Drawing.Size(231, 109);
            this.GbSheetInfo.TabIndex = 2;
            this.GbSheetInfo.TabStop = false;
            this.GbSheetInfo.Text = "Sheet Info";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.TbProgress, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.TbSheetAuthor, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.TbSheetRevisor, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.PbSheetAuthor, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PbSheetRevisor, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.PbSheetProgress, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(225, 90);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // TbProgress
            // 
            this.TbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbProgress.Enabled = false;
            this.TbProgress.Location = new System.Drawing.Point(33, 65);
            this.TbProgress.Name = "TbProgress";
            this.TbProgress.Size = new System.Drawing.Size(189, 20);
            this.TbProgress.TabIndex = 11;
            // 
            // TbSheetAuthor
            // 
            this.TbSheetAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbSheetAuthor.Enabled = false;
            this.TbSheetAuthor.Location = new System.Drawing.Point(33, 5);
            this.TbSheetAuthor.Name = "TbSheetAuthor";
            this.TbSheetAuthor.Size = new System.Drawing.Size(189, 20);
            this.TbSheetAuthor.TabIndex = 5;
            // 
            // TbSheetRevisor
            // 
            this.TbSheetRevisor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbSheetRevisor.Enabled = false;
            this.TbSheetRevisor.Location = new System.Drawing.Point(33, 35);
            this.TbSheetRevisor.Name = "TbSheetRevisor";
            this.TbSheetRevisor.Size = new System.Drawing.Size(189, 20);
            this.TbSheetRevisor.TabIndex = 6;
            this.TbSheetRevisor.Visible = false;
            // 
            // PbSheetAuthor
            // 
            this.PbSheetAuthor.Image = ((System.Drawing.Image)(resources.GetObject("PbSheetAuthor.Image")));
            this.PbSheetAuthor.Location = new System.Drawing.Point(3, 3);
            this.PbSheetAuthor.Name = "PbSheetAuthor";
            this.PbSheetAuthor.Size = new System.Drawing.Size(24, 24);
            this.PbSheetAuthor.TabIndex = 8;
            this.PbSheetAuthor.TabStop = false;
            this.TT.SetToolTip(this.PbSheetAuthor, "Sheet Author");
            // 
            // PbSheetRevisor
            // 
            this.PbSheetRevisor.Image = ((System.Drawing.Image)(resources.GetObject("PbSheetRevisor.Image")));
            this.PbSheetRevisor.Location = new System.Drawing.Point(3, 33);
            this.PbSheetRevisor.Name = "PbSheetRevisor";
            this.PbSheetRevisor.Size = new System.Drawing.Size(24, 24);
            this.PbSheetRevisor.TabIndex = 9;
            this.PbSheetRevisor.TabStop = false;
            this.TT.SetToolTip(this.PbSheetRevisor, "Sheet Revisor");
            this.PbSheetRevisor.Visible = false;
            // 
            // PbSheetProgress
            // 
            this.PbSheetProgress.Image = ((System.Drawing.Image)(resources.GetObject("PbSheetProgress.Image")));
            this.PbSheetProgress.Location = new System.Drawing.Point(3, 63);
            this.PbSheetProgress.Name = "PbSheetProgress";
            this.PbSheetProgress.Size = new System.Drawing.Size(24, 24);
            this.PbSheetProgress.TabIndex = 10;
            this.PbSheetProgress.TabStop = false;
            this.TT.SetToolTip(this.PbSheetProgress, "Editing Status");
            // 
            // GbSongInfo
            // 
            this.GbSongInfo.AutoSize = true;
            this.GbSongInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GbSongInfo.Controls.Add(this.TlpHeader);
            this.GbSongInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbSongInfo.Location = new System.Drawing.Point(3, 3);
            this.GbSongInfo.Name = "GbSongInfo";
            this.GbSongInfo.Size = new System.Drawing.Size(231, 124);
            this.GbSongInfo.TabIndex = 3;
            this.GbSongInfo.TabStop = false;
            this.GbSongInfo.Text = "Song Property";
            // 
            // TlpHeader
            // 
            this.TlpHeader.AutoSize = true;
            this.TlpHeader.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TlpHeader.ColumnCount = 2;
            this.TlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpHeader.Controls.Add(this.TbTitle, 1, 0);
            this.TlpHeader.Controls.Add(this.TbArtist, 1, 1);
            this.TlpHeader.Controls.Add(this.CbCategory, 1, 2);
            this.TlpHeader.Controls.Add(this.TbTags, 1, 3);
            this.TlpHeader.Controls.Add(this.PbSongTitle, 0, 0);
            this.TlpHeader.Controls.Add(this.PbArtist, 0, 1);
            this.TlpHeader.Controls.Add(this.PbCategory, 0, 2);
            this.TlpHeader.Controls.Add(this.PbTags, 0, 3);
            this.TlpHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpHeader.Location = new System.Drawing.Point(3, 16);
            this.TlpHeader.Name = "TlpHeader";
            this.TlpHeader.RowCount = 4;
            this.TlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpHeader.Size = new System.Drawing.Size(225, 105);
            this.TlpHeader.TabIndex = 0;
            // 
            // TbTitle
            // 
            this.TbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbTitle.Location = new System.Drawing.Point(29, 3);
            this.TbTitle.Name = "TbTitle";
            this.TbTitle.NullString = "<Song Title>";
            this.TbTitle.Size = new System.Drawing.Size(193, 20);
            this.TbTitle.TabIndex = 0;
            this.TbTitle.TextChanged += new System.EventHandler(this.TbTitle_TextChanged);
            this.TbTitle.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateTextBox);
            // 
            // TbArtist
            // 
            this.TbArtist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbArtist.Location = new System.Drawing.Point(29, 29);
            this.TbArtist.Name = "TbArtist";
            this.TbArtist.NullString = "<Artist>";
            this.TbArtist.Size = new System.Drawing.Size(193, 20);
            this.TbArtist.TabIndex = 1;
            this.TbArtist.TextChanged += new System.EventHandler(this.TbArtist_TextChanged);
            this.TbArtist.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateTextBox);
            // 
            // CbCategory
            // 
            this.CbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbCategory.FormattingEnabled = true;
            this.CbCategory.Location = new System.Drawing.Point(29, 55);
            this.CbCategory.Name = "CbCategory";
            this.CbCategory.Size = new System.Drawing.Size(193, 21);
            this.CbCategory.TabIndex = 2;
            this.CbCategory.SelectedIndexChanged += new System.EventHandler(this.CbCategory_SelectedIndexChanged);
            // 
            // TbTags
            // 
            this.TbTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbTags.Location = new System.Drawing.Point(29, 82);
            this.TbTags.Name = "TbTags";
            this.TbTags.NullString = "<Tags>";
            this.TbTags.Size = new System.Drawing.Size(193, 20);
            this.TbTags.TabIndex = 3;
            this.TbTags.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateTextBox);
            // 
            // PbSongTitle
            // 
            this.PbSongTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PbSongTitle.Image = ((System.Drawing.Image)(resources.GetObject("PbSongTitle.Image")));
            this.PbSongTitle.Location = new System.Drawing.Point(1, 1);
            this.PbSongTitle.Margin = new System.Windows.Forms.Padding(1);
            this.PbSongTitle.Name = "PbSongTitle";
            this.PbSongTitle.Size = new System.Drawing.Size(24, 24);
            this.PbSongTitle.TabIndex = 9;
            this.PbSongTitle.TabStop = false;
            this.TT.SetToolTip(this.PbSongTitle, "Song Title");
            // 
            // PbArtist
            // 
            this.PbArtist.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PbArtist.Image = ((System.Drawing.Image)(resources.GetObject("PbArtist.Image")));
            this.PbArtist.Location = new System.Drawing.Point(1, 27);
            this.PbArtist.Margin = new System.Windows.Forms.Padding(1);
            this.PbArtist.Name = "PbArtist";
            this.PbArtist.Size = new System.Drawing.Size(24, 24);
            this.PbArtist.TabIndex = 10;
            this.PbArtist.TabStop = false;
            this.TT.SetToolTip(this.PbArtist, "Artist");
            // 
            // PbCategory
            // 
            this.PbCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PbCategory.Image = ((System.Drawing.Image)(resources.GetObject("PbCategory.Image")));
            this.PbCategory.Location = new System.Drawing.Point(1, 53);
            this.PbCategory.Margin = new System.Windows.Forms.Padding(1);
            this.PbCategory.Name = "PbCategory";
            this.PbCategory.Size = new System.Drawing.Size(24, 24);
            this.PbCategory.TabIndex = 11;
            this.PbCategory.TabStop = false;
            this.TT.SetToolTip(this.PbCategory, "Category");
            // 
            // PbTags
            // 
            this.PbTags.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PbTags.Image = ((System.Drawing.Image)(resources.GetObject("PbTags.Image")));
            this.PbTags.Location = new System.Drawing.Point(1, 80);
            this.PbTags.Margin = new System.Windows.Forms.Padding(1);
            this.PbTags.Name = "PbTags";
            this.PbTags.Size = new System.Drawing.Size(24, 24);
            this.PbTags.TabIndex = 12;
            this.PbTags.TabStop = false;
            this.TT.SetToolTip(this.PbTags, "Tags");
            // 
            // NF
            // 
            this.NF.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("NF.ImageStream")));
            this.NF.TransparentColor = System.Drawing.Color.Transparent;
            this.NF.Images.SetKeyName(0, "Italian");
            this.NF.Images.SetKeyName(1, "American");
            this.NF.Images.SetKeyName(2, "Unknown");
            // 
            // SheetPropertyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 452);
            this.Controls.Add(this.TlpMain);
            this.DockAreas = ((ChordEditor.UserControls.DockingManager.DockAreas)(((ChordEditor.UserControls.DockingManager.DockAreas.Float | ChordEditor.UserControls.DockingManager.DockAreas.DockLeft) 
            | ChordEditor.UserControls.DockingManager.DockAreas.DockRight)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Name = "SheetPropertyForm";
            this.TabText = "Property";
            this.Text = "Property";
            this.ToolTipText = "Property";
            this.Load += new System.EventHandler(this.SheetPropertyForm_Load);
            this.TlpMain.ResumeLayout(false);
            this.TlpMain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbNotation)).EndInit();
            this.GbSheetInfo.ResumeLayout(false);
            this.GbSheetInfo.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbSheetAuthor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbSheetRevisor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbSheetProgress)).EndInit();
            this.GbSongInfo.ResumeLayout(false);
            this.GbSongInfo.PerformLayout();
            this.TlpHeader.ResumeLayout(false);
            this.TlpHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbSongTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbArtist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbTags)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.TableLayoutPanel TlpMain;
        private System.Windows.Forms.TableLayoutPanel TlpHeader;
        private UserControls.NullTextBox TbTitle;
        private ChordEditor.UserControls.NullTextBox TbArtist;
        private System.Windows.Forms.ComboBox CbCategory;
        private ChordEditor.UserControls.NullTextBox TbTags;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox TbSheetAuthor;
        private System.Windows.Forms.TextBox TbSheetRevisor;
        private System.Windows.Forms.GroupBox GbSheetInfo;
        private System.Windows.Forms.GroupBox GbSongInfo;
        private System.Windows.Forms.PictureBox PbSongTitle;
        private System.Windows.Forms.PictureBox PbArtist;
        private System.Windows.Forms.PictureBox PbCategory;
        private System.Windows.Forms.PictureBox PbTags;
        private System.Windows.Forms.ToolTip TT;
        private System.Windows.Forms.PictureBox PbSheetAuthor;
        private System.Windows.Forms.PictureBox PbSheetRevisor;
        private System.Windows.Forms.PictureBox PbSheetProgress;
        private System.Windows.Forms.TextBox TbProgress;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PbNotation;
        private System.Windows.Forms.ImageList NF;
	}
}