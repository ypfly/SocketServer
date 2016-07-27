using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer
{
    [Serializable]
    public class MyMessage
    {
       public string id { get; set; }
       public string msg { get; set; }
    }
}
