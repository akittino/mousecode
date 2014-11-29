using System;
using System.Drawing;
using System.Windows.Forms;

namespace mysz
{
    public partial class MoodWindow : Form
    {
        MoodFromHappyToAngryScale moodHAScale = MoodFromHappyToAngryScale.Normal;
        MoodFromExcitedToBoredScale moodBEScale = MoodFromExcitedToBoredScale.Bored;
        bool buttonMoodHSClicked = false;
        bool buttonMoodBEClicked = false;
        Bitmap whiteBitmap = new Bitmap(60, 60);

        MoodFromHappyToAngryScale getHS;
        MoodFromExcitedToBoredScale getBE;


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

        public enum MoodFromExcitedToBoredScale
        {
            Very_Excited = 1,
            Excited = 2,
            Normal = 3,
            Bored = 4,
            Very_Bored = 5
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

        private void angryButton_Click(object sender, EventArgs e)
        {
            moodHAScale = MoodFromHappyToAngryScale.Angry;
            buttonMoodHSClicked = true;
            resetLabelsHS();
            buttonChoosen(angryLabel);
        }

        private void veryExcitedButton_Click(object sender, EventArgs e)
        {
            moodBEScale = MoodFromExcitedToBoredScale.Excited;
            buttonMoodBEClicked = true;
            resetLabelsBE();
            buttonChoosen(veryExcitedLabel);
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
            moodBEScale = MoodFromExcitedToBoredScale.Bored;
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
            veryHappyLabel.Text = "Very Happy";
            veryHappyLabel.ForeColor = Color.Black;
            happyLabel.Text = "Happy";
            happyLabel.ForeColor = Color.Black;
            normalLabel.Text = "Normal";
            normalLabel.ForeColor = Color.Black;
            angryLabel.Text = "Angry";
            angryLabel.ForeColor = Color.Black;
            veryAngryLabel.Text = "Very Angry";
            veryAngryLabel.ForeColor = Color.Black;
        }

        private void resetLabelsBE()
        {
            veryExcitedLabel.Text = "Very Excited";
            veryExcitedLabel.ForeColor = Color.Black;
            excitedLabel.Text = "Excited";
            excitedLabel.ForeColor = Color.Black;
            normalBELabel.Text = "Normal";
            normalBELabel.ForeColor = Color.Black;
            boredLabel.Text = "Bored";
            boredLabel.ForeColor = Color.Black;
            veryBoredLabel.Text = "Very Bored";
            veryBoredLabel.ForeColor = Color.Black;
        }

        private void excitedButton_Click(object sender, EventArgs e)
        {
            moodBEScale = MoodFromExcitedToBoredScale.Excited;
            buttonMoodBEClicked = true;
            resetLabelsBE();
            buttonChoosen(excitedLabel);
        }

        private void normalBEButton_Click(object sender, EventArgs e)
        {
            moodBEScale = MoodFromExcitedToBoredScale.Normal;
            buttonMoodBEClicked = true;
            resetLabelsBE();
            buttonChoosen(normalBELabel);
        }

        private void veryBoredButton_Click(object sender, EventArgs e)
        {
            moodBEScale = MoodFromExcitedToBoredScale.Very_Bored;
            buttonMoodBEClicked = true;
            resetLabelsBE();
            buttonChoosen(veryBoredLabel);
        }

        public Tuple<MoodFromHappyToAngryScale, MoodFromExcitedToBoredScale> getMoods()
        {
            getHS = GetMoodHS();
            getBE = GetMoodBE();
            return Tuple.Create(getHS, getBE);
        }

        public MoodFromHappyToAngryScale GetMoodHS()
        {
            getHS = moodHAScale;
            return getHS;
        }

        public MoodFromExcitedToBoredScale GetMoodBE()
        {
            getBE = moodBEScale;
            return getBE;
        }

    }
}
