using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryEdit(Category category)
        {
            _categoryDal.Update(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(r => r.CategoryID == categoryId);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        public int TotalCategory(int categoryId)
        {
        return  _categoryDal.List(r => r.CategoryID == categoryId).Count();
         

        }
    }
}
