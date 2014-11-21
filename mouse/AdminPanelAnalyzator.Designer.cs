namespace mysz
{
    partial class AdminPanelAnalyzator
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
            this.clearButton = new System.Windows.Forms.Button();
            this.showButton = new System.Windows.Forms.Button();
            this.showRightCheckBox = new System.Windows.Forms.CheckBox();
            this.fileViewer = new System.Windows.Forms.TreeView();
            this.showLeftCheckBox = new System.Windows.Forms.CheckBox();
            this.coordinatesViewer = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coordinatesViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.clearButton);
            this.panel1.Controls.Add(this.showButton);
            this.panel1.Controls.Add(this.showRightCheckBox);
            this.panel1.Controls.Add(this.fileViewer);
            this.panel1.Controls.Add(this.showLeftCheckBox);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 604);
            this.panel1.TabIndex = 0;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(58, 35);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(49, 23);
            this.clearButton.TabIndex = 12;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(3, 35);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(49, 23);
            this.showButton.TabIndex = 4;
            this.showButton.Text = "Show";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // showRightCheckBox
            // 
            this.showRightCheckBox.AutoSize = true;
            this.showRightCheckBox.Location = new System.Drawing.Point(112, 3);
            this.showRightCheckBox.Name = "showRightCheckBox";
            this.showRightCheckBox.Size = new System.Drawing.Size(81, 17);
            this.showRightCheckBox.TabIndex = 3;
            this.showRightCheckBox.Text = "Show Right";
            this.showRightCheckBox.UseVisualStyleBackColor = true;
            // 
            // fileViewer
            // 
            this.fileViewer.Location = new System.Drawing.Point(3, 74);
            this.fileViewer.Name = "fileViewer";
            this.fileViewer.Size = new System.Drawing.Size(237, 523);
            this.fileViewer.TabIndex = 1;
            this.fileViewer.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.fileViewer_AfterCheck);
            this.fileViewer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.fileViewer_AfterSelect);
            // 
            // showLeftCheckBox
            // 
            this.showLeftCheckBox.AutoSize = true;
            this.showLeftCheckBox.Location = new System.Drawing.Point(3, 3);
            this.showLeftCheckBox.Name = "showLeftCheckBox";
            this.showLeftCheckBox.Size = new System.Drawing.Size(74, 17);
            this.showLeftCheckBox.TabIndex = 2;
            this.showLeftCheckBox.Text = "Show Left";
            this.showLeftCheckBox.UseVisualStyleBackColor = true;
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
            // AdminPanelAnalyzator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 628);
            this.Controls.Add(this.coordinatesViewer);
            this.Controls.Add(this.panel1);
            this.Name = "AdminPanelAnalyzator";
            this.Text = "AdminPanelAnalyzator";
            this.Load += new System.EventHandler(this.AdminPanelAnalyzator_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coordinatesViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView fileViewer;
        private System.Windows.Forms.CheckBox showRightCheckBox;
        private System.Windows.Forms.CheckBox showLeftCheckBox;
        private System.Windows.Forms.PictureBox coordinatesViewer;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button showButton;
    }
}