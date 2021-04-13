
namespace PixivToVideo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtOut = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.cmbOutFPS = new System.Windows.Forms.ComboBox();
            this.cmbbit = new System.Windows.Forms.ComboBox();
            this.nuploop = new System.Windows.Forms.NumericUpDown();
            this.ofdZip = new System.Windows.Forms.OpenFileDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbOutput = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuploop)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 282);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(267, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 62);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "动画zip文件";
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(113, 19);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(295, 26);
            this.txtZip.TabIndex = 2;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(111, 15);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(125, 38);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "转换";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtOut
            // 
            this.txtOut.Location = new System.Drawing.Point(113, 51);
            this.txtOut.Name = "txtOut";
            this.txtOut.Size = new System.Drawing.Size(295, 26);
            this.txtOut.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "输出地址";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(414, 17);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 26);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.Text = "浏览";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // cmbOutFPS
            // 
            this.cmbOutFPS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutFPS.FormattingEnabled = true;
            this.cmbOutFPS.Items.AddRange(new object[] {
            "MP4",
            "GIF"});
            this.cmbOutFPS.Location = new System.Drawing.Point(132, 188);
            this.cmbOutFPS.Name = "cmbOutFPS";
            this.cmbOutFPS.Size = new System.Drawing.Size(276, 24);
            this.cmbOutFPS.TabIndex = 39;
            // 
            // cmbbit
            // 
            this.cmbbit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbit.FormattingEnabled = true;
            this.cmbbit.Items.AddRange(new object[] {
            "MP4",
            "GIF"});
            this.cmbbit.Location = new System.Drawing.Point(132, 150);
            this.cmbbit.Name = "cmbbit";
            this.cmbbit.Size = new System.Drawing.Size(276, 24);
            this.cmbbit.TabIndex = 37;
            // 
            // nuploop
            // 
            this.nuploop.Location = new System.Drawing.Point(132, 108);
            this.nuploop.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nuploop.Name = "nuploop";
            this.nuploop.Size = new System.Drawing.Size(276, 26);
            this.nuploop.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(79, 230);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 41;
            this.label8.Text = "格式:";
            // 
            // cmbOutput
            // 
            this.cmbOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutput.FormattingEnabled = true;
            this.cmbOutput.Items.AddRange(new object[] {
            "MP4",
            "GIF"});
            this.cmbOutput.Location = new System.Drawing.Point(132, 225);
            this.cmbOutput.Name = "cmbOutput";
            this.cmbOutput.Size = new System.Drawing.Size(276, 24);
            this.cmbOutput.TabIndex = 40;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtZip);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmbOutput);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cmbOutFPS);
            this.panel2.Controls.Add(this.txtOut);
            this.panel2.Controls.Add(this.btnOpen);
            this.panel2.Controls.Add(this.cmbbit);
            this.panel2.Controls.Add(this.nuploop);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(515, 282);
            this.panel2.TabIndex = 42;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 190);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 16);
            this.label10.TabIndex = 44;
            this.label10.Text = "帧率(mp4):";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 152);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 43;
            this.label9.Text = "码率(mp4):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 110);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 16);
            this.label7.TabIndex = 42;
            this.label7.Text = "循环次数(mp4):";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 369);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmMain";
            this.Text = "P站动图包转动画";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nuploop)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.TextBox txtOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ComboBox cmbOutFPS;
        private System.Windows.Forms.ComboBox cmbbit;
        private System.Windows.Forms.NumericUpDown nuploop;
        private System.Windows.Forms.OpenFileDialog ofdZip;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbOutput;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
    }
}

