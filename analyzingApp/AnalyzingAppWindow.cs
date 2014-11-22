using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace analyzingApp
{
    public class TimePoint
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

    public class playFile
    {
        List<TimePoint> coordsList;
        int gameTime;
        bool correctAnswer = true;

        private double? pathLong = null;
        private double? distanceLong = null;
        private double? distanceToPath = null;
        private double? movingTime = null;

        public playFile(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string s;
                    if (!path.Contains("ReflexGame"))
                    {
                        s = sr.ReadLine();

                        if (s.Split(':').Length != 2)
                        {
                            return;
                        }

                        if (s.Split(':')[1] == " NO")
                        {
                            correctAnswer = false;
                        }
                    }

                    s = sr.ReadLine();
                    gameTime = int.Parse(s.Split(',')[0]);

                    s = sr.ReadLine();
                    coordsList = new List<TimePoint>();
                    while (!string.IsNullOrEmpty(s))
                    {
                        string[] splitted = s.Split(',');

                        if (splitted.Length == 3)
                        {
                            int X = int.Parse(s.Split(',')[0]);
                            int Y = int.Parse(s.Split(',')[1]);
                            int t = int.Parse(s.Split(',')[2]);

                            coordsList.Add(new TimePoint(X, Y, t));
                            s = sr.ReadLine();
                        }
                        else
                        {
                            coordsList = null;
                            return;
                        }
                    }

                }
            }
            catch (IOException e)
            {
                Console.Write(e.ToString());
                //TODO log
                return;
            }
        }

        public bool getCorrectAnswer()
        {
            return correctAnswer;
        }

        public double getPathLong()
        {
            if (pathLong == null)
            {
                pathLong = 0;

                for (int i = 1; i < coordsList.Count; ++i)
                {
                    int dX = coordsList[i - 1].X - coordsList[i].X;
                    int dY = coordsList[i - 1].Y - coordsList[i].Y;
                    pathLong += Math.Sqrt((double)((dX * dX) + (dY * dY)));
                }
            }
            return (double)pathLong;
        }
        public double getDistanceLong()
        {
            if (distanceLong == null)
            {
                distanceLong = 0;

                int dX = coordsList[coordsList.Count - 1].X - coordsList[0].X;
                int dY = coordsList[coordsList.Count - 1].Y - coordsList[0].Y;

                distanceLong = Math.Sqrt((double)((dX * dX) + (dY * dY)));
            }
            return (double)distanceLong;
        }
        public double getDistanceToPath()
        {
            if (distanceToPath == null)
            {
                if (distanceLong == null)
                    this.getDistanceLong();

                if (pathLong == null)
                    this.getPathLong();

                distanceToPath = distanceLong / pathLong;
            }
            return (double)distanceToPath;
        }
        public double getMovingTime()
        {
            if (movingTime == null)
            {
                movingTime = coordsList[coordsList.Count - 1].timeFromGameStart - coordsList[1].timeFromGameStart;
            }
            return (double)movingTime;
        }
    }

    public partial class analyzingAppWindow : Form
    {

        public analyzingAppWindow()
        {
            InitializeComponent();
            playFile pf = new playFile(@"C:\Users\akantak\Personal Data\inz\mousecode\mouse\bin\Debug\ReflexGame\q\2014-11-22\1\P\14-47-41.csv");
            double a = pf.getPathLong();
            double b = pf.getDistanceLong();
            double c = pf.getDistanceToPath();
            double d = pf.getMovingTime();

        }
    }
}
