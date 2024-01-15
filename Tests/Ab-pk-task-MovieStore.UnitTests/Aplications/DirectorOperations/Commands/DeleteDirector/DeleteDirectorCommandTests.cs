using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.DirectorsOperations.Commands.DeleteDirector;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommandTests:IClassFixture<CommonTextFicture>
    {

        private readonly PatikaDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteDirectorCommandTests(CommonTextFicture textFicture)
        {
            _dbContext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        [Fact]
        public void WhenExistingDirectorIdIsGiven_DirectorShouldBeDeleted()
        {
            // Arrange
            Director Director = new Director()
            {
                Name = "ToDeleteDirector",
                Surname = "ToDeleteDirector",
            };

            _dbContext.Directors.Add(Director);
            _dbContext.SaveChanges();

            DeleteDirectorCommand deleteCommand = new DeleteDirectorCommand(_dbContext);
            deleteCommand.Id = Director.Id;

            // Act
            FluentActions.Invoking(() => deleteCommand.Handle()).Invoke();

            // Assert
            var deletedDirector = _dbContext.Directors.FirstOrDefault(x => x.Id == Director.Id);
            deletedDirector.Should().BeNull();
        }
        [Fact]
        public void WhenNonExistingDirectorIdIsGiven_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            int nonExistingDirectorId = -1; // Assuming -1 is not a valid Director Id

            DeleteDirectorCommand deleteCommand = new DeleteDirectorCommand(_dbContext);
            deleteCommand.Id = nonExistingDirectorId;

            // Act & Assert
            FluentActions.Invoking(() => deleteCommand.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Director Bulunamadı");
        }

     
    }
}
