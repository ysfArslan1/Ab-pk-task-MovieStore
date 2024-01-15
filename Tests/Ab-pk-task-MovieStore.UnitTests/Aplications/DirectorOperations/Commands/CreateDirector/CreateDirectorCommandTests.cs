using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.DirectorsOperations.Commands.CreateDirector;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommandTests:IClassFixture<CommonTextFicture>
    {
        private readonly PatikaDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateDirectorCommandTests(CommonTextFicture textFicture)
        {
            _dbcontext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistDirectorNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange(Hazırla)
            Director Director = new Director()
            {
                Name = "name",
                Surname = "surname",
                
            };
            _dbcontext.Directors.Add(Director);
            _dbcontext.SaveChanges();

            CreateDirectorCommand command = new CreateDirectorCommand(_dbcontext, _mapper);
            command.Model = new CreateDirectorModel() { Name = Director.Name,Surname=Director.Surname};

            //act & assert (Çalıştır & Dogrula)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Zaten Mevcut");
        }

        [Fact]
        public void WhenValidInputsIsGiven_Director_ShouldBeCreated()
        {
            //arrange(Hazırla)
            
            CreateDirectorCommand command = new CreateDirectorCommand(_dbcontext, _mapper);
            command.Model = new CreateDirectorModel()
            {
                Name = "name12",
                Surname = "surname12",

            };
            // act
            FluentActions.Invoking(()=>command.Handle()).Invoke();

            // assert 
            var Director = _dbcontext.Directors.FirstOrDefault(x=>x.Name == command.Model.Name);
            Director.Should().NotBeNull();
            Director.Name.Should().Be(command.Model.Name);
            Director.Surname.Should().Be(command.Model.Surname);
        }
    }
}
