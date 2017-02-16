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
						this.ChProgress = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
						this.ChTitle = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
						this.ChArtist = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
						this.ChCategory = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
						this.ChAuthor = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
						this.ChRevisor = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
						this.ChStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
						this.IL = new System.Windows.Forms.ImageList(this.components);
						this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
						this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
						this.BtnDelete = new System.Windows.Forms.Button();
						this.BtnOpen = new System.Windows.Forms.Button();
						this.BtnNew = new System.Windows.Forms.Button();
						((System.ComponentModel.ISupportInitialize)(this.LV)).BeginInit();
						this.tableLayoutPanel1.SuspendLayout();
						this.tableLayoutPanel2.SuspendLayout();
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
						this.LV.Location = new System.Drawing.Point(3, 3);
						this.LV.Name = "LV";
						this.LV.RowHeight = 26;
						this.LV.SelectColumnsOnRightClick = false;
						this.LV.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
						this.LV.SelectedBackColor = System.Drawing.Color.Gainsboro;
						this.LV.SelectedForeColor = System.Drawing.Color.Black;
						this.LV.Size = new System.Drawing.Size(777, 425);
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
						// ChProgress
						// 
						this.ChProgress.AspectName = "Progress";
						this.ChProgress.AspectToStringFormat = "";
						this.ChProgress.DisplayIndex = 0;
						this.ChProgress.Text = "Prog";
						this.ChProgress.Width = 40;
						// 
						// ChTitle
						// 
						this.ChTitle.AspectName = "Title";
						this.ChTitle.DisplayIndex = 1;
						this.ChTitle.Text = "Title";
						this.ChTitle.UseInitialLetterForGroup = true;
						this.ChTitle.Width = 200;
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
						this.IL.TransparentColor = System.Drawing.Color.Transparent;
						this.IL.Images.SetKeyName(0, "incomplete");
						this.IL.Images.SetKeyName(1, "suspended");
						this.IL.Images.SetKeyName(2, "verified");
						this.IL.Images.SetKeyName(3, "locked");
						this.IL.Images.SetKeyName(4, "deleted");
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
						this.tableLayoutPanel2.ColumnCount = 4;
						this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
						this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
						this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
						this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
						this.tableLayoutPanel2.Controls.Add(this.BtnDelete, 0, 0);
						this.tableLayoutPanel2.Controls.Add(this.BtnOpen, 3, 0);
						this.tableLayoutPanel2.Controls.Add(this.BtnNew, 2, 0);
						this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
						this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 434);
						this.tableLayoutPanel2.Name = "tableLayoutPanel2";
						this.tableLayoutPanel2.RowCount = 1;
						this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
						this.tableLayoutPanel2.Size = new System.Drawing.Size(777, 43);
						this.tableLayoutPanel2.TabIndex = 2;
						// 
						// BtnDelete
						// 
						this.BtnDelete.Enabled = false;
						this.BtnDelete.Location = new System.Drawing.Point(3, 3);
						this.BtnDelete.Name = "BtnDelete";
						this.BtnDelete.Size = new System.Drawing.Size(89, 37);
						this.BtnDelete.TabIndex = 2;
						this.BtnDelete.Text = "Delete";
						this.BtnDelete.UseVisualStyleBackColor = true;
						this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
						// 
						// BtnOpen
						// 
						this.BtnOpen.Enabled = false;
						this.BtnOpen.Location = new System.Drawing.Point(685, 3);
						this.BtnOpen.Name = "BtnOpen";
						this.BtnOpen.Size = new System.Drawing.Size(89, 37);
						this.BtnOpen.TabIndex = 0;
						this.BtnOpen.Text = "Open";
						this.BtnOpen.UseVisualStyleBackColor = true;
						this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
						// 
						// BtnNew
						// 
						this.BtnNew.Location = new System.Drawing.Point(590, 3);
						this.BtnNew.Name = "BtnNew";
						this.BtnNew.Size = new System.Drawing.Size(89, 37);
						this.BtnNew.TabIndex = 1;
						this.BtnNew.Text = "New";
						this.BtnNew.UseVisualStyleBackColor = true;
						this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
						// 
						// SheetDatabase
						// 
						this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
						this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
						this.ClientSize = new System.Drawing.Size(783, 480);
						this.CloseButton = false;
						this.CloseButtonVisible = false;
						this.Controls.Add(this.tableLayoutPanel1);
						this.DockAreas = ChordEditor.UserControls.DockingManager.DockAreas.Document;
						this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
						this.HideOnClose = true;
						this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
						this.Name = "SheetDatabase";
						this.TabText = "Sheet Database";
						this.Text = "Sheet Database";
						this.ToolTipText = "Sheet Database";
						this.Load += new System.EventHandler(this.SheetDatabase_Load);
						((System.ComponentModel.ISupportInitialize)(this.LV)).EndInit();
						this.tableLayoutPanel1.ResumeLayout(false);
						this.tableLayoutPanel1.PerformLayout();
						this.tableLayoutPanel2.ResumeLayout(false);
						this.ResumeLayout(false);

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
    }
}