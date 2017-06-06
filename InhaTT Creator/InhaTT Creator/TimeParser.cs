/***

   Copyright (C) 2017. rollrat. All Rights Reserved.

   03-21-2017:   HyunJun Jeong, Creation

***/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace InhaTT_Creator
{
    class TimeParser
    {
        /// <summary>
        /// 괄호안에 있는 문자열들을 모두 가져옵니다.
        /// 단, 각 문자열들을 차례로 리스트에 넣습니다.
        /// </summary>
        static public List<string> getSlice(string a)
        {
            Regex regex = new Regex("\\((.*?)\\)");
            Match match = regex.Match(a);
            List<string> lv = new List<string>();

            while (match.Success)
            {
                lv.Add(match.Groups[1].Value);
                match = match.NextMatch();
            }

            return lv;
        }

        /// <summary>
        /// 시간 정보를 해석합니다.
        /// </summary>
        static public TimeElement Get(string table)
        {
            TimeElement te = new TimeElement();
            try
            {
                /*

                시간 표시 유형이 두 가지가 있다.

                1. 월1,2,3(하-101)/화1,2,3(2-112)
                2. 월1,2,3화1,2,3(60주년-1012)

                * 혼종 발견 ( 처리안함 귀찮음 )
                3. 월1,2,3,화1,2,3(하-101)/수1,2,3(60주년-7077)

                */
                string dayOfWeek = TimeTableSettings.DayOfWeek;
                foreach (string s in table.Split('/'))
                {
                    string i = s.Trim();
                    int j = -1;
                    if (dayOfWeek.Contains(i[0]))
                    {
                        j = TimeTableSettings.DayMaxClass * dayOfWeek.IndexOf(i[0]);
                        i = i.Substring(1);
                        foreach (string t in i.Split(','))
                        {
                            // 강의실 제외한 나머지를 구겨넣음
                            if (t.Contains('('))
                                te.Add(j + Convert.ToInt32(t.Remove(t.IndexOf('('))) - 1);
                            else
                            {
                                // 2 유형의 경우 "화1" 처럼 숫자와 문자가 붙어 있음
                                if (dayOfWeek.Contains(t[0]))
                                {
                                    j = TimeTableSettings.DayMaxClass * dayOfWeek.IndexOf(t[0]);
                                    te.Add(j + Convert.ToInt32(t.Substring(1)) - 1);
                                }
                                else
                                    te.Add(j + Convert.ToInt32(t) - 1);
                            }
                        }
                    }
                }
                foreach (string c in getSlice(table))
                    te.cr.Add(c);
                if (te.cr[0] == "웹강의" && te.cr.Count > 1)
                { te.cr[0] = te.cr[1]; te.with_web = true; }
                else if (te.cr.Count == 1) te.cr.Add(te.cr[0]);
            }
            catch
            {

            }

            return te;
        }
    }
}
