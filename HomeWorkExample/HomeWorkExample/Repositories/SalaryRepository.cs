using HomeWorkExample.Exceptions;
using HomeWorkExample.Interfaces;
using HomeWorkExample.Models;

namespace HomeWorkExample.Repositories;

public class SalaryRepository : ISalaryRepository
{
    private readonly Dictionary<long, CustomerSalary> _salaries = new()
    {
        {
            1, new CustomerSalary
            {
                Id = 345,
                BasicSalary = 26700,
                CustomerId = 1,
                Rate = 2.3
            }
        },
        {
            2, new CustomerSalary
            {
                Id = 346,
                BasicSalary = 26700,
                CustomerId = 2,
                Rate = 3
            }
        },
        {
            3, new CustomerSalary
            {
                Id = 347,
                BasicSalary = 30156.32m,
                CustomerId = 3,
                Rate = 7
            }
        }
    };

    public async Task<CustomerSalary?> GetCustomerSalary(long customerId, CancellationToken cancellationToken)
    {
        _salaries.TryGetValue(customerId, out var customerSalary);

        await Task.Yield();

        return customerSalary;
    }

    public async Task AddCustomerSalary(CustomerSalary salary, CancellationToken cancellationToken)
    {
        await Task.Delay(15, cancellationToken);

        if (!_salaries.TryAdd(salary.CustomerId, salary))
        {
            throw new SqlException($"Пользователь {salary.CustomerId} уже существует в базе данных!");
        }
    }

    public Task UpdateCustomerBaseSalary(CustomerSalary salary, CancellationToken cancellationToken)
    {
        if (!_salaries.ContainsKey(salary.CustomerId))
        {
            throw new SqlException($"Пользователь {salary.CustomerId} не найден");
        }

        _salaries[salary.CustomerId] = salary;

        return Task.CompletedTask;
    }
}