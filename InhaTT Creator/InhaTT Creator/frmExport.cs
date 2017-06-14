/***

   Copyright (C) 2017. rollrat. All Rights Reserved.

   06-11-2017:   HyunJun Jeong, Creation

***/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace InhaTT_Creator
{
    public partial class frmExport : Form
    {
        string data;

        public frmExport(List<TimeElement> view_table)
        {
            InitializeComponent();
            
            StringBuilder text = new StringBuilder();
            foreach (TimeElement te in view_table)
            {
                text.Append(Bot.Concat(Program.m.bot.subject[Convert.ToInt32(te.index)]));
                text.Append("$");
            }
            data = Base64.to(text.ToString());
        }

        private void frmExport_Load(object sender, EventArgs e)
        {
            rtbExport.Text = data;
        }
    }
}
