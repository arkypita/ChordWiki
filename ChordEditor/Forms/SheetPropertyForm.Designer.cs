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
						this.GbTools = new System.Windows.Forms.GroupBox();
						this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
						this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
						this.PbTrasposeUp = new ChordEditor.UserControls.ImageButton();
						this.CbSemitoni = new System.Windows.Forms.ComboBox();
						this.PbTrasposeDown = new ChordEditor.UserControls.ImageButton();
						this.PbNormalized = new ChordEditor.UserControls.ImageButton();
						this.label1 = new System.Windows.Forms.Label();
						this.label2 = new System.Windows.Forms.Label();
						this.PbNotation = new ChordEditor.UserControls.ImageButton();
						this.label3 = new System.Windows.Forms.Label();
						this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
						this.GbSheetInfo = new System.Windows.Forms.GroupBox();
						this.TlpProgress = new System.Windows.Forms.TableLayoutPanel();
						this.pictureBox2 = new System.Windows.Forms.PictureBox();
						this.TbSheetAuthor = new System.Windows.Forms.TextBox();
						this.TbSheetRevisor = new System.Windows.Forms.TextBox();
						this.PbSheetAuthor = new System.Windows.Forms.PictureBox();
						this.PbSheetRevisor = new System.Windows.Forms.PictureBox();
						this.label4 = new System.Windows.Forms.Label();
						this.pictureBox1 = new System.Windows.Forms.PictureBox();
						this.label5 = new System.Windows.Forms.Label();
						this.label6 = new System.Windows.Forms.Label();
						this.label7 = new System.Windows.Forms.Label();
						this.TbVerified = new System.Windows.Forms.TextBox();
						this.TbLocked = new System.Windows.Forms.TextBox();
						this.PbAdd = new ChordEditor.UserControls.ImageButton();
						this.PbVerify = new ChordEditor.UserControls.ImageButton();
						this.PbReview = new ChordEditor.UserControls.ImageButton();
						this.PbLock = new ChordEditor.UserControls.ImageButton();
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
						this.SF = new System.Windows.Forms.ImageList(this.components);
						this.TlpMain.SuspendLayout();
						this.GbTools.SuspendLayout();
						this.tableLayoutPanel3.SuspendLayout();
						this.tableLayoutPanel4.SuspendLayout();
						this.GbSheetInfo.SuspendLayout();
						this.TlpProgress.SuspendLayout();
						((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
						((System.ComponentModel.ISupportInitialize)(this.PbSheetAuthor)).BeginInit();
						((System.ComponentModel.ISupportInitialize)(this.PbSheetRevisor)).BeginInit();
						((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
						this.TlpMain.Controls.Add(this.GbTools, 0, 1);
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
						this.TlpMain.Size = new System.Drawing.Size(268, 452);
						this.TlpMain.TabIndex = 0;
						// 
						// GbTools
						// 
						this.GbTools.AutoSize = true;
						this.GbTools.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
						this.GbTools.Controls.Add(this.tableLayoutPanel3);
						this.GbTools.Controls.Add(this.tableLayoutPanel2);
						this.GbTools.Dock = System.Windows.Forms.DockStyle.Fill;
						this.GbTools.Location = new System.Drawing.Point(3, 133);
						this.GbTools.Name = "GbTools";
						this.GbTools.Size = new System.Drawing.Size(262, 76);
						this.GbTools.TabIndex = 4;
						this.GbTools.TabStop = false;
						this.GbTools.Text = "Tools";
						// 
						// tableLayoutPanel3
						// 
						this.tableLayoutPanel3.AutoSize = true;
						this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
						this.tableLayoutPanel3.ColumnCount = 4;
						this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
						this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
						this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
						this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
						this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 1);
						this.tableLayoutPanel3.Controls.Add(this.PbNormalized, 3, 0);
						this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
						this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
						this.tableLayoutPanel3.Controls.Add(this.PbNotation, 1, 0);
						this.tableLayoutPanel3.Controls.Add(this.label3, 2, 0);
						this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
						this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
						this.tableLayoutPanel3.Name = "tableLayoutPanel3";
						this.tableLayoutPanel3.RowCount = 2;
						this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
						this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
						this.tableLayoutPanel3.Size = new System.Drawing.Size(256, 57);
						this.tableLayoutPanel3.TabIndex = 2;
						// 
						// tableLayoutPanel4
						// 
						this.tableLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.Left;
						this.tableLayoutPanel4.AutoSize = true;
						this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
						this.tableLayoutPanel4.ColumnCount = 3;
						this.tableLayoutPanel3.SetColumnSpan(this.tableLayoutPanel4, 3);
						this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
						this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
						this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
						this.tableLayoutPanel4.Controls.Add(this.PbTrasposeUp, 2, 0);
						this.tableLayoutPanel4.Controls.Add(this.CbSemitoni, 1, 0);
						this.tableLayoutPanel4.Controls.Add(this.PbTrasposeDown, 0, 0);
						this.tableLayoutPanel4.Location = new System.Drawing.Point(60, 27);
						this.tableLayoutPanel4.Name = "tableLayoutPanel4";
						this.tableLayoutPanel4.RowCount = 1;
						this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
						this.tableLayoutPanel4.Size = new System.Drawing.Size(130, 27);
						this.tableLayoutPanel4.TabIndex = 3;
						// 
						// PbTrasposeUp
						// 
						this.PbTrasposeUp.Anchor = System.Windows.Forms.AnchorStyles.None;
						this.PbTrasposeUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
						this.PbTrasposeUp.Coloration = System.Drawing.Color.Empty;
						this.PbTrasposeUp.Cursor = System.Windows.Forms.Cursors.Hand;
						this.PbTrasposeUp.Image = ((System.Drawing.Image)(resources.GetObject("PbTrasposeUp.Image")));
						this.PbTrasposeUp.Location = new System.Drawing.Point(108, 3);
						this.PbTrasposeUp.Margin = new System.Windows.Forms.Padding(1);
						this.PbTrasposeUp.Name = "PbTrasposeUp";
						this.PbTrasposeUp.Size = new System.Drawing.Size(21, 21);
						this.PbTrasposeUp.SizingMode = ChordEditor.UserControls.ImageButton.SizingModes.FixedSize;
						this.PbTrasposeUp.TabIndex = 16;
						this.PbTrasposeUp.TabStop = false;
						this.TT.SetToolTip(this.PbTrasposeUp, "Increase tonality");
						this.PbTrasposeUp.Click += new System.EventHandler(this.PbTrasposeUp_Click);
						// 
						// CbSemitoni
						// 
						this.CbSemitoni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
						this.CbSemitoni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
						this.CbSemitoni.FormattingEnabled = true;
						this.CbSemitoni.Location = new System.Drawing.Point(26, 3);
						this.CbSemitoni.MinimumSize = new System.Drawing.Size(70, 0);
						this.CbSemitoni.Name = "CbSemitoni";
						this.CbSemitoni.Size = new System.Drawing.Size(78, 21);
						this.CbSemitoni.TabIndex = 15;
						this.TT.SetToolTip(this.CbSemitoni, "Traspose tonality");
						this.CbSemitoni.SelectedIndexChanged += new System.EventHandler(this.CbSemitoni_SelectedIndexChanged);
						// 
						// PbTrasposeDown
						// 
						this.PbTrasposeDown.Anchor = System.Windows.Forms.AnchorStyles.None;
						this.PbTrasposeDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
						this.PbTrasposeDown.Coloration = System.Drawing.Color.Empty;
						this.PbTrasposeDown.Cursor = System.Windows.Forms.Cursors.Hand;
						this.PbTrasposeDown.Image = ((System.Drawing.Image)(resources.GetObject("PbTrasposeDown.Image")));
						this.PbTrasposeDown.Location = new System.Drawing.Point(1, 3);
						this.PbTrasposeDown.Margin = new System.Windows.Forms.Padding(1);
						this.PbTrasposeDown.Name = "PbTrasposeDown";
						this.PbTrasposeDown.Size = new System.Drawing.Size(21, 21);
						this.PbTrasposeDown.SizingMode = ChordEditor.UserControls.ImageButton.SizingModes.FixedSize;
						this.PbTrasposeDown.TabIndex = 14;
						this.PbTrasposeDown.TabStop = false;
						this.TT.SetToolTip(this.PbTrasposeDown, "Decrease tonality");
						this.PbTrasposeDown.Click += new System.EventHandler(this.PbTrasposeDown_Click);
						// 
						// PbNormalized
						// 
						this.PbNormalized.Anchor = System.Windows.Forms.AnchorStyles.Left;
						this.PbNormalized.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
						this.PbNormalized.Coloration = System.Drawing.Color.Empty;
						this.PbNormalized.Cursor = System.Windows.Forms.Cursors.Hand;
						this.PbNormalized.Image = null;
						this.PbNormalized.Location = new System.Drawing.Point(157, 1);
						this.PbNormalized.Margin = new System.Windows.Forms.Padding(1);
						this.PbNormalized.Name = "PbNormalized";
						this.PbNormalized.Size = new System.Drawing.Size(32, 22);
						this.PbNormalized.SizingMode = ChordEditor.UserControls.ImageButton.SizingModes.FixedSize;
						this.PbNormalized.TabIndex = 19;
						this.PbNormalized.TabStop = false;
						this.TT.SetToolTip(this.PbNormalized, "Normalize");
						this.PbNormalized.Click += new System.EventHandler(this.PbNormalized_Click);
						// 
						// label1
						// 
						this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
						this.label1.AutoSize = true;
						this.label1.Location = new System.Drawing.Point(3, 5);
						this.label1.Name = "label1";
						this.label1.Size = new System.Drawing.Size(47, 13);
						this.label1.TabIndex = 17;
						this.label1.Text = "Notation";
						// 
						// label2
						// 
						this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
						this.label2.AutoSize = true;
						this.label2.Location = new System.Drawing.Point(3, 34);
						this.label2.Name = "label2";
						this.label2.Size = new System.Drawing.Size(51, 13);
						this.label2.TabIndex = 13;
						this.label2.Text = "Traspose";
						// 
						// PbNotation
						// 
						this.PbNotation.Anchor = System.Windows.Forms.AnchorStyles.Left;
						this.PbNotation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
						this.PbNotation.Coloration = System.Drawing.Color.Empty;
						this.PbNotation.Cursor = System.Windows.Forms.Cursors.Hand;
						this.PbNotation.Image = null;
						this.PbNotation.Location = new System.Drawing.Point(58, 1);
						this.PbNotation.Margin = new System.Windows.Forms.Padding(1);
						this.PbNotation.Name = "PbNotation";
						this.PbNotation.Size = new System.Drawing.Size(32, 22);
						this.PbNotation.SizingMode = ChordEditor.UserControls.ImageButton.SizingModes.FixedSize;
						this.PbNotation.TabIndex = 12;
						this.PbNotation.TabStop = false;
						this.TT.SetToolTip(this.PbNotation, "Change notation");
						this.PbNotation.Click += new System.EventHandler(this.PbNotation_Click);
						// 
						// label3
						// 
						this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
						this.label3.AutoSize = true;
						this.label3.Location = new System.Drawing.Point(94, 5);
						this.label3.Name = "label3";
						this.label3.Size = new System.Drawing.Size(59, 13);
						this.label3.TabIndex = 18;
						this.label3.Text = "Normalized";
						// 
						// tableLayoutPanel2
						// 
						this.tableLayoutPanel2.AutoSize = true;
						this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
						this.tableLayoutPanel2.ColumnCount = 6;
						this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
						this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
						this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
						this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
						this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
						this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
						this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
						this.tableLayoutPanel2.Name = "tableLayoutPanel2";
						this.tableLayoutPanel2.RowCount = 2;
						this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
						this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
						this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
						this.tableLayoutPanel2.Size = new System.Drawing.Size(20, 0);
						this.tableLayoutPanel2.TabIndex = 1;
						// 
						// GbSheetInfo
						// 
						this.GbSheetInfo.AutoSize = true;
						this.GbSheetInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
						this.GbSheetInfo.Controls.Add(this.TlpProgress);
						this.GbSheetInfo.Dock = System.Windows.Forms.DockStyle.Fill;
						this.GbSheetInfo.Location = new System.Drawing.Point(3, 215);
						this.GbSheetInfo.Name = "GbSheetInfo";
						this.GbSheetInfo.Size = new System.Drawing.Size(262, 139);
						this.GbSheetInfo.TabIndex = 2;
						this.GbSheetInfo.TabStop = false;
						this.GbSheetInfo.Text = "Progress Info";
						// 
						// TlpProgress
						// 
						this.TlpProgress.AutoSize = true;
						this.TlpProgress.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
						this.TlpProgress.ColumnCount = 4;
						this.TlpProgress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
						this.TlpProgress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
						this.TlpProgress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
						this.TlpProgress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
						this.TlpProgress.Controls.Add(this.pictureBox2, 0, 4);
						this.TlpProgress.Controls.Add(this.TbSheetAuthor, 2, 0);
						this.TlpProgress.Controls.Add(this.TbSheetRevisor, 2, 2);
						this.TlpProgress.Controls.Add(this.PbSheetAuthor, 0, 0);
						this.TlpProgress.Controls.Add(this.PbSheetRevisor, 0, 2);
						this.TlpProgress.Controls.Add(this.label4, 1, 0);
						this.TlpProgress.Controls.Add(this.pictureBox1, 0, 1);
						this.TlpProgress.Controls.Add(this.label5, 1, 1);
						this.TlpProgress.Controls.Add(this.label6, 1, 2);
						this.TlpProgress.Controls.Add(this.label7, 1, 4);
						this.TlpProgress.Controls.Add(this.TbVerified, 2, 1);
						this.TlpProgress.Controls.Add(this.TbLocked, 2, 4);
						this.TlpProgress.Controls.Add(this.PbAdd, 3, 0);
						this.TlpProgress.Controls.Add(this.PbVerify, 3, 1);
						this.TlpProgress.Controls.Add(this.PbReview, 3, 2);
						this.TlpProgress.Controls.Add(this.PbLock, 3, 4);
						this.TlpProgress.Dock = System.Windows.Forms.DockStyle.Fill;
						this.TlpProgress.Location = new System.Drawing.Point(3, 16);
						this.TlpProgress.Name = "TlpProgress";
						this.TlpProgress.RowCount = 5;
						this.TlpProgress.RowStyles.Add(new System.Windows.Forms.RowStyle());
						this.TlpProgress.RowStyles.Add(new System.Windows.Forms.RowStyle());
						this.TlpProgress.RowStyles.Add(new System.Windows.Forms.RowStyle());
						this.TlpProgress.RowStyles.Add(new System.Windows.Forms.RowStyle());
						this.TlpProgress.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
						this.TlpProgress.Size = new System.Drawing.Size(256, 120);
						this.TlpProgress.TabIndex = 1;
						// 
						// pictureBox2
						// 
						this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
						this.pictureBox2.Location = new System.Drawing.Point(3, 93);
						this.pictureBox2.Name = "pictureBox2";
						this.pictureBox2.Size = new System.Drawing.Size(24, 24);
						this.pictureBox2.TabIndex = 23;
						this.pictureBox2.TabStop = false;
						this.TT.SetToolTip(this.pictureBox2, "Sheet Revisor");
						// 
						// TbSheetAuthor
						// 
						this.TbSheetAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
						this.TbSheetAuthor.Enabled = false;
						this.TbSheetAuthor.Location = new System.Drawing.Point(96, 5);
						this.TbSheetAuthor.Name = "TbSheetAuthor";
						this.TbSheetAuthor.Size = new System.Drawing.Size(133, 20);
						this.TbSheetAuthor.TabIndex = 5;
						// 
						// TbSheetRevisor
						// 
						this.TbSheetRevisor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
						this.TbSheetRevisor.Enabled = false;
						this.TbSheetRevisor.Location = new System.Drawing.Point(96, 65);
						this.TbSheetRevisor.Name = "TbSheetRevisor";
						this.TbSheetRevisor.Size = new System.Drawing.Size(133, 20);
						this.TbSheetRevisor.TabIndex = 6;
						// 
						// PbSheetAuthor
						// 
						this.PbSheetAuthor.Image = ((System.Drawing.Image)(resources.GetObject("PbSheetAuthor.Image")));
						this.PbSheetAuthor.Location = new System.Drawing.Point(3, 3);
						this.PbSheetAuthor.Name = "PbSheetAuthor";
						this.PbSheetAuthor.Size = new System.Drawing.Size(24, 24);
						this.PbSheetAuthor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
						this.PbSheetAuthor.TabIndex = 8;
						this.PbSheetAuthor.TabStop = false;
						this.TT.SetToolTip(this.PbSheetAuthor, "Sheet Author");
						// 
						// PbSheetRevisor
						// 
						this.PbSheetRevisor.Image = ((System.Drawing.Image)(resources.GetObject("PbSheetRevisor.Image")));
						this.PbSheetRevisor.Location = new System.Drawing.Point(3, 63);
						this.PbSheetRevisor.Name = "PbSheetRevisor";
						this.PbSheetRevisor.Size = new System.Drawing.Size(24, 24);
						this.PbSheetRevisor.TabIndex = 9;
						this.PbSheetRevisor.TabStop = false;
						this.TT.SetToolTip(this.PbSheetRevisor, "Sheet Revisor");
						// 
						// label4
						// 
						this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
						this.label4.AutoSize = true;
						this.label4.Location = new System.Drawing.Point(33, 8);
						this.label4.Name = "label4";
						this.label4.Size = new System.Drawing.Size(52, 13);
						this.label4.TabIndex = 19;
						this.label4.Text = "Added by";
						// 
						// pictureBox1
						// 
						this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
						this.pictureBox1.Location = new System.Drawing.Point(3, 33);
						this.pictureBox1.Name = "pictureBox1";
						this.pictureBox1.Size = new System.Drawing.Size(24, 24);
						this.pictureBox1.TabIndex = 20;
						this.pictureBox1.TabStop = false;
						this.TT.SetToolTip(this.pictureBox1, "Sheet Author");
						// 
						// label5
						// 
						this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
						this.label5.AutoSize = true;
						this.label5.Location = new System.Drawing.Point(33, 38);
						this.label5.Name = "label5";
						this.label5.Size = new System.Drawing.Size(56, 13);
						this.label5.TabIndex = 21;
						this.label5.Text = "Verified by";
						// 
						// label6
						// 
						this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
						this.label6.AutoSize = true;
						this.label6.Location = new System.Drawing.Point(33, 68);
						this.label6.Name = "label6";
						this.label6.Size = new System.Drawing.Size(57, 13);
						this.label6.TabIndex = 22;
						this.label6.Text = "Review by";
						// 
						// label7
						// 
						this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
						this.label7.AutoSize = true;
						this.label7.Location = new System.Drawing.Point(33, 98);
						this.label7.Name = "label7";
						this.label7.Size = new System.Drawing.Size(57, 13);
						this.label7.TabIndex = 24;
						this.label7.Text = "Locked by";
						// 
						// TbVerified
						// 
						this.TbVerified.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
						this.TbVerified.Enabled = false;
						this.TbVerified.Location = new System.Drawing.Point(96, 35);
						this.TbVerified.Name = "TbVerified";
						this.TbVerified.Size = new System.Drawing.Size(133, 20);
						this.TbVerified.TabIndex = 25;
						// 
						// TbLocked
						// 
						this.TbLocked.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
						this.TbLocked.Enabled = false;
						this.TbLocked.Location = new System.Drawing.Point(96, 95);
						this.TbLocked.Name = "TbLocked";
						this.TbLocked.Size = new System.Drawing.Size(133, 20);
						this.TbLocked.TabIndex = 26;
						// 
						// PbAdd
						// 
						this.PbAdd.Anchor = System.Windows.Forms.AnchorStyles.Left;
						this.PbAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
						this.PbAdd.Coloration = System.Drawing.Color.Empty;
						this.PbAdd.Cursor = System.Windows.Forms.Cursors.Hand;
						this.PbAdd.Enabled = false;
						this.PbAdd.Image = null;
						this.PbAdd.Location = new System.Drawing.Point(233, 4);
						this.PbAdd.Margin = new System.Windows.Forms.Padding(1);
						this.PbAdd.Name = "PbAdd";
						this.PbAdd.Size = new System.Drawing.Size(22, 22);
						this.PbAdd.SizingMode = ChordEditor.UserControls.ImageButton.SizingModes.FixedSize;
						this.PbAdd.TabIndex = 27;
						this.PbAdd.TabStop = false;
						this.PbAdd.Click += new System.EventHandler(this.PbAdd_Click);
						// 
						// PbVerify
						// 
						this.PbVerify.Anchor = System.Windows.Forms.AnchorStyles.Left;
						this.PbVerify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
						this.PbVerify.Coloration = System.Drawing.Color.Empty;
						this.PbVerify.Cursor = System.Windows.Forms.Cursors.Hand;
						this.PbVerify.Enabled = false;
						this.PbVerify.Image = null;
						this.PbVerify.Location = new System.Drawing.Point(233, 34);
						this.PbVerify.Margin = new System.Windows.Forms.Padding(1);
						this.PbVerify.Name = "PbVerify";
						this.PbVerify.Size = new System.Drawing.Size(22, 22);
						this.PbVerify.SizingMode = ChordEditor.UserControls.ImageButton.SizingModes.FixedSize;
						this.PbVerify.TabIndex = 28;
						this.PbVerify.TabStop = false;
						this.PbVerify.Click += new System.EventHandler(this.PbVerify_Click);
						// 
						// PbReview
						// 
						this.PbReview.Anchor = System.Windows.Forms.AnchorStyles.Left;
						this.PbReview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
						this.PbReview.Coloration = System.Drawing.Color.Empty;
						this.PbReview.Cursor = System.Windows.Forms.Cursors.Hand;
						this.PbReview.Enabled = false;
						this.PbReview.Image = null;
						this.PbReview.Location = new System.Drawing.Point(233, 64);
						this.PbReview.Margin = new System.Windows.Forms.Padding(1);
						this.PbReview.Name = "PbReview";
						this.PbReview.Size = new System.Drawing.Size(22, 22);
						this.PbReview.SizingMode = ChordEditor.UserControls.ImageButton.SizingModes.FixedSize;
						this.PbReview.TabIndex = 29;
						this.PbReview.TabStop = false;
						this.PbReview.Click += new System.EventHandler(this.PbReview_Click);
						// 
						// PbLock
						// 
						this.PbLock.Anchor = System.Windows.Forms.AnchorStyles.Left;
						this.PbLock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
						this.PbLock.Coloration = System.Drawing.Color.Empty;
						this.PbLock.Cursor = System.Windows.Forms.Cursors.Hand;
						this.PbLock.Enabled = false;
						this.PbLock.Image = null;
						this.PbLock.Location = new System.Drawing.Point(233, 94);
						this.PbLock.Margin = new System.Windows.Forms.Padding(1);
						this.PbLock.Name = "PbLock";
						this.PbLock.Size = new System.Drawing.Size(22, 22);
						this.PbLock.SizingMode = ChordEditor.UserControls.ImageButton.SizingModes.FixedSize;
						this.PbLock.TabIndex = 30;
						this.PbLock.TabStop = false;
						this.PbLock.Click += new System.EventHandler(this.PbLock_Click);
						// 
						// GbSongInfo
						// 
						this.GbSongInfo.AutoSize = true;
						this.GbSongInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
						this.GbSongInfo.Controls.Add(this.TlpHeader);
						this.GbSongInfo.Dock = System.Windows.Forms.DockStyle.Fill;
						this.GbSongInfo.Location = new System.Drawing.Point(3, 3);
						this.GbSongInfo.Name = "GbSongInfo";
						this.GbSongInfo.Size = new System.Drawing.Size(262, 124);
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
						this.TlpHeader.Size = new System.Drawing.Size(256, 105);
						this.TlpHeader.TabIndex = 0;
						// 
						// TbTitle
						// 
						this.TbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
						this.TbTitle.Location = new System.Drawing.Point(29, 3);
						this.TbTitle.Name = "TbTitle";
						this.TbTitle.NullString = "<Song Title>";
						this.TbTitle.Size = new System.Drawing.Size(224, 20);
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
						this.TbArtist.Size = new System.Drawing.Size(224, 20);
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
						this.CbCategory.Size = new System.Drawing.Size(224, 21);
						this.CbCategory.TabIndex = 2;
						this.CbCategory.SelectedIndexChanged += new System.EventHandler(this.CbCategory_SelectedIndexChanged);
						// 
						// TbTags
						// 
						this.TbTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
						this.TbTags.Location = new System.Drawing.Point(29, 82);
						this.TbTags.Name = "TbTags";
						this.TbTags.NullString = "<Tags>";
						this.TbTags.Size = new System.Drawing.Size(224, 20);
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
						// SF
						// 
						this.SF.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SF.ImageStream")));
						this.SF.TransparentColor = System.Drawing.Color.Transparent;
						this.SF.Images.SetKeyName(0, "ImgOK");
						this.SF.Images.SetKeyName(1, "ImgKO");
						this.SF.Images.SetKeyName(2, "ImgUNK");
						// 
						// SheetPropertyForm
						// 
						this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
						this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
						this.ClientSize = new System.Drawing.Size(268, 452);
						this.CloseButton = false;
						this.CloseButtonVisible = false;
						this.Controls.Add(this.TlpMain);
						this.DockAreas = ((ChordEditor.UserControls.DockingManager.DockAreas)(((ChordEditor.UserControls.DockingManager.DockAreas.Float | ChordEditor.UserControls.DockingManager.DockAreas.DockLeft) 
            | ChordEditor.UserControls.DockingManager.DockAreas.DockRight)));
						this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
						this.HideOnClose = true;
						this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
						this.Name = "SheetPropertyForm";
						this.TabText = "Property";
						this.Text = "Property";
						this.ToolTipText = "Property";
						this.Load += new System.EventHandler(this.SheetPropertyForm_Load);
						this.TlpMain.ResumeLayout(false);
						this.TlpMain.PerformLayout();
						this.GbTools.ResumeLayout(false);
						this.GbTools.PerformLayout();
						this.tableLayoutPanel3.ResumeLayout(false);
						this.tableLayoutPanel3.PerformLayout();
						this.tableLayoutPanel4.ResumeLayout(false);
						this.GbSheetInfo.ResumeLayout(false);
						this.GbSheetInfo.PerformLayout();
						this.TlpProgress.ResumeLayout(false);
						this.TlpProgress.PerformLayout();
						((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
						((System.ComponentModel.ISupportInitialize)(this.PbSheetAuthor)).EndInit();
						((System.ComponentModel.ISupportInitialize)(this.PbSheetRevisor)).EndInit();
						((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
		private System.Windows.Forms.TableLayoutPanel TlpProgress;
        private System.Windows.Forms.GroupBox GbSheetInfo;
        private System.Windows.Forms.GroupBox GbSongInfo;
        private System.Windows.Forms.PictureBox PbSongTitle;
        private System.Windows.Forms.PictureBox PbArtist;
        private System.Windows.Forms.PictureBox PbCategory;
        private System.Windows.Forms.PictureBox PbTags;
        private System.Windows.Forms.ToolTip TT;
        private System.Windows.Forms.PictureBox PbSheetAuthor;
		private System.Windows.Forms.PictureBox PbSheetRevisor;
        private System.Windows.Forms.GroupBox GbTools;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private UserControls.ImageButton PbNotation;
        private System.Windows.Forms.ImageList NF;
        private System.Windows.Forms.Label label2;
        private UserControls.ImageButton PbTrasposeDown;
        private UserControls.ImageButton PbTrasposeUp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CbSemitoni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private UserControls.ImageButton PbNormalized;
		private System.Windows.Forms.ImageList SF;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.TextBox TbSheetAuthor;
		private System.Windows.Forms.TextBox TbSheetRevisor;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox TbVerified;
		private System.Windows.Forms.TextBox TbLocked;
		private UserControls.ImageButton PbAdd;
		private UserControls.ImageButton PbVerify;
		private UserControls.ImageButton PbReview;
		private UserControls.ImageButton PbLock;
	}
}