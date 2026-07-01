namespace ScanLan
{
    partial class FrmAddWakeupTask
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
            this.lblMac = new System.Windows.Forms.Label();
            this.txtMac = new System.Windows.Forms.TextBox();
            this.lblHostName = new System.Windows.Forms.Label();
            this.txtHostName = new System.Windows.Forms.TextBox();
            this.lblTaskName = new System.Windows.Forms.Label();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.lblMode = new System.Windows.Forms.Label();
            this.radDaily = new System.Windows.Forms.RadioButton();
            this.radWeekly = new System.Windows.Forms.RadioButton();
            this.radMonthly = new System.Windows.Forms.RadioButton();
            this.lblDayValue = new System.Windows.Forms.Label();
            this.pnlWeekDays = new System.Windows.Forms.Panel();
            this.chkWeek0 = new System.Windows.Forms.CheckBox();
            this.chkWeek1 = new System.Windows.Forms.CheckBox();
            this.chkWeek2 = new System.Windows.Forms.CheckBox();
            this.chkWeek3 = new System.Windows.Forms.CheckBox();
            this.chkWeek4 = new System.Windows.Forms.CheckBox();
            this.chkWeek5 = new System.Windows.Forms.CheckBox();
            this.chkWeek6 = new System.Windows.Forms.CheckBox();
            this.nudMonthDay = new System.Windows.Forms.NumericUpDown();
            this.lblTime = new System.Windows.Forms.Label();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlWeekDays.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonthDay)).BeginInit();
            this.SuspendLayout();
            //
            // lblMac
            //
            this.lblMac.AutoSize = true;
            this.lblMac.Location = new System.Drawing.Point(12, 18);
            this.lblMac.Name = "lblMac";
            this.lblMac.Size = new System.Drawing.Size(59, 12);
            this.lblMac.TabIndex = 0;
            this.lblMac.Text = "MAC地址:";
            //
            // txtMac
            //
            this.txtMac.Location = new System.Drawing.Point(90, 14);
            this.txtMac.Name = "txtMac";
            this.txtMac.Size = new System.Drawing.Size(300, 21);
            this.txtMac.TabIndex = 1;
            //
            // lblHostName
            //
            this.lblHostName.AutoSize = true;
            this.lblHostName.Location = new System.Drawing.Point(12, 48);
            this.lblHostName.Name = "lblHostName";
            this.lblHostName.Size = new System.Drawing.Size(59, 12);
            this.lblHostName.TabIndex = 2;
            this.lblHostName.Text = "备注名:";
            //
            // txtHostName
            //
            this.txtHostName.Location = new System.Drawing.Point(90, 44);
            this.txtHostName.Name = "txtHostName";
            this.txtHostName.Size = new System.Drawing.Size(300, 21);
            this.txtHostName.TabIndex = 3;
            //
            // lblTaskName
            //
            this.lblTaskName.AutoSize = true;
            this.lblTaskName.Location = new System.Drawing.Point(12, 78);
            this.lblTaskName.Name = "lblTaskName";
            this.lblTaskName.Size = new System.Drawing.Size(59, 12);
            this.lblTaskName.TabIndex = 4;
            this.lblTaskName.Text = "任务名:";
            //
            // txtTaskName
            //
            this.txtTaskName.Location = new System.Drawing.Point(90, 74);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(300, 21);
            this.txtTaskName.TabIndex = 5;
            //
            // lblMode
            //
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(12, 110);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(41, 12);
            this.lblMode.TabIndex = 6;
            this.lblMode.Text = "重复:";
            //
            // radDaily
            //
            this.radDaily.AutoSize = true;
            this.radDaily.Location = new System.Drawing.Point(90, 108);
            this.radDaily.Name = "radDaily";
            this.radDaily.Size = new System.Drawing.Size(59, 16);
            this.radDaily.TabIndex = 7;
            this.radDaily.TabStop = true;
            this.radDaily.Text = "每天";
            this.radDaily.UseVisualStyleBackColor = true;
            this.radDaily.CheckedChanged += new System.EventHandler(this.RadMode_CheckedChanged);
            //
            // radWeekly
            //
            this.radWeekly.AutoSize = true;
            this.radWeekly.Location = new System.Drawing.Point(170, 108);
            this.radWeekly.Name = "radWeekly";
            this.radWeekly.Size = new System.Drawing.Size(59, 16);
            this.radWeekly.TabIndex = 8;
            this.radWeekly.TabStop = true;
            this.radWeekly.Text = "每周";
            this.radWeekly.UseVisualStyleBackColor = true;
            this.radWeekly.CheckedChanged += new System.EventHandler(this.RadMode_CheckedChanged);
            //
            // radMonthly
            //
            this.radMonthly.AutoSize = true;
            this.radMonthly.Location = new System.Drawing.Point(250, 108);
            this.radMonthly.Name = "radMonthly";
            this.radMonthly.Size = new System.Drawing.Size(59, 16);
            this.radMonthly.TabIndex = 9;
            this.radMonthly.TabStop = true;
            this.radMonthly.Text = "每月";
            this.radMonthly.UseVisualStyleBackColor = true;
            this.radMonthly.CheckedChanged += new System.EventHandler(this.RadMode_CheckedChanged);
            //
            // lblDayValue
            //
            this.lblDayValue.AutoSize = true;
            this.lblDayValue.Location = new System.Drawing.Point(12, 143);
            this.lblDayValue.Name = "lblDayValue";
            this.lblDayValue.Size = new System.Drawing.Size(77, 12);
            this.lblDayValue.TabIndex = 10;
            this.lblDayValue.Text = "星期/日期:";
            //
            // pnlWeekDays
            //
            this.pnlWeekDays.Controls.Add(this.chkWeek0);
            this.pnlWeekDays.Controls.Add(this.chkWeek1);
            this.pnlWeekDays.Controls.Add(this.chkWeek2);
            this.pnlWeekDays.Controls.Add(this.chkWeek3);
            this.pnlWeekDays.Controls.Add(this.chkWeek4);
            this.pnlWeekDays.Controls.Add(this.chkWeek5);
            this.pnlWeekDays.Controls.Add(this.chkWeek6);
            this.pnlWeekDays.Location = new System.Drawing.Point(92, 137);
            this.pnlWeekDays.Name = "pnlWeekDays";
            this.pnlWeekDays.Size = new System.Drawing.Size(310, 24);
            this.pnlWeekDays.TabIndex = 11;
            //
            // chkWeek0
            //
            this.chkWeek0.AutoSize = true;
            this.chkWeek0.Location = new System.Drawing.Point(3, 4);
            this.chkWeek0.Name = "chkWeek0";
            this.chkWeek0.Size = new System.Drawing.Size(36, 16);
            this.chkWeek0.TabIndex = 0;
            this.chkWeek0.Text = "日";
            this.chkWeek0.UseVisualStyleBackColor = true;
            //
            // chkWeek1
            //
            this.chkWeek1.AutoSize = true;
            this.chkWeek1.Location = new System.Drawing.Point(47, 4);
            this.chkWeek1.Name = "chkWeek1";
            this.chkWeek1.Size = new System.Drawing.Size(36, 16);
            this.chkWeek1.TabIndex = 1;
            this.chkWeek1.Text = "一";
            this.chkWeek1.UseVisualStyleBackColor = true;
            //
            // chkWeek2
            //
            this.chkWeek2.AutoSize = true;
            this.chkWeek2.Location = new System.Drawing.Point(91, 4);
            this.chkWeek2.Name = "chkWeek2";
            this.chkWeek2.Size = new System.Drawing.Size(36, 16);
            this.chkWeek2.TabIndex = 2;
            this.chkWeek2.Text = "二";
            this.chkWeek2.UseVisualStyleBackColor = true;
            //
            // chkWeek3
            //
            this.chkWeek3.AutoSize = true;
            this.chkWeek3.Location = new System.Drawing.Point(135, 4);
            this.chkWeek3.Name = "chkWeek3";
            this.chkWeek3.Size = new System.Drawing.Size(36, 16);
            this.chkWeek3.TabIndex = 3;
            this.chkWeek3.Text = "三";
            this.chkWeek3.UseVisualStyleBackColor = true;
            //
            // chkWeek4
            //
            this.chkWeek4.AutoSize = true;
            this.chkWeek4.Location = new System.Drawing.Point(179, 4);
            this.chkWeek4.Name = "chkWeek4";
            this.chkWeek4.Size = new System.Drawing.Size(36, 16);
            this.chkWeek4.TabIndex = 4;
            this.chkWeek4.Text = "四";
            this.chkWeek4.UseVisualStyleBackColor = true;
            //
            // chkWeek5
            //
            this.chkWeek5.AutoSize = true;
            this.chkWeek5.Location = new System.Drawing.Point(223, 4);
            this.chkWeek5.Name = "chkWeek5";
            this.chkWeek5.Size = new System.Drawing.Size(36, 16);
            this.chkWeek5.TabIndex = 5;
            this.chkWeek5.Text = "五";
            this.chkWeek5.UseVisualStyleBackColor = true;
            //
            // chkWeek6
            //
            this.chkWeek6.AutoSize = true;
            this.chkWeek6.Location = new System.Drawing.Point(267, 4);
            this.chkWeek6.Name = "chkWeek6";
            this.chkWeek6.Size = new System.Drawing.Size(36, 16);
            this.chkWeek6.TabIndex = 6;
            this.chkWeek6.Text = "六";
            this.chkWeek6.UseVisualStyleBackColor = true;
            //
            // nudMonthDay
            //
            this.nudMonthDay.Location = new System.Drawing.Point(100, 139);
            this.nudMonthDay.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.nudMonthDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMonthDay.Name = "nudMonthDay";
            this.nudMonthDay.Size = new System.Drawing.Size(120, 21);
            this.nudMonthDay.TabIndex = 12;
            this.nudMonthDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            //
            // lblTime
            //
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(12, 178);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(65, 12);
            this.lblTime.TabIndex = 13;
            this.lblTime.Text = "唤醒时间:";
            //
            // dtpTime
            //
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.Location = new System.Drawing.Point(100, 174);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(120, 21);
            this.dtpTime.TabIndex = 14;
            //
            // btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(140, 212);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 28);
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(230, 212);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            //
            // FrmAddWakeupTask
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 255);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.nudMonthDay);
            this.Controls.Add(this.pnlWeekDays);
            this.Controls.Add(this.lblDayValue);
            this.Controls.Add(this.radMonthly);
            this.Controls.Add(this.radWeekly);
            this.Controls.Add(this.radDaily);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.txtTaskName);
            this.Controls.Add(this.lblTaskName);
            this.Controls.Add(this.txtHostName);
            this.Controls.Add(this.lblHostName);
            this.Controls.Add(this.txtMac);
            this.Controls.Add(this.lblMac);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddWakeupTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加到定时唤醒";
            this.Load += new System.EventHandler(this.FrmAddWakeupTask_Load);
            this.pnlWeekDays.ResumeLayout(false);
            this.pnlWeekDays.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonthDay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMac;
        private System.Windows.Forms.TextBox txtMac;
        private System.Windows.Forms.Label lblHostName;
        private System.Windows.Forms.TextBox txtHostName;
        private System.Windows.Forms.Label lblTaskName;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.RadioButton radDaily;
        private System.Windows.Forms.RadioButton radWeekly;
        private System.Windows.Forms.RadioButton radMonthly;
        private System.Windows.Forms.Label lblDayValue;
        private System.Windows.Forms.Panel pnlWeekDays;
        private System.Windows.Forms.CheckBox chkWeek0;
        private System.Windows.Forms.CheckBox chkWeek1;
        private System.Windows.Forms.CheckBox chkWeek2;
        private System.Windows.Forms.CheckBox chkWeek3;
        private System.Windows.Forms.CheckBox chkWeek4;
        private System.Windows.Forms.CheckBox chkWeek5;
        private System.Windows.Forms.CheckBox chkWeek6;
        private System.Windows.Forms.NumericUpDown nudMonthDay;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
