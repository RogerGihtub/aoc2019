using Microsoft.VisualStudio.TestTools.UnitTesting;
using src;

//day 04
namespace tests
{
    [TestClass]
    public class tests
    {
        [TestMethod]
        public void Example1_1()
        {
            var input = 111111;

            var isPartTwo = false;
            var actual = Program.Process(input,isPartTwo);

            var expected = true;

            Assert.AreEqual(expected, actual); // CollectionAssert
        }

        [TestMethod]
        public void Example1_2()
        {
            var input = 223450;

            var isPartTwo = false;
            var actual = Program.Process(input, isPartTwo);

            var expected = false;

            Assert.AreEqual(expected, actual); // CollectionAssert
        }

        [TestMethod]
        public void Example1_3()
        {
            var input = 123789;

            var isPartTwo = false;
            var actual = Program.Process(input, isPartTwo);

            var expected = false;

            Assert.AreEqual(expected, actual); // CollectionAssert
        }

        [TestMethod]
        public void Example1_4()
        {
            var lower = 111110;
            var upper = 111113;

            var isPartTwo = false;
            var actual = Program.ProcessRange(lower, upper, isPartTwo);

            var expected = 3;

            Assert.AreEqual(expected, actual); // CollectionAssert
        }

        [TestMethod]
        public void Day04_Part01()
        {
            // Your puzzle input: 168630-718098.

            var lower = 168630;
            var upper = 718098;

            var isPartTwo = false;
            var actual = Program.ProcessRange(lower, upper, isPartTwo);

            var expected = 1686;

            Assert.AreEqual(expected, actual); // CollectionAssert
        }

        [TestMethod]
        public void Day04_Part02()
        {
            // Your puzzle input: 168630-718098.

            var lower = 168630;
            var upper = 718098;

            var isPartTwo = true;
            var actual = Program.ProcessRange(lower, upper, isPartTwo);

            var expected = 1145;

            Assert.AreEqual(expected, actual); // CollectionAssert
        }

    }
}
