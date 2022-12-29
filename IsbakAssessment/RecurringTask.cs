using System;
using System.Threading;
using System.Threading.Tasks;

namespace IsbakAssessment.Business
{
    class RecurringTask
    {
        private readonly IScheduledJobService _service;

        public RecurringTask(IScheduledJobService service)
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
