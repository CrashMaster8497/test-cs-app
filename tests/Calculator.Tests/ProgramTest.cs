using System.Text;

namespace Calculator.Tests
{
    [Collection("CalculatorAppTests")]
    public class ProgramTest
    {
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

            CalculatorProgram.Program.Main(Array.Empty<string>());

            var actual = writer.ToString();
            actual = actual.Replace("\r", "");
            actual = actual.Replace("\t", "");
            actual = actual.Replace("\n", "");

            Assert.Equal("Console Calculator in C#" +
                "------------------------" +
                "Type a number, and then press Enter: " +
                "Type another number, and then press Enter: " +
                "Choose an operator from the following list:" +
                "a - Add" +
                "s - Subtract" +
                "m - Multiply" +
                "d - Divide" +
                "Your option? " +
                "Your result: 12" +
                "------------------------" +
                "Press 'n' and Enter to close the app, or press any other key and Enter to continue: ", actual);
        }

        [Fact]
        public void ShouldWaitForValidOperand1()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("a");
            stringBuilder.AppendLine("5");
            stringBuilder.AppendLine("7");
            stringBuilder.AppendLine("a");
            stringBuilder.AppendLine("n");
            var reader = new StringReader(stringBuilder.ToString());
            Console.SetIn(reader);
            var writer = new StringWriter();
            Console.SetOut(writer);

            CalculatorProgram.Program.Main(Array.Empty<string>());

            var actual = writer.ToString();
            actual = actual.Replace("\r", "");
            actual = actual.Replace("\t", "");
            actual = actual.Replace("\n", "");

            Assert.Equal("Console Calculator in C#" +
                "------------------------" +
                "Type a number, and then press Enter: " +
                "This is not valid input. Please enter an integer value: " +
                "This is not valid input. Please enter an integer value: " +
                "Type another number, and then press Enter: " +
                "Choose an operator from the following list:" +
                "a - Add" +
                "s - Subtract" +
                "m - Multiply" +
                "d - Divide" +
                "Your option? " +
                "Your result: 12" +
                "------------------------" +
                "Press 'n' and Enter to close the app, or press any other key and Enter to continue: ", actual);
        }

        [Fact]
        public void ShouldWaitForValidOperand2()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("5");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("a");
            stringBuilder.AppendLine("7");
            stringBuilder.AppendLine("a");
            stringBuilder.AppendLine("n");
            var reader = new StringReader(stringBuilder.ToString());
            Console.SetIn(reader);
            var writer = new StringWriter();
            Console.SetOut(writer);

            CalculatorProgram.Program.Main(Array.Empty<string>());

            var actual = writer.ToString();
            actual = actual.Replace("\r", "");
            actual = actual.Replace("\t", "");
            actual = actual.Replace("\n", "");

            Assert.Equal("Console Calculator in C#" +
                "------------------------" +
                "Type a number, and then press Enter: " +
                "Type another number, and then press Enter: " +
                "This is not valid input. Please enter an integer value: " +
                "This is not valid input. Please enter an integer value: " +
                "Choose an operator from the following list:" +
                "a - Add" +
                "s - Subtract" +
                "m - Multiply" +
                "d - Divide" +
                "Your option? " +
                "Your result: 12" +
                "------------------------" +
                "Press 'n' and Enter to close the app, or press any other key and Enter to continue: ", actual);
        }

        [Fact]
        public void ShouldShowMathematicalError()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("5");
            stringBuilder.AppendLine("0");
            stringBuilder.AppendLine("d");
            stringBuilder.AppendLine("n");
            var reader = new StringReader(stringBuilder.ToString());
            Console.SetIn(reader);
            var writer = new StringWriter();
            Console.SetOut(writer);

            CalculatorProgram.Program.Main(Array.Empty<string>());

            var actual = writer.ToString();
            actual = actual.Replace("\r", "");
            actual = actual.Replace("\t", "");
            actual = actual.Replace("\n", "");

            Assert.Equal("Console Calculator in C#" +
                "------------------------" +
                "Type a number, and then press Enter: " +
                "Type another number, and then press Enter: " +
                "Choose an operator from the following list:" +
                "a - Add" +
                "s - Subtract" +
                "m - Multiply" +
                "d - Divide" +
                "Your option? " +
                "This operation will result in a mathematical error." +
                "------------------------" +
                "Press 'n' and Enter to close the app, or press any other key and Enter to continue: ", actual);
        }

        [Fact]
        public void ShouldDoMultipleOperations()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("5");
            stringBuilder.AppendLine("7");
            stringBuilder.AppendLine("a");
            stringBuilder.AppendLine(".");
            stringBuilder.AppendLine("5");
            stringBuilder.AppendLine("7");
            stringBuilder.AppendLine("m");
            stringBuilder.AppendLine("n");
            var reader = new StringReader(stringBuilder.ToString());
            Console.SetIn(reader);
            var writer = new StringWriter();
            Console.SetOut(writer);

            CalculatorProgram.Program.Main(Array.Empty<string>());

            var actual = writer.ToString();
            actual = actual.Replace("\r", "");
            actual = actual.Replace("\t", "");
            actual = actual.Replace("\n", "");

            Assert.Equal("Console Calculator in C#" +
                "------------------------" +
                "Type a number, and then press Enter: " +
                "Type another number, and then press Enter: " +
                "Choose an operator from the following list:" +
                "a - Add" +
                "s - Subtract" +
                "m - Multiply" +
                "d - Divide" +
                "Your option? " +
                "Your result: 12" +
                "------------------------" +
                "Press 'n' and Enter to close the app, or press any other key and Enter to continue: " +
                "Type a number, and then press Enter: " +
                "Type another number, and then press Enter: " +
                "Choose an operator from the following list:" +
                "a - Add" +
                "s - Subtract" +
                "m - Multiply" +
                "d - Divide" +
                "Your option? " +
                "Your result: 35" +
                "------------------------" +
                "Press 'n' and Enter to close the app, or press any other key and Enter to continue: ", actual);
        }
    }
}
