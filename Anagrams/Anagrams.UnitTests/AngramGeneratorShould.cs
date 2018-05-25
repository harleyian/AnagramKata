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
        public void HandlesEmptyList()
        {
            var anagramGenerator = new AnagramGenerator();

            var anagramList = anagramGenerator.GetAnagrams(null);
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

    }

    public class AnagramGenerator
    {
        public List<string> GetAnagrams(List<string> words)
        {
            if (words == null)
            {
                return new List<string>();
            }

            var result = new List<string>();
            result.Add(string.Format("{0} {1}", words[0], words[1]));
            
            return result;
        }
    }
}
