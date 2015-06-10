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

        private IImmutableDictionary<IImmutableSet<char>, IImmutableList<string>> wordDictionary;

        public WordIndex(IEnumerable<string> words)
        {
            var index = ConstructDictionary(words);

            wordDictionary = MakeDictionaryImmutable(index);
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

        private static ImmutableDictionary<IImmutableSet<char>, IImmutableList<string>> MakeDictionaryImmutable(Dictionary<HashSet<char>, IList<string>> index)
        {
            var immutableIndex = new Dictionary<IImmutableSet<char>, IImmutableList<string>>();
            foreach (HashSet<char> key in index.Keys)
            {
                immutableIndex[key.ToImmutableHashSet()] = index[key].ToImmutableList<string>();
            }
            return immutableIndex.ToImmutableDictionary();
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
