namespace ScanLan
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.gpScan = new System.Windows.Forms.GroupBox();
            this.cmbSpeed = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbIP = new System.Windows.Forms.ComboBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtEnd = new LC.Library.Controls.IPBox();
            this.txtStar = new LC.Library.Controls.IPBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgMembers = new System.Windows.Forms.DataGridView();
            this.ColIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ping主机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看共享ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.唤醒ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCreateSnap = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCreateSnapPing = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAddToLis = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsClear = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gvLis = new System.Windows.Forms.DataGridView();
            this.ColLisName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLisMAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmLisItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsEditLis = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLisDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLisStop = new System.Windows.Forms.Button();
            this.btnLisStart = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.nupLisPort = new System.Windows.Forms.NumericUpDown();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnPing = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.satProcess = new System.Windows.Forms.StatusStrip();
            this.tspbScan = new System.Windows.Forms.ToolStripProgressBar();
            this.tsProcess = new System.Windows.Forms.ToolStripStatusLabel();
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.gpScan.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMembers)).BeginInit();
            this.cmItems.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLis)).BeginInit();
            this.cmLisItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupLisPort)).BeginInit();
            this.satProcess.SuspendLayout();
            this.msMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpScan
            // 
            this.gpScan.Controls.Add(this.cmbSpeed);
            this.gpScan.Controls.Add(this.label4);
            this.gpScan.Controls.Add(this.cmbIP);
            this.gpScan.Controls.Add(this.btnStop);
            this.gpScan.Controls.Add(this.txtEnd);
            this.gpScan.Controls.Add(this.txtStar);
            this.gpScan.Controls.Add(this.label2);
            this.gpScan.Controls.Add(this.label1);
            this.gpScan.Controls.Add(this.btnSearch);
            this.gpScan.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpScan.Location = new System.Drawing.Point(0, 25);
            this.gpScan.Name = "gpScan";
            this.gpScan.Size = new System.Drawing.Size(876, 46);
            this.gpScan.TabIndex = 0;
            this.gpScan.TabStop = false;
            this.gpScan.Text = "扫描";
            // 
            // cmbSpeed
            // 
            this.cmbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpeed.FormattingEnabled = true;
            this.cmbSpeed.Location = new System.Drawing.Point(783, 20);
            this.cmbSpeed.Name = "cmbSpeed";
            this.cmbSpeed.Size = new System.Drawing.Size(81, 20);
            this.cmbSpeed.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "网络:";
            // 
            // cmbIP
            // 
            this.cmbIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIP.FormattingEnabled = true;
            this.cmbIP.Location = new System.Drawing.Point(50, 19);
            this.cmbIP.Name = "cmbIP";
            this.cmbIP.Size = new System.Drawing.Size(159, 20);
            this.cmbIP.TabIndex = 8;
            this.cmbIP.SelectedIndexChanged += new System.EventHandler(this.cmbIP_SelectedIndexChanged);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(702, 18);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(475, 18);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Padding = new System.Windows.Forms.Padding(1);
            this.txtEnd.Size = new System.Drawing.Size(140, 21);
            this.txtEnd.TabIndex = 6;
            // 
            // txtStar
            // 
            this.txtStar.Location = new System.Drawing.Point(271, 18);
            this.txtStar.Name = "txtStar";
            this.txtStar.Padding = new System.Windows.Forms.Padding(1);
            this.txtStar.Size = new System.Drawing.Size(140, 21);
            this.txtStar.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(417, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "结束地址:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "起始地址:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(621, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "扫描";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgMembers);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.satProcess);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(876, 443);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // dgMembers
            // 
            this.dgMembers.AllowUserToAddRows = false;
            this.dgMembers.AllowUserToResizeRows = false;
            this.dgMembers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgMembers.BackgroundColor = System.Drawing.Color.White;
            this.dgMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMembers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColIP,
            this.ColName,
            this.ColMAC});
            this.dgMembers.ContextMenuStrip = this.cmItems;
            this.dgMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMembers.Location = new System.Drawing.Point(3, 17);
            this.dgMembers.MultiSelect = false;
            this.dgMembers.Name = "dgMembers";
            this.dgMembers.ReadOnly = true;
            this.dgMembers.RowHeadersVisible = false;
            this.dgMembers.RowTemplate.Height = 23;
            this.dgMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgMembers.Size = new System.Drawing.Size(870, 322);
            this.dgMembers.TabIndex = 0;
            this.dgMembers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMembers_CellDoubleClick);
            // 
            // ColIP
            // 
            this.ColIP.HeaderText = "IP地址";
            this.ColIP.Name = "ColIP";
            this.ColIP.ReadOnly = true;
            // 
            // ColName
            // 
            this.ColName.HeaderText = "主机名";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            // 
            // ColMAC
            // 
            this.ColMAC.HeaderText = "MAC地址";
            this.ColMAC.Name = "ColMAC";
            this.ColMAC.ReadOnly = true;
            // 
            // cmItems
            // 
            this.cmItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ping主机ToolStripMenuItem,
            this.查看共享ToolStripMenuItem,
            this.唤醒ToolStripMenuItem,
            this.tsCreateSnap,
            this.tsCreateSnapPing,
            this.tsAddToLis,
            this.toolStripMenuItem3,
            this.复制ToolStripMenuItem,
            this.tsDelete,
            this.toolStripMenuItem2,
            this.tsClear});
            this.cmItems.Name = "cmItems";
            this.cmItems.Size = new System.Drawing.Size(211, 214);
            // 
            // ping主机ToolStripMenuItem
            // 
            this.ping主机ToolStripMenuItem.Name = "ping主机ToolStripMenuItem";
            this.ping主机ToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.ping主机ToolStripMenuItem.Text = "ping主机";
            this.ping主机ToolStripMenuItem.Click += new System.EventHandler(this.ping主机ToolStripMenuItem_Click);
            // 
            // 查看共享ToolStripMenuItem
            // 
            this.查看共享ToolStripMenuItem.Name = "查看共享ToolStripMenuItem";
            this.查看共享ToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.查看共享ToolStripMenuItem.Text = "查看共享";
            this.查看共享ToolStripMenuItem.Click += new System.EventHandler(this.查看共享ToolStripMenuItem_Click);
            // 
            // 唤醒ToolStripMenuItem
            // 
            this.唤醒ToolStripMenuItem.Name = "唤醒ToolStripMenuItem";
            this.唤醒ToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.唤醒ToolStripMenuItem.Text = "唤醒";
            this.唤醒ToolStripMenuItem.Click += new System.EventHandler(this.唤醒ToolStripMenuItem_Click);
            // 
            // tsCreateSnap
            // 
            this.tsCreateSnap.Name = "tsCreateSnap";
            this.tsCreateSnap.Size = new System.Drawing.Size(210, 22);
            this.tsCreateSnap.Text = "创建唤醒快捷方式";
            this.tsCreateSnap.Click += new System.EventHandler(this.tsCreateSnap_Click);
            // 
            // tsCreateSnapPing
            // 
            this.tsCreateSnapPing.Name = "tsCreateSnapPing";
            this.tsCreateSnapPing.Size = new System.Drawing.Size(210, 22);
            this.tsCreateSnapPing.Text = "创建带ping唤醒快捷方式";
            this.tsCreateSnapPing.Click += new System.EventHandler(this.TsCreateSnapPing_Click);
            // 
            // tsAddToLis
            // 
            this.tsAddToLis.Name = "tsAddToLis";
            this.tsAddToLis.Size = new System.Drawing.Size(210, 22);
            this.tsAddToLis.Text = "添加到Web";
            this.tsAddToLis.Click += new System.EventHandler(this.TsAddToLis_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(207, 6);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.复制ToolStripMenuItem.Text = "复制";
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制ToolStripMenuItem_Click);
            // 
            // tsDelete
            // 
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(210, 22);
            this.tsDelete.Text = "删除";
            this.tsDelete.Click += new System.EventHandler(this.tsDelete_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(207, 6);
            // 
            // tsClear
            // 
            this.tsClear.Name = "tsClear";
            this.tsClear.Size = new System.Drawing.Size(210, 22);
            this.tsClear.Text = "清空";
            this.tsClear.Click += new System.EventHandler(this.tsClear_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.txtUrl);
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Controls.Add(this.btnPing);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 339);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(870, 79);
            this.panel1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gvLis);
            this.groupBox2.Controls.Add(this.btnLisStop);
            this.groupBox2.Controls.Add(this.btnLisStart);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.nupLisPort);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(416, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(454, 79);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "唤醒服务";
            // 
            // gvLis
            // 
            this.gvLis.AllowUserToAddRows = false;
            this.gvLis.AllowUserToResizeRows = false;
            this.gvLis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvLis.BackgroundColor = System.Drawing.Color.White;
            this.gvLis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLis.ColumnHeadersVisible = false;
            this.gvLis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColLisName,
            this.ColLisMAC});
            this.gvLis.ContextMenuStrip = this.cmLisItems;
            this.gvLis.Dock = System.Windows.Forms.DockStyle.Right;
            this.gvLis.Location = new System.Drawing.Point(204, 17);
            this.gvLis.MultiSelect = false;
            this.gvLis.Name = "gvLis";
            this.gvLis.ReadOnly = true;
            this.gvLis.RowHeadersVisible = false;
            this.gvLis.RowTemplate.Height = 23;
            this.gvLis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvLis.Size = new System.Drawing.Size(247, 59);
            this.gvLis.TabIndex = 4;
            this.gvLis.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GvLis_CellContentClick);
            // 
            // ColLisName
            // 
            this.ColLisName.HeaderText = "名称";
            this.ColLisName.Name = "ColLisName";
            this.ColLisName.ReadOnly = true;
            // 
            // ColLisMAC
            // 
            this.ColLisMAC.HeaderText = "MAC地址";
            this.ColLisMAC.Name = "ColLisMAC";
            this.ColLisMAC.ReadOnly = true;
            // 
            // cmLisItems
            // 
            this.cmLisItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsEditLis,
            this.tsLisDelete});
            this.cmLisItems.Name = "cmLisItems";
            this.cmLisItems.Size = new System.Drawing.Size(101, 48);
            // 
            // tsEditLis
            // 
            this.tsEditLis.Name = "tsEditLis";
            this.tsEditLis.Size = new System.Drawing.Size(100, 22);
            this.tsEditLis.Text = "编辑";
            this.tsEditLis.Click += new System.EventHandler(this.TsEditLis_Click);
            // 
            // tsLisDelete
            // 
            this.tsLisDelete.Name = "tsLisDelete";
            this.tsLisDelete.Size = new System.Drawing.Size(100, 22);
            this.tsLisDelete.Text = "删除";
            this.tsLisDelete.Click += new System.EventHandler(this.TsLisDelete_Click);
            // 
            // btnLisStop
            // 
            this.btnLisStop.Location = new System.Drawing.Point(123, 46);
            this.btnLisStop.Name = "btnLisStop";
            this.btnLisStop.Size = new System.Drawing.Size(75, 23);
            this.btnLisStop.TabIndex = 3;
            this.btnLisStop.Text = "停止监听";
            this.btnLisStop.UseVisualStyleBackColor = true;
            this.btnLisStop.Click += new System.EventHandler(this.BtnLisStop_Click);
            // 
            // btnLisStart
            // 
            this.btnLisStart.Location = new System.Drawing.Point(42, 46);
            this.btnLisStart.Name = "btnLisStart";
            this.btnLisStart.Size = new System.Drawing.Size(75, 23);
            this.btnLisStart.TabIndex = 2;
            this.btnLisStart.Text = "开始监听";
            this.btnLisStart.UseVisualStyleBackColor = true;
            this.btnLisStart.Click += new System.EventHandler(this.BtnLisStart_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "端口";
            // 
            // nupLisPort
            // 
            this.nupLisPort.Location = new System.Drawing.Point(42, 19);
            this.nupLisPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nupLisPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupLisPort.Name = "nupLisPort";
            this.nupLisPort.Size = new System.Drawing.Size(156, 21);
            this.nupLisPort.TabIndex = 0;
            this.nupLisPort.Value = new decimal(new int[] {
            8089,
            0,
            0,
            0});
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(35, 14);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(356, 21);
            this.txtUrl.TabIndex = 7;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(316, 46);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 6;
            this.btnOpen.Text = "打开共享";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnPing
            // 
            this.btnPing.Location = new System.Drawing.Point(235, 46);
            this.btnPing.Name = "btnPing";
            this.btnPing.Size = new System.Drawing.Size(75, 23);
            this.btnPing.TabIndex = 5;
            this.btnPing.Text = "ping地址";
            this.btnPing.UseVisualStyleBackColor = true;
            this.btnPing.Click += new System.EventHandler(this.btnPing_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "地址:";
            // 
            // satProcess
            // 
            this.satProcess.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspbScan,
            this.tsProcess});
            this.satProcess.Location = new System.Drawing.Point(3, 418);
            this.satProcess.Name = "satProcess";
            this.satProcess.Size = new System.Drawing.Size(870, 22);
            this.satProcess.TabIndex = 1;
            this.satProcess.Text = "statusStrip1";
            // 
            // tspbScan
            // 
            this.tspbScan.Name = "tspbScan";
            this.tspbScan.Size = new System.Drawing.Size(300, 16);
            // 
            // tsProcess
            // 
            this.tsProcess.Name = "tsProcess";
            this.tsProcess.Size = new System.Drawing.Size(26, 17);
            this.tsProcess.Text = "0%";
            // 
            // msMenu
            // 
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(876, 25);
            this.msMenu.TabIndex = 2;
            this.msMenu.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(97, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // ofd
            // 
            this.ofd.Filter = "*XML文件|*.xml|所有文件|*.*";
            // 
            // sfd
            // 
            this.sfd.Filter = "XML文件|*.xml|txt文本|*.txt";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 514);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gpScan);
            this.Controls.Add(this.msMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "局域网助手";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.gpScan.ResumeLayout(false);
            this.gpScan.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMembers)).EndInit();
            this.cmItems.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLis)).EndInit();
            this.cmLisItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nupLisPort)).EndInit();
            this.satProcess.ResumeLayout(false);
            this.satProcess.PerformLayout();
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpScan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgMembers;
        private LC.Library.Controls.IPBox txtStar;
        private LC.Library.Controls.IPBox txtEnd;
        private System.Windows.Forms.StatusStrip satProcess;
        private System.Windows.Forms.ToolStripProgressBar tspbScan;
        private System.Windows.Forms.ToolStripStatusLabel tsProcess;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ContextMenuStrip cmItems;
        private System.Windows.Forms.ToolStripMenuItem ping主机ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看共享ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbIP;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnPing;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbSpeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMAC;
        private System.Windows.Forms.ToolStripMenuItem 唤醒ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tsClear;
        private System.Windows.Forms.ToolStripMenuItem tsCreateSnap;
        private System.Windows.Forms.ToolStripMenuItem tsCreateSnapPing;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLisStop;
        private System.Windows.Forms.Button btnLisStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nupLisPort;
        private System.Windows.Forms.DataGridView gvLis;
        private System.Windows.Forms.ToolStripMenuItem tsAddToLis;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLisName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLisMAC;
        private System.Windows.Forms.ContextMenuStrip cmLisItems;
        private System.Windows.Forms.ToolStripMenuItem tsEditLis;
        private System.Windows.Forms.ToolStripMenuItem tsLisDelete;
    }
}

