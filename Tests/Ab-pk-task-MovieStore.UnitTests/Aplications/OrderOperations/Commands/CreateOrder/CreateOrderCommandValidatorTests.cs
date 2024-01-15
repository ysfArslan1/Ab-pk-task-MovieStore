using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.OrdersOperations.Commands.CreateOrder;
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

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommandValidatorTests:IClassFixture<CommonTextFicture>
    {
        
        [Theory]  // hatalı deneme yapıyorum
        [InlineData(null,1,1)]
        [InlineData(1, null, 1)]
        [InlineData(1, 1, null)]
        [InlineData(null, null, 1)]
        public void WhenInvalidInputsAreGiven_Validators_ShouldBeReturnErrors(int id1, int id2, int num)
        {
            //arrange(Hazırla)
            CreateOrderCommand command = new CreateOrderCommand(null, null);
            command.Model = new CreateOrderModel()
            {
                CustemerId = id1,
                MovieId = id2,
                Prize = num

            };

            //act  (Çalıştır )
            CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
            var result = validator.Validate(command.Model);

            //assert (Dogrula)
            result.Errors.Count.Should().BeGreaterThan(0); // error sayısı 0'dan fazla olmalı

        }


        [Fact] // Dogru Çalışma durumu
        public void WhenValidInputsIsGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange(Hazırla)
            CreateOrderCommand command = new CreateOrderCommand(null, null);
            // sadece datetime test edildigi için digerleri valid olmalı
            command.Model = new CreateOrderModel()
            {
                CustemerId = 12,
                MovieId = 21,
                Prize = 1221

            };

            //act  (Çalıştır )
            CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
            var result = validator.Validate(command.Model);

            //assert (Dogrula)
            result.Errors.Count.Should().Be(0); 

        }
    }
}
