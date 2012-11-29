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

namespace WFA_CompilerHelper
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_about = new System.Windows.Forms.Button();
            this.lb_message = new System.Windows.Forms.Label();
            this.btn_go = new System.Windows.Forms.Button();
            this.cb_Framework = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbox_compilerSite = new System.Windows.Forms.CheckBox();
            this.txt_source = new System.Windows.Forms.TextBox();
            this.btn_source = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_output = new System.Windows.Forms.Button();
            this.txt_output = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_about);
            this.groupBox1.Controls.Add(this.lb_message);
            this.groupBox1.Controls.Add(this.btn_go);
            this.groupBox1.Controls.Add(this.cb_Framework);
            this.groupBox1.Font = new System.Drawing.Font("新細明體", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(2, 174);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "選擇Framework";
            // 
            // btn_about
            // 
            this.btn_about.Location = new System.Drawing.Point(173, 51);
            this.btn_about.Name = "btn_about";
            this.btn_about.Size = new System.Drawing.Size(20, 23);
            this.btn_about.TabIndex = 5;
            this.btn_about.Text = "?";
            this.btn_about.UseVisualStyleBackColor = true;
            this.btn_about.Click += new System.EventHandler(this.btn_about_Click);
            // 
            // lb_message
            // 
            this.lb_message.AutoSize = true;
            this.lb_message.Location = new System.Drawing.Point(6, 55);
            this.lb_message.Name = "lb_message";
            this.lb_message.Size = new System.Drawing.Size(0, 15);
            this.lb_message.TabIndex = 4;
            // 
            // btn_go
            // 
            this.btn_go.Location = new System.Drawing.Point(199, 51);
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(75, 23);
            this.btn_go.TabIndex = 3;
            this.btn_go.Text = "開始編譯";
            this.btn_go.UseVisualStyleBackColor = true;
            this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
            // 
            // cb_Framework
            // 
            this.cb_Framework.FormattingEnabled = true;
            this.cb_Framework.Location = new System.Drawing.Point(6, 24);
            this.cb_Framework.Name = "cb_Framework";
            this.cb_Framework.Size = new System.Drawing.Size(268, 23);
            this.cb_Framework.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbox_compilerSite);
            this.groupBox2.Controls.Add(this.txt_source);
            this.groupBox2.Controls.Add(this.btn_source);
            this.groupBox2.Font = new System.Drawing.Font("新細明體", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox2.Location = new System.Drawing.Point(2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 80);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "選擇來源";
            // 
            // cbox_compilerSite
            // 
            this.cbox_compilerSite.AutoSize = true;
            this.cbox_compilerSite.Location = new System.Drawing.Point(107, 54);
            this.cbox_compilerSite.Name = "cbox_compilerSite";
            this.cbox_compilerSite.Size = new System.Drawing.Size(86, 19);
            this.cbox_compilerSite.TabIndex = 2;
            this.cbox_compilerSite.Text = "編譯網站";
            this.cbox_compilerSite.UseVisualStyleBackColor = true;
            this.cbox_compilerSite.CheckedChanged += new System.EventHandler(this.cbox_compilerSite_CheckedChanged);
            // 
            // txt_source
            // 
            this.txt_source.AllowDrop = true;
            this.txt_source.Location = new System.Drawing.Point(6, 24);
            this.txt_source.Name = "txt_source";
            this.txt_source.Size = new System.Drawing.Size(268, 25);
            this.txt_source.TabIndex = 1;
            // 
            // btn_source
            // 
            this.btn_source.Location = new System.Drawing.Point(199, 51);
            this.btn_source.Name = "btn_source";
            this.btn_source.Size = new System.Drawing.Size(75, 23);
            this.btn_source.TabIndex = 0;
            this.btn_source.Text = "選擇檔案";
            this.btn_source.UseVisualStyleBackColor = true;
            this.btn_source.Click += new System.EventHandler(this.btn_source_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_output);
            this.groupBox3.Controls.Add(this.txt_output);
            this.groupBox3.Font = new System.Drawing.Font("新細明體", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox3.Location = new System.Drawing.Point(2, 88);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 80);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "選擇輸出位置";
            // 
            // btn_output
            // 
            this.btn_output.Location = new System.Drawing.Point(199, 51);
            this.btn_output.Name = "btn_output";
            this.btn_output.Size = new System.Drawing.Size(75, 23);
            this.btn_output.TabIndex = 2;
            this.btn_output.Text = "選擇位置";
            this.btn_output.UseVisualStyleBackColor = true;
            this.btn_output.Click += new System.EventHandler(this.btn_output_Click);
            // 
            // txt_output
            // 
            this.txt_output.AllowDrop = true;
            this.txt_output.Location = new System.Drawing.Point(6, 24);
            this.txt_output.Name = "txt_output";
            this.txt_output.Size = new System.Drawing.Size(268, 25);
            this.txt_output.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DereferenceLinks = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.Name = "Form1";
            this.Text = "Compiler Helper 崁拍了幫手";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_source;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_source;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cb_Framework;
        private System.Windows.Forms.Button btn_output;
        private System.Windows.Forms.TextBox txt_output;
        private System.Windows.Forms.Button btn_go;
        private System.Windows.Forms.CheckBox cbox_compilerSite;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lb_message;
        private System.Windows.Forms.Button btn_about;
    }
}

