namespace Calculator.Tests
{
    public class CalculatorTest
    {
        [Fact]
        public void ShouldDoAddition()
        {
            Assert.Equal(12, Calculator.DoOperation(5, 7, "a"));
        }

        [Fact]
        public void ShouldDoSubstraction()
        {
            Assert.Equal(-2, Calculator.DoOperation(5, 7, "s"));
        }

        [Fact]
        public void ShouldDoMultiplication()
        {
            Assert.Equal(35, Calculator.DoOperation(5, 7, "m"));
        }

        [Fact]
        public void ShouldDoDivision1()
        {
            Assert.Equal(2, Calculator.DoOperation(10, 5, "d"));
        }

        [Fact]
        public void ShouldDoDivision2()
        {
            Assert.Equal(2.4, Calculator.DoOperation(12, 5, "d"));
        }

        [Fact]
        public void ShouldDoDivision3()
        {
            Assert.Equal(12 / 3, Calculator.DoOperation(12, 3, "d"));
        }

        [Fact]
        public void ShouldNotDoDivision()
        {
            Assert.Equal(Double.NaN, Calculator.DoOperation(5, 0, "d"));
        }

        [Fact]
        public void ShouldNotDoOperation1()
        {
            Assert.Equal(Double.NaN, Calculator.DoOperation(5, 7, ""));
        }

        [Fact]
        public void ShouldNotDoOperation2()
        {
            Assert.Equal(Double.NaN, Calculator.DoOperation(5, 7, "as"));
        }
    }
}