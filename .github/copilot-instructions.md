# C# Console Application Architecture Guidelines

## Core Architectural Principles

This codebase follows **SOLID principles** with strict separation of concerns. Every class must have a **single, well-defined responsibility**. Follow these guidelines precisely when extending or modifying code.

---

## Project Structure & Responsibilities

### 1. **ConsoleAppProject** - Main Application
**Purpose**: Orchestration and menu navigation only. No business logic or console I/O primitives.

#### Entry Point (`Program.cs`)
- **Responsibility**: Application bootstrapping, configuration, dependency injection, and logging setup
- Configure `IConfiguration` with appsettings.json files
- Register services with DI container
- Set up Serilog logging infrastructure
- **Never** add business logic here

#### Application Class (`Application.cs`)
- **Responsibility**: Single entry point for application workflow
- Instantiate and run the main menu
- Access configuration through dependency injection
- **Never** directly handle user input or contain business logic
- **Never** directly write to console (except for high-level startup messages)

#### Menus Namespace (`Menus/`)

**BaseMenu (Abstract Class)**
- **Responsibility**: Template Method pattern for all menu interactions
- Provides `ShowAsync(string title)` - sealed template method that cannot be overridden
- Forces derived classes to implement:
  - `MenuOptions()` - returns list of menu text
  - `HandleMenuChoiceAsync(int choice)` - processes user selection
- Uses `ConsoleHelpers.InputHelpers` for all input operations
- Uses `MenuGenerator` for menu display formatting
- **Never** add business logic to menus
- **Never** directly handle console I/O primitives (use ConsoleHelpers)

**IAsyncDemo Interface**
- **Responsibility**: Contract for all async menu interactions
- Defines: `ShowAsync()`, `MenuOptions()`, `HandleMenuChoiceAsync()`
- All menu classes must implement this interface

**Concrete Menu Classes** (e.g., `MainMenu`, `CalculatorMenu`)
- **Responsibility**: Menu orchestration and navigation only
- Return `true` from `HandleMenuChoiceAsync` to continue loop, `false` to exit
- Instantiate service layer objects to delegate work
- **Never** contain calculation logic or business rules
- **Never** directly use Console.WriteLine/ReadLine - delegate to ServiceLayer
- Use `InputHelpers.WaitForUserInput()` after operations complete

**MenuGenerator Class**
- **Responsibility**: Menu text formatting only
- Static class with `GenerateMenu()` methods
- Takes title, prompt, options, and line length
- Returns formatted string for display
- **Never** handle user input or navigation logic

#### ServiceLayer Namespace (`ServiceLayer/`)
- **Responsibility**: Business logic coordination and orchestration ONLY
- Service classes orchestrate operations by:
  - Using `InputHelpers` for user input
  - Using `Console.WriteLine(OutputHelpers.BoxedMessage(...))` for formatted output
  - Calling business logic classes for ALL calculations/operations (even simple ones)
  - Coordinating the flow between input, processing, and output
- **Never** use raw `Console.ReadLine()` (use InputHelpers instead)
- **Never** implement ANY business logic directly - always delegate to separate testable classes
- Example: `CalculatorOperations` coordinates but delegates math to a `Calculator` class

---

### 2. **ConsoleHelpers** - Separate Project
**Purpose**: Reusable console I/O primitives. Zero business logic.

#### InputHelpers Class
- **Responsibility**: User input validation and parsing only
- Static methods for typed input: `GetInputAsInt()`, `GetInputAsDouble()`, `GetInputAsBool()`
- All methods include:
  - Prompt message
  - Optional min/max validation
  - Optional confirmation
  - Retry loops until valid
- `WaitForUserInput()` - pause for user acknowledgment
- **Never** add domain-specific logic
- **Never** reference application-specific classes

#### OutputHelpers Class
- **Responsibility**: Console output formatting only
- Static methods for formatted output:
  - `BoxedMessage(string message, char borderChar, int lineLength)` - single message in a box
  - `BoxedMessageWithTitle(string title, string message, int lineLength)` - message with title header
  - `BoxedArrayWithTitle(string title, string[] items, int lineLength)` - array of items with title
- **Returns formatted strings** - does NOT write to console
- ServiceLayer calls `Console.WriteLine(OutputHelpers.BoxedMessage(...))` to display
- Pure string manipulation and formatting
- **Never** add business logic
- **Never** reference application-specific classes

---

## SOLID Principles Enforcement

### Single Responsibility Principle (SRP)
- **One class = One reason to change**
- Menus only navigate, never calculate
- ServiceLayer coordinates, never formats output
- ConsoleHelpers only handles I/O, never business logic
- **Before adding a method**: Ask "Does this belong to this class's single purpose?"

### Open/Closed Principle (OCP)
- Extend menus by creating new classes inheriting from `BaseMenu`
- Add new operations by creating new service classes
- **Never** modify existing menu flow in `BaseMenu`

### Liskov Substitution Principle (LSP)
- All menus inherit from `BaseMenu` and implement `IAsyncDemo`
- Subclasses must honor base class contracts
- `HandleMenuChoiceAsync` must return `bool` with consistent meaning

### Interface Segregation Principle (ISP)
- `IAsyncDemo` defines minimal menu contract
- ConsoleHelpers methods are focused and single-purpose

