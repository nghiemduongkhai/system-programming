using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace SystemProgramming.Lab06
{
    public class ConcurrentFileProcessor
    {
        private readonly string _inputFolder;
        private readonly string _processedFolder;

        private readonly FileSystemWatcher _watcher;
        private readonly ConcurrentQueue<string> _queue = new();
        private readonly HashSet<string> _processingFiles = new();
        private readonly SemaphoreSlim _semaphore = new(1, 1);

        public ConcurrentFileProcessor(string inputFolder, string processedFolder)
        {
            _inputFolder = inputFolder;
            _processedFolder = processedFolder;

            _watcher = new FileSystemWatcher(_inputFolder, "*.json");
            _watcher.Created += OnFileCreated;
            _watcher.EnableRaisingEvents = false;
        }

        public void Start()
        {
            _watcher.EnableRaisingEvents = true;
            Task.Run(ProcessQueueAsync);
        }

        private void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            _queue.Enqueue(e.FullPath);
        }

        private async Task ProcessQueueAsync()
        {
            while (true)
            {
                while (_queue.TryDequeue(out string filePath))
                {
                    await ProcessFileAsync(filePath);
                }

                await Task.Delay(500);
            }
        }

        private async Task ProcessFileAsync(string filePath)
        {
            await _semaphore.WaitAsync();

            try
            {
                if (!File.Exists(filePath))
                    return;

                if (_processingFiles.Contains(filePath))
                    return;

                _processingFiles.Add(filePath);

                // Đợi file ghi xong
                await Task.Delay(500);

                string content = await File.ReadAllTextAsync(filePath);

                Console.WriteLine($"Đang xử lý: {Path.GetFileName(filePath)}");

                // Giả lập xử lý
                await Task.Delay(1000);

                string destPath = Path.Combine(_processedFolder, Path.GetFileName(filePath));

                File.Move(filePath, destPath, true);

                Console.WriteLine($"Đã chuyển sang Processed: {Path.GetFileName(filePath)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi xử lý file: {ex.Message}");
            }
            finally
            {
                _processingFiles.Remove(filePath);
                _semaphore.Release();
            }
        }
    }
}