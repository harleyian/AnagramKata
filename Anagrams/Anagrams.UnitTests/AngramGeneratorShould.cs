using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Anagrams.UnitTests
{
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
            Assert.Equals(anagramList.Count, 0);
        }
    }
}
