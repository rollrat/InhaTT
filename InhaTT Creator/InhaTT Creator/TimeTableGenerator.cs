/***

   Copyright (C) 2017. rollrat. All Rights Reserved.

   05-24-2017:   HyunJun Jeong, Creation

***/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InhaTT_Creator
{
    class TimeTableGenerator
    {
        /// <summary>
        /// 시간표가 겹치는지의 여부를 확인하기 위한 시험용 테이블 입니다.
        /// </summary>
        TimeTable AccessTable;

        /// <summary>
        /// escape: esacpe가 True이면 iteration을 탈출합니다.
        /// </summary>
        bool escape = false;
        List<string> result = new List<string>();
        Stack<string> stack = new Stack<string>();

        /// <summary>
        /// maxShowCount : 사용자에게 보여줄 최종생성경우의 수 입니다.
        /// maxPannelCount : 추출할 모든 경우의 수 입니다.
        /// </summary>
        const int maxShowCount = 100;
        const int maxPannelCount = 100000;

        List<List<TimeElement>> subject_group;

        public void StartCreate(List<List<TimeElement>> subject_group)
        {
            AccessTable = new TimeTable();
            result.Clear();
            stack.Clear();
            this.subject_group = subject_group;
            internal_start();
            internal_trim();
            escape = false;
        }

        public int GetResultCount()
        {
            return result.Count;
        }

        public string GetResult()
        {
            StringBuilder builder = new StringBuilder();
            foreach (string r in result)
                builder.Append(r + '\n');
            return builder.ToString();
        }

        #region 테스트 부분
        
        private void internal_start()
        {
            for (int i = 0; i < subject_group[0].Count; i++)
            {
                stack.Push(subject_group[0][i].index);
                AccessTable.Add(subject_group[0][i]);
                internal_iterate(1);
                AccessTable.Del(subject_group[0][i]);
                stack.Pop();
                if (escape) break;
            }
        }

        private void internal_iterate(int iter)
        {
            if (escape) return;
            if (subject_group.Count == iter)
            {
                StringBuilder builder = new StringBuilder();
                foreach (string s in stack)
                    builder.Append(s + '|');
                result.Add(builder.ToString());
                if (result.Count >= maxPannelCount)
                    escape = true;
                return;
            }
            for (int i = 0; i < subject_group[iter].Count; i++)
            {
                if (AccessTable.CheckOverlap(subject_group[iter][i]))
                    continue;
                stack.Push(subject_group[iter][i].index);
                AccessTable.Add(subject_group[iter][i]);
                internal_iterate(iter + 1);
                AccessTable.Del(subject_group[iter][i]);
                stack.Pop();
                if (escape)
                    return;
            }
        }

        /// <summary>
        /// 생성완료 후 결과를 정리한다.
        /// </summary>
        private void internal_trim()
        {
            result = result.OrderBy(a => Guid.NewGuid()).ToList();
            if (result.Count > maxShowCount)
                result.RemoveRange(maxShowCount, result.Count - maxShowCount);
        }

        #endregion

    }
}
