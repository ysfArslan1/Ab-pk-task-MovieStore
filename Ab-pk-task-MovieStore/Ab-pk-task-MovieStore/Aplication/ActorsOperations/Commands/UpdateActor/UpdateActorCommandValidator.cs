using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.ActorsOperations.Commands.UpdateActor
{
    // UpdateStudentCommand sınıfın için oluşturulan validation sınıfı.
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
    {

        public UpdateActorCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Model.Surname).NotEmpty().MaximumLength(100);
        }
    }

}
