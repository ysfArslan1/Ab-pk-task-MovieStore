using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.ActorsOperations.Commands.UpdateActor;
using Ab_pk_task_MovieStore.Aplication.ActorsOperations.Commands.DeleteActor;
using Ab_pk_task_MovieStore.Aplication.ActorsOperations.Commands.UpdateActor;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using AutoMapper;
using FluentAssertions;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.ActorOperations.Commands.DeleteActor
{
    public class UpdateActorCommandValidatorTests:IClassFixture<CommonTextFicture>
    {

        private readonly PatikaDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateActorCommandValidatorTests(CommonTextFicture textFicture)
        {
            _dbContext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        [Theory]
        [InlineData("", "surname")]
        [InlineData("name", "")]
        [InlineData("", "")]
        public void WhenInvalidInputsAreGiven_Validators_ShouldBeReturnErrors(string name, string surname)
        {
            // Arrange
            UpdateActorCommand command = new UpdateActorCommand(null);
            command.Id = _dbContext.Actors.First().Id;
            command.Model = new UpdateActorModel()
            {
                Name = name,
                Surname = surname,
            };

            // Act
            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            var result = validator.Validate(command);

            //assert (Dogrula)
            result.Errors.Count.Should().BeGreaterThan(0); // error sayısı 0'dan fazla olmalı
        }

        

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // Arrange
            UpdateActorCommand command = new UpdateActorCommand(null);
            command.Id = _dbContext.Actors.First().Id;
            // Only DateTime is being tested, others should be valid
            command.Model = new UpdateActorModel()
            {
                Name = "name",
                Surname = "surname",
            };

            // Act
            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            var result = validator.Validate(command);
            //assert (Dogrula)
            result.Errors.Count.Should().Be(0);
        }
    }
}
