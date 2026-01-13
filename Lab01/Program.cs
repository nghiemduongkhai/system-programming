using System;
using System.Diagnostics;

namespace SystemProgramming.Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            Process p = Process.GetCurrentProcess();

            PrintLine();
            PrintRow("OS", "");
            PrintLine();

            PrintRow("OS Version", Environment.OSVersion.ToString());
            PrintRow("Machine Name", Environment.MachineName);
            PrintRow("Processor Count", Environment.ProcessorCount.ToString());
            PrintRow("Current Directory", Environment.CurrentDirectory);
            PrintRow("System Time", DateTime.Now.ToString());

            PrintLine();
            PrintRow("Process ID (PID)", p.Id.ToString());
            PrintRow("Start Time", p.StartTime.ToString());
            PrintRow("CPU Time Used", p.TotalProcessorTime.ToString());
            PrintRow("Memory Usage (KB)", (p.WorkingSet64 / 1024).ToString());

            PrintLine();

            Console.ReadKey();
        }

        static void PrintLine()
        {
            Console.WriteLine("+----------------------+-----------------------------------------------+");
        }

        static void PrintRow(string col1, string col2)
        {
            Console.WriteLine(
                $"| {col1,-20} | {col2,-45} |"
            );
        }
    }
}
