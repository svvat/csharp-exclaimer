using DeveloperTestInterfaces;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace DeveloperTest
{
    public class TextBuider
    {
        public static List<char> GetChars(ICharacterReader reader)
        {
            List<char> chars = new List<char>();
            try
            {
                
                int idx = 0;
                char c = reader.GetNextChar();
                while (c != 0)
                {
                    chars.Add(c);
                    c = reader.GetNextChar();
                    idx++;
                }
            }
            catch (EndOfStreamException)
            {
                // end of stream
                // note some consider it bad practice to use exceptions for flow control
            }
            return chars;
        }
        public static List<string> GetWords(ICharacterReader reader)
        {
            List<string> words = new List<string>();
            var chars = TextBuider.GetChars(reader);
            
            string word = "";
            foreach (var c in chars) {
                switch (c)
                {
                    case ' ':
                    case '?':
                    case '|':
                    case ',':
                    case '.':
                    case '/':
                    case '\n':
                    case '\t':
                    case ';':
                    case '-':
                        if (word.Length > 0)
                        {
                            words.Add(word);
                            word = "";
                        }
                        break;
                    default:
                        if (c > 32) word += c;
                        break;
                }
            }
            words.Add(word);
            words.ForEach(i => Trace.Write($"{i} "));
            return words;
        }

    }
}