### Dependency Inversion Principle (DIP)
- `Application` depends on abstractions via DI (IConfiguration, ILogger)
- High-level menus depend on service layer abstractions, not concrete implementations
- When adding new features, inject dependencies through constructor

---

## Code Extension Guidelines

### Adding a New Menu
1. Create new class in `Menus/` namespace inheriting from `BaseMenu`
2. Implement `MenuOptions()` returning List<string>
3. Implement `HandleMenuChoiceAsync(int choice)` with switch statement
4. Use switch cases to delegate to ServiceLayer classes
5. Call `InputHelpers.WaitForUserInput()` after operations
6. Return `true` to continue, `false` to exit
7. **Never** add business logic in the menu class

### Adding a New Operation
1. Create method in appropriate ServiceLayer class or create new service class
2. Create separate business logic class for the operation (e.g., `Calculator` class for math)
   - If the business logic class doesn't exist, create it in a new folder/namespace as appropriate
   - Business logic classes should be pure logic with no dependencies on I/O
3. Use `InputHelpers` to get user input with validation
4. Call business logic class to perform the operation
5. Use `OutputHelpers` to format results
6. Display results with `Console.WriteLine(OutputHelpers.BoxedMessage(...))`
7. **Never** use raw `Console.ReadLine()` (use InputHelpers instead)
8. **Never** implement logic in ServiceLayer - always delegate to business logic classes

### Adding a New Console Helper
1. Add to `ConsoleHelpers` project only if reusable across applications
2. Must be static utility method
3. Must handle one specific I/O concern
4. Include validation and error handling
5. **Never** reference application-specific types

---

## Naming Conventions

- **Menus**: End with "Menu" (e.g., `CalculatorMenu`, `MainMenu`)
- **Service Classes**: End with operation type (e.g., `CalculatorOperations`, `ReportGenerator`)
- **Helper Classes**: End with "Helpers" or "Generator" (e.g., `InputHelpers`, `MenuGenerator`)
- **Interfaces**: Start with "I" (e.g., `IAsyncDemo`)
- **Async Methods**: End with "Async" (e.g., `HandleMenuChoiceAsync`, `ShowAsync`)

---

## Anti-Patterns to Avoid

### ❌ **DO NOT**
- Add business logic to menu classes
- Add business logic to ServiceLayer classes (always delegate to business logic classes)
- Use `Console.WriteLine`/`Console.ReadLine` in menu classes (delegate to ServiceLayer)
- Use raw `Console.ReadLine()` anywhere (use InputHelpers with validation)
- Create "God classes" with multiple responsibilities
- Mix I/O primitives (raw Console.ReadLine) and business logic in the same method
- Reference `ConsoleAppProject` types from `ConsoleHelpers` project
- Override `ShowAsync()` in BaseMenu (it's sealed by design)
- Skip input validation

### ✅ **DO**
- Keep classes focused on single responsibility
- Use dependency injection for services
- Always delegate business logic to separate, testable classes (even for simple operations)
- Use ConsoleHelpers for all I/O (InputHelpers for input, OutputHelpers for formatting)
- ServiceLayer pattern: InputHelpers → call business logic class → OutputHelpers
- Follow existing patterns when extending
- Add XML documentation comments
- Validate all user input through InputHelpers
- Return formatted strings from OutputHelpers

---

## Testing Philosophy

### Testing Framework Requirements
- **Use XUnit** for all unit tests
- **Use Shouldly** for assertions (fluent, readable assertions)
- All business logic classes **MUST** have corresponding unit tests

### Test Project Structure
- Create a separate test project (e.g., `ConsoleAppProject.Tests`) if it doesn't exist
- Test project should reference:
  - XUnit framework
  - Shouldly assertion library
  - xunit.runner.visualstudio (for test discovery)
- Mirror the structure of the project being tested
- Name test classes: `{ClassUnderTest}Tests` (e.g., `CalculatorTests`)
- Name test methods: `{MethodName}_{Scenario}_{ExpectedResult}` (e.g., `Add_TwoPositiveNumbers_ReturnsCorrectSum`)

### What to Test
- **Business Logic Classes**: MUST be fully tested (all methods, edge cases, error conditions)
- **ConsoleHelpers**: Should be testable without console interaction
- **ServiceLayer**: Should be testable by mocking I/O dependencies
- **Menus**: Should contain minimal logic (just navigation) - testing optional

### Test-Driven Development Workflow
1. Create business logic class
2. **Immediately create corresponding test class**
3. Write tests for all public methods
4. Test edge cases, error conditions, boundary values
5. Use Shouldly assertions for readability (e.g., `result.ShouldBe(expected)`)

---

## Configuration & Logging

- Use `IConfiguration` for appsettings.json access
- Use `ILogger<T>` for logging via dependency injection
- Serilog configured in `Program.cs`
- Environment-specific settings: `appsettings.{Environment}.json`
- **Never** hardcode configuration values

---

## Summary

**Remember**: This is a **training template**. Every class should be a clear example of single responsibility. When adding code, ask:

1. Does this class have exactly one reason to change?
2. Am I mixing concerns (I/O, logic, navigation)?
3. Could this be reused elsewhere if properly separated?
4. Am I following existing patterns in the codebase?

Keep it **simple**, **separated**, and **SOLID**.
