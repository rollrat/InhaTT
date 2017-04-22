/***

   Copyright (C) 2017. rollrat. All Rights Reserved.

   04-22-2017:   HyunJun Jeong, Creation

***/

using System;
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
    public partial class frmAnalyzer : Form
    {
        public frmAnalyzer()
        {
            InitializeComponent();
        }

        private void frmAnalyzer_Load(object sender, EventArgs e)
        {
            InitField();
            InitClass();
        }
        
        Dictionary<string, List<int>> field = new Dictionary<string, List<int>>();
        private void InitField()
        {
            foreach ( Bot.SubjectStruct ss in Program.m.bot.subject )
            {
                if (!field.ContainsKey(ss.필드))
                    field.Add(ss.필드, new List<int>());
                field[ss.필드].Add(ss.index);
            }
            foreach (KeyValuePair<string, List<int>> kv in field)
            {
                tvField.Nodes.Add(kv.Key);
            }
        }

        static public string[] getSlice(string a)
        {
            Regex regex = new Regex("\\((.*?)\\)");
            Match match = regex.Match(a);
            List<string> lv = new List<string>();

            while (match.Success)
            {
                lv.Add(match.Groups[1].Value);
                match = match.NextMatch();
            }

            return lv.ToArray();
        }

        Dictionary<string, List<int>> _class = new Dictionary<string, List<int>>();
        private void InitClass()
        {
            foreach (Bot.SubjectStruct ss in Program.m.bot.subject)
            {
                foreach (string c in getSlice(ss.시강))
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

        /// <summary>
        /// 서브젝트 정보를 검색 뷰어에 출력합니다.
        /// </summary>
        private void AppendSubjectToList(ListView lv, Bot.SubjectStruct ss)
        {
            lv.Items.Add(new ListViewItem(new string[] { ss.index.ToString(),
                ss.필드, ss.학수번호, ss.분반, ss.과목명, ss.학년, ss.학점,
                ss.구분, ss.시강, ss.교수, ss.평가, ss.비고 }));
        }

        private void tvField_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lvField.Items.Clear();
            foreach (int ix in field[tvField.SelectedNode.FullPath])
                AppendSubjectToList(lvField,Program.m.bot.subject[ix]);
        }

        private void tvClass_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lvClass.Items.Clear();
            foreach (int ix in _class[tvClass.SelectedNode.FullPath])
                AppendSubjectToList(lvClass, Program.m.bot.subject[ix]);
        }
    }
}
