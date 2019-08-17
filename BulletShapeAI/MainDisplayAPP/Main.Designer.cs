namespace MainDisplayAPP
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnVisitJs = new System.Windows.Forms.Button();
            this.picBoxChara = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCharaNumber = new System.Windows.Forms.TextBox();
            this.btnSelectModelFolder = new System.Windows.Forms.Button();
            this.txtFolderName = new System.Windows.Forms.TextBox();
            this.txtInitX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInitY = new System.Windows.Forms.TextBox();
            this.lblInitY = new System.Windows.Forms.Label();
            this.txtEndY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEndX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnInitGraph = new System.Windows.Forms.Button();
            this.lblSumModelNUM = new System.Windows.Forms.Label();
            this.picBoxGemmtry = new System.Windows.Forms.PictureBox();
            this.chkBoxMeshLine = new System.Windows.Forms.CheckBox();
            this.chkDisplayChara = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkboxDragCoffe = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.colorDefine1 = new MainDisplayAPP.ColorDefine();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxChara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxGemmtry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVisitJs
            // 
            this.btnVisitJs.Location = new System.Drawing.Point(888, 12);
            this.btnVisitJs.Name = "btnVisitJs";
            this.btnVisitJs.Size = new System.Drawing.Size(105, 23);
            this.btnVisitJs.TabIndex = 1;
            this.btnVisitJs.Text = "批量提取模型";
            this.btnVisitJs.UseVisualStyleBackColor = true;
            this.btnVisitJs.Click += new System.EventHandler(this.btnVisitJs_Click);
            // 
            // picBoxChara
            // 
            this.picBoxChara.Location = new System.Drawing.Point(582, 465);
            this.picBoxChara.Name = "picBoxChara";
            this.picBoxChara.Size = new System.Drawing.Size(670, 250);
            this.picBoxChara.TabIndex = 3;
            this.picBoxChara.TabStop = false;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 46);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(469, 703);
            this.treeView1.TabIndex = 5;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(542, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "特征提取数：";
            // 
            // txtCharaNumber
            // 
            this.txtCharaNumber.Location = new System.Drawing.Point(616, 56);
            this.txtCharaNumber.Name = "txtCharaNumber";
            this.txtCharaNumber.Size = new System.Drawing.Size(75, 21);
            this.txtCharaNumber.TabIndex = 7;
            this.txtCharaNumber.Text = "100";
            this.txtCharaNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCharaNumber_KeyUp);
            // 
            // btnSelectModelFolder
            // 
            this.btnSelectModelFolder.Location = new System.Drawing.Point(12, 12);
            this.btnSelectModelFolder.Name = "btnSelectModelFolder";
            this.btnSelectModelFolder.Size = new System.Drawing.Size(97, 23);
            this.btnSelectModelFolder.TabIndex = 8;
            this.btnSelectModelFolder.Text = "选择模型文件夹";
            this.btnSelectModelFolder.UseVisualStyleBackColor = true;
            this.btnSelectModelFolder.Click += new System.EventHandler(this.btnSelectModelFolder_Click);
            // 
            // txtFolderName
            // 
            this.txtFolderName.Location = new System.Drawing.Point(115, 14);
            this.txtFolderName.Name = "txtFolderName";
            this.txtFolderName.ReadOnly = true;
            this.txtFolderName.Size = new System.Drawing.Size(756, 21);
            this.txtFolderName.TabIndex = 9;
            // 
            // txtInitX
            // 
            this.txtInitX.Location = new System.Drawing.Point(616, 94);
            this.txtInitX.Name = "txtInitX";
            this.txtInitX.Size = new System.Drawing.Size(75, 21);
            this.txtInitX.TabIndex = 11;
            this.txtInitX.Text = "0";
            this.txtInitX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtInitX_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(513, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "区域初始点X(mm)：";
            // 
            // txtInitY
            // 
            this.txtInitY.Location = new System.Drawing.Point(816, 94);
            this.txtInitY.Name = "txtInitY";
            this.txtInitY.Size = new System.Drawing.Size(75, 21);
            this.txtInitY.TabIndex = 13;
            this.txtInitY.Text = "0";
            this.txtInitY.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtInitY_KeyUp);
            // 
            // lblInitY
            // 
            this.lblInitY.AutoSize = true;
            this.lblInitY.Location = new System.Drawing.Point(709, 97);
            this.lblInitY.Name = "lblInitY";
            this.lblInitY.Size = new System.Drawing.Size(107, 12);
            this.lblInitY.TabIndex = 12;
            this.lblInitY.Text = "区域初始点Y(mm)：";
            // 
            // txtEndY
            // 
            this.txtEndY.Location = new System.Drawing.Point(816, 131);
            this.txtEndY.Name = "txtEndY";
            this.txtEndY.Size = new System.Drawing.Size(75, 21);
            this.txtEndY.TabIndex = 17;
            this.txtEndY.Text = "10";
            this.txtEndY.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtEndY_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(709, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "区域对角点X(mm)：";
            // 
            // txtEndX
            // 
            this.txtEndX.Location = new System.Drawing.Point(616, 131);
            this.txtEndX.Name = "txtEndX";
            this.txtEndX.Size = new System.Drawing.Size(75, 21);
            this.txtEndX.TabIndex = 15;
            this.txtEndX.Text = "60";
            this.txtEndX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtEndX_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(513, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "区域对角点X(mm)：";
            // 
            // btnInitGraph
            // 
            this.btnInitGraph.Location = new System.Drawing.Point(1112, 52);
            this.btnInitGraph.Name = "btnInitGraph";
            this.btnInitGraph.Size = new System.Drawing.Size(105, 23);
            this.btnInitGraph.TabIndex = 18;
            this.btnInitGraph.Text = "图形区域初始化";
            this.btnInitGraph.UseVisualStyleBackColor = true;
            this.btnInitGraph.Click += new System.EventHandler(this.btnInitGraph_Click);
            // 
            // lblSumModelNUM
            // 
            this.lblSumModelNUM.AutoSize = true;
            this.lblSumModelNUM.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSumModelNUM.ForeColor = System.Drawing.Color.Red;
            this.lblSumModelNUM.Location = new System.Drawing.Point(602, 163);
            this.lblSumModelNUM.Name = "lblSumModelNUM";
            this.lblSumModelNUM.Size = new System.Drawing.Size(0, 16);
            this.lblSumModelNUM.TabIndex = 19;
            // 
            // picBoxGemmtry
            // 
            this.picBoxGemmtry.Location = new System.Drawing.Point(582, 200);
            this.picBoxGemmtry.Name = "picBoxGemmtry";
            this.picBoxGemmtry.Size = new System.Drawing.Size(670, 250);
            this.picBoxGemmtry.TabIndex = 20;
            this.picBoxGemmtry.TabStop = false;
            // 
            // chkBoxMeshLine
            // 
            this.chkBoxMeshLine.AutoSize = true;
            this.chkBoxMeshLine.Location = new System.Drawing.Point(1112, 93);
            this.chkBoxMeshLine.Name = "chkBoxMeshLine";
            this.chkBoxMeshLine.Size = new System.Drawing.Size(72, 16);
            this.chkBoxMeshLine.TabIndex = 21;
            this.chkBoxMeshLine.Text = "显示网格";
            this.chkBoxMeshLine.UseVisualStyleBackColor = true;
            this.chkBoxMeshLine.CheckedChanged += new System.EventHandler(this.chkBoxMeshLine_CheckedChanged);
            // 
            // chkDisplayChara
            // 
            this.chkDisplayChara.AutoSize = true;
            this.chkDisplayChara.Location = new System.Drawing.Point(957, 136);
            this.chkDisplayChara.Name = "chkDisplayChara";
            this.chkDisplayChara.Size = new System.Drawing.Size(132, 16);
            this.chkDisplayChara.TabIndex = 22;
            this.chkDisplayChara.Text = "显示模型特征点数据";
            this.chkDisplayChara.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(981, 54);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(50, 21);
            this.numericUpDown1.TabIndex = 23;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(814, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "近似模型阻力系数相差阈值：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(1037, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 16);
            this.label6.TabIndex = 25;
            this.label6.Text = "%";
            // 
            // chkboxDragCoffe
            // 
            this.chkboxDragCoffe.AutoSize = true;
            this.chkboxDragCoffe.Location = new System.Drawing.Point(957, 96);
            this.chkboxDragCoffe.Name = "chkboxDragCoffe";
            this.chkboxDragCoffe.Size = new System.Drawing.Size(96, 16);
            this.chkboxDragCoffe.TabIndex = 26;
            this.chkboxDragCoffe.Text = "突显系数阈值";
            this.chkboxDragCoffe.UseVisualStyleBackColor = true;
            this.chkboxDragCoffe.CheckedChanged += new System.EventHandler(this.chkboxDragCoffe_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(500, 303);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 27;
            this.label7.Text = "弹形轮廓";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(500, 568);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 28;
            this.label8.Text = "轮廓特征";
            // 
            // colorDefine1
            // 
            this.colorDefine1.FormattingEnabled = true;
            this.colorDefine1.Location = new System.Drawing.Point(1112, 131);
            this.colorDefine1.Name = "colorDefine1";
            this.colorDefine1.Size = new System.Drawing.Size(121, 20);
            this.colorDefine1.TabIndex = 29;
            this.colorDefine1.SelectedValueChanged += new System.EventHandler(this.colorDefine1_SelectedValueChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.colorDefine1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkboxDragCoffe);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.chkDisplayChara);
            this.Controls.Add(this.chkBoxMeshLine);
            this.Controls.Add(this.picBoxGemmtry);
            this.Controls.Add(this.lblSumModelNUM);
            this.Controls.Add(this.btnInitGraph);
            this.Controls.Add(this.txtEndY);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEndX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtInitY);
            this.Controls.Add(this.lblInitY);
            this.Controls.Add(this.txtInitX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFolderName);
            this.Controls.Add(this.btnSelectModelFolder);
            this.Controls.Add(this.txtCharaNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.picBoxChara);
            this.Controls.Add(this.btnVisitJs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "弹丸外形特征提取";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxChara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxGemmtry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnVisitJs;
        private System.Windows.Forms.PictureBox picBoxChara;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCharaNumber;
        private System.Windows.Forms.Button btnSelectModelFolder;
        private System.Windows.Forms.TextBox txtFolderName;
        private System.Windows.Forms.TextBox txtInitX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInitY;
        private System.Windows.Forms.Label lblInitY;
        private System.Windows.Forms.TextBox txtEndY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEndX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnInitGraph;
        private System.Windows.Forms.Label lblSumModelNUM;
        private System.Windows.Forms.PictureBox picBoxGemmtry;
        private System.Windows.Forms.CheckBox chkBoxMeshLine;
        private System.Windows.Forms.CheckBox chkDisplayChara;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkboxDragCoffe;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private ColorDefine colorDefine1;
    }
}

