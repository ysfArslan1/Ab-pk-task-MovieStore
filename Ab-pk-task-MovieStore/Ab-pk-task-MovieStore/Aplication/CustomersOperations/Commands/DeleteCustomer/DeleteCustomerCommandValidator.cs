using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.CustomersOperations.Commands.DeleteCustomer
{
    // DeleteStudentCommand sınıfın için oluşturulan validation sınıfı.
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }
    }
}

