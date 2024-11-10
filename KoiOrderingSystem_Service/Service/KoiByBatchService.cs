
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
    public class KoiByBatchService : IKoiByBatchService
    {
        private readonly IKoiByBatchRepo _repo;



        // Constructor to initialize the repository
        public KoiByBatchService(IKoiByBatchRepo repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        // Add a new KoiByBatch
        public async Task<bool> AddAsync(KoiByBatch add)
        {
            if (add == null)
            {
                throw new ArgumentNullException(nameof(add), "KoiByBatch cannot be null.");
            }
            if(add.Quantity < 0)
            {
                throw new Exception("Quantity cannot be smaller than 0");
            }
            if(add.Size < 0)
            {
                throw new Exception("Size cannot be smaller than 0");
            }
            if(add.Price < 0)
            {
                throw new Exception("Price cannot be smaller than 0");
            }
            return await _repo.Add(add);
        }

        // Retrieve all KoiByBatch records
        public async Task<List<KoiByBatch>> GetAlls()
        {
            return await _repo.GetAll();
        }

        // Retrieve a KoiByBatch by ID
        public async Task<KoiByBatch?> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        // Update an existing KoiByBatch
        public async Task<bool> UpdateAsync(KoiByBatch koiByBatch)
        {
            if (koiByBatch == null)
            {
                throw new ArgumentNullException(nameof(koiByBatch), "KoiByBatch cannot be null.");
            }
            if (koiByBatch.Quantity < 0)
            {
                throw new Exception("Quantity cannot be smaller than 0");
            }
            if (koiByBatch.Size < 0)
            {
                throw new Exception("Size cannot be smaller than 0");
            }
            if (koiByBatch.Price < 0)
            {
                throw new Exception("Price cannot be smaller than 0");
            }
            return await _repo.Update(koiByBatch);
        }

        // Delete a KoiByBatch
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.Remove(id);
        }
    }
}
