using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.GenresOperations.Commands.UpdateGenre
{
    // UpdateStudentCommand sınıfın için oluşturulan validation sınıfı.
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {

        public UpdateGenreCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MaximumLength(50);
        }
    }

}
