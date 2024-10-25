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
    public class KoiByBatchService : IKoiByBatchService
    {
        private readonly IBaseRepository<KoiByBatch> _koiByBatchRepository;


        // Constructor to initialize the repository
        public KoiByBatchService(IBaseRepository<KoiByBatch> koiByBatchRepository)
        {
            _koiByBatchRepository = koiByBatchRepository ?? throw new ArgumentNullException(nameof(koiByBatchRepository));
        }

        // Add a new KoiByBatch
        public async Task<bool> AddAsync(KoiByBatch add)
        {
            if (add == null)
            {
                throw new ArgumentNullException(nameof(add), "KoiByBatch cannot be null.");
            }
            return await _koiByBatchRepository.AddAsync(add);
        }

        // Retrieve all KoiByBatch records
        public async Task<List<KoiByBatch>> GetAlls()
        {
            return await _koiByBatchRepository.GetAllAsync();
        }

        // Retrieve a KoiByBatch by ID
        public async Task<KoiByBatch?> GetById(int id)
        {
            return await _koiByBatchRepository.GetByIdAsync(id);
        }

        // Update an existing KoiByBatch
        public async Task<bool> UpdateAsync(KoiByBatch koiByBatch)
        {
            if (koiByBatch == null)
            {
                throw new ArgumentNullException(nameof(koiByBatch), "KoiByBatch cannot be null.");
            }
            return await _koiByBatchRepository.UpdateAsync(koiByBatch);
        }

        // Delete a KoiByBatch
        public async Task<bool> DeleteAsync(int id)
        {
            return await _koiByBatchRepository.DeleteAsync(id);
        }
    }
}
