using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

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
        private string strTimeup = " playing　　　";
        private string strClear = "　　　　　　　";
        private DateTime timeTarget;    // target time
        private int secMinRemain = 30;  // min second for target
        private int secTargetUnit = 15; // time unit for target
        private int secOffset = 5;  // (n * secTargetUnit) + secOffset
        private int maxProgress = 15;   // second
        private int mulProgress = 10;   // resolution of progress  (1/mulProgress) second
        private string strOutFilePath = null;

        public FormMain()
        {
            InitializeComponent();

            strLevel.Add(enmLevel.lv_EASY, "ES");
            strLevel.Add(enmLevel.lv_NORMAL, "NR");
            strLevel.Add(enmLevel.lv_HARD, "HD");
            strLevel.Add(enmLevel.lv_EXPERT, "EX");
            strLevel.Add(enmLevel.lv_TECHNICAL, "TC");

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length >= 2)
            {
                strOutFilePath = args[1];
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = maxProgress * mulProgress;
            progressBar1.Visible = false;
            StopButtionShow(false);
            textNext.Text = strClear;
            BtnStop.Left = BtnEasy.Left;
            BtnStop.Top = BtnEasy.Top;
            BtnStop.Width = BtnHard.Right - BtnEasy.Left;
            BtnStop.Height = progressBar1.Top - BtnEasy.Top;
            // write file
            WriteFile();
        }

        private void SetTerget(enmLevel lv)
        {
            DateTime timeBase = DateTime.Now;
            int secBase = timeBase.Second;
            int secTarget = ((secBase - secOffset + secMinRemain + (secTargetUnit - 1)) / secTargetUnit * secTargetUnit) + secOffset;
            timeTarget = timeBase.AddSeconds(secTarget - secBase);
            timeTarget = timeTarget.AddMilliseconds(-timeBase.Millisecond);

            progressBar1.Value = 0;
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
            // write file
            WriteFile();
        }

        private void WriteFile()
        {
            if (strOutFilePath != null && strOutFilePath.Length > 0)
            {
                // write file
                StreamWriter writer = new StreamWriter(strOutFilePath, false, Encoding.UTF8);
                writer.WriteLine(textNext.Text);
                writer.Close();
            }
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
            // write file
            WriteFile();

        }

        private void timerTick_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now - timeTarget).Seconds > 0)
            {
                timerTick.Stop();
                StopButtionShow(false);
                progressBar1.Visible = false;
                textNext.Text = strTimeup;
                radioTick1.Checked = false;
                radioTick2.Checked = false;
                progressBar1.Value = 0;
                // write file
                WriteFile();
            }
            else
            {
                StopButtionShow(true);
                TimeSpan spanRemain = timeTarget - DateTime.Now;
                // progress
                if (spanRemain.Seconds < maxProgress)
                {
                    int msRemain = maxProgress * 1000 - (spanRemain.Seconds * 1000 + spanRemain.Milliseconds);
                    if (msRemain < 0)
                    {
                        progressBar1.Value = 0;
                    }
                    else if (msRemain > maxProgress * 1000)
                    {
                        progressBar1.Value = progressBar1.Maximum;
                    }
                    else
                    {
                        progressBar1.Value = msRemain * mulProgress / 1000;
                    }
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
