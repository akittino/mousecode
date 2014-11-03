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
        const int CHART_WIDTH = 800;
        const int CHART_HEIGHT = 600;
        const int GRANULATION = 5;
        bool firstRun = true;
        List<Point> CoordsList;
        Thread CoordinateSaver;
        SolidBrush redBrush, greenBrush, blueBrush;
        Graphics graphics;
        bool useLeftButton = true;
        string userName;
        TimeSpan startTime;
        MoodWindow.Mood mood;

        public ReflexGameWindow(string userName, MoodWindow.Mood mood)
        {
            //TODO save status of picturebox, and check minimalizing window
            InitializeComponent();
            SetMouseForm(gameWindow, CHART_WIDTH, CHART_HEIGHT);

            CoordsList = new List<Point>();
            CoordinateSaver = new Thread(SaveCoordinates);

            redBrush = new SolidBrush(Color.Red);
            greenBrush = new SolidBrush(Color.Green);
            blueBrush = new SolidBrush(Color.Blue);
            graphics = gameWindow.CreateGraphics();

            stopRButton.Enabled = false;
            stopLButton.Enabled = false;

            graphics.Clear(Color.White);//TODO why nothing appears?
            drawEllipse(blueBrush);//TODO why nothing appears?
            this.userName = userName; // TODO add user differentation in dir like in Colors Game
            this.mood = mood;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            stopRButton.Enabled = false;
            stopRButton.Visible = false;
            stopLButton.Enabled = false;
            stopLButton.Visible = false;
            startButton.Enabled = false;

            Random rnd = new Random();
            int delay = rnd.Next(30);
            DateTime endTime = DateTime.Now;
            endTime = endTime.AddMilliseconds(2000 + delay * 100);
            DateTime currentTime = DateTime.Now;

            graphics.Clear(Color.White);
            drawEllipse(redBrush);
            writeToPictureBox(graphics, "Don't move mouse cursor out of Start button until circle color change to green.", 150, 280, 15);

            bool waitingFailed = false;
            while (currentTime <= endTime)
            {
                int a = GetX();
                int b = GetY();
                if ((GetX() > 429 || GetX() < 370) ||
                    (GetY() > 599 || GetY() < 577)) // TODO it's very ugly way to do this
                {
                    waitingFailed = true;
                    break;
                }
                currentTime = DateTime.Now;
            }
            if (waitingFailed)
            {
                graphics.Clear(Color.White);
                drawEllipse(blueBrush);
                startButton.Enabled = true;
                writeToPictureBox(graphics,"Game failed.", 350, 250,15);
                writeToPictureBox(graphics,"Moved out from Start button before circle changed to green.", 200, 280,15);
            }
            else
            {
                graphics.Clear(Color.White);
                drawEllipse(greenBrush);
                writeToPictureBox(graphics,"Now! Push Stop button as fast as you can!", 250, 280,15);
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
                startTime = DateTime.Now.TimeOfDay;
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
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            timeLabel.Visible = true;
            startButton.Enabled = true;
            stopRButton.Enabled = false;
            stopRButton.Visible = false;
            stopLButton.Enabled = false;
            stopLButton.Visible = false;
            TimeSpan currentTime = DateTime.Now.TimeOfDay;

            timeLabel.Text = (currentTime - startTime).ToString();
            timeLabel.Text = timeLabel.Text.Substring(6,6) + " s";
            if (CoordinateSaver.IsAlive)    CoordinateSaver.Suspend();
            WriteCoordinatesToFile(timeLabel.Text);

            graphics.Clear(Color.White);
            drawEllipse(blueBrush);
            writeToPictureBox(graphics, "Great job! Your game data was just save to file.", 250, 280, 15);
            //TODO decide about feelings
        }

        void WriteCoordinatesToFile(String gameTimeString)
        {
            String name;
            String dirPath = @".\ReflexGame";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
                if (useLeftButton)  name = dirPath + @"\dataL0.csv";
                else                name = dirPath + @"\dataR0.csv";
            }
            else
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
                if(useLeftButton)   name = dirPath + @"\dataL" + dirInfo.GetFiles().Length.ToString() + ".csv";
                else                name = dirPath + @"\dataR" + dirInfo.GetFiles().Length.ToString() + ".csv";
                while (File.Exists(name))
                {   // very bad idea, but just to be sure TODO talk about this
                    //TODO talk how to save L & R
                    if(useLeftButton)   name = dirPath + @"\dataL" + dirInfo.GetFiles().Length.ToString() + 1 + ".csv";
                    else                name = dirPath + @"\dataR" + dirInfo.GetFiles().Length.ToString() + 1 + ".csv";
                }
            }
            using (StreamWriter sw = new StreamWriter(name))
            {
                sw.WriteLine(DateTime.Now.ToString());
                sw.WriteLine(gameTimeString);
                sw.WriteLine("Mood: "+ mood);
                foreach(Point p in CoordsList)
                {
                    sw.WriteLine(p.X + " , " + p.Y); 
                }
            }

        }

        void SaveCoordinates()
        // writing coordinates to list of coords
        {
           base.SaveCoordinates(GRANULATION, CoordsList);
        }

        public void writeToPictureBox(Graphics graphics, String text, int X, int Y, int fontSize)
        {
            base.writeToPictureBox(graphics, text, X, Y, fontSize);
        }

        public void drawEllipse(SolidBrush brush)
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

        private void ReflexGameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            /* TODO THIS!
            if (CoordinateSaver.IsAlive)
            {
                CoordinateSaver.Abort();
            }
             */
        }

        private void stopRButton_Click(object sender, EventArgs e)
        {
            stopButton_Click(sender, e);
        }

        private void stopLButton_Click(object sender, EventArgs e)
        {
            stopButton_Click(sender, e);
        }
    }
}
