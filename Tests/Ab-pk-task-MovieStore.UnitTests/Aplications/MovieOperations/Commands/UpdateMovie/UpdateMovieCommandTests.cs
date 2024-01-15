using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.MoviesOperations.Commands.UpdateMovie;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommandTests: IClassFixture<CommonTextFicture>
    {

        private readonly PatikaDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateMovieCommandTests(CommonTextFicture textFicture)
        {
            _dbContext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        [Fact]
        public void WhenValidInputsAreGiven_MovieShouldBeUpdated()
        {
            // Arrange
            Movie existingMovie = new Movie()
            {
                Title = "TİTLE6kuyyg",
                ReleaseDate = DateTime.Now.AddDays(-12),
                DirectorId = 1,
                GenreId = 1,
                Prize = 1
            };

            _dbContext.Movies.Add(existingMovie);
            _dbContext.SaveChanges();

            UpdateMovieCommand updateCommand = new UpdateMovieCommand(_dbContext);
            var existingMovies = _dbContext.Movies.ToList();

            updateCommand.Id = existingMovie.Id;
            updateCommand.Model = new UpdateMovieModel()
            {
                Title = "TİTLefe455",
                ReleaseDate = DateTime.Now.AddDays(-12),
                DirectorId = 1,
                GenreId = 2,
                Prize = 2
            };

            // Act
            FluentActions.Invoking(() => updateCommand.Handle()).Invoke();

            // Assert
            var updatedMovie = _dbContext.Movies.Find(existingMovie.Id);
            updatedMovie.Should().NotBeNull();
            updatedMovie.Title.Should().Be(updateCommand.Model.Title);
            updatedMovie.ReleaseDate.Should().Be(updateCommand.Model.ReleaseDate);
            updatedMovie.DirectorId.Should().Be(updateCommand.Model.DirectorId);
            updatedMovie.GenreId.Should().Be(updateCommand.Model.GenreId);
            updatedMovie.Prize.Should().Be(updateCommand.Model.Prize);
        }

        [Fact]
        public void WhenNonExistingMovieIdIsGiven_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            int nonExistingMovieId = -1; // Assuming -1 is not a valid Movie Id

            UpdateMovieCommand updateCommand = new UpdateMovieCommand(_dbContext);
            updateCommand.Id = nonExistingMovieId;
            updateCommand.Model = new UpdateMovieModel()
            {
                Title = "TİTLE6kfgd5",
                ReleaseDate = DateTime.Now.AddDays(-12),
                DirectorId = 1,
                GenreId = 1,
                Prize = 1
            };

            // Act & Assert
            FluentActions.Invoking(() => updateCommand.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Movie Bulunamadı");
        }
    }
}
