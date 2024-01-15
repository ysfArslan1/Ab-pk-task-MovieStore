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
    public static class Customers
    {
        public static void AddCustomers(this PatikaDbContext content)
        {
            content.Customers.AddRange(
                    new Customer
                    {
                        Name = "Customer1",
                        Surname = "custemersurname1",
                        Email = "a1@gmail.com",
                        Password = "12345",
                    }, new Customer
                    {
                        Name = "Customer2",
                        Surname = "custemersurname2",
                        Email = "a2@gmail.com",
                        Password = "22345",
                    }, new Customer
                    {
                        Name = "Customer3",
                        Surname = "custemersurname3",
                        Email = "a3@gmail.com",
                        Password = "32345",
                    }
                );
        }
    }
}
