
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Repository.IRepo;
using KoiOrderingSystem_Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace KoiOrderingSystem_Service.Service
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepo _repo;

        public CurrencyService(ICurrencyRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> AddAsync(Currency add)
        {
            if (add == null)
            {
                throw new ArgumentNullException(nameof(add), "Currency cannot be null.");
            }
            var check = await _repo.ReadAll();
            check = check.Where(c=>c.Name == add.Name).ToList();
            if (check.Any())
            {
                throw new Exception($"Currency {add.Name} had already been added");
            }
            if (add.ExchangeRate <= 0)
            {
                throw new Exception($"Exchange Rate is lower than 0");
            }
                return await _repo.Add(add);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.Remove(id);
        }

        public async Task<List<Currency>> GetAlls()
        {
            return await _repo.GetAll();
        }

        public async Task<Currency?> GetById(int id)
        {
            return await _repo.GetById(id);
        }
        
        public async Task<bool> UpdateAsync(Currency update)
        {
            if (update == null)
            {
                throw new ArgumentNullException(nameof(update), "Currency cannot be null.");
            }
            var check = await _repo.ReadAll();
            check = check.Where(c=>c.Name == update.Name).ToList();
            if (check == null)
            {
                throw new Exception($"You cannot change the currency name to something new");
            }
            if (update.ExchangeRate <= 0)
            {
                throw new Exception($"Exchange Rate is lower than 0");
            }
            return await _repo.Update(update);
        }
    }


}
