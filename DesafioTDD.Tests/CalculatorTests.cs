using DesafioTDD.Services;

namespace DesafioTDD.Tests
{
    public class CalculatorTests
    {
        private readonly Calculator _calculator;

        public CalculatorTests()
        {
            _calculator = new Calculator();
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(4, 5, 9)]
        public void Sum_TwoIntegers_ShouldReturnCorrectResult(int value1, int value2, int expectedResult)
        {
            // Act
            var result = _calculator.Sum(value1, value2);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(6, 2, 4)]
        [InlineData(5, 5, 0)]
        public void Subtract_TwoIntegers_ShouldReturnCorrectResult(int value1, int value2, int expectedResult)
        {
            // Act
            var result = _calculator.Subtract(value1, value2);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(4, 5, 20)]
        public void Multiply_TwoIntegers_ShouldReturnCorrectResult(int value1, int value2, int expectedResult)
        {
            // Act
            var result = _calculator.Multiply(value1, value2);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(6, 2, 3)]
        [InlineData(5, 5, 1)]
        public void Divide_TwoIntegers_ShouldReturnCorrectResult(int value1, int value2, int expectedResult)
        {
            // Act
            var result = _calculator.Divide(value1, value2);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Fact]
        public void Divide_DivideByZero_ShouldThrowException()
        {
            // Act
            Action result = () => _calculator.Divide(3, 0);

            // Assert
            result.Should().Throw<DivideByZeroException>();
        }

        [Fact]
        public void History_NoOperations_ShouldReturnEmptyList()
        {
            // Act
            var result = _calculator.GetHistory();

            // Assert
            result.Should().BeEmpty();
        }

        [Fact]
        public void History_LessThanThreeOperations_ShouldReturnAllOperations()
        {
            //Arrange
            _calculator.Sum(1, 2);
            _calculator.Sum(2, 9);

            // Act
            var result = _calculator.GetHistory();

            // Assert
            result.Should().HaveCount(2);
            result[0].Should().Be("Result: 11");
            result[1].Should().Be("Result: 3");
        }

        [Fact]
        public void History_EqualToThreeOperations_ShouldReturnAllOperations()
        {
            //Arrange
            _calculator.Sum(1, 2);
            _calculator.Sum(2, 9);
            _calculator.Sum(3, 7);

            // Act
            var result = _calculator.GetHistory();

            // Assert
            result.Should().HaveCount(3);
            result[0].Should().Be("Result: 10");
            result[1].Should().Be("Result: 11");
            result[2].Should().Be("Result: 3");
        }

        [Fact]
        public void History_MoreThanThreeOperations_ShouldReturnLastThreeOperations()
        {
            //Arrange
            _calculator.Sum(1, 2);
            _calculator.Sum(2, 9);
            _calculator.Sum(3, 7);
            _calculator.Sum(4, 1);

            // Act
            var result = _calculator.GetHistory();

            // Assert
            result.Should().HaveCount(3);
            result[0].Should().Be("Result: 5");
            result[1].Should().Be("Result: 10");
            result[2].Should().Be("Result: 11");
        }
    }
}