using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;

namespace BoggleGame
{

    public class WordIndex
    {

        private ImmutableDictionary<HashSet<char>, IList<string>> wordDictionary;
        
        public IEnumerable<ISet<char>> Letters
        {
            get
            {
                return new List<ISet<char>>(wordDictionary.Keys);
            }
        }

        public WordIndex(IEnumerable<string> words)
        {
            wordDictionary = ConstructDictionary(words).ToImmutableDictionary();
        }

        private static Dictionary<HashSet<char>, IList<string>> ConstructDictionary(IEnumerable<string> words)
        {
            var index = new Dictionary<HashSet<char>, IList<string>>(HashSet<char>.CreateSetComparer());

            foreach (string word in words)
            {
                HashSet<char> letters = new HashSet<char>(word);
                if (!index.Keys.Contains(letters))
                {
                    index[letters] = new List<string>();
                }
                index[letters].Add(word);
            }
            return index;
        }


        public IList<string> ListPossibleWords(ISet<char> set)
        {
            var wordList = new List<string>();
            foreach (var key in wordDictionary.Keys)
            {
                if (key.IsSubsetOf(set))
                    wordList.AddRange(wordDictionary[key]);
            }
            return wordList;
        }

    }
}
