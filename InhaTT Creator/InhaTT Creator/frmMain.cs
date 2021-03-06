﻿/***

   Copyright (C) 2017. rollrat. All Rights Reserved.

   05-13-2017:   HyunJun Jeong, Creation

***/

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
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
            InitSearchView();

            Text += " (" + bot.subject.Count + "개의 로드된 과목)";
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
        /// 검색뷰어 컬럼
        /// </summary>
        private void InitSearchView()
        {
            // 일반 컬럼 헤더를 ColHeader로 변환
            List<ColHeader> columnsTrans = new List<ColHeader>();
            foreach (ColumnHeader column in lvSearch.Columns)
            {
                columnsTrans.Add(new ColHeader(column.Text, column.Width, column.TextAlign, true));
            }
            lvSearch.Columns.Clear();
            lvSearch.Columns.AddRange(columnsTrans.ToArray());
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
            // 이 함수는 윈도우 파일시스템 정렬용으로 만들어진 string compare함수입니다.
            return StrCmpLogicalW(addr1, addr2);
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

        /// <summary>
        /// 실행취소/다시실행을 위한 스택입니다.
        /// </summary>
        Stack<List<List<TimeElement>>> redo_stack = new Stack<List<List<TimeElement>>>();
        Stack<List<List<TimeElement>>> undo_stack = new Stack<List<List<TimeElement>>>();

        BigInteger comb;

        private void UpdateCombination()
        {
            comb = 1;
            for (int i = 0; i < subject_group.Count; i++)
                comb *= subject_group[i].Count;
            lComb.Text = comb.ToString("#,#");
        }

        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // 중복 검사
                for (int i = 0; i < subject_group.Count; i++)
                    if ((cbSearch.Text == "과목명" && bot.subject[Convert.ToInt32(subject_group[i][0].index)].과목명 == tbSearch.Text) ||
                        (cbSearch.Text == "학수번호" && bot.subject[Convert.ToInt32(subject_group[i][0].index)].학수번호 == tbSearch.Text))
                    {
                        MessageBox.Show("같은 과목이 이미 추가되었습니다.", Version.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                PushUndo();

                // 리스트에 항목 추가
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
                UpdateCombination();
                Task.Run(() => EstimateCountOfResult());
            }
        }

        /// <summary>
        /// 시간표의 생성 경우의 수를 보여줍니다.
        /// </summary>
        private void EstimateCountOfResult()
        {
            // 시간표 생성
            TimeTableGenerator generator = new TimeTableGenerator();
            if (subject_group.Count > 1)
            {
                lCount.Invoke(new Action(() => lCount.Text = "산출중..."));
                generator.StartCreate(subject_group, !cbContinuity.Checked);
                lCount.Invoke(new Action(() => lCount.Text = generator.GetResultCount().ToString()));
            }
        }

        /// <summary>
        /// 특정 과목을 강제로 추가합니다.
        /// </summary>
        public void DoAddSubject(int index)
        {
            PushUndo();

            foreach (List<TimeElement> lte in subject_group)
                foreach (TimeElement te in lte)
                    if ( te.index == index.ToString() )
                    {
                        MessageBox.Show("같은 과목이 이미 추가되었습니다.", Version.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

            // 같은 이름을 가진 과목을 찾는다
            for (int i = 0; i < subject_group.Count; i++)
                if (bot.subject[Convert.ToInt32(subject_group[i][0].index)].과목명 == bot.subject[index].과목명)
                {
                    TimeElement te = TimeParser.Get(bot.subject[index].시강);
                    te.index = index.ToString();
                    subject_group[i].Add(te);
                    return;
                }

            // 같은 이름을 가진 과목이 없다면 새로 만든다.
            List<Bot.SubjectStruct> ssl = new List<Bot.SubjectStruct>();
            List<TimeElement> subjects = new List<TimeElement>();
            TimeElement ite = TimeParser.Get(bot.subject[index].시강);
            ite.index = index.ToString();
            subjects.Add(ite);
            ssl.Add(bot.subject[index]);
            subject_group.Add(subjects);

            AppendSubjectsToList(ssl);
            UpdateCombination();
        }

        /// <summary>
        /// frmTTViewer에서 '이 시간표를 기반으로 시간표 만들기'버튼을 누를때 이 함수가 호출됩니다.
        /// </summary>
        public void DoFixedMode(List<TimeElement> subject)
        {
            PushUndo();
            subject_group.Clear();

            List<Bot.SubjectStruct> ssl = new List<Bot.SubjectStruct>();
            foreach (TimeElement tex in subject)
            {
                Bot.SubjectStruct ss = bot.subject[Convert.ToInt32(tex.index)];
                List<TimeElement> subjects = new List<TimeElement>();
                TimeElement te = TimeParser.Get(ss.시강);
                te.index = ss.index.ToString();
                subjects.Add(te);
                ssl.Add(ss);
                subject_group.Add(subjects);
            }

            lvSearch.Items.Clear();
            AppendSubjectsToList(ssl);
            UpdateCombination();
        }

        #region 스택처리

        private void ClearStack()
        {
            redo_stack.Clear();
            undo_stack.Clear();
        }

        private void PushRedo()
        {
            List<List<TimeElement>> push_list = new List<List<TimeElement>>();
            subject_group.ForEach((te) => { push_list.Add(new List<TimeElement>(te)); });
            redo_stack.Push(new List<List<TimeElement>>(subject_group));
            UpdateCombination();
        }
        private void PopRedo()
        {
            if (redo_stack.Count > 0)
            {
                PushUndoInPopRedo();
                subject_group = redo_stack.Pop();
                UpdateCombination();

                List<Bot.SubjectStruct> ssl = new List<Bot.SubjectStruct>();
                foreach (List<TimeElement> lte in subject_group)
                    foreach (TimeElement te in lte)
                        ssl.Add(bot.subject[Convert.ToInt32(te.index)]);
                lvSearch.Items.Clear();
                AppendSubjectsToList(ssl);
                UpdateCombination();
            }
        }

        private void PushUndo()
        {
            if (redo_stack.Count > 0) redo_stack.Clear();
            List<List<TimeElement>> push_list = new List<List<TimeElement>>();
            subject_group.ForEach((te) => { push_list.Add(new List<TimeElement>(te)); });
            undo_stack.Push(push_list);
            UpdateCombination();
        }
        private void PushUndoInPopRedo()
        {
            List<List<TimeElement>> push_list = new List<List<TimeElement>>();
            subject_group.ForEach((te) => { push_list.Add(new List<TimeElement>(te)); });
            undo_stack.Push(push_list);
            UpdateCombination();
        }
        private void PopUndo()
        {
            if (undo_stack.Count > 0)
            {
                PushRedo();
                subject_group = undo_stack.Pop();
                UpdateCombination();

                List<Bot.SubjectStruct> ssl = new List<Bot.SubjectStruct>();
                foreach (List<TimeElement> lte in subject_group)
                    foreach (TimeElement te in lte)
                        ssl.Add(bot.subject[Convert.ToInt32(te.index)]);
                lvSearch.Items.Clear();
                AppendSubjectsToList(ssl);
                UpdateCombination();
            }
        }

        #endregion

        #region 테스트

        private void bStart_Click(object sender, EventArgs e)
        {
            PushUndo();

            // 웹강의 삭제
            List<ListViewItem> lvil = new List<ListViewItem>(getLviArray());
            for (int i = 0; i < lvil.Count;)
            {
                if (TimeParser.Get(lvil[i].SubItems[8].Text).te.Count == 0)
                { DelInIndex(lvil[i].SubItems[0].Text); lvil.RemoveAt(i); }
                else i++;
            }
            lvSearch.Items.Clear();
            lvSearch.Items.AddRange(lvil.ToArray());

            // 시간표 생성
            TimeTableGenerator generator = new TimeTableGenerator();
            if (subject_group.Count > 1)
            {
                // 시간표 테스트 샘플을 크기에 대한 내림차순으로 정렬합니다.
                // 이 정렬을 통해 더 고른 샘플을 추출할 수 있습니다.
                subject_group.Sort((v1, v2) => v2.Count.CompareTo(v1.Count));
                generator.StartCreate(subject_group, !cbContinuity.Checked);
            }

            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"combinations.txt", generator.GetResult());

            MessageBox.Show("생성완료!\n생성횟수: " + generator.GetResultCount(), Version.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
            (new frmTTViewer(bot.subject)).Show();
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
            PushUndo();
            List<ListViewItem> lvil = new List<ListViewItem>(getLviArray());
            for (int i = 0; i < lvil.Count;)
            {
                if (TimeParser.Get(lvil[i].SubItems[8].Text).IsFillDay(k))
                { DelInIndex(lvil[i].SubItems[0].Text); lvil.RemoveAt(i); }
                else i++;
            }
            lvSearch.Items.Clear();
            lvSearch.Items.AddRange(lvil.ToArray());
            UpdateCombination();
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
                PushUndo();
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
                UpdateCombination();
            }
        }

        private void bDelClass_Click(object sender, EventArgs e)
        {
            PushUndo();
            List<ListViewItem> lvil = new List<ListViewItem>(getLviArray());
            for (int i = 0; i < lvil.Count;)
            {
                if (TimeParser.Get(lvil[i].SubItems[8].Text).IsFillTime((int)numClass.Value))
                { DelInIndex(lvil[i].SubItems[0].Text); lvil.RemoveAt(i); }
                else i++;
            }
            lvSearch.Items.Clear();
            lvSearch.Items.AddRange(lvil.ToArray());
            UpdateCombination();
        }

        private void bFix_Click(object sender, EventArgs e)
        {
            if (lvSearch.SelectedItems.Count > 0)
            {
                PushUndo();
                List<string> ix = new List<string>();
                List<ListViewItem> lvil = new List<ListViewItem>(getLviArray());
                foreach (ListViewItem lvi in lvSearch.SelectedItems)
                    ix.Add(lvi.SubItems[0].Text);

                /* subject_group에서 선택한 과목과 동일한 과목을 찾는다. */
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
                UpdateCombination();
            }
        }

        #endregion

        #region 메뉴 스트립

        private void 다시실행ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopRedo();
        }

        private void 실행취소ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopUndo();
        }

        private void 삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PushUndo();
            foreach (ListViewItem lvi in lvSearch.SelectedItems)
            { DelInIndex(lvi.SubItems[0].Text); lvi.Remove(); }
            UpdateCombination();
        }

        private void 생성된시간표ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmTTViewer(bot.subject)).Show();
        }

        private void 과목분석기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmAnalyzer()).Show();
        }

        private void 설명서ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmManual()).Show();
        }

        private void 정보IToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmInfo()).Show();
        }

        private void 도움말ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmHelp()).Show();
        }

        #endregion

    }
}
