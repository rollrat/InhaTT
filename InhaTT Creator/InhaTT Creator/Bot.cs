/***

   Copyright (C) 2017. rollrat. All Rights Reserved.

   03-21-2017:   HyunJun Jeong, Creation

***/

using System.Collections.Generic;
using System.Text;

namespace InhaTT_Creator
{
    public class Bot
    {
        int index_count = 0;

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

        public List<SubjectStruct> subject = new List<SubjectStruct>();

        public void ParseSubject(string field)
        {
            string[] sl = field.Split('|');
            SubjectStruct ss;

            ss.index = index_count++;
            ss.필드 = sl[0];
            ss.학수번호 = sl[1];
            ss.분반 = sl[2];
            ss.과목명 = sl[3];
            ss.학년 = sl[4];
            ss.학점 = sl[5];
            ss.구분 = sl[6];
            ss.시강 = sl[7];
            ss.교수 = sl[8];
            ss.평가 = sl[9];
            ss.비고 = sl[10];

            subject.Add(ss);
        }

        static public string Concat(SubjectStruct ss)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(ss.필드); sb.Append('|');
            sb.Append(ss.학수번호); sb.Append('|');
            sb.Append(ss.분반); sb.Append('|');
            sb.Append(ss.과목명); sb.Append('|');
            sb.Append(ss.학년); sb.Append('|');
            sb.Append(ss.학점); sb.Append('|');
            sb.Append(ss.구분); sb.Append('|');
            sb.Append(ss.시강); sb.Append('|');
            sb.Append(ss.교수); sb.Append('|');
            sb.Append(ss.평가); sb.Append('|');
            sb.Append(ss.비고);

            return sb.ToString();
        }

    }
}
