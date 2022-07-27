using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            //fake data for working
            _products = new List<Product>
            {
                new Product{ProductId=1, CategoryId=1, ProductName="Iphone", UnitPrice=1020, UnitsInStock=12 },
                new Product{ProductId=2, CategoryId=1, ProductName="Laptop", UnitPrice=11320, UnitsInStock=22 },
                new Product{ProductId=3, CategoryId=2, ProductName="Camera", UnitPrice=4022, UnitsInStock=32 },
                new Product{ProductId=4, CategoryId=2, ProductName="Gopro", UnitPrice=1090, UnitsInStock=1 },
                new Product{ProductId=5, CategoryId=2, ProductName="3Dcam", UnitPrice=21400, UnitsInStock=50 },
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            var deletedProduct = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(deletedProduct);
        }

        public List<Product> GetAll()
        {
            var products = _products.ToList();
            return products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            var selectedId = _products.Where(p => p.CategoryId == categoryId).ToList();
            return selectedId;
        }

        public void Update(Product product)
        {
            var updatedProduct = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            updatedProduct.ProductName = product.ProductName;
            updatedProduct.UnitPrice = product.UnitPrice;
            updatedProduct.UnitsInStock = product.UnitsInStock;
            updatedProduct.CategoryId = product.CategoryId;
        }
    }
}
