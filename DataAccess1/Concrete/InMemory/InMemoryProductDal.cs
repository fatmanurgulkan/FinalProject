using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        

        List<Product> products;
        public InMemoryProductDal()
        {
            products = new List<Product> {
                new Product{ProductId=1 ,CategoryId=1,ProductName="bardak",UnitsInStock=15,UnitPrice=10},
                new Product{ProductId=2 ,CategoryId=1,ProductName="kamera",UnitsInStock=5,UnitPrice=100},
                new Product{ProductId=3,CategoryId=1,ProductName="telefon",UnitsInStock=13,UnitPrice=500},
                new Product{ProductId=4 ,CategoryId=1,ProductName="klavye",UnitsInStock=12,UnitPrice=150},
                new Product{ProductId=5 ,CategoryId=1,ProductName="fare",UnitsInStock=15,UnitPrice=10}




            };

        }
        public void Add(Product product)
        {
            products.Add(product);
        }

        public void Delete(Product product)
        {
            // remove ile olmaz aynı referansta değiller
            Product produsttodelete;// bu kullanım linq
            produsttodelete = products.SingleOrDefault(p=> p.ProductId== product.ProductId);// tek eleman  bulmayı saglar p gezerkenkı elemanın adı



        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product producttoupdate= products.SingleOrDefault(p => p.ProductId == product.ProductId);
         
            producttoupdate.UnitsInStock = product.UnitsInStock;
            producttoupdate.UnitPrice = product.UnitPrice;
            producttoupdate.ProductName = product.ProductName;
            producttoupdate.CategoryId = product.CategoryId;

        }

        List<Product> GetallbyCategory(int categoryId)
        {
          return   products.Where(p => p.CategoryId == categoryId).ToList();// where içindekı verilene uyanı liste yapar.
        }

        List<Product> IProductDal.GetallbyCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
