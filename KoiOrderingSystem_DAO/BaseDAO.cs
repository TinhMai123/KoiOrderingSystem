using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class BaseDAO<T> where T : BaseModel
    {
        private readonly KoiOrderingSystemContext _context;
        private readonly DbSet<T> _dbSet;
        private static BaseDAO<T>? _instance;

        private BaseDAO(KoiOrderingSystemContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public static BaseDAO<T> Instance(KoiOrderingSystemContext context)
        {
            return _instance ??= new BaseDAO<T>(context);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
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
