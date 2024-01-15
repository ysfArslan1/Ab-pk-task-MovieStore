using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.MoviesOperations.Commands.UpdateMovie;
using Ab_pk_task_MovieStore.Aplication.MoviesOperations.Commands.DeleteMovie;
using Ab_pk_task_MovieStore.Aplication.MoviesOperations.Commands.UpdateMovie;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using AutoMapper;
using FluentAssertions;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.MovieOperations.Commands.DeleteMovie
{
    public class UpdateMovieCommandValidatorTests:IClassFixture<CommonTextFicture>
    {

        private readonly PatikaDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateMovieCommandValidatorTests(CommonTextFicture textFicture)
        {
            _dbContext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }

        [Theory]  // hatalı deneme yapıyorum
        [InlineData("denemergg", null, 1, 1)]
        [InlineData("denemesf", 1, null, 1)]
        [InlineData("denemetege", 1, 1, null)]
        [InlineData("", 1, 1, 1)]
        [InlineData(null, 1, 1, 1)]
        public void WhenInvalidInputsAreGiven_Validators_ShouldBeReturnErrors(string title, int id1, int id2, int num)
        {
            // Arrange
            UpdateMovieCommand command = new UpdateMovieCommand(null);
            command.Id = _dbContext.Movies.First().Id;
            command.Model = new UpdateMovieModel()
            {
                Title = null,
                ReleaseDate = DateTime.Now.AddDays(-12),
                DirectorId = id1,
                GenreId = id2,
                Prize = num
            };

            // Act
            UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
            var result = validator.Validate(command);

            //assert (Dogrula)
            result.Errors.Count.Should().BeGreaterThan(0); // error sayısı 0'dan fazla olmalı
        }

        

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // Arrange
            UpdateMovieCommand command = new UpdateMovieCommand(null);
            command.Id = _dbContext.Movies.First().Id;
            // Only DateTime is being tested, others should be valid
            command.Model = new UpdateMovieModel()
            {
                Title = "TİTLEngfhgdfb55",
                ReleaseDate = DateTime.Now.AddDays(-12),
                DirectorId = 1,
                GenreId = 1,
                Prize = 1
            };

            // Act
            UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
            var result = validator.Validate(command);
            //assert (Dogrula)
            result.Errors.Count.Should().Be(0);
        }
    }
}
