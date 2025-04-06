using HomeWorkExample.Models;
using MediatR;

namespace HomeWorkExample.Application.CustomerSalaries.Commands.UpdateSalaryCommand;

public sealed record UpdateSalaryCommandRequest(CustomerSalary Salary) : IRequest;