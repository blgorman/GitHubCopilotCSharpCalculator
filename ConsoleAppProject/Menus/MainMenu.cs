using ServiceLayer;

namespace ConsoleAppProject.Menus;

public class MainMenu : BaseMenu
{
    private CalculatorMenu _consoleHelpersDemoMenu;

    public MainMenu()
    {
        _consoleHelpersDemoMenu = new CalculatorMenu();
    }

    public override async Task<bool> HandleMenuChoiceAsync(int choice)
    {
        IAsyncDemo nextDemo = new CalculatorMenu();
        string title = "C# Calculator Application";
        switch (choice)
        {
            case 1:
                nextDemo = new CalculatorMenu();;
                title = "C# Calculator Application";
                break;
            default:
                return false;
        }

        await nextDemo.ShowAsync(title);

        ConsoleHelpers.InputHelpers.WaitForUserInput();
        return true;
    }

    //get menu options
    public override List<string> MenuOptions() => new List<string>() {
            "C# Calculator Application",
            "Exit"
    };
}
