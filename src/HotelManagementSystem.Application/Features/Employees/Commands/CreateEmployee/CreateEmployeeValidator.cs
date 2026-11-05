using FluentValidation;

namespace HotelManagementSystem.Application.Features.Employees.Commands.CreateEmployee;

public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeValidator()
    {
        RuleFor(x => x.PersonId)
            .GreaterThan(0);

        RuleFor(x => x.DepartmentId)
            .GreaterThan(0);

        RuleFor(x => x.HireDate)
            .NotEmpty()
            ;

        RuleFor(x => x.JobTitle)
            .NotEmpty()
            .MaximumLength(100);
    }
}