
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
        public Task<bool> Add(Order model)
        {
            return OrderDAO.Instance.Add(model);
        }

        public Task<List<Order>> GetAll()
        {
            return OrderDAO.Instance.GetAll();
        }

        public Task<Order?> GetById(int id)
        {
            return OrderDAO.Instance.GetById(id);
        }

        public Task<bool> Remove(int id)
        {
            return OrderDAO.Instance.Remove(id);
        }

        public Task<bool> Update(Order model)
        {
            return OrderDAO.Instance.Update(model);
        }
    }
}
