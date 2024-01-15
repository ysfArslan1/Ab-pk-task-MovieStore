using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.MovieActorsOperations.Commands.UpdateMovieActor;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.MovieActorOperations.Commands.UpdateMovieActor
{
    public class UpdateMovieActorCommandTests: IClassFixture<CommonTextFicture>
    {

        private readonly PatikaDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateMovieActorCommandTests(CommonTextFicture textFicture)
        {
            _dbContext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        [Fact]
        public void WhenValidInputsAreGiven_MovieActorShouldBeUpdated()
        {
            // Arrange
            MovieActor existingMovieActor = new MovieActor()
            {
                MovieId = 1,
                ActorId = 4
            };

            _dbContext.MovieActors.Add(existingMovieActor);
            _dbContext.SaveChanges();

            UpdateMovieActorCommand updateCommand = new UpdateMovieActorCommand(_dbContext);
            var existingMovieActors = _dbContext.MovieActors.ToList();

            updateCommand.Id = existingMovieActor.Id;
            updateCommand.Model = new UpdateMovieActorModel()
            {
                MovieId = 2,
                ActorId = 3
            };

            // Act
            FluentActions.Invoking(() => updateCommand.Handle()).Invoke();

            // Assert
            var updatedMovieActor = _dbContext.MovieActors.Find(existingMovieActor.Id);
            updatedMovieActor.Should().NotBeNull();
            updatedMovieActor.MovieId.Should().Be(updateCommand.Model.MovieId);
            updatedMovieActor.ActorId.Should().Be(updateCommand.Model.ActorId);
        }

        [Fact]
        public void WhenNonExistingMovieActorIdIsGiven_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            int nonExistingMovieActorId = -1; // Assuming -1 is not a valid MovieActor Id

            UpdateMovieActorCommand updateCommand = new UpdateMovieActorCommand(_dbContext);
            updateCommand.Id = nonExistingMovieActorId;
            updateCommand.Model = new UpdateMovieActorModel()
            {
                MovieId = 1,
                ActorId = 1
            };

            // Act & Assert
            FluentActions.Invoking(() => updateCommand.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("MovieActor Bulunamadı");
        }
    }
}
