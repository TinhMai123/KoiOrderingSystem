using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Repository.IRepo
{
    public interface IKoiByBatchRepo
    {
        Task<KoiByBatch?> GetById(int id);
        Task<List<KoiByBatch>> GetAll();
        Task<bool> Add(KoiByBatch model);
        Task<bool> Remove(int id);
        Task<bool> Update(KoiByBatch model);
        Task<KoiByBatch?> ReadById(int id);
        Task<List<KoiByBatch>> ReadAll();
    }
}
