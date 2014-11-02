using System;
using System.Windows.Forms;

namespace mysz
{
    public partial class login_main_window : Form
    {
        const String AdminPassword = "admin";
        
        AdminPanel AdminWindow;
        ThingsGameMenuWindow ThingsWindow;
        ReflexGameMenuWindow ReflexWindow;
        ColorsGameMenuWindow ColorsWindow;
        String UserName;
        public string userName;

        //TODO close all threads in other windows
        public login_main_window()
        {
            InitializeComponent();
            userName = user_name_textbox.Text;
        }

        //TODO if can resize window. mustn't. ALL WINDOWS!!!
        private void admin_panel_button_Click(object sender, EventArgs e)
        {
            switch(admin_password_textbox.Text)
            {
                case "":
                    logThis("Please enter password to use admin panel.");
                break;

                case AdminPassword:
                    logThis("Password correct. Access granted.");
                    AdminWindow = new AdminPanel();
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
            login_status_label.Text = message;
        }



        private void login_button_Click(object sender, EventArgs e)
        {
            if (user_name_textbox.Text == "")
            {
                logThis("Please enter name before login.");
            }
            else if (user_name_textbox.Text.Length > 15)
            {
                logThis("User name is too long. Please use valid name.");
            }
            else
            {
                UserName = user_name_textbox.Text;
                logThis("Access to games granted. Hello " + UserName + "!");
                GamesButtonsOn();
            }
            //TODO name verification -> failes when & in name
        }

        private void things_button_Click(object sender, EventArgs e)
        {
            userName = user_name_textbox.Text;
            ThingsWindow = new ThingsGameMenuWindow(userName);
            logThis("Things game is running now...");
            ThingsWindow.FormClosed += new FormClosedEventHandler(ThingsWindow_FormClosed);
            GamesButtonsOff();
            ThingsWindow.Show();
            this.Hide();
        }

        private void reflex_button_Click(object sender, EventArgs e)
        {
            userName = user_name_textbox.Text;
            ReflexWindow = new ReflexGameMenuWindow(userName);
            logThis("Reflex game is running now...");
            ReflexWindow.FormClosed += new FormClosedEventHandler(ReflexWindow_FormClosed);
            GamesButtonsOff();
            ReflexWindow.Show();
            this.Hide();
        }

        private void colors_button_Click(object sender, EventArgs e)
        {
            userName = user_name_textbox.Text;
            ColorsWindow = new ColorsGameMenuWindow(userName);
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
            admin_panel_button.Enabled = true;
            this.Show();
        }

        void GamesButtonsOn()
        {
            colors_button.Enabled = true;
            reflex_button.Enabled = true;
            things_button.Enabled = true;
        }

        void GamesButtonsOff()
        {
            colors_button.Enabled = false;
            reflex_button.Enabled = false;
            things_button.Enabled = false;
        }
    }
}
