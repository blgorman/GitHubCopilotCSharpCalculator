using ConsoleHelpers;
using ConsoleAppProject.BusinessLogic;

namespace ServiceLayer;

/// <summary>
/// Service layer for calculator operations.
/// Coordinates user I/O and business logic execution.
/// Uses InputHelpers for input, Calculator for logic, OutputHelpers for display.
/// </summary>
public class CalculatorOperations
{
    private readonly Calculator _calculator;

    public CalculatorOperations()
    {
        _calculator = new Calculator();
    }

    /// <summary>
    /// Add two numbers together
    /// </summary>
    public void AddNumbers()
    {
        double firstNumber = InputHelpers.GetInputAsDouble("Enter the first number:", confirm: false);
        double secondNumber = InputHelpers.GetInputAsDouble("Enter the second number:", confirm: false);
        
        double result = _calculator.Add(firstNumber, secondNumber);
        
        string title = $"Add {firstNumber} + {secondNumber}";
        string message = $"Result: {result}";
        Console.WriteLine(OutputHelpers.BoxedMessageWithTitle(title, message, 40));
    }

    /// <summary>
    /// Subtract two numbers
    /// </summary>
    public void SubtractNumbers()
    {
        double firstNumber = InputHelpers.GetInputAsDouble("Enter the first number:", confirm: false);
        double secondNumber = InputHelpers.GetInputAsDouble("Enter the second number:", confirm: false);
        
        double result = _calculator.Subtract(firstNumber, secondNumber);
        
        string title = $"Subtract {firstNumber} - {secondNumber}";
        string message = $"Result: {result}";
        Console.WriteLine(OutputHelpers.BoxedMessageWithTitle(title, message, 40));
    }

    /// <summary>
    /// Multiply two numbers together
    /// </summary>
    public void MultiplyNumbers()
    {
        double firstNumber = InputHelpers.GetInputAsDouble("Enter the first number:", confirm: false);
        double secondNumber = InputHelpers.GetInputAsDouble("Enter the second number:", confirm: false);
        
        double result = _calculator.Multiply(firstNumber, secondNumber);
        
        string title = $"Multiply {firstNumber} * {secondNumber}";
        string message = $"Result: {result}";
        Console.WriteLine(OutputHelpers.BoxedMessageWithTitle(title, message, 40));
    }

    /// <summary>
    /// Divide two numbers
    /// </summary>
    public void DivideNumbers()
    {
        double firstNumber = InputHelpers.GetInputAsDouble("Enter the first number (dividend):", confirm: false);
        double secondNumber = InputHelpers.GetInputAsDouble("Enter the second number (divisor):", confirm: false);
        
        try
        {
            double result = _calculator.Divide(firstNumber, secondNumber);
            
            string title = $"Divide {firstNumber} / {secondNumber}";
            string message = $"Result: {result}";
            Console.WriteLine(OutputHelpers.BoxedMessageWithTitle(title, message, 40));
        }
        catch (DivideByZeroException ex)
        {
            string title = "Division Error";
            string message = ex.Message;
            Console.WriteLine(OutputHelpers.BoxedMessageWithTitle(title, message, 40));
        }
    }
}