namespace mysz
{
    partial class MoodWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoodWindow));
            this.titleLabel = new System.Windows.Forms.Label();
            this.veryHappyButton = new System.Windows.Forms.Button();
            this.happyButton = new System.Windows.Forms.Button();
            this.verySadButton = new System.Windows.Forms.Button();
            this.normalButton = new System.Windows.Forms.Button();
            this.sadButton = new System.Windows.Forms.Button();
            this.colorsLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Gabriola", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(69, 19);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(227, 40);
            this.titleLabel.TabIndex = 21;
            this.titleLabel.Text = "Before game choose your mood";
            // 
            // veryHappyButton
            // 
            this.veryHappyButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("veryHappyButton.BackgroundImage")));
            this.veryHappyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.veryHappyButton.ForeColor = System.Drawing.Color.White;
            this.veryHappyButton.Location = new System.Drawing.Point(76, 74);
            this.veryHappyButton.Name = "veryHappyButton";
            this.veryHappyButton.Size = new System.Drawing.Size(60, 60);
            this.veryHappyButton.TabIndex = 22;
            this.veryHappyButton.UseVisualStyleBackColor = true;
            this.veryHappyButton.Click += new System.EventHandler(this.veryHappyButton_Click);
            // 
            // happyButton
            // 
            this.happyButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("happyButton.BackgroundImage")));
            this.happyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.happyButton.ForeColor = System.Drawing.Color.White;
            this.happyButton.Location = new System.Drawing.Point(226, 74);
            this.happyButton.Name = "happyButton";
            this.happyButton.Size = new System.Drawing.Size(60, 60);
            this.happyButton.TabIndex = 23;
            this.happyButton.UseVisualStyleBackColor = true;
            this.happyButton.Click += new System.EventHandler(this.happyButton_Click);
            // 
            // verySadButton
            // 
            this.verySadButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("verySadButton.BackgroundImage")));
            this.verySadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.verySadButton.ForeColor = System.Drawing.Color.White;
            this.verySadButton.Location = new System.Drawing.Point(226, 190);
            this.verySadButton.Name = "verySadButton";
            this.verySadButton.Size = new System.Drawing.Size(60, 60);
            this.verySadButton.TabIndex = 24;
            this.verySadButton.UseVisualStyleBackColor = true;
            this.verySadButton.Click += new System.EventHandler(this.verySadButton_Click);
            // 
            // normalButton
            // 
            this.normalButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("normalButton.BackgroundImage")));
            this.normalButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.normalButton.ForeColor = System.Drawing.Color.White;
            this.normalButton.Location = new System.Drawing.Point(151, 126);
            this.normalButton.Name = "normalButton";
            this.normalButton.Size = new System.Drawing.Size(60, 60);
            this.normalButton.TabIndex = 25;
            this.normalButton.UseVisualStyleBackColor = true;
            this.normalButton.Click += new System.EventHandler(this.normalButton_Click);
            // 
            // sadButton
            // 
            this.sadButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sadButton.BackgroundImage")));
            this.sadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sadButton.ForeColor = System.Drawing.Color.White;
            this.sadButton.Location = new System.Drawing.Point(76, 190);
            this.sadButton.Name = "sadButton";
            this.sadButton.Size = new System.Drawing.Size(60, 60);
            this.sadButton.TabIndex = 26;
            this.sadButton.UseVisualStyleBackColor = true;
            this.sadButton.Click += new System.EventHandler(this.sadButton_Click);
            // 
            // colorsLabel
            // 
            this.colorsLabel.AutoSize = true;
            this.colorsLabel.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorsLabel.Location = new System.Drawing.Point(75, 137);
            this.colorsLabel.Name = "colorsLabel";
            this.colorsLabel.Size = new System.Drawing.Size(62, 14);
            this.colorsLabel.TabIndex = 40;
            this.colorsLabel.Text = "Very Happy";
            this.colorsLabel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(161, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 41;
            this.label1.Text = "Normal";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(238, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 14);
            this.label2.TabIndex = 42;
            this.label2.Text = "Happy";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(95, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 14);
            this.label3.TabIndex = 43;
            this.label3.Text = "Sad";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(233, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 14);
            this.label4.TabIndex = 44;
            this.label4.Text = "Very sad";
            this.label4.Visible = false;
            // 
            // MoodWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 288);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colorsLabel);
            this.Controls.Add(this.sadButton);
            this.Controls.Add(this.normalButton);
            this.Controls.Add(this.verySadButton);
            this.Controls.Add(this.happyButton);
            this.Controls.Add(this.veryHappyButton);
            this.Controls.Add(this.titleLabel);
            this.Name = "MoodWindow";
            this.Text = "MoodWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button veryHappyButton;
        private System.Windows.Forms.Button happyButton;
        private System.Windows.Forms.Button verySadButton;
        private System.Windows.Forms.Button normalButton;
        private System.Windows.Forms.Button sadButton;
        private System.Windows.Forms.Label colorsLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}