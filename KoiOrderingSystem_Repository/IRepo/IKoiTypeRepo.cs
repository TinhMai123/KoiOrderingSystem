using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Repository.IRepo
{
    public interface IKoiTypeRepo
    {
        Task<KoiType?> GetById(int id);
        Task<List<KoiType>> GetAll();
        Task<bool> Add(KoiType model);
        Task<bool> Remove(int id);
        Task<bool> Update(KoiType model);
        Task<KoiType?> ReadById(int id);
        Task<List<KoiType>> ReadAll();

    }
}
