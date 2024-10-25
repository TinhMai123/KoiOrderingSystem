using ClassBookingRoom_Repository;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Service.Service
{

    public class QuoteService : IQuoteService
    {
        private readonly IBaseRepository<Quote> _quoteRepository;


        // Constructor to initialize the repository
        public QuoteService(IBaseRepository<Quote> quoteRepository)
        {
            _quoteRepository = quoteRepository ?? throw new ArgumentNullException(nameof(quoteRepository));
        }

        // Add a new Quote
        public async Task<bool> AddAsync(Quote add)
        {
            if (add == null)
            {
                throw new ArgumentNullException(nameof(add), "Quote cannot be null.");
            }
            return await _quoteRepository.AddAsync(add);
        }

        // Retrieve all Quote records
        public async Task<List<Quote>> GetAlls()
        {
            return await _quoteRepository.GetAllAsync();
        }

        // Retrieve a Quote by ID
        public async Task<Quote?> GetById(int id)
        {
            return await _quoteRepository.GetByIdAsync(id);
        }

        // Update an existing Quote
        public async Task<bool> UpdateAsync(Quote quote)
        {
            if (quote == null)
            {
                throw new ArgumentNullException(nameof(quote), "Quote cannot be null.");
            }
            return await _quoteRepository.UpdateAsync(quote);
        }

        // Delete a Quote
        public async Task<bool> DeleteAsync(int id)
        {
            return await _quoteRepository.DeleteAsync(id);
        }
    }
}
