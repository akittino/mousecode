using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Collections;

namespace mysz
{
    public partial class ThingsGameWindow : MouseForm
    {
        const int CHART_WIDTH = 800;
        const int CHART_HEIGHT = 600;
        const int GRANULATION = 5;
        const string DATABASE_PATH = @"..\..\..\ThingsDatabase\"; //TODO change path when build .exe!!!
        readonly string USER_NAME;
        readonly int INITIAL_QUESTION_TIME;

        Graphics graphics, questionGraphics;
        List<Point> CoordsList;
        Thread CoordinateSaver;
        GameStates gameState;
        ArrayList questions;        
        Thread Timer;
        Random rnd;

        bool leftButtonCorrect = true;
        bool leftButtonClicked = true;
        int lastQuestionNumber = 0;
        int questionCounter = 0;
        int questionTime = 5;
        int gameId = 0;
        int score = 0;
        

        enum GameStates
        {
            firstRun = 0,
            beforeGame = 1,
            inRound = 2
        };

        class question
        {
            public string name, correctAnswer, wrongAnswer;
            public Image image;

            public question(string filePath)
            {
                bool imageFailed = false;

                try
                {
                    image = Image.FromFile(filePath);
                }
                catch (OutOfMemoryException e)
                {
                    Console.WriteLine(e.Data);
                    imageFailed = true;
                }

                string[] slashList = filePath.Split('\\');
                string[] commaList = slashList[slashList.Length - 1].Split(',');

                if (commaList.Length != 3 || imageFailed)
                    name = correctAnswer = wrongAnswer = "corrupted";
                else
                {
                    name = commaList[0];
                    correctAnswer = commaList[1];
                    wrongAnswer = commaList[2].Remove(commaList[2].Length - 4); 
                    //above remove 4 because of deleting ".jpg"
                }
            }
        };

        public ThingsGameWindow(string userName, int timePerQuestion)
        {
            //TODO save status of picturebox, and check minimalizing window
            InitializeComponent();
            SetMouseForm(gameWindow, CHART_WIDTH, CHART_HEIGHT);

            rnd = new Random();
            questions = new ArrayList();
            CoordsList = new List<Point>();           
            graphics = gameWindow.CreateGraphics();
            questionGraphics = questionBox.CreateGraphics();

            USER_NAME = userName;
            gameState = GameStates.firstRun; 
            questionTime = INITIAL_QUESTION_TIME = timePerQuestion;
            scoreLabel.Text = score.ToString() + " / " + questionCounter.ToString();

            answerRButton.Enabled = false;
            answerLButton.Enabled = false;
            
            if (Directory.Exists(DATABASE_PATH))
            {
                string[] files = Directory.GetFiles(DATABASE_PATH, "*.jpg");
                
                foreach (string path in files)
                {
                    question tmp = new question(path);
                    if (tmp.name != "corrupted")
                    {
                        questions.Add(tmp);
                    }
                }
            }

            graphics.Clear(Color.White);//TODO why nothing appears?
        }

        private void setNewQuestion()
        {
            int nextQuestionNumber = lastQuestionNumber;

            while (nextQuestionNumber == lastQuestionNumber)
                nextQuestionNumber = rnd.Next(questions.Count);

            question currentQuestion = (question)questions[nextQuestionNumber];
            lastQuestionNumber = nextQuestionNumber;
            
            if (rnd.Next(100) > 50)
            {
                leftButtonCorrect = true;
                answerLButton.Text = currentQuestion.correctAnswer;
                answerRButton.Text = currentQuestion.wrongAnswer;
            }
            else
            {
                leftButtonCorrect = false;
                answerLButton.Text = currentQuestion.wrongAnswer;
                answerRButton.Text = currentQuestion.correctAnswer;
            }

            questionBox.Image = currentQuestion.image;
            answerRButton.Enabled = true;
            answerLButton.Enabled = true;
        }

        private bool databaseExists()
        {
            if (questions.ToArray().Length <= 2)
            {
                MessageBox.Show("Unfortunately application couldn't read enough questions from database. Please play other games.");
                return false;
            }
            return true;
        }

        private void decreaseGameTime()
        {
            if (questionCounter % 10 == 0 && questionTime > 2)
            {
                --questionTime;
            }
        }

