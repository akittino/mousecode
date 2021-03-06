﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace mysz
{
    public class MouseForm : Form
    {
        MoodWindow MoodWindow;
        Label timeLabel;
        Func<bool> timeOutMethod;
        int CHART_WIDTH = 0;
        int CHART_HEIGHT = 0;
        double questionTime = 0;
        PictureBox pictureBox;

        protected class TimePoint
        {
            public int X, Y;
            public double timeFromGameStart;
            public TimePoint(int _X, int _Y, double _timeFromGameStart)
            {
                X = _X;
                Y = _Y;
                timeFromGameStart = _timeFromGameStart;
            }
        }

        // this method must be called before using any of other methods from this class
        public void SetMouseForm(PictureBox _picture_box, int _chart_width, int _chart_height, Label _timeLabel)
        {
            CHART_WIDTH = _chart_width;
            CHART_HEIGHT = _chart_height;
            pictureBox = _picture_box;
            timeLabel = _timeLabel;
        }

        protected void setTimeOutMethod(Func<bool> fun)
        {
            timeOutMethod = fun;
        }

        protected void setQuestionTime(double _qT)
        {
            questionTime = _qT;
        }

        protected void writeGameDetails(string gameName, string userName, int gameId, params string[] strings)
        {
            Tuple<MoodWindow.MoodFromHappyToAngryScale, MoodWindow.MoodFromExcitedToBoredScale> moods = getMood();
            String fileName = @".\" + gameName + @"\" + userName + @"\" + String.Format("{0:yyyy-MM-dd}", DateTime.Now) +
                              @"\" + gameId.ToString() + @"\gameDetails.txt";

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName))
            {
                sw.WriteLine("Mood from scale happy to sad: " + moods.Item1.ToString());
                sw.WriteLine("Mood from scale excited to bored: " + moods.Item2.ToString());

                for (int i = 0; i < strings.Length; ++i)
                {
                    sw.WriteLine(strings[i]);
                }
            }
        }

        protected int writeCoordinatesToFile(int gameId, string gameName, bool leftButtonClicked, string USER_NAME, List<TimePoint> CoordsList, params string[] strings)
        {
            String name;
            String dirPath = @".\" + gameName + @"\" + USER_NAME + @"\" + String.Format("{0:yyyy-MM-dd}", DateTime.Now);

            if (gameId == 0)
            {
                if (!System.IO.Directory.Exists(dirPath))
                {
                    System.IO.Directory.CreateDirectory(dirPath);
                    gameId = 1;
                }
                else
                {
                    gameId = ((new System.IO.DirectoryInfo(dirPath)).GetDirectories().Length + 1);
                }
            }

            if (leftButtonClicked)
                dirPath += @"\" + gameId.ToString() + @"\L";
            else
                dirPath += @"\" + gameId.ToString() + @"\R";

            if (!System.IO.Directory.Exists(dirPath))
            {
                System.IO.Directory.CreateDirectory(dirPath);
            }

            name = dirPath + @"\" + String.Format("{0:HH-mm-ss}", DateTime.Now) + ".csv";

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(name))
            {
                for (int i = 0; i < strings.Length; ++i)
                {
                    sw.WriteLine(strings[i]);
                }

                foreach (TimePoint p in CoordsList)
                {
                    sw.WriteLine(p.X + " , " + p.Y + " , " + p.timeFromGameStart.ToString("F0"));
                }
            }
            return gameId;
        }

        protected void TimeCountdown()
        {
            DateTime endTime = DateTime.Now.AddSeconds(questionTime);

            while (endTime >= DateTime.Now)
            {
                this.timeLabel.BeginInvoke((MethodInvoker)delegate()
                {
                    this.timeLabel.Text = String.Format("{0:N2} s",
                        (endTime - DateTime.Now).TotalSeconds);
                });

                Thread.Sleep(10);
            }

            this.timeLabel.BeginInvoke((MethodInvoker)delegate()
            {
                this.timeLabel.Text = "Time out!";
            });

            if(timeOutMethod != null)
                timeOutMethod();

        }

        protected int GetX()
        // return X mouse position
        {
            int X = MousePosition.X - this.Left - pictureBox.Location.X - 8;
            // -8 is shifted because of strange window coordinates
            if (X < 0)
                return 0;
            if (X > CHART_WIDTH)
                return CHART_WIDTH;
            return X;
        }

        protected int GetY()
        // return Y mouse position
        {
            int Y = MousePosition.Y - this.Top - pictureBox.Location.Y - 30;
            // -30 is shifted because of strange window coordinates
            if (Y < 0)
                return 0;
            if (Y > CHART_HEIGHT)
                return CHART_HEIGHT;
            return Y;
        }

        protected string GetXString()
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

        protected string GetYString()
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

        protected void highlightLabel(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.BlueViolet;
        }

        protected void removeHighlightLabel(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.Black;
        }

        protected void writeToPictureBox(Graphics graphics, String text, int X, int Y, int fontSize)
        {
            using (Font myFont = new Font("Times New Roman", fontSize))
            {
                graphics.DrawString(text, myFont, Brushes.Black, new Point(X, Y));
            }
        }

        protected void SaveCoordinates(int GRANULATION, List<TimePoint> CoordsList)
        // writing coordinates to list of coords
        {
            int LastX = 0, LastY = 0;
            DateTime startTime = DateTime.Now;
            while (true)
            {
                if (!(LastX + GRANULATION > GetX()
                    && LastX - GRANULATION < GetX()
                    && LastY + GRANULATION > GetY()
                    && LastY - GRANULATION < GetY()))
                {
                    CoordsList.Add(new TimePoint(GetX(), GetY(), (DateTime.Now - startTime).TotalMilliseconds));
                    LastX = GetX();
                    LastY = GetY();
                }
                Thread.Sleep(10);
            }
        }

        protected Tuple<MoodWindow.MoodFromHappyToAngryScale, MoodWindow.MoodFromExcitedToBoredScale> getMood()
        {
            MoodWindow = new MoodWindow();
            MoodWindow.ShowDialog();
            return MoodWindow.getMoods();
        }

        protected override void WndProc(ref Message msg)
        //workaround to not repaint windows when ALT is pressed
        {
            if (msg.Msg != 0x128)
            {
                base.WndProc(ref msg);
            }
        }
    }
}
