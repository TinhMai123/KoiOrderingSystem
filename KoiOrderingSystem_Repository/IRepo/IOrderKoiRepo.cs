using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Repository.IRepo
{
    public interface IOrderKoiRepo
    {
        Task<OrderKoi?> GetById(int id);
        Task<List<OrderKoi>> GetAll();
        Task<bool> Add(OrderKoi model);
        Task<bool> Remove(int id);
        Task<bool> Update(OrderKoi model);
    }
}
