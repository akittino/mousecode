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
    public partial class AdminPanelAnalyzator : Form
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.StartupPath);
        public AdminPanelAnalyzator()
        {
            InitializeComponent();
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
    }
}
