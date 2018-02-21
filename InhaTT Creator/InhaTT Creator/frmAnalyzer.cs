/***

   Copyright (C) 2017. rollrat. All Rights Reserved.

   04-22-2017:   HyunJun Jeong, Creation

***/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace InhaTT_Creator
{
    public partial class frmAnalyzer : Form
    {
        public frmAnalyzer()
        {
            InitializeComponent();
        }

        private void frmAnalyzer_Load(object sender, EventArgs e)
        {
            InitClass();
            InitProfessor();
            InitSubject();
            InitField();
            InitFilter();
        }

        #region 초기화

        Dictionary<string, List<int>> field = new Dictionary<string, List<int>>();
        private void InitField()
        {
            foreach ( Bot.SubjectStruct ss in Program.m.bot.subject )
            {
                if (!field.ContainsKey(ss.필드))
                    field.Add(ss.필드, new List<int>());
                field[ss.필드].Add(ss.index);
            }
            var list = field.Keys.ToList();
            list.Sort();
            cbFilter.Items.Add("모든교수");
            cbFilterSubject.Items.Add("모든과목");
            foreach (string n in list)
            {
                tvField.Nodes.Add(n);
                cbFilter.Items.Add(n);
                cbFilterSubject.Items.Add(n);
            }
            cbFilter.Text = "모든교수";
            cbFilterSubject.Text = "모든과목";
        }

        Dictionary<string, List<int>> _class = new Dictionary<string, List<int>>();
        private void InitClass()
        {
            foreach (Bot.SubjectStruct ss in Program.m.bot.subject)
            {
                foreach (string c in TimeParser.getSlice(ss.시강))
                {
                    if (!_class.ContainsKey(c))
                        _class.Add(c, new List<int>());
                    _class[c].Add(ss.index);
                }
            }
            var list = _class.Keys.ToList();
            list.Sort();
            foreach (string n in list)
            {
                tvClass.Nodes.Add(n);
            }
        }

        Dictionary<string, List<int>> _professor = new Dictionary<string, List<int>>();
        private void InitProfessor()
        {
            _professor.Add("모든교수", new List<int>());
            foreach (Bot.SubjectStruct ss in Program.m.bot.subject)
            {
                string[] split = ss.교수.Split(',');
                foreach (string c in split)
                {
                    if (!_professor.ContainsKey(c))
                        _professor.Add(c, new List<int>());
                    _professor[c].Add(ss.index);
                    _professor["모든교수"].Add(ss.index);
                }
            }
        }

        Dictionary<string, List<int>> _subject = new Dictionary<string, List<int>>();
        private void InitSubject()
        {
            _subject.Add("모든과목", new List<int>());
            foreach (Bot.SubjectStruct ss in Program.m.bot.subject)
            {
                if (!_subject.ContainsKey(ss.과목명))
                    _subject.Add(ss.과목명, new List<int>());
                _subject[ss.과목명].Add(ss.index);
                _subject["모든과목"].Add(ss.index);
            }
        }

        List<Dictionary<string, List<int>>> _filter = new List<Dictionary<string, List<int>>>();
        private void InitFilter()
        {
            for (int i = 0; i < 5; i++)
            {
                _filter.Add(new Dictionary<string, List<int>>());
            }
            foreach (Bot.SubjectStruct ss in Program.m.bot.subject)
            {
                if (!_filter[0].ContainsKey(ss.필드))
                    _filter[0].Add(ss.필드, new List<int>());
                if (!_filter[1].ContainsKey(ss.학년))
                    _filter[1].Add(ss.학년, new List<int>());
                if (!_filter[2].ContainsKey(ss.학점))
                    _filter[2].Add(ss.학점, new List<int>());
                if (!_filter[3].ContainsKey(ss.구분))
                    _filter[3].Add(ss.구분, new List<int>());
                if (!_filter[4].ContainsKey(ss.평가))
                    _filter[4].Add(ss.평가, new List<int>());
            }
            ComboBox[] obj = { cb1, cb2, cb3, cb4, cb5 };
            for (int i = 0; i < 5; i++)
            {
                Dictionary<string, List<int>> dic = _filter[i];
                var list = dic.Keys.ToList();
                list.Sort();
                list.Insert(0, "모두");
                obj[i].Items.AddRange(list.ToArray());
                obj[i].SelectedIndex = 0;
            }
        }

        #endregion

        /// <summary>
        /// 서브젝트 정보를 검색 뷰어에 출력합니다.
        /// </summary>
        private void AppendSubjectToList(ListView lv, Bot.SubjectStruct ss)
        {
            lv.Items.Add(new ListViewItem(new string[] { ss.index.ToString(),
                ss.필드, ss.학수번호, ss.분반, ss.과목명, ss.학년, ss.학점,
                ss.구분, ss.시강, ss.교수, ss.평가, ss.비고 }));
        }

        private void AppendSubjectsToList(ListView lv, List<Bot.SubjectStruct> ssl)
        {
            List<ListViewItem> lvil = new List<ListViewItem>();
            foreach (Bot.SubjectStruct ss in ssl)
            {
                lvil.Add(new ListViewItem(new string[] { ss.index.ToString(),
                    ss.필드, ss.학수번호, ss.분반, ss.과목명, ss.학년, ss.학점,
                    ss.구분, ss.시강, ss.교수, ss.평가, ss.비고 }));
            }
            lv.Items.AddRange(lvil.ToArray());
        }

        #region 폼 이벤트 처리

        private void tvField_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lvField.Items.Clear();
            foreach (int ix in field[tvField.SelectedNode.FullPath])
                AppendSubjectToList(lvField,Program.m.bot.subject[ix]);
        }

        string choose_cr;
        private void tvClass_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lvClass.Items.Clear();
            foreach (int ix in _class[choose_cr = tvClass.SelectedNode.FullPath])
                AppendSubjectToList(lvClass, Program.m.bot.subject[ix]);
        }

        private void tvProfessor_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lvProfessor.Items.Clear();
            foreach (int ix in _professor[tvProfessor.SelectedNode.FullPath])
                AppendSubjectToList(lvProfessor, Program.m.bot.subject[ix]);
        }

        private void tvSubject_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lvSubject.Items.Clear();
            foreach (int ix in _subject[tvSubject.SelectedNode.FullPath])
                AppendSubjectToList(lvSubject, Program.m.bot.subject[ix]);
        }

        private void lvField_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            List<Bot.SubjectStruct> subject = new List<Bot.SubjectStruct>();
            foreach (ListViewItem lvi in lvField.Items)
                foreach (Bot.SubjectStruct ss in Program.m.bot.subject)
                    if (lvi.SubItems[0].Text == ss.index.ToString())
                    { subject.Add(ss); break; }
            (new frmTTViewer(Program.m.bot.subject, false, subject)).Show();
        }

        private void lvClass_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            List<Bot.SubjectStruct> subject = new List<Bot.SubjectStruct>();
            foreach (ListViewItem lvi in lvClass.Items)
                foreach (Bot.SubjectStruct ss in Program.m.bot.subject)
                    if (lvi.SubItems[0].Text == ss.index.ToString())
                    { subject.Add(ss); break; }
            (new frmTTViewer(Program.m.bot.subject, false, subject, choose_cr)).Show();
        }
        
        private void lvProfessor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            List<Bot.SubjectStruct> subject = new List<Bot.SubjectStruct>();
            foreach (ListViewItem lvi in lvProfessor.Items)
                foreach (Bot.SubjectStruct ss in Program.m.bot.subject)
                    if (lvi.SubItems[0].Text == ss.index.ToString())
                    { subject.Add(ss); break; }
            (new frmTTViewer(Program.m.bot.subject, false, subject)).Show();
        }

        private void lvSubject_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            List<Bot.SubjectStruct> subject = new List<Bot.SubjectStruct>();
            foreach (ListViewItem lvi in lvSubject.Items)
                foreach (Bot.SubjectStruct ss in Program.m.bot.subject)
                    if (lvi.SubItems[0].Text == ss.index.ToString())
                    { subject.Add(ss); break; }
            (new frmTTViewer(Program.m.bot.subject, false, subject)).Show();
        }
        
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _professor.Clear();
            tvProfessor.Nodes.Clear();
            lvProfessor.Items.Clear();
            foreach (Bot.SubjectStruct ss in Program.m.bot.subject)
            {
                if (!ss.필드.Contains(cbFilter.Text) && cbFilter.Text != "모든교수") continue;
                string[] split = ss.교수.Split(',');
                foreach (string c in split)
                {
                    if (!_professor.ContainsKey(c))
                        _professor.Add(c, new List<int>());
                    _professor[c].Add(ss.index);
                }
            }
            var list = _professor.Keys.ToList();
            list.Sort();
            List<TreeNode> ll = new List<TreeNode>();
            list.ForEach((x) => { ll.Add(new TreeNode(x)); });
            tvProfessor.Nodes.AddRange(ll.ToArray());
        }

        private void cbFilterSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            _subject.Clear();
            tvSubject.Nodes.Clear();
            lvSubject.Items.Clear();
            foreach (Bot.SubjectStruct ss in Program.m.bot.subject)
            {
                if (!ss.필드.Contains(cbFilterSubject.Text) && cbFilterSubject.Text != "모든과목") continue;
                if (!_subject.ContainsKey(ss.과목명))
                    _subject.Add(ss.과목명, new List<int>());
                _subject[ss.과목명].Add(ss.index);
            }
            var list = _subject.Keys.ToList();
            list.Sort();
            List<TreeNode> ll = new List<TreeNode>();
            list.ForEach((x) => { ll.Add(new TreeNode(x));});
            tvSubject.Nodes.AddRange(ll.ToArray());
        }

        private void 이과목을목록에추가AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripItem menuItem)
            {
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;

                ListView lv = (ListView)(owner.SourceControl);
                if (lv.SelectedItems.Count > 0)
                {
                    Program.m.DoAddSubject(Convert.ToInt32(lv.SelectedItems[0].SubItems[0].Text));
                }
            }
        }

        private void 필드찾기FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripItem menuItem)
            {
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;

                ListView lv = (ListView)(owner.SourceControl);
                if (lv.SelectedItems.Count > 0)
                {
                    tabControl2.SelectedTab = tabControl2.TabPages[0];
                    cbFilter.Text = lv.SelectedItems[0].SubItems[1].Text;
                    Application.DoEvents();
                    foreach (TreeNode n in tvField.Nodes)
                        if (n.Text == lv.SelectedItems[0].SubItems[1].Text)
                            tvField.SelectedNode = n;
                }
            }
        }

        private void 교수보기PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripItem menuItem)
            {
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;

                ListView lv = (ListView)(owner.SourceControl);
                if (lv.SelectedItems.Count > 0)
                {
                    tabControl2.SelectedTab = tabControl2.TabPages[2];
                    cbFilter.Text = lv.SelectedItems[0].SubItems[1].Text;
                    Application.DoEvents();
                    foreach (TreeNode n in tvProfessor.Nodes)
                        if (n.Text == lv.SelectedItems[0].SubItems[9].Text)
                            tvProfessor.SelectedNode = n;
                }
            }
        }

        private void 과목보기SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripItem menuItem)
            {
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;

                ListView lv = (ListView)(owner.SourceControl);
                if (lv.SelectedItems.Count > 0)
                {
                    tabControl2.SelectedTab = tabControl2.TabPages[3];
                    cbFilterSubject.Text = lv.SelectedItems[0].SubItems[1].Text;
                    Application.DoEvents();
                    foreach (TreeNode n in tvSubject.Nodes)
                        if (n.Text == lv.SelectedItems[0].SubItems[4].Text)
                            tvSubject.SelectedNode = n;
                }
            }
        }

        private void do_filtering()
        {
            List<Bot.SubjectStruct> lss = new List<Bot.SubjectStruct>();
            string c1 = cb1.Text, c2 = cb2.Text, c3 = cb3.Text, c4 = cb4.Text, c5 = cb5.Text;
            foreach (Bot.SubjectStruct ss in Program.m.bot.subject)
                if ((c1 == "모두" || c1 == ss.필드) &&
                    (c2 == "모두" || c2 == ss.학년) &&
                    (c3 == "모두" || c3 == ss.학점) &&
                    (c4 == "모두" || c4 == ss.구분) &&
                    (c5 == "모두" || c5 == ss.평가))
                    lss.Add(ss);
            lvFilter.Items.Clear();
            AppendSubjectsToList(lvFilter, lss);
        }
        
        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        { do_filtering(); }
        private void cb2_SelectedIndexChanged(object sender, EventArgs e)
        { do_filtering(); }
        private void cb3_SelectedIndexChanged(object sender, EventArgs e)
        { do_filtering(); }
        private void cb4_SelectedIndexChanged(object sender, EventArgs e)
        { do_filtering(); }
        private void cb5_SelectedIndexChanged(object sender, EventArgs e)
        { do_filtering(); }

        #endregion

    }
}
