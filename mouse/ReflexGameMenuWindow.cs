using System;
using System.Drawing;
using System.Windows.Forms;

namespace mysz
{
    public partial class ReflexGameMenuWindow : MainGameWindowBase
    {
        ReflexGameWindow ReflexWindow;
        string userName;
        int seconds = 5, minutes = 0;

        public ReflexGameMenuWindow(string userName)
        {
            InitializeComponent();
            MainGameWindowBase BaseWindow = new MainGameWindowBase(helpLabel, titleLabel1, exitLabel, backLabel, settingsLabel,
            playButton, instructionTextBox);
            this.userName = userName;
            titleLabel1.Text = "Welcome " + userName + "!";
        }
       
        private void playButton_Click(object sender, EventArgs e)
        {
            ReflexWindow = new ReflexGameWindow(userName, seconds);
            ReflexWindow.FormClosed += new FormClosedEventHandler(ReflexWindow_FormClosed);
            ReflexWindow.Show();
            this.Hide();
        }

        void ReflexWindow_FormClosed(object sender, FormClosedEventArgs e)
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
            playButton.Enabled = false;
            setTimeButton.BackColor = Color.LightGray;
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
            playButton.Enabled = false;
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

        private void backGameWindow(object sender, EventArgs e)
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
            playButton.Enabled = true;
        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(minutesTextbox.Text, "^[a-zA-Z]+$"))
            {
                MessageBox.Show("Please enter only numbers.");
                minutesTextbox.Text = "";
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(secondsTextbox.Text, "^[a-zA-Z]+$"))
            {
                MessageBox.Show("Please enter only numbers.");
                secondsTextbox.Text = "";
            }
            base.textbox_TextChanged(sender, e, minutesTextbox, secondsTextbox, setTimeButton);
        }

        private void setTimeButton_Click(object sender, EventArgs e)
        {
            int time = base.setTimeButton_Click(sender, e, secondsTextbox.Text, minutesTextbox.Text, setTimeButton);
            seconds = time % 60;
            minutes = time / 60;

            /*** WORKAROUND BELOW ***/
            //TODO@DAX change this window to ask only about seconds per question with one textbox with seconds, and validate if it's 2 <= x <= 10
                //Seconds per question
                seconds = Convert.ToInt32(secondsTextbox.Text);
                if (seconds > 10 || seconds < 2)
                {
                    MessageBox.Show("Time per question should be at least 2 seconds and max 10 seconds!");
                    seconds = 5;
                }

            /*** WORKAROUND ABOVE ***/
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
    }
}
