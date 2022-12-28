using System;

namespace IsbakAssessment.Models
{
    public class CryptoItem
    {
        public int CryptoItemId { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
