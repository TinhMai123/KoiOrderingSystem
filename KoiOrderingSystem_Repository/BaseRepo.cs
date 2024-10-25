using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using KoiOrderingSystem_DAO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassBookingRoom_Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly BaseDAO<T> _dao;

        // Constructor that initializes the BaseDAO instance
        public BaseRepository(KoiOrderingSystemContext context)
        {
            _dao = BaseDAO<T>.Instance(context); // Using the BaseDAO singleton instance
        }

        // Forward the call to GetAllAsync
        public async Task<List<T>> GetAllAsync()
        {
            return await _dao.GetAllAsync();
        }

        // Forward the call to GetByIdAsync (int version)
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dao.GetByIdAsync(id);
        }

        // Forward the call to GetByIdAsync (Guid version)
        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dao.GetByIdAsync(id);
        }

        // Forward the call to AddAsync
        public async Task<bool> AddAsync(T entity)
        {
            return await _dao.AddAsync(entity);
        }

        // Forward the call to UpdateAsync
        public async Task<bool> UpdateAsync(T entity)
        {
            return await _dao.UpdateAsync(entity);
        }

        // Forward the call to DeleteAsync (soft delete)
        public async Task<bool> DeleteAsync(int id)
        {
            return await _dao.DeleteAsync(id);
        }
    }
}
