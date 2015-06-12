using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoggleGame;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;

namespace WordIndexTests
{
    [TestClass]
    public class GameModelTests
    {
        GameModel gm =
            new GameModel(
                new WordIndex(new List<string>() { "moat", "at", "smote", "saw", "was", "rat", "tar" }));

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

    }

    
}

