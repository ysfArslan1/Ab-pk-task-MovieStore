using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.MoviesOperations.Commands.CreateMovie;
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

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommandValidatorTests:IClassFixture<CommonTextFicture>
    {
        
        [Theory]  // hatalı deneme yapıyorum
        [InlineData("denemergg",null,1,1)]
        [InlineData("denemesf", 1, null, 1)]
        [InlineData("denemetege", 1, 1, null)]
        [InlineData("", 1, 1, 1)]
        [InlineData(null, 1, 1, 1)]
        public void WhenInvalidInputsAreGiven_Validators_ShouldBeReturnErrors(string title, int id1, int id2,int num)
        {
            //arrange(Hazırla)
            CreateMovieCommand command = new CreateMovieCommand(null, null);
            command.Model = new CreateMovieModel()
            {
                Title = title,
                ReleaseDate = DateTime.Now.AddDays(-12),
                DirectorId = id1,
                GenreId = id2,
                Prize = num

            };

            //act  (Çalıştır )
            CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
            var result = validator.Validate(command.Model);

            //assert (Dogrula)
            result.Errors.Count.Should().BeGreaterThan(0); // error sayısı 0'dan fazla olmalı

        }


        [Fact] // Dogru Çalışma durumu
        public void WhenValidInputsIsGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange(Hazırla)
            CreateMovieCommand command = new CreateMovieCommand(null, null);
            // sadece datetime test edildigi için digerleri valid olmalı
            command.Model = new CreateMovieModel()
            {
                Title = "TİTLE63LIOYK5",
                ReleaseDate = DateTime.Now.AddDays(-12),
                DirectorId = 1,
                GenreId = 1,
                Prize = 1

            };

            //act  (Çalıştır )
            CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
            var result = validator.Validate(command.Model);

            //assert (Dogrula)
            result.Errors.Count.Should().Be(0); 

        }
    }
}
