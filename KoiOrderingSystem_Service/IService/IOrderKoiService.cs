using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Service.IService
{
    public interface IOrderKoiService
    {
        Task<bool> AddAsync(OrderKoi add);
        Task<List<OrderKoi>> GetAlls();
        Task<OrderKoi?> GetById(int id);
        Task<bool> UpdateAsync(OrderKoi update);
        Task<bool> DeleteAsync(int id);
    }
}
