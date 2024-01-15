using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.OrdersOperations.Commands.DeleteOrder
{
    // DeleteStudentCommand sınıfın için oluşturulan validation sınıfı.
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }
    }
}

