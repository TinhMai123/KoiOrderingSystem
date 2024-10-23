using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Service.IService
{
    public interface IInsuranceService
    {
        Task<bool> AddAsync(Insurance add);
        Task<List<Insurance>> GetAlls();
        Task<Insurance> GetById(int id);
        Task<bool> UpdateAsync(Insurance update);
        Task<bool> DeleteAsync(int id);
    }
}
