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
        double d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, d11, d12, d13;
        int i1, i2, i3, i4, i5;
        bool b1;

        List<string> addList = new List<string>();
        List<Attributes> attributesToAdd = new List<Attributes>();
        List<Attributes> listOfAttributes = new List<Attributes>();
        BindingList<Attributes> dataOriginal = new BindingList<Attributes>();
        BindingList<Attributes> dataToAdd = new BindingList<Attributes>();
        List<string> pathList = new List<string>();
        List<object> listOfGetAttributes = new List<object>();


        public analyzingAppWindow()
        {
            InitializeComponent();
        }
        public class Attributes
        {
            public string Name { get; set; }
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
            settingListOfAttributes(dataOriginal);
            this.listboxBase.DataSource = dataOriginal;
            this.listboxBase.DisplayMember = "Name";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var selectedItem = (Attributes)listboxBase.SelectedItem;

            for (int i = 0; i < listboxBase.Items.Count; i++)
            {
                if (listboxBase.GetSelected(i))
                {
                    dataToAdd.Add(new Attributes { Name = selectedItem.Name });
                    listboxToAdd.DataSource = dataToAdd;
                    listboxToAdd.DisplayMember = "Name";

                    int index = listboxBase.FindString(selectedItem.Name);
                    dataOriginal.RemoveAt(index);
                    this.listboxBase.DataSource = dataOriginal;
                }
            }
        }
        private void settingListOfAttributes(BindingList<Attributes> list)
        {
            list.Add(new Attributes { Name = "Correct Answer" });
            list.Add(new Attributes { Name = "Stops" });
            list.Add(new Attributes { Name = "Game Time" });
            list.Add(new Attributes { Name = "Perfect Line Crosses" });
            list.Add(new Attributes { Name = "Excitement Mood Attribute"});
            list.Add(new Attributes { Name = "Mood" });
            list.Add(new Attributes { Name = "Path" });
            list.Add(new Attributes { Name = "Distance" });
            list.Add(new Attributes { Name = "Distance to Path" });
            list.Add(new Attributes { Name = "Moving Time" });
            list.Add(new Attributes { Name = "Average Speed" });
            list.Add(new Attributes { Name = "Time After Stop" });
            list.Add(new Attributes { Name = "Time Before Start" });
            list.Add(new Attributes { Name = "Max Speed" });
            list.Add(new Attributes { Name = "Perfect Line On Top Percentage" });
            list.Add(new Attributes { Name = "Stop Button Percentage Height" });
            list.Add(new Attributes { Name = "Stop Button Percentage Width" });
            list.Add(new Attributes { Name = "Start Button Percentage Height" });
            list.Add(new Attributes { Name = "Start Button Percentage Width" });
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            var selectedItem = (Attributes)listboxToAdd.SelectedItem;

            for (int i = 0; i < listboxToAdd.Items.Count; i++)
            {
                if (listboxToAdd.GetSelected(i))
                {
                    dataOriginal.Add(new Attributes { Name = selectedItem.Name });
                    listboxBase.DataSource = dataOriginal;
                    listboxBase.DisplayMember = "Name";

                    int index = listboxToAdd.FindString(selectedItem.Name);
                    dataToAdd.RemoveAt(index);
                    this.listboxToAdd.DataSource = dataToAdd;
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!granulationTextbox.Text.Equals(""))
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV Files|*.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    int stops_granulation = Convert.ToInt32(granulationTextbox.Text);

                    for (int i = 0; i < pathList.Count; i++)
                    {
                        listOfGetAttributes.Clear();
                        playFile pf = new playFile(pathList[i], stops_granulation);
                        if (pf.getAttributeFileValid() == false)
                        {
                            //add to log which file was invalid
                            break;
                        }
                        else
                        {
                            addGetAttributesToList(pf);
                            //TODO add new functions added by Olek +  save file
                            //TODO check which attributes were selected and add to file


                            uncheckAllNodes(fileViewer.Nodes);
                            pathList.Clear();
                        }
                        
                    }
                }
            }
            else
                MessageBox.Show("Granulation textbox should be filled before saving.");
        }

        private void uncheckAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode tn in nodes)
            {
                tn.Checked = false;
                CheckChildren(tn, false);
            }
        }

        private void CheckChildren(TreeNode tn, Boolean uncheck)
        {
            foreach (TreeNode t in tn.Nodes)
            {
                CheckChildren(t, uncheck);
                t.Checked = true;
            }
        }

        private void addGetAttributesToList(playFile pf)
        {

            listOfGetAttributes.Add(pf.getAttributeCorrectAnswer());
            listOfGetAttributes.Add(pf.getAttributeStops());
            listOfGetAttributes.Add(pf.getAttributeGameTime());
            listOfGetAttributes.Add(pf.getAttributePerfectLineCrosses());
            listOfGetAttributes.Add(pf.getAttributeExcitement());
            listOfGetAttributes.Add(pf.getAttributeHappiness());
            listOfGetAttributes.Add(pf.getAttributePath());
            listOfGetAttributes.Add(pf.getAttributeDistance());
            listOfGetAttributes.Add(pf.getAttributeDistanceToPath());
            listOfGetAttributes.Add(pf.getAttributeMovingTime());
            listOfGetAttributes.Add(pf.getAttributeAverageSpeed());
            listOfGetAttributes.Add(pf.getAttributeTimeAfterStop());
            listOfGetAttributes.Add(pf.getAttributeTimeBeforeStart());
            listOfGetAttributes.Add(pf.getAttributeMaxSpeed());
            listOfGetAttributes.Add(pf.getAttributePerfectLineOnTopPercentage());
            listOfGetAttributes.Add(pf.getAttributeStopButtonPercentageHeight());
            listOfGetAttributes.Add(pf.getAttributeStopButtonPercentageWidth());
            listOfGetAttributes.Add(pf.getAttributeStartButtonPercentageHeight());
            listOfGetAttributes.Add(pf.getAttributeStartButtonPercentageWidth());
        }

        private void granulationTextbox_TextChanged(object sender, EventArgs e)
        {
            string granulationValue = "";
            int granulationValidator = 0;
            if (granulationTextbox.Text != "")
            {
                try
                {
                    granulationValue = granulationTextbox.Text;
                    granulationValidator = Convert.ToInt32(granulationValue);
                    granulationValue = "0";
                }
                catch
                {
                    MessageBox.Show("Please enter only numbers.");
                    granulationTextbox.Text = "";
                    granulationValue = "1000";
                }
            }
            if (!String.IsNullOrEmpty(granulationTextbox.Text) && (granulationValidator < 1 || granulationValidator > 25))
            {
                MessageBox.Show("Please enter granulation in range from 1 to 25.");
                granulationTextbox.Text = "";
            }
        }

        private void removeAllButton_Click(object sender, EventArgs e)
        {
            listboxToAdd.DataSource = null;
            listboxToAdd.Items.Clear();
            listboxBase.DataSource = null;
            dataOriginal.Clear();
            dataToAdd.Clear();
            listboxToAdd.Items.Clear();
            settingListOfAttributes(dataOriginal);
            listboxBase.DataSource = dataOriginal;
            listboxBase.DisplayMember = "Name";
        }

        private void addAllButton_Click(object sender, EventArgs e)
        {
            listboxBase.DataSource = null;
            listboxBase.Items.Clear();
            listboxToAdd.DataSource = null;
            dataOriginal.Clear();
            dataToAdd.Clear();
            listboxBase.Items.Clear();
            settingListOfAttributes(dataToAdd);
            listboxToAdd.DataSource = dataToAdd;
            listboxToAdd.DisplayMember = "Name";
        }

        private void fileViewer_AfterCheck(object sender, TreeViewEventArgs e)
        {
            bool c = e.Node.Checked;
            string path = "";
            if (e.Node.FullPath.Contains(".csv"))
            {   
                //temp solution
                //TODO still something wrong
                DirectoryInfo dir = new DirectoryInfo(@"..\..\..\mouse\bin\Debug");
                path =  Path.GetFullPath(dir.FullName) + @"\" + e.Node.FullPath; // tmp
                pathList.Add(path);
            }
            else// TODO for other dirs to get csv files
            { 
                
            }
        }
    }
}