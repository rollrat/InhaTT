﻿/***

   Copyright (C) 2017. rollrat. All Rights Reserved.

   04-20-2017:   HyunJun Jeong, Creation

***/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace InhaTT_Creator
{
    public partial class frmTTViewer : Form
    {
        List<Bot.SubjectStruct> subject;
        List<TimeElement> view_table = new List<TimeElement> ();

        /// <summary>
        /// 모든 조합이 저장됨
        /// </summary>
        List<List<TimeElement>> txts = new List<List<TimeElement>>();
        int ir = 0;

        string classroom;

        public frmTTViewer(List<Bot.SubjectStruct> al, bool file = true, 
            List<Bot.SubjectStruct> view = null, string classroom = "")
        {
            InitializeComponent();

            subject = al;

            if (file) Open();
            else Open(view);
            Show();

            this.classroom = classroom;

            lvTable.Invalidate();
            Application.DoEvents();
            DrawTimeTable();
        }

        private void frmTTViewer_Load(object sender, EventArgs e)
        {
            lvTable.Columns[0].TextAlign = HorizontalAlignment.Center;
            DateTime dt = new DateTime(1900, 1, 1, 9, 0, 0);
            for (int i = 1; i <= TimeTableSettings.DayMaxClass; i++)
            {
                string dtt = dt.Hour.ToString().PadLeft(2, '0') + ":" + dt.Minute.ToString().PadLeft(2, '0') + "~";
                dt = dt.AddMinutes(TimeTableSettings.MinPerClass);
                dtt += dt.Hour.ToString().PadLeft(2, '0') + ":" + dt.Minute.ToString().PadLeft(2, '0');
                lvTable.Items.Add(new ListViewItem(new string[] {"",
                    i.ToString().PadLeft(2, '0') + " 교시(" + dtt + ")","","","","",""}));
            }
        }

        /// <summary>
        /// 조합 파일 불러오기
        /// </summary>
        private void Open()
        {
            try
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(frmMain.PathCombinations);
                while ((line = file.ReadLine()) != null)
                {
                    List<TimeElement> al = new List<TimeElement>();
                    foreach (string ix in line.Split('|'))
                        if ( ix != "" )
                        {
                            foreach (Bot.SubjectStruct ss in subject)
                                if (ss.index.ToString() == ix)
                                {
                                    TimeElement te = TimeParser.Get(ss.시강);
                                    te.index = ss.index.ToString();
                                    al.Add(te);
                                }
                        }
                    txts.Add(al);
                }
                file.Close();
                if ( txts.Count > 0 )
                {
                    view_table = txts[0];
                }
                if (txts.Count == 1)
                    bRight.Enabled = false;
            }
            catch {  }
        }

        private void Open(List<Bot.SubjectStruct> subject)
        {
            List<TimeElement> al = new List<TimeElement>();
            foreach (Bot.SubjectStruct ss in subject)
            {
                TimeElement te = TimeParser.Get(ss.시강);
                te.index = ss.index.ToString();
                al.Add(te);
            }
            txts.Add(al);
            view_table = txts[0];
        }

        private void DrawTimeTable()
        {
            lvSearch.Items.Clear();
            foreach (TimeElement te in view_table)
            {
                int index = Convert.ToInt32(te.index);
                Random rm = new Random(index);
                int _r = rm.Next(256), _g = rm.Next(256), _b = rm.Next(256);
                int g = -2, icr = -1;
                bool second = false;
                foreach (int i in te.te)
                {
                    int c = i / TimeTableSettings.DayMaxClass;
                    int r = i % TimeTableSettings.DayMaxClass;

                    if (Math.Abs(g - i) != 1) icr++;

                    if (classroom == "" || classroom == te.cr[icr])
                        lvTable.CreateGraphics().FillRectangle(new SolidBrush(
                            Color.FromArgb(200, _r, _g, _b)
                            ), lvTable.Items[r].SubItems[c + 2].Bounds);

                    if (Math.Abs(g - i) != 1)
                    {
                        if (classroom == "" || classroom == te.cr[icr])
                            lvTable.CreateGraphics().DrawString(subject[index].과목명,
                            lvTable.Font, Brushes.White,
                            lvTable.Items[r].SubItems[c + 2].Bounds);
                        second = true;
                    }
                    else if (second == true && te.cr.Count > 0)
                    {
                        if (classroom == "" || classroom == te.cr[icr])
                            lvTable.CreateGraphics().DrawString(te.cr[icr] + "(" + subject[index].교수 + ")", 
                            lvTable.Font, Brushes.White,
                            lvTable.Items[r].SubItems[c + 2].Bounds);
                        second = false;
                    }

                    g = i;
                }
                foreach (Bot.SubjectStruct ss in subject)
                    if ( ss.index.ToString() == te.index)
                    {
                        AppendSubjectToList(ss);
                        break;
                    }
            }
        }

        //private void lvTable_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        //{
        //    e.Cancel = true;
        //    e.NewWidth = lvTable.Columns[e.ColumnIndex].Width;
        //}

        private void AppendSubjectToList(Bot.SubjectStruct ss)
        {
            lvSearch.Items.Add(new ListViewItem(new string[] { ss.index.ToString(),
                ss.필드, ss.학수번호, ss.분반, ss.과목명, ss.학년, ss.학점,
                ss.구분, ss.시강, ss.교수, ss.평가, ss.비고 }));
        }
        
        #region 버튼 클릭
        private void LeftClick()
        {
            ir--; view_table = txts[ir];
            if (ir == 0)
                bLeft.Enabled = false;
            if (txts.Count != ir + 1)
                bRight.Enabled = true;
            lvTable.Invalidate();
            Application.DoEvents();
            DrawTimeTable();
        }
        private void RightClick()
        {
            try
            {
                ir++; view_table = txts[ir];
                if (txts.Count == ir + 1)
                    bRight.Enabled = false;
                if (ir > 0)
                    bLeft.Enabled = true;
                lvTable.Invalidate();
                Application.DoEvents();
                DrawTimeTable();
            }
            catch
            { }
        }
        private void bRight_Click(object sender, EventArgs e)
        { RightClick(); }
        private void bLeft_Click(object sender, EventArgs e)
        { LeftClick(); }
        private void lvTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && bRight.Enabled)
                RightClick();
            else if (e.KeyCode == Keys.Left && bLeft.Enabled)
                LeftClick();
        }
        #endregion

    }
}
