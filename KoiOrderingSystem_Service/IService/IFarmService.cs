using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Service.IService
{
    public interface IFarmService
    {
        Task<bool> AddAsync(Farm add);
        Task<List<Farm>> GetAlls();
        Task<Farm> GetById(int id);
        Task<bool> UpdateAsync(Farm update);
        Task<bool> DeleteAsync(int id);
    }
}
