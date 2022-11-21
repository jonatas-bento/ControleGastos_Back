using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Expenses;
using Services.Revenues;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Controle_De_Gastos_FamiliaBento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinantialController : ControllerBase
    {
        private readonly IExpenseService _expenseService;
        private readonly IRevenueService _revenueService;

        public FinantialController(IExpenseService expenseService, IRevenueService revenueService)
        {
            this._expenseService = expenseService;
            this._revenueService = revenueService;
        }
        // GET: api/<FinantialController>
        [HttpGet("Expenses")]
        public async Task<IActionResult> GetExpenses()
        {
            try
            {
                var expenses = await _expenseService.GetExpenses();
                if (expenses == null)
                    return BadRequest();

                return Ok(expenses);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }

        // GET api/<FinantialController>/5
        [HttpGet("Expenses/{id}")]
        public async Task<IActionResult> GetExpenseById(int id)
        {
            try
            {
                var expense = await _expenseService.GetBy(id);
                if (expense == null)
                    return NotFound();

                return Ok(expense);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        // GET: api/<FinantialController>
        [HttpGet("Revenues")]
        public async Task<IActionResult> GetRevenues()
        {
            try
            {
                var revenues = await _revenueService.GetRevenues();
                if (revenues == null)
                    return BadRequest();

                return Ok(revenues);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }

        // GET api/<FinantialController>/5
        [HttpGet("Revenues/{id}")]
        public async Task<IActionResult> GetRevenueById(int id)
        {
            try
            {
                var revenue = await _revenueService.GetBy(id);
                if (revenue == null)
                    return NotFound();

                return Ok(revenue);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }

        // POST api/<FinantialController>
        [HttpPost("Expenses")]
        public async Task<IActionResult> InsertExpense(Expense model)
        {
            try
            {
                var expense = await _expenseService.AddExpense(model);
                if (expense == null)
                    return BadRequest();

                return Ok(expense);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT api/<FinantialController>/5
        [HttpPut("Expenses/{id}")]
        public async Task<IActionResult> EditExpense(int id, Expense model)
        {
            try
            {
                var expense = await _expenseService.UpdateExpense(id, model);
                if (expense == null)
                    return NotFound();

                return Ok(expense);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Erro ao tentar atualizar aluno. Erro, {ex.Message}");
                throw;
            }
            


        }



        // POST api/<FinantialController>
        [HttpPost("Revenues")]
        public async Task<IActionResult> InsertRevenue(Revenue model)
        {
            try
            {
                var revenue = await _revenueService.AddRevenue(model);
                if (revenue == null)
                    return BadRequest();

                return Ok(revenue);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT api/<FinantialController>/5
        [HttpPut("Revenues/{id}")]
        public async Task<IActionResult> EditRevenue(int id, Revenue model)
        {
            try
            {
                var revenue = await _revenueService.UpdateRevenue(id, model);
                if (revenue == null)
                    return NotFound();

                return Ok(revenue);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Erro ao tentar atualizar aluno. Erro, {ex.Message}");
                throw;
            }



        }

        // DELETE api/<FinantialController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
