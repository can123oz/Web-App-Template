using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        

        public List<Category> GetAll()
        {
            var categories = _categoryDal.GetAll();
            return categories;
        }

        public Category GetById(int categoryId)
        {
            var category = _categoryDal.Get(p => p.CategorytId == categoryId);
            return category;
        }
    }
}
