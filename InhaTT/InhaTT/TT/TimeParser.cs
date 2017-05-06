/***

   Copyright (C) 2017. rollrat. All Rights Reserved.

   03-21-2017:   HyunJun Jeong, Creation

***/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InhaTT
{
    class TimeParser
    {
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

                */
                string dayOfWeek = "월화수목금";
                foreach (string s in table.Split('/'))
                {
                    string i = s.Trim();
                    int j = -1;
                    if (dayOfWeek.Contains(i[0]))
                    {
                        j = 25 * dayOfWeek.IndexOf(i[0]);
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
                                    j = 25 * dayOfWeek.IndexOf(i[0]);
                                    te.Add(j + Convert.ToInt32(t.Substring(1)) - 1);
                                }
                                else
                                    te.Add(j + Convert.ToInt32(t) - 1);
                            }
                        }
                    }
                }
            } catch
            {

            }

            return te;
        }
    }
}
