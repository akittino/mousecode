namespace mysz
{
    partial class login_main_window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login_main_window));
            this.userNameTextbox = new System.Windows.Forms.TextBox();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.adminPanelButton = new System.Windows.Forms.Button();
            this.loginStatusLabel = new System.Windows.Forms.Label();
            this.colorsButton = new System.Windows.Forms.Button();
            this.reflexButton = new System.Windows.Forms.Button();
            this.thingsButton = new System.Windows.Forms.Button();
            this.gamesGroupBox = new System.Windows.Forms.GroupBox();
            this.thingsLabel = new System.Windows.Forms.Label();
            this.reflexLabel = new System.Windows.Forms.Label();
            this.colorsLabel = new System.Windows.Forms.Label();
            this.adminPasswordTextbox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.gamesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // userNameTextbox
            // 
            this.userNameTextbox.Location = new System.Drawing.Point(115, 63);
            this.userNameTextbox.Name = "userNameTextbox";
            this.userNameTextbox.Size = new System.Drawing.Size(150, 20);
            this.userNameTextbox.TabIndex = 0;
            this.userNameTextbox.TextChanged += new System.EventHandler(this.UserNameTextbox_TextChanged);
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLabel.Location = new System.Drawing.Point(48, 66);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(61, 15);
            this.userNameLabel.TabIndex = 1;
            this.userNameLabel.Text = "User name:";
            // 
            // adminPanelButton
            // 
            this.adminPanelButton.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminPanelButton.Location = new System.Drawing.Point(12, 123);
            this.adminPanelButton.Name = "adminPanelButton";
            this.adminPanelButton.Size = new System.Drawing.Size(102, 23);
            this.adminPanelButton.TabIndex = 9;
            this.adminPanelButton.Text = "Run admin panel";
            this.adminPanelButton.UseVisualStyleBackColor = true;
            this.adminPanelButton.Click += new System.EventHandler(this.RunAdminPanelButton_Click);
            // 
            // loginStatusLabel
            // 
            this.loginStatusLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginStatusLabel.Location = new System.Drawing.Point(9, 176);
            this.loginStatusLabel.Name = "loginStatusLabel";
            this.loginStatusLabel.Size = new System.Drawing.Size(310, 40);
            this.loginStatusLabel.TabIndex = 10;
            this.loginStatusLabel.Text = "Please enter name before play.";
            this.loginStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colorsButton
            // 
            this.colorsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("colorsButton.BackgroundImage")));
            this.colorsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.colorsButton.Enabled = false;
            this.colorsButton.ForeColor = System.Drawing.Color.White;
            this.colorsButton.Location = new System.Drawing.Point(6, 42);
            this.colorsButton.Name = "colorsButton";
            this.colorsButton.Size = new System.Drawing.Size(81, 47);
            this.colorsButton.TabIndex = 11;
            this.colorsButton.UseVisualStyleBackColor = true;
            this.colorsButton.Click += new System.EventHandler(this.ColorsButton_Click);
            // 
            // reflexButton
            // 
            this.reflexButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("reflexButton.BackgroundImage")));
            this.reflexButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.reflexButton.Enabled = false;
            this.reflexButton.Location = new System.Drawing.Point(115, 42);
            this.reflexButton.Name = "reflexButton";
            this.reflexButton.Size = new System.Drawing.Size(81, 47);
            this.reflexButton.TabIndex = 12;
            this.reflexButton.UseVisualStyleBackColor = true;
            this.reflexButton.Click += new System.EventHandler(this.ReflexButton_Click);
            // 
            // thingsButton
            // 
            this.thingsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("thingsButton.BackgroundImage")));
            this.thingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.thingsButton.Enabled = false;
            this.thingsButton.Location = new System.Drawing.Point(223, 42);
            this.thingsButton.Name = "thingsButton";
            this.thingsButton.Size = new System.Drawing.Size(81, 47);
            this.thingsButton.TabIndex = 13;
            this.thingsButton.UseVisualStyleBackColor = true;
            this.thingsButton.Click += new System.EventHandler(this.ThingsButton_Click);
            // 
            // gamesGroupBox
            // 
            this.gamesGroupBox.Controls.Add(this.thingsLabel);
            this.gamesGroupBox.Controls.Add(this.reflexLabel);
            this.gamesGroupBox.Controls.Add(this.colorsLabel);
            this.gamesGroupBox.Controls.Add(this.colorsButton);
            this.gamesGroupBox.Controls.Add(this.thingsButton);
            this.gamesGroupBox.Controls.Add(this.reflexButton);
            this.gamesGroupBox.Enabled = false;
            this.gamesGroupBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gamesGroupBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gamesGroupBox.Location = new System.Drawing.Point(9, 219);
            this.gamesGroupBox.Name = "gamesGroupBox";
            this.gamesGroupBox.Size = new System.Drawing.Size(310, 95);
            this.gamesGroupBox.TabIndex = 14;
            this.gamesGroupBox.TabStop = false;
            this.gamesGroupBox.Text = "Games";
            // 
            // thingsLabel
            // 
            this.thingsLabel.AutoSize = true;
            this.thingsLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thingsLabel.Location = new System.Drawing.Point(241, 24);
            this.thingsLabel.Name = "thingsLabel";
            this.thingsLabel.Size = new System.Drawing.Size(45, 15);
            this.thingsLabel.TabIndex = 41;
            this.thingsLabel.Text = "Things";
            // 
            // reflexLabel
            // 
            this.reflexLabel.AutoSize = true;
            this.reflexLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reflexLabel.Location = new System.Drawing.Point(134, 24);
            this.reflexLabel.Name = "reflexLabel";
            this.reflexLabel.Size = new System.Drawing.Size(39, 15);
            this.reflexLabel.TabIndex = 40;
            this.reflexLabel.Text = "Reflex";
            // 
            // colorsLabel
            // 
            this.colorsLabel.AutoSize = true;
            this.colorsLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorsLabel.Location = new System.Drawing.Point(24, 24);
            this.colorsLabel.Name = "colorsLabel";
            this.colorsLabel.Size = new System.Drawing.Size(42, 15);
            this.colorsLabel.TabIndex = 39;
            this.colorsLabel.Text = "Colors";
            // 
            // adminPasswordTextbox
            // 
            this.adminPasswordTextbox.Location = new System.Drawing.Point(12, 153);
            this.adminPasswordTextbox.Name = "adminPasswordTextbox";
            this.adminPasswordTextbox.Size = new System.Drawing.Size(100, 20);
            this.adminPasswordTextbox.TabIndex = 15;
            this.adminPasswordTextbox.Text = "admin";
            this.adminPasswordTextbox.UseSystemPasswordChar = true;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.titleLabel.Location = new System.Drawing.Point(99, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(117, 21);
            this.titleLabel.TabIndex = 16;
            this.titleLabel.Text = "Mouse Moves";
            // 
            // login_main_window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 344);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.adminPasswordTextbox);
            this.Controls.Add(this.gamesGroupBox);
            this.Controls.Add(this.loginStatusLabel);
            this.Controls.Add(this.adminPanelButton);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.userNameTextbox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 383);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 383);
            this.Name = "login_main_window";
            this.Text = "Mouse Moves";
            this.Load += new System.EventHandler(this.LoginMainWindow_Load);
            this.gamesGroupBox.ResumeLayout(false);
            this.gamesGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userNameTextbox;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Button adminPanelButton;
        private System.Windows.Forms.Label loginStatusLabel;
        private System.Windows.Forms.Button colorsButton;
        private System.Windows.Forms.Button reflexButton;
        private System.Windows.Forms.Button thingsButton;
        private System.Windows.Forms.GroupBox gamesGroupBox;
        private System.Windows.Forms.TextBox adminPasswordTextbox;
        private System.Windows.Forms.Label colorsLabel;
        private System.Windows.Forms.Label thingsLabel;
        private System.Windows.Forms.Label reflexLabel;
        private System.Windows.Forms.Label titleLabel;
    }
}