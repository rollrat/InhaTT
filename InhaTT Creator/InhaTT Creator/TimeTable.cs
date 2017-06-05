/***

   Copyright (C) 2017. rollrat. All Rights Reserved.

   03-21-2017:   HyunJun Jeong, Creation

***/

namespace InhaTT_Creator
{
    class TimeTable
    {
        bool[] table = new bool[TimeTableSettings.DayMaxClass * TimeTableSettings.DayOfWeek.Length];
        int i = 0;

        public TimeTable()
        {
            for (int i = 0; i < TimeTableSettings.DayMaxClass * TimeTableSettings.DayOfWeek.Length; i++)
                table[i] = false;
        }

        /// <summary>
        /// 강의시간이 겹친다면 true를 리턴합니다.
        /// </summary>
        public bool CheckOverlap(TimeElement te)
        {
            return te.Overlap(table);
        }

        /// <summary>
        /// 강의시간이 겹치거나 연강이 존재하면 true를 리턴합니다.
        /// </summary>
        public bool CheckOverlapWithContinuity(TimeElement te)
        {
            return te.OverlapWithContinuity(table);
        }

        /// <summary>
        /// 현재 테이블에 시간-요소를 추가합니다.
        /// </summary>
        public void Add(TimeElement te)
        {
            foreach (int i in te.te)
                table[i] = true;
            i += 1;
        }

        /// <summary>
        /// 현재 테이블에서 중복되는 시간-요소를 삭제합니다.
        /// 이 함수는 Add가 보장된 상태에서 작동되어야 합니다.
        /// </summary>
        public void Del(TimeElement te)
        {
            foreach (int i in te.te)
                table[i] = false;
            i -= 1;
        }

    }
}
