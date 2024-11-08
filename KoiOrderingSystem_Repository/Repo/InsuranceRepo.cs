
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
    public class InsuranceRepo : IInsuranceRepo
    {
        public async Task<bool> Add(Insurance model)
        {
            return await InsuranceDAO.Instance.Add(model);    
        }

        public async Task<List<Insurance>> GetAll()
        {
            return await InsuranceDAO.Instance.GetAll();
        }

        public async Task<Insurance?> GetById(int id)
        {
            return await InsuranceDAO.Instance.GetById(id);
        }

        public async Task<bool> Remove(int id)
        {
            return await InsuranceDAO.Instance.Remove(id);
        }

        public async Task<bool> Update(Insurance model)
        {
            return await InsuranceDAO.Instance.Update(model);
        }
    }
}
