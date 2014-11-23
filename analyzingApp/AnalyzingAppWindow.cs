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
            int stops_granulation = 20; // TODO@DAX this should be parameter to pf readed from window
            string filePath = @"C:\Users\akantak\Personal Data\inz\mousecode\mouse\bin\Debug\ReflexGame\q\2014-11-22\1\P\14-47-41.csv";

            playFile pf = new playFile(filePath, stops_granulation);

            bool b1 = pf.getAttributeCorrectAnswer();

            int i1 = pf.getAttributeStops();
            int i2 = pf.getAttributeGameTime();

            double d1 = pf.getAttributePath();
            double d2 = pf.getAttributeDistance();
            double d3 = pf.getAttributeDistanceToPath();
            double d4 = pf.getAttributeMovingTime();
            double d5 = pf.getAttributeAverageSpeed();
            double d6 = pf.getAttributeTimeAfterStop();
            double d7 = pf.getAttributeTimeBeforeStart();
            double d8 = pf.getAttributeMaxSpeed();

            
        }

    }
}