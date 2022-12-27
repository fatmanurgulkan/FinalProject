using Busıness.Abstract;
using Busıness.Concrete;
using DataAccess.Concrete.EntıtyFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //Attrıbute

    //[LogAspect] --> aop yanı ne yapmasını ıstıyorsan onu yap demek.nereye yazıdıgın onemlı en basa yazarsan tum sınıfın ıcınde loglama yapar.

    public class ProductsController : ControllerBase

    { 
        //naming convention 
        //ıoc container inversion of controller içine new pm() new ıef () koyar kullanılsın dıye 
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            this._productService = productService;//startupa yaptıgımıza bak.
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
