using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _211210GuessGameApp.Models
{
    public class Result
    {
        public string PlayerName { get; set; }

        public int Guesses { get; set; }

        public Result(string playerName, int guesses)
        {
            PlayerName = playerName;
            Guesses = guesses;
        }
    }
}
