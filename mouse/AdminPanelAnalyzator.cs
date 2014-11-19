using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mysz
{
    public partial class AdminPanelAnalyzator : MouseForm
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.StartupPath);
        Pen bluePen, greenPen;
        Graphics graphics;
        public AdminPanelAnalyzator()
        {
            InitializeComponent();
            bluePen = new Pen(Color.Blue, 2f);
            greenPen = new Pen(Color.Green, 2f);
            graphics = coordinatesViewer.CreateGraphics();
            SetMouseForm(coordinatesViewer, coordinatesViewer.Width, coordinatesViewer.Height, null);
        }

        private void AdminPanelAnalyzator_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(directoryInfo.ToString()))
            {
                int tmp = 0;
                DirectoryInfo[] gameDirectories = directoryInfo.GetDirectories();
                DirectoryInfo[] userDirectories = null;
                DirectoryInfo[] dateDirectories = null;
                DirectoryInfo[] gameIdDirectories = null;
                DirectoryInfo[] coordinatesDirectories = null;
                FileInfo[] files = null;

                fileViewer.CheckBoxes = true;


                if (gameDirectories.Length > 0)
                {
                    foreach (var d in gameDirectories)
                    {
                        TreeNode node = fileViewer.Nodes.Add(d.Name);
                        userDirectories = d.GetDirectories();
                        if (userDirectories.Length > 0)
                        {
                            for (int i = 0; i < userDirectories.Length; i++)
                            {
                                TreeNode nodeGameChild = fileViewer.Nodes[tmp].Nodes.Add(userDirectories[i].Name);
                                dateDirectories = userDirectories[i].GetDirectories();
                                if (dateDirectories.Length > 0)
                                {
                                    for (int j = 0; j < dateDirectories.Length; j++)
                                    {
                                        TreeNode nodeUserChild = fileViewer.Nodes[tmp].Nodes[i].Nodes.Add(dateDirectories[j].Name);
                                        gameIdDirectories = dateDirectories[j].GetDirectories();
                                        if (gameIdDirectories.Length > 0)
                                        {
                                            for (int k = 0; k < gameIdDirectories.Length; k++)
                                            {
                                                TreeNode nodeDateChild = fileViewer.Nodes[tmp].Nodes[i].Nodes[j].Nodes.Add(gameIdDirectories[k].Name);
                                                coordinatesDirectories = gameIdDirectories[k].GetDirectories();
                                                if (coordinatesDirectories.Length > 0)
                                                {
                                                    for (int n = 0; n < coordinatesDirectories.Length; n++)
                                                    {
                                                        TreeNode nodeGameIdChild = fileViewer.Nodes[tmp].Nodes[i].Nodes[j].Nodes[k].Nodes.Add(coordinatesDirectories[n].Name);
                                                        files = coordinatesDirectories[n].GetFiles();
                                                        if (files.Length > 0)
                                                        {
                                                            for (int m = 0; m < files.Length; m++)
                                                            {
                                                                TreeNode nodeCoordinatesChild = fileViewer.Nodes[tmp].Nodes[i].Nodes[j].Nodes[k].Nodes[n].Nodes.Add(files[m].Name);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        tmp++;
                    }

                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Bitmap clearBitmap = new Bitmap(coordinatesViewer.Width, coordinatesViewer.Height);
            coordinatesViewer.Image = clearBitmap;
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            printAllChecked();
        }

        private void readFileAndDraw(string path, Pen pen)
        {
            if (path.Split('.')[path.Split('.').Length - 1] != "csv")
            {
                //MessageBox.Show("You should select csv file");
                return;
            }
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
        private void printAllChecked()
        {
            foreach (TreeNode a in fileViewer.Nodes)
            {
                foreach (TreeNode b in a.Nodes)
                {
                    foreach (TreeNode c in b.Nodes)
                    {
                        foreach (TreeNode d in c.Nodes)
                        {
                            foreach (TreeNode f in d.Nodes)
                            {
                                foreach (TreeNode g in f.Nodes)
                                {
                                    if (g.Checked) 
                                        readFileAndDraw(Path.GetFullPath(".") + @"\" + g.FullPath, bluePen);
                                }
                                if (f.Checked)
                                    f.Expand();
                            }
                            if (d.Checked)
                                d.Expand();
                        }
                        if (c.Checked)
                            c.Expand();
                    }
                    if (b.Checked)
                        b.Expand();
                }
                if (a.Checked)
                    a.Expand();
            }

            readFileAndDraw(Path.GetFullPath(".") + @"\" + fileViewer.SelectedNode.FullPath, greenPen);
            //TODO thread in background that check selection and rewrite lines 
        }

        private void fileViewer_AfterCheck(object sender, TreeViewEventArgs e)
        {
            bool c = e.Node.Checked;
            foreach (TreeNode n in e.Node.Nodes)
            {
                n.Checked = c;
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
    }
}
