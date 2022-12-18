using Busıness.Concrete;
using DataAccess.Concrete.EntıtyFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new IEfProductDal());

            foreach (var product in productManager.GetByUnitPrice(20,100))
            {
                Console.WriteLine(product.ProductName);
            }

            
        }
    }
}
