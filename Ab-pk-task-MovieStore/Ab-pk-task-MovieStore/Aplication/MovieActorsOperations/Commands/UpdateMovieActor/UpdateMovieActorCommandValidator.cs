using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.MovieActorsOperations.Commands.UpdateMovieActor
{
    // UpdateStudentCommand sınıfın için oluşturulan validation sınıfı.
    public class UpdateMovieActorCommandValidator : AbstractValidator<UpdateMovieActorCommand>
    {

        public UpdateMovieActorCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.MovieId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.ActorId).NotEmpty().GreaterThan(0);
        }
    }

}
