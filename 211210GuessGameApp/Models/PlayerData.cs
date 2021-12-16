using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _211210GuessGameApp.Models
{
    public class PlayerData
    {
        public string Name { get; set; }

        public double AverageGuesses { get; set; }

        public int PlayedGames { get; set; }

        public PlayerData(string name, double averageGuesses, int playedGames)
        {
            Name = name;
            AverageGuesses = averageGuesses;
            PlayedGames = playedGames;
        }


        public override string ToString()
        {
            return $"{Name}\t{PlayedGames}\t{Math.Round(AverageGuesses, 1)}";
        }
    }
}
