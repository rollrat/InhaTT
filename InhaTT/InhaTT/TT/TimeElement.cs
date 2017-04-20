/***

   Copyright (C) 2017. rollrat. All Rights Reserved.

   03-21-2017:   HyunJun Jeong, Creation

***/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace InhaTT
{
    class TimeElement
    {
        public ArrayList te = new ArrayList();
        public string index;

        public void Add(int b)
        {
            te.Add(b);
        }

        public int[] Get()
        {
            return te.ToArray(typeof(int)) as int[];
        }

        public bool Overlap(bool[] b)
        {
            foreach (int t in te)
                if (b[t] == true)
                    return true;
            return false;
        }
        
        public bool IsFillDay(int k)
        {
            foreach (int i in te)
                if (i / 25 == k)
                    return true;
            return false;
        }
        
    }
}
