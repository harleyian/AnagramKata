using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Anagrams.UnitTests
{
    using System.Collections.Generic;

    [TestClass]
    public class AngramGeneratorShould
    {
        [TestMethod]
        public void HandlesEmptyList()
        {
            var anagramGenerator = new AnagramGenerator();
            anagramGenerator.AddDictionary(null);

            var anagramList = anagramGenerator.GetAnagrams();
            Assert.IsNotNull(anagramList);
            Assert.AreEqual(anagramList.Count, 0);
        }
    }

    public class AnagramGenerator
    {
        public void AddDictionary(object o)
        {
            
        }

        public List<String> GetAnagrams()
        {
            return  new List<string>();
        }
    }
}
