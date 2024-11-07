using ClassBookingRoom_Repository;
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
        public Task<bool> Add(Currency model)
        {
            return CurrencyDAO.Instance.Add(model);
        }

        public Task<List<Currency>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Currency?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Currency model)
        {
            throw new NotImplementedException();
        }
    }
}
