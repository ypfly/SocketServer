namespace SocketServer
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox_Show = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button_SendALL = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.richTextBox_X = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBox_Show);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 255);
            this.panel1.TabIndex = 0;
            // 
            // richTextBox_Show
            // 
            this.richTextBox_Show.BackColor = System.Drawing.Color.Black;
            this.richTextBox_Show.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_Show.ForeColor = System.Drawing.Color.Lime;
            this.richTextBox_Show.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_Show.Name = "richTextBox_Show";
            this.richTextBox_Show.ReadOnly = true;
            this.richTextBox_Show.Size = new System.Drawing.Size(601, 255);
            this.richTextBox_Show.TabIndex = 0;
            this.richTextBox_Show.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.button_SendALL);
            this.panel2.Controls.Add(this.buttonSend);
            this.panel2.Controls.Add(this.splitter2);
            this.panel2.Controls.Add(this.richTextBox_X);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 255);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(601, 246);
            this.panel2.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 186);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 5;
            // 
            // button_SendALL
            // 
            this.button_SendALL.Location = new System.Drawing.Point(212, 186);
            this.button_SendALL.Name = "button_SendALL";
            this.button_SendALL.Size = new System.Drawing.Size(102, 37);
            this.button_SendALL.TabIndex = 4;
            this.button_SendALL.Text = "群发";
            this.button_SendALL.UseVisualStyleBackColor = true;
            this.button_SendALL.Click += new System.EventHandler(this.button_SendALL_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(462, 186);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(115, 37);
            this.buttonSend.TabIndex = 3;
            this.buttonSend.Text = "发送";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 157);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(601, 3);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // richTextBox_X
            // 
            this.richTextBox_X.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox_X.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_X.Name = "richTextBox_X";
            this.richTextBox_X.Size = new System.Drawing.Size(601, 157);
            this.richTextBox_X.TabIndex = 0;
            this.richTextBox_X.Text = "";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 255);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(601, 3);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 501);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox_Show;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.RichTextBox richTextBox_X;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button button_SendALL;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

