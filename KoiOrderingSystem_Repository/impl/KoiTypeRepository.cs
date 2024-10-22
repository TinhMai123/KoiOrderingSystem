using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_DAO;
using System.Collections.Generic;

namespace KoiOrderingSystem_Repository.impl
{
    public class KoiTypeRepository : IKoiTypeRepository
    {
        private readonly KoiTypeDAO _koiTypeDAO;

        // Constructor Dependency Injection for KoiTypeDAO
        public KoiTypeRepository(KoiTypeDAO koiTypeDAO)
        {
            _koiTypeDAO = koiTypeDAO ?? throw new ArgumentNullException(nameof(koiTypeDAO));
        }

        // Add a new KoiType
        public void AddKoiType(KoiType koiType) => KoiTypeDAO.Instance.Add(koiType);

        // Retrieve all KoiType records
        public List<KoiType> GetAllKoiTypes() => KoiTypeDAO.Instance.GetAll();
        // Retrieve a KoiType by ID
        public KoiType GetKoiTypeById(int id) => KoiTypeDAO.Instance.GetById(id);
        // Update an existing KoiType
        public void UpdateKoiType(KoiType koiType) => KoiTypeDAO.Instance.Update(koiType);

        // Delete a KoiType by ID
        public void DeleteKoiType(KoiType koiType) => KoiTypeDAO.Instance.Remove(koiType);
    }
}
