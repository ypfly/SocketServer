using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketServer
{
    class MyDelegate
    {
        delegate void SetShowRichTextBoxText(object sender, string msg);
        delegate void SetCombVale(object sender, object value);
      public  void DoShowMSGFunc(object sendr, string msg)
        {
          
            string message = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss \n    ") + msg ;
            RichTextBox rtb = (RichTextBox)sendr;
            if (rtb.InvokeRequired)
            {
                SetShowRichTextBoxText stbt = new SetShowRichTextBoxText(ShowMSG);
                rtb.Invoke(stbt, new object[] { rtb, message });
            }
            else
            {
                rtb.AppendText(message + "\n");
            }
        }
        void ShowMSG(object sendr, string msg)
        {
            if (sendr == null)
                return;
            RichTextBox rb = (RichTextBox)sendr;
            rb.AppendText(msg+"\n");  
        }

        public void DoSetCombVale(object sendr, object value)
        {
            ComboBox rtb = (ComboBox)sendr;
            IList<ipss> dc = (IList<ipss>)value;
            if (rtb.InvokeRequired)
            {
                SetCombVale stbt = new SetCombVale(setCMBValue);
                rtb.Invoke(stbt, new object[] { rtb, dc });
            }
            else
            {
                rtb.DataSource = dc;
                rtb.DisplayMember = "ip";
              
            }
        } 
        void setCMBValue(object sendr, object value)
        {
            ComboBox c=(ComboBox)sendr;
            IList<ipss> dc = (IList<ipss>)value;
            c.DataSource = dc;
          
            c.DisplayMember = "ip";
        }
    }
}
