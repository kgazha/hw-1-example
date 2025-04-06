using HomeWorkExample.Exceptions;
using HomeWorkExample.Interfaces;

namespace HomeWorkExample.Services;

public class Calculator : ICalculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        return a - b;
    }

    public int Multiply(int a, int b)
    {
        return a * b;
    }

    public int Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new OperationException("Деление на 0");
        }
        
        return a / b;
    }
}