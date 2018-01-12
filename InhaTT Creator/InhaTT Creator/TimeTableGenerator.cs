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
        Stack<string> stack;

        /// <summary>
        /// maxShowCount : 사용자에게 보여줄 최종생성경우의 수 입니다.
        /// maxPannelCount : 추출할 모든 경우의 수 입니다.
        /// </summary>
        const int maxShowCount = 100;
        const int maxPannelCount = 50000;

        List<List<TimeElement>> subject_group;

        /// <summary>
        /// 연강을 허용할 지의 여부를 결정합니다.
        /// </summary>
        bool continuity;

        /// <summary>
        /// 시간표 생성을 시작합니다.
        /// </summary>
        /// <param name="continuity">연강 여부를 결정합니다. 이 값이 true일경우 연강을 허용합니다.</param>
        public void StartCreate(List<List<TimeElement>> subject_group, bool continuity = true)
        {
            AccessTable = new TimeTable();
            result.Clear();
            stack = new Stack<string>(subject_group.Count);
            this.subject_group = subject_group;
            internal_start();
            internal_trim();
            escape = false;
            this.continuity = continuity;
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
                if (!continuity && AccessTable.CheckOverlap(subject_group[iter][i])) continue;
                else if (continuity && AccessTable.CheckOverlapWithContinuity(subject_group[iter][i])) continue;

                stack.Push(subject_group[iter][i].index);
                AccessTable.Add(subject_group[iter][i]);
                internal_iterate(iter + 1);
                AccessTable.Del(subject_group[iter][i]);
                stack.Pop();

                if (escape) return;
            }
        }

        /// <summary>
        /// 생성완료 후 결과를 정리한다.
        /// </summary>
        private void internal_trim()
        {
            // 결과를 랜덤으로 정렬한다.
            result = result.OrderBy(a => Guid.NewGuid()).ToList();
            // maxShowCount개수만큼(초기값은 100개)이 넘으면 뒤에것을 잘라 100개로 만든다.
            if (result.Count > maxShowCount)
                result.RemoveRange(maxShowCount, result.Count - maxShowCount);
        }

        #endregion

    }
}
