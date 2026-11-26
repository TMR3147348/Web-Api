using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductService
    {
        Task<List<Product>, int> GetProducts(int position, int skip, string? desc, int?[] categoryIds);
    }
}
