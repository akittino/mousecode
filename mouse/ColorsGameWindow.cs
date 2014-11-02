using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace mysz
{
    public partial class ColorsGameWindow : MouseForm
    {
        const int CHART_WIDTH = 800;
        const int CHART_HEIGHT = 600;
        const int GRANULATION = 5;
        bool firstRun = true;
        List<string> CoordsList;
        Thread CoordinateSaver;
        DateTime startTime;
        Graphics graphics;
        List<Color> circleColorsBase = new List<Color>();
        List<string> textColorsBase = new List<string>();
        Boolean yesButtonClicked = false;
        Boolean noButtonClicked = false;
        int gameScore = 0;
        Color circleBrushColor;
        String textColor;
        public static AutoResetEvent arEvent = new AutoResetEvent(false);
        int minutes = 0, seconds = 0;


        public ColorsGameWindow()
        {
            InitializeComponent();
            SetMouseForm(gameWindow, CHART_WIDTH, CHART_HEIGHT);
            CoordsList = new List<String>();
            CoordinateSaver = new Thread(SaveCoordinates);
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



        }

        void SaveCoordinates()
        // writing coordinates to list of coords
        {
            int LastX = 0, LastY = 0;
            while (true)
            {
                if (!(LastX + GRANULATION > GetX() && LastX - GRANULATION < GetX() && LastY + GRANULATION > GetY() && LastY - GRANULATION < GetY()))
                {
                    CoordsList.Add(string.Format("    {0}            {1}", GetXString(), GetYString()));
                    LastX = GetX();
                    LastY = GetY();
                }
                Thread.Sleep(10);
            }
        }
        public new void highlightLabel(object sender, EventArgs e)
        {
            base.highlightLabel(sender, e);
        }

        public new void removeHighlightLabel(object sender, EventArgs e)
        {
            base.removeHighlightLabel(sender, e);
        }

        private void endGame(object sender, EventArgs e)
        {
            this.Close();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            playButton.Visible = false;
            animation();
            
            yesButton.Visible = true;
            noButton.Visible = true;
            minutes = 1;
            seconds = 0;

            minutesLabel.Text = minutes.ToString();
            minutesLabel.Visible = true;
            label1.Visible = true;
            if(seconds<10)
                secondsLabel.Text = "0" + seconds.ToString();
            secondsLabel.Visible = true;

            timer1.Start();
            drawEclipse();
            yesButtonClicked = false;
            noButtonClicked = false;
            //TODO cursor back to middle of the circle
            //TODO wait for button to be clicked

            

        }
        private void animation()
        {
            graphics.Clear(Color.White);
            writeToPictureBox("3", 320, 180, 100);
            Thread.Sleep(1000);
            graphics.Clear(Color.White);
            writeToPictureBox("2", 320, 180, 100);
            Thread.Sleep(1000);
            graphics.Clear(Color.White);
            writeToPictureBox("1", 320, 180, 100);
            Thread.Sleep(1000);
            graphics.Clear(Color.White);
            writeToPictureBox("GO!", 280, 180, 100);
            Thread.Sleep(1000);
            graphics.Clear(Color.White);
        }

        private void drawEclipse()
        {
            gameWindow.Refresh();
            scoreNumber.Visible = true;
            gameScore = Convert.ToInt32(scoreNumber.Text);
            Random rnd = new Random();
            circleBrushColor = circleColorsBase[rnd.Next(0, 5)];
            SolidBrush circleBrush = new SolidBrush(circleBrushColor);

            graphics.FillEllipse(circleBrush, 200, 80, 400, 400);
            textColor = textColorsBase[rnd.Next(0, 5)];
            graphics.DrawString(textColor, new Font("Gabriola", 80), Brushes.White, new Point(280, 180));
            if ((textColor == circleBrushColor.ToString())
                || (textColor != circleBrushColor.ToString()))
            {
                gameScore++;
                scoreNumber.Text = gameScore.ToString();
                scoreNumber.Refresh();
            }


        }

        public void writeToPictureBox(String text, int X, int Y, int fontSize)
        {
            using (Font myFont = new Font("Gabriola", fontSize))
            {
                graphics.DrawString(text, myFont, Brushes.Black, new Point(X, Y));
            }
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            yesButtonClicked = true;
            noButtonClicked = false;
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            yesButtonClicked = false;
            noButtonClicked = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds -= 1;
            if (seconds == -1)
            {
                minutes -= 1;
                seconds = 59;
            }
            if (minutes == 0 && seconds == 0)
                timer1.Stop();

            string minutesS = minutes.ToString();
            string secondsS = seconds.ToString();

            minutesLabel.Text = minutesS;
            if (seconds < 10)
                secondsLabel.Text = "0" + secondsS;
            else
                secondsLabel.Text = secondsS;
        }
    }
}
