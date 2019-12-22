using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using src;

//day 03
namespace tests
{
    [TestClass]
    public class tests
    {
        [TestMethod]
        public void Example1_1()
        {
            var inputMoves = new List<string>();

            inputMoves = Program.Ingest(@"..\..\..\..\example1_1_input.txt");

            var moves0 = inputMoves[0].Split(",");
            var moves1 = inputMoves[1].Split(",");

            var isPartTwo = false;
            var actual = Program.Process(moves0, moves1,isPartTwo);

            var expected = 6;

            Assert.AreEqual(expected, actual); // CollectionAssert
        }

        [TestMethod]
        public void Example1_2()
        {
            var inputMoves = new List<string>();

            inputMoves = Program.Ingest(@"..\..\..\..\example1_2_input.txt");

            var moves0 = inputMoves[0].Split(",");
            var moves1 = inputMoves[1].Split(",");

            var isPartTwo = false;
            var actual = Program.Process(moves0, moves1, isPartTwo);

            var expected = 159;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example1_3()
        {
            var inputMoves = new List<string>();

            inputMoves = Program.Ingest(@"..\..\..\..\example1_3_input.txt");

            var moves0 = inputMoves[0].Split(",");
            var moves1 = inputMoves[1].Split(",");

            var isPartTwo = false;
            var actual = Program.Process(moves0, moves1, isPartTwo);

            var expected = 135;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day03_Part01()
        {
            var inputMoves = new List<string>();

            inputMoves = Program.Ingest(@"..\..\..\..\input01.txt");

            var moves0 = inputMoves[0].Split(",");
            var moves1 = inputMoves[1].Split(",");

            var isPartTwo = false;
            var actual = Program.Process(moves0, moves1, isPartTwo);

            var expected = 4981;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example2_1()
        {
            var inputMoves = new List<string>();

            inputMoves = Program.Ingest(@"..\..\..\..\example1_1_input.txt");

            var moves0 = inputMoves[0].Split(",");
            var moves1 = inputMoves[1].Split(",");

            var isPartTwo = true;
            var actual = Program.Process(moves0, moves1, isPartTwo);

            var expected = 30; // 6;

            Assert.AreEqual(expected, actual); // CollectionAssert
        }

        [TestMethod]
        public void Example2_2()
        {
            var inputMoves = new List<string>();

            inputMoves = Program.Ingest(@"..\..\..\..\example1_2_input.txt");

            var moves0 = inputMoves[0].Split(",");
            var moves1 = inputMoves[1].Split(",");

            var isPartTwo = true;
            var actual = Program.Process(moves0, moves1, isPartTwo);

            var expected = 610; // 159;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example2_3()
        {
            var inputMoves = new List<string>();

            inputMoves = Program.Ingest(@"..\..\..\..\example1_3_input.txt");

            var moves0 = inputMoves[0].Split(",");
            var moves1 = inputMoves[1].Split(",");

            var isPartTwo = true;
            var actual = Program.Process(moves0, moves1, isPartTwo);

            var expected = 410; // 135;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day03_Part02()
        {
            var inputMoves = new List<string>();

            inputMoves = Program.Ingest(@"..\..\..\..\input01.txt");

            var moves0 = inputMoves[0].Split(",");
            var moves1 = inputMoves[1].Split(",");

            var isPartTwo = true;
            var actual = Program.Process(moves0, moves1, isPartTwo);

            var expected = 164012;

            Assert.AreEqual(expected, actual);
        }

    }
}
