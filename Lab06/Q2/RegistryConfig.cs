using System;
using Microsoft.Win32;

namespace SystemProgramming.Lab06
{
    public class ServiceConfig
    {
        public string InputFolder { get; set; }
        public string ProcessedFolder { get; set; }
        public int IntervalSeconds { get; set; }

        public static ServiceConfig Load()
        {
            const string registryPath = @"SOFTWARE\TradingService";

            using RegistryKey key = Registry.LocalMachine.OpenSubKey(registryPath);

            if (key == null)
                throw new Exception("Không tìm thấy Registry key.");

            string inputFolder = key.GetValue("InputFolder")?.ToString();
            string processedFolder = key.GetValue("ProcessedFolder")?.ToString();
            object intervalObj = key.GetValue("IntervalSeconds");

            if (string.IsNullOrWhiteSpace(inputFolder))
                throw new Exception("Thiếu InputFolder.");

            if (string.IsNullOrWhiteSpace(processedFolder))
                throw new Exception("Thiếu ProcessedFolder.");

            if (intervalObj == null)
                throw new Exception("Thiếu IntervalSeconds.");

            int intervalSeconds = Convert.ToInt32(intervalObj);

            if (intervalSeconds <= 0)
                throw new Exception("IntervalSeconds phải lớn hơn 0.");

            return new ServiceConfig
            {
                InputFolder = inputFolder,
                ProcessedFolder = processedFolder,
                IntervalSeconds = intervalSeconds
            };
        }
    }
}