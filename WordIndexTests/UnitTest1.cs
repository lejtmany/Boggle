using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoggleGame;
using System.Collections.Generic;
using FluentAssertions;


namespace WordIndexTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSetInitializesRight()
        {
            var index = WordIndex.CreateIndex(new List<string>{ "racecar", "carrace", "bob", "rope", "pore"});
            index.Count.Should().Be(3);
        }
    }
}
