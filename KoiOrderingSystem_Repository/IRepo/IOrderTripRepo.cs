using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Repository.IRepo
{
    public interface IOrderTripRepo
    {
        Task<OrderTrip?> GetById(int id);
        Task<List<OrderTrip>> GetAll();
        Task<bool> Add(OrderTrip model);
        Task<bool> Remove(int id);
        Task<bool> Update(OrderTrip model);
        Task<OrderTrip?> ReadById(int id);
        Task<List<OrderTrip>> ReadAll();
    }
}
