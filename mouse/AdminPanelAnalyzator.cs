﻿using System;
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
            if(Directory.Exists(directoryInfo.ToString()))
            { 
                int tmp=0;
                DirectoryInfo[] gameDirectories = directoryInfo.GetDirectories();
                DirectoryInfo[] userDirectories = null;
                DirectoryInfo[] dateDirectories = null;
                DirectoryInfo[] gameIdDirectories = null;
                DirectoryInfo[] lCoordinatesDirectories = null;
                DirectoryInfo[] rCoordinatesDirectories = null;
                FileInfo[] files = null;


                
                if(gameDirectories.Length >0)
                {
                    foreach (var d in gameDirectories)
                    {
                        TreeNode node = treeView1.Nodes.Add(d.Name);
                        userDirectories = d.GetDirectories();
                        if(userDirectories.Length>0)
                        {
                            for(int i=0;i<userDirectories.Length;i++)
                            {
                                TreeNode nodeGameChild = treeView1.Nodes[tmp].Nodes.Add(userDirectories[i].Name);
                                dateDirectories = userDirectories[i].GetDirectories();
                                if (dateDirectories.Length > 0)
                                {
                                    for (int j = 0; j < dateDirectories.Length; j++)
                                    {
                                        TreeNode nodeUserChild = treeView1.Nodes[tmp].Nodes[i].Nodes.Add(dateDirectories[j].Name);
                                        gameIdDirectories = dateDirectories[j].GetDirectories();
                                        if (gameIdDirectories.Length > 0)
                                        {
                                            for (int k = 0; k < gameIdDirectories.Length; k++)
                                            {
                                                TreeNode nodeDateChild = treeView1.Nodes[tmp].Nodes[i].Nodes[j].Nodes.Add(gameIdDirectories[k].Name);
                                                lCoordinatesDirectories = gameIdDirectories[k].GetDirectories();
                                                if (lCoordinatesDirectories.Length > 0)
                                                {
                                                    for (int n = 0; n < lCoordinatesDirectories.Length; n++)
                                                    {
                                                        TreeNode nodeGameIdChild = treeView1.Nodes[tmp].Nodes[i].Nodes[j].Nodes[k].Nodes.Add(lCoordinatesDirectories[n].Name);
                                                        files = lCoordinatesDirectories[n].GetFiles();
                                                        if (files.Length > 0)
                                                        {
                                                            for (int m = 0; m < files.Length; m++)
                                                            {
                                                                TreeNode nodeCoordinatesChild = treeView1.Nodes[tmp].Nodes[i].Nodes[j].Nodes[k].Nodes[n].Nodes.Add(files[m].Name);
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
}}