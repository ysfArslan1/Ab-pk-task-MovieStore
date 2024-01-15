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
    public static class Movies
    {
        public static void AddMovies(this PatikaDbContext content)
        {
            content.Movies.AddRange(
                    new Movie
                    {
                        Title = "Movie1",
                        ReleaseDate = DateTime.Now.AddDays(-34),
                        GenreId = 1,
                        DirectorId = 1,
                        Prize = 123
                    }, new Movie
                    {
                        Title = "Movie2",
                        ReleaseDate = DateTime.Now.AddDays(-34),
                        GenreId = 2,
                        DirectorId = 1,
                        Prize = 234
                    }, new Movie
                    {
                        Title = "Movie3",
                        ReleaseDate = DateTime.Now.AddDays(-34),
                        GenreId = 1,
                        DirectorId = 3,
                        Prize = 345
                    }
                );
        }
    }
}
