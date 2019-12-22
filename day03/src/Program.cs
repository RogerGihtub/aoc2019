using System;
using System.Collections.Generic;

namespace src
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello World!  AoC 2019 - Day 03");

            Console.WriteLine($"Answers are in the tests.");
        }

        public static int Process(string[] moves0, string[] moves1, bool isPartTwo)
        {
            // origin determined experimentally to avoid moving out-of-bounds
            var initX = 16240;
            var initY = 13240;

            var grid = new string[20480, 20480];

            for (int x = 0; x < 20480; x++)
            {
                for (int y = 0; y < 20480; y++)
                {
                    grid[x, y] = ""; // seemed like a good idea at the time
                }
            }

            //do wire0 first
            var cur0x = initX; //origin
            var cur0y = initY; //origin

            grid[cur0x, cur0y] += "A";

            foreach (var move in moves0)
            {
                var incx = 0; //increment (or decrement)
                var incy = 0;

                //  U7,R6,D4,L4,
                var opcode = move.Substring(0, 1);

                switch (opcode)
                {
                    case "U":
                        incy = -1;
                        break;
                    case "D":
                        incy = +1;
                        break;
                    case "L":
                        incx = -1;
                        break;
                    case "R":
                        incx = +1;
                        break;
                    default:
                        // Console.WriteLine($"ERROR at {ptr}: {opcode}");
                        Console.Write($"!!! {opcode} {move}");
                        break;
                }

                var distance = move.Replace("U", "").Replace("D", "").Replace("R", "").Replace("L", "");

                int dist = 0;

                int.TryParse(distance, out dist);

                if (dist == 0)
                {
                    Console.Write($"!!! {opcode} {move} {distance}");
                }

                for (int i = 0; i < dist; i++)
                {
                    cur0x += incx;
                    cur0y += incy;
                    grid[cur0x, cur0y] += "A";
                }

            }

            //do wire1 next
            var cur1x = initX; //origin
            var cur1y = initY; //origin

            grid[cur1x, cur1y] += "B";

            foreach (var move in moves1)
            {
                var incx = 0; //increment (or decrement)
                var incy = 0;

                //  U7,R6,D4,L4,
                var opcode = move.Substring(0, 1);

                switch (opcode)
                {
                    case "U":
                        incy = -1;
                        break;
                    case "D":
                        incy = +1;
                        break;
                    case "L":
                        incx = -1;
                        break;
                    case "R":
                        incx = +1;
                        break;
                    default:
                        // Console.WriteLine($"ERROR at {ptr}: {opcode}");
                        Console.Write($"!!! {opcode} {move}");
                        break;
                }

                var distance = move.Replace("U", "").Replace("D", "").Replace("R", "").Replace("L", "");

                int dist = 0;

                int.TryParse(distance, out dist);

                if (dist == 0)
                {
                    Console.Write($"!!! {opcode} {move} {distance}");
                }

                for (int i = 0; i < dist; i++)
                {
                    cur1x += incx;
                    cur1y += incy;
                    grid[cur1x, cur1y] += "B";
                }

            }

            // now look for crosses in about the worst way possible

            var minDist = 20480 + 20480;

            for (int x = 0; x < 20480; x++)
            {
                for (int y = 0; y < 20480; y++)
                {
                    var g = grid[x, y];
                    if (g.Length > 1)
                    {
                        var xx = x;
                        var yy = y;
                        var gg = g;
                    }

                    if (grid[x, y].Contains("AB") || grid[x, y].Contains("BA"))
                    {
                        var dist = Math.Abs(x - initX) + Math.Abs(y - initY);
                        if ((dist > 0) && (dist < minDist)) minDist = dist;
                    }
                }
            }

            if (!isPartTwo) return minDist; // 4981

            // part 2 but wait there is more

            // rewalk both wires again, but this time count the steps to the intersections

            //do wire0 first
            cur0x = initX; //origin
            cur0y = initY; //origin

            var steps0 = 0;

            //grid[cur0x, cur0y] += "A";

            foreach (var move in moves0)
            {
                var incx = 0; //increment (or decrement)
                var incy = 0;

                //  U7,R6,D4,L4,
                var opcode = move.Substring(0, 1);

                switch (opcode)
                {
                    case "U":
                        incy = -1;
                        break;
                    case "D":
                        incy = +1;
                        break;
                    case "L":
                        incx = -1;
                        break;
                    case "R":
                        incx = +1;
                        break;
                    default:
                        // Console.WriteLine($"ERROR at {ptr}: {opcode}");
                        Console.Write($"!!! {opcode} {move}");
                        break;
                }

                var distance = move.Replace("U", "").Replace("D", "").Replace("R", "").Replace("L", "");

                int dist = 0;

                int.TryParse(distance, out dist);

                if (dist == 0)
                {
                    Console.Write($"!!! {opcode} {move} {distance}");
                }

                for (int i = 0; i < dist; i++)
                {
                    cur0x += incx;
                    cur0y += incy;
                    steps0 += 1;

                    var spot = grid[cur0x, cur0y];

                    if (spot.Contains("AB") || spot.Contains("BA"))
                    {
                        grid[cur0x, cur0y] += $"#{steps0}#";
                    }
                }

            }


            //do wire1 next
            cur1x = initX; //origin
            cur1y = initY; //origin

            var steps1 = 0;

            //grid[cur1x, cur1y] += "B";

            foreach (var move in moves1)
            {
                var incx = 0; //increment (or decrement)
                var incy = 0;

                //  U7,R6,D4,L4,
                var opcode = move.Substring(0, 1);

                switch (opcode)
                {
                    case "U":
                        incy = -1;
                        break;
                    case "D":
                        incy = +1;
                        break;
                    case "L":
                        incx = -1;
                        break;
                    case "R":
                        incx = +1;
                        break;
                    default:
                        // Console.WriteLine($"ERROR at {ptr}: {opcode}");
                        Console.Write($"!!! {opcode} {move}");
                        break;
                }

                var distance = move.Replace("U", "").Replace("D", "").Replace("R", "").Replace("L", "");

                int dist = 0;

                int.TryParse(distance, out dist);

                if (dist == 0)
                {
                    Console.Write($"!!! {opcode} {move} {distance}");
                }

                for (int i = 0; i < dist; i++)
                {
                    cur1x += incx;
                    cur1y += incy;
                    steps1 += 1;

                    var spot = grid[cur1x, cur1y];

                    if (spot.Contains("AB") || spot.Contains("BA"))
                    {
                        grid[cur1x, cur1y] += $"%{steps1}%";
                    }
                }
            }

            // now we go through AGAIN, looking for the stepped-out intersections,
            // calculate their steps and save the min

            var minSteps = 204800 + 204800;

            for (int x = 0; x < 20480; x++)
            {
                for (int y = 0; y < 20480; y++)
                {
                    var g = grid[x, y];

                    if (grid[x, y].Contains("#") && grid[x, y].Contains("%"))
                    {
                        var c = grid[x, y].Replace("A", "").Replace("B", "").Replace("#%", "!").Replace("%#", "!");
                        c = c.Replace("#", "").Replace("%", "");

                        var cs = c.Split("!");
                        int x1 = 0;
                        int y1 = 0;

                        int.TryParse(cs[0], out x1);
                        int.TryParse(cs[1], out y1);

                        var ts = 0;
                        if (x1 > 0 && y1 > 0)
                        {
                            ts = x1 + y1;

                            if (ts < minSteps) minSteps = ts;
                        }


                    }
                }
            }

            return minSteps; // 164012

        }

        public static List<string> Ingest(string filename)
        {

            string line;

            var arr = new List<string>();

            System.IO.StreamReader file =
                new System.IO.StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                /*var arrS = line.Split(',').ToList();

                foreach (var S in arrS)
                {
                    int i = 0;
                    int.TryParse(S, out i);
                    arr.Add(i);
                }*/
                arr.Add(line);
            }

            file.Close();

            return arr;
        }


    }
}
