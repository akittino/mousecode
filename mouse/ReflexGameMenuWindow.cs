using System;
using System.Drawing;
using System.Windows.Forms;

namespace mysz
{
    public partial class ReflexGameMenuWindow : GameMenuWindowBase
    {
        ReflexGameWindow ReflexWindow;
        string userName;
        int seconds = 4;

        public ReflexGameMenuWindow(string userName)
        {
            InitializeComponent();
            GameMenuWindowBase BaseWindow = new GameMenuWindowBase(helpLabel, titleLabel1, exitLabel, backLabel, settingsLabel,
            playButton, instructionTextBox);
            this.userName = userName;
            titleLabel1.Text = "Welcome \n" + userName + "!";
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
            secondsLabel.Visible = true;
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
            
            if (System.Text.RegularExpressions.Regex.IsMatch(secondsTextbox.Text, "^[a-zA-Z]+$"))
            {
                MessageBox.Show("Please enter only numbers.");
                secondsTextbox.Text = "";
            }
            if (secondsTextbox.Text.Length > 2)
            {
                MessageBox.Show("Please enter only two numbers.");
                secondsTextbox.Text = "";
            }

            base.textbox_TextChanged(sender, e, secondsTextbox, setTimeButton); 
        }

        private void setTimeButton_Click(object sender, EventArgs e)
        {
            string secondsS = "";
            int secondsValidator = 0;
            if (secondsTextbox.Text != "")
            {
                try
                {
                    secondsS = secondsTextbox.Text;
                    secondsValidator = Convert.ToInt32(secondsS);
                    secondsS = "0";
                }
                catch
                {
                    MessageBox.Show("Please enter seconds in valid format.");
                    secondsTextbox.Text = "";
                    secondsS = "1000";
                    //workaround
                }
            }
            if (!String.IsNullOrEmpty(secondsTextbox.Text) && (secondsValidator < 2 || secondsValidator > 10))
            {
                MessageBox.Show("Please enter seconds in range from 2 to 10.");
                secondsTextbox.Text = "";
            }

            else
            {
                int time = 0;
                if (secondsS != "1000")
                    time = base.setTimeButton_Click(sender, e, secondsTextbox.Text, setTimeButton);

                seconds = time;
            }
        }

        public void settingsComponents()
        {
            gameTimeLabel.Visible = false;
            secondsLabel.Visible = false;
            secondsTextbox.Visible = false;
            setTimeButton.Visible = false;
        }
    }
}
