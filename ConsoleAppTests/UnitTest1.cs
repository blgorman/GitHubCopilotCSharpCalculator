using Xunit;
using ServiceLayer;

namespace ConsoleAppTests
{
    public class CalculatorTests
    {
        private readonly Calculator _calculator;

        public CalculatorTests()
        {
            _calculator = new Calculator();
        }

        [Theory]
        [InlineData(5, 3, 8)]
        [InlineData(-5, 3, -2)]
        [InlineData(0, 0, 0)]
        [InlineData(10.5, 2.3, 12.8)]
        public void Add_ShouldReturnCorrectSum(double a, double b, double expected)
        {
            // Act
            var result = _calculator.Add(a, b);

            // Assert
            Assert.Equal(expected, result, precision: 10);
        }

        [Theory]
        [InlineData(5, 3, 2)]
        [InlineData(-5, 3, -8)]
        [InlineData(0, 0, 0)]
        [InlineData(10.5, 2.3, 8.2)]
        public void Subtract_ShouldReturnCorrectDifference(double a, double b, double expected)
        {
            // Act
            var result = _calculator.Subtract(a, b);

            // Assert
            Assert.Equal(expected, result, precision: 10);
        }

        [Theory]
        [InlineData(5, 3, 15)]
        [InlineData(-5, 3, -15)]
        [InlineData(0, 5, 0)]
        [InlineData(2.5, 4, 10)]
        public void Multiply_ShouldReturnCorrectProduct(double a, double b, double expected)
        {
            // Act
            var result = _calculator.Multiply(a, b);

            // Assert
            Assert.Equal(expected, result, precision: 10);
        }

        [Theory]
        [InlineData(10, 2, 5)]
        [InlineData(-10, 2, -5)]
        [InlineData(0, 5, 0)]
        [InlineData(7.5, 2.5, 3)]
        public void Divide_ShouldReturnCorrectQuotient(double a, double b, double expected)
        {
            // Act
            var result = _calculator.Divide(a, b);

            // Assert
            Assert.Equal(expected, result, precision: 10);
        }

        [Fact]
        public void Divide_ByZero_ShouldThrowDivideByZeroException()
        {
            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
        }
    }
}
