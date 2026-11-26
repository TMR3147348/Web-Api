using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository:IOrderRepository
    {
        MyDataBaseContext db;

        public ProductRepository(MyDataBaseContext db)
        {
            this.db = db;
        }
        public async Task<order> CreateOrder(Order order)
        {
            await db.Orders.AddAsync(order);
            await db.SaveChangesAsync();
            return order;
        }
    }
}
