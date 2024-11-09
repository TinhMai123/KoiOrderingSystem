
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
    public class PaymentRepo : IPaymentRepo
    {
        public async Task<bool> Add(Payment model)
        {
            return await PaymentDAO.Instance.Add(model);
        }

        public async Task<List<Payment>> GetAll()
        {
            return await PaymentDAO.Instance.GetAll();
        }

        public async Task<Payment?> GetById(int id)
        {
            return await PaymentDAO.Instance.GetById(id);
        }

        public async Task<List<Payment>> ReadAll()
        {
            return await PaymentDAO.Instance.ReadAll();
        }

        public async Task<Payment?> ReadById(int id)
        {
            return await PaymentDAO.Instance.ReadById(id);
        }

        public async Task<bool> Remove(int id)
        {
            return await PaymentDAO.Instance.Remove(id);
        }

        public async Task<bool> Update(Payment model)
        {
            return await PaymentDAO.Instance.Update(model);
        }
    }
}
