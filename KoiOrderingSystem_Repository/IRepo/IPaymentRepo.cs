using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Repository.IRepo
{
    public interface IPaymentRepo
    {
        Task<Payment?> GetById(int id);
        Task<List<Payment>> GetAll();
        Task<bool> Add(Payment model);
        Task<bool> Remove(int id);
        Task<bool> Update(Payment model);
    }
}
