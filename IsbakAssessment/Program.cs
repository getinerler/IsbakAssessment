using IsbakAssessment.Business;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace IsbakAssessment
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IWebHost host = WebHost
                .CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureServices(services => services
                    .AddTransient<ICryptoService, CryptoService>()
                    .AddTransient<IHostedService, HostedService>()
                    .AddHostedService<HostedService>())
                .Build();

            host.Run();
        }
    }

    public class Startup
    {
        public IConfiguration _config { get; }

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            AddDependencies(services);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
        }

        private void AddDependencies(IServiceCollection services)
        {
            services.AddTransient<ICryptoService, CryptoService>();
            //services.AddTransient<IHostedService, HostedService>();
            services.AddTransient<IScheduledJobService, ScheduledJobService>();
        }
    }
}
