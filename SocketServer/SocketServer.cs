using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketServer
{
    class ipss
    {
        public string ip { get; set; }
        public string port { get; set; }
        public string StrRemoteEndPoint { get; set; }
    }
    class SocketServer
    {

        private IPEndPoint ServerInfo;//存放服务器的IP和端口
        private Socket ServerSocket;//服务器端运行的Socket
        private Thread ServerThread;//服务端运行的线程
        private Socket[] ClientSocket; //存放客户端数量

        Thread threadWatch = null; // 负责监听客户端连接请求的 线程；  
        Socket socketWatch = null;

        Dictionary<string, Socket> dict = new Dictionary<string, Socket>();
        Dictionary<string, Thread> dictThread = new Dictionary<string, Thread>();
        List<ipss> dictip = new List<ipss>();
        MyDelegate md = new MyDelegate();
        ipss ips = null;

        /// <summary>
        /// 监听客户端
        /// </summary>
        public void ListenClient(object sender, string ipstr, string port)
        {
            object[] arrobj = (object[])sender;
            object rtb = arrobj[0];
            // 创建负责监听的套接字，注意其中的参数；  
            socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // 获得文本框中的IP对象；  
            IPAddress address = IPAddress.Parse(ipstr);
            // 创建包含ip和端口号的网络节点对象；  
            IPEndPoint endPoint = new IPEndPoint(address, int.Parse(port));
            try
            {
                // 将负责监听的套接字绑定到唯一的ip和端口上；  
                socketWatch.Bind(endPoint);
            }
            catch (SocketException se)
            {
                md.DoShowMSGFunc(rtb, "异常：" + se.Message);

                return;
            }
            // 设置监听队列的长度；  
            socketWatch.Listen(10);
            // 创建负责监听的线程；  
            threadWatch = new Thread(WatchConnecting);

            threadWatch.IsBackground = true;
            threadWatch.Start(sender);
            md.DoShowMSGFunc(rtb, "服务器启动监听成功!");
            //}  
        }

        /// <summary>  
        /// 监听客户端请求的方法；  
        /// </summary>  
        void WatchConnecting(object sender)
        {
            object[] a = (object[])sender;
            object ShowMsgC = (object)a[0];
            while (true)  // 持续不断的监听客户端的连接请求；  
            {
                // 开始监听客户端连接请求，Accept方法会阻断当前的线程；  
                Socket sokConnection = socketWatch.Accept(); // 一旦监听到一个客户端的请求，就返回一个与该客户端通信的 套接字；  
                // 想列表控件中添加客户端的IP信息；  

                string ipport = sokConnection.RemoteEndPoint.ToString();
                ips = new ipss() { ip = ipport.Substring(0, ipport.IndexOf(":")), port = ipport.Substring(ipport.IndexOf(":") + 1, ipport.Length - ipport.IndexOf(":") - 1), StrRemoteEndPoint = ipport };
                dictip.Add(ips);

                // 将与客户端连接的 套接字 对象添加到集合中；  
                dict.Add(sokConnection.RemoteEndPoint.ToString(), sokConnection);

                md.DoShowMSGFunc(ShowMsgC, ipport.Substring(0, ipport.IndexOf(":")) + "客户端连接成功");
                md.DoSetCombVale(a[1], dictip);
                Thread thr = new Thread(RecMsg);
                //  ThreadPool.QueueUserWorkItem(RecMsg, new object[] { sokConnection, sender });
                thr.IsBackground = true;
                thr.Start(new object[] { sokConnection, ShowMsgC });
                dictThread.Add(sokConnection.RemoteEndPoint.ToString(), thr);  //  将新建的线程 添加 到线程的集合中去。  
            }
        }


        void RecMsg(object a)
        {
            object[] aa = (object[])a;
            Socket sokClient = aa[0] as Socket;
            object sender = (object)aa[1];
            while (true)
            {
                // 定义一个2M的缓存区；  
                byte[] arrMsgRec = new byte[1024 * 1024 * 2];
                // 将接受到的数据存入到输入  arrMsgRec中；  
                int length = -1;
                try
                {
                    length = sokClient.Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
                }
                catch (SocketException se)
                {
                    md.DoShowMSGFunc(aa[1], "异常：" + se.Message);

                    // 从 通信套接字 集合中删除被中断连接的通信套接字；  
                    dict.Remove(sokClient.RemoteEndPoint.ToString());
                    // 从通信线程集合中删除被中断连接的通信线程对象；  
                    dictThread.Remove(sokClient.RemoteEndPoint.ToString());
                    // 从列表中移除被中断的连接IP  
                    for (int i = 0; i < dictip.Count; i++)
                    {
                        if (dictip[i].StrRemoteEndPoint == sokClient.RemoteEndPoint.ToString())
                        {
                            dictip.RemoveAt(i);
                        }
                    }
                    //dictip.RemoveAt(sokClient.RemoteEndPoint.ToString());
                    break;
                }
                catch (Exception e)
                {
                    md.DoShowMSGFunc(sender, "异常：" + e.Message);
                    // 从 通信套接字 集合中删除被中断连接的通信套接字；  
                    dict.Remove(sokClient.RemoteEndPoint.ToString());
                    // 从通信线程集合中删除被中断连接的通信线程对象；  
                    dictThread.Remove(sokClient.RemoteEndPoint.ToString());
                    // 从列表中移除被中断的连接IP  
                    dict.Remove(sokClient.RemoteEndPoint.ToString());
                    break;
                }
                if (arrMsgRec[0] == 0)  // 表示接收到的是数据；  
                {
                    string strMsg = System.Text.Encoding.UTF8.GetString(arrMsgRec, 1, length - 1);// 将接受到的字节数据转化成字符串；  
                    string sip = sokClient.RemoteEndPoint.ToString();
                    md.DoShowMSGFunc(sender, sip.Substring(0, sip.IndexOf(":")) + ":" + strMsg);
                }
                //if (arrMsgRec[0] == 1) // 表示接收到的是文件；  
                //{
                //    SaveFileDialog sfd = new SaveFileDialog();

                //    if (sfd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                //    {// 在上边的 sfd.ShowDialog（） 的括号里边一定要加上 this 否则就不会弹出 另存为 的对话框，而弹出的是本类的其他窗口，，这个一定要注意！！！【解释：加了this的sfd.ShowDialog(this)，“另存为”窗口的指针才能被SaveFileDialog的对象调用，若不加thisSaveFileDialog 的对象调用的是本类的其他窗口了，当然不弹出“另存为”窗口。】  

                //        string fileSavePath = sfd.FileName;// 获得文件保存的路径；  
                //        // 创建文件流，然后根据路径创建文件；  
                //        using (FileStream fs = new FileStream(fileSavePath, FileMode.Create))
                //        {
                //            fs.Write(arrMsgRec, 1, length - 1);
                //            ShowMsg("文件保存成功：" + fileSavePath);
                //        }
                //    }
                //}
            }
        }

        // 发送消息  
        public void btnSend(object sender, string ip, MyMessage Mmsg)
        {
            string strMsg = "服务器  -->" + Mmsg.msg ;
          
                
            byte[] arrMsg= ByteConvertHelper.SerializeObject(Mmsg); 
           
        
            string strKey = "";
            for (int i = 0; i < dictip.Count; i++)
            {
                if (dictip[i].ip == ip)
                    strKey = dictip[i].StrRemoteEndPoint;
            }

            if (string.IsNullOrEmpty(strKey))   // 判断是不是选择了发送的对象；  
            {
                md.DoShowMSGFunc(sender, "请选择你要发送的Ip！！！");
            }
            else
            {
                dict[strKey].Send(arrMsg);// 解决了 sokConnection是局部变量，不能再本函数中引用的问题；                  
                md.DoShowMSGFunc(sender, strMsg);
            }
        }

        /// <summary>  
        /// 群发消息  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e">消息</param>  
        public void btnSendToAll(object sender, string msg)
        {
            string strMsg = "服务器" + "\r\n" + "   -->" + msg;
            byte[] arrMsg = System.Text.Encoding.UTF8.GetBytes(msg); // 将要发送的字符串转换成Utf-8字节数组； 

            byte[] arrSendMsg = new byte[arrMsg.Length + 1]; // 上次写的时候把这一段给弄掉了，实在是抱歉哈~ 用来标识发送是数据而不是文件，如果没有这一段的客户端就接收不到消息了~~~  
            arrSendMsg[0] = 0; // 表示发送的是消息数据  
            Buffer.BlockCopy(arrMsg, 0, arrSendMsg, 1, arrMsg.Length);
            int i = 0;
            foreach (ipss s in dictip)
            {
                i=i+dict[s.StrRemoteEndPoint].Send(arrMsg);
            }
            md.DoShowMSGFunc(sender,strMsg);
            md.DoShowMSGFunc(sender, "群发完毕～～～"+i);
          
        }
    }
}

