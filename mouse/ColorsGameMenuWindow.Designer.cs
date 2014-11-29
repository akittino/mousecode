namespace mysz
{
    partial class ColorsGameMenuWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorsGameMenuWindow));
            this.setTimeButton = new System.Windows.Forms.Button();
            this.secondsTextbox = new System.Windows.Forms.TextBox();
            this.secondsLabel = new System.Windows.Forms.Label();
            this.gameTimeLabel = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.instructionTextBox = new System.Windows.Forms.TextBox();
            this.exitLabel = new System.Windows.Forms.Label();
            this.settingsLabel = new System.Windows.Forms.Label();
            this.titleLabel1 = new System.Windows.Forms.Label();
            this.helpLabel = new System.Windows.Forms.Label();
            this.backLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // setTimeButton
            // 
            this.setTimeButton.Enabled = false;
            this.setTimeButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.setTimeButton.Location = new System.Drawing.Point(527, 129);
            this.setTimeButton.Name = "setTimeButton";
            this.setTimeButton.Size = new System.Drawing.Size(75, 33);
            this.setTimeButton.TabIndex = 19;
            this.setTimeButton.Text = "Set Time";
            this.setTimeButton.UseVisualStyleBackColor = true;
            this.setTimeButton.Visible = false;
            this.setTimeButton.Click += new System.EventHandler(this.setTimeButton_Click);
            // 
            // secondsTextbox
            // 
            this.secondsTextbox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.secondsTextbox.Location = new System.Drawing.Point(476, 133);
            this.secondsTextbox.Name = "secondsTextbox";
            this.secondsTextbox.Size = new System.Drawing.Size(28, 22);
            this.secondsTextbox.TabIndex = 18;
            this.secondsTextbox.Visible = false;
            this.secondsTextbox.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // secondsLabel
            // 
            this.secondsLabel.AutoSize = true;
            this.secondsLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.secondsLabel.Location = new System.Drawing.Point(460, 111);
            this.secondsLabel.Name = "secondsLabel";
            this.secondsLabel.Size = new System.Drawing.Size(61, 19);
            this.secondsLabel.TabIndex = 17;
            this.secondsLabel.Text = "Seconds";
            this.secondsLabel.Visible = false;
            // 
            // gameTimeLabel
            // 
            this.gameTimeLabel.AutoSize = true;
            this.gameTimeLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gameTimeLabel.Location = new System.Drawing.Point(311, 133);
            this.gameTimeLabel.Name = "gameTimeLabel";
            this.gameTimeLabel.Size = new System.Drawing.Size(159, 23);
            this.gameTimeLabel.TabIndex = 15;
            this.gameTimeLabel.Text = "Time per question";
            this.gameTimeLabel.Visible = false;
            // 
            // playButton
            // 
            this.playButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("playButton.BackgroundImage")));
            this.playButton.Font = new System.Drawing.Font("Iskoola Pota", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.ForeColor = System.Drawing.Color.Indigo;
            this.playButton.Location = new System.Drawing.Point(268, 21);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(380, 299);
            this.playButton.TabIndex = 10;
            this.playButton.Text = "PLAY ME";
            this.playButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButtonClick);
            this.playButton.MouseEnter += new System.EventHandler(this.buttonHighlight);
            this.playButton.MouseLeave += new System.EventHandler(this.removeHighlightButton);
            // 
            // instructionTextBox
            // 
            this.instructionTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.instructionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.instructionTextBox.Enabled = false;
            this.instructionTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.instructionTextBox.Location = new System.Drawing.Point(266, 31);
            this.instructionTextBox.Multiline = true;
            this.instructionTextBox.Name = "instructionTextBox";
            this.instructionTextBox.ReadOnly = true;
            this.instructionTextBox.Size = new System.Drawing.Size(380, 299);
            this.instructionTextBox.TabIndex = 11;
            this.instructionTextBox.Text = resources.GetString("instructionTextBox.Text");
            this.instructionTextBox.Visible = false;
            // 
            // exitLabel
            // 
            this.exitLabel.AutoSize = true;
            this.exitLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.exitLabel.Location = new System.Drawing.Point(96, 226);
            this.exitLabel.Name = "exitLabel";
            this.exitLabel.Size = new System.Drawing.Size(45, 23);
            this.exitLabel.TabIndex = 9;
            this.exitLabel.Text = "Exit";
            this.exitLabel.Click += new System.EventHandler(this.exitClick);
            this.exitLabel.MouseEnter += new System.EventHandler(this.highlightLabel);
            this.exitLabel.MouseLeave += new System.EventHandler(this.removeHighlightLabel);
            // 
            // settingsLabel
            // 
            this.settingsLabel.AutoSize = true;
            this.settingsLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.settingsLabel.Location = new System.Drawing.Point(96, 122);
            this.settingsLabel.Name = "settingsLabel";
            this.settingsLabel.Size = new System.Drawing.Size(76, 23);
            this.settingsLabel.TabIndex = 7;
            this.settingsLabel.Text = "Settings";
            this.settingsLabel.Click += new System.EventHandler(this.settingsClick);
            this.settingsLabel.MouseEnter += new System.EventHandler(this.highlightLabel);
            this.settingsLabel.MouseLeave += new System.EventHandler(this.removeHighlightLabel);
            // 
            // titleLabel1
            // 
            this.titleLabel1.AutoSize = true;
            this.titleLabel1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.titleLabel1.Location = new System.Drawing.Point(12, 32);
            this.titleLabel1.Name = "titleLabel1";
            this.titleLabel1.Size = new System.Drawing.Size(87, 23);
            this.titleLabel1.TabIndex = 6;
            this.titleLabel1.Text = "Welcome";
            // 
            // helpLabel
            // 
            this.helpLabel.AutoSize = true;
            this.helpLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.helpLabel.Location = new System.Drawing.Point(96, 174);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.Size = new System.Drawing.Size(50, 23);
            this.helpLabel.TabIndex = 8;
            this.helpLabel.Text = "Help";
            this.helpLabel.Click += new System.EventHandler(this.helpClick);
            this.helpLabel.MouseEnter += new System.EventHandler(this.highlightLabel);
            this.helpLabel.MouseLeave += new System.EventHandler(this.removeHighlightLabel);
            // 
            // backLabel
            // 
            this.backLabel.AutoSize = true;
            this.backLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.backLabel.Location = new System.Drawing.Point(96, 174);
            this.backLabel.Name = "backLabel";
            this.backLabel.Size = new System.Drawing.Size(52, 23);
            this.backLabel.TabIndex = 13;
            this.backLabel.Text = "Back";
            this.backLabel.Visible = false;
            this.backLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.backGameWindow);
            this.backLabel.MouseEnter += new System.EventHandler(this.highlightLabel);
            this.backLabel.MouseLeave += new System.EventHandler(this.removeHighlightLabel);
            // 
            // ColorsGameMenuWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 341);
            this.Controls.Add(this.setTimeButton);
            this.Controls.Add(this.secondsTextbox);
            this.Controls.Add(this.secondsLabel);
            this.Controls.Add(this.gameTimeLabel);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.instructionTextBox);
            this.Controls.Add(this.exitLabel);
            this.Controls.Add(this.settingsLabel);
            this.Controls.Add(this.titleLabel1);
            this.Controls.Add(this.helpLabel);
            this.Controls.Add(this.backLabel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(676, 380);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(676, 380);
            this.Name = "ColorsGameMenuWindow";
            this.Text = "Colors game settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label exitLabel;
        private System.Windows.Forms.Label helpLabel;
        private System.Windows.Forms.Label settingsLabel;
        private System.Windows.Forms.Label titleLabel1;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.TextBox instructionTextBox;
        private System.Windows.Forms.Label backLabel;
        private System.Windows.Forms.Label gameTimeLabel;
        private System.Windows.Forms.Label secondsLabel;
        private System.Windows.Forms.TextBox secondsTextbox;
        private System.Windows.Forms.Button setTimeButton;
    }
}