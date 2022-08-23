using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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
        

        public IDataResult<List<Category>> GetAll()
        {
            var categories = _categoryDal.GetAll();
            return new DataResult<List<Category>>(categories,true,Messages.SuccessMessage);
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            var category = _categoryDal.Get(p => p.CategoryId == categoryId);
            if (category != null)
            {
                return new DataResult<Category>(category, true);
            }
            return new ErrorDataResult<Category>();
        }

        public IResult CheckCategoryLimit(int max)
        {
            var categoryNumber = _categoryDal.GetAll();
            if (categoryNumber.Count >= max)
            {
                return new ErrorResult("max number reached.");
            }
            return new SuccessResult();
        }
    }
}
