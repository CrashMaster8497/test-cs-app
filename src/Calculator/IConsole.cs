namespace CalculatorProgram
{
    public interface IConsole
    {
        string ReadLine();
        void Write(string text);
        void WriteLine(string text);
        void WriteLine(string format, params object[] args);
    }

    internal class DefaultConsole : IConsole
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public void WriteLine(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }
    }
}
