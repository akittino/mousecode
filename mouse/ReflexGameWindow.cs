using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace mysz
{
    public partial class ReflexGameWindow : MouseForm
    {
        enum GameStates
        {
            OutOfGame = 0,
            BeforeGame = 1,
            Waiting = 2
        };

        const int GRANULATION = 5;
        const int CHART_WIDTH = 800;
        const int CHART_HEIGHT = 600;

        readonly string USER_NAME;
        readonly int INITIAL_GAME_TIME;
        readonly Color BACKGROUND_COLOR = Color.White;

        SolidBrush redBrush, greenBrush, blueBrush;
        List<Point> CoordsList;
        Thread CoordinateSaver;
        Thread Timer;
        Random rnd;
        Graphics graphics;
        DateTime startTime;
        GameStates gameState;
        
        bool useLeftButton = true;        
        int gameId = 0;        
        int gameTime;        
        int score = 0;

        public ReflexGameWindow(string userName, int initialGameTime)
        {
            //TODO save status of picturebox, and check minimalizing window
            InitializeComponent();
            SetMouseForm(gameWindow, CHART_WIDTH, CHART_HEIGHT);

            CoordsList = new List<Point>();

            greenBrush = new SolidBrush(Color.Green);
            blueBrush = new SolidBrush(Color.Blue);
            redBrush = new SolidBrush(Color.Red);

            gameTime = INITIAL_GAME_TIME = initialGameTime;
            graphics = gameWindow.CreateGraphics();
            gameState = GameStates.OutOfGame;
            USER_NAME = userName;
            rnd = new Random();
            
            scoreLabel.Text = score.ToString();

            stopRButton.Enabled = false;
            stopLButton.Enabled = false;

            graphics.Clear(BACKGROUND_COLOR);//TODO why nothing appears?
            drawEllipse(blueBrush);//TODO why nothing appears?
        }

        private void TimeCountdown()
        {
            DateTime endTime = DateTime.Now.AddSeconds((double)gameTime);

            while (endTime >= DateTime.Now)
            {
                this.timeLabel.BeginInvoke((MethodInvoker)delegate()
                {
                    this.timeLabel.Text = String.Format("{0:N2} s",
                        (endTime - DateTime.Now).TotalSeconds);
                });

                Thread.Sleep(10);
            }

            this.timeLabel.BeginInvoke((MethodInvoker)delegate()
            {
                this.timeLabel.Text = "Time out!";
            });

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (gameState == GameStates.OutOfGame)
                gameState = GameStates.BeforeGame;

            switch (gameState)
            {
                case GameStates.BeforeGame:
                    firstStartPush();
                    gameState = GameStates.Waiting;
                    waitingCheck();
                    break;

                case GameStates.Waiting:
                    startPush();
                    waitingCheck();
                    break;
            }
        }

        private bool waitingOnButton(DateTime endTime) 
            //if return true that means waiting failed
        {
            int Xmin = startButton.Location.X - gameWindow.Location.X;
            int Ymin = startButton.Location.Y - gameWindow.Location.Y;
            int Xmax = Xmin + startButton.Width;
            int Ymax = Ymin + startButton.Height - 1; 
            // -1 above due to GetY can't be larger then 600 but must detect move out  

            while (DateTime.Now <= endTime)
            {
                if (GetX() > Xmax || GetY() > Ymax ||
                    GetX() < Xmin || GetY() < Ymin)
                {
                    return true;
                }
            }
            return false;
        }

        private void firstStartPush()
        {
            stopRButton.Enabled = false;
            stopRButton.Visible = false;
            stopLButton.Enabled = false;
            stopLButton.Visible = false;
            startButton.Enabled = false;

            startPush();
        }

        private void startPush()
        {
            graphics.Clear(BACKGROUND_COLOR);
            drawEllipse(redBrush);
            writeToPictureBox(graphics, "Don't move mouse cursor out of Start button until circle color change to green.", 150, 280, 15);

        }

        private void pushTheButton()
        {
            graphics.Clear(BACKGROUND_COLOR);
            drawEllipse(greenBrush);
            writeToPictureBox(graphics, "Now! Push Stop button as fast as you can!", 250, 280, 15);

            Timer = new Thread(TimeCountdown);
            Timer.Start();

            timeLabel.Visible = true;
            
            if (rnd.Next(100) >= 50)
            {
                useLeftButton = true;
                stopLButton.Visible = true;
                stopLButton.Enabled = true;
            }
            else
            {
                useLeftButton = false;
                stopRButton.Visible = true;
                stopRButton.Enabled = true;
            }

            startTime = DateTime.Now;
            
            CoordsList.Clear();
            CoordinateSaver = new Thread(saveCoordinates);
            CoordinateSaver.Start();
        }

        private void waitingCheck()
        {
            bool waitingFailed = waitingOnButton(DateTime.Now.AddMilliseconds(2000 + rnd.Next(30) * 100));

            if (waitingFailed)
            {
                graphics.Clear(BACKGROUND_COLOR);
                drawEllipse(blueBrush);

                startButton.Enabled = true;
                
                writeToPictureBox(graphics, "Game paused, please start again.", 270, 250, 15);
                writeToPictureBox(graphics, "Moved out from Start button before circle changed to green.", 200, 280, 15);
            }
            else
            {
                pushTheButton();
                gameState = GameStates.BeforeGame;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = true;
            stopRButton.Enabled = false;
            stopLButton.Enabled = false;

            stopRButton.Visible = false;
            stopLButton.Visible = false;
            timeLabel.Visible = false;

            if (Timer.IsAlive)
                Timer.Abort();

            if (CoordinateSaver.IsAlive)
                CoordinateSaver.Abort();

            writeCoordinatesToFile(String.Format("{0:N2} s", (DateTime.Now - startTime).TotalSeconds));

            graphics.Clear(BACKGROUND_COLOR);
            drawEllipse(blueBrush);

            if (timeLabel.Text.Equals("Time out!"))
            {
                writeToPictureBox(graphics, "Game has just ended due to time out!", 300, 280, 15);
                writeGameDetails();
                
                score = 0;
                gameId = 0;
                gameTime = INITIAL_GAME_TIME;
                gameState = GameStates.OutOfGame;
                scoreLabel.Text = score.ToString();
                
            }
            else
            {
                ++score;
                scoreLabel.Text = score.ToString();

                decreaseGameTime();
                writeToPictureBox(graphics, "Great job! Play next level!", 315, 280, 15);
            }
        }

        private void decreaseGameTime()
        {
            if ((score % 10 == 0) && (gameTime > 2))
            {
                --gameTime;
            }
        }

        private void writeGameDetails()
        {
            MoodWindow.Mood mood = getMood();
            String fileName = @".\ReflexGame\" + USER_NAME + @"\" + String.Format("{0:yyyy-MM-dd}", DateTime.Now) + 
                              @"\" + gameId.ToString() + @"\gameDetails.txt";

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine("Mood: " + mood.ToString());
                sw.WriteLine("Score: " + score.ToString());
                sw.WriteLine("Initial game time: " + INITIAL_GAME_TIME.ToString());
            }
        }

        private void writeCoordinatesToFile(String gameTimeString)
        {
            String name;
            String dirPath = @".\ReflexGame\" + USER_NAME + @"\" + String.Format("{0:yyyy-MM-dd}", DateTime.Now);

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

            if (useLeftButton) 
                dirPath += @"\" + gameId.ToString() + @"\L";
            else 
                dirPath += @"\" + gameId.ToString() + @"\P";

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            name = dirPath + @"\" + String.Format("{0:hh-mm-ss tt}", DateTime.Now) + ".csv";

            using (StreamWriter sw = new StreamWriter(name)) //TODO pathTooLongException
            {
                sw.WriteLine(DateTime.Now.ToString());
                sw.WriteLine(gameTimeString);
                
                foreach (Point p in CoordsList)
                {
                    sw.WriteLine(p.X + " , " + p.Y);
                }
            }
        }

        private void saveCoordinates()
        {
            base.SaveCoordinates(GRANULATION, CoordsList);
        }

        private void drawEllipse(SolidBrush brush)
        {
            graphics.FillEllipse(brush, 300, 500, 200, 200);
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

        private void stopRButton_Click(object sender, EventArgs e)
        {
            stopButton_Click(sender, e);
        }

        private void stopLButton_Click(object sender, EventArgs e)
        {
            stopButton_Click(sender, e);
        }

        private void ReflexGameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Timer != null && Timer.IsAlive)
                Timer.Abort();
            if (CoordinateSaver != null && CoordinateSaver.IsAlive)
                CoordinateSaver.Abort();
            if (gameState != GameStates.OutOfGame && score != 0)
                writeGameDetails();
        }
    }
}
