using System;
using System.Collections.Generic;
using ClassBookingRoom_Repository;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Repository;
using KoiOrderingSystem_Repository.IRepo;
using KoiOrderingSystem_Service.IService;

namespace KoiOrderingSystem_Service.Service
{
    public class KoiService : IKoiService
    {
        private readonly IBaseRepository<Koi> _koiRepository;
        private readonly IKoiRepo _repo;


        // Constructor to initialize the repository
        public KoiService(IBaseRepository<Koi> koiRepository)
        {
            _koiRepository = koiRepository;
        }

        // Add a new Koi
        public async Task<bool> AddAsync(Koi koi)
        {
            return await _koiRepository.AddAsync(koi);
        }

        // Remove an existing Koi
        public async Task<bool> DeleteAsync(int id)
        {
            
            return await _koiRepository.DeleteAsync(id);
        }

        // Get a Koi by its ID
        public async Task<Koi?> GetById(int id)
        {
            return await _koiRepository.GetByIdAsync(id);
        }

        // Update an existing Koi
        public async Task<bool> UpdateAsync(Koi update)
        {
            if (update == null)
            {
                throw new ArgumentNullException(nameof(update), "Koi cannot be null.");
            }
            return await _koiRepository.UpdateAsync(update);
        }

        // Get all Koi
        public async Task<List<Koi>> GetAlls()
        {
            return await _koiRepository.GetAllAsync();
        }

       
    }
}