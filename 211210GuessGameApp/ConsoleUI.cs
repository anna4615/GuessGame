using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _211210GuessGameApp
{
    public class ConsoleUI : IUserInterface
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }

        public void ShowOutput(string text)
        {
            Console.WriteLine(text);
        }
    }
}
