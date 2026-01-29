using ConsoleHelpers;

namespace ServiceLayer;

public class CalculatorOperations
{
    // Implementation of calculator options goes here
    // This is a service layer only, operations should be in a new fully-tested class

    public void AddNumbers()
    {
        Console.WriteLine(OutputHelpers.BoxedMessage("Add Numbers operation selected.", '*', 40));
    }   
}