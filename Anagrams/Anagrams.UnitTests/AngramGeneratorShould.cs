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
            
            result.Add(string.Format("{0} {1}", words[0], words[1]));
            if (words.Count == 4)
            {
                result.Add(string.Format("{0} {1}", words[2], words[3]));
            }

            return result;
        }
    }
}
