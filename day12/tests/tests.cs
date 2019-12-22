using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using src;

//day 06
namespace tests
{
    [TestClass]
    public class tests
    {
        [TestMethod]
        public void Day_12_Part_01_Example1_1()
        {
            var system = new SystemOfMoons();

            system.AddMoon(-1, 0, 2);
            system.AddMoon(2, -10, -7);
            system.AddMoon(4, -8, 8);
            system.AddMoon(3, 5, -1);

// step through with breakpoints, etc

            var report00 = system.MoonReport();

            system.ExecuteTimeStep();
            var report01 = system.MoonReport();

            system.ExecuteTimeStep();
            var report02 = system.MoonReport();

            system.ExecuteTimeStep();
            var report03 = system.MoonReport();

            system.ExecuteTimeStep();
            var report04 = system.MoonReport();

            system.ExecuteTimeStep();
            var report05 = system.MoonReport();

            system.ExecuteTimeStep();
            var report06 = system.MoonReport();

            system.ExecuteTimeStep();
            var report07 = system.MoonReport();

            system.ExecuteTimeStep();
            var report08 = system.MoonReport();

            system.ExecuteTimeStep();
            var report09 = system.MoonReport();

            system.ExecuteTimeStep();
            var report10 = system.MoonReport();

            var actual = 0;

            var expected = 1;

            //Assert.AreEqual(expected, actual); // CollectionAssert
            Assert.Inconclusive();
        }

        [TestMethod]
        public void Day_12_Part_01_Example1_1_B()
        {
            var system = new SystemOfMoons();

            system.AddMoon(-1, 0, 2);
            system.AddMoon(2, -10, -7);
            system.AddMoon(4, -8, 8);
            system.AddMoon(3, 5, -1);

            var report = system.MoonReport();
            var length = 10;

            for (int i = 0; i < length; i++)
            {
                system.ExecuteTimeStep();
                report = system.MoonReport();
            }

            var actual = system.TotalEnergy;

            var expected = 179;

            Assert.AreEqual(expected, actual); // CollectionAssert
        }

        [TestMethod]
        public void Day_12_Part_01()
        {
            var system = new SystemOfMoons();

            /*
<x=9, y=13, z=-8>
<x=-3, y=16, z=-17>
<x=-4, y=11, z=-10>
<x=0, y=-2, z=-2>
            */
            system.AddMoon(9, 13, -8);
            system.AddMoon(-3, 16, -17);
            system.AddMoon(-4, 11, -10);
            system.AddMoon(0, -2, -2);

            var report = system.MoonReport();
            var length = 1000;

            for (int i = 0; i < length; i++)
            {
                system.ExecuteTimeStep();
                report = system.MoonReport();
            }

            var actual = system.TotalEnergy;

            var expected = 7758;

            Assert.AreEqual(expected, actual); // CollectionAssert
        }

        [TestMethod]
        public void Day_12_Part_02_Example_1()
        {
            var system = new SystemOfMoons();

            /*
<x=9, y=13, z=-8>
<x=-3, y=16, z=-17>
<x=-4, y=11, z=-10>
<x=0, y=-2, z=-2>
            
            system.AddMoon(9, 13, -8);
            system.AddMoon(-3, 16, -17);
            system.AddMoon(-4, 11, -10);
            system.AddMoon(0, -2, -2);
            */

            system.AddMoon(-1, 0, 2);
            system.AddMoon(2, -10, -7);
            system.AddMoon(4, -8, 8);
            system.AddMoon(3, 5, -1);

            //var past = system.GetMoons();
            var original = system.MoonHash();

            BigInteger turn = 0;

            var done = false;

            while (!done)
            {
                turn++;
                system.ExecuteTimeStep();
                done = (system.MoonHash() == original);
            }

            // var r = report; //7758

            var actual = turn;

            var expected = 2772;

            Assert.AreEqual(expected, actual); // CollectionAssert
        }

