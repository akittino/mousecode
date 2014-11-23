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
    public partial class analyzingAppWindow : Form
    {
        public analyzingAppWindow()
        {
            InitializeComponent();

            playFile pf = new playFile(@"C:\Users\akantak\Personal Data\inz\mousecode\mouse\bin\Debug\ReflexGame\q\2014-11-22\1\P\14-47-41.csv", 20);

            bool b1 = pf.getCorrectAnswer();

            int i1 = pf.getStops();
            int i2 = pf.getGameTime();

            double d1 = pf.getPath();
            double d2 = pf.getDistance();
            double d3 = pf.getDistanceToPath();
            double d4 = pf.getMovingTime();
            double d5 = pf.getAverageSpeed();
            double d6 = pf.getTimeAfterStop();
            double d7 = pf.getTimeBeforeStart();


        }

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
            readonly int STOPS_GRANULATION; 

            List<TimePoint> coordsList = null;

            int? gameTime = null;
            int? stops = null;

            bool fileValid = true;
            bool correctAnswer = true;

            double? path = null;
            double? distance = null;
            double? movingTime = null;
            double? averageSpeed = null;
            double? timeAfterStop = null;
            double? distanceToPath = null;
            double? timeBeforeStart = null;

            public playFile(string path, int _stopsGranulation)
            {
                STOPS_GRANULATION = _stopsGranulation;
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
                                fileValid = false;
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
                                fileValid = false;
                                coordsList = null;
                                gameTime = null;
                                return;
                            }
                        }

                    }
                }
                catch (IOException e)
                {
                    Console.Write(e.ToString());
                    fileValid = false;
                    //TODO log
                    return;
                }
            }

            public bool getFileValid()
            {
                return fileValid;
            }
            public bool getCorrectAnswer()
            {
                return correctAnswer;
            }
            public int getGameTime()
            {
                //TODO check exception
                return (int)gameTime;
            }
            public double getPath()
            {
                if (path == null)
                {
                    path = 0;

                    for (int i = 1; i < coordsList.Count; ++i)
                    {
                        int dX = coordsList[i - 1].X - coordsList[i].X;
                        int dY = coordsList[i - 1].Y - coordsList[i].Y;

                        path += Math.Sqrt((double)((dX * dX) + (dY * dY)));
                    }
                }
                return (double)path;
            }
            public double getDistance()
            {
                if (distance == null)
                {
                    distance = 0;

                    int dX = coordsList[coordsList.Count - 1].X - coordsList[0].X;
                    int dY = coordsList[coordsList.Count - 1].Y - coordsList[0].Y;

                    distance = Math.Sqrt((double)((dX * dX) + (dY * dY)));
                }
                return (double)distance;
            }
            public double getDistanceToPath()
            {
                if (distanceToPath == null)
                {
                    if (distance == null)
                        this.getDistance();

                    if (path == null)
                        this.getPath();

                    distanceToPath = distance / path;
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
            public double getAverageSpeed()
            {
                if (averageSpeed == null)
                {
                    if (path == null)
                        this.getPath();

                    if (movingTime == null)
                        this.getMovingTime();

                    averageSpeed = path / movingTime;
                }
                return (double)averageSpeed;
            }
            public double getTimeBeforeStart()
            {
                if (timeBeforeStart == null)
                {
                    timeBeforeStart = coordsList[1].timeFromGameStart - coordsList[0].timeFromGameStart;
                }
                return (double)timeBeforeStart;
            }
            public double getTimeAfterStop()
            {
                if (timeAfterStop == null)
                {
                    timeAfterStop = gameTime - coordsList[coordsList.Count - 1].timeFromGameStart;
                }
                return (double)timeAfterStop;
            }
            public int getStops()
            {
                if (stops == null)
                {
                    stops = 0;
                    for (int i = 1; i < coordsList.Count; ++i)
                    {
                        int dX = coordsList[i - 1].X - coordsList[i].X;
                        int dY = coordsList[i - 1].Y - coordsList[i].Y;
                        double dZ = Math.Sqrt((double)((dX * dX) + (dY * dY)));

                        if (dZ < STOPS_GRANULATION)
                            ++stops;
                    }
                }
                return (int)stops;
            }
        }

    }

}