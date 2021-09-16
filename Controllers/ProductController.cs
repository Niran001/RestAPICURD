using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPICrud.Models;
using RestAPICrud.ProductData;

namespace RestAPICrud.Controllers
{
    
    public class ProductController : ControllerBase
    {
        private IProductData _productData;
        public ProductController(IProductData productData)
        {
            _productData = productData;
        }

        [HttpPost]
        [Route("api/Add Product")]
        public IActionResult AddProduct(Product product)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(new FunctionResponse { status = "error", result = ModelState });
                }
                var result = _productData.AddProduct(product);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpPost]
        [Route("api/All Data")]
        public IActionResult Getprod()
        {
            var result = _productData.SelectProduct();
            return Ok(result);
        }

        [HttpPost]
        [Route("api/Update Product")]
        public IActionResult UpdateProduct(Product product)
        {
            var result = _productData.UpdateProduct(product);
            return Ok(result);
        }



        [HttpGet]
        [Route("api/Delete Product")]
        //[ApiController]
        //public IActionResult GetProduct()
        //{
        //    var result=_productData.GetProduct();
        //   return Ok(result);
        //}
        

        public IActionResult Delete(int id)
        {
            var result = _productData.DeleteProduct(id);
            return Ok(result);
        }
        
    }
}
