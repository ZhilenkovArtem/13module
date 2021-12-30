using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task1362
{
    class Program
    {
        static void Main()
        {
            var allText = File.ReadAllText(String.Concat(Directory.GetCurrentDirectory(), @"\Text1.txt"));
            var noPunctuationText = new string(allText.Where(c => !char.IsPunctuation(c)).ToArray());
            string[] words = noPunctuationText.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var uniqueWords = new HashSet<string>(words);
            var wordsList = new List<string>(words);
            var wordsDictionary = new Dictionary<string, int>();
            foreach (var word in uniqueWords)
            {
                var wordCountInList = wordsList.Count(w => w == word);
                wordsDictionary.Add(word, wordCountInList);
            }
            var sortedDict = from pair in wordsDictionary
                             orderby pair.Value descending
                             select pair;
            var newDict = new Dictionary<string, int>();
            int n = 0;
            foreach (var pair in sortedDict)
            {
                newDict.Add(pair.Key, pair.Value);
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
                n++;
                if (n == 10) break;
            }
            Console.ReadKey();
        }
    }
}