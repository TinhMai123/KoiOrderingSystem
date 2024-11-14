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
        Task<KoiOrderDetail?> GetById(int id);
        Task<List<KoiOrderDetail>> GetAll();
        Task<bool> Add(KoiOrderDetail model);
        Task<bool> Remove(int id);
        Task<bool> Update(KoiOrderDetail model);
        Task<KoiOrderDetail?> ReadById(int id);
        Task<List<KoiOrderDetail>> ReadAll();
    }
}
