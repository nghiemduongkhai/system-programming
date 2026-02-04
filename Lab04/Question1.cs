using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SystemProgramming.Lab04
{
    public class Question1
    {
        private static int counter = 0;
        private static object locker = new object();

        public static void Solution()
        {
            Task[] tasks = new Task[5];

            // Race Condition
            counter = 0;
            for (int i = 0; i < 5; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    for (int j = 0; j < 100000; j++)
                        counter++;   
                });
            }

            Task.WaitAll(tasks);
            Console.WriteLine("Race condition result: " + counter);

            //lock
            counter = 0;
            for (int i = 0; i < 5; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    for (int j = 0; j < 100000; j++)
                    {
                        lock (locker)
                        {
                            counter++;
                        }
                    }
                });
            }

            Task.WaitAll(tasks);
            Console.WriteLine("Using lock: " + counter);

            //Interlocked
            counter = 0;
            for (int i = 0; i < 5; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    for (int j = 0; j < 100000; j++)
                        Interlocked.Increment(ref counter);
                });
            }

            Task.WaitAll(tasks);
            Console.WriteLine("Using Interlocked: " + counter);
        }
    }
}