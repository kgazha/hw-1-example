using HomeWorkExample.Exceptions;
using HomeWorkExample.Interfaces;

namespace HomeWorkExample.Services;

public class Calculator : ICalculator
{
    public decimal Add(decimal a, decimal b)
    {
        return a + b;
    }

    public decimal Subtract(decimal a, decimal b)
    {
        return a - b;
    }

    public decimal Multiply(decimal a, decimal b)
    {
        return a * b;
    }
    
    public decimal Multiply(decimal a, double b)
    {
        return a * (decimal)b;
    }

    public double Multiply(double a, double b)
    {
        return a * b;
    }

    public decimal Divide(decimal a, decimal b)
    {
        if (b == 0)
        {
            throw new OperationException("Деление на 0");
        }
        
        return a / b;
    }
}