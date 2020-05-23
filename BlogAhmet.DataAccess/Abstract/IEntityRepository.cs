using BlogAhmet.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;


namespace BlogAhmet.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T: class, IEntity, new()  
    {

        // T türünde bir liste döndüren GetAll metodu vardır. İçine istersek bir sorgu alabilir ve sorguyu yine T türünde yapar. Filtreleme işlemi de yapılabilir, yapılmazsa null döner.
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        // T türünde tek bir kayıt döndürür ve yine T türünde sorgu ve filtreleme yapabilir.
        T Get(Expression<Func<T, bool>> filter);

        // Ekleme, silme ve güncelleme metodları T türünde bir varlık alır ve ona göre işlem yapar.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);


    }
}
