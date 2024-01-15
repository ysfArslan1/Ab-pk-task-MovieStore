using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.MoviesOperations.Commands.DeleteMovie;
using Ab_pk_task_MovieStore.Aplication.MoviesOperations.Commands.UpdateMovie;
using Ab_pk_task_MovieStore.Aplication.MoviesOperations.Queries.GetMovieDetail;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using AutoMapper;
using FluentAssertions;
using FluentValidation.TestHelper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQueryValidatorTests: IClassFixture<CommonTextFicture>
    {
        private readonly PatikaDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetMovieDetailQueryValidatorTests(CommonTextFicture textFicture)
        {
            _dbcontext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }


        [Fact]
        public void WhenIdIsNotProvided_ShouldHaveValidationError()
        {
            // Arrange
            var validator = new GetMovieDetailQueryValidator();
            var item = new GetMovieDetailQuery(_dbcontext,_mapper);

            // Act
            var result = validator.TestValidate(item);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenIdIsNotGreaterThanZero_ShouldHaveValidationError(int invalidId)
        {
            // Arrange
            var validator = new GetMovieDetailQueryValidator();
            var item = new GetMovieDetailQuery(_dbcontext, _mapper);
            item.Id = invalidId;

            // Act
            var result = validator.TestValidate(item);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public void WhenIdIsProvided_ShouldNotHaveValidationError()
        {
            // Arrange
            var validator = new GetMovieDetailQueryValidator();
            var item = new GetMovieDetailQuery(_dbcontext, _mapper);
            item.Id = _dbcontext.Movies.First().Id;

            // Act
            var result = validator.TestValidate(item);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Id);
        }
    }
}
