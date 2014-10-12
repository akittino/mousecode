namespace mysz
{
    partial class ReflexGameWindow
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
            this.picture_box = new System.Windows.Forms.PictureBox();
            this.start_button = new System.Windows.Forms.Button();
            this.stop_button = new System.Windows.Forms.Button();
            this.time_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picture_box)).BeginInit();
            this.SuspendLayout();
            // 
            // picture_box
            // 
            this.picture_box.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.picture_box.Location = new System.Drawing.Point(172, 41);
            this.picture_box.Name = "picture_box";
            this.picture_box.Size = new System.Drawing.Size(800, 600);
            this.picture_box.TabIndex = 11;
            this.picture_box.TabStop = false;
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(172, 617);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(60, 24);
            this.start_button.TabIndex = 12;
            this.start_button.Text = "Start";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // stop_button
            // 
            this.stop_button.Location = new System.Drawing.Point(915, 41);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(57, 23);
            this.stop_button.TabIndex = 13;
            this.stop_button.Text = "Stop";
            this.stop_button.UseVisualStyleBackColor = true;
            this.stop_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // time_label
            // 
            this.time_label.AutoSize = true;
            this.time_label.Location = new System.Drawing.Point(13, 85);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(26, 13);
            this.time_label.TabIndex = 14;
            this.time_label.Text = "time";
            // 
            // ReflexGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 662);
            this.Controls.Add(this.time_label);
            this.Controls.Add(this.stop_button);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.picture_box);
            this.MaximumSize = new System.Drawing.Size(1000, 700);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "ReflexGameWindow";
            this.Text = "ReflexGameWindow";
            ((System.ComponentModel.ISupportInitialize)(this.picture_box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picture_box;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Button stop_button;
        private System.Windows.Forms.Label time_label;
    }
}