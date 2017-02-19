namespace ChordEditor.Forms
{
    partial class SheetDatabase
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
						System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SheetDatabase));
						this.LV = new BrightIdeasSoftware.ObjectListView();
						this.ChTitle = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
						this.ChProgress = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
						this.ChArtist = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
						this.ChCategory = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
						this.ChAuthor = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
						this.ChRevisor = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
						this.ChStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
						this.IL = new System.Windows.Forms.ImageList(this.components);
						this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
						this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
						this.BtnUndelete = new System.Windows.Forms.Button();
						this.BtnDelete = new System.Windows.Forms.Button();
						this.BtnOpen = new System.Windows.Forms.Button();
						this.BtnNew = new System.Windows.Forms.Button();
						this.BtnErase = new System.Windows.Forms.Button();
						this.MMS = new System.Windows.Forms.MenuStrip();
						this.MMnAdmin = new System.Windows.Forms.ToolStripMenuItem();
						this.MMNShowHistory = new System.Windows.Forms.ToolStripMenuItem();
						((System.ComponentModel.ISupportInitialize)(this.LV)).BeginInit();
						this.tableLayoutPanel1.SuspendLayout();
						this.tableLayoutPanel2.SuspendLayout();
						this.MMS.SuspendLayout();
						this.SuspendLayout();
						// 
						// LV
						// 
						this.LV.AllColumns.Add(this.ChTitle);
						this.LV.AllColumns.Add(this.ChProgress);
						this.LV.AllColumns.Add(this.ChArtist);
						this.LV.AllColumns.Add(this.ChCategory);
						this.LV.AllColumns.Add(this.ChAuthor);
						this.LV.AllColumns.Add(this.ChRevisor);
						this.LV.AllColumns.Add(this.ChStatus);
						this.LV.CellEditUseWholeCell = false;
						this.LV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ChTitle,
            this.ChProgress,
            this.ChArtist,
            this.ChCategory,
            this.ChAuthor,
            this.ChRevisor,
            this.ChStatus});
						this.LV.Cursor = System.Windows.Forms.Cursors.Default;
						this.LV.Dock = System.Windows.Forms.DockStyle.Fill;
						this.LV.EmptyListMsg = "";
						this.LV.FullRowSelect = true;
						this.LV.GridLines = true;
						this.LV.GroupWithItemCountFormat = "";
						this.LV.GroupWithItemCountSingularFormat = "";
						this.LV.HideSelection = false;
						this.LV.Location = new System.Drawing.Point(3, 3);
						this.LV.Name = "LV";
						this.LV.RowHeight = 26;
						this.LV.SelectColumnsOnRightClick = false;
						this.LV.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
						this.LV.SelectedBackColor = System.Drawing.Color.Gainsboro;
						this.LV.SelectedForeColor = System.Drawing.Color.Black;
						this.LV.Size = new System.Drawing.Size(777, 422);
						this.LV.SmallImageList = this.IL;
						this.LV.TabIndex = 1;
						this.LV.UseCompatibleStateImageBehavior = false;
						this.LV.UseFiltering = true;
						this.LV.UseHotItem = true;
						this.LV.UseTranslucentHotItem = true;
						this.LV.View = System.Windows.Forms.View.Details;
						this.LV.BeforeSearching += new System.EventHandler<BrightIdeasSoftware.BeforeSearchingEventArgs>(this.LV_BeforeSearching);
						this.LV.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.LV_FormatRow);
						this.LV.SelectionChanged += new System.EventHandler(this.LV_SelectionChanged);
						this.LV.ItemActivate += new System.EventHandler(this.LV_ItemActivate);
						this.LV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LV_KeyDown);
						// 
						// ChTitle
						// 
						this.ChTitle.AspectName = "Title";
						this.ChTitle.DisplayIndex = 1;
						this.ChTitle.Text = "Title";
						this.ChTitle.UseInitialLetterForGroup = true;
						this.ChTitle.Width = 200;
						// 
						// ChProgress
						// 
						this.ChProgress.AspectName = "Progress";
						this.ChProgress.AspectToStringFormat = "";
						this.ChProgress.DisplayIndex = 0;
						this.ChProgress.Text = "Prog";
						this.ChProgress.Width = 40;
						// 
						// ChArtist
						// 
						this.ChArtist.AspectName = "Artist";
						this.ChArtist.Text = "Artist";
						this.ChArtist.Width = 160;
						// 
						// ChCategory
						// 
						this.ChCategory.AspectName = "SheetCategory";
						this.ChCategory.Text = "Category";
						this.ChCategory.Width = 100;
						// 
						// ChAuthor
						// 
						this.ChAuthor.AspectName = "SheetAuthor";
						this.ChAuthor.Text = "Added by";
						this.ChAuthor.Width = 160;
						// 
						// ChRevisor
						// 
						this.ChRevisor.AspectName = "SheetRVName";
						this.ChRevisor.Text = "Revisor or Verifier";
						this.ChRevisor.Width = 160;
						// 
						// ChStatus
						// 
						this.ChStatus.AspectName = "StatusString";
						this.ChStatus.FillsFreeSpace = true;
						this.ChStatus.Text = "Status";
						// 
						// IL
						// 
						this.IL.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IL.ImageStream")));
						this.IL.TransparentColor = System.Drawing.Color.White;
						this.IL.Images.SetKeyName(0, "deleted");
						this.IL.Images.SetKeyName(1, "added");
						this.IL.Images.SetKeyName(2, "verified");
						this.IL.Images.SetKeyName(3, "reviewed");
						this.IL.Images.SetKeyName(4, "locked");
						// 
						// tableLayoutPanel1
						// 
						this.tableLayoutPanel1.ColumnCount = 1;
						this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
						this.tableLayoutPanel1.Controls.Add(this.LV, 0, 0);
						this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
						this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
						this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
						this.tableLayoutPanel1.Name = "tableLayoutPanel1";
						this.tableLayoutPanel1.RowCount = 2;
						this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
						this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
						this.tableLayoutPanel1.Size = new System.Drawing.Size(783, 480);
						this.tableLayoutPanel1.TabIndex = 2;
						// 
						// tableLayoutPanel2
						// 
						this.tableLayoutPanel2.AutoSize = true;
						this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
						this.tableLayoutPanel2.ColumnCount = 7;
						this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
						this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
						this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
						this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
						this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
						this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
						this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
						this.tableLayoutPanel2.Controls.Add(this.BtnUndelete, 0, 0);
						this.tableLayoutPanel2.Controls.Add(this.BtnDelete, 0, 0);
						this.tableLayoutPanel2.Controls.Add(this.BtnOpen, 6, 0);
						this.tableLayoutPanel2.Controls.Add(this.BtnNew, 5, 0);
						this.tableLayoutPanel2.Controls.Add(this.BtnErase, 3, 0);
						this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
						this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 431);
						this.tableLayoutPanel2.Name = "tableLayoutPanel2";
						this.tableLayoutPanel2.RowCount = 1;
						this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
						this.tableLayoutPanel2.Size = new System.Drawing.Size(777, 46);
						this.tableLayoutPanel2.TabIndex = 2;
						// 
						// BtnUndelete
						// 
						this.BtnUndelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
						this.BtnUndelete.Enabled = false;
						this.BtnUndelete.Image = ((System.Drawing.Image)(resources.GetObject("BtnUndelete.Image")));
						this.BtnUndelete.Location = new System.Drawing.Point(98, 3);
						this.BtnUndelete.Name = "BtnUndelete";
						this.BtnUndelete.Size = new System.Drawing.Size(109, 40);
						this.BtnUndelete.TabIndex = 3;
						this.BtnUndelete.Text = "UnDelete";
						this.BtnUndelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
						this.BtnUndelete.UseVisualStyleBackColor = true;
						this.BtnUndelete.Click += new System.EventHandler(this.BtnUndelete_Click);
						// 
						// BtnDelete
						// 
						this.BtnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
						this.BtnDelete.Enabled = false;
						this.BtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("BtnDelete.Image")));
						this.BtnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
						this.BtnDelete.Location = new System.Drawing.Point(3, 3);
						this.BtnDelete.Name = "BtnDelete";
						this.BtnDelete.Size = new System.Drawing.Size(89, 40);
						this.BtnDelete.TabIndex = 2;
						this.BtnDelete.Text = "Delete";
						this.BtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
						this.BtnDelete.UseVisualStyleBackColor = true;
						this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
						// 
						// BtnOpen
						// 
						this.BtnOpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
						this.BtnOpen.Enabled = false;
						this.BtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("BtnOpen.Image")));
						this.BtnOpen.Location = new System.Drawing.Point(685, 3);
						this.BtnOpen.Name = "BtnOpen";
						this.BtnOpen.Size = new System.Drawing.Size(89, 40);
						this.BtnOpen.TabIndex = 0;
						this.BtnOpen.Text = "Open";
						this.BtnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
						this.BtnOpen.UseVisualStyleBackColor = true;
						this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
						// 
						// BtnNew
						// 
						this.BtnNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
						this.BtnNew.Image = ((System.Drawing.Image)(resources.GetObject("BtnNew.Image")));
						this.BtnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
						this.BtnNew.Location = new System.Drawing.Point(590, 3);
						this.BtnNew.Name = "BtnNew";
						this.BtnNew.Size = new System.Drawing.Size(89, 40);
						this.BtnNew.TabIndex = 1;
						this.BtnNew.Text = "New";
						this.BtnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
						this.BtnNew.UseVisualStyleBackColor = true;
						this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
						// 
						// BtnErase
						// 
						this.BtnErase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
						this.BtnErase.Enabled = false;
						this.BtnErase.Image = ((System.Drawing.Image)(resources.GetObject("BtnErase.Image")));
						this.BtnErase.Location = new System.Drawing.Point(233, 3);
						this.BtnErase.Name = "BtnErase";
						this.BtnErase.Size = new System.Drawing.Size(89, 40);
						this.BtnErase.TabIndex = 4;
						this.BtnErase.Text = "Erase";
						this.BtnErase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
						this.BtnErase.UseVisualStyleBackColor = true;
						this.BtnErase.Visible = false;
						this.BtnErase.Click += new System.EventHandler(this.BtnErase_Click);
						// 
						// MMS
						// 
						this.MMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MMnAdmin});
						this.MMS.Location = new System.Drawing.Point(0, 0);
						this.MMS.Name = "MMS";
						this.MMS.Size = new System.Drawing.Size(783, 24);
						this.MMS.TabIndex = 4;
						this.MMS.Text = "menuStrip1";
						this.MMS.Visible = false;
						// 
						// MMnAdmin
						// 
						this.MMnAdmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MMNShowHistory});
						this.MMnAdmin.MergeAction = System.Windows.Forms.MergeAction.Insert;
						this.MMnAdmin.MergeIndex = 1;
						this.MMnAdmin.Name = "MMnAdmin";
						this.MMnAdmin.Size = new System.Drawing.Size(80, 20);
						this.MMnAdmin.Text = "&SVN Admin";
						// 
						// MMNShowHistory
						// 
						this.MMNShowHistory.Name = "MMNShowHistory";
						this.MMNShowHistory.Size = new System.Drawing.Size(137, 22);
						this.MMNShowHistory.Text = "SVN History";
						this.MMNShowHistory.Click += new System.EventHandler(this.MMNShowHistory_Click);
						// 
						// SheetDatabase
						// 
						this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
						this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
						this.ClientSize = new System.Drawing.Size(783, 480);
						this.CloseButton = false;
						this.CloseButtonVisible = false;
						this.Controls.Add(this.MMS);
						this.Controls.Add(this.tableLayoutPanel1);
						this.DockAreas = ChordEditor.UserControls.DockingManager.DockAreas.Document;
						this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
						this.HideOnClose = true;
						this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
						this.Name = "SheetDatabase";
						this.TabText = "Sheet Database";
						this.Text = "Sheet Database";
						this.ToolTipText = "Sheet Database";
						this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SheetDatabase_FormClosing);
						this.Load += new System.EventHandler(this.SheetDatabase_Load);
						this.Shown += new System.EventHandler(this.SheetDatabase_Shown);
						((System.ComponentModel.ISupportInitialize)(this.LV)).EndInit();
						this.tableLayoutPanel1.ResumeLayout(false);
						this.tableLayoutPanel1.PerformLayout();
						this.tableLayoutPanel2.ResumeLayout(false);
						this.MMS.ResumeLayout(false);
						this.MMS.PerformLayout();
						this.ResumeLayout(false);
						this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView LV;
        private BrightIdeasSoftware.OLVColumn ChTitle;
        private BrightIdeasSoftware.OLVColumn ChArtist;
        private BrightIdeasSoftware.OLVColumn ChAuthor;
        private BrightIdeasSoftware.OLVColumn ChRevisor;
        private BrightIdeasSoftware.OLVColumn ChCategory;
        private System.Windows.Forms.ImageList IL;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BtnOpen;
        private System.Windows.Forms.Button BtnNew;
        private System.Windows.Forms.Button BtnDelete;
		private BrightIdeasSoftware.OLVColumn ChStatus;
		private BrightIdeasSoftware.OLVColumn ChProgress;
		private System.Windows.Forms.Button BtnUndelete;
		private System.Windows.Forms.Button BtnErase;
		private System.Windows.Forms.MenuStrip MMS;
		private System.Windows.Forms.ToolStripMenuItem MMnAdmin;
		private System.Windows.Forms.ToolStripMenuItem MMNShowHistory;
    }
}