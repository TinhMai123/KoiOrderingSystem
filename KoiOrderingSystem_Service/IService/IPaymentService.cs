using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Service.IService
{
    public interface IPaymentService
    {
        Task<bool> AddAsync(Payment add);
        Task<List<Payment>> GetAlls();
        Task<Payment> GetById(int id);
        Task<bool> UpdateAsync(Payment update);
        Task<bool> DeleteAsync(int id);
    }
}
