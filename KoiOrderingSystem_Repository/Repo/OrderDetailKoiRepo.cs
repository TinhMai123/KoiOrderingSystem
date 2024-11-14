
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
    public class OrderDetailKoiRepo : IOrderDetailKoiRepo
    {
        public async Task<bool> Add(KoiOrderDetail model)
        {
            return await OrderDetailKoiDAO.Instance.Add(model);
        }

        public async Task<List<KoiOrderDetail>> GetAll()
        {
            return await OrderDetailKoiDAO.Instance.GetAll();
        }

        public async Task<KoiOrderDetail?> GetById(int id)
        {
            return await OrderDetailKoiDAO.Instance.GetById(id);
        }

        public async Task<List<KoiOrderDetail>> ReadAll()
        {
            return await OrderDetailKoiDAO.Instance.ReadAll();
        }

        public async Task<KoiOrderDetail?> ReadById(int id)
        {
            return await OrderDetailKoiDAO.Instance.ReadById(id);
        }

        public async Task<bool> Remove(int id)
        {
            return await OrderDetailKoiDAO.Instance.Remove(id);
        }

        public async Task<bool> Update(KoiOrderDetail model)
        {
            return await OrderDetailKoiDAO.Instance.Update(model);
        }
    }
}
