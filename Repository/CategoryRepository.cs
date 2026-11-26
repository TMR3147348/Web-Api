using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Repository
{
    public class CategoryRepository
    {

        MyDataBaseContext db;

        public ProductRepository(MyDataBaseContext db)
        {
            this.db = db;
        }

        async Task<List<Category>> GetCategories()
        {
            return await db.Categories.ToListAsync();
        }
    }
}
