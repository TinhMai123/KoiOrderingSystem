
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using KoiOrderingSystem_DAO;
using KoiOrderingSystem_Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Repository.Repo
{
    public class CurrencyRepo : ICurrencyRepo
    {
        public async Task<bool> Add(Currency model)
        {
            return await CurrencyDAO.Instance.Add(model);
        }

        public async Task<List<Currency>> GetAll()
        {
            return await CurrencyDAO.Instance.GetAll();
        }
        
        public async Task<Currency?> GetById(int id)
        {
            return await CurrencyDAO.Instance.GetById(id);
        }

        public async Task<List<Currency>> ReadAll()
        {
            return await CurrencyDAO.Instance.ReadAll();
        }

        public async Task<Currency?> ReadById(int id)
        {
            return await CurrencyDAO.Instance.ReadById(id);
        }

        public async Task<bool> Remove(int id)
        {
            return await CurrencyDAO.Instance.Remove(id);
        }

        public async Task<bool> Update(Currency model)
        {
            return await CurrencyDAO.Instance.Update(model);
        }
    }
}
