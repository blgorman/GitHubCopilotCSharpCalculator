namespace ServiceLayer;

/// <summary>
/// Core calculator class containing basic mathematical operations
/// </summary>
public class Calculator
{
    /// <summary>
    /// Adds two numbers together
    /// </summary>
    /// <param name="a">First number</param>
    /// <param name="b">Second number</param>
    /// <returns>Sum of a and b</returns>
    public double Add(double a, double b)
    {
        return a + b;
    }

    /// <summary>
    /// Subtracts the second number from the first
    /// </summary>
    /// <param name="a">First number</param>
    /// <param name="b">Second number</param>
    /// <returns>Difference of a and b</returns>
    public double Subtract(double a, double b)
    {
        return a - b;
    }

    /// <summary>
    /// Multiplies two numbers together
    /// </summary>
    /// <param name="a">First number</param>
    /// <param name="b">Second number</param>
    /// <returns>Product of a and b</returns>
    public double Multiply(double a, double b)
    {
        return a * b;
    }

    /// <summary>
    /// Divides the first number by the second
    /// </summary>
    /// <param name="a">Dividend</param>
    /// <param name="b">Divisor</param>
    /// <returns>Quotient of a and b</returns>
    /// <exception cref="DivideByZeroException">Thrown when b is zero</exception>
    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero");
        }
        return a / b;
    }
}
