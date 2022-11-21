using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Revenues
{
    public interface IRevenueService
    {
        Task<Revenue> AddRevenue(Revenue model);
        Task<List<Revenue>> GetRevenues();
        Task<Revenue> GetBy(int revenueId);
        Task<Revenue> UpdateRevenue(int id, Revenue model);
        Task<bool> DeleteRevenue(int id);
    }
}
