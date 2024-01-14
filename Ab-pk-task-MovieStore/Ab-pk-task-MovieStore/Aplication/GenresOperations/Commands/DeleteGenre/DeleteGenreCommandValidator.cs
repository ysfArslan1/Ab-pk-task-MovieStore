using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.GenresOperations.Commands.DeleteGenre
{
    // DeleteStudentCommand sınıfın için oluşturulan validation sınıfı.
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }
    }
}

