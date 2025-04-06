using MediatR;

namespace HomeWorkExample.Application.CustomerSalaries.Queries.GetCurrentSalaryQuery;

public sealed record GetCurrentSalaryQueryRequest(long CustomerId) : IRequest<GetCurrentSalaryQueryResponse>;