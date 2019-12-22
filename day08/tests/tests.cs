using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using src;

//day 08
namespace tests
{
    [TestClass]
    public class tests
    {
        [TestMethod]
        public void Day08_Part01()
        {
            var img = Program.Ingest(@"..\..\..\..\input01.txt");
            var width = 25;
            var height = 6;

            var actual = Program.Process(img, width, height);

            var expected = 2460;

            Assert.AreEqual(expected, actual); // CollectionAssert
        }
    }
}
