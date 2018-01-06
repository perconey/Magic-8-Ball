using System;
using System.Diagnostics;
using Magic8Ball.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MagicTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ReadTest()
        {
            //Arrange
            var ret = SentenceImporter.ImportSentences();
            //Act
            foreach(var el in ret)
            {
                Console.WriteLine(el);
            }
            //Assert
        }
    }
}
