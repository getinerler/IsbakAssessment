using IsbakAssessment.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace IsbakAssessment.Business
{
    public class CryptoService : ICryptoService
    {
        private readonly string Url = "https://www.binance.com/api/v3/ticker/bookTicker";

        public List<CryptoModel> GetCurrencyRatesByTcmb()
        {
            string text = Get(Url, string.Empty);
            List<CryptoModel> list = JsonConvert.DeserializeObject<List<CryptoModel>>(text);
            return list;
        }

        private static string Get(string uri, string parameters)
        {
            using (var client = new HttpClient(new HttpClientHandler
            { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
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
