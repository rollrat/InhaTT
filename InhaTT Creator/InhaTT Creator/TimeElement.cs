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
        public List<int> te = new List<int>(); /// 시간표 정보가 저장됩니다.
        public List<string> cr = new List<string>(); /// 강의실 정보가 저장됩니다.
        public string index;
        
        /// 이 값이 true인 경우 웹강의가 포함된 경우입니다.
        public bool with_web = false; // frmTTViewer에서 강의실에 맞게 표시할 때 사용함

        /// <summary>
        /// 특정 시간 요소를 선형 리스트에 추가합니다.
        /// </summary>
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
        /// 수업이 겹치는지의 여부를 연강과 함께 확인합니다.
        /// 즉, 수업이 겹치거나 연강인 강의가 존재하면 true를 리턴합니다.
        /// </summary>
        public bool OverlapWithContinuity(bool[] b)
        {
            foreach (int t in te)
            {
                if (t > 0 && b[t - 1] == true) return true;
                if (t < TimeTableSettings.DayMaxClass * TimeTableSettings.DayOfWeek.Length && b[t + 1] == true) return true;
                if (b[t] == true) return true;
            }
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
