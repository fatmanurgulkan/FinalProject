using Busıness.Abstract;
using Busıness.BusinessAspects.Autofac;
using Busıness.CCS;
using Busıness.Constants;
using Busıness.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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
        ICategoryService _categoryService;


        public ProductManager(IProductDal productdal,ICategoryService categoryService) //bir entity manager kendi hariç baska ıdalı enjekte edemez.
        {
            _productdal = productdal;
            _categoryService = categoryService;
           

        }
        [SecuredOperation ("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
           //ürün eklerken konulan kuralları burda yazarız.business code mesela max 10 kategorıde urun eklenebılır.
             IResult result=BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfProductNameExists(product.ProductName), CheckIfCategorLimitExceded());
          
            if (result!=null)
            {
                return result;
            }
            _productdal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
            
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productdal.GetAll(), Messages.ProductsListed);

        }

        public IDataResult<List<Product>> GetAllCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productdal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productdal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productdal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            //if (DateTime.Now.Hour == 21)
            // {
            //return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<ProductDetailDto>>(_productdal.GetProductDetails());
        }
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            return new ErrorResult();

        }


        private IResult CheckIfProductCountOfCategoryCorrect(int categoryıd)
        {
            var result = _productdal.GetAll(p => p.CategoryId == categoryıd).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productdal.GetAll(p => p.ProductName ==productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCategorLimitExceded()
        {
            var result = _categoryService.Getall();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.Categorylimitexceded);
            }
            return new SuccessResult();
           
        }


    }
}
