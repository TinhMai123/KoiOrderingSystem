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
        Task<bool> AddAsync(KoiOrder add);
        Task<List<KoiOrder>> GetAlls();
        Task<KoiOrder?> GetById(int id);
        Task<List<KoiOrder>> ReadAlls();
        Task<KoiOrder?> ReadById(int id);
        Task<bool> UpdateAsync(KoiOrder update);
        Task<bool> DeleteAsync(int id);
    }
}
