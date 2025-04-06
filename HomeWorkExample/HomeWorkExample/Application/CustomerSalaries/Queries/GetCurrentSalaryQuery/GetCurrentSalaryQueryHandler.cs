using HomeWorkExample.Exceptions;
using HomeWorkExample.Interfaces;
using MediatR;

namespace HomeWorkExample.Application.CustomerSalaries.Queries.GetCurrentSalaryQuery;

public class GetCurrentSalaryQueryHandler : IRequestHandler<GetCurrentSalaryQueryRequest, GetCurrentSalaryQueryResponse>
{
    private readonly ISalaryRepository _salaryRepository;

    public GetCurrentSalaryQueryHandler(ISalaryRepository salaryRepository)
    {
        _salaryRepository = salaryRepository;
    }

    public async Task<GetCurrentSalaryQueryResponse> Handle(GetCurrentSalaryQueryRequest request,
        CancellationToken cancellationToken)
    {
        var salary = await _salaryRepository.GetCustomerSalary(request.CustomerId);

        if (salary == null)
        {
            throw new NotFoundException($"Пользователь {request.CustomerId} не найден");
        }
        
        return new GetCurrentSalaryQueryResponse(salary);
    }
}