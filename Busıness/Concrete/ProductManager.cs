using Busıness.Abstract;
using Busıness.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busıness.Concrete
{
    public class ProductManager : IProductService
    {

        IProductDal _productdal;

        public ProductManager(IProductDal productdal)
        {
            _productdal = productdal;
        }

        public IResult Add(Product product)
        {

            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productdal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return  new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return  new SuccessDataResult<List<Product>>(_productdal.GetAll(),Messages.ProductsListed);

        }

        public IDataResult<List<Product>> GetAllCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productdal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult< Product >(_productdal.Get(p=>p.ProductId==productId));  
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>> (_productdal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            //if (DateTime.Now.Hour == 21)
           // {
              //return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
           //}
            return new SuccessDataResult<List<ProductDetailDto>> (_productdal.GetProductDetails()) ;
        }
    }
}
