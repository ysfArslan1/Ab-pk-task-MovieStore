using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.MovieActorsOperations.Commands.DeleteMovieActor
{
    // DeleteStudentCommand sınıfın için oluşturulan validation sınıfı.
    public class DeleteMovieActorCommandValidator : AbstractValidator<DeleteMovieActorCommand>
    {
        public DeleteMovieActorCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }
    }
}

