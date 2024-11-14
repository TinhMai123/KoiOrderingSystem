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
        Task<bool> AddAsync(KoiOrderDetail add);
        Task<List<KoiOrderDetail>> GetAlls();
        Task<KoiOrderDetail?> GetById(int id);
        Task<List<KoiOrderDetail>> ReadAlls();
        Task<KoiOrderDetail?> ReadById(int id);
        Task<bool> UpdateAsync(KoiOrderDetail update);
        Task<bool> DeleteAsync(int id);
    }
}
