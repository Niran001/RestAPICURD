using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using RestAPICrud.Iservice;
using RestAPICrud.Models;

namespace RestAPICrud.ProductData
{
    public class ProductService : IProductData
    {
        private IProductRepository _productRepository;
        private IDbConnection db;
        public ProductService(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DBCONNECTION"));
        }
        public FunctionResponse AddProduct(Product product)
        {
            
            //var Productdetail = new Product
            //{
                
            //    ProductName = product.ProductName,
            //    Price = product.Price,
            //    Quantity = product.Quantity,

            //};
            try
            {
                var query = "Insert into Product(ProductName,Price,Quantity) Values (@ProductName,@Price,@Quantity)" + "select cast(scope_identity()as int);";
                var id = db.Query<int>(query, product).Single();
              //  product.Id = id;
                return new FunctionResponse { status = "ok", message = "Successfully Added" };
            }
            catch (Exception ex)
            {
                return new FunctionResponse { status = "error", message = ex.Message };

            }

           // return message;
        }
        public List<Product> SelectProduct()
        {

            //var Productdetail = new Product
            //{

            //    ProductName = product.ProductName,
            //    Price = product.Price,
            //    Quantity = product.Quantity,

            //};
            
                var query = "select * from Product";
                var prodlist = db.Query<Product>(query, null).ToList();
                //  product.Id = id;
                return prodlist;
            
        }
        public FunctionResponse DeleteProduct(int id)
        {

            //var Productdetail = new Product
            //{

            //    ProductName = product.ProductName,
            //    Price = product.Price,
            //    Quantity = product.Quantity,

            //};

            try
            {
                var query = "Delete from product where Id=@id";
                db.Execute(query, new { @id = id });
                //  product.Id = id;
                return new FunctionResponse { status = "ok", message = "Successfully deleted" };
            }
            catch (Exception ex)
            {
                return new FunctionResponse { status = "error", message = ex.Message };

            }

        }
        public FunctionResponse UpdateProduct( Product product)
        {

            try
            {
                var query = "Update Product set ProductName=@ProductName,Price=@Price,quantity=@Quantity where Id=@Id";

                db.Execute(query, product);
                return new FunctionResponse { status = "Ok", result = product, message = "Here is the List" };
            }
            catch (Exception ex)
            {
                return new FunctionResponse { status = "error", message = ex.Message};
            }
        }
    }
}
