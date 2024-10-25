using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Service.IService
{
    public interface IKoiTypeService
    {
        Task<bool> AddAsync(KoiType add);
        Task<List<KoiType>> GetAlls();
        Task<KoiType?> GetById(int id);
        Task<bool> UpdateAsync(KoiType update);
        Task<bool> DeleteAsync(int id);
    }
}
