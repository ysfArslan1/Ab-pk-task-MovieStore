using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.CustomersOperations.Commands.UpdateCustomer;
using Ab_pk_task_MovieStore.Aplication.CustomersOperations.Commands.DeleteCustomer;
using Ab_pk_task_MovieStore.Aplication.CustomersOperations.Commands.UpdateCustomer;
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

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.CustomerOperations.Commands.DeleteCustomer
{
    public class UpdateCustomerCommandValidatorTests:IClassFixture<CommonTextFicture>
    {

        private readonly PatikaDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandValidatorTests(CommonTextFicture textFicture)
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
            UpdateCustomerCommand command = new UpdateCustomerCommand(null);
            command.Id = _dbContext.Customers.First().Id;
            command.Model = new UpdateCustomerModel()
            {
                Name = name,
                Surname = surname,
            };

            // Act
            UpdateCustomerCommandValidator validator = new UpdateCustomerCommandValidator();
            var result = validator.Validate(command);

            //assert (Dogrula)
            result.Errors.Count.Should().BeGreaterThan(0); // error sayısı 0'dan fazla olmalı
        }

        

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // Arrange
            UpdateCustomerCommand command = new UpdateCustomerCommand(null);
            command.Id = _dbContext.Customers.First().Id;
            // Only DateTime is being tested, others should be valid
            command.Model = new UpdateCustomerModel()
            {
                Name = "name",
                Surname = "surname",
                Email = "a@gmail.com",
                Password = "12345",
            };

            // Act
            UpdateCustomerCommandValidator validator = new UpdateCustomerCommandValidator();
            var result = validator.Validate(command);
            //assert (Dogrula)
            result.Errors.Count.Should().Be(0);
        }
    }
}
