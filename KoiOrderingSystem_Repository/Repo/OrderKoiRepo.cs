
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
    public class OrderKoiRepo : IOrderKoiRepo
    {
        public async Task<bool> Add(KoiOrder model)
        {
            return await OrderKoiDAO.Instance.Add(model);
        }

        public async Task<List<KoiOrder>> GetAll()
        {
            return await OrderKoiDAO.Instance.GetAll();
        }

        public async Task<KoiOrder?> GetById(int id)
        {
            return await OrderKoiDAO.Instance.GetById(id);
        }

        public async Task<List<KoiOrder>> ReadAll()
        {
            return await OrderKoiDAO.Instance.ReadAll();
        }

        public async Task<KoiOrder?> ReadById(int id)
        {
            return await OrderKoiDAO.Instance.ReadById(id);
        }

        public async Task<bool> Remove(int id)
        {
            return await OrderKoiDAO.Instance.Remove(id);
        }

        public async Task<bool> Update(KoiOrder model)
        {
            return await OrderKoiDAO.Instance.Update(model);
        }
    }
}
