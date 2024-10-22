using System;
using System.Collections.Generic;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Repository;
using KoiOrderingSystem_Repository.impl;

namespace KoiOrderingSystem_Service
{
    public class KoiTypeService : IKoiTypeService
    {
        private readonly IKoiTypeRepository _koiTypeRepository;

        // Constructor to initialize the repository
        public KoiTypeService(IKoiTypeRepository koiTypeRepository)
        {
            _koiTypeRepository = koiTypeRepository;
        }

        // Add a new KoiType
        public void AddKoiType(KoiType koiType)
        {
            if (koiType == null)
            {
                throw new ArgumentNullException(nameof(koiType), "KoiType cannot be null.");
            }
            _koiTypeRepository.AddKoiType(koiType);
        }

        // Retrieve all KoiType records
        public List<KoiType> GetAllKoiTypes()
        {
            return _koiTypeRepository.GetAllKoiTypes();
        }

        // Retrieve a KoiType by ID
        public KoiType GetKoiTypeById(int id)
        {
            return _koiTypeRepository.GetKoiTypeById(id);
        }

        // Update an existing KoiType
        public void UpdateKoiType(KoiType koiType)
        {
            if (koiType == null)
            {
                throw new ArgumentNullException(nameof(koiType), "KoiType cannot be null.");
            }
            _koiTypeRepository.UpdateKoiType(koiType);
        }

        // Delete a KoiType by ID
        public void DeleteKoiType(KoiType koiType)
        {
            if (koiType == null)
            {
                throw new ArgumentNullException(nameof(koiType), "KoiType cannot be null.");
            }
            _koiTypeRepository.DeleteKoiType(koiType);
        }
    }
}