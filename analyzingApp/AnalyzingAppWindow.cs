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
using analyzingApp;

namespace analyzingApp
{
    public partial class analyzingAppWindow : Form
    {
        double d1, d2, d3, d4, d5, d6, d7, d8;
        int i1, i2;
        bool b1;

        List<string> addList = new List<string>();
        List<Attributes> attributesToAdd = new List<Attributes>();
        List<Attributes> listOfAttributes = new List<Attributes>();
        BindingList<Attributes> dataOriginal = new BindingList<Attributes>();
        BindingList<Attributes> dataToAdd = new BindingList<Attributes>();


        public analyzingAppWindow()
        {
            InitializeComponent();
            int stops_granulation = 20; // TODO@DAX this should be parameter to pf readed from window
            string filePath = @"C:\Users\dkotecka\Documents\mousecode\mousecode\mouse\bin\Debug\ColorsGame\Dagmara\2014-11-23\5\L\16-02-30.csv";
            
            playFile pf = new playFile(filePath, stops_granulation);

            b1 = pf.getAttributeCorrectAnswer();

            i1 = pf.getAttributeStops();
            i2 = pf.getAttributeGameTime();

            d1 = pf.getAttributePath();
            d2 = pf.getAttributeDistance();
            d3 = pf.getAttributeDistanceToPath();
            d4 = pf.getAttributeMovingTime();
            d5 = pf.getAttributeAverageSpeed();
            d6 = pf.getAttributeTimeAfterStop();
            d7 = pf.getAttributeTimeBeforeStart();
            d8 = pf.getAttributeMaxSpeed();
        }

        private void analyzingAppWindow_Load(object sender, EventArgs e)
        {
            string[] games = { "ColorsGame", "ReflexGame", "ThingsGame" };

            fileViewer.CheckBoxes = true;

            foreach (DirectoryInfo d in (new DirectoryInfo(@"..\..\..\mouse\bin\Debug")).GetDirectories()) // TODO change file path 
            {
                foreach (string g in games)
                {
                    if (d.Name.Equals(g))
                    {
                        TreeNode t = fileViewer.Nodes.Add(d.Name);
                        readChildNodes(t);
                    }
                }
            }
            fileViewer.ExpandAll();

            attributesToChoose();
        }
        private void readChildNodes(TreeNode t)
        {
            DirectoryInfo[] dirsInfo = (new DirectoryInfo(@"..\..\..\mouse\bin\Debug" + @"\" + t.FullPath)).GetDirectories(); // TODO change file path 

            if (dirsInfo.Length != 0)
            {
                foreach (DirectoryInfo d in dirsInfo)
                {
                    TreeNode tn = t.Nodes.Add(d.Name);
                    readChildNodes(tn);
                }
            }
            else
            {
                FileInfo[] files = (new DirectoryInfo(@"..\..\..\mouse\bin\Debug" + @"\" + @"\" + t.FullPath)).GetFiles();// TODO change file path 
                foreach (FileInfo f in files)
                {
                    t.Nodes.Add(f.Name);
                }
            }
        }

        private void attributesToChoose()
        {
            settingListOfAttributes();
            this.listboxBase.DataSource = dataOriginal;
            this.listboxBase.DisplayMember = "Name";
            this.listboxBase.ValueMember = "Value";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var selectedItem = (Attributes)listboxBase.SelectedItem;

            for (int i = 0; i < listboxBase.Items.Count; i++)
            {
                if (listboxBase.GetSelected(i))
                {
                    dataToAdd.Add(new Attributes { Name = selectedItem.Name, Value = selectedItem.Value });
                    listboxToAdd.DataSource = dataToAdd;
                    listboxToAdd.DisplayMember = "Name";
                    listboxToAdd.ValueMember = "Value";

                    int index = listboxBase.FindString(selectedItem.Name);
                    dataOriginal.RemoveAt(index);
                    this.listboxBase.DataSource = dataOriginal;
                    
                }
            }
        }
        private void settingListOfAttributes()
        {

            dataOriginal.Add(new Attributes { Name = "Correct Answer", Value = b1.ToString()});
            dataOriginal.Add(new Attributes { Name = "Stops", Value = i1.ToString() });
            dataOriginal.Add(new Attributes { Name = "Game Time", Value = i2.ToString() });
            dataOriginal.Add(new Attributes { Name = "Path", Value = d1.ToString() });
            dataOriginal.Add(new Attributes { Name = "Distance", Value = d2.ToString() });
            dataOriginal.Add(new Attributes { Name = "Distance to Path", Value = d3.ToString() });
            dataOriginal.Add(new Attributes { Name = "Moving Time", Value = d4.ToString() });
            dataOriginal.Add(new Attributes { Name = "Average Speed", Value = d5.ToString() });
            dataOriginal.Add(new Attributes { Name = "Time After Stop", Value = d6.ToString() });
            dataOriginal.Add(new Attributes { Name = "Time Before Start", Value = d7.ToString() });
            dataOriginal.Add(new Attributes { Name = "Max Speed", Value = d8.ToString() });

            
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            var selectedItem = (Attributes)listboxToAdd.SelectedItem;

            for (int i = 0; i < listboxToAdd.Items.Count; i++)
            {
                if (listboxToAdd.GetSelected(i))
                {
                    dataOriginal.Add(new Attributes { Name = selectedItem.Name, Value = selectedItem.Value });
                    listboxBase.DataSource = dataOriginal;
                    listboxBase.DisplayMember = "Name";
                    listboxBase.ValueMember = "Value";

                    int index = listboxToAdd.FindString(selectedItem.Name);
                    dataToAdd.RemoveAt(index);
                    this.listboxToAdd.DataSource = dataToAdd;
                }
            }
        }

    }
}