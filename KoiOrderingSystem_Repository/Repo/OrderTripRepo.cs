
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
    public class OrderTripRepo : IOrderTripRepo
    {
        public async Task<bool> Add(OrderTrip model)
        {
            return await OrderTripDAO.Instance.Add(model);
        }

        public async Task<List<OrderTrip>> GetAll()
        {
            return await OrderTripDAO.Instance.GetAll();
        }

        public async Task<OrderTrip?> GetById(int id)
        {
            return await OrderTripDAO.Instance.GetById(id);
        }

        public async Task<bool> Remove(int id)
        {
            return await OrderTripDAO.Instance.Remove(id);
        }

        public async Task<bool> Update(OrderTrip model)
        {
            return await OrderTripDAO.Instance.Update(model);
        }
    }
}
