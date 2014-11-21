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

        readonly int INITIAL_GAME_TIME;
        DateTime startTime;

        Graphics graphics;
        MoodWindow.Mood mood;

        List<Color> circleColorsBase = new List<Color>();
        List<string> textColorsBase = new List<string>();
        Color circleBrushColor;
        String textColor;

        bool correctAnswer = false;
        int gameScore = 0;
        bool firstRun = true;
        int quantityOfAnswers = 0;
        string userName;
        bool useLeftButtonYES = false;
        bool useRightButtonNO = false;
        int minutes = 0, seconds = 0;
        int gameId = 0;
        int maxGameTime = 5;

        Thread BackgroundProcessing;
        Thread CoordinateSaver;
        Thread Timer;
        List<Point> CoordsList;

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
            CoordsList = new List<Point>();
            CoordinateSaver = new Thread(SaveCoordinates);
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

        private void endGame(object sender, EventArgs e)
        {
            this.Close();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            scoreNumber.Text = gameScore.ToString();
            scoreNumber.Refresh();
            playButton.Visible = false;
            continueButton.Visible = false;

            BackgroundProcessing = new Thread(pushedPlayButton);
            BackgroundProcessing.Start();
        }

        private void pushedPlayButton()
        {
            if (firstRun == true)
            {
                animation();
            }
            this.BeginInvoke((MethodInvoker)delegate()
            {
                graphics.Clear(Color.White);
                moveCursor();

                yesButton.Visible = true;
                noButton.Visible = true;

                timeLabel.Text = minutes.ToString();
                timeLabel.Visible = true;

                startTime = DateTime.Now;

                drawEclipse();
                CoordsList.Clear();
            });

            Timer = new Thread(TimeCountdown);
            Timer.Start();

            CoordinateSaver = new Thread(SaveCoordinates);
            CoordinateSaver.Start();
        }

        private void animationFun(string sign)
        {
            graphics.Clear(Color.White);
            writeToPictureBox(graphics, sign, 320, 180, 100);
        }

        private void animation()
        {
            string[] signs = { "3", "2", "1", "GO!" };

            for (int i = 0; i < signs.Length; ++i)
            {
                this.gameWindow.BeginInvoke((MethodInvoker)delegate()
                {
                    animationFun(signs[i]);
                });
                Thread.Sleep(1000);
            }
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

        private void yesButton_Click(object sender, EventArgs e)
        {
            startTime = DateTime.Now;

            if ((textColor == circleBrushColor.Name.ToString()))
            {
                gameScore++;
                scoreNumber.Text = gameScore.ToString();
                scoreNumber.Refresh();
                correctAnswer = true;
            }
            quantityOfAnswers++;
            useLeftButtonYES = true;
            if (Timer.IsAlive)
                Timer.Abort();

            if (CoordinateSaver.IsAlive)
                CoordinateSaver.Abort();

            WriteCoordinatesToFile(String.Format("{0:N2} s", (DateTime.Now - startTime).TotalSeconds));

            decreaseGameTime();

            CoordsList.Clear();
            continueButton.Visible = true;
            gameWindow.Refresh();
            timeLabel.Visible = false;
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            startTime = DateTime.Now;

            if (textColor != circleBrushColor.Name.ToString())
            {
                gameScore++;
                scoreNumber.Text = gameScore.ToString();
                scoreNumber.Refresh();
            }
            quantityOfAnswers++;
            useRightButtonNO = true;
            if (Timer.IsAlive)
                Timer.Abort();
            if (CoordinateSaver.IsAlive) CoordinateSaver.Abort();
            WriteCoordinatesToFile(String.Format("{0:N2} s", (DateTime.Now - startTime).TotalSeconds));

            decreaseGameTime();

            CoordsList.Clear();
            continueButton.Visible = true;
            gameWindow.Refresh();
            timeLabel.Visible = false;
        }

        private void moveCursor()
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point((gameWindow.Size.Width / 2) + gameWindow.Location.X + this.Location.X,
                30 + gameWindow.Location.Y + this.Location.Y);
        }
        void SaveCoordinates()
        // writing coordinates to list of coords
        {
            base.SaveCoordinates(GRANULATION, CoordsList);
        }

        void WriteCoordinatesToFile(String gameTimeString)
        {
            firstRun = false;
            String name;
            String dirPath = @".\ColorsGame\" + userName + @"\" + String.Format("{0:yyyy-MM-dd}", DateTime.Now);

            if (gameId == 0)
            {
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                    gameId = 1;
                }
                else
                {
                    gameId = ((new DirectoryInfo(dirPath)).GetDirectories().Length + 1);
                }
            }
            if (useLeftButtonYES)
                dirPath += @"\" + gameId.ToString() + @"\L";
            else
                dirPath += @"\" + gameId.ToString() + @"\P";

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            name = dirPath + @"\" + String.Format("{0:HH-mm-ss}", DateTime.Now) + ".csv";

            using (StreamWriter sw = new StreamWriter(name))
            {
                sw.WriteLine("Correct Answer: " + (correctAnswer == true ? "YES" : "NO"));
                sw.WriteLine(gameTimeString + " / " + maxGameTime + " s");

                foreach (Point p in CoordsList)
                {
                    sw.WriteLine(p.X + " , " + p.Y);
                }
            }
            useRightButtonNO = false;
            useLeftButtonYES = false;
        }
        private void TimeCountdown()
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
                firstRun = true;

                playButton.Location = new Point(450, 148);
                playButton.Text = "PLAY AGAIN";

                yesButton.Visible = false;
                noButton.Visible = false;
                if (CoordinateSaver.IsAlive) CoordinateSaver.Abort();
                if (Timer.IsAlive) Timer.Abort();
                playButton.Visible = true;
                writeToPictureBox(graphics, "Time's up, your score is " + scoreNumber.Text + ". Congratulations!", 200, 300, 20);
                if (gameScore != 0)
                    writeGameDetails();

                gameScore = 0;
                gameId = 0;
                maxGameTime = INITIAL_GAME_TIME;
                scoreNumber.Text = gameScore.ToString();

            });

        }
        private void decreaseGameTime()
        {
            if ((quantityOfAnswers % 10 == 0) && (maxGameTime > 1))
            {
                --maxGameTime;
            }
        }
        private void writeGameDetails()
        {
            MoodWindow.Mood mood = getMood();
            String fileName = @".\ColorsGame\" + userName + @"\" + String.Format("{0:yyyy-MM-dd}", DateTime.Now) +
                              @"\" + gameId.ToString() + @"\gameDetails.txt";

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine("Mood: " + mood.ToString());
                sw.WriteLine("Score: " + scoreNumber.Text + "/" + quantityOfAnswers.ToString());
                sw.WriteLine("Initial game time: " + INITIAL_GAME_TIME.ToString());
            }
        }

        private void ColorsGameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Timer != null && Timer.IsAlive)
                Timer.Abort();
            if (CoordinateSaver != null && CoordinateSaver.IsAlive)
                CoordinateSaver.Abort();
            if (BackgroundProcessing != null && BackgroundProcessing.IsAlive)
                BackgroundProcessing.Abort();
            if (gameScore != 0)
                writeGameDetails();
        }
    }
}
