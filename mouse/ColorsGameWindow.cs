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
        List<string> CoordsList;
        Graphics graphics;
        List<Color> circleColorsBase = new List<Color>();
        List<string> textColorsBase = new List<string>();
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

            // this must be convertible from settings (default 1minute)
            minutes = 1;
            seconds = 0;

            minutesLabel.Text = minutes.ToString();
            minutesLabel.Visible = true;
            label1.Visible = true;
            if (seconds < 10)
                secondsLabel.Text = "0" + seconds.ToString();
            secondsLabel.Visible = true;

            timer1.Start();
            drawEclipse();
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
            //TODO first it should be randomized if the colors should be different or no, cuz now there 1% chance to be the same!
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
            if ((textColor == circleBrushColor.Name.ToString()))
            {
                gameScore++;
                scoreNumber.Text = gameScore.ToString();
                scoreNumber.Refresh();
            }
            if (seconds >= 0)
            {
                moveCursor();
                drawEclipse();
            }
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            if (textColor != circleBrushColor.Name.ToString())
            {
                gameScore++;
                scoreNumber.Text = gameScore.ToString();
                scoreNumber.Refresh();
            }
            if (seconds >= 0)
            {
                moveCursor();
                drawEclipse();
            }
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

            if (seconds == 0)
            {
                gameWindow.Refresh();
                writeToPictureBox("Time's up, your score is " + scoreNumber.Text + ". Congratulations!", 250, 300, 20);
            }
        }
        private void moveCursor()
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            //TODO make dependency on where the window is docked, cuz when move the window, it move cursor to wrong place
            //possible fix below
            Cursor.Position = new Point((gameWindow.Size.Width / 2) + gameWindow.Location.X + this.Location.X, 
                (gameWindow.Size.Height / 2) + gameWindow.Location.Y + this.Location.Y);    
            //Cursor.Position = new Point(640, 400);       

        }
    }
}
