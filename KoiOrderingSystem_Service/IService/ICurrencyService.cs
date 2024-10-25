using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Service.IService
{
    public interface ICurrencyService
    {
        Task<bool> AddAsync(Currency add);
        Task<List<Currency>> GetAlls();
        Task<Currency?> GetById(int id);
        Task<bool> UpdateAsync(Currency update);
        Task<bool> DeleteAsync(int id);
    }
}
