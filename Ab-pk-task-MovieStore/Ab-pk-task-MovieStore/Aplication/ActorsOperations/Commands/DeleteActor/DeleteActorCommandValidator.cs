using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.ActorsOperations.Commands.DeleteActor
{
    // DeleteStudentCommand sınıfın için oluşturulan validation sınıfı.
    public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>
    {
        public DeleteActorCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }
    }
}

