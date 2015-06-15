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

        private ImmutableDictionary<HashSet<char>, ISet<string>> wordDictionary;

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

        private static Dictionary<HashSet<char> , ISet<string>> ConstructDictionary(IEnumerable<string> words)
        {
            var index = new Dictionary<HashSet<char>, ISet<string>>(HashSet<char>.CreateSetComparer());

            foreach (string word in words)
            {
            //    var key = NormalizeString(String.Concat(word.OrderBy(c => c)));
                var key = new HashSet<char>(NormalizeString(word));
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
            var candidateKeys = GetCandidateKeys(letters);
            foreach (var key in candidateKeys)
            {
                var wordsWithin = GetSubsetWords(letters, wordDictionary[key]);
                wordSet.UnionWith(wordsWithin);
            }
            return wordSet;
        }

        private IEnumerable<string> GetSubsetWords(string letters, ISet<string> words)
        {
            var wordsWithin = from w in words
                              where w.IsContainedWithin(letters)
                              select w;
            return wordsWithin;
        }

        private IEnumerable<HashSet<char>> GetCandidateKeys(string letters)
        {
            var lettersSet = new HashSet<char>(letters);
            var candidateKeys = from k in wordDictionary.Keys
                                where k.IsSubsetOf(lettersSet)
                                select k;
            return candidateKeys;
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
