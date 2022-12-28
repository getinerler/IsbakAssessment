using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IsbakAssessment.Business
{
    class HostedService : IHostedService
    {
        private readonly IScheduledJobService _service;

        public HostedService(IScheduledJobService service)
        {
            _service = service;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await _service.SaveAndBroadcastNewCryptoCurrencies();
                Console.WriteLine(DateTime.Now);
                await Task.Delay(30000);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
