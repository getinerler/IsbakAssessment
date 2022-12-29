using IsbakAssessment.Business;
using IsbakAssessment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace IsbakAssessment
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int delay = 30000;
            string connectionString =
              "data source=.;initial catalog=IsbakAssessment;user id=sa;" +
              "MultipleActiveResultSets=True;integrated security=True;";

            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) => services
                    .AddTransient<ICryptoService, CryptoService>()
                    .AddTransient<IScheduledJobService, ScheduledJobService>()
                    .AddTransient<ICryptoRepo, CryptoRepo>()
                    .AddDbContext<DataContext>(options => options.UseSqlServer(connectionString)))
                .Build();

            using IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;
            IScheduledJobService _service = provider.GetRequiredService<IScheduledJobService>();

            while (true)
            {
                try
                {
                    await _service.SaveAndBroadcastNewCryptoCurrencies();
                    Console.WriteLine("Task done " + DateTime.Now.ToShortTimeString() + ".");
                    await Task.Delay(delay);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
