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
    public static class Aktors
    {
        public static void AddAktors(this PatikaDbContext content)
        {
            content.Actors.AddRange(
                    new Actor
                    {
                        Name = "Actor1",
                        Surname = "Surname1",
                    }, new Actor
                    {
                        Name = "Actor2",
                        Surname = "Surname2",
                    }, new Actor
                    {
                        Name = "Actor3",
                        Surname = "Surname3",
                    }, new Actor
                    {
                        Name = "Actor4",
                        Surname = "Surname4",
                    });
        }
    }
}
