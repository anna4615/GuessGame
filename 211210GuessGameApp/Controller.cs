using _211210GuessGameApp.Models;
using _211210GuessGameApp.Games;
using System;
using System.Collections.Generic;


namespace _211210GuessGameApp
{
    public class Controller
    {
        private readonly IUserInterface _ui;
        private readonly IDataAccess _dao;
        private readonly Game _game;
        private readonly Dictionary<string, Func<IGameStrategy>> _gameStrategies;

        private enum GameNames
        {
            Moo = 1,
            GuessNumber
        }

        public Controller(IUserInterface ui, IDataAccess dao, Game game, 
            Dictionary<string, Func<IGameStrategy>> gameStrategies)
        {
            _ui = ui;
            _dao = dao;
            _game = game;
            _gameStrategies = gameStrategies;
        }

        
        public void Run()
        {
            Console.WriteLine("Enter your user name:");
            string playerName = _ui.GetInput();
            _ui.ShowOutput("");            

            do
            {
                //_game.InitiateGame(new MooStrategy());

                _ui.ShowOutput(GetGameList());
                _ui.ShowOutput("Select game number:");
                string selectedGame = SelectGame();
                _game.InitiateGame(_gameStrategies[selectedGame].Invoke());

                _ui.ShowOutput($"\nNew {_game.Name} game");

                //comment out or remove next line to play real games!
                _ui.ShowOutput("For practice, number is: " + _game.Goal + "\n");

                PlayGame();

                _ui.ShowOutput("Correct, it took " + _game.Guesses + " guesses.\n");

                _dao.SaveResult(new Result(playerName, _game.Guesses), _game.Name);

                List<PlayerData> topList = _dao.GetTopList(_game.Name);
                _ui.ShowOutput(PlayerDatasToString(topList) + "\n");
                _ui.ShowOutput("Play new game? y/n");

            }
            while (_ui.GetInput().ToLower().Trim() != "n");
        }


        private static string GetGameList()
        {
            string gameList = "";

            foreach (var game in Enum.GetValues(typeof(GameNames)))
            {
                gameList += $"{(int)game}: {game}\n";
            }

            return gameList;
        }


        private string SelectGame()
        {
            string selectedGame = _ui.GetInput();

            while (ValidGameSelect(selectedGame) == false)
            {
                _ui.ShowOutput($"Invalid input ({selectedGame}). Please, select number from list.");
                selectedGame = _ui.GetInput();
            }

            return Enum.GetName(typeof(GameNames), int.Parse(selectedGame));
        }

        private static bool ValidGameSelect(string input)
        {
            if (int.TryParse(input, out _) == false ||
                Enum.IsDefined(typeof(GameNames), int.Parse(input)) == false)
            {
                return false;
            }

            return true;
        }


        private void PlayGame()
        {
            string respons = "";

            do
            {
                string guess = _ui.GetInput().Trim();
                try
                {
                    respons = _game.Strategy.GetResponseForGuess(guess, _game.Goal);
                    _game.IncreaseGuesses();
                    _ui.ShowOutput(respons + "\n");
                }
                catch (Exception e)
                {
                    _ui.ShowOutput(e.Message + "\n");
                }

            }
            while (respons != _game.CorrectGuessResponse);
        }


        private static string PlayerDatasToString(List<PlayerData> playerDatas)
        {
            string table = "Player\tGames\tAverage\n";
            foreach (PlayerData player in playerDatas)
            {
                table += player.ToString() + "\n";
            }

            return table;
        }
    }
}
