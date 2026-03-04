using System;
using System.IO;
using System.Threading.Tasks;

namespace SystemProgramming.Lab06
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string inputFolder = @"D:\system - programming - labs\Lab06\Q3\Input";
            string processedFolder = @"D:\system - programming - labs\Lab06\Q3\Processed";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(processedFolder);

            var processor = new ConcurrentFileProcessor(inputFolder, processedFolder);

            processor.Start();

            Console.WriteLine("Đang theo dõi thư mục. Nhấn Enter để thoát...");
            Console.ReadLine();
        }
    }
}