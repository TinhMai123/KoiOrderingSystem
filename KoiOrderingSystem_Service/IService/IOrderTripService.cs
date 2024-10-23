using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Service.IService
{
    public interface IOrderTripService
    {
        Task<bool> AddAsync(OrderTrip add);
        Task<List<OrderTrip>> GetAlls();
        Task<OrderTrip> GetById(int id);
        Task<bool> UpdateAsync(OrderTrip update);
        Task<bool> DeleteAsync(int id);
    }
}
