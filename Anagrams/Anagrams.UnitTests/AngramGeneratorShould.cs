using System;
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

        [TestMethod]
        public void HandlemEmptyElementsInInput()
        {
            var inputList = new List<string> { "ABC", "DEF", "ABD", "BA", "", "FED", "AB", "" };
            var anagramGenerator = new AnagramGenerator();

            var anagramList = anagramGenerator.GetAnagrams(inputList);
            Assert.IsNotNull(anagramList);
            Assert.AreEqual(anagramList.Count, 2);
            Assert.AreEqual(anagramList[0], "DEF FED");
            Assert.AreEqual(anagramList[1], "BA AB");
        }

        [TestMethod]
        public void HandleFourLetterWordInput()
        {
            var inputList = new List<string> { "ABC", "DEF", "ABD", "BA", "FED", "AB", "ABDHE" };
            var anagramGenerator = new AnagramGenerator();

            var anagramList = anagramGenerator.GetAnagrams(inputList);
            Assert.IsNotNull(anagramList);
            Assert.AreEqual(anagramList.Count, 2);
            Assert.AreEqual(anagramList[0], "DEF FED");
            Assert.AreEqual(anagramList[1], "BA AB");
        }

        [TestMethod]
        public void HandleFourLetterWordAnagrams()
        {
            var inputList = new List<string> { "ABDHE", "DABEH" };
            var anagramGenerator = new AnagramGenerator();

            var anagramList = anagramGenerator.GetAnagrams(inputList);
            Assert.IsNotNull(anagramList);
            Assert.AreEqual(anagramList.Count, 1);
            Assert.AreEqual(anagramList[0], "ABDHE DABEH");
        }

        [TestMethod]
        public void HandleFourLetterWordAnagramsWithLowerCase()
        {
            var inputList = new List<string> { "ABDHE", "DABeh" };
            var anagramGenerator = new AnagramGenerator();

            var anagramList = anagramGenerator.GetAnagrams(inputList);
            Assert.IsNotNull(anagramList);
            Assert.AreEqual(anagramList.Count, 1);
            Assert.AreEqual(anagramList[0], "ABDHE DABeh");
        }

        [TestMethod]
        public void HandleMultipleAnagramsMatching()
        {
            var inputList = new List<string>
            {
                "kinship",
                "pinkish",
                "enlist",
                "inlets",
                "listen",
                "silent",
                "random",
                "not",
                "matched"
            };

            var anagramGenerator = new AnagramGenerator();

            var anagramList = anagramGenerator.GetAnagrams(inputList);
            Assert.IsNotNull(anagramList);
            Assert.AreEqual(2, anagramList.Count);
            Assert.AreEqual("kinship pinkish", anagramList[0]);
            Assert.AreEqual("enlist inlets listen silent", anagramList[1]);
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

            var anagramsList = new Dictionary<string, List<string>>();
            var result = new List<string>();

            foreach (var word in words)
            {
                if (string.IsNullOrEmpty(word))
                {
                    continue;
                }
                var key = GetAnagramKey(word);
                if (anagramsList.ContainsKey(key))
                {
                    anagramsList[key].Add(word);
                }
                else
                {
                    anagramsList.Add(key, new List<string>{word});
                }
            }

            foreach (var key in anagramsList.Keys)
            {
                if (anagramsList[key].Count > 1)
                {
                    result.Add(string.Join(" ", anagramsList[key]));
                }
            }
            return result;
        }

        private string GetAnagramKey(string inputWord)
        {
            var chars = inputWord.ToLowerInvariant().OrderBy(x=>x);
            return string.Concat(chars);
        }
    }
}
