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
            ((System.ComponentModel.ISupportInitialize)(this.TB)).BeginInit();
            this.SuspendLayout();
            // 
            // TB
            // 
            this.TB.AutoCompleteBrackets = true;
            this.TB.AutoCompleteBracketsList = new char[] {
        '{',
        '}',
        '[',
        ']'};
            this.TB.AutoIndent = false;
            this.TB.AutoIndentChars = false;
            this.TB.AutoIndentExistingLines = false;
            this.TB.AutoScrollMinSize = new System.Drawing.Size(18, 30);
            this.TB.BackBrush = null;
            this.TB.CharHeight = 14;
            this.TB.CharWidth = 8;
            this.TB.CommentPrefix = "#";
            this.TB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB.IsReplaceMode = false;
            this.TB.Location = new System.Drawing.Point(0, 0);
            this.TB.Name = "TB";
            this.TB.Paddings = new System.Windows.Forms.Padding(8);
            this.TB.PreferredLineWidth = 60;
            this.TB.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(255)))));
            this.TB.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("TB.ServiceColors")));
            this.TB.ShowLineNumbers = false;
            this.TB.Size = new System.Drawing.Size(672, 503);
            this.TB.TabIndex = 0;
            this.TB.Zoom = 100;
            this.TB.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.TB_TextChangedDelayed);
            // 
            // SheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 503);
            this.Controls.Add(this.TB);
            this.DockAreas = ChordEditor.UserControls.DockingManager.DockAreas.Document;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SheetForm";
            this.TabText = "";
            this.Text = "New sheet";
            this.ToolTipText = "";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SheetForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SheetForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.TB)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private FastColoredTextBoxNS.FastColoredTextBox TB;
	}
}