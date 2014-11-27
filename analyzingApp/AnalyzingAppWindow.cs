using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace analyzingApp
{
    public partial class analyzingAppWindow : Form
    {
        const string GAMES_DIR = @"..\..\..\mouse\bin\Debug";

        DateTime checkedTime;
        bool checkingDown;
        int checkedLevel;

        Dictionary<string, MethodInfo> playFileMethods = new Dictionary<string, MethodInfo>();
        List<string> addList = new List<string>();
        List<Attribute> attributesToAdd = new List<Attribute>();
        List<Attribute> listOfAttributes = new List<Attribute>();
        BindingList<Attribute> dataOriginal = new BindingList<Attribute>();
        BindingList<Attribute> dataToAdd = new BindingList<Attribute>();
        List<string> pathList = new List<string>();
        List<object> listOfGetAttributes = new List<object>();


        public analyzingAppWindow()
        {
            InitializeComponent();
            checkedTime = DateTime.Now;
            checkingDown = false;
            checkedLevel = 0;
            getListOfAttributes();
        }
        public class Attribute
        {
            public string Name { get; set; }
        }
        private void getListOfAttributes()
        {
            MethodInfo[] methods = typeof(playFile).GetMethods();
            foreach(MethodInfo method in methods)
            {
                if(method.Name.StartsWith("getAttribute"))
                {
                    string attributeName = method.Name.Substring("getAttribute".Length);
                    attributeName = System.Text.RegularExpressions.Regex.Replace(attributeName,
                        @"\B[A-Z]", l => " " + l.ToString().ToLower());
                    playFileMethods.Add(attributeName, method);
                }
            }
        }
        private void analyzingAppWindow_Load(object sender, EventArgs e)
        {
            string[] games = { "ColorsGame", "ReflexGame", "ThingsGame" };

            foreach (DirectoryInfo d in (new DirectoryInfo(GAMES_DIR)).GetDirectories())
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
            fileViewer.ExpandAll();
        }
        private void readChildNodes(TreeNode t)
        {
            DirectoryInfo[] dirsInfo = (new DirectoryInfo(GAMES_DIR + @"\" + t.FullPath)).GetDirectories();

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
                FileInfo[] files = (new DirectoryInfo(GAMES_DIR + @"\" + @"\" + t.FullPath)).GetFiles();
                foreach (FileInfo f in files)
                {
                    t.Nodes.Add(f.Name);
                }
            }
        }

        private void attributesToChoose()
        {
            settingListOfAttributes(dataOriginal);
            List<Attribute> sortedList = dataOriginal.OrderBy(x => x.Name).ToList();
            dataOriginal = new BindingList<Attribute>(sortedList);
            this.listboxBase.DataSource = dataOriginal;
            this.listboxBase.DisplayMember = "Name";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var selectedItem = (Attribute)listboxBase.SelectedItem;

            for (int i = 0; i < listboxBase.Items.Count; i++)
            {
                if (listboxBase.GetSelected(i))
                {
                    dataToAdd.Add(new Attribute { Name = selectedItem.Name });

                    List<Attribute> sortedList = dataToAdd.OrderBy(x => x.Name).ToList();
                    dataToAdd = new BindingList<Attribute>(sortedList);

                    listboxToAdd.DataSource = dataToAdd;
                    listboxToAdd.DisplayMember = "Name";

                    int index = listboxBase.FindString(selectedItem.Name);
                    dataOriginal.RemoveAt(index);
                    this.listboxBase.DataSource = dataOriginal;
                }
            }
        }
        private void settingListOfAttributes(BindingList<Attribute> list)
        {
            foreach(var a in playFileMethods)
            {
                list.Add(new Attribute { Name = a.Key });
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            var selectedItem = (Attribute)listboxToAdd.SelectedItem;

            for (int i = 0; i < listboxToAdd.Items.Count; i++)
            {
                if (listboxToAdd.GetSelected(i))
                {
                    dataOriginal.Add(new Attribute { Name = selectedItem.Name });

                    List<Attribute> sortedList = dataOriginal.OrderBy(x => x.Name).ToList();
                    dataOriginal = new BindingList<Attribute>(sortedList);

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
                        if (pf.getFileValid() == false)
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
            List<Attribute> sortedList = dataOriginal.OrderBy(x => x.Name).ToList();
            dataOriginal = new BindingList<Attribute>(sortedList);
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
            List<Attribute> sortedList = dataToAdd.OrderBy(x => x.Name).ToList();
            dataToAdd = new BindingList<Attribute>(sortedList);
            listboxToAdd.DataSource = dataToAdd;
            listboxToAdd.DisplayMember = "Name";
        }

        private void fileViewer_AfterCheck(object sender, TreeViewEventArgs e)
        {
            bool c = e.Node.Checked;

            if (checkedTime.AddMilliseconds(200) < DateTime.Now)
            {
                checkingDown = c;
                checkedLevel = e.Node.Level;
                checkedTime = DateTime.Now;
                if (!checkingDown)
                {
                    if (e.Node.Parent != null)
                    {
                        e.Node.Parent.Checked = c;
                    }

                    foreach (TreeNode n in e.Node.Nodes)
                    {
                        n.Checked = c;
                    }
                }
            }

            if (checkingDown)
            {
                foreach (TreeNode n in e.Node.Nodes)
                {
                    n.Checked = c;
                }
            }
            else if (checkedLevel > e.Node.Level)
            {
                if (e.Node.Parent != null)
                {
                    e.Node.Parent.Checked = c;
                }
            }
            else if (checkedLevel < e.Node.Level)
            {
                foreach (TreeNode n in e.Node.Nodes)
                {
                    n.Checked = c;
                }
            }
        }
    }
}