namespace NoBeard.Learn.AspNet.MvcApp.Test;

public class Calculator
{
    public double CalculateTax(double amount, double tax)
    {
        if (amount < 0)
            throw new ArgumentException("Negative numbers are not allowed.");

        return Math.Round(amount + amount * tax/100, 2); 
    }

    public double CalculateVat(double amount) 
    {
        return CalculateTax(amount, 25);
    }
}
