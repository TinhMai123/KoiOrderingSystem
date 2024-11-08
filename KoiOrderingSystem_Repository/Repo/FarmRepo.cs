
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using KoiOrderingSystem_DAO;
using KoiOrderingSystem_Repository.IRepo;
using System.Collections.Generic;

namespace KoiOrderingSystem_Repository.Repo

{
    public class FarmRepo : IFarmRepo
    {
        public async Task<bool> Add(Farm model)
        {
            return await FarmDAO.Instance.Add(model);
        }

        public async Task<List<Farm>> GetAll()
        {
            return await FarmDAO.Instance.GetAll();
        }

        public async Task<Farm?> GetById(int id)
        {
            return await FarmDAO.Instance.GetById(id);
        }

        public async Task<bool> Remove(int id)
        {
            return await FarmDAO.Instance.Remove(id);
        }

        public async Task<bool> Update(Farm model)
        {
            return await FarmDAO.Instance.Update(model);
        }
    }
}
