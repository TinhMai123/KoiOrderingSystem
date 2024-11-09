using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Repository.IRepo
{
    public interface IQuoteRepo
    {
        Task<Quote?> GetById(int id);
        Task<List<Quote>> GetAll();
        Task<bool> Add(Quote model);
        Task<bool> Remove(int id);
        Task<bool> Update(Quote model);
        Task<Quote?> ReadById(int id);
        Task<List<Quote>> ReadAll();
    }
}
