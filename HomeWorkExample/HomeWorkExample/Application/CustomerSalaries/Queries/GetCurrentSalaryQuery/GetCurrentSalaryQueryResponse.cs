using HomeWorkExample.Models;

namespace HomeWorkExample.Application.CustomerSalaries.Queries.GetCurrentSalaryQuery;

public sealed record GetCurrentSalaryQueryResponse(CustomerSalary Salary);