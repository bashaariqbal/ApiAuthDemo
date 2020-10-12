using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiDemoWithAuth.Models;

namespace ApiDemoWithAuth.IService
{
    interface IProductService
    {
        Product GetProductsById(int id);
        List<Product> GetAllProduct();
        void AddProduct(Product product);
        void RemoveProduct(int id);
        void EditProduct(Product product);
    }
}
