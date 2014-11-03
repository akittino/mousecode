using System;
using System.Drawing;
using System.Windows.Forms;

namespace mysz
{
    public partial class ReflexGameMenuWindow : MainGameWindowBase
    {
        ReflexGameWindow ReflexWindow;
        MoodWindow MoodWindow;
        string userName;
        MoodWindow.Mood mood;
        public ReflexGameMenuWindow(MoodWindow.Mood mood, string userName)
        {
            InitializeComponent();
            MainGameWindowBase BaseWindow = new MainGameWindowBase(helpLabel, titleLabel1, exitLabel, backLabel, settingsLabel,
            playButton, instructionTextBox);
            this.userName = userName;
            titleLabel1.Text = "Welcome " + userName + "!";
            this.mood = mood;
            //MessageBox.Show(mood.ToString()); for testing only - to show that the mood parameter was passed through
        }

       
        private void playButton_Click(object sender, EventArgs e)
        {
            ReflexWindow = new ReflexGameWindow(userName);
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
            chooseMoodLabel.Visible = true;
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
            chooseMoodLabel.Visible = true;
            backLabel.Location = new Point
            {
                X = 96,
                Y = 260
            };
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
            chooseMoodLabel.Visible = true;
        }

        private void chooseMoodLabel_Click(object sender, EventArgs e)
        {
            MoodWindow = new MoodWindow(MoodWindow.GameType.ReflexWindow, userName);
            MoodWindow.Show();
            
            //TODO unable game if mood is not choosen
            //TODO GUI changes - visibility when Settings etc clicked
        }

    }
}
