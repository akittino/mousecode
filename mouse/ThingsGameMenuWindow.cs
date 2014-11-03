using System;
using System.Drawing;
using System.Windows.Forms;

namespace mysz
{
    public partial class ThingsGameMenuWindow : MainGameWindowBase
    {
        ThingsGameWindow ThingsWindow;
        MoodWindow MoodWindow;        
        public string userName;

        public ThingsGameMenuWindow(string userName)
        {
            InitializeComponent();
            MainGameWindowBase BaseWindow = new MainGameWindowBase(helpLabel, titleLabel1, exitLabel, backLabel, settingsLabel,
            playButton, instructionTextBox);
            this.userName = userName;
            titleLabel1.Text = "Welcome " + userName + "!";
        }

        public void playButtonClick(object sender, EventArgs e)
        {
            ThingsWindow = new ThingsGameWindow(userName);
            ThingsWindow.FormClosed += new FormClosedEventHandler(ThingsWindow_FormClosed);
            ThingsWindow.Show();
            this.Hide();
        }

        void ThingsWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        public void exitClick(object sender, EventArgs e)
        {
            this.Close();
        }

        public void settingsClick(object sender, EventArgs e)
        {
            playButton.Visible = false;
            helpLabel.Visible = false;
            titleLabel1.Visible = false;
            exitLabel.Visible = false;
            backLabel.Visible = true;
            instructionTextBox.Visible = false;
        }

        public void helpClick(object sender, EventArgs e)
        {
            playButton.Visible = false;
            settingsLabel.Visible = false;
            titleLabel1.Visible = false;
            exitLabel.Visible = false;
            backLabel.Visible = true;
            instructionTextBox.Visible = true;
            backLabel.Location = new Point
            {
                X = 96,
                Y = 226
            };
        }

        public void backGameWindow(object sender, MouseEventArgs e)
        {
            playButton.Visible = true;
            if (helpLabel.Visible == true)
            {
                settingsLabel.Visible = true;
            }
            else
            {
                helpLabel.Visible = true;
            }
            titleLabel1.Visible = true;
            exitLabel.Visible = true;
            backLabel.Visible = false;
        }

        public new void highlightLabel(object sender, EventArgs e)
        {
            base.highlightLabel(sender, e);
        }

        public new void removeHighlightLabel(object sender, EventArgs e)
        {
            base.removeHighlightLabel(sender, e);
        }

        public new void removeHighlightButton(object sender, EventArgs e)
        {
            base.removeHighlightButton(sender, e);
        }

        public new void buttonHighlight(object sender, EventArgs e)
        {
            base.buttonHighlight(sender, e);
        }

    }
}
