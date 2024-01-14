using Microsoft.EntityFrameworkCore;
using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.Entities;
using System.IO;

namespace Ab_pk_task_MovieStore.DBOperations;

public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var content = new PatikaDbContext(serviceProvider.GetRequiredService<DbContextOptions<PatikaDbContext>>())) 
        {
            
            if (!content.Genres.Any())
            {
                content.Genres.AddRange(
                    new Genre
                    {
                        Name = "ScienceFiction"
                    }, new Genre
                    {
                        Name = "Fantasy"
                    }, new Genre
                    {
                        Name = "Romance"
                    }
                );
                content.SaveChanges();
            }
            if (!content.Actors.Any())
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
                    }
                );
                content.SaveChanges();
            }
            if (!content.Directors.Any())
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
                content.SaveChanges();
            }
            if (!content.Movies.Any())
            {
                content.Movies.AddRange(
                    new Movie
                    {
                        Title = "Movie1",
                        ReleaseDate = DateTime.Now.AddDays(-34),
                        GenreId = 1,
                        DirectorId = 1,
                        Prize=123
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
                content.SaveChanges();
            }
            if (!content.MovieActors.Any())
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
                content.SaveChanges();
            }
            if (!content.Custemers.Any())
            {
                content.Custemers.AddRange(
                    new Custemer
                    {
                        Name = "Customer1",
                        Surname = "custemersurname1",
                        Email = "a1@gmail.com",
                        Password = "12345",
                    }, new Custemer
                    {
                        Name = "Customer2",
                        Surname = "custemersurname2",
                        Email = "a2@gmail.com",
                        Password = "22345",
                    }, new Custemer
                    {
                        Name = "Customer3",
                        Surname = "custemersurname3",
                        Email = "a3@gmail.com",
                        Password = "32345",
                    }
                );
                content.SaveChanges();
            }




        }
    }
}