        private void playNewQuestion()
        {
            answerRButton.Enabled = false;
            answerLButton.Enabled = false;
            startButton.Enabled = false;

            answerRButton.Visible = true;
            answerLButton.Visible = true;
            timeLabel.Visible = true;

            startButton.Text = "Next question";
            gameState = GameStates.inRound;
            ++questionCounter;
            decreaseGameTime();

            graphics.Clear(Color.White);
            writeToPictureBox("Now quick, answer the question!", 310, 500);

            Timer = new Thread(TimeCountdown);
            CoordinateSaver = new Thread(saveCoordinates);

            setNewQuestion();
            CoordsList.Clear();

            Timer.Start();
            CoordinateSaver.Start();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            switch (gameState)
            {
                case GameStates.firstRun:
                    if (!databaseExists())//TODO think about this ugly way; automatize it
                    {
                        this.Close();
                        return;
                    }
                    playNewQuestion();
                    break;

                case GameStates.beforeGame:
                    playNewQuestion();
                    break;

                case GameStates.inRound:
                    playNewQuestion();
                    break;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = true;
            answerRButton.Enabled = false;
            answerRButton.Visible = false;
            answerLButton.Enabled = false;
            answerLButton.Visible = false;
            timeLabel.Visible = false;

            questionGraphics.Clear(Color.White);
            graphics.Clear(Color.White);

            CoordinateSaver.Abort();
            Timer.Abort();

            if (timeLabel.Text == "Time out!")
            {
                //TODO game lost
                writeGameDetails();
                gameState = GameStates.beforeGame;
                startButton.Text = "Start new game";
                gameId = 0;
                score = 0;
                questionCounter = 0;
                scoreLabel.Text = score.ToString() + " / " + questionCounter.ToString();
            }
            else
            {
                if (leftButtonClicked == leftButtonCorrect)
                {
                    scoreLabel.Text = (++score).ToString() + " / " + questionCounter.ToString();
                }

                writeCoordinatesToFile();
                CoordsList.Clear();
                writeToPictureBox("Good job! Please take next question!", 280, 500);
            }
        }

        private void writeGameDetails()
        {
            MoodWindow.Mood mood = getMood();
            String fileName = @".\ThingsGame\" + USER_NAME + @"\" + String.Format("{0:yyyy-MM-dd}", DateTime.Now) +
                              @"\" + gameId.ToString() + @"\gameDetails.txt";

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine("Mood: " + mood.ToString());
                sw.WriteLine("Score: " + score.ToString()+ " / " + questionCounter.ToString());
                sw.WriteLine("Initial game time: " + INITIAL_QUESTION_TIME.ToString());
            }
        }

        //void WriteCoordinatesToFile(string gameName, ref int gameId, MoodWindow.Mood mood, List<Point> CoordsList)
        //TODO make one writeCoordinates for all windows
        private void writeCoordinatesToFile()
        {
            String name;
            String dirPath = @".\ThingsGame\" + USER_NAME + @"\" + String.Format("{0:yyyy-MM-dd}", DateTime.Now);

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

            if (leftButtonClicked)
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
                sw.WriteLine(DateTime.Now.ToString());
                //sw.WriteLine(gameTimeString + " / " + maxGameTime);
                if (leftButtonClicked == leftButtonCorrect) 
                    sw.WriteLine("Correct button");
                else 
                    sw.WriteLine("Wrong button");
                foreach (Point p in CoordsList)
                {
                    sw.WriteLine(p.X + " , " + p.Y);
                }
            }
        }

        private void TimeCountdown()
        {
            DateTime endTime = DateTime.Now.AddSeconds((double) questionTime);

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

        public void writeToPictureBox(String text, int X, int Y)
        {
            using (Font myFont = new Font("Gabriola", 15))
            {
                graphics.DrawString(text, myFont, Brushes.Black, new Point(X, Y));
            }
        }

        private void saveCoordinates()
        {
            base.SaveCoordinates(GRANULATION, CoordsList);
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
            leftButtonClicked = false;
            stopButton_Click(sender, e);
        }

        private void stopLButton_Click(object sender, EventArgs e)
        {
            leftButtonClicked = true;
            stopButton_Click(sender, e);
        }
    }
}
