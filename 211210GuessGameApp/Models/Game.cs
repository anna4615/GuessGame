using _211210GuessGameApp.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _211210GuessGameApp.Models
{
    public class Game
    {
        public IGameStrategy Strategy { get; set; }

        public string Name { get; private set; }

        public string CorrectGuessResponse { get; private set; }

        public string Goal { get; private set; }

        public int Guesses { get; private set; }


        public void InitiateGame(IGameStrategy strategy)
        {
            Strategy = strategy;
            Name = Strategy.SetGameName();
            CorrectGuessResponse = Strategy.SetCorrectGuessString();
            Goal = Strategy.MakeGoal();
            Guesses = 0;
        }


        public void IncreaseGuesses()
        {
            Guesses++;
        }
    }
}
