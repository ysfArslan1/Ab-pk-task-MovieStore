using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.OrdersOperations.Commands.UpdateOrder
{
    // UpdateStudentCommand sınıfın için oluşturulan validation sınıfı.
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {

        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Model.MovieId).NotEmpty().GreaterThan(0);
        }
    }

}
