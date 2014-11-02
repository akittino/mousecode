using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace mysz
{
    public partial class ColorsGameWindow : MouseForm
    {
        const int CHART_WIDTH = 800;
        const int CHART_HEIGHT = 600;
        const int GRANULATION = 5;
        Graphics graphics;
        List<Color> circleColorsBase = new List<Color>();
        List<string> textColorsBase = new List<string>();
        int gameScore = 0;
        Color circleBrushColor;
        String textColor;
        int minutes = 0, seconds = 0;
        Thread CoordinateSaver;
        List<Point> CoordsList;
        bool firstRun = true;
        string userName;
        int quantityOfAnswers = 0;

        public ColorsGameWindow(string userName, int seconds, int minutes)
        {
            InitializeComponent();
            SetMouseForm(gameWindow, CHART_WIDTH, CHART_HEIGHT);
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
            CoordsList = new List<Point>();
            CoordinateSaver = new Thread(SaveCoordinates);
            this.userName = userName;
            if (minutes * 60 + seconds != 0)
            {
                this.seconds = seconds;
                this.minutes = minutes;
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
            gameScore = 0;
            scoreNumber.Text = "0";
            scoreNumber.Refresh();
            playButton.Visible = false;
            animation();

            yesButton.Visible = true;
            noButton.Visible = true;

            // this must be convertible from settings (default 1minute)
            setTime();

            minutesLabel.Text = minutes.ToString();
            minutesLabel.Visible = true;
            label1.Visible = true;
            if (seconds < 10)
                secondsLabel.Text = "0" + seconds.ToString();
            secondsLabel.Visible = true;

            timer1.Start();
            drawEclipse();
            CoordsList.Clear();
            if (firstRun)
            {
                CoordinateSaver.Start();
                firstRun = false;
            }
            else
            {
                CoordinateSaver.Resume();
            }
        }
        public void setTime()
        {
            int gameTime = base.setTime(seconds, minutes);
            minutes = gameTime / 60;
            seconds = gameTime % 60;
        }

        private void animation()
        {
            graphics.Clear(Color.White);
            writeToPictureBox(graphics, "3", 320, 180, 100);
            Thread.Sleep(1000);
            graphics.Clear(Color.White);
            writeToPictureBox(graphics, "2", 320, 180, 100);
            Thread.Sleep(1000);
            graphics.Clear(Color.White);
            writeToPictureBox(graphics, "1", 320, 180, 100);
            Thread.Sleep(1000);
            graphics.Clear(Color.White);
            writeToPictureBox(graphics, "GO!", 280, 180, 100);
            Thread.Sleep(1000);
            graphics.Clear(Color.White);
            moveCursor();
        }

        private void drawEclipse()
        {
            gameWindow.Refresh();
            scoreNumber.Visible = true;
            gameScore = Convert.ToInt32(scoreNumber.Text);
            Random rnd = new Random();
            // case if colors of text and eclipse are equal
            if (rnd.Next(0, 100) > 50)
            {
                int r = rnd.Next(0, 5);
                circleBrushColor = circleColorsBase[r];
                graphics.FillEllipse(new SolidBrush(circleBrushColor), 200, 80, 400, 400);
                textColor = textColorsBase[r];
                graphics.DrawString(textColor, new Font("Gabriola", 80), Brushes.White, new Point(280, 180));
            }
            //case when colors of text and eclipse are different
            else
            {
                int r1 = rnd.Next(0, 5);
                int r2 = rnd.Next(0, 5);
                if (r2 == r1)
                {
                    while (r2 == r1)
                    {
                        r2 = rnd.Next(0, 5);
                    }
                }
                circleBrushColor = circleColorsBase[r1];
                graphics.FillEllipse(new SolidBrush(circleBrushColor), 200, 80, 400, 400);
                textColor = textColorsBase[r2];
                graphics.DrawString(textColor, new Font("Gabriola", 80), Brushes.White, new Point(280, 180));
            }

        }

        public void writeToPictureBox(Graphics graphics, String text, int X, int Y, int fontSize)
        {
            base.writeToPictureBox(graphics, text, X, Y, fontSize);
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
            quantityOfAnswers++;
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
            quantityOfAnswers++;
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
                playButton.Location = new Point(450, 148);
                playButton.Text = "PLAY AGAIN";

                playButton.Visible = true;
                writeToPictureBox(graphics, "Time's up, your score is " + scoreNumber.Text + ". Congratulations!", 200, 300, 20);

                yesButton.Visible = false;
                noButton.Visible = false;
                if (CoordinateSaver.IsAlive) CoordinateSaver.Suspend();
                WriteCoordinatesToFile();
            }
        }

        private void moveCursor()
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point((gameWindow.Size.Width / 2) + gameWindow.Location.X + this.Location.X,
                (gameWindow.Size.Height / 2) + gameWindow.Location.Y + this.Location.Y);
        }
        void SaveCoordinates()
        // writing coordinates to list of coords
        {
            base.SaveCoordinates(GRANULATION, CoordsList);
        }

        void WriteCoordinatesToFile()
        {
            String name;
            DateTime dateDT = DateTime.Now;
            string date = dateDT.ToString().Substring(0, 10);
            string time = dateDT.ToString().Substring(10, 9);
            time = time.Replace(":", " ");
            String dirPath = @".\ColorsGame\" + userName + "\\" + date;

            name = dirPath + "\\" + time + ".csv";

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            using (StreamWriter sw = new StreamWriter(name))
            {
                sw.WriteLine("Correct answers: " + scoreNumber.Text + "/" + quantityOfAnswers.ToString());
                foreach (Point p in CoordsList)
                {
                    sw.WriteLine(p.X + " , " + p.Y);
                }
            }

        }
    }
}
