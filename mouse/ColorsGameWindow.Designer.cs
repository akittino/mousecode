namespace mysz
{
    partial class ColorsGameWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorsGameWindow));
            this.gameWindow = new System.Windows.Forms.PictureBox();
            this.timeTextLabel = new System.Windows.Forms.Label();
            this.endGameLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.yesButton = new System.Windows.Forms.Button();
            this.noButton = new System.Windows.Forms.Button();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.scoreNumber = new System.Windows.Forms.Label();
            this.continueButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gameWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // gameWindow
            // 
            this.gameWindow.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gameWindow.Location = new System.Drawing.Point(172, 31);
            this.gameWindow.Name = "gameWindow";
            this.gameWindow.Size = new System.Drawing.Size(800, 600);
            this.gameWindow.TabIndex = 15;
            this.gameWindow.TabStop = false;
            // 
            // timeTextLabel
            // 
            this.timeTextLabel.AutoSize = true;
            this.timeTextLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timeTextLabel.Location = new System.Drawing.Point(12, 31);
            this.timeTextLabel.Name = "timeTextLabel";
            this.timeTextLabel.Size = new System.Drawing.Size(58, 23);
            this.timeTextLabel.TabIndex = 29;
            this.timeTextLabel.Text = "Time:";
            // 
            // endGameLabel
            // 
            this.endGameLabel.AutoSize = true;
            this.endGameLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.endGameLabel.Location = new System.Drawing.Point(9, 591);
            this.endGameLabel.Name = "endGameLabel";
            this.endGameLabel.Size = new System.Drawing.Size(92, 23);
            this.endGameLabel.TabIndex = 26;
            this.endGameLabel.Text = "End game";
            this.endGameLabel.Click += new System.EventHandler(this.exitGame);
            this.endGameLabel.MouseEnter += new System.EventHandler(this.highlightLabel);
            this.endGameLabel.MouseLeave += new System.EventHandler(this.removeHighlightLabel);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timeLabel.Location = new System.Drawing.Point(12, 54);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(34, 19);
            this.timeLabel.TabIndex = 30;
            this.timeLabel.Text = "time";
            this.timeLabel.Visible = false;
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.playButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("playButton.BackgroundImage")));
            this.playButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playButton.Font = new System.Drawing.Font("Iskoola Pota", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.Location = new System.Drawing.Point(490, 31);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(198, 136);
            this.playButton.TabIndex = 31;
            this.playButton.Text = "PLAY";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // yesButton
            // 
            this.yesButton.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.yesButton.Location = new System.Drawing.Point(172, 549);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(118, 82);
            this.yesButton.TabIndex = 32;
            this.yesButton.Text = "YES";
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.Visible = false;
            this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
            // 
            // noButton
            // 
            this.noButton.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.noButton.Location = new System.Drawing.Point(854, 549);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(118, 82);
            this.noButton.TabIndex = 33;
            this.noButton.Text = "NO";
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.Visible = false;
            this.noButton.Click += new System.EventHandler(this.noButton_Click);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.scoreLabel.Location = new System.Drawing.Point(12, 90);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(63, 23);
            this.scoreLabel.TabIndex = 35;
            this.scoreLabel.Text = "Score:";
            // 
            // scoreNumber
            // 
            this.scoreNumber.AutoSize = true;
            this.scoreNumber.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.scoreNumber.Location = new System.Drawing.Point(12, 113);
            this.scoreNumber.Name = "scoreNumber";
            this.scoreNumber.Size = new System.Drawing.Size(17, 19);
            this.scoreNumber.TabIndex = 37;
            this.scoreNumber.Text = "0";
            this.scoreNumber.Visible = false;
            // 
            // continueButton
            // 
            this.continueButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.continueButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("continueButton.BackgroundImage")));
            this.continueButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.continueButton.Font = new System.Drawing.Font("Iskoola Pota", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueButton.Location = new System.Drawing.Point(490, 31);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(198, 136);
            this.continueButton.TabIndex = 38;
            this.continueButton.Text = "Continue Game";
            this.continueButton.UseVisualStyleBackColor = false;
            this.continueButton.Visible = false;
            this.continueButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // ColorsGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.scoreNumber);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.timeTextLabel);
            this.Controls.Add(this.endGameLabel);
            this.Controls.Add(this.gameWindow);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 700);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "ColorsGameWindow";
            this.Text = "Colors game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ColorsGameWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gameWindow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox gameWindow;
        private System.Windows.Forms.Label timeTextLabel;
        private System.Windows.Forms.Label endGameLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button yesButton;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label scoreNumber;
        private System.Windows.Forms.Button continueButton;

    }
}