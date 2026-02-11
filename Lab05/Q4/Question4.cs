using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;

namespace SystemProgramming.Lab05
{
    public class Question4
    {
        public static void Solution()
        {
            string folder = "input";
            Directory.CreateDirectory(folder);

            FileSystemWatcher watcher = new FileSystemWatcher(folder);
            watcher.Created += OnFileCreated;
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Monitoring folder... Press Enter.");
            Console.ReadLine();
        }

        public static void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    // wait 
                    Task.Delay(1000).Wait();

                    byte[] data = File.ReadAllBytes(e.FullPath);
                    string output = e.FullPath + ".gz";

                    using (FileStream fs = new FileStream(output, FileMode.Create))
                    {
                        using (GZipStream gzip = new GZipStream(fs, CompressionMode.Compress))
                        {
                            gzip.Write(data, 0, data.Length);
                        }
                    }

                    Console.WriteLine($"Compressed: {e.Name}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }
    }
}