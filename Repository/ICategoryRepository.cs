using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Repository
{
    internal interface ICategoryRepository
    {
        Task<List<Category>> GetCategories();
    }
}
