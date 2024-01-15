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
    public static class Directors
    {
        public static void AddDirectors(this PatikaDbContext content)
        {
            content.Directors.AddRange(
                    new Director
                    {
                        Name = "Director",
                        Surname = "Surname1",
                    }, new Director
                    {
                        Name = "Director2",
                        Surname = "Surname2",
                    }, new Director
                    {
                        Name = "Director3",
                        Surname = "Surname3",
                    }
                );
        }
    }
}
