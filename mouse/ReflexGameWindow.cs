using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        DateTime startTime;
        SolidBrush redBrush, greenBrush, blueBrush;
        Graphics graphics;

        public ReflexGameWindow()
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

            stopButton.Enabled = false;

            graphics.Clear(Color.White);//TODO why nothing appears?
            graphics.FillEllipse(blueBrush, -100, 500, 200, 200);//TODO why nothing appears?
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            stopButton.Enabled = false;
            startButton.Enabled = false;

            Random rnd = new Random();
            int delay = rnd.Next(30);
            DateTime endTime = DateTime.Now;
            endTime = endTime.AddMilliseconds(2000 + delay * 100);
            DateTime currentTime = DateTime.Now;

            graphics.Clear(Color.White);
            graphics.FillEllipse(redBrush, -100, 500, 200, 200);
            writeToPictureBox("Don't move mouse cursor out of Start button until corner color change to green.", 150, 280);

            bool waitingFailed = false;
            while (currentTime <= endTime)
            {
                if ((GetX() > 59 || GetX() < 1) ||
                    (GetY() > 599 || GetY() < 576))
                {
                    waitingFailed = true;
                    break;
                }
                currentTime = DateTime.Now;
            }
            if (waitingFailed)
            {
                graphics.Clear(Color.White);
                graphics.FillEllipse(blueBrush, -100, 500, 200, 200);
                startButton.Enabled = true;
                writeToPictureBox("Game failed.", 350, 250);
                writeToPictureBox("Moved out from Start button before corner changed to green.", 200, 280);
            }
            else
            {
                graphics.Clear(Color.White);
                graphics.FillEllipse(greenBrush, -100, 500, 200, 200);
                writeToPictureBox("Now! Push Stop button as fast as you can!", 250, 280);
                stopButton.Enabled = true;

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
                startTime = DateTime.Now;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            timeLabel.Visible = true;
            startButton.Enabled = true;
            stopButton.Enabled = false;
            DateTime currentTime = DateTime.Now;

            timeLabel.Text = (currentTime - startTime).TotalMilliseconds.ToString() + " ms";

            if (CoordinateSaver.IsAlive)    CoordinateSaver.Suspend();
            WriteCoordinatesToFile(timeLabel.Text);

            graphics.Clear(Color.White);
            graphics.FillEllipse(blueBrush, -100, 500, 200, 200);
            writeToPictureBox("Great job! Your game data was just save to file.", 250, 280);
            //TODO decide about feelings
            //TODO find out if something's wrong with time
        }

        void WriteCoordinatesToFile(String gameTime)
        {
            String name;
            String dirPath = @".\ReflexGame";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
                name = dirPath + @"\data0.csv";
            }
            else
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
                name = dirPath + @"\data" + dirInfo.GetFiles().Length.ToString() + ".csv";
                while (File.Exists(name))
                {   // very bad idea, but just to be sure TODO talk about this
                    name = dirPath + @"\data" + dirInfo.GetFiles().Length.ToString() + 1 + ".csv";
                }
            }
            using (StreamWriter sw = new StreamWriter(name))
            {
                sw.WriteLine(DateTime.Now.ToString());
                sw.WriteLine(gameTime + " ms");
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
            while (true)
            {
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

        private void ReflexGameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            /* TODO THIS!
            if (CoordinateSaver.IsAlive)
            {
                CoordinateSaver.Abort();
            }
             */
        }
    }
}
