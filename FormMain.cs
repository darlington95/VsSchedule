using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VsSchedule
{
    public partial class FormMain : Form
    {
        enum enmLevel { lv_EASY, lv_NORMAL, lv_HARD, lv_EXPERT, lv_TECHNICAL };
        private string strPre = " 次回";
        private Dictionary<enmLevel, string> strLevel = new Dictionary<enmLevel, string>();
        private string strMid = " ";
        private string strTimeFormat = "mm:ss";
        private string strPost = " ";
        private string strTimeup = "開始　　　　　";
        private string strClear = "　　　　　　　";
        private DateTime timeTarget;    // target time
        private int secMinRemain = 40;  // min second for target
        private int secTargetUnit = 15; // time unit for target
        private int maxProgress = 15;   // second

        public FormMain()
        {
            InitializeComponent();

            strLevel.Add(enmLevel.lv_EASY, "ES");
            strLevel.Add(enmLevel.lv_NORMAL, "NR");
            strLevel.Add(enmLevel.lv_HARD, "HD");
            strLevel.Add(enmLevel.lv_EXPERT, "EX");
            strLevel.Add(enmLevel.lv_TECHNICAL, "TC");
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            StopButtionShow(false);
            textNext.Text = strClear;
            BtnStop.Left = BtnEasy.Left;
            BtnStop.Top = BtnEasy.Top;
            BtnStop.Width = BtnHard.Right - BtnEasy.Left;
            BtnStop.Height = progressBar1.Top - BtnEasy.Top;
        }

        private void SetTerget(enmLevel lv)
        {
            DateTime timeBase = DateTime.Now;
            int secBase = timeBase.Second;
            int secTarget = (secBase + secMinRemain + (secTargetUnit - 1)) / secTargetUnit * secTargetUnit;
            timeTarget = timeBase.AddSeconds(secTarget - secBase);

            progressBar1.Value = 0;
            progressBar1.Maximum = maxProgress;
            timerTick.Start();

            StringBuilder sbOut = new StringBuilder();
            // pre
            sbOut.Append(strPre);
            // level
            if (strLevel.ContainsKey(lv))
            {
                sbOut.Append(strLevel[lv]);
            }
            else
            {
                sbOut.Append("??");
            }
            // mid
            sbOut.Append(strMid);
            // time
            sbOut.Append(timeTarget.ToString(strTimeFormat));
            // post
            sbOut.Append(strPost);
            // show text
            textNext.Text = sbOut.ToString();
        }

        private void StopButtionShow(bool stop_show)
        {
            BtnStop.Visible = stop_show;

            BtnEasy.Visible = !stop_show;
            BtnNormal.Visible = !stop_show;
            BtnHard.Visible = !stop_show;
            BtnExpert.Visible = !stop_show;
            BtnTechnical.Visible = !stop_show;
        }

        private void Stop()
        {
            timerTick.Stop();
            StopButtionShow(false);
            progressBar1.Visible = false;
            textNext.Text = strClear;
            radioTick1.Checked = false;
            radioTick2.Checked = false;
            progressBar1.Value = 0;
        }

        private void timerTick_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now >= timeTarget)
            {
                timerTick.Stop();
                StopButtionShow(false);
                progressBar1.Visible = false;
                textNext.Text = strTimeup;
                radioTick1.Checked = false;
                radioTick2.Checked = false;
                progressBar1.Value = 0;
            }
            else
            {
                StopButtionShow(true);
                int secRemain = (timeTarget - DateTime.Now).Seconds;
                // progress
                if (secRemain <= maxProgress)
                {
                    progressBar1.Value = maxProgress - secRemain;
                    progressBar1.Visible = true;
                }
                else
                {
                    progressBar1.Visible = false;
                }

                if (radioTick1.Checked)
                {
                    radioTick2.Checked = true;
                }
                else
                {
                    radioTick1.Checked = true;
                }
            }
        }

        private void BtnEasy_Click(object sender, EventArgs e)
        {
            StopButtionShow(true);
            SetTerget(enmLevel.lv_EASY);
        }

        private void BtnNormal_Click(object sender, EventArgs e)
        {
            StopButtionShow(true);
            SetTerget(enmLevel.lv_NORMAL);
        }

        private void BtnHard_Click(object sender, EventArgs e)
        {
            StopButtionShow(true);
            SetTerget(enmLevel.lv_HARD);
        }

        private void BtnExpert_Click(object sender, EventArgs e)
        {
            StopButtionShow(true);
            SetTerget(enmLevel.lv_EXPERT);
        }

        private void BtnTechnical_Click(object sender, EventArgs e)
        {
            StopButtionShow(true);
            SetTerget(enmLevel.lv_TECHNICAL);
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            Stop();
        }
    }
}
