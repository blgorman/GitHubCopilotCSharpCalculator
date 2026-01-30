namespace ConsoleAppProject.BusinessLogic;

/// <summary>
/// Pure business logic class for mathematical operations.
/// Contains no I/O dependencies - fully testable.
/// </summary>
public class Calculator
{
    /// <summary>
    /// Adds two numbers together
    /// </summary>
    /// <param name="firstNumber">The first number to add</param>
    /// <param name="secondNumber">The second number to add</param>
    /// <returns>The sum of the two numbers</returns>
    public double Add(double firstNumber, double secondNumber)
    {
        return firstNumber + secondNumber;
    }

    /// <summary>
    /// Subtracts the second number from the first number
    /// </summary>
    /// <param name="firstNumber">The number to subtract from</param>
    /// <param name="secondNumber">The number to subtract</param>
    /// <returns>The difference between the two numbers</returns>
    public double Subtract(double firstNumber, double secondNumber)
    {
        return firstNumber - secondNumber;
    }

    /// <summary>
    /// Multiplies two numbers together
    /// </summary>
    /// <param name="firstNumber">The first number to multiply</param>
    /// <param name="secondNumber">The second number to multiply</param>
    /// <returns>The product of the two numbers</returns>
    public double Multiply(double firstNumber, double secondNumber)
    {
        return firstNumber * secondNumber;
    }

    /// <summary>
    /// Divides the first number by the second number
    /// </summary>
    /// <param name="firstNumber">The dividend</param>
    /// <param name="secondNumber">The divisor</param>
    /// <returns>The quotient of the division</returns>
    /// <exception cref="DivideByZeroException">Thrown when attempting to divide by zero</exception>
    public double Divide(double firstNumber, double secondNumber)
    {
        if (secondNumber == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero");
        }
        
        return firstNumber / secondNumber;
    }
}
