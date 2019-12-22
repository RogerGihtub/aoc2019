using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using src;

//day 06
namespace tests
{
    [TestClass]
    public class tests
    {
        [TestMethod]
        public void Simplify_Test_1_1()
        {
            int[] inputs = new int[] { 1, 1 };

            int[] expected = new int[] { 1, 1 };

            var asteroid = new Asteroid();

            asteroid.Simplify(inputs);

            CollectionAssert.AreEqual(expected, inputs); // CollectionAssert
        }

        [TestMethod]
        public void Simplify_Test_neg1_neg1()
        {
            int[] inputs = new int[] { -1, -1 };

            int[] expected = new int[] { -1, -1 };

            var asteroid = new Asteroid();

            asteroid.Simplify(inputs);

            CollectionAssert.AreEqual(expected, inputs); // CollectionAssert
        }

        [TestMethod]
        public void Simplify_Test_1_0()
        {
            int[] inputs = new int[] { 1, 0 };

            int[] expected = new int[] { 1, 0 };

            var asteroid = new Asteroid();

            asteroid.Simplify(inputs);

            CollectionAssert.AreEqual(expected, inputs); // CollectionAssert
        }

        [TestMethod]
        public void Simplify_Test_3_2()
        {
            int[] inputs = new int[] { 3, 2 };

            int[] expected = new int[] { 3, 2 };

            var asteroid = new Asteroid();

            asteroid.Simplify(inputs);

            CollectionAssert.AreEqual(expected, inputs); // CollectionAssert
        }

        [TestMethod]
        public void Simplify_Test_4_2()
        {
            int[] inputs = new int[] { 4, 2 };

            int[] expected = new int[] { 2, 1 };

            var asteroid = new Asteroid();

            asteroid.Simplify(inputs);

            CollectionAssert.AreEqual(expected, inputs); // CollectionAssert
        }

        [TestMethod]
        public void Simplify_Test_neg4_2()
        {
            int[] inputs = new int[] { -4, 2 };

            int[] expected = new int[] { -2, 1 };

            var asteroid = new Asteroid();

            asteroid.Simplify(inputs);

            CollectionAssert.AreEqual(expected, inputs); // CollectionAssert
        }

        [TestMethod]
        public void Simplify_Test_neg3_2()
        {
            int[] inputs = new int[] { -3, 2 };

            int[] expected = new int[] { -3, 2 };

            var asteroid = new Asteroid();

            asteroid.Simplify(inputs);

            CollectionAssert.AreEqual(expected, inputs); // CollectionAssert
        }

        [TestMethod]
        public void Simplify_Test_neg1_2()
        {
            int[] inputs = new int[] { -1, 2 };

            int[] expected = new int[] { -1, 2 };

            var asteroid = new Asteroid();

            asteroid.Simplify(inputs);

            CollectionAssert.AreEqual(expected, inputs); // CollectionAssert
        }

        [TestMethod]
        public void Simplify_Test_neg3_neg6()
        {
            int[] inputs = new int[] { -3, -6 };

            int[] expected = new int[] { -1, -2 };

            var asteroid = new Asteroid();

            asteroid.Simplify(inputs);

            CollectionAssert.AreEqual(expected, inputs); // CollectionAssert
        }

        [TestMethod]
        public void IntegralPoints_None_Between_The_Same()
        {
            var a = new Point(0, 0);
            var b = new Point(0, 0);

            var asteroid = new Asteroid();

            var between = asteroid.IntegralPointsBetweenPoints(a, b);

            Assert.AreEqual(0, between.Count); // CollectionAssert
        }

        [TestMethod]
        public void IntegralPoints_None_Between_Adjacent()
        {
            var a = new Point(0, 0);
            var b = new Point(1, 1);

            var asteroid = new Asteroid();

            var between = asteroid.IntegralPointsBetweenPoints(a, b);

            Assert.AreEqual(0, between.Count); // CollectionAssert
        }

        [TestMethod]
        public void IntegralPoints_One_Between_1_1_and_3_3()
        {
            var a = new Point(1, 1);
            var b = new Point(3, 3);

            var asteroid = new Asteroid();

            var between = asteroid.IntegralPointsBetweenPoints(a, b);

            Assert.AreEqual(1, between.Count); // CollectionAssert

            var pt = between.First();

            Assert.AreEqual(2, pt.X);
            Assert.AreEqual(2, pt.Y);

        }

        [TestMethod]
        public void IntegralPoints_One_Between_3_3_and_1_1()
        {
            var a = new Point(3, 3);
            var b = new Point(1, 1);

            var asteroid = new Asteroid();

            var between = asteroid.IntegralPointsBetweenPoints(a, b);

            Assert.AreEqual(1, between.Count); // CollectionAssert

            var pt = between.First();

            Assert.AreEqual(2, pt.X);
            Assert.AreEqual(2, pt.Y);
        }

        [TestMethod]
        public void IntegralPoints_Two_Between_1_1_and_4_7()
        {
            var a = new Point(1, 1);
            var b = new Point(4, 7);

            var asteroid = new Asteroid();

            var between = asteroid.IntegralPointsBetweenPoints(a, b);

            Assert.AreEqual(2, between.Count); // CollectionAssert

            var pt = between[0];

            Assert.AreEqual(2, pt.X);
            Assert.AreEqual(3, pt.Y);

            var pt2 = between[1];

            Assert.AreEqual(3, pt2.X);
            Assert.AreEqual(5, pt2.Y);
        }

        [TestMethod]
        public void Example_1_1()
        {
            var asteroid = new Asteroid();
            var field = asteroid.IngestFile(@"..\..\..\..\example1_1_input.txt");

            var fieldCounted = asteroid.GenerateCounts(field);

            var actual = asteroid.GetMaxCount(fieldCounted);

            var expected = 8;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example_1_2()
        {
            var asteroid = new Asteroid();
            var field = asteroid.IngestFile(
                @"..\..\..\..\example1_2_input.txt");

            var fieldCounted = asteroid.GenerateCounts(field);

            var actual = asteroid.GetMaxCount(fieldCounted);

            var expected = 33;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example_1_3()
        {
            var asteroid = new Asteroid();
            var field = asteroid.IngestFile(
                @"..\..\..\..\example1_3_input.txt");

            var fieldCounted = asteroid.GenerateCounts(field);

            var actual = asteroid.GetMaxCount(fieldCounted);

            var expected = 210;

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Day10_Part_01()
        {
            var asteroid = new Asteroid();
            var field = asteroid.IngestFile(
                @"..\..\..\..\input01.txt");

            var fieldCounted = asteroid.GenerateCounts(field);

            var actual = asteroid.GetMaxCount(fieldCounted);

            var expected = 256;

            Assert.AreEqual(expected, actual);
        }
    }
}
