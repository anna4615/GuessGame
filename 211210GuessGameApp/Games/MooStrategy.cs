using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _211210GuessGameApp.Games
{
    public class MooStrategy : IGameStrategy
    {
        private int bulls;
        private int cows;


        public string SetGameName()
        {
            return "Moo";
        }


        public string SetCorrectGuessString()
        {
            return "BBBB,";
        }


        public string MakeGoal()
        {
            Random randomGenerator = new Random();
            string goal = "";
            for (int i = 0; i < 4; i++)
            {
                string randomDigit;
                do
                {
                    int random = randomGenerator.Next(10);
                    randomDigit = random.ToString();
                }
                while (goal.Contains(randomDigit));

                goal += randomDigit;
            }

            return goal;
        }


        public string GetResponseForGuess(string guess, string goal)
        {
            CheckGuess(guess, goal);

            return MakeResponseString();
        }


        private void CheckGuess(string guess, string goal)
        {
           
            if (GuessIsValid(guess))
            {
                GetBullsAndCows(guess, goal);
            }

            else
            {
                throw new GuessNotValidException("Guess must be exactly four digits.");
            }
        }

        private static bool GuessIsValid(string guess)
        {
            if (guess.Length == 4 && int.TryParse(guess, out _))
            {
                return true;
            }

            return false;
        }

        private void GetBullsAndCows(string guess, string goal)
        {
            bulls = 0;
            cows = 0;

            for (int i = 0; i < guess.Length; i++)
            {
                // istället för nested for-loop
                if (goal.Contains(guess[i]))
                {
                    if (goal.IndexOf(guess[i]) == i)
                        bulls++;
                    else
                        cows++;
                }
            }
        }

        private string MakeResponseString()
        {
            return $"{"BBBB".Substring(0, bulls)},{"CCCC".Substring(0, cows)}";
        }
    }


}
