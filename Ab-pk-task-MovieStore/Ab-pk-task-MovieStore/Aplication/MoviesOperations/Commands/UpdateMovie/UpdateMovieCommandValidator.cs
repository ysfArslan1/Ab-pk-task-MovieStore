using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.MoviesOperations.Commands.UpdateMovie
{
    // UpdateStudentCommand sınıfın için oluşturulan validation sınıfı.
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {

        public UpdateMovieCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Model.ReleaseDate).LessThan(DateTime.Now);
            RuleFor(x => x.Model.Prize).NotNull().GreaterThan(0);
            RuleFor(x => x.Model.Title).NotNull().MaximumLength(100);
            RuleFor(x => x.Model.DirectorId).NotNull().GreaterThan(0);
            RuleFor(x => x.Model.GenreId).NotNull().GreaterThan(0);
        }
    }

}
