using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;
using System.IO;

namespace BoggleGame
{
    public class GameModel
    {
        public uint Score { get; private set; }
        public ISet<char> RoundLetters
        {
            get
            {
                return new HashSet<char>(roundLetters);
            }
        }

        private readonly WordIndex wordList;
        private readonly IList<HashSet<char>> randomSets;

        private HashSet<char> roundLetters;
        private ISet<string> possibleMatches;
        private ISet<string> matchesFound;

        public GameModel(string filePath)
        {
            wordList = new WordIndex(File.ReadAllLines(filePath));
            randomSets = GetRandomSets();
            InitRound();
        }

        private void InitRound()
        {
            roundLetters = randomSets[0];
            possibleMatches = wordList[roundLetters];
            matchesFound = new HashSet<string>();
        }

        private IList<HashSet<char>> GetRandomSets()
        {
            var rnd = new Random();
            IList<HashSet<char>> sizedSets = (from s in wordList.Keys
                                              where s.Count >= 4 && s.Count <= 10
                                              select s).ToList();
            //shuffle list
            sizedSets.OrderBy(item => rnd.Next());

            return sizedSets;
        }

        public bool SubmitString(string word)
        {
            bool wordFound = CheckString(word);
            if (wordFound)
            {
                matchesFound.Add(word);
            }
            return wordFound;
        }

        private bool CheckString(string word)
        {
            return wordList[roundLetters].Contains(word);
        }


    }
}
