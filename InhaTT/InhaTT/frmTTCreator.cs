/***

   Copyright (C) 2017. rollrat. All Rights Reserved.

   04-20-2017:   HyunJun Jeong, Creation

***/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace InhaTT
{
    public partial class frmTTCreator : Form
    {
        List<Bot.SubjectStruct> subject;

        public frmTTCreator(List<Bot.SubjectStruct> al)
        {
            InitializeComponent();

            subject = al;
        }

        private void frmTTCreator_Load(object sender, EventArgs e)
        {
            cbSearch.Text = "과목명";
            tbSearch.AutoCompleteCustomSource.Clear();
            ArrayList al = new ArrayList();
            foreach (Bot.SubjectStruct ss in subject)
                if (!al.Contains(ss.과목명)) al.Add(ss.과목명);
            tbSearch.AutoCompleteCustomSource.AddRange(al.ToArray(typeof(string)) as string[]);
            
            // 리스트뷰-컬럼 to ColHeader
            List<frmMain.ColHeader> columnsTrans = new List<frmMain.ColHeader>();
            foreach (ColumnHeader column in lvSearch.Columns)
            {
                columnsTrans.Add(new frmMain.ColHeader(column.Text, column.Width, column.TextAlign, true));
            }
            lvSearch.Columns.Clear();
            lvSearch.Columns.AddRange(columnsTrans.ToArray());
        }
        
        private void lvSearch_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            frmMain.ColHeader clickedCol = (frmMain.ColHeader)this.lvSearch.Columns[e.Column];
            clickedCol.@ascending = !clickedCol.@ascending;
            int numItems = this.lvSearch.Items.Count;
            this.lvSearch.BeginUpdate();

            ArrayList SortArray = new ArrayList();
            int i = 0;
            for (i = 0; i <= numItems - 1; i++)
            {
                SortArray.Add(new frmMain.SortWrapper(this.lvSearch.Items[i], e.Column));
            }

            SortArray.Sort(0, SortArray.Count, new frmMain.SortWrapper.SortComparer(clickedCol.@ascending));

            this.lvSearch.Items.Clear();
            int z = 0;
            for (z = 0; z <= numItems - 1; z++)
            {
                this.lvSearch.Items.Add(((frmMain.SortWrapper)SortArray[z]).sortItem);
            }

            this.lvSearch.EndUpdate();
        }
        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearch.AutoCompleteCustomSource.Clear();
            ArrayList al = new ArrayList();
            if (cbSearch.Text == "과목명")
            {
                foreach (Bot.SubjectStruct ss in subject)
                    if (!al.Contains(ss.과목명)) al.Add(ss.과목명);
            }
            else if (cbSearch.Text == "학수번호")
            {
                foreach (Bot.SubjectStruct ss in subject)
                    if (!al.Contains(ss.학수번호)) al.Add(ss.학수번호);
            }
            tbSearch.AutoCompleteCustomSource.AddRange(al.ToArray(typeof(string)) as string[]);
        }

        /// <summary>
        /// 검색 테스트 케이스를 저장합니다.
        /// 상위 리스트엔 각 과목명에 해당하는 리스트가,
        /// 하위 리스트엔 과목명이 같은 과목들이 저장됩니다.
        /// </summary>
        List<List<TimeElement>> subject_group = new List<List<TimeElement>>();

        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                List<TimeElement> subjects = new List<TimeElement>();
                if (cbSearch.Text == "과목명")
                {
                    foreach (Bot.SubjectStruct ss in subject)
                    {
                        if (ss.과목명 == tbSearch.Text)
                        {
                            TimeElement te = TimeParser.Get(ss.시강);
                            te.index = ss.index.ToString();
                            subjects.Add(te);
                            AppendSubjectToList(ss);
                        }
                    }
                }
                else if (cbSearch.Text == "학수번호")
                {
                    foreach (Bot.SubjectStruct ss in subject)
                    {
                        if (ss.학수번호 == tbSearch.Text)
                        {
                            TimeElement te = TimeParser.Get(ss.시강);
                            te.index = ss.index.ToString();
                            subjects.Add(te);
                            AppendSubjectToList(ss);
                        }
                    }
                }
                subject_group.Add(subjects);
            }
        }
        private void lvSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (ListViewItem lvi in lvSearch.SelectedItems)
                {
                    DelLVI(lvi);
                }
            }
        }

        /// <summary>
        /// 서브젝트 정보를 검색 뷰어에 출력합니다.
        /// </summary>
        private void AppendSubjectToList(Bot.SubjectStruct ss)
        {
            lvSearch.Items.Add(new ListViewItem(new string[] { ss.index.ToString(),
                ss.필드, ss.학수번호, ss.분반, ss.과목명, ss.학년, ss.학점,
                ss.구분, ss.시강, ss.교수, ss.평가, ss.비고 }));
        }

        #region 테스트
        /// <summary>
        /// 시간표가 겹치는지의 여부를 확인하기 위한 시험용 테이블 입니다.
        /// </summary>
        TimeTable AccessTable;

        /// <summary>
        /// escape: esacpe가 True이면 iteration을 탈출합니다.
        /// </summary>
        bool escape = false;
        List<string> result = new List<string>();
        Stack<string> stack = new Stack<string>();

        private void bStart_Click(object sender, EventArgs e)
        {
            result.Clear();
            AccessTable = new TimeTable();
            stack.Clear();
            if ( subject_group.Count > 1 )
            {
                for ( int i = 0; i < subject_group[0].Count; i++ )
                {
                    stack.Push(subject_group[0][i].index);
                    AccessTable.Add(subject_group[0][i]);
                    Iterate(1);
                    stack.Pop();
                    AccessTable.Del(subject_group[0][i]);
                    if (escape)
                        break;
                }
            }
            StringBuilder builder = new StringBuilder();
            foreach (string r in result)
                builder.Append(r + '\n');
            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"combinations.txt", builder.ToString());
            escape = false;
            Program.m.ActivateTTListButton();
            MessageBox.Show("생성완료!\n생성횟수: " + result.Count, Version.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Iterate(int iter)
        {
            if (escape) return;
            if ( subject_group.Count == iter )
            {
                StringBuilder builder = new StringBuilder();
                foreach (string s in stack)
                    builder.Append(s + '|');
                result.Add(builder.ToString());
                if (result.Count >= numMax.Value)
                    escape = true;
                return;
            }
            for (int i = 0; i < subject_group[iter].Count; i++)
            {
                if (AccessTable.CheckOverlap(subject_group[iter][i]))
                    continue;
                stack.Push(subject_group[iter][i].index);
                AccessTable.Add(subject_group[iter][i]);
                Iterate(iter + 1);
                stack.Pop();
                AccessTable.Del(subject_group[iter][i]);
                if (escape)
                    return;
            }
        }
        #endregion

        #region 삭제 버튼
        private void DelLVI(ListViewItem lvi)
        {
            string vi = lvi.SubItems[0].Text;
            lvi.Remove();
            for (int i = 0; i < subject_group.Count; i++)
            {
                for (int j = 0; j < subject_group[i].Count; j++)
                {
                    string ix = subject_group[i][j].index;
                    if (ix == vi)
                    {
                        subject_group[i].RemoveAt(j);
                        if (subject_group[i].Count == 0)
                        {
                            subject_group.RemoveAt(i);
                            MessageBox.Show($"\"{subject[Convert.ToInt32(ix)].과목명}\" 과목이 완전히 삭제되었습니다.", 
                                Version.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        return;
                    }
                }
            }
        }

        private void DelDay(int k)
        {
            for (int i = 0; i < subject_group.Count; i++)
                for (int j = 0; j < subject_group[i].Count; j++)
                {
                    if (cbJunPil.Checked && subject[Convert.ToInt32(subject_group[i][j].index)].구분 == "전공필수")
                        break;
                    if (cbGyoFil.Checked && subject[Convert.ToInt32(subject_group[i][j].index)].구분 == "교양필수")
                        break;
                    if (subject_group[i][j].IsFillDay(k))
                    {
                        foreach (ListViewItem lvi in lvSearch.Items)
                            if (lvi.SubItems[0].Text == subject_group[i][j].index)
                            { DelLVI(lvi); break; }
                        j--;
                    }
                }
        }

        private void bDel1_Click(object sender, EventArgs e)
        { DelDay(0); }
        private void bDel2_Click(object sender, EventArgs e)
        { DelDay(1); }
        private void bDel3_Click(object sender, EventArgs e)
        { DelDay(2); }
        private void bDel4_Click(object sender, EventArgs e)
        { DelDay(3); }
        private void bDel5_Click(object sender, EventArgs e)
        { DelDay(4); }

        private void bDel6_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvSearch.Items)
                if (lvi.SubItems[7].Text.Contains("선택"))
                    DelLVI(lvi);
        }

        private void bDel7_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvSearch.Items)
                if (lvi.SubItems[7].Text.Contains("교양"))
                    DelLVI(lvi);
        }

        private void bDel8_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < subject_group.Count; i++)
                for (int j = 0; j < subject_group[i].Count; j++)
                {
                    if (subject_group[i][j].te.Count == 0)
                    {
                        foreach (ListViewItem lvi in lvSearch.Items)
                            if (lvi.SubItems[0].Text == subject_group[i][j].index)
                            { DelLVI(lvi); break; }
                        j--;
                    }
                }
        }
        #endregion

    }
}
