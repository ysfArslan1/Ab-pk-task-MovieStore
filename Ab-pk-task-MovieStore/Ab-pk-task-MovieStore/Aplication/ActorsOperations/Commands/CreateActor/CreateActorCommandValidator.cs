
using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.ActorsOperations.Commands.CreateActor
{
    // CreateStudentCommant sınıfın için oluşturulan validation sınıfı.
    public class CreateActorCommandValidator : AbstractValidator<CreateActorModel>
    {
        public CreateActorCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(50);
        }

    }
}
