using System;

namespace src
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello World!  AoC 2019 - Day 01");

            string filename = @"..\..\..\..\input01.txt";
            bool isPartTwo = false;

            var part01 = Process(filename, isPartTwo);

            Console.WriteLine(part01);

            isPartTwo = true;
            var part02 = Process(filename, isPartTwo);

            Console.WriteLine(part02);

        }

        public static int Process(string filename, bool IsPartTwo)
        {
            string line;

            var total = 0;

            System.IO.StreamReader file = new System.IO.StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                int i = 0;
                int.TryParse(line, out i);

                if (!IsPartTwo) total += CalculateFuel(i);
                if (IsPartTwo) total += CalculateFuelRecursively(i);
            }

            file.Close();

            return total;
        }

        public static int CalculateFuel(int mass)
        {
            var divby3 = mass / 3;
            var rounddown = Math.Floor((double)divby3);
            var sub2 = (int)rounddown - 2;

            return sub2;
        }

        public static int CalculateFuelRecursively(int mass)
        {
            var fuel = 0;
            var divby3 = mass / 3;
            var rounddown = Math.Floor((double)divby3);
            var sub2 = (int)rounddown - 2;

            if (sub2 < 0)
            {
                return fuel;
            }
            else
            {
                fuel += sub2;
                fuel += CalculateFuelRecursively(sub2);
            }
            return fuel;
        }


    }
}
