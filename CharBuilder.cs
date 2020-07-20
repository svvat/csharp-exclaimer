using DeveloperTestInterfaces;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System;

namespace DeveloperTest
{
    public class TextBuider
    {
        public List<char> GetChars(ICharacterReader reader)
        {
            List<char> chars = new List<char>();
            try
            {
                
                int idx = 0;
                char c = reader.GetNextChar();
                while (c != 0)
                {
                    chars.Add(c);
                    Debug.Write(c);
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
        public List<string> GetWords(ICharacterReader reader)
        {
            var t = new TextBuider();
            Debug.WriteLine("GetWords...1");

            List<string> words = new List<string>();
            var chars = t.GetChars(reader);
            
            string word = "";
            foreach (var c in chars) {
                switch (c)
                {
                    case ' ':
                    case '?':
                    case '|':
                    case '[':
                    case ']':
                    case ':':
                    case '(':
                    case ')':
                    case ',':
                    case '.':
                    case '\'':
                    case '/':
                    case '`':
                    case '\n':
                    case '\t':
                    case ';':
//                    case '-':
                        if (word.Length > 0)
                        {
                            word = word.ToLower();
                            if(word.Contains("--"))
                            {
                                var split=word.Split(new string[] { "--" }, StringSplitOptions.None);
                                words.Add(split[0]);
                                words.Add(split[1]);
                            }
                            else
                            {
                                words.Add(word);
                            }

                            word = "";
                        }
                        break;
                    default:
                        if (c > 32) word += c;
                        break;
                }
            }
            if(word.Length>0) words.Add(word);

            words.ForEach(i => Trace.Write($"{i} "));
            return words;
        }

    }
}