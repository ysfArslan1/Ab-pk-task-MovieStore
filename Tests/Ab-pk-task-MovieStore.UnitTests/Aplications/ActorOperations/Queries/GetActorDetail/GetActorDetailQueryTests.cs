using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.ActorsOperations.Commands.DeleteActor;
using Ab_pk_task_MovieStore.Aplication.ActorsOperations.Commands.UpdateActor;
using Ab_pk_task_MovieStore.Aplication.ActorsOperations.Queries.GetActorDetail;
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

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailQueryTests: IClassFixture<CommonTextFicture>
    {
        private readonly PatikaDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetActorDetailQueryTests(CommonTextFicture textFicture)
        {
            _dbcontext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        

        [Fact]
        public void WhenNonExistingActorIdIsGiven_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            int nonExistingActorId = -1; // Assuming -1 is not a valid Actor Id

            GetActorDetailQuery query = new GetActorDetailQuery(_dbcontext,_mapper);
            query.Id = nonExistingActorId;

            // Act & Assert
            FluentActions.Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bulunamadı");
        }

        [Fact]
        public void WhenExistingActorIdIsGiven_ActorShouldBeReturn()
        {
            // Arrange
            Actor Actor = new Actor()
            {
                Name = "name",
                Surname = "surname",
            };

            _dbcontext.Actors.Add(Actor);
            _dbcontext.SaveChanges();

            GetActorDetailQuery query = new GetActorDetailQuery(_dbcontext,_mapper);
            query.Id = Actor.Id;

            // Act
            FluentActions.Invoking(() => query.Handle()).Invoke();

            // Assert
            var result = _dbcontext.Actors.FirstOrDefault(x => x.Id == Actor.Id);
            result.Should().NotBeNull();
            result.Name.Should().Be(Actor.Name);
            result.Surname.Should().Be(Actor.Surname);
        }
    }
}
