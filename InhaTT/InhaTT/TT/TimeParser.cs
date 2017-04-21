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

                1. 월1,2,3/화1,2,3
                2. 월1,2,3,화1,2,3

                */
                foreach (string s in table.Split('/'))
                {
                    string i = s.Trim();
                    int j = -1;
                    if (i[0] == '월')
                        j = 25 * 0;
                    else if (i[0] == '화')
                        j = 25 * 1;
                    else if (i[0] == '수')
                        j = 25 * 2;
                    else if (i[0] == '목')
                        j = 25 * 3;
                    else if (i[0] == '금')
                        j = 25 * 4;
                    if (j >= 0)
                    {
                        i = i.Substring(1);
                        foreach (string t in i.Split(','))
                        {
                            if (t.Contains('('))
                                te.Add(j + Convert.ToInt32(t.Remove(t.IndexOf('('))) - 1);
                            else
                            {
                                if ("월화수목금".Contains(t[0]))
                                {
                                    if (t[0] == '월')
                                        j = 25 * 0;
                                    else if (t[0] == '화')
                                        j = 25 * 1;
                                    else if (t[0] == '수')
                                        j = 25 * 2;
                                    else if (t[0] == '목')
                                        j = 25 * 3;
                                    else if (t[0] == '금')
                                        j = 25 * 4;
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
