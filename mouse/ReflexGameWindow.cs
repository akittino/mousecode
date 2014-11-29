using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace mysz
{
    public partial class ReflexGameWindow : MouseForm
    {
        const int GRANULATION = 5;
        const int CHART_WIDTH = 800;
        const int CHART_HEIGHT = 600;

        readonly string USER_NAME;
        readonly int INITIAL_GAME_TIME;
        readonly Color BACKGROUND_COLOR = Color.White;

        SolidBrush redBrush, greenBrush, blueBrush;
        List<TimePoint> CoordsList;
        Thread CoordinateSaver;
        Thread Timer;
        Random rnd;
        Graphics graphics;
        DateTime startTime;
        GameStates gameState;
        
        bool useLeftButton = true;        
        int gameId = 0;        
        int maxGameTime = 4;        
        int score = 0;

        enum GameStates
        {
            OutOfGame = 0,
            BeforeGame = 1,
            Waiting = 2
        };

        public ReflexGameWindow(string userName, int initialGameTime)
        {
            InitializeComponent();
            SetMouseForm(gameWindow, CHART_WIDTH, CHART_HEIGHT, timeLabel);
            setTimeOutMethod(timedOut);
            setQuestionTime((double)initialGameTime);

            CoordsList = new List<TimePoint>();

            greenBrush = new SolidBrush(Color.Green);
            blueBrush = new SolidBrush(Color.Blue);
            redBrush = new SolidBrush(Color.Red);

            maxGameTime = INITIAL_GAME_TIME = initialGameTime;
            graphics = gameWindow.CreateGraphics();
            gameState = GameStates.OutOfGame;
            USER_NAME = userName;
            rnd = new Random();
            
            scoreLabel.Text = "";
            timeLabel.Text = "";

            stopRButton.Enabled = false;
            stopLButton.Enabled = false;
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
            writeToPictureBox(graphics, "Don't move mouse cursor out of Start button until circle color change to green.", 80, 280, 15);

        }

        private void pushTheButton()
        {
            graphics.Clear(BACKGROUND_COLOR);
            drawEllipse(greenBrush);
            writeToPictureBox(graphics, "Now! Push Stop button as fast as you can!", 230, 280, 15);

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
                gameState = GameStates.BeforeGame;
                
                writeToPictureBox(graphics, "Game paused, please start again.", 270, 250, 15);
                writeToPictureBox(graphics, "Moved out from Start button before circle changed to green.", 170, 280, 15);
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

            graphics.Clear(BACKGROUND_COLOR);
            drawEllipse(blueBrush);

            if (timeLabel.Text.Equals("Time out!"))
            {
                writeToPictureBox(graphics, "Game has just ended due to time out!", 245, 280, 15);

                if (gameId != 0)
                    writeGameDetails();
                
                score = 0;
                gameId = 0;
                maxGameTime = INITIAL_GAME_TIME;
                setQuestionTime((double)maxGameTime);
                gameState = GameStates.OutOfGame;
                scoreLabel.Text = score.ToString();
                
            }
            else
            {

                gameId = writeCoordinatesToFile((DateTime.Now - startTime).TotalMilliseconds);

                ++score;
                scoreLabel.Text = score.ToString();

                decreaseGameTime();
                writeToPictureBox(graphics, "Great job! Play next level!", 290, 280, 15);
            }
        }

        private void decreaseGameTime()
        {
            if ((score % 10 == 0) && (maxGameTime > 1))
            {
                setQuestionTime((double)--maxGameTime);
            }
        }

        private bool timedOut()
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                stopButton_Click(null, null);
            });
            return false;
        }

        private int writeCoordinatesToFile(double gameTime)
        {
            return base.writeCoordinatesToFile(gameId, "ReflexGame", useLeftButton, USER_NAME, CoordsList,
                gameTime.ToString("F0") + " , " + maxGameTime * 1000);
        }

        private void writeGameDetails()
        {
            base.writeGameDetails("ReflexGame", USER_NAME, gameId,
                "Score: " + score.ToString(), "Initial game time: " + INITIAL_GAME_TIME.ToString());
        }

        private void saveCoordinates()
        {
            base.SaveCoordinates(GRANULATION, CoordsList);
        }

        private void drawEllipse(SolidBrush brush)
        {
            graphics.FillEllipse(brush, 250, 470, 300, 300);
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
