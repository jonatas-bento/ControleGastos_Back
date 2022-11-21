using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ApplicationDbContext _context;

        public ExpenseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Expense>> GetAll()
        {
            IQueryable<Expense> expenses = _context.Expenses.AsNoTracking();
            if (expenses.Count() > 0)
                return null;

            return await expenses.ToListAsync();
        }

        public async Task<Expense> GetBy(int id)
        {
            IQueryable<Expense> expense = _context.Expenses.AsNoTracking();
            var result = expense.OrderBy(x => x.Id)
                .Where(x => x.Id == id);

            return await result.FirstOrDefaultAsync();
        }
    }
}
