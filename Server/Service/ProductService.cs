using Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server.Service
{
    public class ProductService
    {
        List<ProductModel> products = new();
        public List<ProductModel> ListAllProducts()
        {
            return products.ToList();
        }

        public bool CreateProduct(string json)
        {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var body = JsonSerializer.Deserialize<ProductParams>(json, options);
                ProductModel product = new ProductModel();
                product.Product = body.Product;
                product.Price = body.Price;
                product.Id = Guid.NewGuid().ToString();
                products.Add(product);
                return true;
        }

        public bool UpdateProduct(string json) {

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var body = JsonSerializer.Deserialize<ProductModel>(json, options);
            var productToUpdate = products.Find(p => p.Id == body.Id);

            if (productToUpdate == null)
            {
                return false;
            }

            productToUpdate.Product = body.Product;
            productToUpdate.Price = body.Price;
            return true;
        }

        public bool DeleteProduct(string id)
        {

            var productToUpdate = products.Find(p => p.Id == id);

            if (productToUpdate == null)
            {
                return false;
            }

            products.Remove(productToUpdate);
            return true;
        }
    }
}
