using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoggleGame;
using FluentAssertions;
using System.Collections.Generic;

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
            var setList = new List<ISet<char>>();
            for (int i = 0; i < 100; i++)
            {
                setList.Add(gm.RoundLetters);
                gm.NewRound();
            }
            setList.Should().OnlyHaveUniqueItems();
        }
    }
}
