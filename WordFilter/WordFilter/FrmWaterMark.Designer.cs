namespace WordFilter
{
    partial class FrmWaterMark
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPutToClipboard = new System.Windows.Forms.Button();
            this.txtWaterMark = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnView = new System.Windows.Forms.Button();
            this.btnPutFile = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.btnLoadClipboard = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPutToClipboard);
            this.groupBox1.Controls.Add(this.txtWaterMark);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.btnPutFile);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 306);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(608, 137);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnPutToClipboard
            // 
            this.btnPutToClipboard.Location = new System.Drawing.Point(139, 84);
            this.btnPutToClipboard.Name = "btnPutToClipboard";
            this.btnPutToClipboard.Size = new System.Drawing.Size(106, 41);
            this.btnPutToClipboard.TabIndex = 5;
            this.btnPutToClipboard.Text = "输出剪贴板";
            this.btnPutToClipboard.UseVisualStyleBackColor = true;
            this.btnPutToClipboard.Click += new System.EventHandler(this.btnPutToClipboard_Click);
            // 
            // txtWaterMark
            // 
            this.txtWaterMark.Location = new System.Drawing.Point(93, 37);
            this.txtWaterMark.Name = "txtWaterMark";
            this.txtWaterMark.Size = new System.Drawing.Size(146, 26);
            this.txtWaterMark.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "盲水印:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnLoadFile);
            this.panel3.Controls.Add(this.btnView);
            this.panel3.Controls.Add(this.btnLoadClipboard);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(375, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(230, 112);
            this.panel3.TabIndex = 1;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(101, 68);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(113, 41);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "查看盲水印";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnPutFile
            // 
            this.btnPutFile.Location = new System.Drawing.Point(27, 84);
            this.btnPutFile.Name = "btnPutFile";
            this.btnPutFile.Size = new System.Drawing.Size(106, 41);
            this.btnPutFile.TabIndex = 0;
            this.btnPutFile.Text = "输出到文件";
            this.btnPutFile.UseVisualStyleBackColor = true;
            this.btnPutFile.Click += new System.EventHandler(this.btnPutFile_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pbImage);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(608, 306);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // pbImage
            // 
            this.pbImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImage.Location = new System.Drawing.Point(3, 22);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(602, 281);
            this.pbImage.TabIndex = 1;
            this.pbImage.TabStop = false;
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(3, 15);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(92, 41);
            this.btnLoadFile.TabIndex = 4;
            this.btnLoadFile.Text = "加载文件";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // btnLoadClipboard
            // 
            this.btnLoadClipboard.Location = new System.Drawing.Point(101, 15);
            this.btnLoadClipboard.Name = "btnLoadClipboard";
            this.btnLoadClipboard.Size = new System.Drawing.Size(113, 41);
            this.btnLoadClipboard.TabIndex = 3;
            this.btnLoadClipboard.Text = "加载剪贴板";
            this.btnLoadClipboard.UseVisualStyleBackColor = true;
            this.btnLoadClipboard.Click += new System.EventHandler(this.btnLoadClipboard_Click);
            // 
            // ofd
            // 
            this.ofd.Filter = "All Image Files|*.bmp;*.ico;*.gif;*.jpeg;*.jpg;*.png;*.tif;*.tiff";
            // 
            // sfd
            // 
            this.sfd.Filter = "Jpg|*.jpg|Bmp|*.bmp|Gif|*.gif|Png|*.png|tiff|*.tiff";
            // 
            // FrmWaterMark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 443);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmWaterMark";
            this.Text = "盲水印";
            this.Load += new System.EventHandler(this.FrmWaterMark_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPutToClipboard;
        private System.Windows.Forms.TextBox txtWaterMark;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnPutFile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Button btnLoadClipboard;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.SaveFileDialog sfd;
    }
}