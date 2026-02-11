using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SystemProgramming.Lab05
{
    public class Question2
    {
        public static void Solution(string[] args)
        {
            PipeServerIPC.Run();
            PipeClientIPC.Run();
        }
    }
}