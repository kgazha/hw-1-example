using HomeWorkExample.Application.CustomerSalaries.Commands.UpdateBaseSalaryCommand;
using HomeWorkExample.Application.CustomerSalaries.Queries.GetCurrentSalaryQuery;
using Microsoft.AspNetCore.Mvc;

namespace HomeWorkExample.Controllers;

public class CustomerSalaryController : ApiController
{
    [HttpGet]
    public async Task<GetCurrentSalaryQueryResponse> GetCustomerSalary(
        GetCurrentSalaryQueryRequest request)
        => await Mediator!.Send(request);

    [HttpPost]
    public async Task UpdateSalary(
        [FromBody] UpdateBaseSalaryCommandRequest request)
        => await Mediator!.Send(request);
}