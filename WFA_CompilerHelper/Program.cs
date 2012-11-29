using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WFA_CompilerHelper
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class ListItem
    {
        public string text { set; get; }
        public string value { set; get; }
        /// <summary>
        /// 自製ListItem
        /// </summary>
        /// <param name="_text">清單控制項所代表的項目中所顯示的文字</param>
        /// <param name="_value">相關聯的值</param>
        public ListItem(string _text, string _value)
        {
            this.text = _text;
            this.value = _value;
        }
    }
}
