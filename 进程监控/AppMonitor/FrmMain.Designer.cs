namespace AppMonitor
{
    partial class FrmMain
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            btnTest = new Button();
            groupBox1 = new GroupBox();
            mbDisplay = new UIMessageBox();
            groupBox2 = new GroupBox();
            label2 = new Label();
            labLast = new Label();
            dgView = new DataGridView();
            ColServerName = new DataGridViewTextBoxColumn();
            ColPath = new DataGridViewTextBoxColumn();
            ColMemory = new DataGridViewTextBoxColumn();
            ColCPU = new DataGridViewTextBoxColumn();
            ColState = new DataGridViewTextBoxColumn();
            ColDir = new DataGridViewButtonColumn();
            ColStart = new DataGridViewButtonColumn();
            ColRestart = new DataGridViewButtonColumn();
            groupBox3 = new GroupBox();
            label3 = new Label();
            nupSecond = new NumericUpDown();
            panel1 = new Panel();
            Btn_Connect = new Button();
            Btn_Disconnect = new Button();
            label1 = new Label();
            nupMemory = new NumericUpDown();
            nfIcon = new NotifyIcon(components);
            cmsIcon = new ContextMenuStrip(components);
            tsShow = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            tsExit = new ToolStripMenuItem();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgView).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nupSecond).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nupMemory).BeginInit();
            cmsIcon.SuspendLayout();
            SuspendLayout();
            // 
            // btnTest
            // 
            btnTest.Location = new Point(8, 25);
            btnTest.Margin = new Padding(5);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(125, 40);
            btnTest.TabIndex = 0;
            btnTest.Text = "刷新";
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Click += BtnTest_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(mbDisplay);
            groupBox1.Dock = DockStyle.Bottom;
            groupBox1.Location = new Point(0, 382);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(904, 204);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "                                ";
            // 
            // mbDisplay
            // 
            mbDisplay.Dock = DockStyle.Fill;
            mbDisplay.FlowButtnVisable = false;
            mbDisplay.Font = new Font("宋体", 10F);
            mbDisplay.Location = new Point(3, 25);
            mbDisplay.MaxRow = 50;
            mbDisplay.Name = "mbDisplay";
            mbDisplay.ShowError = true;
            mbDisplay.ShowLog = true;
            mbDisplay.ShowWarning = true;
            mbDisplay.Size = new Size(898, 176);
            mbDisplay.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(labLast);
            groupBox2.Controls.Add(dgView);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(904, 309);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "服务程序";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(102, 1);
            label2.Name = "label2";
            label2.Size = new Size(78, 21);
            label2.TabIndex = 6;
            label2.Text = "上次检查:";
            // 
            // labLast
            // 
            labLast.AutoSize = true;
            labLast.Location = new Point(187, 1);
            labLast.Name = "labLast";
            labLast.Size = new Size(15, 21);
            labLast.TabIndex = 5;
            labLast.Text = " ";
            // 
            // dgView
            // 
            dgView.AllowUserToAddRows = false;
            dgView.AllowUserToDeleteRows = false;
            dgView.AllowUserToOrderColumns = true;
            dgView.AllowUserToResizeRows = false;
            dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgView.Columns.AddRange(new DataGridViewColumn[] { ColServerName, ColPath, ColMemory, ColCPU, ColState, ColDir, ColStart, ColRestart });
            dgView.Dock = DockStyle.Fill;
            dgView.EditMode = DataGridViewEditMode.EditOnEnter;
            dgView.Location = new Point(3, 25);
            dgView.Name = "dgView";
            dgView.ReadOnly = true;
            dgView.RowHeadersVisible = false;
            dgView.RowHeadersWidth = 5;
            dgView.RowTemplate.Height = 23;
            dgView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgView.Size = new Size(898, 281);
            dgView.TabIndex = 1;
            dgView.CellContentClick += DgView_CellContentClick;
            // 
            // ColServerName
            // 
            ColServerName.DataPropertyName = "Name";
            ColServerName.FillWeight = 75.21151F;
            ColServerName.HeaderText = "服务名";
            ColServerName.Name = "ColServerName";
            ColServerName.ReadOnly = true;
            // 
            // ColPath
            // 
            ColPath.DataPropertyName = "Path";
            ColPath.FillWeight = 75.21151F;
            ColPath.HeaderText = "主路径";
            ColPath.Name = "ColPath";
            ColPath.ReadOnly = true;
            // 
            // ColMemory
            // 
            ColMemory.DataPropertyName = "UseMemoryText";
            ColMemory.FillWeight = 75.21151F;
            ColMemory.HeaderText = "内存";
            ColMemory.Name = "ColMemory";
            ColMemory.ReadOnly = true;
            // 
            // ColCPU
            // 
            ColCPU.DataPropertyName = "UseCPU";
            ColCPU.FillWeight = 75.21151F;
            ColCPU.HeaderText = "CPU";
            ColCPU.Name = "ColCPU";
            ColCPU.ReadOnly = true;
            // 
            // ColState
            // 
            ColState.DataPropertyName = "StateText";
            ColState.FillWeight = 75.21151F;
            ColState.HeaderText = "状态";
            ColState.Name = "ColState";
            ColState.ReadOnly = true;
            // 
            // ColDir
            // 
            ColDir.FillWeight = 47.60575F;
            ColDir.HeaderText = "";
            ColDir.Name = "ColDir";
            ColDir.ReadOnly = true;
            ColDir.Text = "文件夹";
            ColDir.UseColumnTextForButtonValue = true;
            // 
            // ColStart
            // 
            ColStart.FillWeight = 37.60575F;
            ColStart.HeaderText = "";
            ColStart.Name = "ColStart";
            ColStart.ReadOnly = true;
            ColStart.Resizable = DataGridViewTriState.True;
            ColStart.SortMode = DataGridViewColumnSortMode.Automatic;
            ColStart.Text = "打开";
            ColStart.UseColumnTextForButtonValue = true;
            // 
            // ColRestart
            // 
            ColRestart.FillWeight = 37.60575F;
            ColRestart.HeaderText = "";
            ColRestart.Name = "ColRestart";
            ColRestart.ReadOnly = true;
            ColRestart.Text = "重启";
            ColRestart.UseColumnTextForButtonValue = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(nupSecond);
            groupBox3.Controls.Add(panel1);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(nupMemory);
            groupBox3.Controls.Add(btnTest);
            groupBox3.Dock = DockStyle.Bottom;
            groupBox3.Location = new Point(0, 309);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(904, 73);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "                                ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(471, 35);
            label3.Name = "label3";
            label3.Size = new Size(78, 21);
            label3.TabIndex = 7;
            label3.Text = "刷新秒数:";
            // 
            // nupSecond
            // 
            nupSecond.Location = new Point(555, 33);
            nupSecond.Maximum = new decimal(new int[] { 3600, 0, 0, 0 });
            nupSecond.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            nupSecond.Name = "nupSecond";
            nupSecond.Size = new Size(74, 29);
            nupSecond.TabIndex = 6;
            nupSecond.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // panel1
            // 
            panel1.Controls.Add(Btn_Connect);
            panel1.Controls.Add(Btn_Disconnect);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(635, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(266, 45);
            panel1.TabIndex = 5;
            // 
            // Btn_Connect
            // 
            Btn_Connect.Location = new Point(5, 0);
            Btn_Connect.Margin = new Padding(5);
            Btn_Connect.Name = "Btn_Connect";
            Btn_Connect.Size = new Size(125, 40);
            Btn_Connect.TabIndex = 1;
            Btn_Connect.Text = "开启监控";
            Btn_Connect.UseVisualStyleBackColor = true;
            Btn_Connect.Click += Btn_Connect_Click;
            // 
            // Btn_Disconnect
            // 
            Btn_Disconnect.Enabled = false;
            Btn_Disconnect.Location = new Point(140, 0);
            Btn_Disconnect.Margin = new Padding(5);
            Btn_Disconnect.Name = "Btn_Disconnect";
            Btn_Disconnect.Size = new Size(125, 40);
            Btn_Disconnect.TabIndex = 2;
            Btn_Disconnect.Text = "停止监控";
            Btn_Disconnect.UseVisualStyleBackColor = true;
            Btn_Disconnect.Click += Btn_Disconnect_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(136, 35);
            label1.Name = "label1";
            label1.Size = new Size(120, 21);
            label1.TabIndex = 4;
            label1.Text = "重启内存数:MB";
            // 
            // nupMemory
            // 
            nupMemory.Location = new Point(262, 33);
            nupMemory.Name = "nupMemory";
            nupMemory.Size = new Size(120, 29);
            nupMemory.TabIndex = 3;
            // 
            // nfIcon
            // 
            nfIcon.ContextMenuStrip = cmsIcon;
            nfIcon.Icon = (Icon)resources.GetObject("nfIcon.Icon");
            nfIcon.Text = "服务监控";
            nfIcon.Visible = true;
            // 
            // cmsIcon
            // 
            cmsIcon.Items.AddRange(new ToolStripItem[] { tsShow, toolStripMenuItem2, tsExit });
            cmsIcon.Name = "cmsIcon";
            cmsIcon.Size = new Size(101, 54);
            // 
            // tsShow
            // 
            tsShow.Name = "tsShow";
            tsShow.Size = new Size(100, 22);
            tsShow.Text = "打开";
            tsShow.Click += tsShow_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(97, 6);
            // 
            // tsExit
            // 
            tsExit.Name = "tsExit";
            tsExit.Size = new Size(100, 22);
            tsExit.Text = "退出";
            tsExit.Click += tsExit_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(904, 586);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Font = new Font("微软雅黑", 12F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5);
            Name = "FrmMain";
            Text = "服务监控";
            Deactivate += FrmMain_Deactivate;
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgView).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nupSecond).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nupMemory).EndInit();
            cmsIcon.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgView;
        private UIMessageBox mbDisplay;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NotifyIcon nfIcon;
        private System.Windows.Forms.Button Btn_Disconnect;
        private System.Windows.Forms.Button Btn_Connect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nupMemory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColServerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMemory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCPU;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColState;
        private System.Windows.Forms.DataGridViewButtonColumn ColDir;
        private System.Windows.Forms.DataGridViewButtonColumn ColStart;
        private System.Windows.Forms.DataGridViewButtonColumn ColRestart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labLast;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nupSecond;
        private System.Windows.Forms.Panel panel1;
        private ContextMenuStrip cmsIcon;
        private ToolStripMenuItem tsShow;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem tsExit;
    }
}
