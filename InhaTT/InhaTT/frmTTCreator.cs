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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InhaTT
{
    public partial class frmTTCreator : Form
    {
        ArrayList subject;
        public frmTTCreator(ArrayList al)
        {
            InitializeComponent();

            subject = al;
        }

        private void frmTTCreator_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "과목명";
            textBox1.AutoCompleteCustomSource.Clear();
            ArrayList al = new ArrayList();
            foreach (Bot.SubjectStruct ss in subject)
                if (!al.Contains(ss.과목명)) al.Add(ss.과목명);
            textBox1.AutoCompleteCustomSource.AddRange(al.ToArray(typeof(string)) as string[]);


            // 리스트뷰-컬럼 to ColHeader
            List<frmMain.ColHeader> columnsTrans = new List<frmMain.ColHeader>();
            foreach (ColumnHeader column in listView1.Columns)
            {
                columnsTrans.Add(new frmMain.ColHeader(column.Text, column.Width, column.TextAlign, true));
            }
            listView1.Columns.Clear();
            listView1.Columns.AddRange(columnsTrans.ToArray());
        }


        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            frmMain.ColHeader clickedCol = (frmMain.ColHeader)this.listView1.Columns[e.Column];
            clickedCol.@ascending = !clickedCol.@ascending;
            int numItems = this.listView1.Items.Count;
            this.listView1.BeginUpdate();

            ArrayList SortArray = new ArrayList();
            int i = 0;
            for (i = 0; i <= numItems - 1; i++)
            {
                SortArray.Add(new frmMain.SortWrapper(this.listView1.Items[i], e.Column));
            }

            SortArray.Sort(0, SortArray.Count, new frmMain.SortWrapper.SortComparer(clickedCol.@ascending));

            this.listView1.Items.Clear();
            int z = 0;
            for (z = 0; z <= numItems - 1; z++)
            {
                this.listView1.Items.Add(((frmMain.SortWrapper)SortArray[z]).sortItem);
            }

            this.listView1.EndUpdate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.AutoCompleteCustomSource.Clear();
            ArrayList al = new ArrayList();
            if (comboBox1.Text == "과목명")
            {
                foreach (Bot.SubjectStruct ss in subject)
                    if (!al.Contains(ss.과목명)) al.Add(ss.과목명);
            }
            else if (comboBox1.Text == "학수번호")
            {
                foreach (Bot.SubjectStruct ss in subject)
                    if (!al.Contains(ss.학수번호)) al.Add(ss.학수번호);
            }
            textBox1.AutoCompleteCustomSource.AddRange(al.ToArray(typeof(string)) as string[]);
        }

        ArrayList subject_group = new ArrayList();

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBox1.Text == "과목명")
                {
                    ArrayList subjects = new ArrayList();
                    foreach (Bot.SubjectStruct ss in subject)
                    {
                        if (ss.과목명 == textBox1.Text)
                        {
                            TimeElement te = TimeParser.Get(ss.시강);
                            te.index = ss.index.ToString();
                            subjects.Add(te);
                            AppendSubjectToList(ss);
                        }
                    }
                    subject_group.Add(subjects);
                }
                else if (comboBox1.Text == "학수번호")
                {
                    ArrayList subjects = new ArrayList();
                    foreach (Bot.SubjectStruct ss in subject)
                    {
                        if (ss.학수번호 == textBox1.Text)
                        {
                            TimeElement te = TimeParser.Get(ss.시강);
                            te.index = ss.index.ToString();
                            subjects.Add(te);
                            AppendSubjectToList(ss);
                        }
                    }
                    subject_group.Add(subjects);
                }
            }
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (ListViewItem lvi in listView1.SelectedItems)
                {
                    DelLVI(lvi);
                }
            }
        }

        private void DelLVI(ListViewItem lvi)
        {
            string vi = lvi.SubItems[0].Text;
            lvi.Remove();
            for (int i = 0; i < subject_group.Count; i++)
            {
                for (int j = 0; j < ((ArrayList)subject_group[i]).Count; j++)
                {
                    if (((TimeElement)((ArrayList)subject_group[i])[j]).index.ToString() == vi)
                    {
                        ((ArrayList)subject_group[i]).RemoveAt(j);
                        if (((ArrayList)subject_group[i]).Count == 0)
                            subject_group.RemoveAt(i);
                        return;
                    }
                }
            }
        }

        private void AppendSubjectToList(Bot.SubjectStruct ss)
        {
            listView1.Items.Add(new ListViewItem(new string[] { ss.index.ToString(),
                ss.필드, ss.학수번호, ss.분반, ss.과목명, ss.학년, ss.학점,
                ss.구분, ss.시강, ss.교수, ss.평가, ss.비고 }));
        }

        bool escape = false;
        ArrayList result = new ArrayList();
        TimeTable AccessTable;
        Stack<string> stack = new Stack<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            result.Clear();
            AccessTable = new TimeTable();
            stack.Clear();
            if ( subject_group.Count > 1 )
            {
                for ( int i = 0; i < ((ArrayList)subject_group[0]).Count; i++ )
                {
                    stack.Push(((TimeElement)(((ArrayList)subject_group[0])[i])).index);
                    AccessTable.Add((TimeElement)(((ArrayList)subject_group[0])[i]));
                    Iterate(1);
                    stack.Pop();
                    AccessTable.Del((TimeElement)(((ArrayList)subject_group[0])[i]));
                    if (escape)
                        break;
                }
            }
            StringBuilder builder = new StringBuilder();
            foreach (string r in result)
                builder.Append(r + '\n');
            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"combinations.txt", builder.ToString());
            escape = false;
            MessageBox.Show("생성완료!\n생성횟수: " + result.Count, Version.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Iterate(int iter)
        {
            if (escape)
                return;
            if ( subject_group.Count == iter )
            {
                StringBuilder builder = new StringBuilder();
                foreach (string s in stack)
                    builder.Append(s + '|');
                result.Add(builder.ToString());
                if (result.Count >= numericUpDown1.Value)
                    escape = true;
                return;
            }
            for (int i = 0; i < ((ArrayList)subject_group[iter]).Count; i++)
            {
                if (AccessTable.CheckOverlap((TimeElement)(((ArrayList)subject_group[iter])[i])))
                    continue;
                stack.Push(((TimeElement)(((ArrayList)subject_group[iter])[i])).index);
                AccessTable.Add((TimeElement)(((ArrayList)subject_group[iter])[i]));
                Iterate(iter + 1);
                stack.Pop();
                AccessTable.Del((TimeElement)(((ArrayList)subject_group[iter])[i]));
                if (escape)
                    return;
            }
        }

        private void DelDay(int k)
        {
            for (int i = 0; i < subject_group.Count; i++)
                for (int j = 0; j < ((ArrayList)subject_group[i]).Count; j++)
                {
                    if (checkBox1.Checked && ((Bot.SubjectStruct)(subject[Convert.ToInt32(((TimeElement)(((ArrayList)subject_group[i])[j])).index)])).구분 == "전공필수")
                        break;
                    if (checkBox2.Checked && ((Bot.SubjectStruct)(subject[Convert.ToInt32(((TimeElement)(((ArrayList)subject_group[i])[j])).index)])).구분 == "교양필수")
                        break;
                    if (((TimeElement)(((ArrayList)subject_group[i])[j])).IsFillDay(k))
                    {
                        foreach (ListViewItem lvi in listView1.Items)
                            if (lvi.SubItems[0].Text == ((TimeElement)(((ArrayList)subject_group[i])[j])).index)
                            { DelLVI(lvi); break; }
                        j--;
                    }
                }
        }

        private void button2_Click(object sender, EventArgs e)
        { DelDay(0); }
        private void button3_Click(object sender, EventArgs e)
        { DelDay(1); }
        private void button5_Click(object sender, EventArgs e)
        { DelDay(2); }
        private void button4_Click(object sender, EventArgs e)
        { DelDay(3); }
        private void button6_Click(object sender, EventArgs e)
        { DelDay(4); }

        private void button8_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listView1.Items)
                if (lvi.SubItems[7].Text.Contains("선택"))
                    DelLVI(lvi);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listView1.Items)
                if (lvi.SubItems[7].Text.Contains("교양"))
                    DelLVI(lvi);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < subject_group.Count; i++)
                for (int j = 0; j < ((ArrayList)subject_group[i]).Count; j++)
                {
                    if (((TimeElement)(((ArrayList)subject_group[i])[j])).te.Count == 0)
                    {
                        foreach (ListViewItem lvi in listView1.Items)
                            if (lvi.SubItems[0].Text == ((TimeElement)(((ArrayList)subject_group[i])[j])).index)
                            { DelLVI(lvi); break; }
                        j--;
                    }
                }
        }
    }
}
