using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SystemProgramming.Lab06
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private const int IntervalSeconds = 30;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Trading Service STARTED at: {time}", DateTimeOffset.Now);
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Processing trade files at: {time}", DateTimeOffset.Now);

                    // Xử lý file 

                    await Task.Delay(TimeSpan.FromSeconds(IntervalSeconds), stoppingToken);
                }
                catch (TaskCanceledException)
                {
                    // Service đang dừng
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unexpected error occurred");
                }
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Trading Service STOPPED at: {time}", DateTimeOffset.Now);
            return base.StopAsync(cancellationToken);
        }
    }
}