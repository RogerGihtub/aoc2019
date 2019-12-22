using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Linq;
using src;

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
        public void Example_2_1()
        {
            var filename = @"..\..\..\..\example1_3_input.txt";
            var asteroid = new Asteroid();
            var field = asteroid.IngestFile(filename);

            var fieldCounted = asteroid.GenerateCounts(field);
            var actual = asteroid.GetMaxCount(fieldCounted);
            var expected = 210;
            Assert.AreEqual(expected, actual);

            var station = asteroid.WhereIsMaxCount(fieldCounted);
            Assert.AreEqual(11, station.X);
            Assert.AreEqual(13, station.Y);

            var asteroidStation = new Asteroid();
            asteroidStation.X = station.X;
            asteroidStation.Y = station.Y;

            var myTwelve = asteroidStation.GetMyTwelveOClock();
            Assert.AreEqual(11, myTwelve.X);
            Assert.AreEqual(0, myTwelve.Y);

            var lowerRight = asteroidStation.GetLowerRightPoint(filename);
            Assert.AreEqual(19, lowerRight.X);
            Assert.AreEqual(19, lowerRight.Y);

            var borderPoints = asteroidStation.RocksAroundTheClockTonight(myTwelve, lowerRight);
            Assert.AreEqual(76, borderPoints.Count());

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

        [TestMethod]
        public void Take_Bearing_000()
        {
            var origin = new Point(2, 2);
            var target = new Point(2, 1); // due north
            var asteroid = new Asteroid();

            var actual = asteroid.TakeBearing(origin, target);

            double expected = (double)000;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Take_Bearing_090()
        {
            var origin = new Point(2, 2);
            var target = new Point(3, 2); // due east
            var asteroid = new Asteroid();

            var actual = asteroid.TakeBearing(origin, target);

            double expected = (double)090;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Take_Bearing_180()
        {
            var origin = new Point(2, 2);
            var target = new Point(2, 3); // due south
            var asteroid = new Asteroid();

            var actual = asteroid.TakeBearing(origin, target);

            double expected = (double)180;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Take_Bearing_270()
        {
            var origin = new Point(2, 2);
            var target = new Point(1, 2); // due west
            var asteroid = new Asteroid();

            var actual = asteroid.TakeBearing(origin, target);

            double expected = (double)270;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Take_Bearing_045()
        {
            var origin = new Point(2, 2);
            var target = new Point(3, 1); // due north-east
            var asteroid = new Asteroid();

            var actual = asteroid.TakeBearing(origin, target);

            double expected = (double)045;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Take_Bearing_026_5__NNE()
        {
            var origin = new Point(3, 3);
            var target = new Point(4, 1); // due north-north-east
            var asteroid = new Asteroid();

            var actual = asteroid.TakeBearing(origin, target);

            double expected = (double)026.56505117707799;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Take_Bearing_063_4__ENE()
        {
            var origin = new Point(3, 3);
            var target = new Point(5, 2); // due east-north-east
            var asteroid = new Asteroid();

            var actual = asteroid.TakeBearing(origin, target);

            double expected = (double)63.43494882292201;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Take_Bearing_135()
        {
            var origin = new Point(2, 2);
            var target = new Point(3, 3); // due south-east
            var asteroid = new Asteroid();

            var actual = asteroid.TakeBearing(origin, target);

            double expected = (double)135;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Take_Bearing_116_6__ESE()
        {
            var origin = new Point(3, 3);
            var target = new Point(5, 4); // due east-south-east
            var asteroid = new Asteroid();

            var actual = asteroid.TakeBearing(origin, target);

            double expected = (double)116.56505117707799;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Take_Bearing_153_4__SSE()
        {
            var origin = new Point(3, 3);
            var target = new Point(4, 5); // due south-south-east
            var asteroid = new Asteroid();

            var actual = asteroid.TakeBearing(origin, target);

            double expected = (double)153.43494882292202;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Take_Bearing_225()
        {
            var origin = new Point(3, 3);
            var target = new Point(2, 4); // due south-west
            var asteroid = new Asteroid();

            var actual = asteroid.TakeBearing(origin, target);

            double expected = (double)225;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Take_Bearing_206_6__SSW()
        {
            var origin = new Point(3, 3);
            var target = new Point(2, 5); // due south-south-west
            var asteroid = new Asteroid();

            var actual = asteroid.TakeBearing(origin, target);

            double expected = (double)206.56505117707798;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Take_Bearing_243_4__WSW()
        {
            var origin = new Point(3, 3);
            var target = new Point(1, 4); // due west-south-west
            var asteroid = new Asteroid();

            var actual = asteroid.TakeBearing(origin, target);

            double expected = (double)243.43494882292202;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Take_Bearing_315()
        {
            var origin = new Point(3, 3);
            var target = new Point(2, 2); // due north-west
            var asteroid = new Asteroid();

            var actual = asteroid.TakeBearing(origin, target);

            double expected = (double)315;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Take_Bearing_296_6__WNW()
        {
            var origin = new Point(3, 3);
            var target = new Point(1, 2); // due west-north-west
            var asteroid = new Asteroid();

            var actual = asteroid.TakeBearing(origin, target);

            double expected = (double)296.565051177078;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Take_Bearing_333_4__NNW()
        {
            var origin = new Point(3, 3);
            var target = new Point(2, 1); // due north-north-west
            var asteroid = new Asteroid();

            var actual = asteroid.TakeBearing(origin, target);

            double expected = (double)333.434948822922;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example_2_2()
        {
            var filename = @"C:\Temp\aoc2019\day10_02\example2_2_input.txt";
            var asteroid = new Asteroid();
            var field = asteroid.IngestFile(filename);

            var station = new Asteroid();
            station.X = 8;
            station.Y = 3;

            var bearingField = station.GenerateBearings(station, field);

            //does bearingField include station?  Nope!.
            var expected = field.Count - 1;
            var actual = bearingField.Count;
            Assert.AreEqual(expected, actual);

            var beamWidth = station.GetMinimumBearingDifference(bearingField);

            Assert.IsTrue(beamWidth < 1.1);

            var destructionField = station.DestroyAllAsteroids(bearingField, station);

            var firstDestroyedAsteroid = station.GetSpecificDestroyedAsteroid(
                destructionField, 1);
            Assert.AreEqual(station.X, firstDestroyedAsteroid.X);
            Assert.AreEqual(station.Y - 2, firstDestroyedAsteroid.Y);

            var secondDestroyedAsteroid = station.GetSpecificDestroyedAsteroid(
                destructionField, 2);
            Assert.AreEqual(station.X + 1, secondDestroyedAsteroid.X);
            Assert.AreEqual(0, secondDestroyedAsteroid.Y);

            var thirdDestroyedAsteroid = station.GetSpecificDestroyedAsteroid(
                destructionField, 3);
            Assert.AreEqual(firstDestroyedAsteroid.X + 1, thirdDestroyedAsteroid.X);
            Assert.AreEqual(firstDestroyedAsteroid.Y, thirdDestroyedAsteroid.Y);

        }

        [TestMethod]
        public void Example_2_3()
        {
            var filename = @"C:\Temp\aoc2019\day10_02\example1_3_input.txt";
            var asteroid = new Asteroid();
            var field = asteroid.IngestFile(filename);

            var station = new Asteroid();
            station.X = 11;
            station.Y = 13;

            var bearingField = station.GenerateBearings(station, field);

            //does bearingField include station?  Nope!.
            var expected = field.Count - 1;
            var actual = bearingField.Count;
            Assert.AreEqual(expected, actual);

            var beamWidth = station.GetMinimumBearingDifference(bearingField);

            Assert.IsTrue(beamWidth < 1.1);

            var destructionField = station.DestroyAllAsteroids(bearingField, station);

            var firstDestroyedAsteroid = station.GetSpecificDestroyedAsteroid(
                destructionField, 1);
            Assert.AreEqual(11, firstDestroyedAsteroid.X);
            Assert.AreEqual(12, firstDestroyedAsteroid.Y);

            var secondDestroyedAsteroid = station.GetSpecificDestroyedAsteroid(
                destructionField, 2);
            Assert.AreEqual(12, secondDestroyedAsteroid.X);
            Assert.AreEqual(1, secondDestroyedAsteroid.Y);

            var thirdDestroyedAsteroid = station.GetSpecificDestroyedAsteroid(
                destructionField, 3);
            Assert.AreEqual(12, thirdDestroyedAsteroid.X);
            Assert.AreEqual(2, thirdDestroyedAsteroid.Y);

            var asteroid_12_8 = station.GetSpecificDestroyedAsteroid(
                destructionField, 12, 8);
            //Assert.AreEqual(10, asteroid_12_8.OrderOfDestruction);

            var tenthDestroyedAsteroid = station.GetSpecificDestroyedAsteroid(
    destructionField, 10);

            var badTenthBearing = tenthDestroyedAsteroid.Bearing;

            var alongBadBearing = station.FindAsteroidsAlongBearing(
                destructionField, badTenthBearing, beamWidth * 5);

            Assert.AreEqual(12, tenthDestroyedAsteroid.X);
            Assert.AreEqual(8, tenthDestroyedAsteroid.Y);


            var twoHundredthDestroyedAsteroid = station.GetSpecificDestroyedAsteroid(
    destructionField, 200);
            Assert.AreEqual(8, twoHundredthDestroyedAsteroid.X);
            Assert.AreEqual(2, twoHundredthDestroyedAsteroid.Y);


        }

        [TestMethod]
        public void Day10_Part_02()
        {
            var asteroid = new Asteroid();
            var field = asteroid.IngestFile(
                @"..\..\..\..\input01.txt");

            var fieldCounted = asteroid.GenerateCounts(field);

            var stationPoint = asteroid.WhereIsMaxCount(field);

            var station = new Asteroid();
            station.X = stationPoint.X;
            station.Y = stationPoint.Y;

            var bearingField = station.GenerateBearings(station, field);

            //does bearingField include station?  Nope!.
            var expectedC = field.Count - 1;
            var actualC = bearingField.Count;
            Assert.AreEqual(expectedC, actualC);

            var beamWidth = station.GetMinimumBearingDifference(bearingField);

            Assert.IsTrue(beamWidth < 1.1);

            var destructionField = station.DestroyAllAsteroids(bearingField, station);

            /*
            var firstDestroyedAsteroid = station.GetSpecificDestroyedAsteroid(
                destructionField, 1);
            Assert.AreEqual(11, firstDestroyedAsteroid.X);
            Assert.AreEqual(12, firstDestroyedAsteroid.Y);

            var secondDestroyedAsteroid = station.GetSpecificDestroyedAsteroid(
                destructionField, 2);
            Assert.AreEqual(12, secondDestroyedAsteroid.X);
            Assert.AreEqual(1, secondDestroyedAsteroid.Y);

            var thirdDestroyedAsteroid = station.GetSpecificDestroyedAsteroid(
                destructionField, 3);
            Assert.AreEqual(12, thirdDestroyedAsteroid.X);
            Assert.AreEqual(2, thirdDestroyedAsteroid.Y);

            var asteroid_12_8 = station.GetSpecificDestroyedAsteroid(
                destructionField, 12, 8);
            //Assert.AreEqual(10, asteroid_12_8.OrderOfDestruction);

            var tenthDestroyedAsteroid = station.GetSpecificDestroyedAsteroid(
    destructionField, 10);

            var badTenthBearing = tenthDestroyedAsteroid.Bearing;

            var alongBadBearing = station.FindAsteroidsAlongBearing(
                destructionField, badTenthBearing, beamWidth * 5);

            Assert.AreEqual(12, tenthDestroyedAsteroid.X);
            Assert.AreEqual(8, tenthDestroyedAsteroid.Y);
            */

            var twoHundredthDestroyedAsteroid = station.GetSpecificDestroyedAsteroid(
    destructionField, 200);

            var actual = (twoHundredthDestroyedAsteroid.X * 100)
                + twoHundredthDestroyedAsteroid.Y;

            var expected = 1707;

            Assert.AreEqual(expected, actual);


        }
    }
}
