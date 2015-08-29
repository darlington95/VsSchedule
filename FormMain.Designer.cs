namespace VsSchedule
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.radioTick1 = new System.Windows.Forms.RadioButton();
            this.radioTick2 = new System.Windows.Forms.RadioButton();
            this.BtnEasy = new System.Windows.Forms.Button();
            this.BtnNormal = new System.Windows.Forms.Button();
            this.BtnHard = new System.Windows.Forms.Button();
            this.BtnExpert = new System.Windows.Forms.Button();
            this.BtnTechnical = new System.Windows.Forms.Button();
            this.BtnStop = new System.Windows.Forms.Button();
            this.timerTick = new System.Windows.Forms.Timer(this.components);
            this.textNext = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(4, 38);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(237, 10);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 0;
            // 
            // radioTick1
            // 
            this.radioTick1.AutoSize = true;
            this.radioTick1.Enabled = false;
            this.radioTick1.Location = new System.Drawing.Point(4, 54);
            this.radioTick1.Name = "radioTick1";
            this.radioTick1.Size = new System.Drawing.Size(14, 13);
            this.radioTick1.TabIndex = 1;
            this.radioTick1.UseVisualStyleBackColor = true;
            // 
            // radioTick2
            // 
            this.radioTick2.AutoSize = true;
            this.radioTick2.Enabled = false;
            this.radioTick2.Location = new System.Drawing.Point(4, 73);
            this.radioTick2.Name = "radioTick2";
            this.radioTick2.Size = new System.Drawing.Size(14, 13);
            this.radioTick2.TabIndex = 2;
            this.radioTick2.UseVisualStyleBackColor = true;
            // 
            // BtnEasy
            // 
            this.BtnEasy.Location = new System.Drawing.Point(4, 3);
            this.BtnEasy.Name = "BtnEasy";
            this.BtnEasy.Size = new System.Drawing.Size(75, 40);
            this.BtnEasy.TabIndex = 5;
            this.BtnEasy.Text = "EASY";
            this.BtnEasy.UseVisualStyleBackColor = true;
            this.BtnEasy.Click += new System.EventHandler(this.BtnEasy_Click);
            // 
            // BtnNormal
            // 
            this.BtnNormal.Location = new System.Drawing.Point(85, 3);
            this.BtnNormal.Name = "BtnNormal";
            this.BtnNormal.Size = new System.Drawing.Size(75, 40);
            this.BtnNormal.TabIndex = 6;
            this.BtnNormal.Text = "NORMAIL";
            this.BtnNormal.UseVisualStyleBackColor = true;
            this.BtnNormal.Click += new System.EventHandler(this.BtnNormal_Click);
            // 
            // BtnHard
            // 
            this.BtnHard.Location = new System.Drawing.Point(167, 2);
            this.BtnHard.Name = "BtnHard";
            this.BtnHard.Size = new System.Drawing.Size(75, 40);
            this.BtnHard.TabIndex = 7;
            this.BtnHard.Text = "HARD";
            this.BtnHard.UseVisualStyleBackColor = true;
            this.BtnHard.Click += new System.EventHandler(this.BtnHard_Click);
            // 
            // BtnExpert
            // 
            this.BtnExpert.Location = new System.Drawing.Point(45, 49);
            this.BtnExpert.Name = "BtnExpert";
            this.BtnExpert.Size = new System.Drawing.Size(75, 40);
            this.BtnExpert.TabIndex = 8;
            this.BtnExpert.Text = "EXPERT";
            this.BtnExpert.UseVisualStyleBackColor = true;
            this.BtnExpert.Click += new System.EventHandler(this.BtnExpert_Click);
            // 
            // BtnTechnical
            // 
            this.BtnTechnical.Location = new System.Drawing.Point(127, 49);
            this.BtnTechnical.Name = "BtnTechnical";
            this.BtnTechnical.Size = new System.Drawing.Size(75, 40);
            this.BtnTechnical.TabIndex = 9;
            this.BtnTechnical.Text = "TEC";
            this.BtnTechnical.UseVisualStyleBackColor = true;
            this.BtnTechnical.Click += new System.EventHandler(this.BtnTechnical_Click);
            // 
            // BtnStop
            // 
            this.BtnStop.Location = new System.Drawing.Point(208, 49);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(33, 39);
            this.BtnStop.TabIndex = 4;
            this.BtnStop.Text = "STOP";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // timerTick
            // 
            this.timerTick.Interval = 200;
            this.timerTick.Tick += new System.EventHandler(this.timerTick_Tick);
            // 
            // textNext
            // 
            this.textNext.AutoSize = true;
            this.textNext.Location = new System.Drawing.Point(20, 62);
            this.textNext.Name = "textNext";
            this.textNext.Size = new System.Drawing.Size(27, 12);
            this.textNext.TabIndex = 3;
            this.textNext.Text = "next";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 91);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.BtnTechnical);
            this.Controls.Add(this.BtnExpert);
            this.Controls.Add(this.BtnHard);
            this.Controls.Add(this.BtnNormal);
            this.Controls.Add(this.BtnEasy);
            this.Controls.Add(this.radioTick2);
            this.Controls.Add(this.radioTick1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textNext);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "VsSchedule";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RadioButton radioTick1;
        private System.Windows.Forms.RadioButton radioTick2;
        private System.Windows.Forms.Button BtnEasy;
        private System.Windows.Forms.Button BtnNormal;
        private System.Windows.Forms.Button BtnHard;
        private System.Windows.Forms.Button BtnExpert;
        private System.Windows.Forms.Button BtnTechnical;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.Timer timerTick;
        private System.Windows.Forms.Label textNext;
    }
}

