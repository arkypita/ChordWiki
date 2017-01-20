namespace ChordEditor.Forms
{
	partial class PendingChangesForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private BrightIdeasSoftware.ObjectListView panel1;

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
            this.panel1 = new BrightIdeasSoftware.ObjectListView();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.CellEditUseWholeCell = false;
            this.panel1.CheckBoxes = true;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.EmptyListMsg = "";
            this.panel1.GridLines = true;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(829, 294);
            this.panel1.TabIndex = 0;
            this.panel1.UseCompatibleStateImageBehavior = false;
            this.panel1.View = System.Windows.Forms.View.List;
            // 
            // PendingChangesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 294);
            this.Controls.Add(this.panel1);
            this.DockAreas = ((ChordEditor.UserControls.DockingManager.DockAreas)((ChordEditor.UserControls.DockingManager.DockAreas.Float | ChordEditor.UserControls.DockingManager.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Name = "PendingChangesForm";
            this.TabText = "Pending Changes";
            this.Text = "Pending Changes";
            this.ToolTipText = "Pending Changes";
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion
	}
}