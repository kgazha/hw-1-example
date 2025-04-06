using HomeWorkExample.Exceptions;
using HomeWorkExample.Interfaces;
using MediatR;

namespace HomeWorkExample.Application.CustomerSalaries.Queries.GetCurrentSalaryQuery;

public class GetCurrentSalaryQueryHandler : IRequestHandler<GetCurrentSalaryQueryRequest, GetCurrentSalaryQueryResponse>
{
    private readonly ISalaryRepository _salaryRepository;
    private readonly ICalculator _calculator;

    public GetCurrentSalaryQueryHandler(ISalaryRepository salaryRepository, ICalculator calculator)
    {
        _salaryRepository = salaryRepository;
        _calculator = calculator;
    }

    public async Task<GetCurrentSalaryQueryResponse> Handle(GetCurrentSalaryQueryRequest request,
        CancellationToken cancellationToken)
    {
        var salary = await _salaryRepository.GetCustomerSalary(request.CustomerId, cancellationToken);

        if (salary == null)
        {
            throw new NotFoundException($"Пользователь {request.CustomerId} не найден");
        }

        var realSalary = _calculator.Multiply(salary.BasicSalary, salary.Rate);

        return new GetCurrentSalaryQueryResponse(realSalary);
    }
}