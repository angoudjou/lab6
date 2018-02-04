using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        public static bool checkSpecialChar(string word)
        {
            char[] special_chars = { '@', '>', '<', '-', '\\','.','+','#','&','{','}','|', '=', ',' , '/', ':', '!', '§', '%', '*','$', '£', '(',')','[',']', '_'};
            foreach (char c in special_chars)
            {
                if (word.Contains(c)) return true;
            }
            
            return false;
        }
        public static bool startWithVowel(string word)
        {
            if (word.Length >0)
            {
                char a = word[0];
                char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
                foreach (char item in vowels)
                {
                    if (item.Equals(a))
                    {
                        return true;

                    }

                }
            }
            return false;
        }
        public static bool ContainsVowel(string word)
        {
            if (word.Length > 0)
            {
                char a = word[0];
                char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
                foreach (char item in vowels)
                {
                    if (word.Contains (item))
                    {
                        return true;

                    }

                }
            }
            
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pig Latin translator");
            Console.Write("Please enter a word: ");
            Console.WriteLine();
            string word = Console.ReadLine();
            string b = TranslateWordToPigLatin(word);
            Console.WriteLine(b);
            Console.WriteLine("Enter a sentence");
            string sentence = Console.ReadLine();
            if(sentence.Length>0)
            Console.WriteLine(TranslateSentenceToPig(sentence));
            else
                Console.WriteLine("You did not enter a sentence");
            Console.ReadLine();
            
            ;
        }
        static public string TranslateSentenceToPig( string sentence)
        {
            string result = "";
            string[] sentence_break = sentence.Split(' ');

            foreach (string item in sentence_break)
            {
                if(item.Length>1)
                result += TranslateWordToPigLatin(item) + " ";
            }

            string format_result = char.ToUpper(result[0]) + result.Substring(1);
            return format_result;

        }
        static public string TranslateWordToPigLatin( string word)
        {
            int i = 0, j;
            string begn = "";
            //if the contains character is not between a-Z
            foreach (char item in word.ToCharArray())
            {
                if (int.TryParse(item.ToString(), out j)) return word;

            }

            // checks if it contains specials keys
            if (checkSpecialChar(word))
            {
                return word;
            }

            //if the word does contains vowels we return it as it is eg: By, my
            if (!ContainsVowel(word))
            {
                return word;
            }
          //  Console.WriteLine(startWithVowel(word.ToLower()));
            if (startWithVowel(word.ToLower()))
            {
              return word + "way";
            }
            else
            {
                //move all consonnant that appearear before the first vowels

                while (!startWithVowel(word.Substring(i)))
                {
                    begn += word[i];
                    i++;
                }
                //no vowel found, it may by a number
                if (i == word.Length)
                {
                    return word;
                }
                else

                    return word.Substring(i) + begn + "ay";
            }
            



        }
    }
}
