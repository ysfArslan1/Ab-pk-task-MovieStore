using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.MoviesOperations.Commands.DeleteMovie
{
    // DeleteStudentCommand sınıfın için oluşturulan validation sınıfı.
    public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }
    }
}

