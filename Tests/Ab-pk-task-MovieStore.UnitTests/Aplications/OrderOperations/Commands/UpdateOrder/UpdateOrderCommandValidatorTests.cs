using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.OrdersOperations.Commands.UpdateOrder;
using Ab_pk_task_MovieStore.Aplication.OrdersOperations.Commands.DeleteOrder;
using Ab_pk_task_MovieStore.Aplication.OrdersOperations.Commands.UpdateOrder;
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

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.OrderOperations.Commands.DeleteOrder
{
    public class UpdateOrderCommandValidatorTests:IClassFixture<CommonTextFicture>
    {

        private readonly PatikaDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateOrderCommandValidatorTests(CommonTextFicture textFicture)
        {
            _dbContext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        [Theory]
        [InlineData(-4)]
        [InlineData(null)]
        [InlineData(0)]
        public void WhenInvalidInputsAreGiven_Validators_ShouldBeReturnErrors(int id1)
        {
            // Arrange
            UpdateOrderCommand command = new UpdateOrderCommand(null);
            command.Id = _dbContext.Orders.First().Id;
            command.Model = new UpdateOrderModel()
            {
                MovieId = id1,
            };

            // Act
            UpdateOrderCommandValidator validator = new UpdateOrderCommandValidator();
            var result = validator.Validate(command);

            //assert (Dogrula)
            result.Errors.Count.Should().BeGreaterThan(0); // error sayısı 0'dan fazla olmalı
        }

        

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // Arrange
            UpdateOrderCommand command = new UpdateOrderCommand(null);
            command.Id = _dbContext.Orders.First().Id;
            // Only DateTime is being tested, others should be valid
            command.Model = new UpdateOrderModel()
            {
                MovieId = 123
            };

            // Act
            UpdateOrderCommandValidator validator = new UpdateOrderCommandValidator();
            var result = validator.Validate(command);
            //assert (Dogrula)
            result.Errors.Count.Should().Be(0);
        }
    }
}
