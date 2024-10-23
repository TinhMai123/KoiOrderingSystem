using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBookingRoom_Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        public readonly KoiOrderingSystemContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(KoiOrderingSystemContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public void AttachEntity(T entity)
        {
            _context.Attach(entity);
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }

        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                entity.DeletedAt = DateTime.Now;
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
