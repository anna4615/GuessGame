using _211210GuessGameApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _211210GuessGameApp
{
    public class FileDataAccess : IDataAccess
    {
        private readonly string path = @"C:\ITHS\Clean code\Examineringsuppgift\211210GuessGameSolution\211210GuessGameApp\Resource\";

        public void SaveResult(Result result, string gameName)
        {
            StreamWriter writer = new StreamWriter($"{path}{gameName}.txt", append: true);
            writer.WriteLine(result.PlayerName + "#&#" + result.Guesses);
            writer.Close();
        }


        public List<PlayerData> GetTopList(string gameName)
        {
            List<PlayerData> playerDatas = GetResultsForGame(gameName)
                .GroupBy(r => r.PlayerName)
                .Select(g => new PlayerData(g.Key, g.Average(r => r.Guesses), g.Count()))
                .OrderBy(p => p.AverageGuesses)
                .ToList();

            return playerDatas;
        }


        private List<Result> GetResultsForGame(string gameName)
        {
            StreamReader reader = new StreamReader($"{path}{gameName}.txt");
            List<Result> results = new List<Result>();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split("#&#");
                results.Add(new Result(data[0], int.Parse(data[1])));
            }

            reader.Close();

            return results;
        }
    }
}
