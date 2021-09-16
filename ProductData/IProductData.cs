using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestAPICrud.Models;

namespace RestAPICrud.ProductData
{
    public interface IProductData
    {
        //List<Product> GetProduct();

        //Product GetProduct(int Id);

        FunctionResponse AddProduct(Product product);

        List<Product> SelectProduct();
        FunctionResponse DeleteProduct(int id);
        FunctionResponse UpdateProduct(Product product);
    }
}
