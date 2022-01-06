using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.UI.Consoles
{
    public interface IConsole
    {
        public string ReadLine();

        public void WriteLine();

        public ConsoleKeyInfo ReadKey();

        public void Write();

        public void Clear();
    }
}