using Ab_pk_task_MovieStore.Aplication.GenresOperations.Queries.GetGenreDetail;
using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.DirectorsOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQueryValidator : AbstractValidator<GetDirectorDetailQuery>
    {
        public GetDirectorDetailQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }

    }
}
