using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Repository.IRepo
{
    public interface IFarmKoiTypeRepo
    {
        Task<FarmKoiType?> GetById(int id);
        Task<List<FarmKoiType>> GetAll();
        Task<bool> Add(FarmKoiType model);
        Task<bool> Remove(int id);
        Task<bool> Update(FarmKoiType model);
        Task<FarmKoiType?> ReadById(int id);
        Task<List<FarmKoiType>> ReadAll();
    }
}
