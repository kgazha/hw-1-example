namespace HomeWorkExample.Interfaces;

public interface ICalculator
{
    public decimal Add(decimal a, decimal b);
    public decimal Subtract(decimal a, decimal b);
    public decimal Multiply(decimal a, decimal b);
    public decimal Multiply(decimal a, double b);
    public double Multiply(double a, double b);
    public decimal Divide(decimal a, decimal b);
}