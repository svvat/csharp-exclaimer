#region Copyright statement
// --------------------------------------------------------------
// Copyright (C) 1999-2016 Exclaimer Ltd. All Rights Reserved.
// No part of this source file may be copied and/or distributed 
// without the express permission of a director of Exclaimer Ltd
// ---------------------------------------------------------------
#endregion
using System;
using System.Collections.Generic;
using DeveloperTestInterfaces;
using System.Linq;
using System.Diagnostics;
using System.Threading;

namespace DeveloperTest
{
    class readData
    {
        public ICharacterReader reader;
        public Dictionary<string, int> wordTotals;
    }

    public sealed class DeveloperTestImplementation : IDeveloperTest
    {

        private Dictionary<string, int> DictionarySort(Dictionary<string, int> dict)
        {
            var ret = dict.OrderBy(i => i.Key).OrderByDescending(i => i.Value);
            var ret2 = ret.ToDictionary<KeyValuePair<string, int>, string, int>(pair => pair.Key, pair => pair.Value);
            return ret2;
        }

        public void RunQuestionOne(ICharacterReader reader, IOutputResult output)
        {
            Dictionary<string, int> wordTotals = new Dictionary<string, int>();
            var t = new TextBuider();
            AddSortedDictionary(t.GetWords(reader), ref wordTotals);

            loadResults(output, wordTotals);

        }

        private void loadResults(IOutputResult output, Dictionary<string, int> wordTotals)
        {

            foreach (var wordTotal in wordTotals.OrderBy(i => i.Key).OrderByDescending(i => i.Value))
            {
                output.AddResult($"{wordTotal.Key} - {wordTotal.Value}");
            }
        }

        private void AddSortedDictionary(List<string> words, ref Dictionary<string, int> wordTotals)
        {

            foreach (var word in words)
            {
                string lowcaseWord = word.ToLower();

                if (!wordTotals.ContainsKey(lowcaseWord))
                    wordTotals.Add(lowcaseWord, 1);
                else
                    wordTotals[lowcaseWord]++;

            }

            wordTotals = DictionarySort(wordTotals);
        }

        public void loadWordCount(Object o)
        {
            try
            {
                var t = new TextBuider();
                readData q2Data = (readData)o;
                ICharacterReader reader = q2Data.reader;
                AddSortedDictionary(t.GetWords(q2Data.reader), ref q2Data.wordTotals);

                _completeCount++;
    
            }
            catch(Exception e)
            {
                _failCount++;
                Console.WriteLine("\nMessage ---\n{0}", e.Message);
            }
        }


        private int _completeCount = 0, _failCount = 0;
        /// <summary>
        /// This method takes an array of ICharacterReader interfaces and should perform the following operations: -
        ///   a) Access the readers in parallel and calculate the word counts split by word
        ///   b) Every ten seconds the code should output the current combined word counts in the same format as question one           
        ///   c) When all results have been calculated, the final combined results should be written to the provided implementation of IOutputResult in the same format as question one.
        /// </summary>
        /// <param name="readers"></param>
        /// <param name="output"></param>
        public void RunQuestionTwo(ICharacterReader[] readers, IOutputResult output)
        {
            Debug.WriteLine("RunQuestionTwo...");

            const int DELAYMS = 100;
            int readerCount = readers.Length;
            Dictionary<string, int> wordTotals = new Dictionary<string, int>();
            List<Dictionary<string, int>> readerOutputs = new List<Dictionary<string, int>>();
            List<Thread> activeThreads = new List<Thread>(readerCount);
            Debug.WriteLine("RunQuestionTwo...1");
            foreach (ICharacterReader reader in readers)
            {
                // fire up each reader asynchronously
                // var sortedList = GetSortedDictionary(reader);

                
                readData q2Data = new readData { reader = reader, wordTotals = wordTotals };

                Thread t = new Thread(new ParameterizedThreadStart(loadWordCount));
                activeThreads.Add(t);
                t.Start(q2Data);

            }

            Debug.WriteLine("RunQuestionTwo...2");

            while (_completeCount + _failCount < readerCount)
            {
                Thread.Sleep(DELAYMS);
                loadResults(output, wordTotals);
                Debug.WriteLine(string.Format("\nFails:{0}, success {1}", _failCount, _completeCount));
            }

            loadResults(output, wordTotals);
        }
    }
}