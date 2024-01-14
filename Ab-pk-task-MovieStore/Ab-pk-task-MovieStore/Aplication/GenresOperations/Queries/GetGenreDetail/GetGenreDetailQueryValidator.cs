using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.GenresOperations.Queries.GetGenreDetail
{
    // GetStudentDetailQuery sınıfın için oluşturulan validation sınıfı.
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
    {

        public GetGenreDetailQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }

    }

}
