namespace SampleForm
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
            this.btnAD = new System.Windows.Forms.Button();
            this.btnGif = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFps = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.txtFps)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAD
            // 
            this.btnAD.Location = new System.Drawing.Point(12, 105);
            this.btnAD.Name = "btnAD";
            this.btnAD.Size = new System.Drawing.Size(121, 50);
            this.btnAD.TabIndex = 0;
            this.btnAD.Text = "滚动广告";
            this.btnAD.UseVisualStyleBackColor = true;
            this.btnAD.Click += new System.EventHandler(this.btnAD_Click);
            // 
            // btnGif
            // 
            this.btnGif.Location = new System.Drawing.Point(151, 105);
            this.btnGif.Name = "btnGif";
            this.btnGif.Size = new System.Drawing.Size(121, 50);
            this.btnGif.TabIndex = 1;
            this.btnGif.Text = "GIF图片";
            this.btnGif.UseVisualStyleBackColor = true;
            this.btnGif.Click += new System.EventHandler(this.btnGif_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "广告帧数:";
            // 
            // txtFps
            // 
            this.txtFps.Location = new System.Drawing.Point(78, 25);
            this.txtFps.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.txtFps.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtFps.Name = "txtFps";
            this.txtFps.Size = new System.Drawing.Size(120, 21);
            this.txtFps.TabIndex = 3;
            this.txtFps.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 167);
            this.Controls.Add(this.txtFps);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGif);
            this.Controls.Add(this.btnAD);
            this.Name = "FrmMain";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.txtFps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAD;
        private System.Windows.Forms.Button btnGif;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtFps;
    }
}

