
using KoiOrderingSystem_BusinessObject.Data;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiOrderingSystem_DAO;

namespace KoiOrderingSystem_Repository.Repo
{
    public class QuoteRepo : IQuoteRepo
    {
        public async Task<bool> Add(Quote model)
        {
            return await QuoteDAO.Instance.Add(model);
        }

        public async Task<List<Quote>> GetAll()
        {
            return await QuoteDAO.Instance.GetAll();
        }

        public async Task<Quote?> GetById(int id)
        {
            return await QuoteDAO.Instance.GetById(id);
        }

        public async Task<bool> Remove(int id)
        {
            return await QuoteDAO.Instance.Remove(id);
        }

        public async Task<bool> Update(Quote model)
        {
            return await QuoteDAO.Instance.Update(model);
        }
    }
}
