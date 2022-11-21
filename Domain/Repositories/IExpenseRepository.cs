using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IExpenseRepository
    {
        Task<List<Expense>> GetAll();
        Task<Expense> GetBy(int id);
    }
}
