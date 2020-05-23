using BlogAhmet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAhmet.Business.Abstract
{
    public interface ICategoryService
    {
        Category Get(int id);

        List<Category> GetAll();
       
        List<Category> GetCategoriesByName(string categoryName);

        void Add(Category category);

        void Update(Category category);

        void Delete(Category category);
    }
}
