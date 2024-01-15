using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.OrdersOperations.Commands.DeleteOrder;
using Ab_pk_task_MovieStore.Aplication.OrdersOperations.Commands.UpdateOrder;
using Ab_pk_task_MovieStore.Aplication.OrdersOperations.Queries.GetOrderDetail;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.OrderOperations.Queries.GetOrderDetail
{
    public class GetOrderDetailQueryTests: IClassFixture<CommonTextFicture>
    {
        private readonly PatikaDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetOrderDetailQueryTests(CommonTextFicture textFicture)
        {
            _dbcontext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        

        [Fact]
        public void WhenNonExistingOrderIdIsGiven_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            int nonExistingOrderId = -1; // Assuming -1 is not a valid Order Id

            GetOrderDetailQuery query = new GetOrderDetailQuery(_dbcontext,_mapper);
            query.Id = nonExistingOrderId;

            // Act & Assert
            FluentActions.Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bulunamadı");
        }

        [Fact]
        public void WhenExistingOrderIdIsGiven_OrderShouldBeReturn()
        {
            // Arrange
            Order Order = new Order()
            {
                CustemerId = 1,
                MovieId = 1,
                Prize = 123
            };

            _dbcontext.Orders.Add(Order);
            _dbcontext.SaveChanges();

            GetOrderDetailQuery query = new GetOrderDetailQuery(_dbcontext,_mapper);
            query.Id = Order.Id;

            // Act
            FluentActions.Invoking(() => query.Handle()).Invoke();

            // Assert
            var result = _dbcontext.Orders.FirstOrDefault(x => x.Id == Order.Id);
            result.Should().NotBeNull();
            result.CustemerId.Should().Be(Order.CustemerId);
            result.MovieId.Should().Be(Order.MovieId);
            result.Prize.Should().Be(Order.Prize);
        }
    }
}
