using ChattingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattingServer
{
    public class ConnectedClient
    {
        //conection back to client
        public IClient connection;

        public string UserName { get; set; }
    }
}
