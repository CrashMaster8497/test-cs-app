using System.Text;
using System.Text.RegularExpressions;
using CalculatorProgram;

namespace Calculator.Tests
{
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
            stringBuilder.AppendLine("5");
            stringBuilder.AppendLine("7");
            stringBuilder.AppendLine("a");
            stringBuilder.AppendLine("n");
            var reader = new StringReader(stringBuilder.ToString());
            Console.SetIn(reader);
            var writer = new StringWriter();
            Console.SetOut(writer);

            Program.Main(Array.Empty<string>());

            var actual = Regex.Replace(writer.ToString(), "[\r\t\n]*", string.Empty);

            Assert.Equal(Header + FirstNumber + SecondNumber + Operators + Result + "12" + Continue, actual);
        }

        [Fact]
        public void ShouldRunProgram()
        {
            var mockConsole = new MockConsole();
            mockConsole.Output.Enqueue("5", "7", "a", "n");

            var program = new Program();
            program.MyConsole = mockConsole;
            program.RunProgram();

            var actual = Regex.Replace(mockConsole.Input.ToString(), "[\r\t\n]*", string.Empty);

            Assert.Equal(Header + FirstNumber + SecondNumber + Operators + Result + "12" + Continue, actual);
        }

        [Fact]
        public void ShouldWaitForValidFirstOperand()
        {
            var mockConsole = new MockConsole();
            mockConsole.Output.Enqueue("", "a", "5", "7", "a", "n");

            var program = new Program();
            program.MyConsole = mockConsole;
            program.RunProgram();

            var actual = Regex.Replace(mockConsole.Input.ToString(), "[\r\t\n]*", string.Empty);

            Assert.Equal(Header + FirstNumber + NotValidNumber + NotValidNumber + SecondNumber + Operators + Result + "12" + Continue, actual);
        }

        [Fact]
        public void ShouldWaitForValidSecondOperand()
        {
            var mockConsole = new MockConsole();
            mockConsole.Output.Enqueue("5", "", "a", "7", "a", "n");

            var program = new Program();
            program.MyConsole = mockConsole;
            program.RunProgram();

            var actual = Regex.Replace(mockConsole.Input.ToString(), "[\r\t\n]*", string.Empty);

            Assert.Equal(Header + FirstNumber + SecondNumber + NotValidNumber + NotValidNumber + Operators + Result + "12" + Continue, actual);
        }

        [Fact]
        public void ShouldShowMathematicalError()
        {
            var mockConsole = new MockConsole();
            mockConsole.Output.Enqueue("5", "0", "d", "n");

            var program = new Program();
            program.MyConsole = mockConsole;
            program.RunProgram();

            var actual = Regex.Replace(mockConsole.Input.ToString(), "[\r\t\n]*", string.Empty);

            Assert.Equal(Header + FirstNumber + SecondNumber + Operators + MathError + Continue, actual);
        }

        [Fact]
        public void ShouldDoMultipleOperations()
        {
            var mockConsole = new MockConsole();
            mockConsole.Output.Enqueue("5", "7", "a", ".", "5", "7", "s", ".", "5", "7", "m", ".", "7", "5", "d", "n");

            var program = new Program();
            program.MyConsole = mockConsole;
            program.RunProgram();

            var actual = Regex.Replace(mockConsole.Input.ToString(), "[\r\t\n]*", string.Empty);

            Assert.Equal(Header +
                FirstNumber + SecondNumber + Operators + Result + "12" + Continue +
                FirstNumber + SecondNumber + Operators + Result + "-2" + Continue +
                FirstNumber + SecondNumber + Operators + Result + "35" + Continue +
                FirstNumber + SecondNumber + Operators + Result + (7.0 / 5.0) + Continue, actual);
        }
    }

    internal static class MyExtensions
    {
        public static void Enqueue<T>(this Queue<T> queue, params T[] args)
        {
            foreach (var item in args)
            {
                queue.Enqueue(item);
            }
        }
    }

    internal class MockConsole : IConsole
    {
        public StringBuilder Input { get; set; } = new StringBuilder();
        public Queue<string> Output { get; set; } = new Queue<string>();

        public string ReadLine()
        {
            return Output.Dequeue();
        }

        public void Write(string text)
        {
            Input.Append(text);
        }

        public void WriteLine(string text)
        {
            Input.AppendLine(text);
        }

        public void WriteLine(string format, params object[] args)
        {
            Input.AppendLine(string.Format(format, args));
        }
    }
}
