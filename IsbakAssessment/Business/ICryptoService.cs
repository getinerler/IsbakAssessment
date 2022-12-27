using IsbakAssessment.Dtos;
using System.Collections.Generic;

namespace IsbakAssessment.Business
{
    public interface ICryptoService
    {
        List<CryptoModel> GetCurrencyRatesByTcmb();
    }
}
