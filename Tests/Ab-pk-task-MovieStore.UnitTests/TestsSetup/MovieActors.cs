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
    public static class MovieActors
    {
        public static void AddMovieActors(this PatikaDbContext content)
        {
            content.MovieActors.AddRange(
                    new MovieActor
                    {
                        MovieId = 1,
                        ActorId = 1,
                    }, new MovieActor
                    {
                        MovieId = 1,
                        ActorId = 2,
                    }, new MovieActor
                    {
                        MovieId = 1,
                        ActorId = 3,
                    }, new MovieActor
                    {
                        MovieId = 2,
                        ActorId = 2,
                    }, new MovieActor
                    {
                        MovieId = 2,
                        ActorId = 3,
                    }, new MovieActor
                    {
                        MovieId = 3,
                        ActorId = 1,
                    }
                );
        }
    }
}
