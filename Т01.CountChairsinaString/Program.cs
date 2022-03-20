using System;
using System.Collections.Generic;
using System.Linq;

namespace Т01.CountChairsinaString
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToArray();

            Dictionary<char, int> countingLetters = new Dictionary<char, int>();

            foreach (char letter in input)
            {
                if (letter != ' ')
                {
                    if (countingLetters.ContainsKey(letter) == false)
                    {
                        countingLetters.Add(letter, 1);
                    }
                    else
                    {
                        countingLetters[letter]++;
                    }
                }
            }


            foreach (var letters in countingLetters)
            {
                Console.WriteLine($"{letters.Key} -> {letters.Value}");
            }
        }
    }
}
