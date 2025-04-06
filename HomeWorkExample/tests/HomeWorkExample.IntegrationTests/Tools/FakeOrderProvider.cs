using HomeWorkExample.Interfaces;

namespace HomeWorkExample.IntegrationTests.Tools;

public class FakeCalculator : ICalculator
{
    public decimal Add(decimal a, decimal b)
    {
        throw new NotImplementedException();
    }

    public decimal Subtract(decimal a, decimal b)
    {
        throw new NotImplementedException();
    }

    public decimal Multiply(decimal a, decimal b)
    {
        throw new NotImplementedException();
    }

    public decimal Multiply(decimal a, double b)
    {
        throw new NotImplementedException();
    }

    public double Multiply(double a, double b)
    {
        throw new NotImplementedException();
    }

    public decimal Divide(decimal a, decimal b)
    {
        throw new NotImplementedException();
    }
}