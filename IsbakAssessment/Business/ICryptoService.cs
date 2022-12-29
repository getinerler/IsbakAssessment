using IsbakAssessment.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsbakAssessment.Business
{
    public interface ICryptoService
    {
        CoinMarketCapListDto GetCurrencyRatesByTcmb();
        Task SaveListToDatabase(List<CryptoModel> list);
    }
}
