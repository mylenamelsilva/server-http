using Server.Model;
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
        public T GetResponse<T>(string method)
        {
            switch (method.ToLower())
            {
                case "get":
                    var res = GetProducts();
                    return (T)Convert.ChangeType(res, typeof(T));
                case "post":
                    break;
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

        public bool CreateProduct()
        {
            throw new NotImplementedException();
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
