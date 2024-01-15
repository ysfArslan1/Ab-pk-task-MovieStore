using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.MovieActorsOperations.Commands.DeleteMovieActor;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.MovieActorOperations.Commands.DeleteMovieActor
{
    public class DeleteMovieActorCommandTests:IClassFixture<CommonTextFicture>
    {

        private readonly PatikaDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteMovieActorCommandTests(CommonTextFicture textFicture)
        {
            _dbContext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        [Fact]
        public void WhenExistingMovieActorIdIsGiven_MovieActorShouldBeDeleted()
        {
            // Arrange
            MovieActor MovieActor = new MovieActor()
            {
                MovieId = 1,
                ActorId = 1
            };

            _dbContext.MovieActors.Add(MovieActor);
            _dbContext.SaveChanges();

            DeleteMovieActorCommand deleteCommand = new DeleteMovieActorCommand(_dbContext);
            deleteCommand.Id = MovieActor.Id;

            // Act
            FluentActions.Invoking(() => deleteCommand.Handle()).Invoke();

            // Assert
            var deletedMovieActor = _dbContext.MovieActors.FirstOrDefault(x => x.Id == MovieActor.Id);
            deletedMovieActor.Should().BeNull();
        }
        [Fact]
        public void WhenNonExistingMovieActorIdIsGiven_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            int nonExistingMovieActorId = -1; // Assuming -1 is not a valid MovieActor Id

            DeleteMovieActorCommand deleteCommand = new DeleteMovieActorCommand(_dbContext);
            deleteCommand.Id = nonExistingMovieActorId;

            // Act & Assert
            FluentActions.Invoking(() => deleteCommand.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("MovieActor Bulunamadı");
        }

     
    }
}
