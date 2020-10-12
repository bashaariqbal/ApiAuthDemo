using ApiDemoWithAuth.IService;
using ApiDemoWithAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourthApi.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> products = new List<Product>();
        public ProductService()
        {
            TestDBProduct();
        }
        private void TestDBProduct()
        {
            if (products.Count < 1)
            {
                products.Add(new Product { Id = 1, ProductName = "car", Price = 1000 });
                products.Add(new Product { Id = 2, ProductName = "MotorBike", Price = 500 });
            }
        }
        public void AddProduct(Product product)
        {
            var newId = products.Max(x => x.Id) + 1;
            products.Add(new Product { Id = newId, ProductName = product.ProductName, Price = product.Price });
        }

        public void EditProduct(Product product)
        {
            var productNeededToBeUpdated = products.Find(x => x.Id == product.Id);
            productNeededToBeUpdated.Price = product.Price;
            productNeededToBeUpdated.ProductName = product.ProductName;

        }

        public List<Product> GetAllProduct()
        {
            return products;
        }

        public Product GetProductsById(int id)
        {
            return products.Find(x => x.Id == id);

        }

        public void RemoveProduct(int id)
        {
            products.Remove(products.Find(p => p.Id == id));
        }
    }
}