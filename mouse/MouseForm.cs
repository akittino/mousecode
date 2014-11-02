using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace mysz
{
    public class MouseForm : Form
    {
        int CHART_WIDTH = 0;
        int CHART_HEIGHT = 0;
        PictureBox picture_box;

        // this method must be called before using any of other methods from this class
        public void SetMouseForm(PictureBox _picture_box, int _chart_width, int _chart_height)
        {
            CHART_WIDTH = _chart_width;
            CHART_HEIGHT = _chart_height;
            picture_box = _picture_box;
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
        public void highlightLabel(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.BlueViolet;
        }

        public void removeHighlightLabel(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.Black;
        }

        public void writeToPictureBox(Graphics graphics, String text, int X, int Y, int fontSize)
        {
            using (Font myFont = new Font("Gabriola", fontSize))
            {
                graphics.DrawString(text, myFont, Brushes.Black, new Point(X, Y));
            }
        }
        public void SaveCoordinates(int GRANULATION, List<Point> CoordsList)
        // writing coordinates to list of coords
        {
            int LastX = 0, LastY = 0;
            while (true)
            {
                if (!(LastX + GRANULATION > GetX()
                    && LastX - GRANULATION < GetX()
                    && LastY + GRANULATION > GetY()
                    && LastY - GRANULATION < GetY()))
                {
                    CoordsList.Add(new Point(GetX(), GetY()));
                    LastX = GetX();
                    LastY = GetY();
                }
                Thread.Sleep(10);
            }
        }

        public int setTime(int seconds, int minutes)
        {
            if (minutes * 60 + seconds == 0)
            {
                minutes = 1;
                seconds = 0;
            }
            return minutes * 60 + seconds;
        }
    }
}
