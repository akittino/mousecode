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

    }
}