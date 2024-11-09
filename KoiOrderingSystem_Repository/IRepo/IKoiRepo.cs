using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Repository.IRepo
{
    public interface IKoiRepo
    {
        Task<Koi?> GetById(int id);
        Task<List<Koi>> GetAll();
        Task<bool> Add(Koi model);
        Task<bool> Remove(int id);
        Task<bool> Update(Koi model);
        Task<Koi?> ReadById(int id);
        Task<List<Koi>> ReadAll();
    }
}
