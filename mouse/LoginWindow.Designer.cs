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
            this.user_name_textbox = new System.Windows.Forms.TextBox();
            this.user_name_label = new System.Windows.Forms.Label();
            this.mood_label = new System.Windows.Forms.Label();
            this.very_sad_mood_button = new System.Windows.Forms.Button();
            this.sad_mood_button = new System.Windows.Forms.Button();
            this.normal_mood_button = new System.Windows.Forms.Button();
            this.happy_mood_button = new System.Windows.Forms.Button();
            this.very_happy_mood_button = new System.Windows.Forms.Button();
            this.login_button = new System.Windows.Forms.Button();
            this.admin_panel_button = new System.Windows.Forms.Button();
            this.login_status_label = new System.Windows.Forms.Label();
            this.colors_button = new System.Windows.Forms.Button();
            this.reflex_button = new System.Windows.Forms.Button();
            this.things_button = new System.Windows.Forms.Button();
            this.games_group_box = new System.Windows.Forms.GroupBox();
            this.admin_password_textbox = new System.Windows.Forms.TextBox();
            this.games_group_box.SuspendLayout();
            this.SuspendLayout();
            // 
            // user_name_textbox
            // 
            this.user_name_textbox.Location = new System.Drawing.Point(131, 41);
            this.user_name_textbox.Name = "user_name_textbox";
            this.user_name_textbox.Size = new System.Drawing.Size(150, 20);
            this.user_name_textbox.TabIndex = 0;
            this.user_name_textbox.Text = "D&O";
            this.user_name_textbox.TextChanged += new System.EventHandler(this.user_name_textbox_TextChanged);
            // 
            // user_name_label
            // 
            this.user_name_label.AutoSize = true;
            this.user_name_label.Location = new System.Drawing.Point(64, 44);
            this.user_name_label.Name = "user_name_label";
            this.user_name_label.Size = new System.Drawing.Size(61, 13);
            this.user_name_label.TabIndex = 1;
            this.user_name_label.Text = "User name:";
            // 
            // mood_label
            // 
            this.mood_label.AutoSize = true;
            this.mood_label.Location = new System.Drawing.Point(27, 86);
            this.mood_label.Name = "mood_label";
            this.mood_label.Size = new System.Drawing.Size(98, 13);
            this.mood_label.TabIndex = 2;
            this.mood_label.Text = "Choose your mood:";
            // 
            // very_sad_mood_button
            // 
            this.very_sad_mood_button.Location = new System.Drawing.Point(132, 80);
            this.very_sad_mood_button.Name = "very_sad_mood_button";
            this.very_sad_mood_button.Size = new System.Drawing.Size(25, 25);
            this.very_sad_mood_button.TabIndex = 3;
            this.very_sad_mood_button.Text = ":((";
            this.very_sad_mood_button.UseVisualStyleBackColor = true;
            // 
            // sad_mood_button
            // 
            this.sad_mood_button.Location = new System.Drawing.Point(163, 80);
            this.sad_mood_button.Name = "sad_mood_button";
            this.sad_mood_button.Size = new System.Drawing.Size(25, 25);
            this.sad_mood_button.TabIndex = 4;
            this.sad_mood_button.Text = ":(";
            this.sad_mood_button.UseVisualStyleBackColor = true;
            // 
            // normal_mood_button
            // 
            this.normal_mood_button.Location = new System.Drawing.Point(194, 80);
            this.normal_mood_button.Name = "normal_mood_button";
            this.normal_mood_button.Size = new System.Drawing.Size(25, 25);
            this.normal_mood_button.TabIndex = 5;
            this.normal_mood_button.Text = ":|";
            this.normal_mood_button.UseVisualStyleBackColor = true;
            // 
            // happy_mood_button
            // 
            this.happy_mood_button.Location = new System.Drawing.Point(225, 80);
            this.happy_mood_button.Name = "happy_mood_button";
            this.happy_mood_button.Size = new System.Drawing.Size(25, 25);
            this.happy_mood_button.TabIndex = 6;
            this.happy_mood_button.Text = ":)";
            this.happy_mood_button.UseVisualStyleBackColor = true;
            // 
            // very_happy_mood_button
            // 
            this.very_happy_mood_button.Location = new System.Drawing.Point(256, 80);
            this.very_happy_mood_button.Name = "very_happy_mood_button";
            this.very_happy_mood_button.Size = new System.Drawing.Size(25, 25);
            this.very_happy_mood_button.TabIndex = 7;
            this.very_happy_mood_button.Text = ":))";
            this.very_happy_mood_button.UseVisualStyleBackColor = true;
            // 
            // login_button
            // 
            this.login_button.Location = new System.Drawing.Point(206, 124);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(75, 23);
            this.login_button.TabIndex = 8;
            this.login_button.Text = "Log in";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // admin_panel_button
            // 
            this.admin_panel_button.Location = new System.Drawing.Point(9, 124);
            this.admin_panel_button.Name = "admin_panel_button";
            this.admin_panel_button.Size = new System.Drawing.Size(102, 23);
            this.admin_panel_button.TabIndex = 9;
            this.admin_panel_button.Text = "Run admin panel";
            this.admin_panel_button.UseVisualStyleBackColor = true;
            this.admin_panel_button.Click += new System.EventHandler(this.admin_panel_button_Click);
            // 
            // login_status_label
            // 
            this.login_status_label.Location = new System.Drawing.Point(12, 216);
            this.login_status_label.Name = "login_status_label";
            this.login_status_label.Size = new System.Drawing.Size(310, 13);
            this.login_status_label.TabIndex = 10;
            this.login_status_label.Text = "Log in before choosing game";
            this.login_status_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colors_button
            // 
            this.colors_button.Enabled = false;
            this.colors_button.Location = new System.Drawing.Point(24, 33);
            this.colors_button.Name = "colors_button";
            this.colors_button.Size = new System.Drawing.Size(75, 23);
            this.colors_button.TabIndex = 11;
            this.colors_button.Text = "Colors";
            this.colors_button.UseVisualStyleBackColor = true;
            // 
            // reflex_button
            // 
            this.reflex_button.Enabled = false;
            this.reflex_button.Location = new System.Drawing.Point(116, 33);
            this.reflex_button.Name = "reflex_button";
            this.reflex_button.Size = new System.Drawing.Size(75, 23);
            this.reflex_button.TabIndex = 12;
            this.reflex_button.Text = "Reflex";
            this.reflex_button.UseVisualStyleBackColor = true;
            this.reflex_button.Click += new System.EventHandler(this.reflex_button_Click);
            // 
            // things_button
            // 
            this.things_button.Enabled = false;
            this.things_button.Location = new System.Drawing.Point(210, 33);
            this.things_button.Name = "things_button";
            this.things_button.Size = new System.Drawing.Size(75, 23);
            this.things_button.TabIndex = 13;
            this.things_button.Text = "Things";
            this.things_button.UseVisualStyleBackColor = true;
            this.things_button.Click += new System.EventHandler(this.things_button_Click);
            // 
            // games_group_box
            // 
            this.games_group_box.Controls.Add(this.colors_button);
            this.games_group_box.Controls.Add(this.things_button);
            this.games_group_box.Controls.Add(this.reflex_button);
            this.games_group_box.Location = new System.Drawing.Point(12, 255);
            this.games_group_box.Name = "games_group_box";
            this.games_group_box.Size = new System.Drawing.Size(310, 80);
            this.games_group_box.TabIndex = 14;
            this.games_group_box.TabStop = false;
            this.games_group_box.Text = "Games";
            // 
            // admin_password_textbox
            // 
            this.admin_password_textbox.Location = new System.Drawing.Point(9, 154);
            this.admin_password_textbox.Name = "admin_password_textbox";
            this.admin_password_textbox.Size = new System.Drawing.Size(100, 20);
            this.admin_password_textbox.TabIndex = 15;
            this.admin_password_textbox.Text = "admin";
            this.admin_password_textbox.UseSystemPasswordChar = true;
            this.admin_password_textbox.Click += new System.EventHandler(this.admin_password_textbox_Click);
            // 
            // login_main_window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 345);
            this.Controls.Add(this.admin_password_textbox);
            this.Controls.Add(this.games_group_box);
            this.Controls.Add(this.login_status_label);
            this.Controls.Add(this.admin_panel_button);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.very_happy_mood_button);
            this.Controls.Add(this.happy_mood_button);
            this.Controls.Add(this.normal_mood_button);
            this.Controls.Add(this.sad_mood_button);
            this.Controls.Add(this.very_sad_mood_button);
            this.Controls.Add(this.mood_label);
            this.Controls.Add(this.user_name_label);
            this.Controls.Add(this.user_name_textbox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 383);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 383);
            this.Name = "login_main_window";
            this.Text = "LoginWindow";
            this.games_group_box.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox user_name_textbox;
        private System.Windows.Forms.Label user_name_label;
        private System.Windows.Forms.Label mood_label;
        private System.Windows.Forms.Button very_sad_mood_button;
        private System.Windows.Forms.Button sad_mood_button;
        private System.Windows.Forms.Button normal_mood_button;
        private System.Windows.Forms.Button happy_mood_button;
        private System.Windows.Forms.Button very_happy_mood_button;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.Button admin_panel_button;
        private System.Windows.Forms.Label login_status_label;
        private System.Windows.Forms.Button colors_button;
        private System.Windows.Forms.Button reflex_button;
        private System.Windows.Forms.Button things_button;
        private System.Windows.Forms.GroupBox games_group_box;
        private System.Windows.Forms.TextBox admin_password_textbox;
    }
}