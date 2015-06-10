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

        private WordIndex wi = new WordIndex(File.ReadAllLines("WordList.txt"));

        [TestMethod]
        public void TestSetInitializesRight()
        {
        }

        [TestMethod]
        public void TestGetPossibleWords()
        {
            var possibleWords = wi.ListPossibleWords(new HashSet<char>("mace"));
            possibleWords.ToString();
        }

    }
}
