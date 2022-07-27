using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager1 = new ProductManager(new EfProductDal());

            foreach (var item in productManager1.GetAll())
            {
                Console.WriteLine(item.ProductName);
            }

            foreach (var item in productManager1.GetAllByCategoryId(2))
            {
                Console.WriteLine(item.ProductName);
            }
            Console.ReadLine();
        }
    }
}
