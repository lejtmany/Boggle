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
        private string roundLetters;
        public string RoundLetters
        {
            get
            {
                return roundLetters;
            }
        }

        public ISet<string> MatchesFound
        {
            get
            {
                return matchesFound.ToImmutableHashSet<string>();
            }
        }

        public ISet<string> MatchesNotFound
        {
            get
            {
                return possibleMatches.Except(matchesFound).ToImmutableHashSet<string>();
            }
        }

        public ISet<string> PossibleMatches
        {
            get
            {
                return possibleMatches.ToImmutableHashSet<string>();
            }
        }

        public ushort RoundSetSize { get; private set; }
        public ushort ScoreIncrement{get; private set;}

        private readonly Random rnd = new Random();

        private readonly WordIndex wordIndex;
        private ISet<string> possibleMatches;
        private ISet<string> matchesFound;

        public GameModel(WordIndex wordIndex, ushort roundSetSize = 8, ushort scoreIncrement = 10)
        {
            this.wordIndex = wordIndex;
            this.RoundSetSize = roundSetSize;
            this.ScoreIncrement = scoreIncrement;
            Score = 0;
            NewRound();
        }

        public void NewRound()
        {
            roundLetters = GetRandomSet(RoundSetSize);
            possibleMatches = wordIndex[roundLetters];
            matchesFound = new HashSet<string>();
        }


        private string GetRandomSet(int size)
        {

            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var sb = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                sb.Append(alphabet[rnd.Next((alphabet.Length - 1) + 1)]);
            }
            return sb.ToString();
        }

        public bool SubmitString(string word)
        {
            bool wordFound = CheckString(word);
            if (wordFound)
            {
                matchesFound.Add(word);
                Score += ScoreIncrement;
            }
            return wordFound;
        }

        private bool CheckString(string word)
        {
            return wordIndex[roundLetters].Contains(word);
        }


    }
}
