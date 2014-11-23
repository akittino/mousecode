using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class buttonCoordinates
    {
        public int X1, X2, Y1, Y2;
        public buttonCoordinates(int _X1, int _X2, int _Y1, int _Y2)
        {
            X1 = _X1;
            X2 = _X2;
            Y1 = _Y1;
            Y2 = _Y2;
        }
    }

    public class playFile
    {
        readonly int STOPS_GRANULATION;
        readonly bool usedLeftButton;
        readonly buttonCoordinates stopButton;
        readonly buttonCoordinates startButton;

        List<TimePoint> coordsList = null;

        int? perfectLineCrosses = null;
        int? gameTime = null;
        int? stops = null;

        bool fileValid = true;
        bool correctAnswer = true;

        double? path = null;
        double? distance = null;
        double? maxSpeed = null;
        double? movingTime = null;
        double? averageSpeed = null;
        double? timeAfterStop = null;
        double? distanceToPath = null;
        double? timeBeforeStart = null;
        double? stopButtonPercentageWidth = null;
        double? stopButtonPercentageHeight = null;
        double? perfectLineOnTopPercentage = null;
        double? startButtonPercentageWidth = null;
        double? startButtonPercentageHeight = null;

        public playFile(string path, int _stopsGranulation)
        {
            STOPS_GRANULATION = _stopsGranulation;
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    if (path.Split('\\')[path.Split('\\').Length - 2] == "L")
                    {
                        usedLeftButton = true;
                    }
                    else
                    {
                        usedLeftButton = false;
                    }

                    string s;
                    if (!path.Contains("ReflexGame"))
                    {
                        if(path.Contains("ThingsGame"))
                        {
                            startButton = new buttonCoordinates(320, 320 + 157, 600 - 54, 600);
                            if(usedLeftButton)
                            {
                                stopButton = new buttonCoordinates(0, 118, 0, 82);
                            }
                            else
                            {
                                stopButton = new buttonCoordinates(800 - 118, 800, 0, 82);
                            }
                        }
                        else
                        {
                            startButton = new buttonCoordinates(318, 318 + 198, 0, 136);
                            if (usedLeftButton)
                            {
                                stopButton = new buttonCoordinates(0, 118, 600 - 82, 600);
                            }
                            else
                            {
                                stopButton = new buttonCoordinates(800 - 118, 800, 600 - 82, 600);
                            }
                        }
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
                    else
                    {
                        startButton = new buttonCoordinates(346, 346 + 82, 600 - 82, 600);
                        if(usedLeftButton)
                        {
                            stopButton = new buttonCoordinates(0, 118, 0, 82);
                        }
                        else
                        {
                            stopButton = new buttonCoordinates(800 - 118, 800, 0, 82);
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

        private void perfectLineAnalyze()
        {
            perfectLineCrosses = 0;
            perfectLineOnTopPercentage = 0;

            if (path == null)
                getAttributeDistance();
            double pathOnTop = 0;

            int Ax = coordsList[0].X;
            int Ay = coordsList[0].Y;
            int Bx = coordsList[coordsList.Count - 1].X;
            int By = coordsList[coordsList.Count - 1].Y;
            int lastSign = -1;
            //TODO maths below is very naive, fix it! find better way to split the segment when sign changes

            for (int i = 1; i < coordsList.Count - 2; ++i)
            {
                int sign = Math.Sign((Bx - Ax) * (coordsList[i].Y - Ay) - (By - Ay) * (coordsList[i].X - Ax));

                if(sign != 0 && sign != lastSign)
                {
                    ++perfectLineCrosses;
                    lastSign = sign;
                }

                if(lastSign == -1)
                {
                    int dX = coordsList[i].X - coordsList[i - 1].X;
                    int dY = coordsList[i].Y - coordsList[i - 1].Y;

                    pathOnTop += Math.Sqrt((double)((dX * dX) + (dY * dY)));
                }
            }

            if (lastSign == -1)
            {
                int dX = coordsList[coordsList.Count - 1].X - coordsList[coordsList.Count - 2].X;
                int dY = coordsList[coordsList.Count - 1].Y - coordsList[coordsList.Count - 2].Y;

                pathOnTop += Math.Sqrt((double)((dX * dX) + (dY * dY)));
            }

            perfectLineOnTopPercentage = pathOnTop / path;


        }

        public bool getAttributeFileValid()
        {
            return fileValid;
        }
        public bool getAttributeCorrectAnswer()
        {
            return correctAnswer;
        }
        public int getAttributeGameTime()
        {
            return (int)gameTime;
        }
        public int getAttributePerfectLineCrosses()
        {
            if (perfectLineCrosses == null)
            {
                perfectLineAnalyze();
            }
            return (int)perfectLineCrosses;
        }
        public int getAttributeStops()
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
        public double getAttributePath()
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
        public double getAttributeDistance()
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
        public double getAttributeDistanceToPath()
        {
            if (distanceToPath == null)
            {
                if (distance == null)
                    this.getAttributeDistance();

                if (path == null)
                    this.getAttributePath();

                distanceToPath = distance / path;
            }
            return (double)distanceToPath;
        }
        public double getAttributeMovingTime()
        {
            if (movingTime == null)
            {
                movingTime = coordsList[coordsList.Count - 1].timeFromGameStart - coordsList[1].timeFromGameStart;
            }
            return (double)movingTime;
        }
        public double getAttributeAverageSpeed()
        {
            if (averageSpeed == null)
            {
                if (path == null)
                    this.getAttributePath();

                if (movingTime == null)
                    this.getAttributeMovingTime();

                averageSpeed = path / movingTime;
            }
            return (double)averageSpeed;
        }
        public double getAttributeTimeBeforeStart()
        {
            if (timeBeforeStart == null)
            {
                timeBeforeStart = coordsList[1].timeFromGameStart - coordsList[0].timeFromGameStart;
            }
            return (double)timeBeforeStart;
        }
        public double getAttributeTimeAfterStop()
        {
            if (timeAfterStop == null)
            {
                timeAfterStop = gameTime - coordsList[coordsList.Count - 1].timeFromGameStart;
            }
            return (double)timeAfterStop;
        }
        public double getAttributeMaxSpeed()
        {
            if(maxSpeed == null)
            {
                maxSpeed = 0;
                for (int i = 1; i < coordsList.Count; ++i)
                {
                    int dX = coordsList[i - 1].X - coordsList[i].X;
                    int dY = coordsList[i - 1].Y - coordsList[i].Y;
                    double dT = Math.Abs(coordsList[i - 1].timeFromGameStart - coordsList[i].timeFromGameStart);
                    double distance = Math.Sqrt((double)((dX * dX) + (dY * dY)));

                    double tmpMaxSpeed = distance / dT;

                    if (tmpMaxSpeed > maxSpeed)
                        maxSpeed = tmpMaxSpeed;
                }
            }
            return (double)maxSpeed;
        }
        public double getAttributePerfectLineOnTopPercentage()
        {
            if(perfectLineOnTopPercentage == null)
            {
                perfectLineAnalyze();
            }
            return (double)perfectLineOnTopPercentage;
        }
        public double getAttributeStopButtonPercentageHeight()
        {
            if(stopButtonPercentageHeight == null)
            {
                stopButtonPercentageHeight = ((double)coordsList[coordsList.Count - 1].Y - stopButton.Y1) / (stopButton.Y2 - stopButton.Y1);
            }
            return (double)stopButtonPercentageHeight;
        }
        public double getAttributeStopButtonPercentageWidth()
        {
            if (stopButtonPercentageWidth == null)
            {
                stopButtonPercentageWidth = ((double)coordsList[coordsList.Count - 1].X - stopButton.X1) / (stopButton.X2 - stopButton.X1);
            }
            return (double)stopButtonPercentageWidth;
        }
        public double getAttributeStartButtonPercentageHeight()
        {
            if (startButtonPercentageHeight == null)
            {
                startButtonPercentageHeight = ((double)coordsList[0].Y - startButton.Y1) / (startButton.Y2 - startButton.Y1);
            }
            return (double)startButtonPercentageHeight;
        }
        public double getAttributeStartButtonPercentageWidth()
        {
            if (startButtonPercentageWidth == null)
            {
                startButtonPercentageWidth = ((double)coordsList[0].X - startButton.X1) / (startButton.X2 - startButton.X1);
            }
            return (double)startButtonPercentageWidth;
        }
    }
}
