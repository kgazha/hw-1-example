using HomeWorkExample.Models;

namespace HomeWorkExample.Interfaces;

public interface ISalaryRepository
{
    public Task<CustomerSalary?> GetCustomerSalary(long customerId, CancellationToken cancellationToken);
    public Task AddCustomerSalary(CustomerSalary salary, CancellationToken cancellationToken);
    public Task UpdateCustomerBaseSalary(CustomerSalary salary, CancellationToken cancellationToken);
}