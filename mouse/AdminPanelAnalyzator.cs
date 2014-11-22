using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace mysz
{
    public partial class AdminPanelAnalyzator : MouseForm
    {
        readonly Color BACKGROUND_COLOR = Color.Black;

        Pen bluePen, yellowPen;
        Graphics graphics;

        TreeNode lastSelected;
        DateTime checkedTime;
        bool checkingDown;
        int checkedLevel;
        Thread refreshThread;

        public AdminPanelAnalyzator()
        {
            InitializeComponent();
            bluePen = new Pen(Color.Blue, 2f);
            yellowPen = new Pen(Color.Yellow, 2f);
            graphics = coordinatesViewer.CreateGraphics();
            SetMouseForm(coordinatesViewer, coordinatesViewer.Width, coordinatesViewer.Height, null);
            checkedTime = DateTime.Now;
            checkingDown = false;
            checkedLevel = 0;
        }

        private void AdminPanelAnalyzator_Load(object sender, EventArgs e)
        {
            string [] games = {"ColorsGame", "ReflexGame", "ThingsGame"};

            fileViewer.CheckBoxes = true;

            foreach (DirectoryInfo d in (new DirectoryInfo(Application.StartupPath)).GetDirectories())
            {
                foreach(string g in games)
                {
                    if(d.Name.Equals(g))
                    {
                        TreeNode t = fileViewer.Nodes.Add(d.Name);
                        readChildNodes(t);
                    }
                }
            }

            fileViewer.ExpandAll();
        }

        private void readChildNodes(TreeNode t)
        {
            DirectoryInfo[] dirsInfo = (new DirectoryInfo(Application.StartupPath + @"\" + t.FullPath)).GetDirectories();

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
                FileInfo[] files = (new DirectoryInfo(Application.StartupPath + @"\" + t.FullPath)).GetFiles();

                foreach(FileInfo f in files)
                {
                    t.Nodes.Add(f.Name);
                }
            }
        }

        private void readFileAndDraw(string path, Pen pen)
        {
            if (path.Split('.')[path.Split('.').Length - 1] != "csv")
            {
                //MessageBox.Show("You should select csv file");
                return;
            }

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    int linesToSkip = 2;
                    if (path.Split('\\')[path.Split('\\').Length - 6] == "ReflexGame")
                        linesToSkip = 1;

                    while (linesToSkip-- != 0)
                        sr.ReadLine();

                    List<Point> coordsList = new List<Point>();

                    string s = sr.ReadLine();
                    while (!string.IsNullOrEmpty(s))
                    {
                        coordsList.Add(new Point(int.Parse(s.Split(',')[0]), int.Parse(s.Split(',')[1])));
                        s = sr.ReadLine();
                    }

                    drawMouseTrace(coordsList, pen);
                }
            }
            catch(IOException e)
            {
                MessageBox.Show("Please close all games files when using this analyzer!");
            }
        }

        private void printChecked()
        {
            foreach(TreeNode t in fileViewer.Nodes)
            {
                drawCheckedChildNodes(t);
            }
        }

        private void drawCheckedChildNodes (TreeNode t)
        {
            if (t.FullPath.Split('.')[t.FullPath.Split('.').Length - 1] != "csv")
            {
                foreach(TreeNode child in t.Nodes)
                {
                    drawCheckedChildNodes(child);
                }
            }
            else
            {
                if (t.Checked)
                {
                    fileViewer.BeginInvoke((MethodInvoker)delegate 
                    { 
                        readFileAndDraw(Path.GetFullPath(".") + @"\" + t.FullPath, bluePen);
                    });
                }
            }

        }

        private void waitBeforeRefresh()
        {
            Thread.Sleep(200);
            graphics.Clear(BACKGROUND_COLOR);
            printChecked();
            fileViewer.BeginInvoke((MethodInvoker)delegate
            {
                fileViewer.SelectedNode = null;
            });
        }

        private void fileViewer_AfterCheck(object sender, TreeViewEventArgs e)
        {
            bool c = e.Node.Checked;

            if (checkedTime.AddMilliseconds(200) < DateTime.Now)
            {
                refreshThread = new Thread(waitBeforeRefresh);
                refreshThread.Start();
                checkingDown = c;
                checkedLevel = e.Node.Level;
                checkedTime = DateTime.Now;
                if(!checkingDown)
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

        private void drawMouseTrace(List<Point> coordsList, Pen pen)
        {
            if (coordsList.Count < 2)
                return;

            graphics.DrawEllipse(pen, coordsList[0].X - 1, coordsList[0].Y - 1, 2, 2);
            
            for (int i = 1; i < coordsList.Count; i++)
            {
                graphics.DrawLine(pen, coordsList[i - 1], coordsList[i]);
                graphics.DrawEllipse(pen, coordsList[i].X - 1, coordsList[i].Y - 1, 2, 2);
            }
        }

        private void fileViewer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text.Length < 5 || e.Node.Text.Substring(e.Node.Text.Length - 4) != ".csv")
            {
                e = null;
            }

            if(lastSelected != null )
            {
                if (lastSelected.Checked == true)
                {
                    readFileAndDraw(Path.GetFullPath(".") + @"\" + lastSelected.FullPath, bluePen);
                }
                else
                {
                    graphics.Clear(BACKGROUND_COLOR);
                    printChecked();
                }
            }
            if (e != null)
            {
                readFileAndDraw(Path.GetFullPath(".") + @"\" + e.Node.FullPath, yellowPen);
                lastSelected = e.Node;
            }
            else
            {
                lastSelected = null;
            }
            
        }

        private void AdminPanelAnalyzator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(refreshThread != null && refreshThread.IsAlive)
            {
                refreshThread.Abort();
            }
        }
    }
}
//TODO files validate
//TODO add bitmap click to get play reading