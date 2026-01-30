using ConsoleAppProject.BusinessLogic;
using Shouldly;

namespace ConsoleAppTests;

/// <summary>
/// Unit tests for the Calculator business logic class.
/// Tests all mathematical operations including edge cases and error conditions.
/// </summary>
public class CalculatorTests
{
    private readonly Calculator _calculator;

    public CalculatorTests()
    {
        _calculator = new Calculator();
    }

    #region Add Tests

    [Fact]
    public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
    {
        // Arrange
        double firstNumber = 10.5;
        double secondNumber = 20.3;
        double expected = 30.8;

        // Act
        double result = _calculator.Add(firstNumber, secondNumber);

        // Assert
        result.ShouldBe(expected, 0.0001);
    }

    [Fact]
    public void Add_TwoNegativeNumbers_ReturnsCorrectSum()
    {
        // Arrange
        double firstNumber = -15.5;
        double secondNumber = -10.2;
        double expected = -25.7;

        // Act
        double result = _calculator.Add(firstNumber, secondNumber);

        // Assert
        result.ShouldBe(expected, 0.0001);
    }

    [Fact]
    public void Add_PositiveAndNegativeNumbers_ReturnsCorrectSum()
    {
        // Arrange
        double firstNumber = 50.0;
        double secondNumber = -20.0;
        double expected = 30.0;

        // Act
        double result = _calculator.Add(firstNumber, secondNumber);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void Add_ZeroAndNumber_ReturnsNumber()
    {
        // Arrange
        double firstNumber = 0.0;
        double secondNumber = 42.0;
        double expected = 42.0;

        // Act
        double result = _calculator.Add(firstNumber, secondNumber);

        // Assert
        result.ShouldBe(expected);
    }

    #endregion

    #region Subtract Tests

    [Fact]
    public void Subtract_TwoPositiveNumbers_ReturnsCorrectDifference()
    {
        // Arrange
        double firstNumber = 50.0;
        double secondNumber = 20.0;
        double expected = 30.0;

        // Act
        double result = _calculator.Subtract(firstNumber, secondNumber);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void Subtract_ResultingInNegative_ReturnsCorrectDifference()
    {
        // Arrange
        double firstNumber = 20.0;
        double secondNumber = 50.0;
        double expected = -30.0;

        // Act
        double result = _calculator.Subtract(firstNumber, secondNumber);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void Subtract_TwoNegativeNumbers_ReturnsCorrectDifference()
    {
        // Arrange
        double firstNumber = -10.0;
        double secondNumber = -25.0;
        double expected = 15.0;

        // Act
        double result = _calculator.Subtract(firstNumber, secondNumber);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void Subtract_SameNumbers_ReturnsZero()
    {
        // Arrange
        double firstNumber = 42.0;
        double secondNumber = 42.0;
        double expected = 0.0;

        // Act
        double result = _calculator.Subtract(firstNumber, secondNumber);

        // Assert
        result.ShouldBe(expected);
    }

    #endregion

    #region Multiply Tests

    [Fact]
    public void Multiply_TwoPositiveNumbers_ReturnsCorrectProduct()
    {
        // Arrange
        double firstNumber = 5.0;
        double secondNumber = 6.0;
        double expected = 30.0;

        // Act
        double result = _calculator.Multiply(firstNumber, secondNumber);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void Multiply_TwoNegativeNumbers_ReturnsPositiveProduct()
    {
        // Arrange
        double firstNumber = -4.0;
        double secondNumber = -5.0;
        double expected = 20.0;

        // Act
        double result = _calculator.Multiply(firstNumber, secondNumber);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void Multiply_PositiveAndNegativeNumbers_ReturnsNegativeProduct()
    {
        // Arrange
        double firstNumber = 7.0;
        double secondNumber = -3.0;
        double expected = -21.0;

        // Act
        double result = _calculator.Multiply(firstNumber, secondNumber);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void Multiply_ByZero_ReturnsZero()
    {
        // Arrange
        double firstNumber = 42.0;
        double secondNumber = 0.0;
        double expected = 0.0;

        // Act
        double result = _calculator.Multiply(firstNumber, secondNumber);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void Multiply_DecimalNumbers_ReturnsCorrectProduct()
    {
        // Arrange
        double firstNumber = 2.5;
        double secondNumber = 4.0;
        double expected = 10.0;

        // Act
        double result = _calculator.Multiply(firstNumber, secondNumber);

        // Assert
        result.ShouldBe(expected);
    }

    #endregion

    #region Divide Tests

    [Fact]
    public void Divide_TwoPositiveNumbers_ReturnsCorrectQuotient()
    {
        // Arrange
        double firstNumber = 20.0;
        double secondNumber = 4.0;
        double expected = 5.0;

        // Act
        double result = _calculator.Divide(firstNumber, secondNumber);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void Divide_TwoNegativeNumbers_ReturnsPositiveQuotient()
    {
        // Arrange
        double firstNumber = -30.0;
        double secondNumber = -5.0;
        double expected = 6.0;

        // Act
        double result = _calculator.Divide(firstNumber, secondNumber);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void Divide_PositiveByNegative_ReturnsNegativeQuotient()
    {
        // Arrange
        double firstNumber = 40.0;
        double secondNumber = -8.0;
        double expected = -5.0;

        // Act
        double result = _calculator.Divide(firstNumber, secondNumber);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void Divide_ZeroByNumber_ReturnsZero()
    {
        // Arrange
        double firstNumber = 0.0;
        double secondNumber = 10.0;
        double expected = 0.0;

        // Act
        double result = _calculator.Divide(firstNumber, secondNumber);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        double firstNumber = 42.0;
        double secondNumber = 0.0;

        // Act & Assert
        Should.Throw<DivideByZeroException>(() => _calculator.Divide(firstNumber, secondNumber))
            .Message.ShouldBe("Cannot divide by zero");
    }

    [Fact]
    public void Divide_DecimalNumbers_ReturnsCorrectQuotient()
    {
        // Arrange
        double firstNumber = 7.5;
        double secondNumber = 2.5;
        double expected = 3.0;

        // Act
        double result = _calculator.Divide(firstNumber, secondNumber);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void Divide_ResultingInDecimal_ReturnsCorrectQuotient()
    {
        // Arrange
        double firstNumber = 10.0;
        double secondNumber = 3.0;
        double expected = 3.3333333333333335;

        // Act
        double result = _calculator.Divide(firstNumber, secondNumber);

        // Assert
        result.ShouldBe(expected, 0.0001);
    }

    #endregion
}
