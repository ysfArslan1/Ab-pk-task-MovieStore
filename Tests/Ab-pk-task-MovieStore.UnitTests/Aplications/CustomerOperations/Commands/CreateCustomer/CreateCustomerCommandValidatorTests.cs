using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.CustomersOperations.Commands.CreateCustomer;
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

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidatorTests:IClassFixture<CommonTextFicture>
    {
        
        [Theory]  // hatalı deneme yapıyorum
        [InlineData("","surname")]
        [InlineData("name","")]
        [InlineData("", "")]
        public void WhenInvalidInputsAreGiven_Validators_ShouldBeReturnErrors(string name, string surname)
        {
            //arrange(Hazırla)
            CreateCustomerCommand command = new CreateCustomerCommand(null, null);
            command.Model = new CreateCustomerModel()
            {
                Name = name,
                Surname = surname,

            };

            //act  (Çalıştır )
            CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
            var result = validator.Validate(command.Model);

            //assert (Dogrula)
            result.Errors.Count.Should().BeGreaterThan(0); // error sayısı 0'dan fazla olmalı

        }


        [Fact] // Dogru Çalışma durumu
        public void WhenValidInputsIsGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange(Hazırla)
            CreateCustomerCommand command = new CreateCustomerCommand(null, null);
            // sadece datetime test edildigi için digerleri valid olmalı
            command.Model = new CreateCustomerModel()
            {
                Name = "name387464",
                Surname = "surname3ly4",
                Email = "alytu92@gmail.com",
                Password = "12345",

            };

            //act  (Çalıştır )
            CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
            var result = validator.Validate(command.Model);

            //assert (Dogrula)
            result.Errors.Count.Should().Be(0); 

        }
    }
}
