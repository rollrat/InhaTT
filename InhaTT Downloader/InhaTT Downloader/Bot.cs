/***

   Copyright (C) 2017. rollrat. All Rights Reserved.

   03-21-2017:   HyunJun Jeong, Creation

***/

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.IO;

namespace InhaTT_Downloader
{
    class Bot
    {
        public string html_data;
        string sugang_main = "http://sugang.inha.ac.kr/sugang/SU_51001/Lec_Time_Search.aspx";
        int index_count = 0;

        public struct FieldStruct
        {
            public string magic;
            public string name;
        }

        public ArrayList field = new ArrayList();

        public Bot()
        {
            DownloadURL(sugang_main);
            ParseField();
        }

        private bool DownloadURL(string addr)
        {
            try
            {
                WebClient wclient = new WebClient();
                wclient.Encoding = Encoding.GetEncoding("euc-kr");
                html_data = wclient.DownloadString(addr);
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message,
                  "InhaTT", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }
        
        private void ParseField()
        {
            string src = html_data.Split(
                new string[] { "<span id=\"lblMajor\">" }, StringSplitOptions.None)[1].Split(
                new string[] { "h2\" class=\"btn\" />" }, StringSplitOptions.None)[0];

            Regex regex = new Regex(@"<option(selected=""selected""| )*value=""(\d+)"">(.*?)</option>");
            Match match = regex.Match(src);

            while ( match.Success )
            {
                FieldStruct fs;
                fs.magic = match.Groups[2].Value;
                fs.name = match.Groups[3].Value;
                field.Add(fs);
                match = match.NextMatch();
            }
        }
        
        public struct SubjectStruct
        {
            public int index;
            public string 필드;
            public string 학수번호;
            public string 분반;
            public string 과목명;
            public string 학년;
            public string 학점;
            public string 구분;
            public string 시강;
            public string 교수;
            public string 평가;
            public string 비고;
        }

        public ArrayList subject = new ArrayList();

        public void ParseSubject(string field)
        {
            Regex regex = new Regex(@"<font color=""blue"">(.*?)</font>.*?Center"">(.*?)</td>.*?Center"">(.*?)</td>.*?Center"">(.*?)</td>.*?Center"">(.*?)</td>.*?Center"">(.*?)</td>.*?Center"">(.*?)</td>.*?Center"">(.*?)</td>.*?Center"">(.*?)</td>.*?Center"">(.*?)</td>");
            Match match = regex.Match(html_data);

            while (match.Success)
            {
                SubjectStruct ss;
                ss.index = index_count++;
                ss.필드 = field;
                ss.학수번호 = match.Groups[1].Value;
                ss.분반 = match.Groups[2].Value;
                ss.과목명 = match.Groups[3].Value;
                ss.학년 = match.Groups[4].Value;
                ss.학점 = match.Groups[5].Value;
                ss.구분 = match.Groups[6].Value;
                ss.시강 = match.Groups[7].Value;
                ss.교수 = match.Groups[8].Value;
                ss.평가 = match.Groups[9].Value;
                ss.비고 = match.Groups[10].Value;
                subject.Add(ss);
                match = match.NextMatch();
            }
        }
        
        public string SubjectsToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (SubjectStruct ss in subject)
            {
                builder.Append(FieldToDepartment(ss.필드));     builder.Append('|');
                builder.Append(ss.학수번호);  builder.Append('|');
                builder.Append(ss.분반);     builder.Append('|');
                builder.Append(ss.과목명);   builder.Append('|');
                builder.Append(ss.학년);     builder.Append('|');
                builder.Append(ss.학점);     builder.Append('|');
                builder.Append(ss.구분);     builder.Append('|');
                builder.Append(ss.시강);     builder.Append('|');
                builder.Append(ss.교수);     builder.Append('|');
                builder.Append(ss.평가);     builder.Append('|');
                builder.Append(ss.비고);     builder.Append('\n');
            }

            return builder.ToString();
        }
        
        public string GetSortedBySubjectName()
        {
            StringBuilder builder = new StringBuilder();
            ArrayList al = new ArrayList();

            foreach (SubjectStruct ss in subject)
            {
                if (!al.Contains(ss.과목명))
                    al.Add(ss.과목명);
            }

            foreach ( string s in al )
            {
                builder.Append(s);
                builder.Append('|');
            }

            return builder.ToString();
        }

        public string GetSortedBySubjectPro()
        {
            StringBuilder builder = new StringBuilder();
            ArrayList al = new ArrayList();

            foreach (SubjectStruct ss in subject)
            {
                if (!al.Contains(ss.교수))
                    al.Add(ss.교수);
            }

            foreach (string s in al)
            {
                builder.Append(s);
                builder.Append('|');
            }

            return builder.ToString();
        }

        public string GetSortedBySubjectField()
        {
            StringBuilder builder = new StringBuilder();
            ArrayList al = new ArrayList();

            foreach (SubjectStruct ss in subject)
            {
                if (!al.Contains(FieldToDepartment(ss.필드)))
                    al.Add(FieldToDepartment(ss.필드));
            }

            foreach (string s in al)
            {
                builder.Append(s);
                builder.Append('|');
            }

            return builder.ToString();
        }

        public string GetSortedBySubjectMagic()
        {
            StringBuilder builder = new StringBuilder();
            ArrayList al = new ArrayList();

            foreach (SubjectStruct ss in subject)
            {
                if (!al.Contains(ss.학수번호))
                    al.Add(ss.학수번호);
            }

            foreach (string s in al)
            {
                builder.Append(s);
                builder.Append('|');
            }

            return builder.ToString();
        }
        public string FieldToDepartment(string magic)
        {
            foreach (FieldStruct fs in field)
                if (fs.magic == magic) return fs.name;
            return "";
        }
    }
}
