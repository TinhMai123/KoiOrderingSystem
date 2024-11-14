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
        Task<OrderKoiDetail?> GetById(int id);
        Task<List<OrderKoiDetail>> GetAll();
        Task<bool> Add(OrderKoiDetail model);
        Task<bool> Remove(int id);
        Task<bool> Update(OrderKoiDetail model);
        Task<OrderKoiDetail?> ReadById(int id);
        Task<List<OrderKoiDetail>> ReadAll();
    }
}
