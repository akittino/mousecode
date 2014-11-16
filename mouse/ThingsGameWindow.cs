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
        //TODO change moment when asking about mood
        //TODO fix some fuckup when wrong answer (ask again about mood)
        //TODO add green OK when game completed, and red warning when failed
        const int CHART_WIDTH = 800;
        const int CHART_HEIGHT = 600;
        const int GRANULATION = 5;
        MoodWindow.Mood mood;
        double roundTime = 10; // in seconds
        List<Point> CoordsList;
        Thread CoordinateSaver;
        DateTime endGameTime;
        Graphics graphics, questionGraphics;
        Random rnd;
        ArrayList questions;
        bool inGame = false;
        bool leftButtonCorrect = true;
        bool leftButtonClicked = true;
        string userName;
        int gameId = 0;

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
                    wrongAnswer = commaList[2].Remove(commaList[2].Length - 4); // remove 4 because of deleting ".jpg"
                }
            }
        };

        public ThingsGameWindow(string userName)
        {
            //TODO save status of picturebox, and check minimalizing window
            InitializeComponent();
            SetMouseForm(gameWindow, CHART_WIDTH, CHART_HEIGHT);

            CoordsList = new List<Point>();

            graphics = gameWindow.CreateGraphics();
            questionGraphics = questionBox.CreateGraphics();
            rnd = new Random();

            answerRButton.Enabled = false;
            answerLButton.Enabled = false;

            string[] files = Directory.GetFiles(@"..\..\..\ThingsDatabase\", "*.jpg");//TODO change path when build .exe!!!
            questions = new ArrayList();

            foreach (string path in files)
            {
                question tmp = new question(path);
                if(tmp.name != "corrupted")
                    questions.Add(tmp); //TODO check if there's any questions
            }


            graphics.Clear(Color.White);//TODO why nothing appears?
            this.userName = userName;
        }

        private void setNewQuestion()
        {
            //TODO get better solution to get random next question
            //depends on current question (to not show the same)
            question currentQuestion = (question)questions[rnd.Next(questions.Count)];
            
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

        private void startButton_Click(object sender, EventArgs e)
        {
            answerRButton.Enabled = false;
            answerRButton.Visible = true;
            answerLButton.Enabled = false;
            answerLButton.Visible = true;
            startButton.Enabled = false;
            timeLabel.Visible = true;
            startButton.Text = "Next question";
            startButton.Enabled = false;

            graphics.Clear(Color.White);
            writeToPictureBox("Now quick, answer the question!", 310, 550);

            if (! inGame)
            {
                endGameTime = DateTime.Now.AddSeconds(roundTime);
                CoordinateSaver = new Thread(SaveCoordinates);
                CoordinateSaver.Start();
                inGame = true;
            }
            CoordsList.Clear();
            setNewQuestion();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = true;
            answerRButton.Enabled = false;
            answerRButton.Visible = false;
            answerLButton.Enabled = false;
            answerLButton.Visible = false;
            DateTime currentTime = DateTime.Now;


            questionGraphics.Clear(Color.White);
            graphics.Clear(Color.White);

            if (!CoordinateSaver.IsAlive)
            {
                if (leftButtonClicked == leftButtonCorrect)
                {
                    mood = getMood();
                    WriteCoordinatesToFile();
                    CoordsList.Clear();
                    writeToPictureBox("Great job! Your move data was just save to file. The game has ended!", 190, 550);
                }
                else
                {
                    CoordsList.Clear();
                    writeToPictureBox("Your last answer wasn't correct. Game over!", 230, 550);
                }
                startButton.Text = "Start new game";
                gameId = 0;
                inGame = false;
            }
            else
            {
                if (leftButtonClicked == leftButtonCorrect)
                {
                    CoordinateSaver.Suspend();
                    WriteCoordinatesToFile();
                    CoordsList.Clear();
                    CoordinateSaver.Resume();
                    writeToPictureBox("Great job! Your move data was just save to file. Please take next question!", 180, 550);
                }
                else
                {
                    CoordinateSaver.Abort();
                    CoordsList.Clear();
                    writeToPictureBox("Your last answer wasn't correct. The game is ended!", 230, 550);
                    startButton.Text = "Start new game";
                    gameId = 0;
                    inGame = false;
                }
                
            }
            
            //TODO decide about feelings
        }

        void WriteCoordinatesToFile()
        {
            String name;
            String dirPath = @".\ThingsGame\" + userName + @"\" + String.Format("{0:yyyy-MM-dd}", DateTime.Now);
            if (gameId == 0)
            {
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                    gameId = 1;
                }
                else
                {
                    DirectoryInfo partDirInfo = new DirectoryInfo(dirPath);
                    gameId = (partDirInfo.GetDirectories().Length + 1);
                }
            }
            dirPath += @"\" + gameId.ToString();
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath); //TODO make this safe to existing dirs
                if (leftButtonCorrect)  name = dirPath + @"\dataL0.csv";
                else                name = dirPath + @"\dataR0.csv";
            }
            else
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
                if(leftButtonCorrect)   name = dirPath + @"\dataL" + dirInfo.GetFiles().Length.ToString() + ".csv";
                else                    name = dirPath + @"\dataR" + dirInfo.GetFiles().Length.ToString() + ".csv";
                int fileAddCounter = 1;
                while (File.Exists(name))
                {   // very bad idea, but just to be sure TODO talk about this
                    //TODO talk how to save L & R
                    if(leftButtonCorrect)   name = dirPath + @"\dataL" + dirInfo.GetFiles().Length.ToString() + (fileAddCounter++) + ".csv";
                    else                    name = dirPath + @"\dataR" + dirInfo.GetFiles().Length.ToString() + (fileAddCounter++) + ".csv";
                }
            }
            using (StreamWriter sw = new StreamWriter(name))
            {
                sw.WriteLine(DateTime.Now.ToString());
                sw.WriteLine("Mood: " + mood);
                foreach(Point p in CoordsList)
                {
                    sw.WriteLine(p.X + " , " + p.Y); 
                }
            }

        }

        void SaveCoordinates()
        // writing coordinates to list of coords
        {
            int LastX = 0, LastY = 0;
            while (DateTime.Now < endGameTime)
            {
                if (this.timeLabel.InvokeRequired)
                {
                    this.timeLabel.BeginInvoke((MethodInvoker)delegate() { this.timeLabel.Text = (endGameTime - DateTime.Now).TotalSeconds.ToString("0.00"); ;});
                }
                else
                {
                    timeLabel.Text = (endGameTime - DateTime.Now).TotalSeconds.ToString("0.00"); ;
                }

                if (!( LastX + GRANULATION > GetX() 
                    && LastX - GRANULATION < GetX() 
                    && LastY + GRANULATION > GetY() 
                    && LastY - GRANULATION < GetY() ))
                {
                    CoordsList.Add(new Point(GetX(), GetY()));
                    LastX = GetX();
                    LastY = GetY();
                }
                Thread.Sleep(10);
            }
            if (this.timeLabel.InvokeRequired)
            {
                this.timeLabel.BeginInvoke((MethodInvoker)delegate() { this.timeLabel.Text = "0"; ;});
            }
            else
            {
                timeLabel.Text = "0";
            }
        }

        public void writeToPictureBox(String text, int X, int Y)
        {
            using (Font myFont = new Font("Gabriola", 15))
            {
                graphics.DrawString(text, myFont, Brushes.Black, new Point(X, Y));
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
