/***

   Copyright (C) 2017. rollrat. All Rights Reserved.

   03-21-2017:   HyunJun Jeong, Creation

***/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InhaTT_Downloader
{
    public partial class frmDownLoader : Form
    {
        Bot bot = new Bot();
        int iter = 0;
        StringBuilder builder = new StringBuilder();
        
        public frmDownLoader()
        {
            InitializeComponent();
        }

        private void frmDownLoader_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://sugang.inha.ac.kr/sugang/SU_51001/Lec_Time_Search.htm");

            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wb_DocumentCompleted);
        }

        bool r = false;
        bool o = false;

        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if ( o)
            {

                HtmlWindow docWindow1 = webBrowser1.Document.Window;

                foreach (HtmlWindow frameWindow in docWindow1.Frames)
                {
                    Regex regex = new Regex(@"<font color=""blue"">(.*?)</font>.*?Center"">(.*?)</td>.*?Center"">(.*?)</td>.*?Center"">(.*?)</td>.*?Center"">(.*?)</td>.*?Center"">(.*?)</td>.*?Center"">(.*?)</td>.*?Center"">(.*?)</td>.*?Center"">(.*?)</td>.*?Center"">(.*?)</td>");
                    Match match = regex.Match(frameWindow.Document.Body.OuterHtml);

                    while (match.Success)
                    {
                        bot.html_data = match.Groups[0].Value;
                        if (iter > 0)
                            bot.ParseSubject(((Bot.FieldStruct)bot.field[iter - 1]).magic);
                        else
                            bot.ParseSubject("0");
                        match = match.NextMatch();
                    }
                }
                
                System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"datas.txt", bot.SubjectsToString());

                System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"gbsf.txt", bot.GetSortedBySubjectField());
                System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"gbsm.txt", bot.GetSortedBySubjectMagic());
                System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"gbsn.txt", bot.GetSortedBySubjectName());
                System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"gsbp.txt", bot.GetSortedBySubjectPro());

                this.Close();
                return;
            }

            HtmlWindow docWindow = webBrowser1.Document.Window;

            foreach (HtmlWindow frameWindow in docWindow.Frames)
            {
                Regex regex = new Regex(@"<font color=""blue"">(.*?)</font>.*?Center"">(.*?)</td>.*?Center"">(.*?)</td>.*?Center"">(.*?)</td>.*?Center"">(.*?)</td>.*?Center"">(.*?)</td>.*?Center"">(.*?)</td>.*?Center"">(.*?)</td>.*?Center"">(.*?)</td>.*?Center"">(.*?)</td>");
                Match match = regex.Match(frameWindow.Document.Body.OuterHtml);
                
                while (match.Success)
                {
                    bot.html_data = match.Groups[0].Value;
                    if (iter > 0)
                        bot.ParseSubject(((Bot.FieldStruct)bot.field[iter - 1]).magic);
                    else
                        bot.ParseSubject("0");
                    match = match.NextMatch();
                }

                if (((Bot.FieldStruct)bot.field[iter]).magic == "4")
                    r = true;

                if (r == false)
                {
                    frameWindow.Document.GetElementById("ddlDept").SetAttribute("value", ((Bot.FieldStruct)bot.field[iter]).magic);
                    frameWindow.Document.Body.All.GetElementsByName("ibtnSearch1")[0].InvokeMember("click");
                }
                else
                {
                    frameWindow.Document.GetElementById("ddlKita").SetAttribute("value", ((Bot.FieldStruct)bot.field[iter]).magic);
                    frameWindow.Document.Body.All.GetElementsByName("ibtnSearch2")[0].InvokeMember("click");
                }
                iter++;
                if (bot.field.Count <= iter)
                {
                    o = true;
                }
                return;
            }

        }
    }
}
