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
            ProductManager productManager1 = new ProductManager(new EfProductDal());
            var x = 1;
            foreach (var item in productManager1.GetAll())
            {
                
                Console.WriteLine(x);
                Console.WriteLine(item.ProductName);
                x = x+1;
            }
            Console.WriteLine("---------------------------------------------------------------");
            foreach (var item in productManager1.GetAllByCategoryId(2))
            { 
                Console.WriteLine(item.ProductName);
            }
            Console.WriteLine("---------------------------------------------------------------");
            foreach (var item in productManager1.GetByUnitePrice(40,100))
            {
                Console.WriteLine(item.ProductName);
            }
            Console.ReadLine();
        }
    }
}
