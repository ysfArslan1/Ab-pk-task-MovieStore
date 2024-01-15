using Microsoft.EntityFrameworkCore;
using Ab_pk_task_MovieStore.Entities;

namespace Ab_pk_task_MovieStore.DBOperations;

public class PatikaDbContext : DbContext, IPatikaDbContext
{
    public PatikaDbContext(DbContextOptions<PatikaDbContext> options) : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Customer> Customers{ get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<MovieActor> MovieActors { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Genre> Genres { get; set; }

    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
}

