/***

   Copyright (C) 2017. rollrat. All Rights Reserved.

   03-21-2017:   HyunJun Jeong, Creation

***/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InhaTT
{
    // 폐기됨
    class TimeTableGenerator
    {
        Dictionary<string, ArrayList> dic = new Dictionary<string, ArrayList>();
        TimeTable tt = new TimeTable();

        public void PutTestCase(string d, TimeElement t)
        {
            if (dic[d] == null)
                dic[d] = new ArrayList();
            dic[d].Add(t);
        }
        
        public bool OptionFix(TimeElement te)
        {
            if (tt.CheckOverlap(te) == true)
                return false;
            tt.Add(te);
            return true;
        }

        public delegate void StartDelegate(TimeTable x);

        public void Start(StartDelegate dlg)
        {
            foreach (KeyValuePair<string, ArrayList> entry in dic)
            {
                foreach(TimeElement i in entry.Value)
                {
                    if (!tt.CheckOverlap(i))
                        tt.Add(i);
                    dlg(tt);
                    tt.Del(i);
                }
            }
        }
        
        public ArrayList[] KVPairToArrayList()
        {
            ArrayList al = new ArrayList();

            foreach (KeyValuePair<string, ArrayList> entry in dic)
            {
                al.Add(entry);
            }

            return al.ToArray(typeof(ArrayList)) as ArrayList[];
        }

        public void StartWithArray(StartDelegate dlg)
        {
            ArrayList[] ala = KVPairToArrayList();
            for ( int i = 0; i < ala.Length; i++ )
            {
                for ( int j = 0; j < ala[i].Count; j++ )
                {
                    if ( !tt.CheckOverlap((TimeElement)ala[i][j]))
                    {
                        tt.Add((TimeElement)ala[i][j]);
                    }
                    StartWithArray(dlg);
                    dlg(tt);
                    tt.Del((TimeElement)ala[i][j]);
                }
            }
        }

    }
}
