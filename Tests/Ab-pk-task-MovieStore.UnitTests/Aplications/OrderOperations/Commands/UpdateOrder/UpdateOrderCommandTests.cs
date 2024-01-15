using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.OrdersOperations.Commands.UpdateOrder;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.OrderOperations.Commands.UpdateOrder
{
    public class UpdateOrderCommandTests: IClassFixture<CommonTextFicture>
    {

        private readonly PatikaDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateOrderCommandTests(CommonTextFicture textFicture)
        {
            _dbContext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        [Fact]
        public void WhenValidInputsAreGiven_OrderShouldBeUpdated()
        {
            // Arrange
            Order existingOrder = new Order()
            {
                CustemerId = 12,
                MovieId = 32,
                Prize = 1231
            };

            _dbContext.Orders.Add(existingOrder);
            _dbContext.SaveChanges();

            UpdateOrderCommand updateCommand = new UpdateOrderCommand(_dbContext);
            var existingOrders = _dbContext.Orders.ToList();

            updateCommand.Id = existingOrder.Id;
            updateCommand.Model = new UpdateOrderModel()
            {
                MovieId = 13,
            };

            // Act
            FluentActions.Invoking(() => updateCommand.Handle()).Invoke();

            // Assert
            var updatedOrder = _dbContext.Orders.Find(existingOrder.Id);
            updatedOrder.Should().NotBeNull();
            updatedOrder.MovieId.Should().Be(updateCommand.Model.MovieId);
        }

        [Fact]
        public void WhenNonExistingOrderIdIsGiven_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            int nonExistingOrderId = -1; // Assuming -1 is not a valid Order Id

            UpdateOrderCommand updateCommand = new UpdateOrderCommand(_dbContext);
            updateCommand.Id = nonExistingOrderId;
            updateCommand.Model = new UpdateOrderModel()
            {
                MovieId = 123,
            };

            // Act & Assert
            FluentActions.Invoking(() => updateCommand.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Order Bulunamadı");
        }
    }
}
