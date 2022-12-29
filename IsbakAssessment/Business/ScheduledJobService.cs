using IsbakAssessment.Data;
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
        private readonly ICryptoRepo _cryptoRepo;

        public ScheduledJobService(ICryptoService cryptoService, ICryptoRepo cryptoRepo)
        {
            _cryptoService = cryptoService;
            _cryptoRepo = cryptoRepo;
        }

        public async Task SaveAndBroadcastNewCryptoCurrencies()
        {
            CoinMarketCapListDto list = _cryptoService.GetCurrencyRatesByTcmb();
            List<CryptoModel> cryptoList = ConvertToCryptoModel(list);
            await _cryptoRepo.SaveList(cryptoList);
            await SendSignal(cryptoList);
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
              .WithUrl(Globals.FrontendProjectUrl)
              .Build();
            await con.StartAsync();
            await con.InvokeAsync("NewCryptoData", newList.ToArray());
            await con.DisposeAsync();
        }
    }
}