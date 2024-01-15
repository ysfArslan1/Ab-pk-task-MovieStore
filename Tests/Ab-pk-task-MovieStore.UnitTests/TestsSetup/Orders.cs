using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ab_pk_task_MovieStore.UnitTests.TestsSetup
{
    public static class Orders
    {
        public static void AddOrders(this PatikaDbContext content)
        {
            content.Orders.AddRange(
                    new Order
                    {
                        MovieId = 1,
                        CustemerId = 1,
                        PurchaseDate = DateTime.Now.AddDays(-43),
                        Prize = 123
                    },
                    new Order
                    {
                        MovieId = 1,
                        CustemerId = 2,
                        PurchaseDate = DateTime.Now.AddDays(-43),
                        Prize = 123
                    },
                    new Order
                    {
                        MovieId = 2,
                        CustemerId = 3,
                        PurchaseDate = DateTime.Now.AddDays(-43),
                        Prize = 234
                    }
                );
        }
    }
}
