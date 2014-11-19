using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace mysz
{
    public partial class AdminPanel : MouseForm
    {
        const int CHART_WIDTH = 800;
        const int CHART_HEIGHT = 600;
        const int GRANULATION = 5;
        int LastX = 0;
        int LastY = 0;
        Thread CoordinateUpdater;
        Thread CoordinateSaver;
        List<String> CoordsList;
        public AdminPanel()
        // main form - main function in app
        {
            InitializeComponent();
            SetMouseForm(picture_box, CHART_WIDTH, CHART_HEIGHT, null);
            CoordinateUpdater = new Thread(UpdateCoordinates);
            CoordinateSaver = new Thread(SaveCoordinates);
            CoordsList = new List<String>();
            coordinates_list.DataSource = CoordsList;  
            CoordinateUpdater.Start();
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
                if (!(LastX + GRANULATION > GetX() && LastX - GRANULATION < GetX() && LastY + GRANULATION > GetY() && LastY - GRANULATION < GetY()))
                {
                    CoordsList.Add(string.Format("    {0}            {1}", GetXString(), GetYString()));
                    if (this.coordinates_list.InvokeRequired)
                    {
                        this.coordinates_list.BeginInvoke((MethodInvoker)delegate()
                        {
                            this.coordinates_list.DataSource = null;
                            this.coordinates_list.Items.Clear();
                            this.coordinates_list.DataSource = CoordsList;
                            int VisibleCoordsNumber = coordinates_list.ClientSize.Height / coordinates_list.ItemHeight;
                            coordinates_list.TopIndex = Math.Max(coordinates_list.Items.Count - VisibleCoordsNumber + 1, 0);
                        });
                    }
                    else
                    {
                        this.coordinates_list.DataSource = null;
                        this.coordinates_list.Items.Clear();
                        this.coordinates_list.DataSource = CoordsList;
                    }
                    LastX = GetX();
                    LastY = GetY();
                }
                Thread.Sleep(10);
            }
        }

        private void StartButtonClick(object sender, EventArgs e)
        // button starting coords save
        {
            CoordsList.Clear();
            CoordsList.Add(string.Format("    {0}            {1}", GetXString(), GetYString()));
            if (!CoordinateSaver.IsAlive)
            {
                CoordinateSaver = new Thread(SaveCoordinates);
                CoordinateSaver.Start();
            }
        }

        private void StopButtonClick(object sender, EventArgs e)
        // button stoping coords save
        {
            if (CoordinateSaver.IsAlive)
                CoordinateSaver.Abort();
        }

        private void AdminPanelClosing(object sender, FormClosingEventArgs e)
        // killing alive threads when closing window
        {
            if(CoordinateUpdater.IsAlive) 
                CoordinateUpdater.Abort();
            if (CoordinateSaver.IsAlive)
                CoordinateSaver.Abort();
        }

        private void ChartDrawButtonClick(object sender, EventArgs e)
        // button drawing a path of mouse move
        {
            if (CoordsList.Count < 2)
                return;
            Pen p = new Pen(Color.Blue, 2f);
            Graphics g = picture_box.CreateGraphics();
            //g.Clear(Color.White);
            //stupid idea, change string to point!
            int LastX = Convert.ToInt32(CoordsList[0].Substring(0, 10));
            int lasty = Convert.ToInt32(CoordsList[0].Substring(10));
            g.DrawEllipse(p, LastX-1, lasty-1, 2, 2);
            int x = Convert.ToInt32(CoordsList[1].Substring(0, 10));
            int y = Convert.ToInt32(CoordsList[1].Substring(10));
            g.DrawEllipse(p, x - 1, y - 1, 2, 2);
            g.DrawLine(p, new Point(LastX, lasty), new Point(x, y));
            for (int i = 2; i < CoordsList.Count; i++)
            {
                LastX = x;
                lasty = y;
                x = Convert.ToInt32(CoordsList[i].Substring(0, 10));
                y = Convert.ToInt32(CoordsList[i].Substring(10));
                g.DrawEllipse(p, x - 1, y - 1, 2, 2);
                g.DrawLine(p, new Point(LastX, lasty), new Point(x, y));
            }

        }
    }
}
