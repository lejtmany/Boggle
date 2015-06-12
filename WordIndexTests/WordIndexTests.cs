using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoggleGame;
using System.Collections.Generic;
using FluentAssertions;
using System.IO;


namespace WordIndexTests
{
    [TestClass]
    public class WordIndexTests
    {
        //       WordIndex wi = new WordIndex(File.ReadAllLines(Directory.GetCurrentDirectory))

        private WordIndex wi =
            new WordIndex(new List<string>() { "bog", "glob", "mate", "tame", "at", "me", "sylvester", "mace" });


        [TestMethod]
        public void TestIndexer()
        {
            var possibleWords = wi["mace"];
            possibleWords.Should().OnlyContain(s => new HashSet<char>(s).IsSubsetOf("mace"));
        }

        [TestMethod]
        public void TestIndexerWhenNoMatches()
        {
            var possibleWords = wi["z"];
            possibleWords.Count.Should().Be(0);
        }

        [TestMethod]
        public void TestIndexerWhenCapitalsInSet()
        {
            var possibleWords = wi["MaCE"];
            possibleWords.Should().OnlyContain(s => new HashSet<char>(s).IsSubsetOf(new HashSet<char>("mace".ToLower())));
        }

    }
}
