using System;
using System.Drawing;
using System.Windows.Forms;

namespace mysz
{
    public partial class ColorsGameMenuWindow : MainGameWindowBase
    {
        ColorsGameWindow ColorsWindow;
        string userName;
        int seconds = 0, minutes = 0;

        public ColorsGameMenuWindow(string userName)
        {
            InitializeComponent();
            MainGameWindowBase BaseWindow = new MainGameWindowBase(helpLabel, titleLabel1, exitLabel, backLabel, settingsLabel,
            playButton, instructionTextBox);
            this.userName = userName;
            titleLabel1.Text = "Welcome " + userName +"!";
        }
       
        public void playButtonClick(object sender, EventArgs e)
        {
            ColorsWindow = new ColorsGameWindow(userName, seconds, minutes);
            ColorsWindow.FormClosed += new FormClosedEventHandler(ColorsWindow_FormClosed);
            ColorsWindow.Show();
            this.Hide();
        }

        void ColorsWindow_FormClosed(object sender, FormClosedEventArgs e)
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
            gameTimeLabel.Visible = true;
            minutesLabel.Visible = true;
            secondsLabel.Visible = true;
            minutesTextbox.Visible = true;
            secondsTextbox.Visible = true;
            setTimeButton.Visible = true;
            
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
            settingsComponents();
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
            settingsComponents();
        }
        public new void highlightLabel(object sender, EventArgs e)
        {
            base.highlightLabel(sender, e);
        }

        public new void removeHighlightLabel(object sender, EventArgs e)
        {
            base.removeHighlightLabel(sender, e);
        }

        public new void buttonHighlight(object sender, EventArgs e)
        {
            base.buttonHighlight(sender, e);
        }

        public new void removeHighlightButton(object sender, EventArgs e)
        {
            base.removeHighlightButton(sender, e);
        }

        public void settingsComponents()
        {
            gameTimeLabel.Visible = false;
            minutesLabel.Visible = false;
            secondsLabel.Visible = false;
            minutesTextbox.Visible = false;
            secondsTextbox.Visible = false;
            setTimeButton.Visible = false;
        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {
            if (!minutesTextbox.Text.Equals("") && !secondsTextbox.Text.Equals(""))
            {
                setTimeButton.Enabled = true;
            }
            else
            {
                setTimeButton.Enabled = false;
            }
        }

        private void setTimeButton_Click(object sender, EventArgs e)
        {
            seconds = Convert.ToInt32(secondsTextbox.Text);
            minutes = Convert.ToInt32(minutesTextbox.Text);
        }
    }

}
