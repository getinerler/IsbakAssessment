using IsbakAssessment.Business;
using IsbakAssessment.Dtos;
using System;
using System.Collections.Generic;

namespace IsbakAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            ICryptoService service = new CryptoService();
            List<CryptoModel> list = service.GetCurrencyRatesByTcmb();

            foreach (CryptoModel item in list)
            {
                Console.WriteLine(
                    item.Symbol + " " + 
                    item.BidQty + " " +
                    item.AskQty + " " +
                    item.AskPrice);
            }

            Console.ReadLine();
        }
    }
}
