using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SystemProgramming.Lab05
{
    public class Question5
    {
        public static void Solution(string[] args)
        {
            // Run the server first, then the client in program arguments,not here
            JsonRpcClient.Run();
            JsonRpcServer.Run();
        }
    }
    }
}