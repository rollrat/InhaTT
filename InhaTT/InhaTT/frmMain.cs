/***

   Copyright (C) 2017. rollrat. All Rights Reserved.

   03-21-2017:   HyunJun Jeong, Creation

***/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace InhaTT
{
    public partial class frmMain : Form
    {
        static public string PathData = AppDomain.CurrentDomain.BaseDirectory + @"datas";
        static public string PathCombinations = AppDomain.CurrentDomain.BaseDirectory + @"combinations.txt";
        static public string PathAutoSave = AppDomain.CurrentDomain.BaseDirectory + @".autosave";

        public Bot bot = new Bot();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Text += Version.Text;
            // 조합 파일이 존재하는 경우 도구->시간표리스트 버튼 활성화
            if (File.Exists(PathCombinations)) bList.Enabled = true;

            // 순서 변경금지
            InitDatas();
            InitSearchView();
            InitTableTime();
            InitSaveData();

            cbbSearchType.Text = "과목명";
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

        #region 프로그램 초기화
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

        /// <summary>
        /// 검색뷰어 컬럼 및 과목 데이터 세팅
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

            // 과목 데이터 출력
            foreach (Bot.SubjectStruct ss in bot.subject)
            {
                AppendSubjectToList(ss);
                Application.DoEvents();
            }
        }

        /// <summary>
        /// 테이블 뷰어의 시간 및 교시를 세팅함
        /// </summary>
        private void InitTableTime()
        {
            lvTable.Columns[0].TextAlign = HorizontalAlignment.Center;
            DateTime dt = new DateTime(1900, 1, 1, 9, 0, 0);
            for (int i = 1; i <= 25; i++)
            {
                string dtt = dt.Hour.ToString().PadLeft(2, '0') + ":" + dt.Minute.ToString().PadLeft(2, '0') + "~";
                dt = dt.AddMinutes(30);
                dtt += dt.Hour.ToString().PadLeft(2, '0') + ":" + dt.Minute.ToString().PadLeft(2, '0');
                lvTable.Items.Add(new ListViewItem(new string[] {"",
                    i.ToString().PadLeft(2, '0') + " 교시(" + dtt + ")","","","","",""}));
            }
        }

        /// <summary>
        /// 세이브 파일 불러오기
        /// </summary>
        private void InitSaveData()
        {
            if (SaveExist())
            {
                foreach (string ix in Open().Split('|'))
                    foreach (ListViewItem lvi in lvSearch.Items)
                        if (lvi.SubItems[0].Text == ix)
                        {
                            TimeElement te = TimeParser.Get(lvi.SubItems[8].Text);

                            lvSearchAdd.Items.Add((ListViewItem)lvi.Clone());
                            te.index = lvi.SubItems[0].Text;
                            tt.Add(te);
                            view_table.Add(te);
                        }
                DrawTimeTable();
            }
        }
        #endregion

        #region Column 작업

        /// <summary>
        /// AutoComplete 작업
        /// </summary>
        private void cbbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearch.AutoCompleteCustomSource.Clear();
            ArrayList al = new ArrayList();
            if (cbbSearchType.Text == "과목명")
            {
                foreach (Bot.SubjectStruct ss in bot.subject)
                    if (!al.Contains(ss.과목명))  al.Add(ss.과목명);
            }
            else if (cbbSearchType.Text == "교수")
            {
                foreach (Bot.SubjectStruct ss in bot.subject)
                    if (!al.Contains(ss.교수)) al.Add(ss.교수);
            }
            else if (cbbSearchType.Text == "필드")
            {
                foreach (Bot.SubjectStruct ss in bot.subject)
                    if (!al.Contains(ss.필드)) al.Add(ss.필드);
            }
            else if (cbbSearchType.Text == "학수번호")
            {
                foreach (Bot.SubjectStruct ss in bot.subject)
                    if (!al.Contains(ss.학수번호)) al.Add(ss.학수번호);
            }
            tbSearch.AutoCompleteCustomSource.AddRange(al.ToArray(typeof(string)) as string[]);
        }

        /// <summary>
        /// 검색 구현부
        /// </summary>
        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lvSearch.Items.Clear();
                if (cbbSearchType.Text == "과목명")
                {
                    foreach (Bot.SubjectStruct ss in bot.subject)
                        if (ss.과목명.Contains(tbSearch.Text))
                            AppendSubjectToList(ss);
                }
                else if (cbbSearchType.Text == "교수")
                {
                    foreach (Bot.SubjectStruct ss in bot.subject)
                        if (ss.교수.Contains(tbSearch.Text))
                            AppendSubjectToList(ss);
                }
                else if (cbbSearchType.Text == "필드")
                {
                    foreach (Bot.SubjectStruct ss in bot.subject)
                        if (ss.필드.Contains(tbSearch.Text))
                            AppendSubjectToList(ss);
                }
                else if (cbbSearchType.Text == "학수번호")
                {
                    foreach (Bot.SubjectStruct ss in bot.subject)
                        if (ss.학수번호.Contains(tbSearch.Text))
                            AppendSubjectToList(ss);
                }
            }
        }

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

        #region 시간표

        /// <summary>
        /// 컬럼 사이즈 조정을 금지한다
        /// </summary>
        private void lvTable_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lvTable.Columns[e.ColumnIndex].Width;
        }
        
        /// <summary>
        /// 검색 뷰어에서 클릭만 했을 경우 옅은 빨간색 나타나게 해줌
        /// </summary>
        TimeElement preview = new TimeElement();
        private void lvSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSearch.SelectedItems.Count != 0)
            {
                preview = TimeParser.Get(lvSearch.SelectedItems[0].SubItems[8].Text);
                DrawTimeTable();
            }
        }

        /// <summary>
        /// "추가됨" 텝에 있는 선택한 과목 삭제
        /// </summary>
        private void lvSearchAdd_KeyDown(object sender, KeyEventArgs e)
        {
            // 모든 과목을 삭제하도록 구현예정
            if ( e.KeyCode == Keys.Delete && lvSearchAdd.SelectedItems.Count != 0)
            {
                string vi = lvSearchAdd.SelectedItems[0].SubItems[0].Text;
                if (lvSearchAdd.SelectedItems.Count != 0)
                    lvSearchAdd.SelectedItems[0].Remove();
                for (int i = 0; i < view_table.Count; i++)
                {
                    if (view_table[i].index == vi)
                    {
                        tt.Del(view_table[i]);
                        view_table.RemoveAt(i);
                        break;
                    }
                }
                Save();
                DrawTimeTable();
            }
        }

        /// <summary>
        /// view_table: 테이블 뷰어에 표시되는 과목을 저장함
        /// tt: 시간표가 겹치는지 확인을 위한 타임테이블 정보
        /// </summary>
        public List<TimeElement> view_table = new List<TimeElement>();
        TimeTable tt = new TimeTable();

        /// <summary>
        /// 시간표를 TTViewer에서 선택한 시간표로 변경한다.
        /// </summary>
        public void Trans()
        {
            Save();
            if (SaveExist())
            {
                lvSearchAdd.Items.Clear();
                // ix == index
                foreach (string ix in Open().Split('|'))
                    foreach (ListViewItem lvi in lvSearch.Items)
                        if (lvi.SubItems[0].Text == ix)
                        {
                            TimeElement te = TimeParser.Get(lvi.SubItems[8].Text);

                            lvSearchAdd.Items.Add((ListViewItem)lvi.Clone());
                            te.index = lvi.SubItems[0].Text;
                            tt.Add(te);
                            view_table.Add(te);
                        }
            }
            DrawTimeTable();
        }

        /// <summary>
        /// 선택한 과목을 테이블 뷰어에 추가한다.
        /// </summary>
        private void lvSearch_DoubleClick(object sender, EventArgs e)
        {
            if (lvSearch.SelectedItems.Count != 0)
            {
                TimeElement te = TimeParser.Get(lvSearch.SelectedItems[0].SubItems[8].Text);

                if (!tt.CheckOverlap(te))
                {
                    lvSearchAdd.Items.Add((ListViewItem)lvSearch.SelectedItems[0].Clone());
                    te.index = lvSearch.SelectedItems[0].SubItems[0].Text;
                    tt.Add(te);
                    view_table.Add(te);
                    Save();
                    DrawTimeTable(false);
                }
                else
                {
                    MessageBox.Show("이미 겹치는 항목이 존재합니다.", Version.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 괄호 사이에 포함된 모든 내용을 가져온다.
        /// 매칭되는 것이 두 개 이상일 경우 '/'를 붙인다.
        /// </summary>
        static public string getSlice(string a)
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

        private void DrawTimeTable(bool bpreview = true)
        {
            lvTable.Invalidate();
            Application.DoEvents();

            foreach (TimeElement te in view_table)
            {
                int index = Convert.ToInt32(te.index);
                Random rm = new Random(index);
                int _r = rm.Next(256), _g = rm.Next(255), _b = rm.Next(255);
                int g = -2;
                bool second = false;
                foreach (int i in te.te)
                {
                    int c = i / 25;
                    int r = i % 25;

                    lvTable.CreateGraphics().FillRectangle(new SolidBrush(
                        Color.FromArgb(200,_r,_g,_b)
                        ), lvTable.Items[r].SubItems[c + 2].Bounds);

                    if (Math.Abs(g - i) != 1) {
                        lvTable.CreateGraphics().DrawString(((Bot.SubjectStruct)bot.subject[index]).과목명,
                            lvTable.Font, Brushes.White,
                            lvTable.Items[r].SubItems[c + 2].Bounds);
                        second = true;
                    } else if ( second == true ) {
                        lvTable.CreateGraphics().DrawString(getSlice(((Bot.SubjectStruct)bot.subject[index]).시강),
                            lvTable.Font, Brushes.White,
                            lvTable.Items[r].SubItems[c + 2].Bounds);
                        second = false;
                    }

                    g = i;
                }
            }

            if (bpreview)
            // Draw Preview
            foreach (int i in preview.te)
            {
                int c = i / 25;
                int r = i % 25;
                
                lvTable.CreateGraphics().FillRectangle(new SolidBrush(Color.FromArgb(70, 255, 0, 0)), lvTable.Items[r].SubItems[c + 2].Bounds);
            }

        }

        #endregion

        #region AutoSave
        private void Save()
        {
            StringBuilder builder = new StringBuilder();
            foreach (TimeElement te in view_table)
            {
                builder.Append(te.index + "|");
            }
            System.IO.File.WriteAllText(PathAutoSave, builder.ToString());
        }
        private bool SaveExist()
        {
            return File.Exists(PathAutoSave);
        }
        private string Open()
        {
            try
            {
                return File.ReadAllLines(PathAutoSave)[0];
            }
            catch { return ""; }
        }
        #endregion

        #region 버튼
        private void bCreate_Click(object sender, EventArgs e)
        {
            (new frmTTCreator(bot.subject)).Show();
        }

        private void bList_Click(object sender, EventArgs e)
        {
            (new frmTTViewer(bot.subject)).Show();
        }

        private void bMenu_Click(object sender, EventArgs e)
        {
            (new frmManual()).Show();
        }

        private void bAnalyze_Click(object sender, EventArgs e)
        {
            (new frmAnalyzer()).Show();
        }

        public void ActivateTTListButton()
        {
            bList.Enabled = true;
        }
        #endregion

    }
}
