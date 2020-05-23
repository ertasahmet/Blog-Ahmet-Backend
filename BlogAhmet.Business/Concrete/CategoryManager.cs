using BlogAhmet.Business.Abstract;
using BlogAhmet.Business.Utilities;
using BlogAhmet.Business.ValidationRules.FluentValidation;
using BlogAhmet.DataAccess.Abstract;
using BlogAhmet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAhmet.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {

        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {

            _categoryDal = categoryDal;

        }

        public void Add(Category category)
        {

            CategoryValidator categoryValidator = new CategoryValidator();

            ValidationTool.Validate(categoryValidator, category);
            _categoryDal.Add(category);
        }

        public void Delete(Category category)
        {
            try
            {
                _categoryDal.Delete(category);
            }
            catch (Exception ex)
            {
                throw new Exception("Kategori silme gerçekleştirilemedi.");
            }
        }


        public Category Get(int id)
        {
            return _categoryDal.Get(a => a.CategoryId == id);
        }


        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public List<Category> GetCategoriesByName(string categoryName)
        {
            return _categoryDal.GetAll(p => p.CategoryName.ToLower().Contains(categoryName.ToLower()));
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
