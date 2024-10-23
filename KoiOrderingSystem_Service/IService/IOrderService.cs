using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Service.IService
{
    public interface IOrderService
    {
        Task<bool> AddAsync(Order add);
        Task<List<Order>> GetAlls();
        Task<Order> GetById(int id);
        Task<bool> UpdateAsync(Order update);
        Task<bool> DeleteAsync(int id);
    }
}
