using MediatR;

namespace HomeWorkExample.Application.CustomerSalaries.Commands.UpdateBaseSalaryCommand;

public sealed record UpdateBaseSalaryCommandRequest(long CustomerId, decimal BaseSalary) : IRequest;