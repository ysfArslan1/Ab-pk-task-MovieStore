using Ab_pk_task_MovieStore.Aplication.GenresOperations.Queries.GetGenreDetail;
using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.OrdersOperations.Queries.GetOrderDetail
{
    public class GetOrderDetailQueryValidator : AbstractValidator<GetOrderDetailQuery>
    {
        public GetOrderDetailQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }

    }
}
