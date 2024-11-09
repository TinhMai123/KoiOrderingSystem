using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Repository.IRepo
{
    public interface IOrderDetailKoiRepo
    {
        Task<OrderDetailKoi?> GetById(int id);
        Task<List<OrderDetailKoi>> GetAll();
        Task<bool> Add(OrderDetailKoi model);
        Task<bool> Remove(int id);
        Task<bool> Update(OrderDetailKoi model);
        Task<OrderDetailKoi?> ReadById(int id);
        Task<List<OrderDetailKoi>> ReadAll();
    }
}
