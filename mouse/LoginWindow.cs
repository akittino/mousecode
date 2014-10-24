using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mysz
{
    public partial class login_main_window : Form
    {
        AdminPanel AP;
        ThingsGameWindow ThingsWindow;
        ReflexGameWindow ReflexWindow;
        String UserName;
        public login_main_window()
        {
            InitializeComponent();
        }
        //TODO if can resize window. mustn't
        private void admin_panel_button_Click(object sender, EventArgs e)
        {
            switch(admin_password_textbox.Text)
            {
                case "":
                    logThis("Please enter password to use admin panel.");
                break;

                case "admin":
                    logThis("Password correct. Access granted.");
                    AP = new AdminPanel();
                    AP.Activated += new EventHandler(AP_Activated);
                    AP.FormClosed += new FormClosedEventHandler(AP_FormClosed);
                    AP.Show();
                break;

                default:
                    logThis("Password incorrect. Access denied.");
                break;
            }

        }

        void AP_FormClosed(object sender, FormClosedEventArgs e)
        {
            admin_panel_button.Enabled = true;
            this.Show();
        }

        void AP_Activated(object sender, EventArgs e)
        {
            admin_panel_button.Enabled = false;
            this.Hide();
        }

        private void admin_password_textbox_Click(object sender, EventArgs e)
        {
            admin_password_textbox.Clear();
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
            //TODO can't write !!!
        }

        private void logThis(String message)
        {
            login_status_label.Text = message;
        }

        private void things_button_Click(object sender, EventArgs e)
        {
            ThingsWindow = new ThingsGameWindow();
            logThis("Things game is running now...");
            ThingsWindow.FormClosed += new FormClosedEventHandler(ThingsWindow_FormClosed);
            GamesButtonsOff();
            ThingsWindow.Show();
        }

        void ThingsWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            GamesButtonsOn();
            logThis("Things game ended.");
        }

        private void user_name_textbox_TextChanged(object sender, EventArgs e)
        {
            user_name_textbox.Clear();
        }

        private void reflex_button_Click(object sender, EventArgs e)
        {
            ReflexWindow = new ReflexGameWindow();
            logThis("Reflex game is running now...");
            ReflexWindow.FormClosed += new FormClosedEventHandler(ReflexWindow_FormClosed);
            GamesButtonsOff();
            ReflexWindow.Show();
        }

        void ReflexWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            GamesButtonsOn();
            logThis("Reflex game ended.");
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
