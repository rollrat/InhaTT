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

        public bool CheckOverlap(TimeElement te)
        {
            return te.Overlap(table);
        }

        public void Add(TimeElement te)
        {
            foreach (int i in te.te)
                table[i] = true;
            i += 1;
        }

        public void Del(TimeElement te)
        {
            foreach (int i in te.te)
                table[i] = false;
            i -= 1;
        }

    }
}
