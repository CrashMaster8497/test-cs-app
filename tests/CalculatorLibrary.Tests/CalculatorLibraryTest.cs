namespace CalculatorLibrary.Tests
{
    public class CalculatorLibraryTest
    {
        [Fact]
        public void ShouldDoAddition()
        {
            var calculator = new Calculator();

            var actual = calculator.DoOperation(5, 7, "a");
            calculator.Finish();

            Assert.Equal(12, actual);
        }

        [Fact]
        public void ShouldDoSubstraction()
        {
            var calculator = new Calculator();

            var actual = calculator.DoOperation(5, 7, "s");
            calculator.Finish();

            Assert.Equal(-2, actual);
        }

        [Fact]
        public void ShouldDoMultiplication()
        {
            var calculator = new Calculator();

            var actual = calculator.DoOperation(5, 7, "m");
            calculator.Finish();

            Assert.Equal(35, actual);
        }

        [Fact]
        public void ShouldDoDivisionInt()
        {
            var calculator = new Calculator();

            var actual = calculator.DoOperation(10, 5, "d");
            calculator.Finish();

            Assert.Equal(2, actual);
        }

        [Fact]
        public void ShouldDoDivisionRational()
        {
            var calculator = new Calculator();

            var actual = calculator.DoOperation(12, 5, "d");
            calculator.Finish();

            Assert.Equal(2.4, actual);
        }

        [Fact]
        public void ShouldDoDivisionIrrational()
        {
            var calculator = new Calculator();

            var actual = calculator.DoOperation(5, 3, "d");
            calculator.Finish();

            Assert.Equal(5.0 / 3.0, actual);
        }

        [Fact]
        public void ShouldNotDoDivision()
        {
            var calculator = new Calculator();

            var actual = calculator.DoOperation(5, 0, "d");
            calculator.Finish();

            Assert.Equal(Double.NaN, actual);
        }

        [Fact]
        public void ShouldNotDoOperation1()
        {
            var calculator = new Calculator();

            var actual = calculator.DoOperation(5, 7, "");
            calculator.Finish();

            Assert.Equal(Double.NaN, actual);
        }

        [Fact]
        public void ShouldNotDoOperation2()
        {
            var calculator = new Calculator();

            var actual = calculator.DoOperation(5, 7, "as");
            calculator.Finish();

            Assert.Equal(Double.NaN, actual);
        }
    }
}
