using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _211210GuessGameApp.Games
{
    public class GuessNotValidException : Exception
    {
        public GuessNotValidException(string message) : base(message)
        {
        }
    }
}
