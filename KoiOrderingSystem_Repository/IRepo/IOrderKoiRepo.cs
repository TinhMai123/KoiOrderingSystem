using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Repository.IRepo
{
    public interface IOrderKoiRepo
    {
        Task<KoiOrder?> GetById(int id);
        Task<List<KoiOrder>> GetAll();
        Task<bool> Add(KoiOrder model);
        Task<bool> Remove(int id);
        Task<bool> Update(KoiOrder model);
        Task<KoiOrder?> ReadById(int id);
        Task<List<KoiOrder>> ReadAll();
    }
}
