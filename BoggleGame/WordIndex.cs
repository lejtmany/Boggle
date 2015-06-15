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

        private ImmutableDictionary<string, ISet<string>> wordDictionary;

        public ISet<string> this[string s]
        {
            get
            {
                return GetPossibleWords(s);
            }
        }

        public WordIndex(IEnumerable<string> words)
        {
            wordDictionary = ConstructDictionary(words).ToImmutableDictionary();
        }

        private static Dictionary<string, ISet<string>> ConstructDictionary(IEnumerable<string> words)
        {
            var index = new Dictionary<string, ISet<string>>();

            foreach (string word in words)
            {
                var key = NormalizeString(String.Concat(word.OrderBy(c => c)));
                if (!index.Keys.Contains(key))
                {
                    index[key] = new HashSet<string>();
                }
                index[key].Add(NormalizeString(word));
            }
            return index;
        }


        public ISet<string> GetPossibleWords(string letters)
        {
            var wordSet = new HashSet<string>();
            letters = NormalizeString(letters);
            foreach (var key in wordDictionary.Keys)
            {
                if (key.IsContainedWithin(letters))
                    wordSet.UnionWith(wordDictionary[key]);
            }
            return wordSet;
        }

        private static string NormalizeString(string s){
            return s.ToUpper().Trim();
        }

        static void Main()
        {
            Console.WriteLine("git".IsContainedWithin("light"));
            Console.WriteLine("pall".IsContainedWithin("lamp"));
            Console.WriteLine("mace".IsContainedWithin("macee"));
            Console.ReadLine();
        }

    }

     static class Extensions
    {
        public static bool IsContainedWithin(this string s, string other)
        {
            var lookup = other.ToLookup(c=>c);
            return s.ToLookup(c => c).All(c => lookup[c.Key].Count() >= c.Count());
        }
    }

    
}
