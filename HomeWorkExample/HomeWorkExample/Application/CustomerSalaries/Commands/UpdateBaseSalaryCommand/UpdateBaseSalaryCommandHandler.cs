using HomeWorkExample.Exceptions;
using HomeWorkExample.Interfaces;
using MediatR;

namespace HomeWorkExample.Application.CustomerSalaries.Commands.UpdateBaseSalaryCommand;

public class UpdateBaseSalaryCommandHandler : IRequestHandler<UpdateBaseSalaryCommandRequest>
{
    private readonly ISalaryRepository _salaryRepository;

    public UpdateBaseSalaryCommandHandler(ISalaryRepository salaryRepository)
    {
        _salaryRepository = salaryRepository;
    }

    public async Task Handle(UpdateBaseSalaryCommandRequest request, CancellationToken cancellationToken)
    {
        var salary = await _salaryRepository.GetCustomerSalary(request.CustomerId, cancellationToken);

        if (salary == null)
        {
            throw new NotFoundException($"Пользователь {request.CustomerId} не найден");
        }

        salary.BasicSalary = request.BaseSalary;

        await _salaryRepository.UpdateCustomerBaseSalary(salary, cancellationToken);
    }
}