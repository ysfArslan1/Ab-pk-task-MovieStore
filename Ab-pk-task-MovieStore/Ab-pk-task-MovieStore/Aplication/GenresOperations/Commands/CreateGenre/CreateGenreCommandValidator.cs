
using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.GenresOperations.Commands.CreateGenre
{
    // CreateStudentCommant sınıfın için oluşturulan validation sınıfı.
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreModel>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        }

    }
}
