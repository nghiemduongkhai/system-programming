using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SystemProgramming.Lab04
{
    public class Question2
    {
        public static void Solution()
        {
            Task task1 = Task.Run(() =>
            {
                Task.Delay(1000).Wait();
                Console.WriteLine("Task 1 finished");
            });

            Task task2 = Task.Run(() =>
            {
                Task.Delay(1500).Wait();
                Console.WriteLine("Task 2 finished");
            });

            Task task3 = Task.Run(() =>
            {
                Task.Delay(800).Wait();
                Console.WriteLine("Task 3 finished");
            });

            Task.WhenAll(task1, task2, task3).Wait();

            Console.WriteLine("All tasks completed.");
        }
    }
}