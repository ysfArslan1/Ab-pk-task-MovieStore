using Ab_pk_task_MovieStore.Aplication.GenresOperations.Queries.GetGenreDetail;
using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.ActorsOperations.Queries.GetActorDetail
{
    public class GetActorDetailQueryValidator : AbstractValidator<GetActorDetailQuery>
    {
        public GetActorDetailQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }

    }
}
