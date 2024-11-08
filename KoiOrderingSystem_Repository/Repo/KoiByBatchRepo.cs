
using KoiOrderingSystem_BusinessObject.Data;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiOrderingSystem_DAO;

namespace KoiOrderingSystem_Repository.Repo
{
    public class KoiByBatchRepo : IKoiByBatchRepo
    {
        public async Task<bool> Add(KoiByBatch model)
        {
            return await KoiByBatchDAO.Instance.Add(model);
        }

        public async Task<List<KoiByBatch>> GetAll()
        {
            return await KoiByBatchDAO.Instance.GetAll();
        }

        public async Task<KoiByBatch?> GetById(int id)
        {
            return await KoiByBatchDAO.Instance.GetById(id);
        }

        public async Task<bool> Remove(int id)
        {
            return await KoiByBatchDAO.Instance.Remove(id);
        }

        public async Task<bool> Update(KoiByBatch model)
        {
            return await KoiByBatchDAO.Instance.Update(model);
        }
    }
}
