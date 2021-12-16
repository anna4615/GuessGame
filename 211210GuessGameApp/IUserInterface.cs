using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _211210GuessGameApp
{
    public interface IUserInterface
    {
        void ShowOutput(string text);

        string GetInput();
    }
}
