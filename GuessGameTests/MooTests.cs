using _211210GuessGameApp.Games;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessGameTests
{
    [TestClass]
    public class MooTests
    {
        MooStrategy mooStrategy;

        [TestInitialize]
        public void Init()
        {
            mooStrategy = new MooStrategy();
        }

        [TestMethod]
        public void TestSetName()
        {
            string name = mooStrategy.SetGameName();
            Assert.AreEqual("Moo", name);
        }

        [TestMethod]
        public void TestSetCorrectGuessString()
        {
            string correctGuessResponse = mooStrategy.SetCorrectGuessString();
            Assert.AreEqual("BBBB,", correctGuessResponse);
        }

        [TestMethod]
        public void TestMakeGoal_FourSignsLong()
        {
            string goal = mooStrategy.MakeGoal();
            Assert.AreEqual(4, goal.Length);
        }

        [TestMethod]
        public void TestMakeGoal_OnlyNumbers()
        {
            string goal = mooStrategy.MakeGoal();

            Assert.IsTrue(int.TryParse(goal, out int _));
        }


        //MakeGoal metoden kan ge 4 olika siffror även om koden inte ser till att det blir så,
        //kör därför MakeGoal 100 gånger.
        [TestMethod]
        public void TestMakeGoal_DifferentNumbers()
        {
            for (int i = 0; i < 100; i++)
            {
                string goal = mooStrategy.MakeGoal();
                char[] goalChars = goal.ToCharArray();

                for (int j = 0; j < goalChars.Length; j++)
                {
                    Assert.AreEqual(1, goalChars.Where(c => c == goalChars[j]).Count());
                }
            }
        }

        [TestMethod]
        public void TestGetResponseForGuess_CorrectGuess()
        {
            string respons = mooStrategy.GetResponseForGuess("1234", "1234");
            Assert.AreEqual("BBBB,", respons);
        }

        [TestMethod]
        public void TestGetResponseForGuess_WrongGuess1()
        {
            string respons = mooStrategy.GetResponseForGuess("2256", "1234");
            Assert.AreEqual("B,C", respons);
        }

        [TestMethod]
        public void TestGetResponseForGuess_WrongGuess2()
        {
            string respons = mooStrategy.GetResponseForGuess("2233", "1234");
            Assert.AreEqual("BB,CC", respons);
        }

        [TestMethod]
        public void TestGetResponseForGuess_WrongGuess3()
        {
            string respons = mooStrategy.GetResponseForGuess("4321", "1234");
            Assert.AreEqual(",CCCC", respons);
        }

        [TestMethod]
        public void TestGetResponseForGuess_WrongGuess4()
        {
            string respons = mooStrategy.GetResponseForGuess("5678", "1234");
            Assert.AreEqual(",", respons);
        }

        [TestMethod]
        public void TestGetResponseForGuess_InvalidGuess()
        {
            Assert.ThrowsException<GuessNotValidException>(() => mooStrategy.GetResponseForGuess("12345", "1234"));
        }
    }
}
