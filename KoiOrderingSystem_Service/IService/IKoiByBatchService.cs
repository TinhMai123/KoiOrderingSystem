using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Service.IService
{
    public interface IKoiByBatchService
    {
        Task<bool> AddAsync(KoiByBatch add);
        Task<List<KoiByBatch>> GetAlls();
        Task<KoiByBatch> GetById(int id);
        Task<bool> UpdateAsync(KoiByBatch update);
        Task<bool> DeleteAsync(int id);
    }
}
