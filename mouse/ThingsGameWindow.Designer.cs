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
            this.answerRButton = new System.Windows.Forms.Button();
            this.answerLButton = new System.Windows.Forms.Button();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.scoreTextLabel = new System.Windows.Forms.Label();
            this.questionBox = new System.Windows.Forms.PictureBox();
            this.timeTextLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.endGameLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.gameWindow = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.questionBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // answerRButton
            // 
            this.answerRButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.answerRButton.Location = new System.Drawing.Point(854, 31);
            this.answerRButton.Name = "answerRButton";
            this.answerRButton.Size = new System.Drawing.Size(118, 82);
            this.answerRButton.TabIndex = 36;
            this.answerRButton.Text = "STOP";
            this.answerRButton.UseVisualStyleBackColor = true;
            this.answerRButton.Visible = false;
            this.answerRButton.Click += new System.EventHandler(this.stopRButton_Click);
            // 
            // answerLButton
            // 
            this.answerLButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.answerLButton.Location = new System.Drawing.Point(172, 31);
            this.answerLButton.Name = "answerLButton";
            this.answerLButton.Size = new System.Drawing.Size(118, 82);
            this.answerLButton.TabIndex = 35;
            this.answerLButton.Text = "STOP";
            this.answerLButton.UseVisualStyleBackColor = true;
            this.answerLButton.Visible = false;
            this.answerLButton.Click += new System.EventHandler(this.stopLButton_Click);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.scoreLabel.Location = new System.Drawing.Point(12, 113);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(21, 19);
            this.scoreLabel.TabIndex = 29;
            this.scoreLabel.Text = " 0";
            // 
            // scoreTextLabel
            // 
            this.scoreTextLabel.AutoSize = true;
            this.scoreTextLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.scoreTextLabel.Location = new System.Drawing.Point(12, 90);
            this.scoreTextLabel.Name = "scoreTextLabel";
            this.scoreTextLabel.Size = new System.Drawing.Size(63, 23);
            this.scoreTextLabel.TabIndex = 28;
            this.scoreTextLabel.Text = "Score:";
            // 
            // questionBox
            // 
            this.questionBox.BackColor = System.Drawing.Color.White;
            this.questionBox.Location = new System.Drawing.Point(322, 50);
            this.questionBox.Name = "questionBox";
            this.questionBox.Size = new System.Drawing.Size(500, 500);
            this.questionBox.TabIndex = 27;
            this.questionBox.TabStop = false;
            // 
            // timeTextLabel
            // 
            this.timeTextLabel.AutoSize = true;
            this.timeTextLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timeTextLabel.Location = new System.Drawing.Point(12, 31);
            this.timeTextLabel.Name = "timeTextLabel";
            this.timeTextLabel.Size = new System.Drawing.Size(58, 23);
            this.timeTextLabel.TabIndex = 25;
            this.timeTextLabel.Text = "Time:";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timeLabel.Location = new System.Drawing.Point(12, 54);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(38, 19);
            this.timeLabel.TabIndex = 24;
            this.timeLabel.Text = " time";
            this.timeLabel.Visible = false;
            // 
            // endGameLabel
            // 
            this.endGameLabel.AutoSize = true;
            this.endGameLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.endGameLabel.Location = new System.Drawing.Point(9, 591);
            this.endGameLabel.Name = "endGameLabel";
            this.endGameLabel.Size = new System.Drawing.Size(92, 23);
            this.endGameLabel.TabIndex = 22;
            this.endGameLabel.Text = "End game";
            this.endGameLabel.Click += new System.EventHandler(this.exitGame);
            this.endGameLabel.MouseEnter += new System.EventHandler(this.highlightLabel);
            this.endGameLabel.MouseLeave += new System.EventHandler(this.removeHighlightLabel);
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startButton.Location = new System.Drawing.Point(492, 577);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(157, 54);
            this.startButton.TabIndex = 12;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
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
            // ThingsGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.answerRButton);
            this.Controls.Add(this.answerLButton);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.scoreTextLabel);
            this.Controls.Add(this.questionBox);
            this.Controls.Add(this.timeTextLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.endGameLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.gameWindow);
            this.Location = new System.Drawing.Point(172, 41);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 700);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "ThingsGameWindow";
            this.Text = "ThingsGameWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThingsGameWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.questionBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameWindow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox gameWindow;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label endGameLabel;
        private System.Windows.Forms.Label timeTextLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.PictureBox questionBox;
        private System.Windows.Forms.Label scoreTextLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Button answerLButton;
        private System.Windows.Forms.Button answerRButton;
    }
}