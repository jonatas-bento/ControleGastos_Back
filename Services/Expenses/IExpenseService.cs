using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Expenses
{
    public interface IExpenseService
    {
        Task<Expense> AddExpense(Expense model);
        Task<List<Expense>> GetExpenses();
        Task<Expense> GetBy(int expenseId);
        Task<Expense> UpdateExpense(int id, Expense model);
        Task<bool> DeleteExpense(int id);
    }
}
