using FluentValidation;

namespace Ab_pk_task_MovieStore.Aplication.CustomersOperations.Commands.UpdateCustomer
{
    // UpdateStudentCommand sınıfın için oluşturulan validation sınıfı.
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {

        public UpdateCustomerCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Model.Surname).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Model.Email).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Model.Password).NotEmpty().MaximumLength(100);
        }
    }

}
