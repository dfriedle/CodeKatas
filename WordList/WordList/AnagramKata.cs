using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace WordList
{
    internal class AnagramKata
    {
        private static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            ExecuteKata();

            stopwatch.Stop();
            Console.Out.WriteLine(stopwatch.Elapsed.TotalMilliseconds);
        }

        private static void ExecuteKata()
        {
            var words = ReadInWords();

            var anagrams = FindAnagrams(words);
            //var anagrams = FindAnagramsLinq(words);

            PrintAnagrams(anagrams);
        }

        #region Read in from file

        private static IEnumerable<string> ReadInWords()
        {
            var lines = new List<string>();
            var file = new StreamReader("wordlist.txt");

            try
            {
                string line;
                while ((line = file.ReadLine()) != null)
                    lines.Add(line);
            }
            finally
            {
                file.Close();
            }

            return lines;
        }

        #endregion

        #region Find anagrams

        private static Dictionary<string, List<string>> FindAnagrams(IEnumerable<string> words)
        {
            var anagrams = new Dictionary<string, List<string>>();
            foreach (var word in words)
            {
                var key = SortAlphabetically(word);
                if (!anagrams.ContainsKey(key))
                    anagrams[key] = new List<string>();

                anagrams[key].Add(word);
            }
            return anagrams
                .Where(anagram => anagram.Value.Count > 1)
                .ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        private static Dictionary<string, List<string>> FindAnagramsLinq(IEnumerable<string> words)
        {
            return words.GroupBy(SortAlphabetically)
                .Where(grouping => grouping.Count() > 1)
                .ToDictionary(grouping => grouping.Key, grouping => grouping.ToList());
        }

        private static string SortAlphabetically(string word)
        {
            return string.Concat(word.ToCharArray().OrderBy(c => c));
        }

        #endregion

        #region Print out to console

        private static void PrintAnagrams(Dictionary<string, List<string>> anagrams)
        {
            foreach (var anagram in anagrams)
                Console.Out.WriteLine(string.Join(", ", anagram.Value));

            Console.Out.WriteLine($"Found in total {anagrams.Count} anagrams.");
        }

        #endregion
    }
}