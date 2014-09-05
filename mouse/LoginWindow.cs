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
        public login_main_window()
        {
            InitializeComponent();
        }

        private void admin_panel_button_Click(object sender, EventArgs e)
        {
            admin_panel_button.Enabled = false;
            //TODO enable button when close admin panel
            new AdminPanel().Show();
        }
    }
}
