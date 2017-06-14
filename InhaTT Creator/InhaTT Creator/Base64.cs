/***

   Copyright (C) 2017. rollrat. All Rights Reserved.

   06-11-2017:   HyunJun Jeong, Creation

***/

using System;
using System.Text;

namespace InhaTT_Creator
{
    class Base64
    {
        public static string to (string text)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
        }

        public static string from ( string text )
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(text));
        }
    }
}
