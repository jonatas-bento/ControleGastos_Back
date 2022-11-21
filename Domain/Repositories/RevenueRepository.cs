using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class RevenueRepository : IRevenueRepository
    {
        private readonly ApplicationDbContext _context;

        public RevenueRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Revenue>> GetAll()
        {
            IQueryable<Revenue> revenues = _context.Revenues.AsNoTracking();
            if (revenues.Count() > 0)
                return null;

            return await revenues.ToListAsync();
        }

        public async Task<Revenue> GetBy(int id)
        {
            IQueryable<Revenue> revenues = _context.Revenues.AsNoTracking();
            var result = revenues.OrderBy(x => x.Id)
                .Where(x => x.Id == id);

            return await result.FirstOrDefaultAsync();
        }

    }
}
