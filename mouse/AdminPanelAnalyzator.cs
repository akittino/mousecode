using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace mysz
{
    public partial class AdminPanelAnalyzator : Form
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.StartupPath);
        public const int TVIF_STATE = 0x8;
        public const int TVIS_STATEIMAGEMASK = 0xF000;
        public const int TV_FIRST = 0x1100;
        public const int TVM_SETITEM = TV_FIRST + 63;

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam); 
        public AdminPanelAnalyzator()
        {
            InitializeComponent();

        }
        public struct TVITEM
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            [MarshalAs(UnmanagedType.LPTStr)]
            public String lpszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;

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
                DirectoryInfo[] coordinatesDirectories = null;
                FileInfo[] files = null;
                treeView1.CheckBoxes = true;
                treeView1.DrawMode = TreeViewDrawMode.OwnerDrawAll;
                
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
                                                coordinatesDirectories = gameIdDirectories[k].GetDirectories();
                                                if (coordinatesDirectories.Length > 0)
                                                {
                                                    for (int n = 0; n < coordinatesDirectories.Length; n++)
                                                    {
                                                        TreeNode nodeGameIdChild = treeView1.Nodes[tmp].Nodes[i].Nodes[j].Nodes[k].Nodes.Add(coordinatesDirectories[n].Name);
                                                        files = coordinatesDirectories[n].GetFiles();
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

        private void button2_Click(object sender, EventArgs e)
        {
            picture_box.InitialImage = null;
        }

        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node.Level == 0 || e.Node.Level == 1 || e.Node.Level == 2)
                HideCheckBox(e.Node);
            e.DrawDefault = true;
        }
        
        private void HideCheckBox(TreeNode node)
        {
            TVITEM tvi = new TVITEM();
            tvi.hItem = node.Handle;
            tvi.mask = TVIF_STATE;
            tvi.stateMask = TVIS_STATEIMAGEMASK;
            tvi.state = 0;
            IntPtr lparam = Marshal.AllocHGlobal(Marshal.SizeOf(tvi));
            Marshal.StructureToPtr(tvi, lparam, false);
            SendMessage(this.treeView1.Handle, TVM_SETITEM, IntPtr.Zero, lparam);
        }
}}
