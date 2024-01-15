using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.MoviesOperations.Commands.DeleteMovie;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommandTests:IClassFixture<CommonTextFicture>
    {

        private readonly PatikaDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteMovieCommandTests(CommonTextFicture textFicture)
        {
            _dbContext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        [Fact]
        public void WhenExistingMovieIdIsGiven_MovieShouldBeDeleted()
        {
            // Arrange
            Movie Movie = new Movie()
            {
                Title = "TİTLE6hwesa55",
                ReleaseDate = DateTime.Now.AddDays(-12),
                DirectorId = 1,
                GenreId = 1,
                Prize = 1
            };

            _dbContext.Movies.Add(Movie);
            _dbContext.SaveChanges();

            DeleteMovieCommand deleteCommand = new DeleteMovieCommand(_dbContext);
            deleteCommand.Id = Movie.Id;

            // Act
            FluentActions.Invoking(() => deleteCommand.Handle()).Invoke();

            // Assert
            var deletedMovie = _dbContext.Movies.FirstOrDefault(x => x.Id == Movie.Id);
            deletedMovie.Should().BeNull();
        }
        [Fact]
        public void WhenNonExistingMovieIdIsGiven_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            int nonExistingMovieId = -1; // Assuming -1 is not a valid Movie Id

            DeleteMovieCommand deleteCommand = new DeleteMovieCommand(_dbContext);
            deleteCommand.Id = nonExistingMovieId;

            // Act & Assert
            FluentActions.Invoking(() => deleteCommand.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Movie Bulunamadı");
        }

     
    }
}
