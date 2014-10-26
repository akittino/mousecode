namespace mysz
{
    partial class ColorsGameMainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorsGameMainWindow));
            this.exitLabel = new System.Windows.Forms.Label();
            this.helpLabel = new System.Windows.Forms.Label();
            this.settingsLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.instructionTextBox = new System.Windows.Forms.TextBox();
            this.backLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exitLabel
            // 
            this.exitLabel.AutoSize = true;
            this.exitLabel.Font = new System.Drawing.Font("Gabriola", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitLabel.Location = new System.Drawing.Point(96, 226);
            this.exitLabel.Name = "exitLabel";
            this.exitLabel.Size = new System.Drawing.Size(43, 40);
            this.exitLabel.TabIndex = 9;
            this.exitLabel.Text = "Exit";
            this.exitLabel.Click += new System.EventHandler(this.exitClick);
            this.exitLabel.MouseEnter += new System.EventHandler(this.highlightLabel);
            this.exitLabel.MouseLeave += new System.EventHandler(this.removeHighlightLabel);
            // 
            // helpLabel
            // 
            this.helpLabel.AutoSize = true;
            this.helpLabel.Font = new System.Drawing.Font("Gabriola", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel.Location = new System.Drawing.Point(96, 174);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.Size = new System.Drawing.Size(49, 40);
            this.helpLabel.TabIndex = 8;
            this.helpLabel.Text = "Help";
            this.helpLabel.Click += new System.EventHandler(this.helpClick);
            this.helpLabel.MouseEnter += new System.EventHandler(this.highlightLabel);
            this.helpLabel.MouseLeave += new System.EventHandler(this.removeHighlightLabel);
            // 
            // settingsLabel
            // 
            this.settingsLabel.AutoSize = true;
            this.settingsLabel.Font = new System.Drawing.Font("Gabriola", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsLabel.Location = new System.Drawing.Point(96, 122);
            this.settingsLabel.Name = "settingsLabel";
            this.settingsLabel.Size = new System.Drawing.Size(69, 40);
            this.settingsLabel.TabIndex = 7;
            this.settingsLabel.Text = "Settings";
            this.settingsLabel.Click += new System.EventHandler(this.settingsClick);
            this.settingsLabel.MouseEnter += new System.EventHandler(this.highlightLabel);
            this.settingsLabel.MouseLeave += new System.EventHandler(this.removeHighlightLabel);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(36, 31);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(205, 45);
            this.titleLabel.TabIndex = 6;
            this.titleLabel.Text = "Welcome to Colors Game";
            // 
            // playButton
            // 
            this.playButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("playButton.BackgroundImage")));
            this.playButton.Font = new System.Drawing.Font("Iskoola Pota", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.ForeColor = System.Drawing.Color.Indigo;
            this.playButton.Location = new System.Drawing.Point(266, 31);
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
            this.instructionTextBox.Location = new System.Drawing.Point(266, 31);
            this.instructionTextBox.Multiline = true;
            this.instructionTextBox.Name = "instructionTextBox";
            this.instructionTextBox.ReadOnly = true;
            this.instructionTextBox.Size = new System.Drawing.Size(380, 299);
            this.instructionTextBox.TabIndex = 11;
            this.instructionTextBox.Text = resources.GetString("instructionTextBox.Text");
            this.instructionTextBox.Visible = false;
            // 
            // backLabel
            // 
            this.backLabel.AutoSize = true;
            this.backLabel.Font = new System.Drawing.Font("Gabriola", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backLabel.Location = new System.Drawing.Point(96, 174);
            this.backLabel.Name = "backLabel";
            this.backLabel.Size = new System.Drawing.Size(51, 40);
            this.backLabel.TabIndex = 13;
            this.backLabel.Text = "Back";
            this.backLabel.Visible = false;
            this.backLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.backGameWindow);
            this.backLabel.MouseEnter += new System.EventHandler(this.highlightLabel);
            this.backLabel.MouseLeave += new System.EventHandler(this.removeHighlightLabel);
            // 
            // ColorsGameMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 342);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.instructionTextBox);
            this.Controls.Add(this.exitLabel);
            this.Controls.Add(this.settingsLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.helpLabel);
            this.Controls.Add(this.backLabel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(676, 380);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(676, 380);
            this.Name = "ColorsGameMainWindow";
            this.Text = "ColorsGameWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label exitLabel;
        private System.Windows.Forms.Label helpLabel;
        private System.Windows.Forms.Label settingsLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.TextBox instructionTextBox;
        private System.Windows.Forms.Label backLabel;
    }
}