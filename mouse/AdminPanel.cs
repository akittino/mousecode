using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace mysz
{
    public partial class AdminPanel : Form
    {
        const int CHART_WIDTH = 800;
        const int CHART_HEIGHT = 600;
        const int GRANULATION = 5;
        int lastX = 0;
        int lastY = 0;
        Thread coordinateUpdater;
        Thread coordinateSaver;
        List<String> coordsList;
        public AdminPanel()
        // main form - main function in app
        {
            InitializeComponent();
            coordinateUpdater = new Thread(UpdateCoordinates);
            coordinateSaver = new Thread(SaveCoordinates);
            coordsList = new List<String>();
            coordinates_list.DataSource = coordsList;  
            coordinateUpdater.Start();
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

        void UpdateCoordinates()
        // updating coordinates on GUI in left top
        {
            while (true)
            {
                if (this.X_value.InvokeRequired || this.Y_value.InvokeRequired)
                {
                    this.X_value.BeginInvoke((MethodInvoker)delegate() { this.X_value.Text = GetXString(); ;});
                    this.Y_value.BeginInvoke((MethodInvoker)delegate() { this.Y_value.Text = GetYString(); ;});
                }
                else
                {
                    this.X_value.Text = GetXString();
                    this.Y_value.Text = GetYString();
                }
                Thread.Sleep(10);
            }
        }

        void SaveCoordinates()
        // writing coordinates to list of coords
        {
            while (true)
            {
                if (!(lastX + GRANULATION > GetX() && lastX - GRANULATION < GetX() && lastY + GRANULATION > GetY() && lastY - GRANULATION < GetY()))
                {
                    coordsList.Add(string.Format("    {0}            {1}", GetXString(), GetYString()));
                    if (this.coordinates_list.InvokeRequired)
                    {
                        this.coordinates_list.BeginInvoke((MethodInvoker)delegate()
                        {
                            this.coordinates_list.DataSource = null;
                            this.coordinates_list.Items.Clear();
                            this.coordinates_list.DataSource = coordsList;
                            int VisibleCoordsNumber = coordinates_list.ClientSize.Height / coordinates_list.ItemHeight;
                            coordinates_list.TopIndex = Math.Max(coordinates_list.Items.Count - VisibleCoordsNumber + 1, 0);
                        });
                    }
                    else
                    {
                        this.coordinates_list.DataSource = null;
                        this.coordinates_list.Items.Clear();
                        this.coordinates_list.DataSource = coordsList;
                    }
                    lastX = GetX();
                    lastY = GetY();
                }
                Thread.Sleep(10);
            }
        }

        private void StartButtonClick(object sender, EventArgs e)
        // button starting coords save
        {
            coordsList.Clear();
            coordsList.Add(string.Format("    {0}            {1}", GetXString(), GetYString()));
            if (!coordinateSaver.IsAlive)
            {
                coordinateSaver = new Thread(SaveCoordinates);
                coordinateSaver.Start();
            }
        }

        private void StopButtonClick(object sender, EventArgs e)
        // button stoping coords save
        {
            if (coordinateSaver.IsAlive)
                coordinateSaver.Abort();
        }

        private void AdminPanelClosing(object sender, FormClosingEventArgs e)
        // killing alive threads when closing window
        {
            if(coordinateUpdater.IsAlive) 
                coordinateUpdater.Abort();
            if (coordinateSaver.IsAlive)
                coordinateSaver.Abort();
        }

        private void ChartDrawButtonClick(object sender, EventArgs e)
        // button drawing a path of mouse move
        {
            if (coordsList.Count < 2)
                return;
            Pen p = new Pen(Color.Blue, 2f);
            Graphics g = picture_box.CreateGraphics();
            g.Clear(Color.White);
            int lastx = Convert.ToInt32(coordsList[0].Substring(0, 10));
            int lasty = Convert.ToInt32(coordsList[0].Substring(10));
            g.DrawEllipse(p, lastx-1, lasty-1, 2, 2);
            int x = Convert.ToInt32(coordsList[1].Substring(0, 10));
            int y = Convert.ToInt32(coordsList[1].Substring(10));
            g.DrawEllipse(p, x - 1, y - 1, 2, 2);
            g.DrawLine(p, new Point(lastx, lasty), new Point(x, y));
            for (int i = 2; i < coordsList.Count; i++)
            {
                lastx = x;
                lasty = y;
                x = Convert.ToInt32(coordsList[i].Substring(0, 10));
                y = Convert.ToInt32(coordsList[i].Substring(10));
                g.DrawEllipse(p, x - 1, y - 1, 2, 2);
                g.DrawLine(p, new Point(lastx, lasty), new Point(x, y));
            }

        }
    }
}
