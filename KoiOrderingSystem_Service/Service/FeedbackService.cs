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
    public class FeedbackService : IFeedbackService
    {
        private readonly IBaseRepository<Feedback> _feebackRepository;
        private readonly IFeedbackRepo _repo;



        // Constructor to initialize the repository
        public FeedbackService(IBaseRepository<Feedback> feebackRepository, IFeedbackRepo repo)
        {
            _feebackRepository = feebackRepository ?? throw new ArgumentNullException(nameof(feebackRepository));
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        // Add a new Feedback
        public async Task<bool> AddAsync(Feedback add)
        {
            if (add == null)
            {
                throw new ArgumentNullException(nameof(add), "Feedback cannot be null.");
            }
            return await _feebackRepository.AddAsync(add);
        }

        // Retrieve all Feedback records
        public async Task<List<Feedback>> GetAlls()
        {
            return await _feebackRepository.GetAllAsync();
        }

        // Retrieve a Feedback by ID
        public async Task<Feedback?> GetById(int id)
        {
            return await _feebackRepository.GetByIdAsync(id);
        }

        // Update an existing Feedback
        public async Task<bool> UpdateAsync(Feedback feeback)
        {
            if (feeback == null)
            {
                throw new ArgumentNullException(nameof(feeback), "Feedback cannot be null.");
            }
            return await _feebackRepository.UpdateAsync(feeback);
        }

        // Delete a Feedback
        public async Task<bool> DeleteAsync(int id)
        {
            return await _feebackRepository.DeleteAsync(id);
        }
    }
}
