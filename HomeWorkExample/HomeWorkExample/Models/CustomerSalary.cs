namespace HomeWorkExample.Models;

public class CustomerSalary
{
    public long Id { get; set; }
    public long CustomerId { get; set; }
    public decimal BasicSalary { get; set; }
    public double Rate { get; set; }
}