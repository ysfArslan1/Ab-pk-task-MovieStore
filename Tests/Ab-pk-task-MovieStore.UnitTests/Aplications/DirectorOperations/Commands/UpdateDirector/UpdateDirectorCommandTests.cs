using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.DirectorsOperations.Commands.UpdateDirector;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommandTests: IClassFixture<CommonTextFicture>
    {

        private readonly PatikaDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateDirectorCommandTests(CommonTextFicture textFicture)
        {
            _dbContext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        [Fact]
        public void WhenValidInputsAreGiven_DirectorShouldBeUpdated()
        {
            // Arrange
            Director existingDirector = new Director()
            {
                Name = "namehege34",
                Surname = "surname34ge"
            };

            _dbContext.Directors.Add(existingDirector);
            _dbContext.SaveChanges();

            UpdateDirectorCommand updateCommand = new UpdateDirectorCommand(_dbContext);
            var existingDirectors = _dbContext.Directors.ToList();

            updateCommand.Id = existingDirector.Id;
            updateCommand.Model = new UpdateDirectorModel()
            {
                Name = "name134566",
                Surname = "surname1"
            };

            // Act
            FluentActions.Invoking(() => updateCommand.Handle()).Invoke();

            // Assert
            var updatedDirector = _dbContext.Directors.Find(existingDirector.Id);
            updatedDirector.Should().NotBeNull();
            updatedDirector.Name.Should().Be(updateCommand.Model.Name);
            updatedDirector.Surname.Should().Be(updateCommand.Model.Surname);
        }

        [Fact]
        public void WhenNonExistingDirectorIdIsGiven_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            int nonExistingDirectorId = -1; // Assuming -1 is not a valid Director Id

            UpdateDirectorCommand updateCommand = new UpdateDirectorCommand(_dbContext);
            updateCommand.Id = nonExistingDirectorId;
            updateCommand.Model = new UpdateDirectorModel()
            {
                Name = "name",
                Surname = "surname",
            };

            // Act & Assert
            FluentActions.Invoking(() => updateCommand.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Director Bulunamadı");
        }
    }
}
