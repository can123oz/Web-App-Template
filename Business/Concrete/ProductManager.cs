using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        ILogger _logger;

        public ProductManager(IProductDal productDal, ILogger logger, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _logger = logger;
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //No need to validate inside of the class.
            //ValidationTool.Validate(new ProductValidator(), product);
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId, 10), 
                CheckIfProductNameTaken(product.ProductName), 
                _categoryService.CheckCategoryLimit(15));
            
            if(result != null)
            {
                return result;   
            }

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            var listedProduct = _productDal.GetAll();
            if (DateTime.Now.Hour == 22)
            {
                //frontend ci burdan liste geldiğini bilmeli ona gore yazıcak.
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(listedProduct, Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            var listCategoryId = _productDal.GetAll(p => p.CategoryId == id);
            return new SuccessDataResult<List<Product>>(listCategoryId);
        }

        public IDataResult<Product> GetById(int id)
        {
            var result = _productDal.Get(p => p.ProductId == id);
            if (result != null)
            {
                return new SuccessDataResult<Product>(result, Messages.ProductsListed);
            }
            return new ErrorDataResult<Product>(result, Messages.NotFound);
        }

        public IDataResult<List<Product>> GetByUnitePrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            var result = _productDal.GetProductsDetails();
            return new SuccessDataResult<List<ProductDetailDto>>(result, Messages.MaintenanceTime);
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }

        //I want this method only for this class
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId, int maxNumber)
        {
            // Select count(*) from products where categoryId = 1
            var maxNumberofProduct = _productDal.GetAll(p => p.CategoryId == categoryId);
            if (maxNumberofProduct.Count >= maxNumber)
            {
                return new ErrorResult(Messages.GeneralErrorMessage);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameTaken(string productName)
        {
            var names = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (names)
            {
                return new ErrorResult(Messages.NameTakenError);
            }
            return new SuccessResult();
        }

    }
}
