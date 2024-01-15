using Ab_pk_task_MovieStore.Common;
using Ab_pk_task_MovieStore.DBOperations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab_pk_task_MovieStore.UnitTests.TestsSetup
{
    public class CommonTextFicture
    {
        public PatikaDbContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public CommonTextFicture()
        {
            var options = new DbContextOptionsBuilder<PatikaDbContext>().UseInMemoryDatabase(databaseName: "PatikaTestDb").Options;
            Context = new PatikaDbContext(options);
            Context.Database.EnsureCreated();
            Context.AddGenres();
            Context.AddAktors();
            Context.AddCustomers();
            Context.AddDirectors();
            Context.AddMovieActors();
            Context.AddMovies();
            Context.AddOrders();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();

        }
    }
}
