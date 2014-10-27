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

       
    }
}
