using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.ActorsOperations.Commands.DeleteActor;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommandTests:IClassFixture<CommonTextFicture>
    {

        private readonly PatikaDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteActorCommandTests(CommonTextFicture textFicture)
        {
            _dbContext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        [Fact]
        public void WhenExistingActorIdIsGiven_ActorShouldBeDeleted()
        {
            // Arrange
            Actor Actor = new Actor()
            {
                Name = "ToDeleteActor",
                Surname = "ToDeleteActor",
            };

            _dbContext.Actors.Add(Actor);
            _dbContext.SaveChanges();

            DeleteActorCommand deleteCommand = new DeleteActorCommand(_dbContext);
            deleteCommand.Id = Actor.Id;

            // Act
            FluentActions.Invoking(() => deleteCommand.Handle()).Invoke();

            // Assert
            var deletedActor = _dbContext.Actors.FirstOrDefault(x => x.Id == Actor.Id);
            deletedActor.Should().BeNull();
        }
        [Fact]
        public void WhenNonExistingActorIdIsGiven_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            int nonExistingActorId = -1; // Assuming -1 is not a valid Actor Id

            DeleteActorCommand deleteCommand = new DeleteActorCommand(_dbContext);
            deleteCommand.Id = nonExistingActorId;

            // Act & Assert
            FluentActions.Invoking(() => deleteCommand.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Actor Bulunamadı");
        }

     
    }
}
