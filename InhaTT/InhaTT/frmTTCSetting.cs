/***

   Copyright (C) 2017. rollrat. All Rights Reserved.

   04-24-2017:   HyunJun Jeong, Creation

***/

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace InhaTT
{
    public partial class frmTTCSetting : Form
    {
        public frmTTCSetting()
        {
            InitializeComponent();
        }

        private void frmTTCSetting_Load(object sender, EventArgs e)
        {
            pgSet.SelectedObject = new TTCSetting();
        }
    }

    public class TTCSetting
    {
        bool[] gongang = new bool[5];
        int min_gongang_time = 1;
        bool random_sort = false, random_process = false, startcount_sort = true;
        int max_random_process = 10000;

        [Category("의도적인 공강"), DefaultValue(false), Description("월요일에 의도적으로 공강을 만들지의 여부를 지정합니다.")]
        public bool 월요일
        { get { return gongang[0]; } set { gongang[0] = value; } }
        [Category("의도적인 공강"), DefaultValue(false), Description("화요일에 의도적으로 공강을 만들지의 여부를 지정합니다.")]
        public bool 화요일
        { get { return gongang[1]; } set { gongang[1] = value; } }
        [Category("의도적인 공강"), DefaultValue(false), Description("수요일에 의도적으로 공강을 만들지의 여부를 지정합니다.")]
        public bool 수요일
        { get { return gongang[2]; } set { gongang[2] = value; } }
        [Category("의도적인 공강"), DefaultValue(false), Description("목요일에 의도적으로 공강을 만들지의 여부를 지정합니다.")]
        public bool 목요일
        { get { return gongang[3]; } set { gongang[3] = value; } }
        [Category("의도적인 공강"), DefaultValue(false), Description("금요일에 의도적으로 공강을 만들지의 여부를 지정합니다.")]
        public bool 금요일
        { get { return gongang[4]; } set { gongang[4] = value; } }
        [Category("의도적인 공강"), DefaultValue(1), Description("최소 공강 시간을 지정합니다. 단위는 '교시'입니다.")]
        public int 최소공강시간
        { get { return min_gongang_time; } set { min_gongang_time = value; } }

        [Category("고급 설정"), DefaultValue(false), Description("'RandomCount'로 지정한 만큼 표본을 뽑아 시간표 생성을 시작합니다.")]
        public bool RandomProcess
        { get { return random_process; } set { random_process = value; } }
        [Category("고급 설정"), DefaultValue(10000), Description("표본의 개수를 지정합니다.")]
        public int RandomCount
        { get { return max_random_process; } set { max_random_process = value; } }
        [Category("고급 설정"), DefaultValue(false), Description("생성기가 생성한 결과를 임의로 정렬할 지의 여부를 지정합니다.")]
        public bool ResultRandomSort
        { get { return random_sort; } set { random_sort = value; } }
        [Category("고급 설정"), DefaultValue(true), Description("'Iterate'과정에서 'subject_group'를 요소 개수를 기준으로 정렬한 후 진행할 지의 여부를 지정합니다.")]
        public bool StartCountSort
        { get { return startcount_sort; } set { startcount_sort = value; } }

    }

}
