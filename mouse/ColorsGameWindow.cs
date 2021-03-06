﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace mysz
{
    public partial class ColorsGameWindow : MouseForm
    {
        const int CHART_WIDTH = 800;
        const int CHART_HEIGHT = 600;
        const int GRANULATION = 5;
        readonly int INITIAL_GAME_TIME;
        DateTime startTime;

        Graphics graphics;

        List<Color> circleColorsBase = new List<Color>();
        List<string> textColorsBase = new List<string>();
        Color circleBrushColor;
        String textColor;

        bool correctAnswer = false;
        int gameScore = 0;
        int quantityOfAnswers = 0;
        string userName;
        bool leftButtonYESClicked = false;
        int gameId = 0;
        int maxGameTime = 5;

        Thread CoordinateSaver;
        Thread Timer;
        List<TimePoint> CoordsList;

        public ColorsGameWindow(string userName, int initialGameTime)
        {
            InitializeComponent();
            SetMouseForm(gameWindow, CHART_WIDTH, CHART_HEIGHT, null);
            graphics = gameWindow.CreateGraphics();
            circleColorsBase.Add(Color.Red);
            circleColorsBase.Add(Color.Green);
            circleColorsBase.Add(Color.Blue);
            circleColorsBase.Add(Color.Purple);
            circleColorsBase.Add(Color.Yellow);
            circleColorsBase.Add(Color.Pink);
            textColorsBase.Add("Red");
            textColorsBase.Add("Green");
            textColorsBase.Add("Blue");
            textColorsBase.Add("Purple");
            textColorsBase.Add("Yellow");
            textColorsBase.Add("Pink");
            CoordsList = new List<TimePoint>();
            CoordinateSaver = new Thread(saveCoordinates);
            this.userName = userName;
            maxGameTime = INITIAL_GAME_TIME = initialGameTime;
        }

        public new void highlightLabel(object sender, EventArgs e)
        {
            base.highlightLabel(sender, e);
        }

        public new void removeHighlightLabel(object sender, EventArgs e)
        {
            base.removeHighlightLabel(sender, e);
        }

        private void exitGame(object sender, EventArgs e)
        {
            this.Close();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            scoreNumber.Text = gameScore.ToString() + "/" + quantityOfAnswers.ToString();
            scoreNumber.Refresh();
            playButton.Visible = false;
            continueButton.Visible = false;

            pushedPlayButton();
        }

        private void pushedPlayButton()
        {
            graphics.Clear(Color.White);

            yesButton.Visible = true;
            noButton.Visible = true;

            timeLabel.Visible = true;

            startTime = DateTime.Now;

            drawEllipse();
            CoordsList.Clear();

            Timer = new Thread(TimeCountdown);
            Timer.Start();

            CoordinateSaver = new Thread(saveCoordinates);
            CoordinateSaver.Start();
        }

        private void drawEllipse()
        {
            gameWindow.Refresh();
            scoreNumber.Visible = true;
            Random rnd = new Random();
            // case if colors of text and eclipse are equal
            if (rnd.Next(0, 100) > 50)
            {
                int r = rnd.Next(0, 6);
                circleBrushColor = circleColorsBase[r];
                graphics.FillEllipse(new SolidBrush(circleBrushColor), 200, 80, 400, 400);
                textColor = textColorsBase[r];
                drawColorName(textColor);
            }
            //case when colors of text and eclipse are different
            else
            {
                int r1 = rnd.Next(0, 6);
                int r2 = rnd.Next(0, 500)%6;
                while (r2 == r1)
                {
                    r2 = rnd.Next(0, 50)%6;
                }
                circleBrushColor = circleColorsBase[r1];
                graphics.FillEllipse(new SolidBrush(circleBrushColor), 200, 80, 400, 400);
                textColor = textColorsBase[r2];
                drawColorName(textColor);
            }
        }

        private void drawColorName(string textColor)
        {
            int X = 250;
            switch(textColor)
            {
                case "Red":
                    X = 290;
                    break;
                case "Blue":
                    X = 280;
                    break;
                case "Pink":
                    X = 280;
                    break;
                case "Yellow":
                    X = 230;
                    break;
                case "Purple":
                    X = 240;
                    break;
            }
            graphics.DrawString(textColor, new Font("Times New Roman", 80), Brushes.White, new Point(X, 210));
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            startTime = DateTime.Now;
            quantityOfAnswers++;

            if ((textColor == circleBrushColor.Name.ToString()))
            {
                gameScore++;
                correctAnswer = true;
            }

            scoreNumber.Text = gameScore.ToString() + "/" + quantityOfAnswers.ToString();
            scoreNumber.Refresh();

            leftButtonYESClicked = true;
            if (Timer.IsAlive)
                Timer.Abort();

            if (CoordinateSaver.IsAlive)
                CoordinateSaver.Abort();
            gameId = writeCoordinatesToFile((Convert.ToDouble(maxGameTime) - Convert.ToDouble(timeLabel.Text.Remove(timeLabel.Text.Length - 1))) * 1000);


            decreaseGameTime();

            CoordsList.Clear();
            continueButton.Visible = true;
            gameWindow.Refresh();
            timeLabel.Visible = false;
            correctAnswer = false;

            yesButton.Visible = false;
            noButton.Visible = false;
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            startTime = DateTime.Now;

            quantityOfAnswers++;
            if (textColor != circleBrushColor.Name.ToString())
            {
                gameScore++;
                
                correctAnswer = true;
            }
            scoreNumber.Text = gameScore.ToString() + "/" + quantityOfAnswers.ToString();
            scoreNumber.Refresh();

            leftButtonYESClicked = false;
            if (Timer.IsAlive)
                Timer.Abort();
            if (CoordinateSaver.IsAlive) CoordinateSaver.Abort();


            gameId = writeCoordinatesToFile((Convert.ToDouble(maxGameTime) - Convert.ToDouble(timeLabel.Text.Remove(timeLabel.Text.Length - 1))) * 1000);

            decreaseGameTime();

            CoordsList.Clear();
            continueButton.Visible = true;
            gameWindow.Refresh();
            timeLabel.Visible = false;
            correctAnswer = false;

            yesButton.Visible = false;
            noButton.Visible = false;
            
        }

        void saveCoordinates()
        // writing coordinates to list of coords
        {
            base.SaveCoordinates(GRANULATION, CoordsList);
        }

        int writeCoordinatesToFile(double gameTime)
        {
            return base.writeCoordinatesToFile(gameId, "ColorsGame", leftButtonYESClicked, userName, CoordsList, 
                "Correct answer:" + ((correctAnswer == true) ? "YES" : "NO"), gameTime.ToString("F0") + "," + maxGameTime * 1000);
        }

        private new void TimeCountdown()
        {
            DateTime endTime = DateTime.Now.AddSeconds((double)maxGameTime);

            while (endTime >= DateTime.Now)
            {
                this.timeLabel.BeginInvoke((MethodInvoker)delegate()
                {
                    this.timeLabel.Text = String.Format("{0:N2} s", (endTime - DateTime.Now).TotalSeconds);
                });

                Thread.Sleep(10);
            }

            this.timeLabel.BeginInvoke((MethodInvoker)delegate()
            {
                this.timeLabel.Text = "Time out!";
                gameWindow.Refresh();

                playButton.Location = new Point(450, 148);
                playButton.Text = "PLAY AGAIN";

                yesButton.Visible = false;
                noButton.Visible = false;
                if (CoordinateSaver.IsAlive) CoordinateSaver.Abort();
                if (Timer.IsAlive) Timer.Abort();
                playButton.Visible = true;
                writeToPictureBox(graphics, "Time's up, your score is " + scoreNumber.Text + ". Congratulations!", 130, 300, 20);
                if (gameId != 0)
                    writeGameDetails();

                quantityOfAnswers = 0;
                gameScore = 0;
                gameId = 0;
                maxGameTime = INITIAL_GAME_TIME;

            });

        }
        private void decreaseGameTime()
        {
            if (quantityOfAnswers != 0 && quantityOfAnswers % 10 == 0 && maxGameTime > 1)
            {
                --maxGameTime;
            }
        }
        private void writeGameDetails()
        {
            base.writeGameDetails("ColorsGame", userName, gameId, "Score: " + scoreNumber.Text, "Initial game time: " + INITIAL_GAME_TIME.ToString());
        }

        private void ColorsGameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Timer != null && Timer.IsAlive)
                Timer.Abort();
            if (CoordinateSaver != null && CoordinateSaver.IsAlive)
                CoordinateSaver.Abort();
            if (gameId != 0)
                writeGameDetails();
        }
    }
}
