using BlogAhmet.DataAccess.Abstract;
using BlogAhmet.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BlogAhmet.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity> 
        where TEntity : class, IEntity, new()
    {

        // Ekleme metodu yazıyoruz, parametre olarak IProduct gibi varlık alıyor.
        public void Add(TEntity entity)
        {
            // Using ile context'i ekliyoruz.
            using (BlogAhmetContext context = new BlogAhmetContext(BlogAhmetContext.ops.dbOptions))
            {
                // context.Entry ile tablomuza erişiyoruz önce.
                var addedEntity = context.Entry(entity);

                // State'lerden bu erişimin sebebinin ekleme olacağını söylüyoruz.
                addedEntity.State = EntityState.Added;

                // Eklemeyi yapıp değişiklikleri kaydediyoruz.
                context.SaveChanges();
            }
        }

        // Burada da aynı şekilde, tabloya erişip sileceğimizi söylüyoruz ve silip kaydediyoruz.
        public void Delete(TEntity entity)
        {
            using (BlogAhmetContext context = new BlogAhmetContext(BlogAhmetContext.ops.dbOptions))
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        // IProduct gibi TEntity dönen bir Get metodu oluşturuyoruz ve içine sorgu ve filtreleme alıyor.
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            // Contexte bağlanıyoruz.
            using (BlogAhmetContext context = new BlogAhmetContext(BlogAhmetContext.ops.dbOptions))
            {
                // context.Set ile çalıştığımız tabloya odaklanıp giriş yapıyoruz ve filtreye uyan ilk şeyi alıp dönüyor.
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }


        // IProduct gibi TEntity türünde bir liste döndüren GetAll metodu yazıyoruz, parametre olarak sorgu ve filtreleri veriyoruz.
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            // Using ile contexti kullanıyoruz.
            using (BlogAhmetContext context = new BlogAhmetContext(BlogAhmetContext.ops.dbOptions))
            {
                // Eğer filtre yoksa verdiğimiz tabloya giriş yapıp onu liste olarak döndürüyoruz, eğer filtre varsa tabloya odaklanıp sorguyu yapıp öyle liste döndürüyoruz.
                return filter == null ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();

            }
        }

        // Ekleme ve silme işlemlerindeki aynı şeyleri yapıyoruz.
        public void Update(TEntity entity)
        {
            using (BlogAhmetContext context = new BlogAhmetContext(BlogAhmetContext.ops.dbOptions))
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

    }
}
