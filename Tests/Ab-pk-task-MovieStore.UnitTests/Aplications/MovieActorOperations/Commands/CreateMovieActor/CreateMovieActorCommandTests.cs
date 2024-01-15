using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.MovieActorsOperations.Commands.CreateMovieActor;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.MovieActorOperations.Commands.CreateMovieActor
{
    public class CreateMovieActorCommandTests:IClassFixture<CommonTextFicture>
    {
        private readonly PatikaDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateMovieActorCommandTests(CommonTextFicture textFicture)
        {
            _dbcontext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistMovieActorNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange(Hazırla)
            MovieActor MovieActor = new MovieActor()
            {
                MovieId=1,
                ActorId=1
                
            };
            _dbcontext.MovieActors.Add(MovieActor);
            _dbcontext.SaveChanges();

            CreateMovieActorCommand command = new CreateMovieActorCommand(_dbcontext, _mapper);
            command.Model = new CreateMovieActorModel() { MovieId = MovieActor.MovieId, ActorId=MovieActor.ActorId};

            //act & assert (Çalıştır & Dogrula)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Zaten Mevcut");
        }

        [Fact]
        public void WhenValidInputsIsGiven_MovieActor_ShouldBeCreated()
        {
            //arrange(Hazırla)
            
            CreateMovieActorCommand command = new CreateMovieActorCommand(_dbcontext, _mapper);
            command.Model = new CreateMovieActorModel()
            {
                MovieId = 4,
                ActorId = 1

            };
            // act
            FluentActions.Invoking(()=>command.Handle()).Invoke();

            // assert 
            var MovieActor = _dbcontext.MovieActors.FirstOrDefault(x=>x.MovieId == command.Model.MovieId && x.ActorId == command.Model.ActorId);
            MovieActor.Should().NotBeNull();
            MovieActor.MovieId.Should().Be(command.Model.MovieId);
            MovieActor.ActorId.Should().Be(command.Model.ActorId);
        }
    }
}
