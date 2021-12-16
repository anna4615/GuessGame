using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _211210GuessGameApp.Games
{
    public class GuessNumberStrategy : IGameStrategy
    {
        public string SetGameName()
        {
            return "GuessNumber";
        }


        public string SetCorrectGuessString()
        {
            return "Correct";
        }


        public string MakeGoal()
        {
            Random random = new Random();
            int number = random.Next(0, 101);

            return number.ToString();
        }


        public string GetResponseForGuess(string guess, string goal)
        {
            int goalNumber = int.Parse(goal);
            string response;

            if (int.TryParse(guess, out int guessedNumber))
            {
                if (guessedNumber < goalNumber)
                    response = "To low";
                else if (guessedNumber > goalNumber)
                    response = "Too high";
                else
                    response = "Correct";
            }

            else
            {
                throw new GuessNotValidException("Guess must be a number.");
            }

            return response;
        }
    }
}
