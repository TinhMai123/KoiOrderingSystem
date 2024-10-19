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
        public void AddKoiType(KoiType koiType)=> KoiTypeDAO.Instance.AddKoiType(koiType);

        // Retrieve all KoiType records
        public List<KoiType> GetAllKoiTypes()=>KoiTypeDAO.Instance.GetAllKoiTypes();
        // Retrieve a KoiType by ID
        public KoiType GetKoiTypeById(int id)=>KoiTypeDAO.Instance.GetKoiTypeById(id);
        // Update an existing KoiType
        public void UpdateKoiType(KoiType koiType)=>KoiTypeDAO.Instance.UpdateKoiType(koiType);

        // Delete a KoiType by ID
        public void DeleteKoiType(KoiType koiType)=>KoiTypeDAO.Instance.DeleteKoiType(koiType);
    }
}
