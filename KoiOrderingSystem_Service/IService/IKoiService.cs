using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Service.IService
{
    public interface IKoiService
    {
        Task<bool> AddAsync(Koi add);
        Task<List<Koi>> GetAlls();
        Task<Koi> GetById(int id);
        Task<bool> UpdateAsync(Koi update);
        Task<bool> DeleteAsync(int id);
    }
}
