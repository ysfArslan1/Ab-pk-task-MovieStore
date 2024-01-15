using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.ActorsOperations.Commands.UpdateActor;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandTests: IClassFixture<CommonTextFicture>
    {

        private readonly PatikaDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateActorCommandTests(CommonTextFicture textFicture)
        {
            _dbContext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        [Fact]
        public void WhenValidInputsAreGiven_ActorShouldBeUpdated()
        {
            // Arrange
            Actor existingActor = new Actor()
            {
                Name = "namegt56",
                Surname = "surname324gte"
            };

            _dbContext.Actors.Add(existingActor);
            _dbContext.SaveChanges();

            UpdateActorCommand updateCommand = new UpdateActorCommand(_dbContext);
            var existingActors = _dbContext.Actors.ToList();

            updateCommand.Id = existingActor.Id;
            updateCommand.Model = new UpdateActorModel()
            {
                Name = "name134566",
                Surname = "surname1"
            };

            // Act
            FluentActions.Invoking(() => updateCommand.Handle()).Invoke();

            // Assert
            var updatedActor = _dbContext.Actors.Find(existingActor.Id);
            updatedActor.Should().NotBeNull();
            updatedActor.Name.Should().Be(updateCommand.Model.Name);
            updatedActor.Surname.Should().Be(updateCommand.Model.Surname);
        }

        [Fact]
        public void WhenNonExistingActorIdIsGiven_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            int nonExistingActorId = -1; // Assuming -1 is not a valid Actor Id

            UpdateActorCommand updateCommand = new UpdateActorCommand(_dbContext);
            updateCommand.Id = nonExistingActorId;
            updateCommand.Model = new UpdateActorModel()
            {
                Name = "name",
                Surname = "surname",
            };

            // Act & Assert
            FluentActions.Invoking(() => updateCommand.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Actor Bulunamadı");
        }
    }
}
