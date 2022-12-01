using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            //foreach (var item in categoryManager.GetAll())
            //{
            //    Console.WriteLine(item.CategoryName);
            //}
            //ProductManager productManager = new ProductManager(new EfProductDal(), ,new CategoryManager(new EfCategoryDal()));

            //var result = productManager.GetProductDetails();
            //Console.WriteLine(result.Message);
            //if (result.Success == true)
            //{
            //    foreach (var item in result.Data)
            //    {
            //        Console.WriteLine(item + " / " + item + " / " );
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}

            sendFonksiyon sendTry = new();
            sendTry.gmailSender(new gmail());
            sendTry.gmailSender(new hotmail());

            Console.ReadLine();


        }

        class sendFonksiyon
        {
            public string gmailSender(ImailSender _mail)
            {
                return _mail.send();
            }
        }


        interface ImailSender
        {
            string send();
        }

        class gmail : ImailSender
        {
            public string send()
            {
                return "gmail picked";
            }
        }

        class hotmail : ImailSender
        {
            public string send()
            {
                return "hotmail picked";
            }
        }



    }
}