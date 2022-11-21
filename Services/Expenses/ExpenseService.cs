using Domain.Entities;
using Domain.Repositories;

namespace Services.Expenses
{
    public class ExpenseService : IExpenseService
    {
        private readonly IRepository _repository;
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IRepository repository, IExpenseRepository expenseRepository)
        {
            _repository = repository;
            _expenseRepository = expenseRepository;
        }
        public async Task<Expense> AddExpense(Expense model)
        {
            try
            {
                _repository.Add<Expense>(model);
                if (await _repository.SaveChangesAsync())
                {
                    return await _expenseRepository.GetBy(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteExpense(int id)
        {
            try
            {
                var expense = _expenseRepository.GetBy(id);
                if (expense == null)
                    throw new Exception("O dado não pôde ser encontrado ou não existe");

                _repository.Delete(expense);
                return await _repository.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Expense> GetBy(int expenseId)
        {
            try
            {
                var expense = await _expenseRepository.GetBy(expenseId);
                if (expense == null)
                    return null;

                return expense;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Expense>> GetExpenses()
        {
            try
            {
                var expenses = await _expenseRepository.GetAll();
                if (expenses == null)
                    return null;

                return expenses;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Expense> UpdateExpense(int id, Expense model)
        {
            try
            {
                var expense = await _expenseRepository.GetBy(id);
                if (expense == null)
                    return null;

                model.Id = expense.Id;

                _repository.Update<Expense>(model);

                if (await _repository.SaveChangesAsync())
                {
                    return await _expenseRepository.GetBy(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
