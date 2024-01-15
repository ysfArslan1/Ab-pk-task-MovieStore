using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.ActorsOperations.Commands.CreateActor;
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

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandValidatorTests:IClassFixture<CommonTextFicture>
    {
        
        [Theory]  // hatalı deneme yapıyorum
        [InlineData("","surname")]
        [InlineData("name","")]
        [InlineData("", "")]
        public void WhenInvalidInputsAreGiven_Validators_ShouldBeReturnErrors(string name, string surname)
        {
            //arrange(Hazırla)
            CreateActorCommand command = new CreateActorCommand(null, null);
            command.Model = new CreateActorModel()
            {
                Name = name,
                Surname = surname,

            };

            //act  (Çalıştır )
            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            var result = validator.Validate(command.Model);

            //assert (Dogrula)
            result.Errors.Count.Should().BeGreaterThan(0); // error sayısı 0'dan fazla olmalı

        }


        [Fact] // Dogru Çalışma durumu
        public void WhenValidInputsIsGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange(Hazırla)
            CreateActorCommand command = new CreateActorCommand(null, null);
            // sadece datetime test edildigi için digerleri valid olmalı
            command.Model = new CreateActorModel()
            {
                Name = "name34",
                Surname = "surname34",

            };

            //act  (Çalıştır )
            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            var result = validator.Validate(command.Model);

            //assert (Dogrula)
            result.Errors.Count.Should().Be(0); 

        }
    }
}
