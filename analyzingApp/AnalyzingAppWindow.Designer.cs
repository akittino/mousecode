namespace analyzingApp
{
    partial class analyzingAppWindow
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
            this.listboxBase = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.listboxToAdd = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fileViewer);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 604);
            this.panel1.TabIndex = 0;
            // 
            // fileViewer
            // 
            this.fileViewer.Location = new System.Drawing.Point(3, 3);
            this.fileViewer.Name = "fileViewer";
            this.fileViewer.Size = new System.Drawing.Size(228, 598);
            this.fileViewer.TabIndex = 0;
            // 
            // listboxBase
            // 
            this.listboxBase.FormattingEnabled = true;
            this.listboxBase.Location = new System.Drawing.Point(293, 44);
            this.listboxBase.Name = "listboxBase";
            this.listboxBase.Size = new System.Drawing.Size(157, 251);
            this.listboxBase.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cechy do wyboru";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(478, 126);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Add >>";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(478, 165);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 4;
            this.removeButton.Text = "<< Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // listboxToAdd
            // 
            this.listboxToAdd.FormattingEnabled = true;
            this.listboxToAdd.Location = new System.Drawing.Point(595, 44);
            this.listboxToAdd.Name = "listboxToAdd";
            this.listboxToAdd.Size = new System.Drawing.Size(157, 251);
            this.listboxToAdd.TabIndex = 5;
            // 
            // analyzingAppWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 628);
            this.Controls.Add(this.listboxToAdd);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listboxBase);
            this.Controls.Add(this.panel1);
            this.Name = "analyzingAppWindow";
            this.Text = "Analyzing App";
            this.Load += new System.EventHandler(this.analyzingAppWindow_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView fileViewer;
        private System.Windows.Forms.ListBox listboxBase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.ListBox listboxToAdd;
    }
}

