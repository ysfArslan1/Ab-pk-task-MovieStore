using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.MoviesOperations.Commands.CreateMovie;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommandTests:IClassFixture<CommonTextFicture>
    {
        private readonly PatikaDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateMovieCommandTests(CommonTextFicture textFicture)
        {
            _dbcontext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistMovieNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange(Hazırla)
            Movie Movie = new Movie()
            {
                Title="TİTLE63455",
                ReleaseDate=DateTime.Now.AddDays(-12),
                DirectorId=1,
                GenreId=1,
                Prize = 1

            };
            _dbcontext.Movies.Add(Movie);
            _dbcontext.SaveChanges();

            CreateMovieCommand command = new CreateMovieCommand(_dbcontext, _mapper);
            command.Model = new CreateMovieModel() { Title = Movie.Title, ReleaseDate = Movie.ReleaseDate,
                DirectorId = Movie.DirectorId,
                GenreId = Movie.GenreId,
                Prize = Movie.Prize,
            };

            //act & assert (Çalıştır & Dogrula)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Zaten Mevcut");
        }

        [Fact]
        public void WhenValidInputsIsGiven_Movie_ShouldBeCreated()
        {
            //arrange(Hazırla)
            
            CreateMovieCommand command = new CreateMovieCommand(_dbcontext, _mapper);
            command.Model = new CreateMovieModel()
            {
                Title = "TİTLE6354",
                ReleaseDate = DateTime.Now.AddDays(-12),
                DirectorId = 1,
                GenreId = 1,
                Prize = 1

            };
            // act
            FluentActions.Invoking(()=>command.Handle()).Invoke();

            // assert 
            var Movie = _dbcontext.Movies.FirstOrDefault(x=>x.Title == command.Model.Title && x.DirectorId == command.Model.DirectorId);
            Movie.Should().NotBeNull();
            Movie.Title.Should().Be(command.Model.Title);
            Movie.ReleaseDate.Should().Be(command.Model.ReleaseDate);
            Movie.DirectorId.Should().Be(command.Model.DirectorId);
            Movie.GenreId.Should().Be(command.Model.GenreId);
            Movie.Prize.Should().Be(command.Model.Prize);
        }
    }
}
