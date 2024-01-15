
using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.MoviesOperations.Commands.CreateMovie
{
    // CreateStudentCommant sınıfın için oluşturulan validation sınıfı.
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieModel>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.ReleaseDate).NotEmpty().LessThan(DateTime.Now);
            RuleFor(x => x.GenreId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.DirectorId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Prize).NotEmpty().GreaterThan(0);
        }

    }
}
