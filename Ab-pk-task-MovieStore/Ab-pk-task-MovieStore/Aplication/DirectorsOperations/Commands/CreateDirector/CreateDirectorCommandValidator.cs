
using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.DirectorsOperations.Commands.CreateDirector
{
    // CreateStudentCommant sınıfın için oluşturulan validation sınıfı.
    public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorModel>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(50);
        }

    }
}
