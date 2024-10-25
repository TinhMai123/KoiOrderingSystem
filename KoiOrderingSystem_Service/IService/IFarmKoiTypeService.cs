using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Service.IService
{
    public interface IFarmKoiTypeService
    {
        Task<bool> AddAsync(FarmKoiType add);
        Task<List<FarmKoiType>> GetAlls();
        Task<FarmKoiType?> GetById(int id);
        Task<bool> UpdateAsync(FarmKoiType update);
        Task<bool> DeleteAsync(int id);
    }
}
