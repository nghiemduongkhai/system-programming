using System;
using System.Text;
using Microsoft.Win32;

namespace SystemProgramming.Lab06
{
    public class Question2
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                ServiceConfig config = ServiceConfig.Load();

                Console.WriteLine("Đọc cấu hình thành công:");
                Console.WriteLine($"InputFolder     : {config.InputFolder}");
                Console.WriteLine($"ProcessedFolder : {config.ProcessedFolder}");
                Console.WriteLine($"IntervalSeconds : {config.IntervalSeconds}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi cấu hình:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}