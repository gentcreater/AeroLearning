using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;
using System.IO;
using Microsoft.Win32;

namespace MainDisplayAPP
{
    //[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    //[System.Runtime.InteropServices.ComVisible(true)]
    public partial class Main : Form
    {
        //Boolean IsFirst = true;
        //Boolean IsGraphInit = false;
        JSengin visitJs;
        graph2D graph;
       
        public Main()
        {
            InitializeComponent();
            this.txtFolderName.Text = ReadWriteRegist(string.Empty);
            btnInitGraph_Click(btnInitGraph, new EventArgs());
        }

        private void btnVisitJs_Click(object sender, EventArgs e)
        {
            try
            {
                int charaNum = Convert.ToInt16(txtCharaNumber.Text.Trim());
                double initX = Convert.ToDouble(txtInitX.Text.Trim());
                double initY = Convert.ToDouble(txtInitY.Text.Trim());
                double endX = Convert.ToDouble(txtEndX.Text.Trim());
                double endY = Convert.ToDouble(txtEndY.Text.Trim());                

                visitJs = new JSengin(txtFolderName.Text.Trim(), charaNum, new EndPoint(initX, initY), new EndPoint(endX, endY));

                FillTreeView(visitJs);

            }
            catch (Exception ex)
            {
                new ShowException(ex.Message);
            }
        }
        private void FillTreeView(JSengin JS)
        {
            this.treeView1.Nodes.Clear();
            int SumModelNum = 0;
            try
            {
                //将获取的JS模型灌入TreeView
                this.treeView1.LabelEdit = true;
                this.treeView1.ShowNodeToolTips = true;
                foreach (string strPath in JS.SubJsPaths)
                {
                    TreeNode node = new TreeNode();
                    List<string> jsfiles = new List<string>();
                    jsfiles = JS.JsFiles[JS.SubJsPaths.IndexOf(strPath)];
                    List<Model> models = new List<Model>();
                    models = JS.ModelsSet[JS.SubJsPaths.IndexOf(strPath)];
                    //foreach (string strfile in jsfiles)
                    foreach(Model mo in models)
                    {
                        TreeNode nf = new TreeNode();
                        nf.Text = mo.modelName;
                        nf.ToolTipText = mo.modelNotes;
                        node.Nodes.Add(nf);
                    }
                    node.Text = Path.GetFileNameWithoutExtension(strPath);
                    node.ToolTipText = strPath+"\n共"+ node.GetNodeCount(true).ToString()+"个模型";
                    this.treeView1.Nodes.Add(node);
                    SumModelNum += node.GetNodeCount(true);
                }
                this.lblSumModelNUM.Text = "按" + txtCharaNumber.Text + "个特征粒度，共成功导入" + SumModelNum.ToString() + "个模型";
            }
            catch (Exception ex)
            {
                new ShowException(ex.Message);
            }           
        }
        private string ReadWriteRegist(string path)
        {
            try
            {
                RegistryKey software = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);        //打开注册表中的software 
                RegistryKey ReadKey = software.OpenSubKey("FolderPath", true);   // 打开自定义的文件目录项
                if (ReadKey == null)
                {
                    ReadKey = software.CreateSubKey("FolderPath");  //不存在则新建
                    ReadKey.SetValue("OpenFolderDir", path);   //写入文件目录
                    ReadKey.Close();
                    Registry.CurrentUser.Close();
                }
                else
                {
                    if (path == string.Empty)
                    {
                        return ReadKey.GetValue("OpenFolderDir").ToString();
                    }
                    else
                    {
                        ReadKey.SetValue("OpenFolderDir", folderBrowserDialog1.SelectedPath);
                        ReadKey.Close();
                        Registry.CurrentUser.Close();
                    }
                }
                return path;
            }
            catch (Exception ex)
            {
                new ShowException(ex.Message);
                return string.Empty;
            }
        }

