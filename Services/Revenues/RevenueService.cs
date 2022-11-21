using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Revenues
{
    public class RevenueService : IRevenueService
    {
        private readonly IRepository _repository;
        private readonly IRevenueRepository _revenueRepository;

        public RevenueService(IRepository repository, IRevenueRepository revenueRepository)
        {
            _repository = repository;
            _revenueRepository = revenueRepository;
        }
        public async Task<Revenue> AddRevenue(Revenue model)
        {
            try
            {
                _repository.Add<Revenue>(model);
                if (await _repository.SaveChangesAsync())
                {
                    return await _revenueRepository.GetBy(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteRevenue(int id)
        {
            try
            {
                var revenue = _revenueRepository.GetBy(id);
                if (revenue == null)
                    throw new Exception("O dado não pôde ser encontrado ou não existe");

                _repository.Delete(revenue);
                return await _repository.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Revenue> GetBy(int revenueId)
        {
            try
            {
                var revenue = await _revenueRepository.GetBy(revenueId);
                if (revenue == null)
                    return null;

                return revenue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<List<Revenue>> GetRevenues()
        {
            try
            {
                var revenues = await _revenueRepository.GetAll();
                if (revenues == null)
                    return null;

                return revenues;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Revenue> UpdateRevenue(int id, Revenue model)
        {
            try
            {
                var revenue = await _revenueRepository.GetBy(id);
                if (revenue == null)
                    return null;

                model.Id = revenue.Id;

                _repository.Update<Revenue>(model);

                if (await _repository.SaveChangesAsync())
                {
                    return await _revenueRepository.GetBy(model.Id);
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
