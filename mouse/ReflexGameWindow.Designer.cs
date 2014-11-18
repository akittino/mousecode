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
            this.stopRButton = new System.Windows.Forms.Button();
            this.gameWindow = new System.Windows.Forms.PictureBox();
            this.startButton = new System.Windows.Forms.Button();
            this.endGameLabel = new System.Windows.Forms.Label();
            this.timeTextLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.stopLButton = new System.Windows.Forms.Button();
            this.scoreTextLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gameWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // stopRButton
            // 
            this.stopRButton.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stopRButton.Location = new System.Drawing.Point(915, 31);
            this.stopRButton.Name = "stopRButton";
            this.stopRButton.Size = new System.Drawing.Size(57, 23);
            this.stopRButton.TabIndex = 17;
            this.stopRButton.Text = "Stop";
            this.stopRButton.UseVisualStyleBackColor = true;
            this.stopRButton.Click += new System.EventHandler(this.stopRButton_Click);
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
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startButton.Location = new System.Drawing.Point(542, 607);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(60, 24);
            this.startButton.TabIndex = 12;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // endGameLabel
            // 
            this.endGameLabel.AutoSize = true;
            this.endGameLabel.Font = new System.Drawing.Font("Gabriola", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endGameLabel.Location = new System.Drawing.Point(9, 591);
            this.endGameLabel.Name = "endGameLabel";
            this.endGameLabel.Size = new System.Drawing.Size(85, 40);
            this.endGameLabel.TabIndex = 22;
            this.endGameLabel.Text = "End game";
            this.endGameLabel.Click += new System.EventHandler(this.exitGame);
            this.endGameLabel.MouseEnter += new System.EventHandler(this.highlightLabel);
            this.endGameLabel.MouseLeave += new System.EventHandler(this.removeHighlightLabel);
            // 
            // timeTextLabel
            // 
            this.timeTextLabel.AutoSize = true;
            this.timeTextLabel.Font = new System.Drawing.Font("Gabriola", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeTextLabel.Location = new System.Drawing.Point(12, 31);
            this.timeTextLabel.Name = "timeTextLabel";
            this.timeTextLabel.Size = new System.Drawing.Size(55, 40);
            this.timeTextLabel.TabIndex = 25;
            this.timeTextLabel.Text = "Time:";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timeLabel.Location = new System.Drawing.Point(16, 71);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(12, 18);
            this.timeLabel.TabIndex = 24;
            this.timeLabel.Text = " ";
            // 
            // stopLButton
            // 
            this.stopLButton.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stopLButton.Location = new System.Drawing.Point(172, 31);
            this.stopLButton.Name = "stopLButton";
            this.stopLButton.Size = new System.Drawing.Size(57, 23);
            this.stopLButton.TabIndex = 26;
            this.stopLButton.Text = "Stop";
            this.stopLButton.UseVisualStyleBackColor = true;
            this.stopLButton.Click += new System.EventHandler(this.stopLButton_Click);
            // 
            // scoreTextLabel
            // 
            this.scoreTextLabel.AutoSize = true;
            this.scoreTextLabel.Font = new System.Drawing.Font("Gabriola", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreTextLabel.Location = new System.Drawing.Point(12, 94);
            this.scoreTextLabel.Name = "scoreTextLabel";
            this.scoreTextLabel.Size = new System.Drawing.Size(57, 40);
            this.scoreTextLabel.TabIndex = 27;
            this.scoreTextLabel.Text = "Score:";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.scoreLabel.Location = new System.Drawing.Point(16, 134);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(12, 18);
            this.scoreLabel.TabIndex = 28;
            this.scoreLabel.Text = " ";
            // 
            // ReflexGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.scoreTextLabel);
            this.Controls.Add(this.stopLButton);
            this.Controls.Add(this.timeTextLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.endGameLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.stopRButton);
            this.Controls.Add(this.gameWindow);
            this.Location = new System.Drawing.Point(172, 41);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 700);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "ReflexGameWindow";
            this.Text = "ReflexGameWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReflexGameWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gameWindow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button stopRButton;
        private System.Windows.Forms.PictureBox gameWindow;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label endGameLabel;
        private System.Windows.Forms.Label timeTextLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Button stopLButton;
        private System.Windows.Forms.Label scoreTextLabel;
        private System.Windows.Forms.Label scoreLabel;
    }
}