using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SystemProgramming.Lab02
{
    public class Question3
    {
        public static void Solution()
        {
            Console.WriteLine("Program started");

            int result = Add(3, 6);

            Console.WriteLine($"Result = {result}");
        }

        public static int Add(int a, int b)
        {
            return a + b;
        }
    }
}