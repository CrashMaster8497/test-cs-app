using System;
using CalculatorLibrary;

namespace CalculatorProgram
{
    public class Program
    {
        public IConsole MyConsole = new DefaultConsole();

        public void RunProgram()
        {
            bool endApp = false;
            // Display title as the C# console calculator app.
            MyConsole.WriteLine("Console Calculator in C#\r");
            MyConsole.WriteLine("------------------------\n");

            Calculator calculator = new Calculator();
            while (!endApp)
            {
                // Declare variables and set to empty.
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                // Ask the user to type the first number.
                MyConsole.Write("Type a number, and then press Enter: ");
                numInput1 = MyConsole.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    MyConsole.Write("This is not valid input. Please enter an integer value: ");
                    numInput1 = MyConsole.ReadLine();
                }

                // Ask the user to type the second number.
                MyConsole.Write("Type another number, and then press Enter: ");
                numInput2 = MyConsole.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    MyConsole.Write("This is not valid input. Please enter an integer value: ");
                    numInput2 = MyConsole.ReadLine();
                }

                // Ask the user to choose an operator.
                MyConsole.WriteLine("Choose an operator from the following list:");
                MyConsole.WriteLine("\ta - Add");
                MyConsole.WriteLine("\ts - Subtract");
                MyConsole.WriteLine("\tm - Multiply");
                MyConsole.WriteLine("\td - Divide");
                MyConsole.Write("Your option? ");

                string op = MyConsole.ReadLine();

                result = calculator.DoOperation(cleanNum1, cleanNum2, op);
                if (double.IsNaN(result))
                {
                    MyConsole.WriteLine("This operation will result in a mathematical error.\n");
                }
                else MyConsole.WriteLine("Your result: {0:0.##}\n", result);

                MyConsole.WriteLine("------------------------\n");

                // Wait for the user to respond before closing.
                MyConsole.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (MyConsole.ReadLine() == "n") endApp = true;

                MyConsole.WriteLine("\n"); // Friendly linespacing.
            }
            calculator.Finish();
        }

        public static void Main(string[] args)
        {
            var program = new Program();
            program.RunProgram();
        }
    }
}
