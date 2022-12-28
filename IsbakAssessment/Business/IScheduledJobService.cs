using System.Threading.Tasks;

namespace IsbakAssessment.Business
{
    public interface IScheduledJobService
    {
        Task SaveAndBroadcastNewCryptoCurrencies();
    }
}
