using Xunit;
using ServiceLayer;

namespace ConsoleAppTests
{
    public class CalculatorOperationsTests
    {
        private readonly CalculatorOperations _calculator;

        public CalculatorOperationsTests()
        {
            _calculator = new CalculatorOperations();
        }

        #region Add Tests

        [Fact]
        public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
        {
            // Arrange
            double a = 5;
            double b = 3;

            // Act
            double result = _calculator.Add(a, b);

            // Assert
            Assert.Equal(8, result);
        }

        [Fact]
        public void Add_TwoNegativeNumbers_ReturnsCorrectSum()
        {
            // Arrange
            double a = -5;
            double b = -3;

            // Act
            double result = _calculator.Add(a, b);

            // Assert
            Assert.Equal(-8, result);
        }

        [Fact]
        public void Add_PositiveAndNegativeNumber_ReturnsCorrectSum()
        {
            // Arrange
            double a = 10;
            double b = -4;

            // Act
            double result = _calculator.Add(a, b);

            // Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void Add_WithZero_ReturnsOtherNumber()
        {
            // Arrange
            double a = 7;
            double b = 0;

            // Act
            double result = _calculator.Add(a, b);

            // Assert
            Assert.Equal(7, result);
        }

        #endregion

        #region Subtract Tests

        [Fact]
        public void Subtract_TwoPositiveNumbers_ReturnsCorrectDifference()
        {
            // Arrange
            double a = 10;
            double b = 4;

            // Act
            double result = _calculator.Subtract(a, b);

            // Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void Subtract_NegativeFromPositive_ReturnsCorrectDifference()
        {
            // Arrange
            double a = 5;
            double b = -3;

            // Act
            double result = _calculator.Subtract(a, b);

            // Assert
            Assert.Equal(8, result);
        }

        [Fact]
        public void Subtract_SameNumbers_ReturnsZero()
        {
            // Arrange
            double a = 5;
            double b = 5;

            // Act
            double result = _calculator.Subtract(a, b);

            // Assert
            Assert.Equal(0, result);
        }

        #endregion

        #region Multiply Tests

        [Fact]
        public void Multiply_TwoPositiveNumbers_ReturnsCorrectProduct()
        {
            // Arrange
            double a = 6;
            double b = 7;

            // Act
            double result = _calculator.Multiply(a, b);

            // Assert
            Assert.Equal(42, result);
        }

        [Fact]
        public void Multiply_PositiveAndNegative_ReturnsNegativeProduct()
        {
            // Arrange
            double a = 5;
            double b = -3;

            // Act
            double result = _calculator.Multiply(a, b);

            // Assert
            Assert.Equal(-15, result);
        }

        [Fact]
        public void Multiply_TwoNegativeNumbers_ReturnsPositiveProduct()
        {
            // Arrange
            double a = -4;
            double b = -3;

            // Act
            double result = _calculator.Multiply(a, b);

            // Assert
            Assert.Equal(12, result);
        }

        [Fact]
        public void Multiply_ByZero_ReturnsZero()
        {
            // Arrange
            double a = 100;
            double b = 0;

            // Act
            double result = _calculator.Multiply(a, b);

            // Assert
            Assert.Equal(0, result);
        }

        #endregion

        #region Divide Tests

        [Fact]
        public void Divide_TwoPositiveNumbers_ReturnsCorrectQuotient()
        {
            // Arrange
            double a = 20;
            double b = 4;

            // Act
            double result = _calculator.Divide(a, b);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void Divide_PositiveByNegative_ReturnsNegativeQuotient()
        {
            // Arrange
            double a = 10;
            double b = -2;

            // Act
            double result = _calculator.Divide(a, b);

            // Assert
            Assert.Equal(-5, result);
        }

        [Fact]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            // Arrange
            double a = 10;
            double b = 0;

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(a, b));
        }

        [Fact]
        public void Divide_ZeroByNumber_ReturnsZero()
        {
            // Arrange
            double a = 0;
            double b = 5;

            // Act
            double result = _calculator.Divide(a, b);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Divide_WithDecimalResult_ReturnsCorrectQuotient()
        {
            // Arrange
            double a = 7;
            double b = 2;

            // Act
            double result = _calculator.Divide(a, b);

            // Assert
            Assert.Equal(3.5, result);
        }

        #endregion
    }
}
