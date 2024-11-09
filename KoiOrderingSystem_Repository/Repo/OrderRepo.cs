
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
    public class OrderRepo : IOrderRepo
    {
        public async Task<bool> Add(Order model)
        {
            return await OrderDAO.Instance.Add(model);
        }

        public async Task<List<Order>> GetAll()
        {
            return await OrderDAO.Instance.GetAll();
        }

        public async Task<Order?> GetById(int id)
        {
            return await OrderDAO.Instance.GetById(id);
        }

        public async Task<bool> Remove(int id)
        {
            return await OrderDAO.Instance.Remove(id);
        }

        public async Task<bool> Update(Order model)
        {
            return await OrderDAO.Instance.Update(model);
        }
    }
}
