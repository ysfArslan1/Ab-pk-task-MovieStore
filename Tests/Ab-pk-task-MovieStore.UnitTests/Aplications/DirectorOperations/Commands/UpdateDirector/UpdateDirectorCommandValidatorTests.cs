using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.DirectorsOperations.Commands.UpdateDirector;
using Ab_pk_task_MovieStore.Aplication.DirectorsOperations.Commands.DeleteDirector;
using Ab_pk_task_MovieStore.Aplication.DirectorsOperations.Commands.UpdateDirector;
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

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.DirectorOperations.Commands.DeleteDirector
{
    public class UpdateDirectorCommandValidatorTests:IClassFixture<CommonTextFicture>
    {

        private readonly PatikaDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateDirectorCommandValidatorTests(CommonTextFicture textFicture)
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
            UpdateDirectorCommand command = new UpdateDirectorCommand(null);
            command.Id = _dbContext.Directors.First().Id;
            command.Model = new UpdateDirectorModel()
            {
                Name = name,
                Surname = surname,
            };

            // Act
            UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
            var result = validator.Validate(command);

            //assert (Dogrula)
            result.Errors.Count.Should().BeGreaterThan(0); // error sayısı 0'dan fazla olmalı
        }

        

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // Arrange
            UpdateDirectorCommand command = new UpdateDirectorCommand(null);
            command.Id = _dbContext.Directors.First().Id;
            // Only DateTime is being tested, others should be valid
            command.Model = new UpdateDirectorModel()
            {
                Name = "name",
                Surname = "surname",
            };

            // Act
            UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
            var result = validator.Validate(command);
            //assert (Dogrula)
            result.Errors.Count.Should().Be(0);
        }
    }
}
