using Microsoft.EntityFrameworkCore;
using Ab_pk_task_MovieStore.Entities;

namespace Ab_pk_task_MovieStore.DBOperations;

public interface IPatikaDbContext
{
    
    DbSet<Movie> Movies { get; set; }
    DbSet<Actor> Actors { get; set; }
    DbSet<Custemer> Custemers { get; set; }
    DbSet<Director> Directors { get; set; }
    DbSet<MovieActor> MovieActors { get; set; }
    DbSet<Order> Orders { get; set; }
    DbSet<Genre> Genres { get; set; }
    int SaveChanges();

}

