using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _211210GuessGameApp.Games
{
    public interface IGameStrategy
    {
        string SetGameName();

        string SetCorrectGuessString();

        string MakeGoal();

        string GetResponseForGuess(string guess, string goal);
    }
}
