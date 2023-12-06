﻿using Server.Model;
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
    }
}
