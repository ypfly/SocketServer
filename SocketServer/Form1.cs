using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
namespace SocketServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SocketServer sockerS = new SocketServer();
        private void Form1_Load(object sender, EventArgs e)
        {
            sockerS.ListenClient(new object[] { richTextBox_Show, comboBox1 }, "10.6.103.183", "9950");         
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            sockerS.btnSend(richTextBox_Show, comboBox1.Text, new MyMessage() { id="0",msg=richTextBox_X.Text});
            richTextBox_X.Clear();
        }

        private void button_SendALL_Click(object sender, EventArgs e)
        {
            sockerS.btnSendToAll(richTextBox_Show,richTextBox_X.Text);
            richTextBox_X.Clear();
        }
      

     
    }
}
