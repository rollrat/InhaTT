/***

   Copyright (C) 2017. rollrat. All Rights Reserved.

   05-26-2017:   HyunJun Jeong, Creation

***/

namespace InhaTT_Creator
{
    class TimeTableSettings
    {
        /// <summary>
        /// 하루를 몇 교시로 할지 결정합니다.
        /// </summary>
        public const int DayMaxClass = 25;

        /// <summary>
        /// 일주일을 나타내는 요일의 접두구분자를 지정합니다.
        /// 토요일도 수업을 추가하고 싶으면, "월화수목금토"로 대체하십시오.
        /// </summary>
        public const string DayOfWeek = "월화수목금";
    }
}
