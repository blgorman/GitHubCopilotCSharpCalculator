using ConsoleHelpers;

namespace ServiceLayer;

public class CalculatorOperations
{
    private readonly Calculator _calculator;

    public CalculatorOperations()
    {
        _calculator = new Calculator();
    }

    public void AddNumbers()
    {
        Console.WriteLine(OutputHelpers.BoxedMessage("Add Numbers", '*', 40));
        
        double num1 = InputHelpers.GetInputAsDouble("Enter the first number:");
        double num2 = InputHelpers.GetInputAsDouble("Enter the second number:");
        
        double result = _calculator.Add(num1, num2);
        
        Console.WriteLine(OutputHelpers.BoxedMessage($"{num1} + {num2} = {result}", '*', 40));
    }

    public void SubtractNumbers()
    {
        Console.WriteLine(OutputHelpers.BoxedMessage("Subtract Numbers", '*', 40));
        
        double num1 = InputHelpers.GetInputAsDouble("Enter the first number:");
        double num2 = InputHelpers.GetInputAsDouble("Enter the second number:");
        
        double result = _calculator.Subtract(num1, num2);
        
        Console.WriteLine(OutputHelpers.BoxedMessage($"{num1} - {num2} = {result}", '*', 40));
    }

    public void MultiplyNumbers()
    {
        Console.WriteLine(OutputHelpers.BoxedMessage("Multiply Numbers", '*', 40));
        
        double num1 = InputHelpers.GetInputAsDouble("Enter the first number:");
        double num2 = InputHelpers.GetInputAsDouble("Enter the second number:");
        
        double result = _calculator.Multiply(num1, num2);
        
        Console.WriteLine(OutputHelpers.BoxedMessage($"{num1} × {num2} = {result}", '*', 40));
    }

    public void DivideNumbers()
    {
        Console.WriteLine(OutputHelpers.BoxedMessage("Divide Numbers", '*', 40));
        
        double num1 = InputHelpers.GetInputAsDouble("Enter the first number (dividend):");
        double num2 = InputHelpers.GetInputAsDouble("Enter the second number (divisor):");
        
        try
        {
            double result = _calculator.Divide(num1, num2);
            Console.WriteLine(OutputHelpers.BoxedMessage($"{num1} ÷ {num2} = {result}", '*', 40));
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine(OutputHelpers.BoxedMessage($"Error: {ex.Message}", '*', 40));
        }
    }
}