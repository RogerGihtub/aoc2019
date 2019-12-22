using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using src;

//day 06
namespace tests
{
    [TestClass]
    public class tests
    {
        [TestMethod]
        public void Example1_1()
        {
            var inputs = new List<string>();

            inputs.Add("COM)B");

            var isPartTwo = false;
            var actual = Program.Process(inputs, isPartTwo);

            var expected = 1;

            Assert.AreEqual(expected, actual); // CollectionAssert
        }

        [TestMethod]
        public void Example1_2()
        {
            var inputs = new List<string>();

            inputs.Add("COM)B");
            inputs.Add("COM)C");

            var isPartTwo = false;
            var actual = Program.Process(inputs, isPartTwo);

            var expected = 2;

            Assert.AreEqual(expected, actual); // CollectionAssert
        }

        [TestMethod]
        public void Example1_3()
        {
            var inputs = new List<string>();

            inputs.Add("COM)B");
            inputs.Add("B)C");

            var isPartTwo = false;
            var actual = Program.Process(inputs, isPartTwo);

            var expected = 3;

            Assert.AreEqual(expected, actual); // CollectionAssert
        }

        [TestMethod]
        public void Example1_4()
        {
            var inputs = new List<string>();

            inputs.Add("COM)B");
            inputs.Add("B)C");
            inputs.Add("C)D");

            var isPartTwo = false;
            var actual = Program.Process(inputs, isPartTwo);

            var expected = 6;

            Assert.AreEqual(expected, actual); // CollectionAssert
        }

        [TestMethod]
        public void Example1_5()
        {
            var inputs = new List<string>();

            inputs = Program.Ingest(@"..\..\..\..\example1_1_input.txt");

            var isPartTwo = false;
            var actual = Program.Process(inputs, isPartTwo);

            var expected = 42;

            Assert.AreEqual(expected, actual); // CollectionAssert
        }

        [TestMethod]
        public void Example1_6()
        {
            var inputs = new List<string>();

            // just making sure the root node doesn't need to be first
            inputs = Program.Ingest(@"..\..\..\..\example1_2_input.txt");

            var isPartTwo = false;
            var actual = Program.Process(inputs, isPartTwo);

            var expected = 42;

            Assert.AreEqual(expected, actual); // CollectionAssert
        }

        [TestMethod]
        public void Day06_Part01()
        {
            var inputs = new List<string>();

            inputs = Program.Ingest(@"..\..\..\..\input01.txt");

            var isPartTwo = false;
            var actual = Program.Process(inputs, isPartTwo);

            //this takes about six minutes to run.
            var expected = 271151; 

            Assert.AreEqual(expected, actual); // CollectionAssert
        }

        [TestMethod]
        public void Example2_1()
        {
            var inputs = new List<string>();

            inputs = Program.Ingest(@"..\..\..\..\example2_1_input.txt");

            var isPartTwo = true;
            var actual = Program.Process(inputs, isPartTwo);

            var expected = 4;

            Assert.AreEqual(expected, actual); // CollectionAssert
        }

        [TestMethod]
        public void Day06_Part02()
        {
            var inputs = new List<string>();

            inputs = Program.Ingest(@"..\..\..\..\input01.txt");

            var isPartTwo = true;
            var actual = Program.Process(inputs, isPartTwo);

            //this ALSO takes about six minutes to run.
            var expected = 388;

            Assert.AreEqual(expected, actual); // CollectionAssert
        }

    }
}
