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
        bool resetedName = false;

        public login_main_window()
        {
            InitializeComponent();            
        }

        private void RunAdminPanelButton_Click(object sender, EventArgs e)
        {
            switch(adminPasswordTextbox.Text)
            {
                case "":
                    LogThis("Please enter password to use admin panel.");
                break;

                case AdminPassword:
                    LogThis("Password correct. Access granted.");
                    AdminWindow = new AdminPanelAnalyzator();
                    AdminWindow.FormClosed += new FormClosedEventHandler(AdminWindow_FormClosed);
                    AdminWindow.Show();
                    this.Hide();
                break;

                default:
                    LogThis("Password incorrect. Access denied.");
                break;
            }

        }

        private void LogThis(String message)
        {
            loginStatusLabel.Text = message;
        }


        private void ThingsButton_Click(object sender, EventArgs e)
        {
            ThingsWindow = new ThingsGameMenuWindow(userNameTextbox.Text);
            LogThis("Things game is running now...");
            ThingsWindow.FormClosed += new FormClosedEventHandler(ThingsWindow_FormClosed);
            GamesButtonsOff();
            ThingsWindow.Show();
            this.Hide();
        }

        private void ReflexButton_Click(object sender, EventArgs e)
        {
            ReflexWindow = new ReflexGameMenuWindow(userNameTextbox.Text);
            LogThis("Reflex game is running now...");
            ReflexWindow.FormClosed += new FormClosedEventHandler(ReflexWindow_FormClosed);
            GamesButtonsOff();
            ReflexWindow.Show();
            this.Hide();
        }

        private void ColorsButton_Click(object sender, EventArgs e)
        {
            ColorsWindow = new ColorsGameMenuWindow(userNameTextbox.Text);
            LogThis("Colors game is running now...");
            ColorsWindow.FormClosed += new FormClosedEventHandler(ColorsWindow_FormClosed);
            GamesButtonsOff();
            ColorsWindow.Show();
            this.Hide();
        }

        void ReflexWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            GamesButtonsOn();
            LogThis("Reflex game ended.");
        }

        void ColorsWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            GamesButtonsOn();
            LogThis("Colors game ended.");
        }

        void ThingsWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            GamesButtonsOn();
            LogThis("Things game ended.");
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

        private void UserNameTextbox_TextChanged(object sender, EventArgs e)
        {
            if (resetedName)
            {
                resetedName = false;
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(userNameTextbox.Text, "^[0-9a-zA-Z]+$") && !String.IsNullOrEmpty(userNameTextbox.Text))
            {
                LogThis("Username accepts only alphanumeric characters!");
                resetedName = true;
                userNameTextbox.ResetText();
            }
            else if (userNameTextbox.Text == "")
            {
                LogThis("Please enter name before play.");
                GamesButtonsOff();
            }
            else if (userNameTextbox.Text.Length > 12)
            {
                MessageBox.Show("User name allows only 12 characters.");
                LogThis("User name is too long. Please use valid name.");
                userNameTextbox.Text = "";
            }
            else
            {
                LogThis("Access to games granted.\n Hello " + userNameTextbox.Text + "!");
                GamesButtonsOn();
            }
        }

        private void LoginMainWindow_Load(object sender, EventArgs e)
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
