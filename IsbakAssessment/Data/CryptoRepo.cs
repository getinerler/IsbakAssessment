using IsbakAssessment.Dtos;
using IsbakAssessment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsbakAssessment.Data
{
    public class CryptoRepo : ICryptoRepo
    {
        private readonly DataContext _ctx;

        public CryptoRepo(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<CryptoItem>> GetLastItems(int num)
        {

            List<CryptoItem> list = await _ctx.CryptoItems
                .OrderByDescending(x => x.CryptoItemId)
                .Take(num)
                .ToListAsync();

            return list;
        }

        public async Task SaveList(List<CryptoModel> list)
        {
            List<CryptoItem> listForRepo = list
                .Select(x => new CryptoItem()
                {
                    Name = x.Symbol,
                    Symbol = x.Symbol,
                    Price = x.Price,
                    CreatedDate = DateTime.Now
                })
                .ToList();

            _ctx.AddRange(listForRepo);
            await _ctx.SaveChangesAsync();
        }
    }
}
