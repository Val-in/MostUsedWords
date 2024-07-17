using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MostUsedWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "D:/Desktop/Text1.txt";
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                string text = string.Join(" ", lines);

                char[] separators = { ' ', ',', '.', ';', ':', '!', '?', '-', '–' };

                string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                words = words.Select(w => w.ToLower()).ToArray();

                Dictionary<string, int> wordsCount = new Dictionary<string, int>();
                foreach (string word in words)
                {
                    if (wordsCount.ContainsKey(word))
                    { 
                        wordsCount[word]++;
                    }
                    else
                    {
                        wordsCount[word] = 1;
                    }
                }

                var sortedWords = wordsCount.OrderByDescending(word => word.Value).Take(10);

                Console.WriteLine($"Top 10 most found words in the text: ");
                foreach (var word in sortedWords)
                {
                    Console.WriteLine($"{word.Key}: {word.Value} times.");
                }

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File '{filePath}' not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
