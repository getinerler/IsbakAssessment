using IsbakAssessment.Dtos;

namespace IsbakAssessment.Business
{
    public interface ICryptoService
    {
        CoinMarketCapListDto GetCurrencyRatesByTcmb();
    }
}
