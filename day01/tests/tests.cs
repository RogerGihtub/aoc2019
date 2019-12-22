using Microsoft.VisualStudio.TestTools.UnitTesting;
using src;


namespace tests
{
    [TestClass]
    public class tests
    {
        [TestMethod]
        public void Example2_1()
        {
            // For a mass of 14 -> 2

            var mass = 14;
            var actual = Program.CalculateFuelRecursively(mass);
            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example2_2()
        {
            // For a mass of 1969 -> 966

            var mass = 1969;
            var actual = Program.CalculateFuelRecursively(mass);
            var expected = 966;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example2_3()
        {
            // 100756 ==> 50346

            var mass = 100756;
            var actual = Program.CalculateFuelRecursively(mass);
            var expected = 50346;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example1()
        {
            // For a mass of 12, divide by 3 and round down to get 4, 
            // then subtract 2 to get 2.

            var mass = 12;
            var actual = Program.CalculateFuel(mass);
            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example2()
        {
            // For a mass of 14, dividing by 3 and rounding down still yields 4, 
            // so the fuel required is also 2.

            var mass = 14;
            var actual = Program.CalculateFuel(mass);
            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example3()
        {
            // For a mass of 1969, the fuel required is 654.

            var mass = 1969;
            var actual = Program.CalculateFuel(mass);
            var expected = 654;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example4()
        {
            // For a mass of 100756, the fuel required is 33583.

            var mass = 100756;
            var actual = Program.CalculateFuel(mass);
            var expected = 33583;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day01_Part01()
        {
            string filename = @"..\..\..\..\input01.txt";
            bool isPartTwo = false;

            var actual = Program.Process(filename, isPartTwo);
            var expected = 3295206;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day01_Part02()
        {
            string filename = @"..\..\..\..\input01.txt";
            bool isPartTwo = true;

            var actual = Program.Process(filename, isPartTwo);
            var expected = 4939939;

            Assert.AreEqual(expected, actual);
        }
    }
}
