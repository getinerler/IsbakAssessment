using Newtonsoft.Json;

namespace IsbakAssessment.Dtos
{
    public class CryptoModel
    {
        public string Name { get; set; }
        public string  Symbol { get; set; }
        public decimal Price { get; set; }
        public int ChangeRate { get; set; }
    }
}
