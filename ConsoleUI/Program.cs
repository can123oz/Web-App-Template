using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager1 = new ProductManager(new InMemoryProductDal());
            ProductManager productManager2 = new ProductManager(new EfProductDal());

            foreach (var item in productManager1.GetAll())
            {
                Console.WriteLine(item.ProductName);
            }

            foreach (var item in productManager2.GetAll())
            {
                Console.WriteLine(item.ProductName);
            }
            Console.ReadLine();
        }
    }
}
