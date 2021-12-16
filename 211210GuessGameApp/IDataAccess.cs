using _211210GuessGameApp.Models;
using System;
using System.Collections.Generic;

namespace _211210GuessGameApp
{
    public interface IDataAccess
    {
        public void SaveResult(Result result, string gameName); 
        public List<PlayerData> GetTopList(string gameName);        
    }
}
