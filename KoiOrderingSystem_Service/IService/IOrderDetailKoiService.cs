using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Service.IService
{
    public interface IOrderDetailKoiService
    {
        Task<bool> AddAsync(OrderDetailKoi add);
        Task<List<OrderDetailKoi>> GetAlls();
        Task<OrderDetailKoi?> GetById(int id);
        Task<List<OrderDetailKoi>> ReadAlls();
        Task<OrderDetailKoi?> ReadById(int id);
        Task<bool> UpdateAsync(OrderDetailKoi update);
        Task<bool> DeleteAsync(int id);
    }
}
