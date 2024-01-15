using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.OrdersOperations.Commands.DeleteOrder;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.OrderOperations.Commands.DeleteOrder
{
    public class DeleteOrderCommandTests:IClassFixture<CommonTextFicture>
    {

        private readonly PatikaDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteOrderCommandTests(CommonTextFicture textFicture)
        {
            _dbContext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }

        [Fact]
        public void WhenNonExistingOrderIdIsGiven_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            int nonExistingOrderId = -1; // Assuming -1 is not a valid Order Id

            DeleteOrderCommand deleteCommand = new DeleteOrderCommand(_dbContext);
            deleteCommand.Id = nonExistingOrderId;

            // Act & Assert
            FluentActions.Invoking(() => deleteCommand.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Order Bulunamadı");
        }

     
    }
}
