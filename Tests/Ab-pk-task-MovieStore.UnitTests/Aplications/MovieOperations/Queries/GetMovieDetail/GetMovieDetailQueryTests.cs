using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.MoviesOperations.Commands.DeleteMovie;
using Ab_pk_task_MovieStore.Aplication.MoviesOperations.Commands.UpdateMovie;
using Ab_pk_task_MovieStore.Aplication.MoviesOperations.Queries.GetMovieDetail;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQueryTests: IClassFixture<CommonTextFicture>
    {
        private readonly PatikaDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetMovieDetailQueryTests(CommonTextFicture textFicture)
        {
            _dbcontext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        

        [Fact]
        public void WhenNonExistingMovieIdIsGiven_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            int nonExistingMovieId = -1; // Assuming -1 is not a valid Movie Id

            GetMovieDetailQuery query = new GetMovieDetailQuery(_dbcontext,_mapper);
            query.Id = nonExistingMovieId;

            // Act & Assert
            FluentActions.Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bulunamadı");
        }

        [Fact]
        public void WhenExistingMovieIdIsGiven_MovieShouldBeReturn()
        {
            // Arrange
            Movie Movie = new Movie()
            {
                Title = "TİTLE63ytjhrth5",
                ReleaseDate = DateTime.Now.AddDays(-12),
                DirectorId = 1,
                GenreId = 1,
                Prize = 1
            };

            _dbcontext.Movies.Add(Movie);
            _dbcontext.SaveChanges();

            GetMovieDetailQuery query = new GetMovieDetailQuery(_dbcontext,_mapper);
            query.Id = Movie.Id;

            // Act
            FluentActions.Invoking(() => query.Handle()).Invoke();

            // Assert
            var result = _dbcontext.Movies.FirstOrDefault(x => x.Id == Movie.Id);
            result.Should().NotBeNull();
            result.Title.Should().Be(Movie.Title);
            result.ReleaseDate.Should().Be(Movie.ReleaseDate);
            result.DirectorId.Should().Be(Movie.DirectorId);
            result.GenreId.Should().Be(Movie.GenreId);
            result.Prize.Should().Be(Movie.Prize);
        }
    }
}
