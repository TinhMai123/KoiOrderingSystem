using ClassBookingRoom_Repository;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Repository.IRepo;
using KoiOrderingSystem_Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Service.Service
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IBaseRepository<Currency> _currencyRepository;
        private readonly ICurrencyRepo _repo;



        // Constructor to initialize the repository
        public CurrencyService(IBaseRepository<Currency> currencyRepository, ICurrencyRepo repo)
        {
            _currencyRepository = currencyRepository ?? throw new ArgumentNullException(nameof(currencyRepository));
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        // Add a new Currency
        public async Task<bool> AddAsync(Currency add)
        {
            if (add == null)
            {
                throw new ArgumentNullException(nameof(add), "Currency cannot be null.");
            }
            return await _currencyRepository.AddAsync(add);
        }

        // Retrieve all Currency records
        public async Task<List<Currency>> GetAlls()
        {
            return await _currencyRepository.GetAllAsync();
        }

        // Retrieve a Currency by ID
        public async Task<Currency?> GetById(int id)
        {
            return await _currencyRepository.GetByIdAsync(id);
        }

        // Update an existing Currency
        public async Task<bool> UpdateAsync(Currency currency)
        {
            if (currency == null)
            {
                throw new ArgumentNullException(nameof(currency), "Currency cannot be null.");
            }
            return await _currencyRepository.UpdateAsync(currency);
        }

        // Delete a Currency
        public async Task<bool> DeleteAsync(int id)
        {
            return await _currencyRepository.DeleteAsync(id);
        }
    }
}
