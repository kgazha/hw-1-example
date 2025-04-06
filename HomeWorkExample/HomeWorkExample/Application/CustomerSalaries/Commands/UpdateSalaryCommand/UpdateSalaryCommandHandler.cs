using HomeWorkExample.Interfaces;
using MediatR;

namespace HomeWorkExample.Application.CustomerSalaries.Commands.UpdateSalaryCommand;

public class UpdateSalaryCommandHandler : IRequestHandler<UpdateSalaryCommandRequest>
{
    private readonly ISalaryRepository _salaryRepository;

    public UpdateSalaryCommandHandler(ISalaryRepository salaryRepository)
    {
        _salaryRepository = salaryRepository;
    }

    public async Task Handle(UpdateSalaryCommandRequest request, CancellationToken cancellationToken)
    {
        await _salaryRepository.UpdateCustomerSalary(request.Salary);
    }
}