namespace ChordEditor.Forms
{
	partial class LogMessageForm
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
						System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogMessageForm));
						this.fctb = new FastColoredTextBoxNS.FastColoredTextBox();
						((System.ComponentModel.ISupportInitialize)(this.fctb)).BeginInit();
						this.SuspendLayout();
						// 
						// fctb
						// 
						this.fctb.AutoCompleteBrackets = true;
						this.fctb.AutoCompleteBracketsList = new char[] {
        '{',
        '}',
        '[',
        ']'};
						this.fctb.AutoIndent = false;
						this.fctb.AutoIndentChars = false;
						this.fctb.AutoIndentExistingLines = false;
						this.fctb.AutoScrollMinSize = new System.Drawing.Size(18, 30);
						this.fctb.BackBrush = null;
						this.fctb.CharHeight = 14;
						this.fctb.CharWidth = 8;
						this.fctb.CommentPrefix = "#";
						this.fctb.Cursor = System.Windows.Forms.Cursors.IBeam;
						this.fctb.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
						this.fctb.Dock = System.Windows.Forms.DockStyle.Fill;
						this.fctb.Font = new System.Drawing.Font("Courier New", 9.75F);
						this.fctb.Hotkeys = resources.GetString("fctb.Hotkeys");
						this.fctb.IsReplaceMode = false;
						this.fctb.Location = new System.Drawing.Point(0, 0);
						this.fctb.Name = "fctb";
						this.fctb.Paddings = new System.Windows.Forms.Padding(8);
						this.fctb.ReadOnly = true;
						this.fctb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(255)))));
						this.fctb.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctb.ServiceColors")));
						this.fctb.ShowLineNumbers = false;
						this.fctb.Size = new System.Drawing.Size(829, 294);
						this.fctb.TabIndex = 1;
						this.fctb.TabLength = 10;
						this.fctb.Zoom = 100;
						this.fctb.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fctb_TextChanged);
						// 
						// LogMessageForm
						// 
						this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
						this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
						this.ClientSize = new System.Drawing.Size(829, 294);
						this.CloseButton = false;
						this.CloseButtonVisible = false;
						this.Controls.Add(this.fctb);
						this.DockAreas = ((ChordEditor.UserControls.DockingManager.DockAreas)((ChordEditor.UserControls.DockingManager.DockAreas.Float | ChordEditor.UserControls.DockingManager.DockAreas.DockBottom)));
						this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
						this.HideOnClose = true;
						this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
						this.Name = "LogMessageForm";
						this.TabText = "Messages";
						this.Text = "Messages";
						this.ToolTipText = "Messages";
						((System.ComponentModel.ISupportInitialize)(this.fctb)).EndInit();
						this.ResumeLayout(false);

		}

		#endregion

        private FastColoredTextBoxNS.FastColoredTextBox fctb;
	}
}