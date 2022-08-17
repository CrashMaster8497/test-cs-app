using System.Text;
using System.Text.RegularExpressions;

namespace Calculator.Tests
{
    public static class MyExtensions
    {
        public static void AppendLines(this StringBuilder stringBuilder, params string[] lines)
        {
            foreach(var line in lines)
            {
                stringBuilder.AppendLine(line);
            }
        }
    }

    [Collection("CalculatorAppTests")]
    public class ProgramTest
    {
        const string Header = "Console Calculator in C#" + "------------------------";
        const string FirstNumber = "Type a number, and then press Enter: ";
        const string SecondNumber = "Type another number, and then press Enter: ";
        const string Operators = "Choose an operator from the following list:" + "a - Add" + "s - Subtract" + "m - Multiply" + "d - Divide" + "Your option? ";
        const string Result = "Your result: ";
        const string Continue = "------------------------" + "Press 'n' and Enter to close the app, or press any other key and Enter to continue: ";
        const string NotValidNumber = "This is not valid input. Please enter an integer value: ";
        const string MathError = "This operation will result in a mathematical error.";

        [Fact]
        public void ShouldRun()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLines("5", "7", "a", "n");
            var reader = new StringReader(stringBuilder.ToString());
            Console.SetIn(reader);
            var writer = new StringWriter();
            Console.SetOut(writer);

            CalculatorProgram.Program.Main(Array.Empty<string>());

            var actual = Regex.Replace(writer.ToString(), "[\r\t\n]*", string.Empty);

            Assert.Equal(Header + FirstNumber + SecondNumber + Operators + Result + "12" + Continue, actual);
        }

        [Fact]
        public void ShouldWaitForValidFirstOperand()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLines("", "a", "5", "7", "a", "n");
            var reader = new StringReader(stringBuilder.ToString());
            Console.SetIn(reader);
            var writer = new StringWriter();
            Console.SetOut(writer);

            CalculatorProgram.Program.Main(Array.Empty<string>());

            var actual = Regex.Replace(writer.ToString(), "[\r\t\n]*", string.Empty);

            Assert.Equal(Header + FirstNumber + NotValidNumber + NotValidNumber + SecondNumber + Operators + Result + "12" + Continue, actual);
        }

        [Fact]
        public void ShouldWaitForValidSecondOperand()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLines("5", "", "a", "7", "a", "n");
            var reader = new StringReader(stringBuilder.ToString());
            Console.SetIn(reader);
            var writer = new StringWriter();
            Console.SetOut(writer);

            CalculatorProgram.Program.Main(Array.Empty<string>());

            var actual = Regex.Replace(writer.ToString(), "[\r\t\n]*", string.Empty);

            Assert.Equal(Header + FirstNumber + SecondNumber + NotValidNumber + NotValidNumber + Operators + Result + "12" + Continue, actual);
        }

        [Fact]
        public void ShouldShowMathematicalError()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLines("5", "0", "d", "n");
            var reader = new StringReader(stringBuilder.ToString());
            Console.SetIn(reader);
            var writer = new StringWriter();
            Console.SetOut(writer);

            CalculatorProgram.Program.Main(Array.Empty<string>());

            var actual = Regex.Replace(writer.ToString(), "[\r\t\n]*", string.Empty);

            Assert.Equal(Header + FirstNumber + SecondNumber + Operators + MathError + Continue, actual);
        }

        [Fact]
        public void ShouldDoMultipleOperations()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLines("5", "7", "a", ".", "5", "7", "s", ".", "5", "7", "m", ".", "7", "5", "d", "n");
            var reader = new StringReader(stringBuilder.ToString());
            Console.SetIn(reader);
            var writer = new StringWriter();
            Console.SetOut(writer);

            CalculatorProgram.Program.Main(Array.Empty<string>());

            var actual = Regex.Replace(writer.ToString(), "[\r\t\n]*", string.Empty);

            Assert.Equal(Header +
                FirstNumber + SecondNumber + Operators + Result + "12" + Continue +
                FirstNumber + SecondNumber + Operators + Result + "-2" + Continue +
                FirstNumber + SecondNumber + Operators + Result + "35" + Continue +
                FirstNumber + SecondNumber + Operators + Result + (7.0 / 5.0) + Continue, actual);
        }
    }
}
