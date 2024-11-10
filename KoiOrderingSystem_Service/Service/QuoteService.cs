
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

    public class QuoteService : IQuoteService
    {
        private readonly IQuoteRepo _repo;

        // Constructor to initialize the repository
        public QuoteService( IQuoteRepo repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        // Add a new Quote
        public async Task<bool> AddAsync(Quote add)
        {
            if (add == null)
            {
                throw new ArgumentNullException(nameof(add), "Quote cannot be null.");
            }
            return await _repo.Add(add);
        }

        // Retrieve all Quote records
        public async Task<List<Quote>> GetAlls()
        {
            return await _repo.GetAll();
        }

        // Retrieve a Quote by ID
        public async Task<Quote?> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        // Update an existing Quote
        public async Task<bool> UpdateAsync(Quote quote)
        {
            if (quote == null)
            {
                throw new ArgumentNullException(nameof(quote), "Quote cannot be null.");
            }
            return await _repo.Update(quote);
        }

        // Delete a Quote
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.Remove(id);
        }
    }
}
