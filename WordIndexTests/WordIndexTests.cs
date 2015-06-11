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
            var letterSet = new HashSet<char>("mace");
            var possibleWords = wi[letterSet];
            possibleWords.Should().OnlyContain(s => new HashSet<char>(s).IsSubsetOf(letterSet));
        }

        [TestMethod]
        public void TestIndexerWhenNoMatches()
        {
            var letterSet = new HashSet<char>("z");
            var possibleWords = wi[letterSet];
            possibleWords.Count.Should().Be(0);
        }

        [TestMethod]
        public void TestIndexerWhenCapitalsInSet()
        {
            var key = "MaCE";
            var letterSet = new HashSet<char>(key);
            var possibleWords = wi[letterSet];
            possibleWords.Should().OnlyContain(s => new HashSet<char>(s).IsSubsetOf(new HashSet<char>(key.ToLower())));
        }

    }
}
