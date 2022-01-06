using System;
using Repository.Library;
using Repository.UI.Consoles;

namespace Repository.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface ui = new UserInterface(new RealConsole());
            ui.Run();
        }
    }
}





