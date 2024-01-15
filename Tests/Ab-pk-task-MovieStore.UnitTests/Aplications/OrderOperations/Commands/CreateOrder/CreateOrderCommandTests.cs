using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.OrdersOperations.Commands.CreateOrder;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommandTests:IClassFixture<CommonTextFicture>
    {
        private readonly PatikaDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateOrderCommandTests(CommonTextFicture textFicture)
        {
            _dbcontext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        

        [Fact]
        public void WhenValidInputsIsGiven_Order_ShouldBeCreated()
        {
            //arrange(Hazırla)
            
            CreateOrderCommand command = new CreateOrderCommand(_dbcontext, _mapper);
            command.Model = new CreateOrderModel()
            {
                CustemerId = 2,
                MovieId = 3,
                Prize = 1231

            };
            // act
            FluentActions.Invoking(()=>command.Handle()).Invoke();

            // assert 
            var Order = _dbcontext.Orders.FirstOrDefault(x=>x.CustemerId == command.Model.CustemerId && x.MovieId == command.Model.MovieId);
            Order.Should().NotBeNull();
            Order.MovieId.Should().Be(command.Model.MovieId);
            Order.CustemerId.Should().Be(command.Model.CustemerId);
        }
    }
}
