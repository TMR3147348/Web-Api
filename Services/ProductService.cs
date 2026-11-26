using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService:IProductService
    {
        IProductRepository productservice;
        public ProductService(IProductRepository reposproductserviceitory)
        {
            this.productservice = productservice;
        }



        public async Task<List<Product> ,int > GetProducts()
        {
            return await productservice.GetProducts();
        }
    }
}
