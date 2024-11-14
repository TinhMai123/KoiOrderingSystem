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
        Task<bool> AddAsync(OrderKoiDetail add);
        Task<List<OrderKoiDetail>> GetAlls();
        Task<OrderKoiDetail?> GetById(int id);
        Task<List<OrderKoiDetail>> ReadAlls();
        Task<OrderKoiDetail?> ReadById(int id);
        Task<bool> UpdateAsync(OrderKoiDetail update);
        Task<bool> DeleteAsync(int id);
    }
}
