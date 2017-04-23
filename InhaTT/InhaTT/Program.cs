using System;
using System.Windows.Forms;

namespace InhaTT
{
    static class Program
    {
        static public frmMain m;

        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            if ( (m = new frmMain()).IsOpenSafety )
                Application.Run(m);
        }
    }
}
