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

        private WordIndex wi =
            new WordIndex(new List<string>() { "bog", "glob", "mate", "tame", "at", "me", "sylvester", "mace", "met", "meet", "ace", "came", "macee", "a" });


        [TestMethod]
        public void TestIndexer()
        {
            var possibleWords = wi["mace"];
            int origCount = possibleWords.Count;
            possibleWords.UnionWith(new List<string>() {"MACE", "ACE", "CAME", "A", "ME"});
            int newCount = possibleWords.Count;
            origCount.ShouldBeEquivalentTo(newCount);
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
            possibleWords.Should().OnlyContain(s => new HashSet<char>(s).IsSubsetOf(new HashSet<char>("mace".ToUpper())));
        }

        [TestMethod]
        public void TestAccountsForDuplicates()
        {
            var possibleWords = wi["mace"];
            possibleWords.Should().NotContain("MACEE");
        }

    }
}
