using ConsoleHelpers;

namespace ServiceLayer;

public class CalculatorOperations
{
    /// <summary>
    /// Adds two numbers together
    /// </summary>
    /// <param name="a">First number</param>
    /// <param name="b">Second number</param>
    /// <returns>The sum of a and b</returns>
    public double Add(double a, double b)
    {
        return a + b;
    }

    /// <summary>
    /// Subtracts the second number from the first
    /// </summary>
    /// <param name="a">First number</param>
    /// <param name="b">Second number to subtract</param>
    /// <returns>The difference of a minus b</returns>
    public double Subtract(double a, double b)
    {
        return a - b;
    }

    /// <summary>
    /// Multiplies two numbers together
    /// </summary>
    /// <param name="a">First number</param>
    /// <param name="b">Second number</param>
    /// <returns>The product of a and b</returns>
    public double Multiply(double a, double b)
    {
        return a * b;
    }

    /// <summary>
    /// Divides the first number by the second
    /// </summary>
    /// <param name="a">Dividend</param>
    /// <param name="b">Divisor</param>
    /// <returns>The quotient of a divided by b</returns>
    /// <exception cref="DivideByZeroException">Thrown when b is zero</exception>
    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }
        return a / b;
    }

    /// <summary>
    /// Prompts user for two numbers and performs addition
    /// </summary>
    public void AddNumbers()
    {
        Console.WriteLine(OutputHelpers.BoxedMessage("Add Numbers", '*', 40));
        double a = InputHelpers.GetInputAsDouble("Enter the first number:");
        double b = InputHelpers.GetInputAsDouble("Enter the second number:");
        double result = Add(a, b);
        Console.WriteLine(OutputHelpers.BoxedMessage($"{a} + {b} = {result}", '=', 40));
    }

    /// <summary>
    /// Prompts user for two numbers and performs subtraction
    /// </summary>
    public void SubtractNumbers()
    {
        Console.WriteLine(OutputHelpers.BoxedMessage("Subtract Numbers", '*', 40));
        double a = InputHelpers.GetInputAsDouble("Enter the first number:");
        double b = InputHelpers.GetInputAsDouble("Enter the second number:");
        double result = Subtract(a, b);
        Console.WriteLine(OutputHelpers.BoxedMessage($"{a} - {b} = {result}", '=', 40));
    }

    /// <summary>
    /// Prompts user for two numbers and performs multiplication
    /// </summary>
    public void MultiplyNumbers()
    {
        Console.WriteLine(OutputHelpers.BoxedMessage("Multiply Numbers", '*', 40));
        double a = InputHelpers.GetInputAsDouble("Enter the first number:");
        double b = InputHelpers.GetInputAsDouble("Enter the second number:");
        double result = Multiply(a, b);
        Console.WriteLine(OutputHelpers.BoxedMessage($"{a} * {b} = {result}", '=', 40));
    }

    /// <summary>
    /// Prompts user for two numbers and performs division
    /// </summary>
    public void DivideNumbers()
    {
        Console.WriteLine(OutputHelpers.BoxedMessage("Divide Numbers", '*', 40));
        double a = InputHelpers.GetInputAsDouble("Enter the dividend (number to be divided):");
        double b = InputHelpers.GetInputAsDouble("Enter the divisor (number to divide by):");
        
        try
        {
            double result = Divide(a, b);
            Console.WriteLine(OutputHelpers.BoxedMessage($"{a} / {b} = {result}", '=', 40));
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine(OutputHelpers.BoxedMessage($"Error: {ex.Message}", '!', 40));
        }
    }
}