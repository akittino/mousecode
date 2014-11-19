using System;
using System.Drawing;
using System.Windows.Forms;

namespace mysz
{
    public partial class MainGameWindowBase : Form
    {
        readonly Label helpLabel, titleLabel, exitLabel, backLabel, settingsLabel;
        Button playButton;
        TextBox instructionTextBox;
        public MainGameWindowBase(Label helpLabel, Label titleLabel, Label exitLabel, Label backLabel, Label settingsLabel,
            Button playButton, TextBox instructionTextBox)
        {
            this.helpLabel = helpLabel;
            this.titleLabel = titleLabel;
            this.exitLabel = exitLabel;
            this.backLabel = backLabel;
            this.settingsLabel = settingsLabel;
            this.playButton = playButton;
            this.instructionTextBox = instructionTextBox;

        }

        public MainGameWindowBase()
        { }

        public void highlightLabel(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.BlueViolet;
        }

        public void removeHighlightLabel(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.Black;
        }

        public void buttonHighlight(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.BlueViolet;
        }

        public void removeHighlightButton(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.Indigo;
        }

        public int setTimeButton_Click(object sender, EventArgs e, string secondsS, Button button)
        {
            int seconds = Convert.ToInt32(secondsS);
            button.BackColor = Color.ForestGreen;
            return seconds;
        }

        public void textbox_TextChanged(object sender, EventArgs e, TextBox seconds, Button timeButton)
        {
            
            timeButton.BackColor = Color.LightGray;
            if (!seconds.Text.Equals(""))
            {
                timeButton.Enabled = true;
            }
            else
            {
                timeButton.Enabled = false;
            }
        }

       
    }
}
