using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Repository.IRepo
{
    public interface IInsuranceRepo
    {
        Task<Insurance?> GetById(int id);
        Task<List<Insurance>> GetAll();
        Task<bool> Add(Insurance model);
        Task<bool> Remove(int id);
        Task<bool> Update(Insurance model);
        Task<Insurance?> ReadById(int id);
        Task<List<Insurance>> ReadAll();
    }
}
