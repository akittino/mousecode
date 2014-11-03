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
            this.user_name_textbox = new System.Windows.Forms.TextBox();
            this.user_name_label = new System.Windows.Forms.Label();
            this.login_button = new System.Windows.Forms.Button();
            this.admin_panel_button = new System.Windows.Forms.Button();
            this.login_status_label = new System.Windows.Forms.Label();
            this.colorsButton = new System.Windows.Forms.Button();
            this.reflexButton = new System.Windows.Forms.Button();
            this.thingsButton = new System.Windows.Forms.Button();
            this.gamesGroupBox = new System.Windows.Forms.GroupBox();
            this.colorsLabel = new System.Windows.Forms.Label();
            this.admin_password_textbox = new System.Windows.Forms.TextBox();
            this.reflexLabel = new System.Windows.Forms.Label();
            this.thingsLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gamesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // user_name_textbox
            // 
            this.user_name_textbox.Location = new System.Drawing.Point(115, 63);
            this.user_name_textbox.Name = "user_name_textbox";
            this.user_name_textbox.Size = new System.Drawing.Size(150, 20);
            this.user_name_textbox.TabIndex = 0;
            this.user_name_textbox.Text = "DO";
            // 
            // user_name_label
            // 
            this.user_name_label.AutoSize = true;
            this.user_name_label.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_name_label.Location = new System.Drawing.Point(48, 66);
            this.user_name_label.Name = "user_name_label";
            this.user_name_label.Size = new System.Drawing.Size(61, 15);
            this.user_name_label.TabIndex = 1;
            this.user_name_label.Text = "User name:";
            // 
            // login_button
            // 
            this.login_button.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_button.Location = new System.Drawing.Point(209, 123);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(75, 23);
            this.login_button.TabIndex = 8;
            this.login_button.Text = "Log in";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // admin_panel_button
            // 
            this.admin_panel_button.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin_panel_button.Location = new System.Drawing.Point(12, 123);
            this.admin_panel_button.Name = "admin_panel_button";
            this.admin_panel_button.Size = new System.Drawing.Size(102, 23);
            this.admin_panel_button.TabIndex = 9;
            this.admin_panel_button.Text = "Run admin panel";
            this.admin_panel_button.UseVisualStyleBackColor = true;
            this.admin_panel_button.Click += new System.EventHandler(this.admin_panel_button_Click);
            // 
            // login_status_label
            // 
            this.login_status_label.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_status_label.Location = new System.Drawing.Point(9, 183);
            this.login_status_label.Name = "login_status_label";
            this.login_status_label.Size = new System.Drawing.Size(310, 23);
            this.login_status_label.TabIndex = 10;
            this.login_status_label.Text = "Log in before choosing game";
            this.login_status_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colorsButton
            // 
            this.colorsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("colorsButton.BackgroundImage")));
            this.colorsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.colorsButton.Enabled = false;
            this.colorsButton.Location = new System.Drawing.Point(6, 42);
            this.colorsButton.Name = "colorsButton";
            this.colorsButton.Size = new System.Drawing.Size(81, 47);
            this.colorsButton.TabIndex = 11;
            this.colorsButton.UseVisualStyleBackColor = true;
            this.colorsButton.Click += new System.EventHandler(this.colors_button_Click);
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
            this.reflexButton.Click += new System.EventHandler(this.reflex_button_Click);
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
            this.thingsButton.Click += new System.EventHandler(this.things_button_Click);
            // 
            // gamesGroupBox
            // 
            this.gamesGroupBox.Controls.Add(this.thingsLabel);
            this.gamesGroupBox.Controls.Add(this.reflexLabel);
            this.gamesGroupBox.Controls.Add(this.colorsLabel);
            this.gamesGroupBox.Controls.Add(this.colorsButton);
            this.gamesGroupBox.Controls.Add(this.thingsButton);
            this.gamesGroupBox.Controls.Add(this.reflexButton);
            this.gamesGroupBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gamesGroupBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gamesGroupBox.Location = new System.Drawing.Point(9, 219);
            this.gamesGroupBox.Name = "gamesGroupBox";
            this.gamesGroupBox.Size = new System.Drawing.Size(310, 95);
            this.gamesGroupBox.TabIndex = 14;
            this.gamesGroupBox.TabStop = false;
            this.gamesGroupBox.Text = "Games";
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
            this.colorsLabel.Visible = false;
            // 
            // admin_password_textbox
            // 
            this.admin_password_textbox.Location = new System.Drawing.Point(12, 153);
            this.admin_password_textbox.Name = "admin_password_textbox";
            this.admin_password_textbox.Size = new System.Drawing.Size(100, 20);
            this.admin_password_textbox.TabIndex = 15;
            this.admin_password_textbox.Text = "admin";
            this.admin_password_textbox.UseSystemPasswordChar = true;
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
            this.reflexLabel.Visible = false;
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
            this.thingsLabel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gabriola", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(108, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 40);
            this.label1.TabIndex = 16;
            this.label1.Text = "Mouse Tracker";
            // 
            // login_main_window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 345);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.admin_password_textbox);
            this.Controls.Add(this.gamesGroupBox);
            this.Controls.Add(this.login_status_label);
            this.Controls.Add(this.admin_panel_button);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.user_name_label);
            this.Controls.Add(this.user_name_textbox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 383);
            this.Name = "login_main_window";
            this.Text = "LoginWindow";
            this.gamesGroupBox.ResumeLayout(false);
            this.gamesGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox user_name_textbox;
        private System.Windows.Forms.Label user_name_label;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.Button admin_panel_button;
        private System.Windows.Forms.Label login_status_label;
        private System.Windows.Forms.Button colorsButton;
        private System.Windows.Forms.Button reflexButton;
        private System.Windows.Forms.Button thingsButton;
        private System.Windows.Forms.GroupBox gamesGroupBox;
        private System.Windows.Forms.TextBox admin_password_textbox;
        private System.Windows.Forms.Label colorsLabel;
        private System.Windows.Forms.Label thingsLabel;
        private System.Windows.Forms.Label reflexLabel;
        private System.Windows.Forms.Label label1;
    }
}