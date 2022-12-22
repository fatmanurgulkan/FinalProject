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
            ProductTest();
            //CategoryTest();

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new IEfCategoryDal());
            foreach (var category in categoryManager.Getall())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new IEfProductDal());
            var result = productManager.GetProductDetails();
            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + "/"+ product.CategoryName);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }

        


           
        }
    }
}
