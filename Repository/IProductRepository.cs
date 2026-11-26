using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Repository
{
    public interface IProductRepository
    {
        Task<List<Product>, int> GetProducts(int position, int skip, string? desc, int?[] categoryIds);
    }
}
//public async Task<(List<Product> Items, int TotalCount)> getProducts(int position, int skip, string? desc
//int?[] categoryIds)