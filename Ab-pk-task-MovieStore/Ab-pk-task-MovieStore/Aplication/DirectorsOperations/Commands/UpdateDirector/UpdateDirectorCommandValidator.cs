using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.DirectorsOperations.Commands.UpdateDirector
{
    // UpdateStudentCommand sınıfın için oluşturulan validation sınıfı.
    public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommand>
    {

        public UpdateDirectorCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Model.Surname).NotEmpty().MaximumLength(100);
        }
    }

}
