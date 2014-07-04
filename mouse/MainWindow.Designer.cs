namespace mysz
{
    partial class main_form
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
            this.start_button = new System.Windows.Forms.Button();
            this.X_value = new System.Windows.Forms.Label();
            this.Y_value = new System.Windows.Forms.Label();
            this.X_label = new System.Windows.Forms.Label();
            this.Y_label = new System.Windows.Forms.Label();
            this.stop_button = new System.Windows.Forms.Button();
            this.coordinates_list = new System.Windows.Forms.ListBox();
            this.chart_button = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(885, 39);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(75, 23);
            this.start_button.TabIndex = 0;
            this.start_button.Text = "Start";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // X_value
            // 
            this.X_value.AutoSize = true;
            this.X_value.Location = new System.Drawing.Point(28, 22);
            this.X_value.Name = "X_value";
            this.X_value.Size = new System.Drawing.Size(13, 13);
            this.X_value.TabIndex = 2;
            this.X_value.Text = "0";
            // 
            // Y_value
            // 
            this.Y_value.AutoSize = true;
            this.Y_value.Location = new System.Drawing.Point(82, 22);
            this.Y_value.Name = "Y_value";
            this.Y_value.Size = new System.Drawing.Size(13, 13);
            this.Y_value.TabIndex = 3;
            this.Y_value.Text = "0";
            // 
            // X_label
            // 
            this.X_label.AutoSize = true;
            this.X_label.Location = new System.Drawing.Point(31, 9);
            this.X_label.Name = "X_label";
            this.X_label.Size = new System.Drawing.Size(17, 13);
            this.X_label.TabIndex = 4;
            this.X_label.Text = "X:";
            // 
            // Y_label
            // 
            this.Y_label.AutoSize = true;
            this.Y_label.Location = new System.Drawing.Point(83, 9);
            this.Y_label.Name = "Y_label";
            this.Y_label.Size = new System.Drawing.Size(17, 13);
            this.Y_label.TabIndex = 5;
            this.Y_label.Text = "Y:";
            // 
            // stop_button
            // 
            this.stop_button.Location = new System.Drawing.Point(160, 616);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(75, 23);
            this.stop_button.TabIndex = 7;
            this.stop_button.Text = "Stop";
            this.stop_button.UseVisualStyleBackColor = true;
            this.stop_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // coordinates_list
            // 
            this.coordinates_list.FormattingEnabled = true;
            this.coordinates_list.Location = new System.Drawing.Point(15, 39);
            this.coordinates_list.Name = "coordinates_list";
            this.coordinates_list.Size = new System.Drawing.Size(120, 602);
            this.coordinates_list.TabIndex = 6;
            // 
            // chart_button
            // 
            this.chart_button.Location = new System.Drawing.Point(885, 616);
            this.chart_button.Name = "chart_button";
            this.chart_button.Size = new System.Drawing.Size(75, 23);
            this.chart_button.TabIndex = 9;
            this.chart_button.Text = "Fill picture";
            this.chart_button.UseVisualStyleBackColor = true;
            this.chart_button.Click += new System.EventHandler(this.chart_draw_button_click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox.Location = new System.Drawing.Point(160, 39);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(800, 600);
            this.pictureBox.TabIndex = 10;
            this.pictureBox.TabStop = false;
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 662);
            this.Controls.Add(this.chart_button);
            this.Controls.Add(this.stop_button);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.coordinates_list);
            this.Controls.Add(this.Y_label);
            this.Controls.Add(this.X_label);
            this.Controls.Add(this.Y_value);
            this.Controls.Add(this.X_value);
            this.Controls.Add(this.pictureBox);
            this.MaximumSize = new System.Drawing.Size(1000, 700);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "main_form";
            this.Text = "MouseTracker v2.0 by D&O";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Label X_value;
        private System.Windows.Forms.Label Y_value;
        private System.Windows.Forms.Label X_label;
        private System.Windows.Forms.Label Y_label;
        private System.Windows.Forms.Button stop_button;
        private System.Windows.Forms.ListBox coordinates_list;
        private System.Windows.Forms.Button chart_button;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}

