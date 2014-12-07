using System;
using System.Collections.Generic;
using System.IO;

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

    public class ButtonCoordinates
    {
        public int X1, X2, Y1, Y2;
        public ButtonCoordinates(int _X1, int _X2, int _Y1, int _Y2)
        {
            X1 = _X1;
            X2 = _X2;
            Y1 = _Y1;
            Y2 = _Y2;
        }
    }

    public class PlayFile
    {
        readonly int STOPS_GRANULATION;
        readonly bool usedLeftButton;
        readonly ButtonCoordinates stopButton;
        readonly ButtonCoordinates startButton;

        List<TimePoint> coordsList = null;

        int? stops = null;
        int? gameTime = null;
        int? happyMood = null;
        int? excitedMood = null;
        int? perfectLineCrosses = null;

        bool correctAnswer = true;

        double? maxSpeed = null;
        double? distance = null;
        double? movingTime = null;
        double? pathLength = null;
        double? averageSpeed = null;
        double? maxSpeedTime = null;
        double? maxSpeedPlace = null;
        double? timeAfterStop = null;
        double? distanceToPath = null;
        double? timeBeforeStart = null;
        double? standardDeviation = null;
        double? stopButtonPercentageWidth = null;
        double? stopButtonPercentageHeight = null;
        double? perfectLineOnTopPercentage = null;
        double? startButtonPercentageWidth = null;
        double? startButtonPercentageHeight = null;

        string fileLog = null;

        public PlayFile(string path, int _stopsGranulation)
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
                        if (path.Contains("ThingsGame"))
                        {
                            startButton = new ButtonCoordinates(320, 320 + 157, 600 - 54, 600);
                            if (usedLeftButton)
                            {
                                stopButton = new ButtonCoordinates(0, 118, 0, 82);
                            }
                            else
                            {
                                stopButton = new ButtonCoordinates(800 - 118, 800, 0, 82);
                            }
                        }
                        else
                        {
                            startButton = new ButtonCoordinates(318, 318 + 198, 0, 136);
                            if (usedLeftButton)
                            {
                                stopButton = new ButtonCoordinates(0, 118, 600 - 82, 600);
                            }
                            else
                            {
                                stopButton = new ButtonCoordinates(800 - 118, 800, 600 - 82, 600);
                            }
                        }
                        s = sr.ReadLine();

                        if (s.Split(':')[1] == " NO")
                        {
                            correctAnswer = false;
                        }
                    }
                    else
                    {
                        startButton = new ButtonCoordinates(346, 346 + 82, 600 - 82, 600);
                        if (usedLeftButton)
                        {
                            stopButton = new ButtonCoordinates(0, 118, 0, 82);
                        }
                        else
                        {
                            stopButton = new ButtonCoordinates(800 - 118, 800, 0, 82);
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
                            fileLog = "For file:\n" + path + "\nCoordinates line hadn't three values in line. Couldn't proceed it!\n";
                            coordsList = null;
                            gameTime = null;
                            return;
                        }
                    }

                }

                if (coordsList.Count < 5)
                {
                    fileLog = "For file:\n" + path + "\nFile was corrupted. Couldn't proceed it!\n";
                    return;
                }

                string[] pathParts = path.Split('\\');
                string moodPath = "";

                for (int i = 0; i < pathParts.Length - 2; ++i)
                {
                    moodPath += pathParts[i] + '\\';
                }

                moodPath += "gameDetails.txt";

                if (!File.Exists(moodPath))
                {
                    fileLog = "For file:\n" + path + "\nThere was no mood file. Couldn't proceed it!\n";
                    return;
                }

                using (StreamReader sr = new StreamReader(moodPath))
                {
                    string s = sr.ReadLine().Split(':')[1];
                    happyMood = getHappyMood(s);

                    s = sr.ReadLine().Split(':')[1];
                    excitedMood = getExcitedMood(s);
                }
            }

            catch (DirectoryNotFoundException)
            {
                fileLog = "Directory not found exception for file: \n" + path + "\n";
            }
            catch (FileNotFoundException)
            {
                fileLog = "File not found exception for file: \n" + path + "\n";
            }
            catch (FormatException)
            {
                fileLog = "Data was corrupted for file: \n" + path + "\n";
            }
            catch (Exception)
            {
                fileLog = "Unrecognized error for file: \n" + path + "\n";
            }
            return;

        }

        private int getHappyMood(string s)
        {
            switch (s)
            {
                case " Very_Happy":
                    return 1;
                case " Happy":
                    return 2;
                case " Normal":
                    return 3;
                case " Angry":
                    return 4;
                case " Very_Angry":
                    return 5;
                default:
                    return 0;
            }
        }
        private int getExcitedMood(string s)
        {
            switch (s)
            {
                case " Very_Excited":
                    return 1;
                case " Excited":
                    return 2;
                case " Normal":
                    return 3;
                case " Bored":
                    return 4;
                case " Very_Bored":
                    return 5;
                default:
                    return 0;
            }
        }
        private void perfectLineAnalyze()
        {
            perfectLineCrosses = 0;
            perfectLineOnTopPercentage = 0;

            if (pathLength == null)
                getAttributePathLength();
            double pathOnTop = 0;

            int Ax = coordsList[0].X;
            int Ay = coordsList[0].Y;
            int Bx = coordsList[coordsList.Count - 1].X;
            int By = coordsList[coordsList.Count - 1].Y;
            int lastSign = -1;

            for (int i = 1; i < coordsList.Count - 2; ++i)
            {
                int sign = Math.Sign((Bx - Ax) * (coordsList[i].Y - Ay) - (By - Ay) * (coordsList[i].X - Ax));
                int dX = coordsList[i].X - coordsList[i - 1].X;
                int dY = coordsList[i].Y - coordsList[i - 1].Y;

                if (sign != 0 && sign != lastSign)
                {
                    ++perfectLineCrosses;
                    pathOnTop += Math.Sqrt((double)((dX * dX) + (dY * dY))) / 2;
                    lastSign = sign;
                }
                else if ((sign == 0 && lastSign == -1) || lastSign == -1)
                {
                    pathOnTop += Math.Sqrt((double)((dX * dX) + (dY * dY)));
                }
            }

            if (lastSign == -1)
            {
                int dX = coordsList[coordsList.Count - 1].X - coordsList[coordsList.Count - 2].X;
                int dY = coordsList[coordsList.Count - 1].Y - coordsList[coordsList.Count - 2].Y;

                pathOnTop += Math.Sqrt((double)((dX * dX) + (dY * dY)));
            }
            if (usedLeftButton)
            {
                perfectLineOnTopPercentage = 1 - (pathOnTop / pathLength);
            }
            else
            {
                perfectLineOnTopPercentage = pathOnTop / pathLength;
            }


        }

        public string getFileLog()
        {
            return fileLog;
        }
        public bool getFileValid()
        {
            if (fileLog == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int getAttributeCorrectAnswer()
        {
            return Convert.ToInt32(correctAnswer);
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
        public int getAttributeExcitement()
        {
            return (int)excitedMood;
        }
        public int getAttributeHappiness()
        {
            return (int)happyMood;
        }
        public double getAttributePathLength()
        {
            if (pathLength == null)
            {
                pathLength = 0;

                for (int i = 1; i < coordsList.Count; ++i)
                {
                    int dX = coordsList[i - 1].X - coordsList[i].X;
                    int dY = coordsList[i - 1].Y - coordsList[i].Y;

                    pathLength += Math.Sqrt((double)((dX * dX) + (dY * dY)));
                }
            }
            return (double)pathLength;
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

                if (pathLength == null)
                    this.getAttributePathLength();

                distanceToPath = distance / pathLength;
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
                if (pathLength == null)
                    this.getAttributePathLength();

                if (movingTime == null)
                    this.getAttributeMovingTime();

                averageSpeed = pathLength / movingTime;
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
            if (maxSpeed == null)
            {
                if (pathLength == null)
                {
                    getAttributePathLength();
                }

                maxSpeed = 0;
                double placeDistance = 0;
                for (int i = 1; i < coordsList.Count; ++i)
                {
                    int dX = coordsList[i - 1].X - coordsList[i].X;
                    int dY = coordsList[i - 1].Y - coordsList[i].Y;
                    double dT = coordsList[i].timeFromGameStart - coordsList[i - 1].timeFromGameStart;
                    double distance = Math.Sqrt((double)((dX * dX) + (dY * dY)));

                    placeDistance += distance;
                    double tmpSpeed = distance / dT;

                    if (tmpSpeed > maxSpeed)
                    {
                        maxSpeed = tmpSpeed;
                        maxSpeedPlace = placeDistance / pathLength;
                        maxSpeedTime = (coordsList[i].timeFromGameStart - (dT / 2)) / movingTime;
                    }
                }
            }
            return (double)maxSpeed;
        }
        public double getAttributeMaxSpeedTime()
        {
            if (maxSpeedTime == null)
            {
                getAttributeMaxSpeed();
            }
            return (double)maxSpeedTime;
        }
        public double getAttributeMaxSpeedPlace()
        {
            if (maxSpeedPlace == null)
            {
                getAttributeMaxSpeed();
            }
            return (double)maxSpeedPlace;
        }
        public double getAttributeStandardDeviation()
        {
            if (standardDeviation == null)
            {
                if (averageSpeed == null)
                    getAttributeAverageSpeed();

                double sum = 0;
                for (int i = 1; i < coordsList.Count; ++i)
                {
                    int dX = coordsList[i - 1].X - coordsList[i].X;
                    int dY = coordsList[i - 1].Y - coordsList[i].Y;
                    double dT = Math.Abs(coordsList[i - 1].timeFromGameStart - coordsList[i].timeFromGameStart);
                    double distance = Math.Sqrt((double)((dX * dX) + (dY * dY)));

                    double tmpSpeed = distance / dT;
                    sum += Math.Pow(tmpSpeed - (double)averageSpeed, 2);
                }
                standardDeviation = sum / (coordsList.Count - 1);
                // c4 factor is omitted, we don't need so much precision
            }
            return (double)standardDeviation;
        }
        public double getAttributePerfectLineOnTopPercentage()
        {
            if (perfectLineOnTopPercentage == null)
            {
                perfectLineAnalyze();
            }
            return (double)perfectLineOnTopPercentage;
        }
        public double getAttributeStopButtonPercentageHeight()
        {
            if (stopButtonPercentageHeight == null)
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
