using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Services
{
    public class CategoryService:ICategoryService
    {
        IUserRepository userrepository;
        public CategoryService(ICategoryService userrepository)
        {
            this.userrepository = userrepository;
        }



        public async Task<List<Category>> GetCategories()
        {
            return await userrepository.GetCategories();
        }
    }
}
