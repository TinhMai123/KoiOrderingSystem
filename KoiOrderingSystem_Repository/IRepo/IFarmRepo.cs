using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Repository.IRepo
{
    public interface IFarmRepo
    {
        Task<Farm?> GetById(int id);
        Task<List<Farm>> GetAll();
        Task<bool> Add(Farm model);
        Task<bool> Remove(int id);
        Task<bool> Update(Farm model);
    }
}
