namespace mysz
{
    partial class VisualizeCoordinatesWindow
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.fileViewer = new System.Windows.Forms.TreeView();
            this.coordinatesViewer = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coordinatesViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.fileViewer);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 604);
            this.panel1.TabIndex = 0;
            // 
            // fileViewer
            // 
            this.fileViewer.Location = new System.Drawing.Point(3, 3);
            this.fileViewer.Name = "fileViewer";
            this.fileViewer.Size = new System.Drawing.Size(237, 594);
            this.fileViewer.TabIndex = 1;
            this.fileViewer.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.fileViewer_AfterCheck);
            this.fileViewer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.fileViewer_AfterSelect);
            // 
            // coordinatesViewer
            // 
            this.coordinatesViewer.BackColor = System.Drawing.Color.Black;
            this.coordinatesViewer.Location = new System.Drawing.Point(265, 11);
            this.coordinatesViewer.Name = "coordinatesViewer";
            this.coordinatesViewer.Size = new System.Drawing.Size(800, 600);
            this.coordinatesViewer.TabIndex = 11;
            this.coordinatesViewer.TabStop = false;
            // 
            // VisualizeCoordinatesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 628);
            this.Controls.Add(this.coordinatesViewer);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1093, 667);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1093, 667);
            this.Name = "VisualizeCoordinatesWindow";
            this.Text = "Visualise coordinates";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VisualizeCoordinatesWindow_FormClosing);
            this.Load += new System.EventHandler(this.VisualizeCoordinatesWindow_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.coordinatesViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView fileViewer;
        private System.Windows.Forms.PictureBox coordinatesViewer;
    }
}