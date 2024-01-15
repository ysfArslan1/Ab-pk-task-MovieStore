using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.DirectorsOperations.Commands.CreateDirector;
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

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommandValidatorTests:IClassFixture<CommonTextFicture>
    {
        
        [Theory]  // hatalı deneme yapıyorum
        [InlineData("","surname")]
        [InlineData("name","")]
        [InlineData("", "")]
        public void WhenInvalidInputsAreGiven_Validators_ShouldBeReturnErrors(string name, string surname)
        {
            //arrange(Hazırla)
            CreateDirectorCommand command = new CreateDirectorCommand(null, null);
            command.Model = new CreateDirectorModel()
            {
                Name = name,
                Surname = surname,

            };

            //act  (Çalıştır )
            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            var result = validator.Validate(command.Model);

            //assert (Dogrula)
            result.Errors.Count.Should().BeGreaterThan(0); // error sayısı 0'dan fazla olmalı

        }


        [Fact] // Dogru Çalışma durumu
        public void WhenValidInputsIsGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange(Hazırla)
            CreateDirectorCommand command = new CreateDirectorCommand(null, null);
            // sadece datetime test edildigi için digerleri valid olmalı
            command.Model = new CreateDirectorModel()
            {
                Name = "name34",
                Surname = "surname34",

            };

            //act  (Çalıştır )
            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            var result = validator.Validate(command.Model);

            //assert (Dogrula)
            result.Errors.Count.Should().Be(0); 

        }
    }
}
