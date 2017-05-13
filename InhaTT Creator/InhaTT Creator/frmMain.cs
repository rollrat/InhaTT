/***

   Copyright (C) 2017. rollrat. All Rights Reserved.

   05-13-2017:   HyunJun Jeong, Creation

***/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace InhaTT_Creator
{
    public partial class frmMain : Form
    {
        static public string PathData = AppDomain.CurrentDomain.BaseDirectory + @"datas";
        static public string PathCombinations = AppDomain.CurrentDomain.BaseDirectory + @"combinations.txt";

        public Bot bot = new Bot();

        public bool IsOpenSafety = true;

        public frmMain()
        {
            // 데이터 파일이 존재하지 않으면 프로그램을 종료시킴
            if (!File.Exists(PathData))
            {
                MessageBox.Show("데이터 파일을 찾을 수 없습니다.", Version.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                IsOpenSafety = false;
                return;
            }

            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Text += Version.Text;

            InitDatas();
            InitGUI();
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

        /// <summary>
        /// 서브젝트 리스트 정보를 모두 검색 뷰어에 출력합니다.
        /// </summary>
        private void AppendSubjectsToList(List<Bot.SubjectStruct> ssl)
        {
            List<ListViewItem> lvil = new List<ListViewItem>();
            foreach (Bot.SubjectStruct ss in ssl)
            {
                lvil.Add(new ListViewItem(new string[] { ss.index.ToString(),
                    ss.필드, ss.학수번호, ss.분반, ss.과목명, ss.학년, ss.학점,
                    ss.구분, ss.시강, ss.교수, ss.평가, ss.비고 }));
            }
            lvSearch.Items.AddRange(lvil.ToArray());
        }

        #region 프로그램 초기화

        private void InitGUI()
        {
            cbSearch.Text = "과목명";
            tbSearch.AutoCompleteCustomSource.Clear();
            ArrayList al = new ArrayList();
            foreach (Bot.SubjectStruct ss in bot.subject)
                if (!al.Contains(ss.과목명)) al.Add(ss.과목명);
            tbSearch.AutoCompleteCustomSource.AddRange(al.ToArray(typeof(string)) as string[]);
        }

        /// <summary>
        /// 과목 데이터 불러오기
        /// </summary>
        private void InitDatas()
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(PathData);
            while ((line = file.ReadLine()) != null)
            {
                bot.ParseSubject(line);
            }
            file.Close();
        }

        #endregion

        #region Column 작업
        
        #region ColHeader 구현부
        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
        public static extern int StrCmpLogicalW(string psz1, string psz2);

        public static int ComparePath(string addr1, string addr2)
        {
            return StrCmpLogicalW(addr1, addr2);
        }
        public static bool IsNumeric(string input)
        {
            int test;
            return int.TryParse(input, out test);
        }
        public class PathComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                return StrCmpLogicalW((string)x, (string)y);
            }
        }
        public static IComparer GetPathComparer()
        {
            return (IComparer)new PathComparer();
        }

        public class SortWrapper
        {
            internal ListViewItem sortItem;

            internal int sortColumn;
            public SortWrapper(ListViewItem Item, int iColumn)
            {
                sortItem = Item;
                sortColumn = iColumn;
            }

            public string Text
            {
                get { return sortItem.SubItems[sortColumn].Text; }
            }

            public class SortComparer : IComparer
            {
                private bool @ascending;
                public SortComparer(bool asc)
                {
                    this.@ascending = asc;
                }

                public int Compare(object x, object y)
                {
                    if ((x == null) | (y == null))
                        return 0;

                    SortWrapper xItem = (SortWrapper)x;
                    SortWrapper yItem = (SortWrapper)y;

                    string xText = xItem.sortItem.SubItems[xItem.sortColumn].Text;
                    string yText = yItem.sortItem.SubItems[yItem.sortColumn].Text;

                    return ComparePath(xText, yText) * (this.@ascending ? 1 : -1);
                }
            }
        }

        public class ColHeader : ColumnHeader
        {

            public bool @ascending;
            public ColHeader(string text, int width, HorizontalAlignment align, bool asc)
            {
                this.Text = text;
                this.Width = width;
                this.TextAlign = align;
                this.@ascending = asc;
            }
        }
        #endregion

        private void lvSearch_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColHeader clickedCol = (ColHeader)this.lvSearch.Columns[e.Column];
            clickedCol.@ascending = !clickedCol.@ascending;
            int numItems = this.lvSearch.Items.Count;
            this.lvSearch.BeginUpdate();

            ArrayList SortArray = new ArrayList();
            int i = 0;
            for (i = 0; i <= numItems - 1; i++)
            {
                SortArray.Add(new SortWrapper(this.lvSearch.Items[i], e.Column));
            }

            SortArray.Sort(0, SortArray.Count, new SortWrapper.SortComparer(clickedCol.@ascending));

            this.lvSearch.Items.Clear();
            int z = 0;
            for (z = 0; z <= numItems - 1; z++)
            {
                this.lvSearch.Items.Add(((SortWrapper)SortArray[z]).sortItem);
            }

            this.lvSearch.EndUpdate();
        }
        #endregion

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearch.AutoCompleteCustomSource.Clear();
            ArrayList al = new ArrayList();
            if (cbSearch.Text == "과목명")
            {
                foreach (Bot.SubjectStruct ss in bot.subject)
                    if (!al.Contains(ss.과목명)) al.Add(ss.과목명);
            }
            else if (cbSearch.Text == "학수번호")
            {
                foreach (Bot.SubjectStruct ss in bot.subject)
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
                // 중복 검사
                for (int i = 0; i < subject_group.Count; i++)
                    if (bot.subject[Convert.ToInt32(subject_group[i][0].index)].과목명 == tbSearch.Text)
                    {
                        MessageBox.Show("같은 과목이 이미 추가되었습니다.", Version.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                // 추가
                List<TimeElement> subjects = new List<TimeElement>();
                List<Bot.SubjectStruct> ssl = new List<Bot.SubjectStruct>();
                if (cbSearch.Text == "과목명")
                {
                    foreach (Bot.SubjectStruct ss in bot.subject)
                    {
                        if (ss.과목명 == tbSearch.Text)
                        {
                            TimeElement te = TimeParser.Get(ss.시강);
                            te.index = ss.index.ToString();
                            subjects.Add(te);
                            ssl.Add(ss);
                        }
                    }
                }
                else if (cbSearch.Text == "학수번호")
                {
                    foreach (Bot.SubjectStruct ss in bot.subject)
                    {
                        if (ss.학수번호 == tbSearch.Text)
                        {
                            TimeElement te = TimeParser.Get(ss.시강);
                            te.index = ss.index.ToString();
                            subjects.Add(te);
                            ssl.Add(ss);
                        }
                    }
                }
                if (ssl.Count == 0) return;
                AppendSubjectsToList(ssl);
                subject_group.Add(subjects);
            }
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

        /// <summary>
        /// maxShowCount : 사용자에게 보여줄 최종생성경우의 수 입니다.
        /// maxPannelCount : 추출할 모든 경우의 수 입니다.
        /// </summary>
        const int maxShowCount = 100;
        const int maxPannelCount = 100000;

        private void bStart_Click(object sender, EventArgs e)
        {
            // 웹 강의 삭제
            List<ListViewItem> lvil = new List<ListViewItem>(getLviArray());
            for (int i = 0; i < lvil.Count;)
            {
                if (TimeParser.Get(lvil[i].SubItems[8].Text).te.Count == 0)
                { DelInIndex(lvil[i].SubItems[0].Text); lvil.RemoveAt(i); }
                else i++;
            }
            result.Clear();
            AccessTable = new TimeTable();
            stack.Clear();
            if (subject_group.Count > 1)
            {
                subject_group.Sort((v1, v2) => v2.Count.CompareTo(v1.Count));
                for (int i = 0; i < subject_group[0].Count; i++)
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
            result = result.OrderBy(a => Guid.NewGuid()).ToList();
            if (result.Count > maxShowCount)
                result.RemoveRange(maxShowCount, result.Count - maxShowCount);
            StringBuilder builder = new StringBuilder();
            foreach (string r in result)
                builder.Append(r + '\n');
            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"combinations.txt", builder.ToString());
            escape = false;
            MessageBox.Show("생성완료!\n생성횟수: " + result.Count, Version.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
            (new frmTTViewer(bot.subject)).Show();
        }

        private void Iterate(int iter)
        {
            if (escape) return;
            if (subject_group.Count == iter)
            {
                StringBuilder builder = new StringBuilder();
                foreach (string s in stack)
                    builder.Append(s + '|');
                result.Add(builder.ToString());
                if (result.Count >= maxPannelCount)
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

        /// <summary>
        /// 어떤 과목이 완벽히 삭제되었는지 확인합니다.
        /// 이때, 해당 과목이 완벽히 삭제되었다면, for문의 i++가 
        /// 생략되어야 하므로, i에다 1을 감산합니다.
        /// </summary>
        private int CheckDelComplete(string ix, int i)
        {
            if (subject_group[i].Count == 0)
            {
                subject_group.RemoveAt(i--);
                MessageBox.Show($"\"{bot.subject[Convert.ToInt32(ix)].과목명}\" 과목이 완전히 삭제되었습니다.",
                    Version.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return i;
        }

        /// <summary>
        /// 해당 인덱스를 가진 과목을 삭제합니다.
        /// </summary>
        private void DelInIndex(string vi)
        {
            for (int i = 0; i < subject_group.Count; i++)
            {
                for (int j = 0; j < subject_group[i].Count; j++)
                {
                    string ix = subject_group[i][j].index;
                    if (ix == vi)
                    {
                        subject_group[i].RemoveAt(j);
                        i = CheckDelComplete(ix, i);
                        return;
                    }
                }
            }
        }

        private void lvSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                foreach (ListViewItem lvi in lvSearch.SelectedItems)
                { DelInIndex(lvi.SubItems[0].Text); lvi.Remove(); }
        }

        private ListViewItem[] getLviArray()
        {
            ListViewItem[] items = new ListViewItem[lvSearch.Items.Count];
            lvSearch.Items.CopyTo(items, 0);
            return items;
        }

        /// <summary>
        /// k번째 요일의 모든 과목을 삭제합니다.
        /// </summary>
        private void DelDay(int k)
        {
            List<ListViewItem> lvil = new List<ListViewItem>(getLviArray());
            for (int i = 0; i < lvil.Count;)
            {
                if (TimeParser.Get(lvil[i].SubItems[8].Text).IsFillDay(k))
                { DelInIndex(lvil[i].SubItems[0].Text); lvil.RemoveAt(i); }
                else i++;
            }
            lvSearch.Items.Clear();
            lvSearch.Items.AddRange(lvil.ToArray());
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

        /// <summary>
        /// 어떤 한 과목을 완전히 삭제합니다.
        /// </summary>
        private void bDel9_Click(object sender, EventArgs e)
        {
            if (lvSearch.SelectedItems.Count > 0)
            {
                List<ListViewItem> lvil = new List<ListViewItem>(getLviArray());
                int i = 0;
                string sbj = lvSearch.SelectedItems[0].SubItems[4].Text;
                for (; i < subject_group.Count; i++)
                {
                    bool success = false;
                    for (int j = 0; j < subject_group[i].Count;)
                        if (subject_group[i][j].index == lvSearch.SelectedItems[0].SubItems[0].Text)
                        {
                            foreach (TimeElement te in subject_group[i])
                                for (int k = 0; k < lvil.Count;)
                                    if (lvil[k].SubItems[0].Text == te.index)
                                    { lvil.RemoveAt(k); break; }
                                    else k++;
                            success = true;
                            break;
                        }
                        else j++;
                    if (success) break;
                }
                subject_group.RemoveAt(i);
                lvSearch.Items.Clear();
                lvSearch.Items.AddRange(lvil.ToArray());
                MessageBox.Show($"\"{sbj}\" 과목이 완전히 삭제되었습니다.",
                    Version.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bDelClass_Click(object sender, EventArgs e)
        {
            List<ListViewItem> lvil = new List<ListViewItem>(getLviArray());
            for (int i = 0; i < lvil.Count;)
            {
                if (TimeParser.Get(lvil[i].SubItems[8].Text).IsFillTime((int)numClass.Value))
                { DelInIndex(lvil[i].SubItems[0].Text); lvil.RemoveAt(i); }
                else i++;
            }
            lvSearch.Items.Clear();
            lvSearch.Items.AddRange(lvil.ToArray());
        }

        private void bFix_Click(object sender, EventArgs e)
        {
            if (lvSearch.SelectedItems.Count > 0)
            {
                List<string> ix = new List<string>();
                List<ListViewItem> lvil = new List<ListViewItem>(getLviArray());
                foreach (ListViewItem lvi in lvSearch.SelectedItems)
                    ix.Add(lvi.SubItems[0].Text);
                int i = 0;
                for (; i < subject_group.Count; i++)
                    for (int j = 0; j < subject_group[i].Count; j++)
                        if (subject_group[i][j].index == lvSearch.SelectedItems[0].SubItems[0].Text)
                            goto EX;
                EX:
                for (int j = 0; j < subject_group[i].Count;)
                    if (!ix.Contains(subject_group[i][j].index))
                    {
                        for (int k = 0; k < lvil.Count; k++)
                            if (lvil[k].SubItems[0].Text == subject_group[i][j].index)
                            { lvil.RemoveAt(k); break; }
                        subject_group[i].RemoveAt(j);
                    }
                    else j++;
                lvSearch.Items.Clear();
                lvSearch.Items.AddRange(lvil.ToArray());
            }
        }
        #endregion

        private void 생성된시간표ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmTTViewer(bot.subject)).Show();
        }

        private void 과목분석기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmAnalyzer()).Show();
        }
    }
}
