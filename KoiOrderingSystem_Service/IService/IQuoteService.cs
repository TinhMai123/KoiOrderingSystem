using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Service.IService
{
    public interface IQuoteService
    {
        Task<bool> AddAsync(Quote add);
        Task<List<Quote>> GetAlls();
        Task<Quote?> GetById(int id);
        Task<List<Quote>> ReadAlls();
        Task<Quote?> ReadById(int id);
        Task<bool> UpdateAsync(Quote update);
        Task<bool> DeleteAsync(int id);
    }
}
