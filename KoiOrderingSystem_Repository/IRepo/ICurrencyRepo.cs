using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Repository.IRepo
{
    public interface ICurrencyRepo
    {
        Task<Currency?> GetById(int id);
        Task<List<Currency>> GetAll();
        Task<bool> Add(Currency model);
        Task<bool> Remove(int id);
        Task<bool> Update(Currency model);
        Task<Currency?> ReadById(int id);
        Task<List<Currency>> ReadAll();
    }
}
