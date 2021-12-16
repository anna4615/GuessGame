using _211210GuessGameApp.Models;
using _211210GuessGameApp.Games;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GuessGameTests
{
    [TestClass]
    public class GameTests
    {
        Game game = new Game();

        [TestInitialize]
        public void Init()
        {
            game.InitiateGame(new MockStrategy());
        }

        [TestMethod]
        public void TestInitiateGame_SetGameName()
        {
            Assert.AreEqual("Name", game.Name);
        }

        [TestMethod]
        public void TestInitiateGame_SetCorrectGuessString()
        {
            Assert.AreEqual("Mock", game.CorrectGuessResponse);
        }

        [TestMethod]
        public void TestInitiateGame_MakeGoal()
        {
            Assert.AreEqual("1234", game.Goal);
        }

        [TestMethod]
        public void TestInitiateGame_Guesses()
        {
            Assert.AreEqual(0, game.Guesses);
        }

        [TestMethod]
        public void TestIncreaseGuesses()
        {
            game.IncreaseGuesses();
            Assert.AreEqual(1, game.Guesses);
        }

        [TestMethod]
        public void TestRepeatedIncreaseGuesses()
        {
            game.IncreaseGuesses();
            game.IncreaseGuesses();
            game.IncreaseGuesses();
            game.IncreaseGuesses();
            game.IncreaseGuesses();
            Assert.AreEqual(5, game.Guesses);
        }

        [TestMethod]
        public void TestResetGuessesOnInitialization()
        {
            game.IncreaseGuesses();
            game.IncreaseGuesses();
            game.InitiateGame(new MockStrategy());           
            Assert.AreEqual(0, game.Guesses);
        }
    }

    class MockStrategy : IGameStrategy
    {
        public string GetResponseForGuess(string guess, string goal)
        {
            throw new NotImplementedException();
        }

        public string MakeGoal()
        {
            return "1234";
        }

        public string SetCorrectGuessString()
        {
            return "Mock";
        }

        public string SetGameName()
        {
            return "Name";
        }
    }
}
