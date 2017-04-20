/***

   Copyright (C) 2017. rollrat. All Rights Reserved.

   04-20-2017:   HyunJun Jeong, Creation

***/

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InhaTT
{
    public partial class frmTTViewer : Form
    {
        ArrayList subject;
        ArrayList tet = new ArrayList();
        ArrayList txts = new ArrayList();
        int ir = 0;

        public frmTTViewer(ArrayList al)
        {
            InitializeComponent();

            subject = al;

            Open();
            Show();
            listView2.Invalidate();
            Application.DoEvents();
            DrawTimeTable();
            listView2.Invalidate();
            Application.DoEvents();
            DrawTimeTable();
        }
        private void Open()
        {
            try
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"combinations.txt");
                while ((line = file.ReadLine()) != null)
                {
                    ArrayList al = new ArrayList();
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
                    tet = (ArrayList)txts[0];
                }
                if (txts.Count == 1)
                    button2.Enabled = false;
            }
            catch {  }
        }

        private void DrawTimeTable()
        {
            listView1.Items.Clear();
            foreach (TimeElement te in tet)
            {
                int index = Convert.ToInt32(te.index);
                Random rm = new Random(index);
                int _r = rm.Next(256), _g = rm.Next(256), _b = rm.Next(256);
                int g = -2;
                bool second = false;
                foreach (int i in te.te)
                {
                    int c = i / 25;
                    int r = i % 25;

                    listView2.CreateGraphics().FillRectangle(new SolidBrush(
                        Color.FromArgb(200, _r, _g, _b)
                        ), listView2.Items[r].SubItems[c + 2].Bounds);

                    if (Math.Abs(g - i) != 1)
                    {
                        listView2.CreateGraphics().DrawString(((Bot.SubjectStruct)subject[index]).과목명,
                            listView2.Font, Brushes.White,
                            listView2.Items[r].SubItems[c + 2].Bounds);
                        second = true;
                    }
                    else if (second == true)
                    {
                        listView2.CreateGraphics().DrawString(getSlice(((Bot.SubjectStruct)subject[index]).시강),
                            listView2.Font, Brushes.White,
                            listView2.Items[r].SubItems[c + 2].Bounds);
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

        private void listView2_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView2.Columns[e.ColumnIndex].Width;
        }


        private void AppendSubjectToList(Bot.SubjectStruct ss)
        {
            listView1.Items.Add(new ListViewItem(new string[] { ss.index.ToString(),
                ss.필드, ss.학수번호, ss.분반, ss.과목명, ss.학년, ss.학점,
                ss.구분, ss.시강, ss.교수, ss.평가, ss.비고 }));
        }

        private string getSlice(string a)
        {
            Regex regex = new Regex("\\((.*?)\\)");
            Match match = regex.Match(a);
            StringBuilder builder = new StringBuilder();

            while ( match.Success )
            {
                builder.Append(match.Groups[1]);
                match = match.NextMatch();
                if (match.Success)
                    builder.Append("/");
            }

            return builder.ToString();
        }
        
        private void frmTTViewer_Load(object sender, EventArgs e)
        {
            listView2.Columns[0].TextAlign = HorizontalAlignment.Center;
            DateTime dt = new DateTime(1900, 1, 1, 9, 0, 0);
            for (int i = 1; i <= 25; i++)
            {
                string dtt = dt.Hour.ToString().PadLeft(2, '0') + ":" + dt.Minute.ToString().PadLeft(2, '0') + "~";
                dt = dt.AddMinutes(30);
                dtt += dt.Hour.ToString().PadLeft(2, '0') + ":" + dt.Minute.ToString().PadLeft(2, '0');
                listView2.Items.Add(new ListViewItem(new string[] {"",
                    i.ToString().PadLeft(2, '0') + " 교시(" + dtt + ")","","","","",""}));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ir++; tet = (ArrayList)txts[ir];
            if (txts.Count == ir + 1)
                button2.Enabled = false;
            if (ir > 0)
                button1.Enabled = true;
            listView2.Invalidate();
            Application.DoEvents();
            DrawTimeTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ir--; tet = (ArrayList)txts[ir];
            if (ir == 0)
                button1.Enabled = false;
            if (txts.Count != ir + 1)
                button2.Enabled = true;
            listView2.Invalidate();
            Application.DoEvents();
            DrawTimeTable();
        }
        
        private void listView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && button2.Enabled)
            {
                ir++; tet = (ArrayList)txts[ir];
                if (txts.Count == ir + 1)
                    button2.Enabled = false;
                if (ir > 0)
                    button1.Enabled = true;
                listView2.Invalidate();
                Application.DoEvents();
                DrawTimeTable();
            }
            else if (e.KeyCode == Keys.Left && button1.Enabled)
            {
                ir--; tet = (ArrayList)txts[ir];
                if (ir == 0)
                    button1.Enabled = false;
                if (txts.Count != ir + 1)
                    button2.Enabled = true;
                listView2.Invalidate();
                Application.DoEvents();
                DrawTimeTable();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.m.tet = tet;
            Program.m.Trans();
            Program.m.Focus();
        }
    }
}
