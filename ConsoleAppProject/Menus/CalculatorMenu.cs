
using ConsoleHelpers;
using ServiceLayer;

namespace ConsoleAppProject.Menus;

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
