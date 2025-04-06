using HomeWorkExample.Models;

namespace HomeWorkExample.Interfaces;

public interface ISalaryRepository
{
    public Task<CustomerSalary?> GetCustomerSalary(long customerId);
    public Task AddCustomerSalary(CustomerSalary salary);
    public Task UpdateCustomerSalary(CustomerSalary salary);
}