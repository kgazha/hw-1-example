using HomeWorkExample.Application.CustomerSalaries.Commands.UpdateSalaryCommand;
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
        [FromBody] UpdateSalaryCommandRequest request)
        => await Mediator!.Send(request);
}