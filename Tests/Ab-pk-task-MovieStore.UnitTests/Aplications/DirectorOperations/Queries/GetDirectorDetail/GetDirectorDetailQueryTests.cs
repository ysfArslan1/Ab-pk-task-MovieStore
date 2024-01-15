using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.DirectorsOperations.Commands.DeleteDirector;
using Ab_pk_task_MovieStore.Aplication.DirectorsOperations.Commands.UpdateDirector;
using Ab_pk_task_MovieStore.Aplication.DirectorsOperations.Queries.GetDirectorDetail;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQueryTests: IClassFixture<CommonTextFicture>
    {
        private readonly PatikaDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetDirectorDetailQueryTests(CommonTextFicture textFicture)
        {
            _dbcontext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        

        [Fact]
        public void WhenNonExistingDirectorIdIsGiven_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            int nonExistingDirectorId = -1; // Assuming -1 is not a valid Director Id

            GetDirectorDetailQuery query = new GetDirectorDetailQuery(_dbcontext,_mapper);
            query.Id = nonExistingDirectorId;

            // Act & Assert
            FluentActions.Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bulunamadı");
        }

        [Fact]
        public void WhenExistingDirectorIdIsGiven_DirectorShouldBeReturn()
        {
            // Arrange
            Director Director = new Director()
            {
                Name = "name",
                Surname = "surname",
            };

            _dbcontext.Directors.Add(Director);
            _dbcontext.SaveChanges();

            GetDirectorDetailQuery query = new GetDirectorDetailQuery(_dbcontext,_mapper);
            query.Id = Director.Id;

            // Act
            FluentActions.Invoking(() => query.Handle()).Invoke();

            // Assert
            var result = _dbcontext.Directors.FirstOrDefault(x => x.Id == Director.Id);
            result.Should().NotBeNull();
            result.Name.Should().Be(Director.Name);
            result.Surname.Should().Be(Director.Surname);
        }
    }
}
