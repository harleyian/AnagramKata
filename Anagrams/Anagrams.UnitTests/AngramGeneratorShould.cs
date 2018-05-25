﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Anagrams.UnitTests
{
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class AngramGeneratorShould
    {
        [TestMethod]
        public void HandlesNullList()
        {
            var anagramGenerator = new AnagramGenerator();

            var anagramList = anagramGenerator.GetAnagrams(null);
            Assert.IsNotNull(anagramList);
            Assert.AreEqual(anagramList.Count, 0);
        }

        [TestMethod]
        public void HandlesEmptyList()
        {
            var anagramGenerator = new AnagramGenerator();

            var anagramList = anagramGenerator.GetAnagrams(new List<string>());
            Assert.IsNotNull(anagramList);
            Assert.AreEqual(anagramList.Count, 0);
        }

        [TestMethod]
        public void FindOneAnagram()
        {
            var inputList = new List<string> { "AB", "BA" };
            var anagramGenerator = new AnagramGenerator();

            var anagramList = anagramGenerator.GetAnagrams(inputList);
            Assert.IsNotNull(anagramList);
            Assert.AreEqual(anagramList.Count, 1);
            Assert.AreEqual(anagramList[0], "AB BA");
        }

        [TestMethod]
        public void FindTwoAnagram()
        {
            var inputList = new List<string> { "AB", "BA", "CD", "DC" };
            var anagramGenerator = new AnagramGenerator();

            var anagramList = anagramGenerator.GetAnagrams(inputList);
            Assert.IsNotNull(anagramList);
            Assert.AreEqual(anagramList.Count, 2);
            Assert.AreEqual(anagramList[0], "AB BA");
            Assert.AreEqual(anagramList[1], "CD DC");
        }

        [TestMethod]
        public void FindOneNonSequentialAnagram()
        {
            var inputList = new List<string> { "AB", "CD", "BA" };

            var anagramGenerator = new AnagramGenerator();

            var anagramList = anagramGenerator.GetAnagrams(inputList);
            Assert.IsNotNull(anagramList);
            Assert.AreEqual(anagramList.Count, 1);
            Assert.AreEqual(anagramList[0], "AB BA");
        }

        [TestMethod]
        public void FindTwoAnagramsInNonSequentialOrder()
        {
            var inputList = new List<string> { "AB", "CD", "BA", "DC" };
            var anagramGenerator = new AnagramGenerator();

            var anagramList = anagramGenerator.GetAnagrams(inputList);
            Assert.IsNotNull(anagramList);
            Assert.AreEqual(anagramList.Count, 2);
            Assert.AreEqual(anagramList[0], "AB BA");
            Assert.AreEqual(anagramList[1], "CD DC");
        }

        [TestMethod]
        public void FindTwoAnagramsInNonSequentialOrderAndOneThreeLetterInput()
        {
            var inputList = new List<string> { "AB", "CD", "BA", "DC", "DCa" };
            var anagramGenerator = new AnagramGenerator();

            var anagramList = anagramGenerator.GetAnagrams(inputList);
            Assert.IsNotNull(anagramList);
            Assert.AreEqual(anagramList.Count, 2);
            Assert.AreEqual(anagramList[0], "AB BA");
            Assert.AreEqual(anagramList[1], "CD DC");
        }

        [TestMethod]
        public void FindMultipleMatchesWithDifferentLengths()
        {
            var inputList = new List<string> { "ABC", "DEF", "ABD", "BA", "FED", "AB" };
            var anagramGenerator = new AnagramGenerator();

            var anagramList = anagramGenerator.GetAnagrams(inputList);
            Assert.IsNotNull(anagramList);
            Assert.AreEqual(anagramList.Count, 2);
            Assert.AreEqual(anagramList[0], "DEF FED");
            Assert.AreEqual(anagramList[1], "BA AB");
        }

    }

    public class AnagramGenerator
    {
        public List<string> GetAnagrams(List<string> words)
        {
            if (words == null || words.Count == 0)
            {
                return new List<string>();
            }

            var result = new List<string>();

            for (int i = 0; i < words.Count; i++)
            {
                var currentWord = words[i];

                for (int j = i+1; j < words.Count; j++)
                {
                    var nextWord = words[j];
                    if (nextWord.Length != currentWord.Length)
                    {
                        continue;
                    }

                    var currentWordCharArray = currentWord.ToCharArray();

                    for (int k = 0; k < currentWordCharArray.Length; k++)
                    {
                        if (!nextWord.Contains(currentWord.ToCharArray()[k]))
                        {
                            break;
                        }

                        if (k == currentWordCharArray.Length-1)
                        {
                            result.Add(currentWord + " " + nextWord);
                        }
                        
                    }
                    
                }
            }
            return result;
        }
    }
}
