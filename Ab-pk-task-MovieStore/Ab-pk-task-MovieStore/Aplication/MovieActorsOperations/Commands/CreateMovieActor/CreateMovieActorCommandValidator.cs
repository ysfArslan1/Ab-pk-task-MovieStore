
using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.MovieActorsOperations.Commands.CreateMovieActor
{
    // CreateStudentCommant sınıfın için oluşturulan validation sınıfı.
    public class CreateMovieActorCommandValidator : AbstractValidator<CreateMovieActorModel>
    {
        public CreateMovieActorCommandValidator()
        {
            RuleFor(x => x.MovieId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.ActorId).NotEmpty().GreaterThan(0);
        }

    }
}
