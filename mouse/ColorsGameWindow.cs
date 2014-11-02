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

            drawEclipse();
            yesButtonClicked = false;
            noButtonClicked = false;
            //TODO cursor back to middle of the circle
            //TODO wait for button to be clicked

            if ((textColor == circleBrushColor.ToString() && yesButtonClicked == true)
                || (textColor != circleBrushColor.ToString() && noButtonClicked == true))
            {
                gameScore++;
                scoreNumber.Text = gameScore.ToString();
                scoreNumber.Refresh();
            }


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
            // TODO sth is wrong with random - always textColor == eclipseColor
            gameWindow.Refresh();
            scoreNumber.Visible = true;
            gameScore = Convert.ToInt32(scoreNumber.Text);
            Random rEclipse = new Random();
            Random rText = new Random();
            circleBrushColor = circleColorsBase[rEclipse.Next(0, 5)];
            SolidBrush circleBrush = new SolidBrush(circleBrushColor);

            graphics.FillEllipse(circleBrush, 200, 80, 400, 400);
            textColor = textColorsBase[rText.Next(0, 5)];
            graphics.DrawString(textColor, new Font("Gabriola", 80), Brushes.White, new Point(280, 180));

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
    }
}
