using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete
{
    public class BaseEntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        #region Injection

        //Veri tabanına bir sorgu gönderilecekse ilgili veri tabanına bağlanılması gereklidir. Bunun için veri tabanının bir nesnesi burada oluşturulur ve bu nesne üzerinden ilgili işlemler yapılabilir.

        protected readonly DbContext _context;
        public BaseEntityRepository(DbContext context)
        {
            _context = context;
        }
        #endregion



        #region AddAsync
        //Veri ekleme fonksiyonudur.
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return entity;
        }
        #endregion

        #region DeleteAsync
        //Veri silme fonksiyonudur.
        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            await Task.Run(() => { _context.Set<TEntity>().Remove(entity); });
            return entity;
        }
        #endregion

        #region FindAsync
        //Id üzerinden veri getirme fonksiyonudur.
        public async Task<TEntity> FindAsync(object id)
        {
            return await _context.Set<TEntity>().FindAsync();
        }
        #endregion

        #region GetAllAsync
        //İstenilen filtre üzerinden verileri listeleme fonksiyonudur.
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.ToListAsync();
        }
        #endregion

        #region GetAsync
        //İstenilen filtre üzerinden veri getirme fonksiyonudur.
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            query = query.Where(predicate);
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.SingleOrDefaultAsync();
        }
        #endregion

        #region SaveAsync
        //Ekleme silme ve güncelleme fonksiyonlarından sonra tetiklenecek kayıt fonksiyonudur.
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        #endregion

        #region UpdateAsync
        //Veri güncelleme fonksiyonudur.
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await Task.Run(() => { _context.Set<TEntity>().Update(entity); });
            return entity;
        }
        #endregion

    }
}
