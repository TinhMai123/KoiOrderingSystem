
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
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepo _repo;



        // Constructor to initialize the repository
        public FeedbackService(IFeedbackRepo repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        // Add a new Feedback
        public async Task<bool> AddAsync(Feedback add)
        {
            if (add == null)
            {
                throw new ArgumentNullException(nameof(add), "Feedback cannot be null.");
            }
            if(add.Rating<0 && add.Rating > 5)
            {
                throw new Exception($"We do not accept this number");
            }

            return await _repo.Add(add);
        }

        // Retrieve all Feedback records
        public async Task<List<Feedback>> GetAlls()
        {
            return await _repo.GetAll();
        }

        // Retrieve a Feedback by ID
        public async Task<Feedback?> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        // Update an existing Feedback
        public async Task<bool> UpdateAsync(Feedback feedback)
        {
            if (feedback == null)
            {
                throw new ArgumentNullException(nameof(feedback), "Feedback cannot be null.");
            }
            if (feedback.Rating < 0 && feedback.Rating > 5)
            {
                throw new Exception($"We do not accept this number");
            }
            return await _repo.Update(feedback);
        }

        // Delete a Feedback
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.Remove(id);
        }
    }
}
