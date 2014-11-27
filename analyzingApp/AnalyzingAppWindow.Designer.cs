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
            this.label2 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.granulationTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.removeAllButton = new System.Windows.Forms.Button();
            this.addAllButton = new System.Windows.Forms.Button();
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
            this.fileViewer.CheckBoxes = true;
            this.fileViewer.Location = new System.Drawing.Point(3, 3);
            this.fileViewer.Name = "fileViewer";
            this.fileViewer.Size = new System.Drawing.Size(228, 598);
            this.fileViewer.TabIndex = 0;
            this.fileViewer.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.fileViewer_AfterCheck);
            // 
            // listboxBase
            // 
            this.listboxBase.FormattingEnabled = true;
            this.listboxBase.Location = new System.Drawing.Point(293, 44);
            this.listboxBase.Name = "listboxBase";
            this.listboxBase.Size = new System.Drawing.Size(157, 303);
            this.listboxBase.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Attributes to choose:";
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
            this.listboxToAdd.Location = new System.Drawing.Point(595, 46);
            this.listboxToAdd.Name = "listboxToAdd";
            this.listboxToAdd.Size = new System.Drawing.Size(157, 303);
            this.listboxToAdd.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(592, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Chosen attributes:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(869, 44);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // granulationTextbox
            // 
            this.granulationTextbox.Location = new System.Drawing.Point(806, 46);
            this.granulationTextbox.Name = "granulationTextbox";
            this.granulationTextbox.Size = new System.Drawing.Size(33, 20);
            this.granulationTextbox.TabIndex = 8;
            this.granulationTextbox.Text = "10";
            this.granulationTextbox.TextChanged += new System.EventHandler(this.granulationTextbox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(793, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Granulation:";
            // 
            // removeAllButton
            // 
            this.removeAllButton.Location = new System.Drawing.Point(478, 243);
            this.removeAllButton.Name = "removeAllButton";
            this.removeAllButton.Size = new System.Drawing.Size(75, 23);
            this.removeAllButton.TabIndex = 10;
            this.removeAllButton.Text = "Remove All";
            this.removeAllButton.UseVisualStyleBackColor = true;
            this.removeAllButton.Click += new System.EventHandler(this.removeAllButton_Click);
            // 
            // addAllButton
            // 
            this.addAllButton.Location = new System.Drawing.Point(478, 204);
            this.addAllButton.Name = "addAllButton";
            this.addAllButton.Size = new System.Drawing.Size(75, 23);
            this.addAllButton.TabIndex = 11;
            this.addAllButton.Text = "Add All";
            this.addAllButton.UseVisualStyleBackColor = true;
            this.addAllButton.Click += new System.EventHandler(this.addAllButton_Click);
            // 
            // analyzingAppWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 628);
            this.Controls.Add(this.addAllButton);
            this.Controls.Add(this.removeAllButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.granulationTextbox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listboxToAdd);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listboxBase);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(971, 667);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(971, 667);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox granulationTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button removeAllButton;
        private System.Windows.Forms.Button addAllButton;
    }
}