        private void btnSelectModelFolder_Click(object sender, EventArgs e)
        {
            //folder控件描述Environment.SpecialFolder.Desktop;
            folderBrowserDialog1.Description = "请选择一个包含JS格式的弹形模型文件夹：";
            string Historypath = ReadWriteRegist(string.Empty);
            if (Historypath == string.Empty)
            {
                //指定folder根=桌面
                folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
            }
            else
            {
                folderBrowserDialog1.SelectedPath = Historypath;
            }
            //是否添加新建文件夹的按钮
            folderBrowserDialog1.ShowNewFolderButton = true;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                //将当前打开的目录存入注册表,并显示在界面
                txtFolderName.Text = ReadWriteRegist(folderBrowserDialog1.SelectedPath);                
                
                //遍历选择目录下所有子目录和文件，并使用目录树VIEW控件显示
            }
        }

        private void btnInitGraph_Click(object sender, EventArgs e)
        {
            graph = new graph2D(this.picBoxChara.Width, this.picBoxChara.Height, "弹形轮廓特征提取示意图", "弹形轮廓原图", 10, this.chkBoxMeshLine.Checked, this.colorDefine1.SelectColor);

            if (this.picBoxChara.Image != null) this.picBoxChara.Image.Dispose();
            if (this.picBoxGemmtry.Image != null) this.picBoxGemmtry.Image.Dispose();
            this.picBoxChara.Image = graph.img;
            this.picBoxChara.Show();
            this.picBoxChara.Refresh();

            this.picBoxGemmtry.Image = graph.imgVector;
            this.picBoxGemmtry.Show();
            this.picBoxGemmtry.Refresh();
        }

        private void txtCharaNumber_KeyUp(object sender, KeyEventArgs e)
        {
            int tmp;
            if (!int.TryParse(txtCharaNumber.Text.Trim(), out tmp))
            {
                new ShowException("特征数文本框未正确输入数字");
            }
        }

        private void txtInitX_KeyUp(object sender, KeyEventArgs e)
        {
            int tmp;
            if (!int.TryParse(txtInitX.Text.Trim(), out tmp))
            {
                new ShowException("初始点X文本框未正确输入数字");
            }
        }

        private void txtInitY_KeyUp(object sender, KeyEventArgs e)
        {
            int tmp;
            if (!int.TryParse(txtInitY.Text.Trim(), out tmp))
            {
                new ShowException("初始点Y文本框未正确输入数字");
            }
        }

        private void txtEndX_KeyUp(object sender, KeyEventArgs e)
        {
            int tmp;
            if (!int.TryParse(txtEndX.Text.Trim(), out tmp))
            {
                new ShowException("对焦点X文本框未正确输入数字");
            }
        }

        private void txtEndY_KeyUp(object sender, KeyEventArgs e)
        {
            int tmp;
            if (!int.TryParse(txtEndY.Text.Trim(), out tmp))
            {
                new ShowException("对角点Y文本框未正确输入数字");
            }
        }

        private void chkBoxMeshLine_CheckedChanged(object sender, EventArgs e)
        {
            if (this.picBoxChara.Image != null)
            {
                //graph = new graph2D(this.picBoxChara.Width, this.picBoxChara.Height, "弹形轮廓特征提取示意图", 10, this.chkBoxMeshLine.Checked);
                graph.IsMeshLine = this.chkBoxMeshLine.Checked;
                if (this.picBoxChara.Image != null) this.picBoxChara.Image.Dispose();
                this.picBoxChara.Image = graph.img;
                this.picBoxChara.Show();
                this.picBoxChara.Refresh();
            }            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectNode = this.treeView1.SelectedNode;
            if (selectNode != null)
            {
                if (selectNode.Text.Contains(".js"))
                {
                    graph.TitleANDmodel = selectNode.Text;
                    string strpath = selectNode.Parent.ToolTipText.Substring(0, selectNode.Parent.ToolTipText.IndexOf("\n"));
                    int i = this.visitJs.SubJsPaths.IndexOf(strpath);
                    int j;
                    if (selectNode.Text.Contains("有弧含双值点"))
                    {
                        j = this.visitJs.JsFiles[i].IndexOf(selectNode.Text.Substring(0, selectNode.Text.IndexOf("有弧含双值点")));
                    }
                    else
                    {
                        j = this.visitJs.JsFiles[i].IndexOf(selectNode.Text);
                    }
                    if(graph!=null)
                    {
                        //graph.PointColor = this.colorDefine1.SelectColor;
                        graph.Points = this.visitJs.ModelsSet[i][j].characterSet;
                        if (this.picBoxChara.Image != null) this.picBoxChara.Image.Dispose();
                        this.picBoxChara.Image = graph.img;
                        this.picBoxChara.Show();
                        this.picBoxChara.Refresh();
                        if (this.chkDisplayChara.Checked)
                        {
                            new ShowException(selectNode.Text, graph.displayAllPoints, true);
                        }
                        graph.VectorEdges = this.visitJs.ModelsSet[i][j].edges;
                        if (this.picBoxGemmtry.Image != null) this.picBoxGemmtry.Image.Dispose();
                        this.picBoxGemmtry.Image = graph.imgVector;
                        this.picBoxGemmtry.Show();
                        this.picBoxGemmtry.Refresh();
                    }
                }
            }
        }
        /// <summary>
        /// 近似模型阻力系数差值百分比阈值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (this.chkboxDragCoffe.Checked)
            {
                foreach (TreeNode node in this.treeView1.Nodes)
                {
                    foreach (TreeNode n in node.Nodes)
                    {
                        n.BackColor = treeView1.BackColor;
                    }
                    SetTreeNodeDragCoffeDiffValue(Color.Red);
                }
            }
        }

        private void SetTreeNodeDragCoffeDiffValue(Color nodebackColor)
        {
            foreach (TreeNode node in this.treeView1.Nodes)
            {
                foreach (TreeNode n in node.Nodes)
                {
                    string str = n.Text.Substring(0,n.Text.IndexOf("cd"));
                    foreach(TreeNode nn in node.Nodes)
                    {
                        if (nn.Text.Contains(str) && node.Nodes.IndexOf(nn) != node.Nodes.IndexOf(n))
                        {
                            double dragcoffe_n = Convert.ToDouble(n.Text.Substring(n.Text.IndexOf("_cd") + 3, n.Text.IndexOf(".js") - n.Text.IndexOf("_cd") - 3));
                            double dragcoffe_nn = Convert.ToDouble(nn.Text.Substring(nn.Text.IndexOf("_cd") + 3, nn.Text.IndexOf(".js") - nn.Text.IndexOf("_cd") - 3));
                            double min = Math.Min(dragcoffe_n, dragcoffe_nn);
                            if (Math.Abs(dragcoffe_n - dragcoffe_nn) * 100 / min > Convert.ToDouble(this.numericUpDown1.Value))
                            {
                                n.BackColor = nodebackColor;
                                nn.BackColor = nodebackColor;
                            }
                        }
                    }        
                }
            }
        }

        private void chkboxDragCoffe_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkboxDragCoffe.Checked) SetTreeNodeDragCoffeDiffValue(Color.Red);
            else
            {
                foreach (TreeNode node in this.treeView1.Nodes)
                {
                    foreach (TreeNode n in node.Nodes)
                    {
                        n.BackColor = treeView1.BackColor;
                    }
                }
            }
        }

        private void colorDefine1_SelectedValueChanged(object sender, EventArgs e)
        {
            btnInitGraph_Click(btnInitGraph, new EventArgs());
            treeView1_AfterSelect(treeView1, new TreeViewEventArgs(this.treeView1.SelectedNode));
        }
    }
}
