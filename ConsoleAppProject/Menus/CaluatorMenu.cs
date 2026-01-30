using ConsoleHelpers;
using ServiceLayer;

namespace ConsoleAppProject.Menus;

/// <summary>
/// Calculator menu for mathematical operations.
/// Provides options for Add, Subtract, Multiply, and Divide.
/// </summary>
public class CalculatorMenu : BaseMenu
{
    private readonly CalculatorOperations _calculatorOperations;

    public CalculatorMenu()
    {
        _calculatorOperations = new CalculatorOperations();   
    }

    public override List<string> MenuOptions() => new List<string> {
        "Add Numbers",
        "Subtract Numbers",
        "Multiply Numbers",
        "Divide Numbers",
        "Exit"
    };

    public override async Task<bool> HandleMenuChoiceAsync(int choice)
    {
        await Task.CompletedTask; // Satisfy async signature
        
        switch (choice)
        {
            case 1:
                _calculatorOperations.AddNumbers();
                break;
            case 2:
                _calculatorOperations.SubtractNumbers();
                break;
            case 3:
                _calculatorOperations.MultiplyNumbers();
                break;
            case 4:
                _calculatorOperations.DivideNumbers();
                break;
            case 5:
            default:
                return false;
        }

        InputHelpers.WaitForUserInput();
        return true;
    }
}
