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
    public partial class ThingsGameWindow : MouseForm
    {
        const int CHART_WIDTH = 800;
        const int CHART_HEIGHT = 600;
        const int GRANULATION = 5;
        bool firstRun = true;
        List<string> CoordsList;
        Thread CoordinateSaver;
        DateTime startTime;

        public ThingsGameWindow()
        {
            InitializeComponent();
            SetMouseForm(gameWindow, CHART_WIDTH, CHART_HEIGHT);
            CoordsList = new List<String>();
            CoordinateSaver = new Thread(SaveCoordinates);
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            Point StartPoint = Cursor.Position;
            Pen p = new Pen(Color.Red, 2f);
            SolidBrush red = new SolidBrush(Color.Red);
            SolidBrush green = new SolidBrush(Color.Green);
            Graphics g = gameWindow.CreateGraphics();

            g.Clear(Color.White);
            g.FillEllipse(red, -100, 500, 200, 200);

            stopButton.Enabled = false;
            startButton.Enabled = false;

            Random rnd = new Random();
            int delay = rnd.Next(30);
            DateTime endTime = DateTime.Now;
            endTime = endTime.AddMilliseconds(2000 + delay * 100);
            DateTime currentTime = DateTime.Now;

            while (currentTime <= endTime) //TODO implement case to check if mouse is in red circle,
                //now workaround with moving cursor
                currentTime = DateTime.Now;

            g.FillEllipse(green, -100, 500, 200, 200);
            stopButton.Enabled = true;
            startTime = DateTime.Now;
            Cursor.Position = StartPoint;
            CoordsList.Clear();
            if (firstRun)
            {
                CoordinateSaver.Start();
                firstRun = false;
            }
            else
                CoordinateSaver.Resume();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            timeLabel.Visible = true;
            startButton.Enabled = true;
            DateTime currentTime = DateTime.Now;
            timeLabel.Text = (currentTime - startTime).TotalMilliseconds + " ms";
            if (CoordinateSaver.IsAlive)
                CoordinateSaver.Suspend();
            //TODO implement game
            //TODO find better solution with threads
            //TODO find out what's wrong with time
            //TODO save time to file
        }


        void SaveCoordinates()
        // writing coordinates to list of coords
        {
            int LastX = 0, LastY = 0;
            while (true)
            {
                if (!(LastX + GRANULATION > GetX() && LastX - GRANULATION < GetX() && LastY + GRANULATION > GetY() && LastY - GRANULATION < GetY()))
                {
                    CoordsList.Add(string.Format("    {0}            {1}", GetXString(), GetYString()));
                    LastX = GetX();
                    LastY = GetY();
                }
                Thread.Sleep(10);
            }
        }
        public void highlightLabel(object sender, EventArgs e)
        {
            base.highlightLabel(sender, e);
        }

        public void removeHighlightLabel(object sender, EventArgs e)
        {
            base.removeHighlightLabel(sender, e);
        }

        private void endGame(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
