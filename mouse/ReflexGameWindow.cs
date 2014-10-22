using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace mysz
{
    public partial class ReflexGameWindow : Form // TODO one Form with getX etc functions
    {
        const int CHART_WIDTH = 800;
        const int CHART_HEIGHT = 600;
        const int GRANULATION = 5;
        bool firstRun = true;
        List<string> CoordsList;
        Thread CoordinateSaver;
        DateTime startTime;

        public ReflexGameWindow()
        {
            InitializeComponent();
            CoordsList = new List<String>();
            CoordinateSaver = new Thread(SaveCoordinates);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point StartPoint = Cursor.Position;
            Pen p = new Pen(Color.Red, 2f);
            SolidBrush red = new SolidBrush(Color.Red);
            SolidBrush green = new SolidBrush(Color.Green);
            Graphics g = picture_box.CreateGraphics();

            g.Clear(Color.White);
            g.FillEllipse(red, -100, 500, 200, 200);

            stop_button.Enabled = false;
            start_button.Enabled = false;

            Random rnd = new Random();
            int delay = rnd.Next(30);
            DateTime endTime = DateTime.Now;
            endTime = endTime.AddMilliseconds(2000 + delay*100);
            DateTime currentTime = DateTime.Now;

            while (currentTime <= endTime) //TODO implement case to check if mouse is in red circle,
            //now workaround with moving cursor
                currentTime = DateTime.Now;

            g.FillEllipse(green, -100, 500, 200, 200);
            stop_button.Enabled = true;
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

        private void stop_button_Click(object sender, EventArgs e)
        {
            start_button.Enabled = true;
            DateTime currentTime = DateTime.Now;
            time_label.Text = (currentTime - startTime).TotalMilliseconds + " ms";
            if (CoordinateSaver.IsAlive)
                CoordinateSaver.Suspend();
            //TODO implement game
            //TODO find better solution with threads
            //TODO find out what's wrong with time
            //TODO find out what happened that sometimes it doesn't change to green circle
            //TODO kill saveCoords threads when closing window
            //TODO save time to file
        }

        public int GetX()
        // return X mouse position
        {
            int X = MousePosition.X - this.Left - picture_box.Location.X - 8;
            // -8 is shifted because of strange window coordinates
            if (X < 0)
                return 0;
            if (X > CHART_WIDTH)
                return CHART_WIDTH;
            return X;
        }

        public int GetY()
        // return Y mouse position
        {
            int Y = MousePosition.Y - this.Top - picture_box.Location.Y - 30;
            // -30 is shifted because of strange window coordinates
            if (Y < 0)
                return 0;
            if (Y > CHART_HEIGHT)
                return CHART_HEIGHT;
            return Y;
        }

        public string GetXString()
        // return X mouse position as String
        {
            int x = GetX();
            if (x < 10)
                return "    " + x.ToString();
            else if (x < 100)
                return "  " + x.ToString();
            else
                return x.ToString();
        }

        public string GetYString()
        // return Y mouse position as String
        {
            int y = GetY();
            if (y < 10)
                return "    " + y.ToString();
            else if (y < 100)
                return "  " + y.ToString();
            else
                return y.ToString();
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
    }
}
