using IsbakAssessment.Dtos;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Web;

namespace IsbakAssessment.Business
{
    public class CryptoService : ICryptoService
    {
        public CoinMarketCapListDto GetCurrencyRatesByTcmb()
        {
            //Token tükenirse sandbox ortamı kullanılabilir.
            //https://sandbox-api.coinmarketcap.com/v1/cryptocurrency/listings/latest

            UriBuilder URL = new UriBuilder(Globals.CoinMarketCapUrl);

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = "1";
            queryString["limit"] = "100";
            queryString["convert"] = "TRY";

            URL.Query = queryString.ToString();

            WebClient client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", Globals.CoinMarketCapKey);
            client.Headers.Add("Accepts", "application/json");
            string res = client.DownloadString(URL.ToString());

            CoinMarketCapListDto item = JsonConvert.DeserializeObject<CoinMarketCapListDto>(res);
            return item;
        }
    }
}
