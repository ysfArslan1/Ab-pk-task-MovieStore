
using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.CustomersOperations.Commands.CreateCustomer
{
    // CreateStudentCommant sınıfın için oluşturulan validation sınıfı.
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerModel>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Email).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Password).NotEmpty().MaximumLength(50);
        }

    }
}
