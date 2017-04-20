/***

   Copyright (C) 2017. rollrat. All Rights Reserved.

   03-21-2017:   HyunJun Jeong, Creation

***/

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InhaTT
{
    public partial class frmMain : Form
    {
        Bot bot = new Bot();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Text += Version.Text;

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"datas");
            while ((line = file.ReadLine()) != null)
            {
                bot.ParseSubject(line);
            }
            file.Close();

            // 리스트뷰-컬럼 to ColHeader
            List<ColHeader> columnsTrans = new List<ColHeader>();
            foreach (ColumnHeader column in listView1.Columns)
            {
                columnsTrans.Add(new ColHeader(column.Text, column.Width, column.TextAlign, true));
            }
            listView1.Columns.Clear();
            listView1.Columns.AddRange(columnsTrans.ToArray());

            foreach (Bot.SubjectStruct ss in bot.subject)
            {
                AppendSubjectToList(ss);
                Application.DoEvents();
            }

            comboBox1.Text = "과목명";

            // 리스트뷰2 교시/시간 출력
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
            
            // save 파일 불러오기
            if ( SaveExist() )
            {
                foreach (string ix in Open().Split('|'))
                    foreach (ListViewItem lvi in listView1.Items)
                        if (lvi.SubItems[0].Text == ix)
                        {
                            TimeElement te = TimeParser.Get(lvi.SubItems[8].Text);
                            
                            listView3.Items.Add((ListViewItem)lvi.Clone());
                            te.index = lvi.SubItems[0].Text;
                            tt.Add(te);
                            tet.Add(te);
                        }
                DrawTimeTable();
            }

            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"combinations.txt"))
                button5.Enabled = true;
        }

        private void AppendSubjectToList(Bot.SubjectStruct ss)
        {
            listView1.Items.Add(new ListViewItem(new string[] { ss.index.ToString(),
                ss.필드, ss.학수번호, ss.분반, ss.과목명, ss.학년, ss.학점,
                ss.구분, ss.시강, ss.교수, ss.평가, ss.비고 }));
        }
        
        #region Column 작업
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.AutoCompleteCustomSource.Clear();
            ArrayList al = new ArrayList();
            if (comboBox1.Text == "과목명")
            {
                foreach (Bot.SubjectStruct ss in bot.subject)
                    if (!al.Contains(ss.과목명))  al.Add(ss.과목명);
            }
            else if (comboBox1.Text == "교수")
            {
                foreach (Bot.SubjectStruct ss in bot.subject)
                    if (!al.Contains(ss.교수)) al.Add(ss.교수);
            }
            else if (comboBox1.Text == "필드")
            {
                foreach (Bot.SubjectStruct ss in bot.subject)
                    if (!al.Contains(ss.필드)) al.Add(ss.필드);
            }
            else if (comboBox1.Text == "학수번호")
            {
                foreach (Bot.SubjectStruct ss in bot.subject)
                    if (!al.Contains(ss.학수번호)) al.Add(ss.학수번호);
            }
            textBox1.AutoCompleteCustomSource.AddRange(al.ToArray(typeof(string)) as string[]);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listView1.Items.Clear();
                if (comboBox1.Text == "과목명")
                {
                    foreach (Bot.SubjectStruct ss in bot.subject)
                        if (ss.과목명.Contains(textBox1.Text))
                            AppendSubjectToList(ss);
                }
                else if (comboBox1.Text == "교수")
                {
                    foreach (Bot.SubjectStruct ss in bot.subject)
                        if (ss.교수.Contains(textBox1.Text))
                            AppendSubjectToList(ss);
                }
                else if (comboBox1.Text == "필드")
                {
                    foreach (Bot.SubjectStruct ss in bot.subject)
                        if (ss.필드.Contains(textBox1.Text))
                            AppendSubjectToList(ss);
                }
                else if (comboBox1.Text == "학수번호")
                {
                    foreach (Bot.SubjectStruct ss in bot.subject)
                        if (ss.학수번호.Contains(textBox1.Text))
                            AppendSubjectToList(ss);
                }
            }
        }
        
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

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColHeader clickedCol = (ColHeader)this.listView1.Columns[e.Column];
            clickedCol.@ascending = !clickedCol.@ascending;
            int numItems = this.listView1.Items.Count;
            this.listView1.BeginUpdate();

            ArrayList SortArray = new ArrayList();
            int i = 0;
            for (i = 0; i <= numItems - 1; i++)
            {
                SortArray.Add(new SortWrapper(this.listView1.Items[i], e.Column));
            }

            SortArray.Sort(0, SortArray.Count, new SortWrapper.SortComparer(clickedCol.@ascending));

            this.listView1.Items.Clear();
            int z = 0;
            for (z = 0; z <= numItems - 1; z++)
            {
                this.listView1.Items.Add(((SortWrapper)SortArray[z]).sortItem);
            }

            this.listView1.EndUpdate();
        }
        #endregion

        #region 시간표
        private void listView2_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView2.Columns[e.ColumnIndex].Width;
        }
        
        TimeElement preview = new TimeElement();

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                preview = TimeParser.Get(listView1.SelectedItems[0].SubItems[8].Text);
                listView2.Invalidate();
                Application.DoEvents();
                DrawTimeTable();
            }
        }
        private void listView3_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Delete )
            {
                if (listView3.SelectedItems.Count != 0)
                {
                    string vi = listView3.SelectedItems[0].SubItems[0].Text;
                    if (listView3.SelectedItems.Count != 0)
                        listView3.SelectedItems[0].Remove();
                    for (int i = 0; i < tet.Count; i++)
                        if (((TimeElement)tet[i]).index == vi)
                        { tt.Del((TimeElement)tet[i]); tet.RemoveAt(i); break; }
                    listView2.Invalidate();
                    Save();
                    Application.DoEvents();
                    DrawTimeTable();
                }
            }
        }

        public ArrayList tet = new ArrayList();
        TimeTable tt = new TimeTable();

        public void Trans()
        {
            listView2.Invalidate();
            Save();
            Application.DoEvents();
            DrawTimeTable();
            if (SaveExist())
            {
                listView3.Items.Clear();
                foreach (string ix in Open().Split('|'))
                    foreach (ListViewItem lvi in listView1.Items)
                        if (lvi.SubItems[0].Text == ix)
                        {
                            TimeElement te = TimeParser.Get(lvi.SubItems[8].Text);

                            listView3.Items.Add((ListViewItem)lvi.Clone());
                            te.index = lvi.SubItems[0].Text;
                            tt.Add(te);
                            tet.Add(te);
                        }
                DrawTimeTable();
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                TimeElement te = TimeParser.Get(listView1.SelectedItems[0].SubItems[8].Text);

                if (!tt.CheckOverlap(te))
                {
                    listView3.Items.Add((ListViewItem)listView1.SelectedItems[0].Clone());
                    te.index = listView1.SelectedItems[0].SubItems[0].Text;
                    tt.Add(te);
                    tet.Add(te);
                    Save();
                }
                else
                {
                    MessageBox.Show("이미 겹치는 항목이 존재합니다.", Version.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void DrawTimeTable()
        {
            foreach (TimeElement te in tet)
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

                    listView2.CreateGraphics().FillRectangle(new SolidBrush(
                        Color.FromArgb(200,_r,_g,_b)
                        ), listView2.Items[r].SubItems[c + 2].Bounds);

                    if (Math.Abs(g - i) != 1) {
                        listView2.CreateGraphics().DrawString(((Bot.SubjectStruct)bot.subject[index]).과목명,
                            listView2.Font, Brushes.White,
                            listView2.Items[r].SubItems[c + 2].Bounds);
                        second = true;
                    } else if ( second == true ) {
                        listView2.CreateGraphics().DrawString(getSlice(((Bot.SubjectStruct)bot.subject[index]).시강),
                            listView2.Font, Brushes.White,
                            listView2.Items[r].SubItems[c + 2].Bounds);
                        second = false;
                    }

                    g = i;
                }
            }

            // Draw Preview
            foreach (int i in preview.te)
            {
                int c = i / 25;
                int r = i % 25;
                
                listView2.CreateGraphics().FillRectangle(new SolidBrush(Color.FromArgb(70, 255, 0, 0)), listView2.Items[r].SubItems[c + 2].Bounds);
            }

        }

        private void Save()
        {
            StringBuilder builder = new StringBuilder();
            foreach (TimeElement te in tet)
            {
                builder.Append(te.index + "|");
            }
            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @".autosave", builder.ToString());
        }
        private bool SaveExist()
        {
            return File.Exists(AppDomain.CurrentDomain.BaseDirectory + @".autosave");
        }
        private string Open()
        {
            try {
                return File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + @".autosave")[0]; }
            catch { return ""; }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            (new frmTTCreator(bot.subject)).Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            (new frmTTViewer(bot.subject)).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            (new frmManual()).Show();
        }
    }
}
