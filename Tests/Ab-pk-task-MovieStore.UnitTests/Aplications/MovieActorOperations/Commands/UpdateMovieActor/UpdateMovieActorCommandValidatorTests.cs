using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.MovieActorsOperations.Commands.UpdateMovieActor;
using Ab_pk_task_MovieStore.Aplication.MovieActorsOperations.Commands.DeleteMovieActor;
using Ab_pk_task_MovieStore.Aplication.MovieActorsOperations.Commands.UpdateMovieActor;
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

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.MovieActorOperations.Commands.DeleteMovieActor
{
    public class UpdateMovieActorCommandValidatorTests : IClassFixture<CommonTextFicture>
    {

        private readonly PatikaDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateMovieActorCommandValidatorTests(CommonTextFicture textFicture)
        {
            _dbContext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        [Theory]
        [InlineData(null, 1)]
        [InlineData(2,null)]
        [InlineData(null, null)]
        public void WhenInvalidInputsAreGiven_Validators_ShouldBeReturnErrors(int id1, int id2)
        {
            // Arrange
            UpdateMovieActorCommand command = new UpdateMovieActorCommand(null);
            command.Id = _dbContext.MovieActors.First().Id;
            command.Model = new UpdateMovieActorModel()
            {
                MovieId = id1,
                ActorId = id2
            };

            // Act
            UpdateMovieActorCommandValidator validator = new UpdateMovieActorCommandValidator();
            var result = validator.Validate(command);

            //assert (Dogrula)
            result.Errors.Count.Should().BeGreaterThan(0); // error sayısı 0'dan fazla olmalı
        }

        

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // Arrange
            UpdateMovieActorCommand command = new UpdateMovieActorCommand(null);
            command.Id = _dbContext.MovieActors.First().Id;
            // Only DateTime is being tested, others should be valid
            command.Model = new UpdateMovieActorModel()
            {
                MovieId = 1,
                ActorId = 1
            };

            // Act
            UpdateMovieActorCommandValidator validator = new UpdateMovieActorCommandValidator();
            var result = validator.Validate(command);
            //assert (Dogrula)
            result.Errors.Count.Should().Be(0);
        }
    }
}
