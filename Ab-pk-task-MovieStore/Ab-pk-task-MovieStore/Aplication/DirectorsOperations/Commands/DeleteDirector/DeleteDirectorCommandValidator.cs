using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.DirectorsOperations.Commands.DeleteDirector
{
    // DeleteStudentCommand sınıfın için oluşturulan validation sınıfı.
    public class DeleteDirectorCommandValidator : AbstractValidator<DeleteDirectorCommand>
    {
        public DeleteDirectorCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }
    }
}

