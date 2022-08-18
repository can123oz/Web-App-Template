using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
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
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //our generic validator for fluent validation.
            ValidationTool.Validate(new ProductValidator(), product);


            //business codes here.

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
                return new SuccessDataResult<Product>(result,Messages.ProductsListed);
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
    }
}
