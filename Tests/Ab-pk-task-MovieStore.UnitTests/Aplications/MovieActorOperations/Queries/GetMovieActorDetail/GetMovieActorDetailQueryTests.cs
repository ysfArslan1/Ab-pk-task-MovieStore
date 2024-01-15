using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.MovieActorsOperations.Commands.DeleteMovieActor;
using Ab_pk_task_MovieStore.Aplication.MovieActorsOperations.Commands.UpdateMovieActor;
using Ab_pk_task_MovieStore.Aplication.MovieActorsOperations.Queries.GetMovieActorDetail;
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

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.MovieActorOperations.Queries.GetMovieActorDetail
{
    public class GetMovieActorDetailQueryTests: IClassFixture<CommonTextFicture>
    {
        private readonly PatikaDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetMovieActorDetailQueryTests(CommonTextFicture textFicture)
        {
            _dbcontext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        

        [Fact]
        public void WhenNonExistingMovieActorIdIsGiven_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            int nonExistingMovieActorId = -1; // Assuming -1 is not a valid MovieActor Id

            GetMovieActorDetailQuery query = new GetMovieActorDetailQuery(_dbcontext,_mapper);
            query.Id = nonExistingMovieActorId;

            // Act & Assert
            FluentActions.Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bulunamadı");
        }

        [Fact]
        public void WhenExistingMovieActorIdIsGiven_MovieActorShouldBeReturn()
        {
            // Arrange
            MovieActor MovieActor = new MovieActor()
            {
                MovieId = 1,
                ActorId = 1
            };

            _dbcontext.MovieActors.Add(MovieActor);
            _dbcontext.SaveChanges();

            GetMovieActorDetailQuery query = new GetMovieActorDetailQuery(_dbcontext,_mapper);
            query.Id = MovieActor.Id;

            // Act
            FluentActions.Invoking(() => query.Handle()).Invoke();

            // Assert
            var result = _dbcontext.MovieActors.FirstOrDefault(x => x.Id == MovieActor.Id);
            result.Should().NotBeNull();
            result.MovieId.Should().Be(MovieActor.MovieId);
            result.ActorId.Should().Be(MovieActor.ActorId);
        }
    }
}
