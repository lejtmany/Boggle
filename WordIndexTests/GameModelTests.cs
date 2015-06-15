using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoggleGame;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace WordIndexTests
{
    [TestClass]
    public class GameModelTests
    {
        WordIndex wi = new WordIndex(File.ReadAllLines("WordList.txt"));
        GameModel gm;
        [TestInitialize]
        public void Setup()
        {
             gm = new GameModel(wi);
        }

        [TestMethod]
        public void TestNewLetterSetEveryTime()
        {
            var lettersList = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                gm.NewRound();
                lettersList.Add(gm.RoundLetters);
            }
            lettersList.Distinct().Count().ShouldBeEquivalentTo(lettersList.Count);
        }

        [TestMethod]
        public void TestPossibleWords()
        {
            gm.PossibleMatches.Should().OnlyContain(s => wi[gm.RoundLetters].Contains(s.ToUpper()));
        }

        [TestMethod]
        public void CorrectSubmitMatchShouldIncrementScore()
        {
            var match = gm.PossibleMatches.ElementAt(0);
            gm.SubmitString(match);
            gm.Score.ShouldBeEquivalentTo(gm.ScoreIncrement);
        }

    }


}

