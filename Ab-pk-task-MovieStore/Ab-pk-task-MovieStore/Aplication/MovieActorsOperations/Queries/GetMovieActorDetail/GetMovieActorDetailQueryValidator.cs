using Ab_pk_task_MovieStore.Aplication.GenresOperations.Queries.GetGenreDetail;
using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.MovieActorsOperations.Queries.GetMovieActorDetail
{
    public class GetMovieActorDetailQueryValidator : AbstractValidator<GetMovieActorDetailQuery>
    {
        public GetMovieActorDetailQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }

    }
}
