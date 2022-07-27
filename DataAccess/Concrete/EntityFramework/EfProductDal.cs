using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {

        List<Product> _products;

        public EfProductDal()
        {
            //fake data for working
            _products = new List<Product>
            {
                new Product{ProductId=1, CategoryId=1, ProductName="WaterBottle", UnitPrice=10, UnitsInStock=132 },
                new Product{ProductId=2, CategoryId=1, ProductName="EmptyCan", UnitPrice=1, UnitsInStock=22 },
                new Product{ProductId=3, CategoryId=2, ProductName="Speaker", UnitPrice=122, UnitsInStock=200 },
                new Product{ProductId=4, CategoryId=2, ProductName="Keyboard", UnitPrice=190, UnitsInStock=10 },
                new Product{ProductId=5, CategoryId=2, ProductName="Charger", UnitPrice=20, UnitsInStock=50 },
            };
        }
        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products.ToList();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
