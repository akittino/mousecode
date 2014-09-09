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
    public partial class ThingsGameWindow : Form
    {
        public ThingsGameWindow()
        {
            InitializeComponent();
        }

        private void highlightLabel(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.BlueViolet;

        }

        private void removeHighlightLabel(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.Black;
        }

        private void buttonHighlight(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.BlueViolet;
        }

        private void removeHighlightButton(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.Indigo;
        }

        private void exitClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void settingsClick(object sender, EventArgs e)
        {
            playButton.Visible = false;
            helpLabel.Visible = false;
            titleLabel.Visible = false;
            exitLabel.Visible = false;
            backLabel.Visible = true;
            instructionTextBox.Visible = false;
            endGameLabel.Visible = false;
        }

        private void helpClick(object sender, EventArgs e)
        {
            playButton.Visible = false;
            settingsLabel.Visible = false;
            titleLabel.Visible = false;
            exitLabel.Visible = false;
            backLabel.Visible = true;
            instructionTextBox.Visible = true;
            endGameLabel.Visible = false;
            backLabel.Location = new Point
            {
                X = 96,
                Y = 226
            };
        }

        private void playButtonClick(object sender, EventArgs e)
        {
            playButton.Visible = false;
            settingsLabel.Visible = false;
            titleLabel.Visible = false;
            exitLabel.Visible = false;
            helpLabel.Visible = false;
            endGameLabel.Visible = true;
        }

        private void backThingsGameWindow(object sender, MouseEventArgs e)
        {
            playButton.Visible = true;
            if (helpLabel.Visible == true)
            {
                settingsLabel.Visible = true;
            }
            else if (endGameLabel.Visible == true)
            {
                settingsLabel.Visible = true;
                helpLabel.Visible = true;
            }
            else
            {
                helpLabel.Visible = true;
            }
            titleLabel.Visible = true;
            exitLabel.Visible = true;
            backLabel.Visible = false;
            endGameLabel.Visible = false;
        }
    }
}
