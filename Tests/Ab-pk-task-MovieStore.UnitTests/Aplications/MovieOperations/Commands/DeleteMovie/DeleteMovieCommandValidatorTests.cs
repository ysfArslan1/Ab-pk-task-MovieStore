using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.MoviesOperations.Commands.DeleteMovie;
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
    public class DeleteMovieCommandValidatorTests:IClassFixture<CommonTextFicture>
    {

        private readonly PatikaDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteMovieCommandValidatorTests(CommonTextFicture textFicture)
        {
            _dbContext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        [Fact]
        public void WhenIdIsNotProvided_ShouldHaveValidationError()
        {
            // Arrange
            var validator = new DeleteMovieCommandValidator();
            var deleteCommand = new DeleteMovieCommand(_dbContext);

            // Act
            var result = validator.TestValidate(deleteCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenIdIsNotGreaterThanZero_ShouldHaveValidationError(int invalidId)
        {
            // Arrange
            var validator = new DeleteMovieCommandValidator();
            var deleteCommand = new DeleteMovieCommand(_dbContext);
            deleteCommand.Id = invalidId;

            // Act
            var result = validator.TestValidate(deleteCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public void WhenIdIsProvided_ShouldNotHaveValidationError()
        {
            // Arrange
            var validator = new DeleteMovieCommandValidator();
            var deleteCommand = new DeleteMovieCommand (_dbContext);
            deleteCommand.Id = _dbContext.Movies.First().Id;

            // Act
            var result = validator.TestValidate(deleteCommand);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Id);
        }
    }
}
