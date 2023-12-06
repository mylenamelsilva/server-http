﻿using Server.Model;
using Server.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controller
{
    public class ProductController
    {
        private ProductService _productService = new();
        public T GetResponse<T>(string method, string? json)
        {
            switch (method.ToLower())
            {
                case "get":
                    var res = GetProducts();
                    return (T)Convert.ChangeType(res, typeof(T));
                case "post":
                    var postRes = CreateProduct(json);
                    return (T)Convert.ChangeType(postRes, typeof(T));
                case "delete":
                    break;
                case "update":
                    break;
            }

            return default(T);
        }

        public List<ProductModel> GetProducts()
        {
            List<ProductModel> result = _productService.ListAllProducts();
            return result;
        }

        public bool CreateProduct(string json)
        {
            bool result = _productService.CreateProduct(json);
            return result;
        }

        public bool DeleteProduct()
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct()
        {
            throw new NotImplementedException();
        }
    }
}
