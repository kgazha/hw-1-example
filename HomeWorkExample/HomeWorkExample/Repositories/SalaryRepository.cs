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
                Salary = 100000,
                CustomerId = 1
            }
        },
        {
            2, new CustomerSalary
            {
                Id = 346,
                Salary = 300000,
                CustomerId = 2
            }
        },
        {
            3, new CustomerSalary
            {
                Id = 347,
                Salary = 5000000,
                CustomerId = 3
            }
        }
    };

    public async Task<CustomerSalary?> GetCustomerSalary(long customerId)
    {
        _salaries.TryGetValue(customerId, out var customerSalary);

        await Task.Yield();

        return customerSalary;
    }

    public async Task AddCustomerSalary(CustomerSalary salary)
    {
        await Task.Delay(15);

        if (_salaries.ContainsKey(salary.CustomerId))
        {
            throw new SqlException($"Пользователь {salary.CustomerId} уже существует в базе данных!");
        }

        _salaries.Add(salary.Id, salary);
    }

    public Task UpdateCustomerSalary(CustomerSalary salary)
    {
        if (!_salaries.ContainsKey(salary.CustomerId))
        {
            throw new SqlException($"Пользователь {salary.CustomerId} не найден");
        }

        _salaries[salary.CustomerId] = salary;

        return Task.CompletedTask;
    }
}