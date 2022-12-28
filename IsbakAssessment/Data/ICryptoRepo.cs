using IsbakAssessment.Dtos;
using IsbakAssessment.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsbakAssessment.Data
{
    public interface ICryptoRepo
    {
        Task<List<CryptoItem>> GetLastItems(int num);
        Task SaveList(List<CryptoModel> list);
    }
}
