using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Claims;
using ApiDemoWithAuth.Models;
using ApiDemoWithAuth.IService;
using FourthApi.Services;

namespace ApiDemoWithAuth.Controllers
{
    
    public class ProductController : ApiController
    {
        IProductService productService = new ProductService();
        [Authorize (Roles = "admin")]
        [HttpGet]
        [Route("api/product/get")]
        public IHttpActionResult Get()
        {
            var products = productService.GetAllProduct();
            return Ok(productService.GetAllProduct());
        }

        [Route("api/product/get")]
        public IHttpActionResult Get(int id)
        {
            return Ok(productService.GetProductsById(id));
        }
        [Authorize]
        [Route("api/product/Add")]
        public IHttpActionResult Post(Product  product)
        {
            productService.AddProduct(product);
            return Ok("added");
        }

        [Route("api/product/Edit")]
        public IHttpActionResult Put(Product product)
        {
            productService.EditProduct(product);
            return Ok("EditProduct");
        }

        [Route("api/product/Delete")]
        public IHttpActionResult Delete(int id)
        {
            productService.RemoveProduct(id);
            return Ok("Removed");
        }
    }
}