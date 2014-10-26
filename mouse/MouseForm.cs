using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
