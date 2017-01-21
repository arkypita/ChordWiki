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
            this.TlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.TlpHeader = new System.Windows.Forms.TableLayoutPanel();
            this.LblTitle = new System.Windows.Forms.Label();
            this.LblArtist = new System.Windows.Forms.Label();
            this.TbTitle = new System.Windows.Forms.TextBox();
            this.TbArtist = new System.Windows.Forms.TextBox();
            this.TlpMain.SuspendLayout();
            this.TlpHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // TlpMain
            // 
            this.TlpMain.ColumnCount = 1;
            this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpMain.Controls.Add(this.TlpHeader, 0, 0);
            this.TlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpMain.Enabled = false;
            this.TlpMain.Location = new System.Drawing.Point(0, 0);
            this.TlpMain.Name = "TlpMain";
            this.TlpMain.RowCount = 2;
            this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpMain.Size = new System.Drawing.Size(284, 261);
            this.TlpMain.TabIndex = 0;
            // 
            // TlpHeader
            // 
            this.TlpHeader.AutoSize = true;
            this.TlpHeader.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TlpHeader.ColumnCount = 2;
            this.TlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpHeader.Controls.Add(this.LblTitle, 0, 0);
            this.TlpHeader.Controls.Add(this.LblArtist, 0, 1);
            this.TlpHeader.Controls.Add(this.TbTitle, 1, 0);
            this.TlpHeader.Controls.Add(this.TbArtist, 1, 1);
            this.TlpHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpHeader.Location = new System.Drawing.Point(3, 3);
            this.TlpHeader.Name = "TlpHeader";
            this.TlpHeader.RowCount = 2;
            this.TlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpHeader.Size = new System.Drawing.Size(278, 52);
            this.TlpHeader.TabIndex = 0;
            // 
            // LblTitle
            // 
            this.LblTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblTitle.AutoSize = true;
            this.LblTitle.Location = new System.Drawing.Point(3, 6);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(27, 13);
            this.LblTitle.TabIndex = 0;
            this.LblTitle.Text = "Title";
            // 
            // LblArtist
            // 
            this.LblArtist.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblArtist.AutoSize = true;
            this.LblArtist.Location = new System.Drawing.Point(3, 32);
            this.LblArtist.Name = "LblArtist";
            this.LblArtist.Size = new System.Drawing.Size(30, 13);
            this.LblArtist.TabIndex = 1;
            this.LblArtist.Text = "Artist";
            // 
            // TbTitle
            // 
            this.TbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbTitle.Location = new System.Drawing.Point(39, 3);
            this.TbTitle.Name = "TbTitle";
            this.TbTitle.Size = new System.Drawing.Size(236, 20);
            this.TbTitle.TabIndex = 2;
            this.TbTitle.TextChanged += new System.EventHandler(this.TbTitle_TextChanged);
            // 
            // TbArtist
            // 
            this.TbArtist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbArtist.Location = new System.Drawing.Point(39, 29);
            this.TbArtist.Name = "TbArtist";
            this.TbArtist.Size = new System.Drawing.Size(236, 20);
            this.TbArtist.TabIndex = 3;
            this.TbArtist.TextChanged += new System.EventHandler(this.TbArtist_TextChanged);
            // 
            // SheetPropertyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
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
            this.TlpHeader.ResumeLayout(false);
            this.TlpHeader.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.TableLayoutPanel TlpMain;
        private System.Windows.Forms.TableLayoutPanel TlpHeader;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.Label LblArtist;
        private System.Windows.Forms.TextBox TbTitle;
        private System.Windows.Forms.TextBox TbArtist;
	}
}