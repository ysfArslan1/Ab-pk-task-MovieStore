using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.ActorsOperations.Commands.CreateActor;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandTests:IClassFixture<CommonTextFicture>
    {
        private readonly PatikaDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateActorCommandTests(CommonTextFicture textFicture)
        {
            _dbcontext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistActorNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange(Hazırla)
            Actor Actor = new Actor()
            {
                Name = "name",
                Surname = "surname",
                
            };
            _dbcontext.Actors.Add(Actor);
            _dbcontext.SaveChanges();

            CreateActorCommand command = new CreateActorCommand(_dbcontext, _mapper);
            command.Model = new CreateActorModel() { Name = Actor.Name,Surname=Actor.Surname};

            //act & assert (Çalıştır & Dogrula)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Zaten Mevcut");
        }

        [Fact]
        public void WhenValidInputsIsGiven_Actor_ShouldBeCreated()
        {
            //arrange(Hazırla)
            
            CreateActorCommand command = new CreateActorCommand(_dbcontext, _mapper);
            command.Model = new CreateActorModel()
            {
                Name = "name12",
                Surname = "surname12",

            };
            // act
            FluentActions.Invoking(()=>command.Handle()).Invoke();

            // assert 
            var Actor = _dbcontext.Actors.FirstOrDefault(x=>x.Name == command.Model.Name);
            Actor.Should().NotBeNull();
            Actor.Name.Should().Be(command.Model.Name);
            Actor.Surname.Should().Be(command.Model.Surname);
        }
    }
}
