using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SystemProgramming.Lab05
{
    public class Question3
    {
        public static void Solution(string[] arg)
        {
            TcpClient.Run();
            TcpServer.Run();
        }
    }
}