namespace mysz
{
    partial class ThingsGameWindow
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
            this.timeTextLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.saveScoreLabel = new System.Windows.Forms.Label();
            this.endGameLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.gameWindow = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gameWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // timeTextLabel
            // 
            this.timeTextLabel.AutoSize = true;
            this.timeTextLabel.Font = new System.Drawing.Font("Gabriola", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeTextLabel.Location = new System.Drawing.Point(14, 31);
            this.timeTextLabel.Name = "timeTextLabel";
            this.timeTextLabel.Size = new System.Drawing.Size(51, 40);
            this.timeTextLabel.TabIndex = 32;
            this.timeTextLabel.Text = "Time";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(18, 71);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(29, 15);
            this.timeLabel.TabIndex = 31;
            this.timeLabel.Text = "time";
            // 
            // saveScoreLabel
            // 
            this.saveScoreLabel.AutoSize = true;
            this.saveScoreLabel.Font = new System.Drawing.Font("Gabriola", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveScoreLabel.Location = new System.Drawing.Point(11, 551);
            this.saveScoreLabel.Name = "saveScoreLabel";
            this.saveScoreLabel.Size = new System.Drawing.Size(85, 40);
            this.saveScoreLabel.TabIndex = 30;
            this.saveScoreLabel.Text = "Save score";
            this.saveScoreLabel.MouseEnter += new System.EventHandler(this.highlightLabel);
            this.saveScoreLabel.MouseLeave += new System.EventHandler(this.removeHighlightLabel);
            // 
            // endGameLabel
            // 
            this.endGameLabel.AutoSize = true;
            this.endGameLabel.Font = new System.Drawing.Font("Gabriola", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endGameLabel.Location = new System.Drawing.Point(11, 591);
            this.endGameLabel.Name = "endGameLabel";
            this.endGameLabel.Size = new System.Drawing.Size(85, 40);
            this.endGameLabel.TabIndex = 29;
            this.endGameLabel.Text = "End game";
            this.endGameLabel.Click += new System.EventHandler(this.exitGame);
            this.endGameLabel.MouseEnter += new System.EventHandler(this.highlightLabel);
            this.endGameLabel.MouseLeave += new System.EventHandler(this.removeHighlightLabel);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(174, 607);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(60, 24);
            this.startButton.TabIndex = 26;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(917, 31);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(57, 23);
            this.stopButton.TabIndex = 28;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // gameWindow
            // 
            this.gameWindow.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gameWindow.Location = new System.Drawing.Point(174, 31);
            this.gameWindow.Name = "gameWindow";
            this.gameWindow.Size = new System.Drawing.Size(800, 600);
            this.gameWindow.TabIndex = 27;
            this.gameWindow.TabStop = false;
            // 
            // ThingsGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 662);
            this.Controls.Add(this.timeTextLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.saveScoreLabel);
            this.Controls.Add(this.endGameLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.gameWindow);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 700);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "ThingsGameWindow";
            this.Text = "ThingsGameWindow";
            ((System.ComponentModel.ISupportInitialize)(this.gameWindow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label timeTextLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label saveScoreLabel;
        private System.Windows.Forms.Label endGameLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.PictureBox gameWindow;

    }
}