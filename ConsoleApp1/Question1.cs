using ConsoleApp1.Enums;
using ConsoleApp1.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Q1
{
    internal static class Question1
    {
        internal static void DoWork()
        {
            Console.Write("Input one line of word(s): ");
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                return;

            var v = input.SeparateCharacters(CharacterType.Vowel);
            Console.WriteLine("Vowel Characters:");
            Process(v);

            var c = input.SeparateCharacters(CharacterType.Consonant);
            Console.WriteLine("Consonant Characters:");
            Process(c);
        }

        static string Process(string sentence)
        {
            if (string.IsNullOrWhiteSpace(sentence))
                return null;

            sentence = sentence.Trim().Replace(" ", "").ToLower();
            while (sentence.Count() > 0)
            {
                var a = sentence.First();
                Console.Write(string.Concat(sentence.Where(w => w == a)));
                sentence = sentence.Replace(a.ToString(), string.Empty);
            }

            Console.WriteLine();
            return sentence.ToLower();
        }
    }
}
