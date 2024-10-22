using System;
using System.Collections.Generic;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Repository;

namespace KoiOrderingSystem_Service
{
    public class KoiService : IKoiService
    {
        private readonly IKoiRepository _koiRepository;

        // Constructor to initialize the repository
        public KoiService(IKoiRepository koiRepository)
        {
            _koiRepository = koiRepository;
        }

        // Add a new Koi
        public void addKoi(Koi koi)
        {
            if (koi == null)
            {
                throw new ArgumentNullException(nameof(koi), "Koi cannot be null.");
            }
            _koiRepository.addKoi(koi);
        }

        // Remove an existing Koi
        public void removeKoi(Koi koi)
        {
            if (koi == null)
            {
                throw new ArgumentNullException(nameof(koi), "Koi cannot be null.");
            }
            _koiRepository.removeKoi(koi);
        }

        // Get a Koi by its ID
        public Koi getKoiById(int koiId)
        {
            return _koiRepository.getKoiById(koiId);
        }

        // Update an existing Koi
        public void updateKoi(Koi koi)
        {
            if (koi == null)
            {
                throw new ArgumentNullException(nameof(koi), "Koi cannot be null.");
            }
            _koiRepository.updateKoi(koi);
        }

        // Get all Koi
        public List<Koi> getall()
        {
            return _koiRepository.getall();
        }
    }
}