        [TestMethod]
        public void Day_12_Part_02()
        {
            var system = new SystemOfMoons();

            /*
<x=9, y=13, z=-8>
<x=-3, y=16, z=-17>
<x=-4, y=11, z=-10>
<x=0, y=-2, z=-2>
*/

            system.AddMoon(9, 13, -8);
            system.AddMoon(-3, 16, -17);
            system.AddMoon(-4, 11, -10);
            system.AddMoon(0, -2, -2);

            /*
        system.AddMoon(-1, 0, 2);
        system.AddMoon(2, -10, -7);
        system.AddMoon(4, -8, 8);
        system.AddMoon(3, 5, -1);
        */

            //var past = system.GetMoons();
            var original = system.MoonHash();

            BigInteger turn = 0;

            var done = false;

            while (!done)
            {
                turn++;
                system.ExecuteTimeStep();
                done = (system.MoonHash() == original);
            }

            // var r = report; //7758

            var actual = turn;

            var expected = 0;

            Assert.AreEqual(expected, actual); // CollectionAssert
        }


        [TestMethod]
        [DataRow(0,924)]
        [DataRow(1, 2772)]
        [DataRow(2, 2772)]
        [DataRow(3, 924)]
        public void Day_12_Part_02_Example_1_Experiment_1(int id, int expected)
        {
            var system = new SystemOfMoons();

            /*
<x=9, y=13, z=-8>
<x=-3, y=16, z=-17>
<x=-4, y=11, z=-10>
<x=0, y=-2, z=-2>
            
            system.AddMoon(9, 13, -8);
            system.AddMoon(-3, 16, -17);
            system.AddMoon(-4, 11, -10);
            system.AddMoon(0, -2, -2);
            */

            system.AddMoon(-1, 0, 2);
            system.AddMoon(2, -10, -7);
            system.AddMoon(4, -8, 8);
            system.AddMoon(3, 5, -1);

            //var past = system.GetMoons();
            //var id = 3;
            var original = system.MoonHash(id);

            BigInteger turn = 0;

            var done = false;

            while (!done)
            {
                turn++;
                system.ExecuteTimeStep();
                done = (system.MoonHash(id) == original);
            }

            // var r = report; //7758

            var actual = turn;

            //var expected = 2772;
            //0:924
            //1:2772
            //2:2772
            //3:924

            Assert.AreEqual(expected, actual); // CollectionAssert
        }

        [TestMethod]
        //[DataRow(0, 100124388)] // 5 min
        [DataRow(1, 2772)]
        //[DataRow(2, 2772)]
        //[DataRow(3, 924)]
        // 4686774924
        public void Day_12_Part_02_Example_2_Experiment_2(int id, int expected)
        {
            var system = new SystemOfMoons();

            /*
<x=9, y=13, z=-8>
<x=-3, y=16, z=-17>
<x=-4, y=11, z=-10>
<x=0, y=-2, z=-2>
            
            system.AddMoon(9, 13, -8);
            system.AddMoon(-3, 16, -17);
            system.AddMoon(-4, 11, -10);
            system.AddMoon(0, -2, -2);

            system.AddMoon(-1, 0, 2);
            system.AddMoon(2, -10, -7);
            system.AddMoon(4, -8, 8);
            system.AddMoon(3, 5, -1);
            */
            system.AddMoon(-8,-10,0);
            system.AddMoon(5,5,10);
            system.AddMoon(2,-7,3);
            system.AddMoon(9,-8,-3);

            //var past = system.GetMoons();
            //var id = 3;
            var original = system.MoonHash(id);

            BigInteger turn = 0;

            var done = false;

            while (!done)
            {
                turn++;
                system.ExecuteTimeStep();
                done = (system.MoonHash(id) == original);
            }

            // var r = report; //7758

            var actual = turn;

            //var expected = 2772;
            //0:924
            //1:2772
            //2:2772
            //3:924

            // 4686774924

            Assert.AreEqual(expected, actual); // CollectionAssert
        }

    }
}
