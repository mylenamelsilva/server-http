using Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service
{
    public class ProductService
    {
        List<ProductModel> products = new();
        public List<ProductModel> ListAllProducts()
        {
            CreateProduct();
            return products.ToList();
        }

        public bool CreateProduct()
        {

                ProductModel product = new ProductModel();
                product.Product = "Produto 1";
                product.Price = 34;
                product.Id = Guid.NewGuid().ToString();
                products.Add(product);
                return true;
        }
    }
}
