
using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.OrdersOperations.Commands.CreateOrder
{
    // CreateStudentCommant sınıfın için oluşturulan validation sınıfı.
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderModel>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.MovieId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.CustemerId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Prize).NotEmpty().GreaterThan(0);
        }

    }
}
