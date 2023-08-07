using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.MorseCodeTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] words = input.Split(" | ");

            Console.WriteLine(string.Join(" ", Translate(words)));
        }
        static List<string> Translate(string[] words)
        {
            Dictionary<char, string> morseCode = new Dictionary<char, string>()
            {
                {'A', ".-"},
                {'B', "-..."},
                {'C', "-.-."},
                {'D', "-.."},
                {'E', "."},
                {'F', "..-."},
                {'G', "--."},
                {'H', "...."},
                {'I', ".."},
                {'J', ".---"},
                {'K', "-.-"},
                {'L', ".-.."},
                {'M', "--"},
                {'N', "-."},
                {'O', "---"},
                {'P', ".--."},
                {'Q', "--.-"},
                {'R', ".-."},
                {'S', "..."},
                {'T', "-"},
                {'U', "..-"},
                {'V', "...-"},
                {'W', ".--"},
                {'X', "-..-"},
                {'Y', "-.--"},
                {'Z', "--.."},
                {'0', "-----"},
                {'1', ".----"},
                {'2', "..---"},
                {'3', "...--"},
                {'4', "....-"},
                {'5', "....."},
                {'6', "-...."},
                {'7', "--..."},
                {'8', "---.."},
                {'9', "----."},
                {'.', ".-.-.-"},
                {',', "--..--"},
                {'?', "..--.."},
                {'\'', ".----."},
                {'!', "-.-.--"},
                {'/', "-..-."},
                {'(', "-.--."},
                {')', "-.--.-"},
                {'&', ".-..."},
                {':', "---..."},
                {';', "-.-.-."},
                {'=', "-...-"},
                {'+', ".-.-."},
                {'-', "-....-"},
                {'_', "..--.-"},
                {'\"', ".-..-."},
                {'$', "...-..-"},
                {'@', ".--.-."},
                {' ', "/"}
            };

            List<string> message = new List<string>();
            foreach (string w in words)
            {
                string word = string.Empty;
                string[] chr = w.Split(' ');

                foreach (string c in chr)
                {
                    foreach (var d in morseCode)
                    {
                        if(c == d.Value)
                        {
                            word = word + d.Key; 
                            break;
                        }
                    }
                }

                message.Add(word);
            }
            return message;
        }
    }
}

