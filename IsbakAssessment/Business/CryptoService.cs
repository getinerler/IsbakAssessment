using IsbakAssessment.Data;
using IsbakAssessment.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace IsbakAssessment.Business
{
    public class CryptoService : ICryptoService
    {
        private readonly string Url = "https://www.binance.com/api/v3/ticker/bookTicker";
        private readonly ICryptoRepo _repo;

        public CryptoService(ICryptoRepo repo)
        {
            _repo = repo;
        }

        public List<CryptoModel> GetCurrencyRatesByTcmb()
        {
            string text = Get(Url, string.Empty);
            List<CryptoModel> list = JsonConvert.DeserializeObject<List<CryptoModel>>(text);
            return list;
        }

        public async Task SaveListToDatabase(List<CryptoModel> list)
        {
            await _repo.SaveList(list);
        }

        private static string Get(string uri, string parameters)
        {
            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(uri);
                HttpResponseMessage response = client.GetAsync(parameters).Result;
                response.EnsureSuccessStatusCode();
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
        }
    }
}
