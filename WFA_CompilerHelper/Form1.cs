/*
    Copyright (c) 2012 H.T.D htd@demon-inc.tw

    Permission is hereby granted, free of charge, to any person obtaining a copy of this software 
    and associated documentation files (the "Software"), to deal in the Software without restriction, 
    including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
    and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, 
    subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all copies or substantial 
    portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
    INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
  
    IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, 
    DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
  
    Copyright (c) 2012 H.T.D htd@demon-inc.tw
     
    軟體的著作權利人依此MIT授權條款，將其對於軟體的著作權利授權釋出，
    只要使用者踐履以下二項MIT授權條款敘明的義務性規定，
    其即享有對此軟體程式及其相關說明文檔自由不受限制地進行利用的權利，
    範圍包括「使用、重製、修改、合併、出版、散布、再授權、及販售程式重製作品」等諸多方面的應用，
    而散布程式之人、更可將上述權利傳遞予其後收受程式的後手，
    倘若其後收受程式之人亦服膺以下二項MIT授權條款的義務性規定，
    則其對程式亦享有與前手運用範圍相同的同一權利。
  
    散布此一軟體程式者，須將本條款其上的「著作權聲明」及以下的「免責聲明」，
    內嵌於軟體程式及其重製作品的實體之中。
 
    因MIT軟體程式的授權模式乃是無償提供，是以在現行法律的架構下可以主張合理的免除擔保責任。
    MIT軟體的著作權人或任何的後續散布者，對於其所散布的MIT軟體程式皆不負任何形式上實質上的擔保責任，
    明示亦或隱喻、商業利用性亦或特定目的使用性，這些均不在保障之列。利用MIT軟體程式的所有風險均由使用者自行擔負。
    假如所使用的MIT程式發生缺陷性問題，使用者需自行擔負修正、改正及必要的服務支出。
    MIT軟體程式的著作權人不負任何形式上實質上的擔保責任，無論任何一般的、特殊的、偶發的、因果關係式的損害，
    或是MIT軟體程式的不適用性，均須由使用者自行負擔。 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;

namespace WFA_CompilerHelper
{
    public partial class Form1 : Form
    {
        private string windowsPath = Environment.GetEnvironmentVariable("windir");
        private string[] frameworkPath = {  "Microsoft.NET\\Framework\\v2.0.50727",
                                        "Microsoft.NET\\Framework\\v3.5",
                                        "Microsoft.NET\\Framework\\v4.0.30319",
                                        "Microsoft.NET\\Framework64\\v2.0.50727",
                                        "Microsoft.NET\\Framework64\\v3.5",
                                        "Microsoft.NET\\Framework64\\v4.0.30319"
                                     };

        private string[] framework = {  "Framework 2.0 (x86)",
                                    "Framework 3.5 (x86)",
                                    "Framework 4.0 (x86)",
                                    "Framework 2.0 (x64)",
                                    "Framework 3.5 (x64)",
                                    "Framework 4.0 (x64)" 
                                 };

        protected void changeButtonEnabledStatus(bool IO)
        {
            btn_source.Enabled = IO;
            btn_output.Enabled = IO;
            btn_go.Enabled = IO;
        }

        /// <summary>
        /// The function determines whether the current operating system is a 
        /// 64-bit operating system.
        /// </summary>
        /// <returns>
        /// The function returns true if the operating system is 64-bit; 
        /// otherwise, it returns false.
        /// </returns>
        public static bool Is64BitOperatingSystem()
        {
            if (IntPtr.Size == 8)  // 64-bit programs run only on Win64
            {
                return true;
            }
            else  // 32-bit programs run on both 32-bit and 64-bit Windows
            {
                // Detect whether the current process is a 32-bit process 
                // running on a 64-bit system.
                bool flag;
                return ((DoesWin32MethodExist("kernel32.dll", "IsWow64Process") &&
                    IsWow64Process(GetCurrentProcess(), out flag)) && flag);
            }
        }

        /// <summary>
        /// The function determins whether a method exists in the export 
        /// table of a certain module.
        /// </summary>
        /// <param name="moduleName">The name of the module</param>
        /// <param name="methodName">The name of the method</param>
        /// <returns>
        /// The function returns true if the method specified by methodName 
        /// exists in the export table of the module specified by moduleName.
        /// </returns>
        static bool DoesWin32MethodExist(string moduleName, string methodName)
        {
            IntPtr moduleHandle = GetModuleHandle(moduleName);
            if (moduleHandle == IntPtr.Zero)
            {
                return false;
            }
            return (GetProcAddress(moduleHandle, methodName) != IntPtr.Zero);
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr GetCurrentProcess();

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr GetModuleHandle(string moduleName);

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule,
            [MarshalAs(UnmanagedType.LPStr)]string procName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWow64Process(IntPtr hProcess, out bool wow64Process);

        public Form1()
        {
            InitializeComponent();
        }

        // Check the .NET Framework of this PC
        protected void loadFramework()
        {
            if (Is64BitOperatingSystem())
            {
                for (int a = 3; a < frameworkPath.Length; a++)
                {
                    if (Directory.Exists(string.Format("{0}\\{1}", windowsPath, frameworkPath[a])))
                    {
                        cb_Framework.Items.Add(new ListItem(framework[a], frameworkPath[a]));
                    }
                }
            }
            else
            {
                for (int a = 0; a <=3 ; a++)
                {
                    if (Directory.Exists(string.Format("{0}\\{1}", windowsPath, frameworkPath[a])))
                    {
                        cb_Framework.Items.Add(new ListItem(framework[a], frameworkPath[a]));
                    }
                }
            }

            if (cb_Framework.Items.Count > 0)
            {
                cb_Framework.SelectedIndex = 0;
            }
            else
            {
                cb_Framework.Items.Add("找不到可用的.NET Framework");
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadFramework();
            cb_Framework.DisplayMember = "text";
            cb_Framework.ValueMember = "value";
        }

        private void btn_source_Click(object sender, EventArgs e)
        {
            lb_message.Text = "";
            if (cbox_compilerSite.Checked)
            {
                // 開啟對話框
                if (folderBrowserDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                {
                    // 使用者沒有選檔案
                    return;
                }
                
                txt_source.Text = folderBrowserDialog1.SelectedPath;
            }
            else
            {
                if ((string.IsNullOrEmpty(openFileDialog1.InitialDirectory)))
                {
                    openFileDialog1.InitialDirectory = "C:";
                }

                openFileDialog1.Filter =
                        "類別檔 (*.cs)|*.cs";
                openFileDialog1.Title = "請選擇來源";
                openFileDialog1.Multiselect = false; // 允許選取多檔案

                // 開啟對話框
                if (openFileDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                {
                    // 使用者沒有選檔案
                    return;
                }

                txt_source.Text = openFileDialog1.FileName;
            }
        }

        private void btn_output_Click(object sender, EventArgs e)
        {
            lb_message.Text = "";
            if (cbox_compilerSite.Checked)
            {
                // 開啟對話框
                if (folderBrowserDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                {
                    // 使用者沒有選檔案
                    return;
                }

                txt_output.Text = folderBrowserDialog1.SelectedPath;
            }
            else
            {
                saveFileDialog1.Filter =
                               "應用程式 (*.exe)|*.exe|動態連接庫 (*.dll)|*.dll";
                saveFileDialog1.Title = "請選擇輸出位置";

                // 開啟對話框
                if (saveFileDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                {
                    // 使用者沒有選檔案
                    return;
                }

                txt_output.Text = saveFileDialog1.FileName;
            }
        }

        private void btn_go_Click(object sender, EventArgs e)
        {


            bool TF = false;
            string frameworkFullPath = null;
            string compilerType = null;     //csc || aspnet_compiler
            string command = null;          //csc:/target:library, /optimize; aspnet_compiler: -f -v -p
            
            lb_message.Text = "";
            if (cbox_compilerSite.Checked)
            {
                try
                {
                    if (!string.IsNullOrEmpty(txt_source.Text) && Directory.Exists(txt_source.Text) && !string.IsNullOrEmpty(txt_output.Text) && Directory.Exists(txt_output.Text))
                    {
                        compilerType = "aspnet_compiler.exe";
                        frameworkFullPath = string.Format("{0}\\{1}\\{2}", windowsPath, ((ListItem)cb_Framework.SelectedItem).value, compilerType);
                        command = string.Format("-f -v /Publish -p \"{0}\" \"{1}\"", txt_source.Text, txt_output.Text);
                        TF = true;
                    }
                    else
                        lb_message.Text = "請檢查來源以及輸出位置";
                }
                catch
                {
                    lb_message.Text = "請檢查來源以及輸出位置";
                }
            }
            else
            {
                int b = 0;
                if (!string.IsNullOrEmpty(txt_output.Text))
                    b = txt_output.Text.LastIndexOf('\\');

                try
                {
                    if (!string.IsNullOrEmpty(txt_source.Text) && File.Exists(txt_source.Text) && !string.IsNullOrEmpty(txt_output.Text) && Directory.Exists(txt_output.Text.Remove(b)))
                    {
                        compilerType = "csc.exe";
                        frameworkFullPath = string.Format("{0}\\{1}\\{2}", windowsPath, ((ListItem)cb_Framework.SelectedItem).value, compilerType);
                        int a = txt_output.Text.LastIndexOf('.');

                        if (txt_output.Text.Substring(a).Equals(".dll"))
                            command = string.Format("/target:library /out:\"{0}\" \"{1}\"", txt_output.Text, txt_source.Text);
                        else
                            command = string.Format("/optimize /out:\"{0}\" \"{1}\"", txt_output.Text, txt_source.Text);
                        
                        TF = true;
                    }
                    else
                        lb_message.Text = "請檢查來源以及輸出位置";
                }
                catch
                {
                    lb_message.Text = "請檢查來源以及輸出位置";
                }
            }

            if (TF)
            {
                changeButtonEnabledStatus(false);
                Process _Process = new Process();
                _Process.StartInfo.FileName = frameworkFullPath;
                _Process.StartInfo.Arguments = command;
                _Process.StartInfo.UseShellExecute = false; //隱藏執行的csc或aspnet_compiler
                _Process.StartInfo.CreateNoWindow = true;   //隱藏執行的csc或aspnet_compiler
                _Process.StartInfo.RedirectStandardError = true;
                _Process.StartInfo.RedirectStandardInput = true;
                _Process.StartInfo.RedirectStandardOutput = true;
                _Process.EnableRaisingEvents = true;
                _Process.SynchronizingObject = this;

                try
                {
                    _Process.Start();

                    using (StreamWriter sw = new StreamWriter(string.Format("{0}\\report.log", System.Environment.CurrentDirectory), false))
                    {
                        sw.WriteLine(_Process.StandardOutput.ReadToEnd());
                    }
                    
                    _Process.Exited += new EventHandler(_Process_Exited);
                    _Process.WaitForExit();
                    _Process.Close();                    
                }
                catch (Exception ex)
                {
                    changeButtonEnabledStatus(true);
                    lb_message.Text = "編譯出錯了>\"<";
                }
            }
        }

        void _Process_Exited(object sender, EventArgs e)
        {
            changeButtonEnabledStatus(true);
            lb_message.Text = "編譯結束囉^_^";
        }

        private void cbox_compilerSite_CheckedChanged(object sender, EventArgs e)
        {
            cb_Framework.Items.Clear();
            txt_output.Text = "";
            txt_source.Text = "";
            if (cbox_compilerSite.Checked)
            {
                if (Is64BitOperatingSystem())
                {
                    for (int a = 3; a < frameworkPath.Length; a++)
                    {
                        if (Directory.Exists(string.Format("{0}\\{1}", windowsPath, frameworkPath[a])))
                        {
                            if (a != 4)
                                cb_Framework.Items.Add(new ListItem(framework[a], frameworkPath[a]));
                        }
                    }
                }
                else
                {
                    for (int a = 0; a <= 3; a++)
                    {
                        if (Directory.Exists(string.Format("{0}\\{1}", windowsPath, frameworkPath[a])))
                        {
                            if (a != 1)
                                cb_Framework.Items.Add(new ListItem(framework[a], frameworkPath[a]));
                        }
                    }
                }

                if (cb_Framework.Items.Count > 0)
                {
                    cb_Framework.SelectedIndex = 0;
                }
                else
                {
                    cb_Framework.Items.Add("找不到可用的.NET Framework");
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;
                    groupBox3.Enabled = false;
                }
            }
            else
                loadFramework();
        }

        private void btn_about_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("{0} v{1}\r\nAuthor: H.T.D\r\nhtd@demon-inc.tw", 
                this.Text, 
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()));
        }

    }
}
