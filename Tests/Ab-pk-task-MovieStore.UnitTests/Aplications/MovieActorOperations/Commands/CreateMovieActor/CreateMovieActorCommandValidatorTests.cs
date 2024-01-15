using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.MovieActorsOperations.Commands.CreateMovieActor;
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

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.MovieActorOperations.Commands.CreateMovieActor
{
    public class CreateMovieActorCommandValidatorTests:IClassFixture<CommonTextFicture>
    {
        
        [Theory]  // hatalı deneme yapıyorum
        [InlineData(1,null)]
        [InlineData(null,3)]
        [InlineData(null, null)]
        public void WhenInvalidInputsAreGiven_Validators_ShouldBeReturnErrors(int id1, int id2)
        {
            //arrange(Hazırla)
            CreateMovieActorCommand command = new CreateMovieActorCommand(null, null);
            command.Model = new CreateMovieActorModel()
            {
                MovieId = id1,
                ActorId = id2

            };

            //act  (Çalıştır )
            CreateMovieActorCommandValidator validator = new CreateMovieActorCommandValidator();
            var result = validator.Validate(command.Model);

            //assert (Dogrula)
            result.Errors.Count.Should().BeGreaterThan(0); // error sayısı 0'dan fazla olmalı

        }


        [Fact] // Dogru Çalışma durumu
        public void WhenValidInputsIsGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange(Hazırla)
            CreateMovieActorCommand command = new CreateMovieActorCommand(null, null);
            // sadece datetime test edildigi için digerleri valid olmalı
            command.Model = new CreateMovieActorModel()
            {
                MovieId = 1,
                ActorId = 1

            };

            //act  (Çalıştır )
            CreateMovieActorCommandValidator validator = new CreateMovieActorCommandValidator();
            var result = validator.Validate(command.Model);

            //assert (Dogrula)
            result.Errors.Count.Should().Be(0); 

        }
    }
}
