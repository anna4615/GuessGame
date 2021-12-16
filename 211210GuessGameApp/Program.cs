using _211210GuessGameApp;
using _211210GuessGameApp.Games;
using _211210GuessGameApp.Models;
using System;
using System.Collections.Generic;

namespace GuessGameApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserInterface ui = new ConsoleUI();
            IDataAccess dao = new FileDataAccess();
            Game game = new Game();

            Dictionary<string, Func<IGameStrategy>> gameStrategies = new Dictionary<string, Func<IGameStrategy>>()
            {
                { "Moo", () => new MooStrategy() },
                { "GuessNumber", () => new GuessNumberStrategy() }
            };

            Controller controller = new Controller(ui, dao, game, gameStrategies);

            controller.Run();
        }
    }
}
