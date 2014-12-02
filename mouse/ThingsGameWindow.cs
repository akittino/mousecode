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

        //TODO sth is wrong with time after first game -> first game has correct initial time but second game time equals last time from firstgame
        const int CHART_WIDTH = 800;
        const int CHART_HEIGHT = 600;
        const int GRANULATION = 5;
        const string DATABASE_PATH = @"..\..\..\Things Images\"; //TODORELEASE change path when build .exe!!!  
        //const string DATABASE_PATH = @"Things Images";
        readonly string userName;
        readonly int INITIAL_QUESTION_TIME;
        
        public bool databaseCorrupted;
        Graphics graphics, questionGraphics;
        List<TimePoint> CoordsList;
        Thread CoordinateSaver;
        ArrayList questions;
        Thread Timer;
        Random rnd;
        List<int> questionsRnd = new List<int>();

        bool leftButtonCorrect = true;
        bool leftButtonClicked = true;
        int questionCounter = 0;
        int questionTime = 5;
        int gameId = 0;
        int gameScore = 0;
        int nextQuestionNumber = 0;

        class Question
        {
            public string correctAnswer, wrongAnswer;
            public Image image;

            public Question(string filePath)
            {
                bool imageFailed = false;

                try
                {
                    image = Image.FromFile(filePath);
                }
                catch (Exception)
                {
                    imageFailed = true;
                }

                string[] slashList = filePath.Split('\\');
                string[] commaList = slashList[slashList.Length - 1].Split(',');

                if (commaList.Length != 3 || imageFailed)
                    correctAnswer = wrongAnswer = "corrupted";
                else
                {
                    correctAnswer = commaList[1];
                    wrongAnswer = commaList[2].Remove(commaList[2].Length - 4);
                    //above remove 4 because of deleting ".jpg"
                    if(correctAnswer.Length >= 15 || wrongAnswer.Length >= 15)
                    {
                        correctAnswer = wrongAnswer = "corrupted";
                    }
                }
            }
        };

        public ThingsGameWindow(string userName, int timePerQuestion)
        {
            InitializeComponent();

            SetMouseForm(gameWindow, CHART_WIDTH, CHART_HEIGHT, timeLabel);
            setTimeOutMethod(timedOut);

            rnd = new Random();
            questions = new ArrayList();
            CoordsList = new List<TimePoint>();
            graphics = gameWindow.CreateGraphics();
            questionGraphics = questionBox.CreateGraphics();

            timeLabel.Text = "";
            scoreLabel.Text = "";

            this.userName = userName;
            questionTime = INITIAL_QUESTION_TIME = timePerQuestion;

            setQuestionTime((double)questionTime);

            answerRButton.Enabled = false;
            answerLButton.Enabled = false;

            if (Directory.Exists(DATABASE_PATH))
            {
                string[] files = Directory.GetFiles(DATABASE_PATH, "*.jpg");

                foreach (string path in files)
                {
                    Question tmp = new Question(path);
                    if (tmp.correctAnswer != "corrupted")
                    {
                        questions.Add(tmp);
                    }
                }
            }

            if (!enoughQuestionsInDatabase())
            {
                databaseCorrupted = true;
                this.Close();
                return;
            }
            else
            {
                databaseCorrupted = false;
            }
        }

        private void setNewQuestion()
        {

            if (questionsRnd.Count == 0)
            {
                for (int j = 0; j < questions.Count; j++)
                {
                    questionsRnd.Add(j);
                }
            }
            
            int rndNumber = rnd.Next(questionsRnd.Count);
            nextQuestionNumber = questionsRnd[rndNumber];
            Question currentQuestion = (Question)questions[nextQuestionNumber];
            questionsRnd.RemoveAll(x => x == nextQuestionNumber);


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
            if (questionBox.Image != null)
                questionBox.Location = new Point(this.Width / 2 - questionBox.Image.Width / 3, this.Height / 2 - gameWindow.Height / 2);
            answerRButton.Enabled = true;
            answerLButton.Enabled = true;

        }

        private bool enoughQuestionsInDatabase()
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
            if (questionCounter % 10 == 0 && questionTime > 1)
            {
                setQuestionTime((double)--questionTime);
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

            startButton.Text = "Next";
            ++questionCounter;
            decreaseGameTime();

            graphics.Clear(Color.White);
            writeToPictureBox("Now quick, answer the question!", 270, 520);

            Timer = new Thread(TimeCountdown);
            CoordinateSaver = new Thread(saveCoordinates);

            setNewQuestion();
            CoordsList.Clear();

            Timer.Start();
            CoordinateSaver.Start();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            playNewQuestion();
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
                startButton.Text = "Start";
                writeToPictureBox("Please start a game!", 315, 520);
                questionsRnd.Clear();
                if (gameId != 0)
                    writeGameDetails();

                gameScore = 0;
                gameId = 0;
                CoordsList.Clear();
                questionCounter = 0;
                scoreLabel.Text = gameScore.ToString() + " / " + questionCounter.ToString();
            }
            else
            {
                if (leftButtonClicked == leftButtonCorrect)
                {
                    ++gameScore;
                    writeToPictureBox("Good job! Please take next question!", 240, 520);
                }
                else
                {
                    writeToPictureBox("You were wrong! Please take next question!", 210, 520);
                }

                scoreLabel.Text = gameScore.ToString() + " / " + questionCounter.ToString();

                double usedTime = 1000 * (questionTime - double.Parse(timeLabel.Text.Remove(timeLabel.Text.Length - 1)));
                gameId = writeCoordinatesToFile(usedTime);

                CoordsList.Clear();
            }
        }

        public void writeToPictureBox(String text, int X, int Y)
        {
            using (Font myFont = new Font("Times New Roman", 15))
            {
                graphics.DrawString(text, myFont, Brushes.Black, new Point(X, Y));
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
            return base.writeCoordinatesToFile(gameId, "ThingsGame", leftButtonClicked, userName, CoordsList,
                "Correct Answer: " + ((leftButtonClicked == leftButtonCorrect) ? "YES" : "NO"), gameTime.ToString("F0") + " , " + questionTime * 1000);
        }

        private void writeGameDetails()
        {
            base.writeGameDetails("ThingsGame", userName, gameId, "Score: " + scoreLabel.Text, "Initial game time: " + INITIAL_QUESTION_TIME.ToString());
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

        private void ThingsGameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Timer != null && Timer.IsAlive)
                Timer.Abort();
            if (CoordinateSaver != null && CoordinateSaver.IsAlive)
                CoordinateSaver.Abort();
            if (gameId != 0) // this means that some data was already saved
                writeGameDetails();
        }
    }
}