using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        //Veri erişim kodlarının imzaları burada bulunur. BU yapı bütün IEntity nesneleri için çalışabilecek düzeyde jenerik olarak tasarlanmıştır.
        //Bulunan bütün fonksiyonlar asenkron olarak çalışırlar.

        //İlgili filtreye ve talebe göre listeleme fonksiyonudur.
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties);

        //İlgili filtreye ve talebe göre bir adet varlık getirme fonksiyonudur.
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties);

        //İlgili id'ye göre listeleme fonksiyonudur. Yalnızca id üzerinden sorgu yapılabilir.
        Task<TEntity> FindAsync(object id);

        //Varlık ekleme fonksiyonudur.
        Task<TEntity> AddAsync(TEntity entity);

        //Varlık güncelleme fonksiyonudur.
        Task<TEntity> UpdateAsync(TEntity entity);

        //Varlık silme fonsiyonudur.
        Task<TEntity> DeleteAsync(TEntity entity);

        //Ekleme, silme ve güncelleme fonksiyonlarından sonra işlemin kayıt edilmesi gereklidir. Kayıt fonksiyonudur.
        Task<int> SaveAsync();
    }
}
