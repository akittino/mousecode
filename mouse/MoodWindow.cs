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
    public partial class MoodWindow : Form
    {
        MoodFromHappyToAngryScale moodHAScale = MoodFromHappyToAngryScale.Normal;
        MoodBoredOrExcited moodBEScale = MoodBoredOrExcited.Bored;
        bool buttonMoodHSClicked = false;
        bool buttonMoodBEClicked = false;
        Bitmap whiteBitmap = new Bitmap(60, 60);


        public MoodWindow()
        {
            InitializeComponent();
        }

        public enum MoodFromHappyToAngryScale
        {
            Very_Happy = 1,
            Happy = 2,
            Normal = 3,
            Angry = 4,
            Very_Angry = 5
        };

        public enum MoodBoredOrExcited
        {
            Excited =1,
            Bored = 2
        };

        private void veryHappyButton_Click(object sender, EventArgs e)
        {
            moodHAScale = MoodFromHappyToAngryScale.Very_Happy;
            buttonMoodHSClicked = true;
            resetLabelsHS();
            buttonChoosen(veryHappyLabel);
            
        }

        private void happyButton_Click(object sender, EventArgs e)
        {
            moodHAScale = MoodFromHappyToAngryScale.Happy;
            buttonMoodHSClicked = true;
            resetLabelsHS();
            buttonChoosen(happyLabel);
            
        }

        private void normalButton_Click(object sender, EventArgs e)
        {
            moodHAScale = MoodFromHappyToAngryScale.Normal;
            buttonMoodHSClicked = true;
            resetLabelsHS();
            buttonChoosen(normalLabel);
            
        }

        private void veryAngryButton_Click(object sender, EventArgs e)
        {
            moodHAScale = MoodFromHappyToAngryScale.Very_Angry;
            buttonMoodHSClicked = true;
            resetLabelsHS();
            buttonChoosen(veryAngryLabel);
        }

        public MoodFromHappyToAngryScale GetMood()
        { 
            MoodFromHappyToAngryScale get = moodHAScale;
            return get;
        }

        private void angryButton_Click(object sender, EventArgs e)
        {
            moodHAScale = MoodFromHappyToAngryScale.Angry;
            buttonMoodHSClicked = true;
            resetLabelsHS();
            buttonChoosen(angryLabel);
        }

        private void excitedButton_Click(object sender, EventArgs e)
        {
            moodBEScale = MoodBoredOrExcited.Excited;
            buttonMoodBEClicked = true;
            resetLabelsBE();
            buttonChoosen(excitedLabel);
        }

        private void answerRButton_Click(object sender, EventArgs e)
        {
            if (buttonMoodBEClicked == true && buttonMoodHSClicked == true)
            {
                this.Close();
            }
        }

        private void boredButton_Click(object sender, EventArgs e)
        {
            moodBEScale = MoodBoredOrExcited.Bored;
            buttonMoodBEClicked = true;
            resetLabelsBE();
            buttonChoosen(boredLabel);
        }

        private void buttonChoosen(Label label)
        {
            label.Text = "Choosen";
            label.ForeColor = Color.Green;
        }

        private void resetLabelsHS()
        {
            angryLabel.Text = "Angry";
            angryLabel.ForeColor = Color.Black;
            veryHappyLabel.Text = "Very happy";
            veryHappyLabel.ForeColor = Color.Black;
            veryAngryLabel.Text = "Very angry";
            veryAngryLabel.ForeColor = Color.Black;
            normalLabel.Text = "Normal";
            normalLabel.ForeColor = Color.Black;
            happyLabel.Text = "Happy";
            happyLabel.ForeColor = Color.Black;
        }

        private void resetLabelsBE()
        {
            excitedLabel.Text = "Excited";
            excitedLabel.ForeColor = Color.Black;
            boredLabel.Text = "Bored";
            boredLabel.ForeColor = Color.Black;
        }
    }
}
