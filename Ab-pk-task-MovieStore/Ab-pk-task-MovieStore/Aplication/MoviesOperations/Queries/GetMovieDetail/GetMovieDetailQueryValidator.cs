using Ab_pk_task_MovieStore.Aplication.GenresOperations.Queries.GetGenreDetail;
using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.MoviesOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQueryValidator : AbstractValidator<GetMovieDetailQuery>
    {
        public GetMovieDetailQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }

    }
}
