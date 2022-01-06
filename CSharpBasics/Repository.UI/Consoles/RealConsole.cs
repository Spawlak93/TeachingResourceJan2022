using System;

namespace Repository.UI.Consoles
{
    public class RealConsole : IConsole
    {
        public void Clear()
        {
            Console.Clear();
        }

        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Write(object obj)
        {
            Console.Write(obj);
        }

        public void WriteLine(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}