/***

   Copyright (C) 2017. rollrat. All Rights Reserved.

   04-22-2017:   HyunJun Jeong, Creation

***/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            foreach (string n in list)
            {
                tvField.Nodes.Add(n);
                cbFilter.Items.Add(n);
                cbFilterSubject.Items.Add(n);
            }
            cbFilter.Text = list[0];
            cbFilterSubject.Text = list[0];
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
            foreach (Bot.SubjectStruct ss in Program.m.bot.subject)
            {
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
            foreach (string n in list)
            {
                tvProfessor.Nodes.Add(n);
            }
        }

        Dictionary<string, List<int>> _subject = new Dictionary<string, List<int>>();
        private void InitSubject()
        {
            foreach (Bot.SubjectStruct ss in Program.m.bot.subject)
            {
                if (!_subject.ContainsKey(ss.과목명))
                    _subject.Add(ss.과목명, new List<int>());
                _subject[ss.과목명].Add(ss.index);
            }
            var list = _subject.Keys.ToList();
            list.Sort();
            foreach (string n in list)
            {
                tvSubject.Nodes.Add(n);
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
                if (!ss.필드.Contains(cbFilter.Text)) continue;
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
            foreach (string n in list)
            {
                tvProfessor.Nodes.Add(n);
            }
        }

        private void cbFilterSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            _subject.Clear();
            tvSubject.Nodes.Clear();
            lvSubject.Items.Clear();
            foreach (Bot.SubjectStruct ss in Program.m.bot.subject)
            {
                if (!ss.필드.Contains(cbFilterSubject.Text)) continue;
                if (!_subject.ContainsKey(ss.과목명))
                    _subject.Add(ss.과목명, new List<int>());
                _subject[ss.과목명].Add(ss.index);
            }
            var list = _subject.Keys.ToList();
            list.Sort();
            foreach (string n in list)
            {
                tvSubject.Nodes.Add(n);
            }
        }

        #endregion

    }
}
