using IsbakAssessment.Dtos;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsbakAssessment.Business
{
    public class ScheduledJobService : IScheduledJobService
    {
        private readonly ICryptoService _cryptoService;

        public ScheduledJobService(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        public async Task SaveAndBroadcastNewCryptoCurrencies()
        {
            try
            {
                List<CryptoModel> list = _cryptoService.GetCurrencyRatesByTcmb();

                await _cryptoService.SaveListToDatabase(list);

                List<CryptoSignalRModel> newList = list
                    .Select(x => new CryptoSignalRModel()
                    {
                        Name = x.Symbol,
                        Symbol = x.Symbol,
                        Price = x.AskPrice,
                        ChangeRate = 5
                    })
                    .ToList();

                await SendSignal(newList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task SendSignal(List<CryptoSignalRModel> newList)
        {

            var con = new HubConnectionBuilder()
              .WithUrl("https://localhost:44356/signalrurl")
              .Build();

            await con.StartAsync();

            await con.InvokeAsync("NewCryptoData", newList.ToArray());
        }
    }
}