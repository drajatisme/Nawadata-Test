
using ConsoleApp1.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Extensions
{
    public static class StringExtensions
    {
        public static string SeparateCharacters(this string sentence, CharacterType characterType)
        {
            if (string.IsNullOrWhiteSpace(sentence))
                return null;

            var vowels = new char[5] { 'a', 'i', 'u', 'e', 'o' };
            switch (characterType)
            {
                case CharacterType.Vowel:
                    return string.Concat(sentence.Where(w => vowels.Contains(w)));
                case CharacterType.Consonant:
                    return string.Concat(sentence.Except(vowels));
            }

            return null;
        }

        public static IEnumerable<int> ConvertToInt(this IEnumerable<string> strings)
        {
            var result = new List<int>();

            try
            {
                foreach (var item in strings)
                {
                    var itemParsed = int.Parse(item);

                    if (itemParsed > 4)
                        throw new Exception("Max Member per Family is 4 people");

                    result.Add(itemParsed);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
