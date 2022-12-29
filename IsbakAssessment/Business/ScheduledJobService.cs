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
                CoinMarketCapListDto list = _cryptoService.GetCurrencyRatesByTcmb();
                List<CryptoModel> cryptoList = ConvertToCryptoModel(list);
                await _cryptoService.SaveListToDatabase(cryptoList);
                await SendSignal(cryptoList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private List<CryptoModel> ConvertToCryptoModel(CoinMarketCapListDto list)
        {
            List<CryptoModel> cryptoList = list.Data
                   .Select(x => new CryptoModel()
                   {
                       Name = x.Name,
                       Symbol = x.Symbol,
                       Price = Math.Round(x.Quote.Try.Price, 2),
                       ChangeRate = Convert.ToInt32(x.Quote.Try.PercentChange24h)
                   })
                   .ToList();

            return cryptoList;
        }

        private async Task SendSignal(List<CryptoModel> newList)
        {
            var con = new HubConnectionBuilder()
              .WithUrl("https://localhost:44356/signalrurl")
              .Build();
            await con.StartAsync();
            await con.InvokeAsync("NewCryptoData", newList.ToArray());
            await con.DisposeAsync();
        }
    }
}