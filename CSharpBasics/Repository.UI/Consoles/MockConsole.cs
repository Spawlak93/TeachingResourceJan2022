using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.UI.Consoles
{
    public class MockConsole : IConsole
    {
        public string Output;
        public Queue<string> UserInput;

        MockConsole(IEnumerable<string> input)
        {
            Output = "";
            UserInput = new Queue<string>(input);
        }
        public void Clear()
        {
            Output += "Clear Method Called";
        }

        public ConsoleKeyInfo ReadKey()
        {
            return new ConsoleKeyInfo();
        }

        public string ReadLine()
        {
            return UserInput.Dequeue();
        }

        public void Write(object o)
        {
            Output += o + "\n";
        }

        public void WriteLine(object o)
        {
            Output += o + "\n";            
        }
    }
}