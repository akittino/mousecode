using System;
using System.Windows.Forms;

namespace mysz
{
    public partial class login_main_window : Form
    {
        const String AdminPassword = "admin";
        AdminPanelAnalyzator AdminWindow;
        ThingsGameMenuWindow ThingsWindow;
        ReflexGameMenuWindow ReflexWindow;
        ColorsGameMenuWindow ColorsWindow;

        //TODO close all threads in other windows
        public login_main_window()
        {
            InitializeComponent();            
        }

        //TODO if can resize window. mustn't. ALL WINDOWS!!!
        private void admin_panel_button_Click(object sender, EventArgs e)
        {
            switch(adminPasswordTextbox.Text)
            {
                case "":
                    logThis("Please enter password to use admin panel.");
                break;

                case AdminPassword:
                    logThis("Password correct. Access granted.");
                    AdminWindow = new AdminPanelAnalyzator();
                    AdminWindow.FormClosed += new FormClosedEventHandler(AdminWindow_FormClosed);
                    AdminWindow.Show();
                    this.Hide();
                break;

                default:
                    logThis("Password incorrect. Access denied.");
                break;
            }

        }

        private void logThis(String message)
        {
            loginStatusLabel.Text = message;
        }


        private void things_button_Click(object sender, EventArgs e)
        {
            ThingsWindow = new ThingsGameMenuWindow(userNameTextbox.Text);
            logThis("Things game is running now...");
            ThingsWindow.FormClosed += new FormClosedEventHandler(ThingsWindow_FormClosed);
            GamesButtonsOff();
            ThingsWindow.Show();
            this.Hide();
        }

        private void reflex_button_Click(object sender, EventArgs e)
        {
            ReflexWindow = new ReflexGameMenuWindow(userNameTextbox.Text);
            logThis("Reflex game is running now...");
            ReflexWindow.FormClosed += new FormClosedEventHandler(ReflexWindow_FormClosed);
            GamesButtonsOff();
            ReflexWindow.Show();
            this.Hide();
        }

        private void colors_button_Click(object sender, EventArgs e)
        {
            ColorsWindow = new ColorsGameMenuWindow(userNameTextbox.Text);
            logThis("Colors game is running now...");
            ColorsWindow.FormClosed += new FormClosedEventHandler(ColorsWindow_FormClosed);
            GamesButtonsOff();
            ColorsWindow.Show();
            this.Hide();
        }

        void ReflexWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            GamesButtonsOn();
            logThis("Reflex game ended.");
        }

        void ColorsWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            GamesButtonsOn();
            logThis("Colors game ended.");
        }

        void ThingsWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            GamesButtonsOn();
            logThis("Things game ended.");
        }

        void AdminWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            adminPanelButton.Enabled = true;
            this.Show();
        }

        void GamesButtonsOn()
        {
            gamesGroupBox.Enabled = true;
            colorsButton.Enabled = true;
            reflexButton.Enabled = true;
            thingsButton.Enabled = true;

            colorsLabel.Enabled = true; 
            reflexLabel.Enabled = true;
            thingsLabel.Enabled = true;
        }

        void GamesButtonsOff()
        {
            colorsButton.Enabled = false;
            reflexButton.Enabled = false;
            thingsButton.Enabled = false;

            colorsLabel.Enabled = false;
            reflexLabel.Enabled = false;
            thingsLabel.Enabled = false;
        }

        private void userNameTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(userNameTextbox.Text, "^[0-9a-zA-Z]+$") && !String.IsNullOrEmpty(userNameTextbox.Text))
            {
                logThis("Username accepts only alphanumeric characters!");
                userNameTextbox.ResetText();

            }
            else if (userNameTextbox.Text == "")
            {
                logThis("Please enter name before play.");
                GamesButtonsOff();
            }
            else if (userNameTextbox.Text.Length >= 15)
            {
                MessageBox.Show("User name allows only 15 characters.");
                logThis("User name is too long. Please use valid name.");
                userNameTextbox.Text = "";
            }
            else
            {
                logThis("Access to games granted. Hello " + userNameTextbox.Text + "!");
                GamesButtonsOn();
            }
        }

        private void login_main_window_Load(object sender, EventArgs e)
        {
            String path = System.IO.Path.GetFullPath(".");
            if (path.Length > 150)
            {
                MessageBox.Show("Please place this application in directory with shorter path!");
                this.Close();
            }
        }
    }
}
