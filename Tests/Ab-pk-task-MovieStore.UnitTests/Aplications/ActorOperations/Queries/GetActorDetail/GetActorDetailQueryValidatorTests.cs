using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.ActorsOperations.Commands.DeleteActor;
using Ab_pk_task_MovieStore.Aplication.ActorsOperations.Commands.UpdateActor;
using Ab_pk_task_MovieStore.Aplication.ActorsOperations.Queries.GetActorDetail;
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

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailQueryValidatorTests: IClassFixture<CommonTextFicture>
    {
        private readonly PatikaDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetActorDetailQueryValidatorTests(CommonTextFicture textFicture)
        {
            _dbcontext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }


        [Fact]
        public void WhenIdIsNotProvided_ShouldHaveValidationError()
        {
            // Arrange
            var validator = new GetActorDetailQueryValidator();
            var item = new GetActorDetailQuery(_dbcontext,_mapper);

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
            var validator = new GetActorDetailQueryValidator();
            var item = new GetActorDetailQuery(_dbcontext, _mapper);
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
            var validator = new GetActorDetailQueryValidator();
            var item = new GetActorDetailQuery(_dbcontext, _mapper);
            item.Id = _dbcontext.Actors.First().Id;

            // Act
            var result = validator.TestValidate(item);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Id);
        }
    }
}
