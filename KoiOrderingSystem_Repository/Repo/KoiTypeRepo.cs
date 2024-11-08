
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using KoiOrderingSystem_DAO;
using KoiOrderingSystem_Repository.IRepo;
using System.Collections.Generic;

namespace KoiOrderingSystem_Repository.Repo
{
    public class KoiTypeRepo : IKoiTypeRepo
    {
        public async Task<bool> Add(KoiType model)
        {
            return await KoiTypeDAO.Instance.Add(model);
        }

        public async Task<List<KoiType>> GetAll()
        {
            return await KoiTypeDAO.Instance.GetAll();
        }

        public async Task<KoiType?> GetById(int id)
        {
            return await KoiTypeDAO.Instance.GetById(id);
        }

        public async Task<bool> Remove(int id)
        {
            return await KoiTypeDAO.Instance.Remove(id);
        }

        public async Task<bool> Update(KoiType model)
        {
            return await KoiTypeDAO.Instance.Update(model);
        }
    }
}
