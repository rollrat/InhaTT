/***

   Copyright (C) 2017. rollrat. All Rights Reserved.

   05-30-2017:   HyunJun Jeong, Creation

***/

using System.Windows.Forms;

namespace InhaTT_Creator
{
    public partial class frmInfo : Form
    {
        public frmInfo()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/rollrat/InhaTT");
        }
    }
}
