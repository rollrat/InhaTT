/***

   Copyright (C) 2017. rollrat. All Rights Reserved.

   03-21-2017:   HyunJun Jeong, Creation

***/

using System.Collections.Generic;

namespace InhaTT_Creator
{
    /// <summary>
    /// 과목의 시간 정보가 저장되는 클래스입니다.
    /// 시간 정보는 선형으로 저장됩니다.
    /// </summary>
    public class TimeElement
    {
        public List<int> te = new List<int>();
        public List<string> cr = new List<string>();
        public string index;

        public void Add(int b)
        {
            te.Add(b);
        }

        /// <summary>
        /// 수업이 겹치는지의 여부를 확인함
        /// </summary>
        public bool Overlap(bool[] b)
        {
            foreach (int t in te)
                if (b[t] == true)
                    return true;
            return false;
        }

        /// <summary>
        /// 특정 요일에 수업시간이 존재하는지 확인함
        /// </summary>
        public bool IsFillDay(int k)
        {
            foreach (int i in te)
                if (i / TimeTableSettings.DayMaxClass == k)
                    return true;
            return false;
        }

        /// <summary>
        /// 특정 교시에 수업시간이 존재하는지 확인함
        /// </summary>
        public bool IsFillTime(int k)
        {
            foreach (int i in te)
                if (i % TimeTableSettings.DayMaxClass == k - 1)
                    return true;
            return false;
        }
    }
}
